Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Drawing.Printing




Public Class frmGastosMontaje
Private dtProveedores As Data.DataTable
Private strProveedor As String
Private dtDetPosicion As Data.DataTable
Private mInventarioID As Integer, mFilaEnEdicion As Integer

Public mUsuarioId As String
Private strNombreProveedor As String


Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click

        If flyPanelBotones.Width = 190 Then
            flyPanelBotones.Width = 45
            'grpDetalle.Width = grpDetalle.Width + (190 - 45)
        Else
            flyPanelBotones.Width = 190
            'grpDetalle.Width = grpDetalle.Width - (190 - 45)
        End If

End Sub

Public Sub CargaCrearDtDetPosicion()
   'CREO LA TABLA EN MEMORIA DE LOS DETALLES DE LAS POCIONES
    dtDetPosicion = CrearDtDetPosicion()
End Sub

Private Sub frmGastosMontaje_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim obCntv As New clConectividad, mTipoGastosTransp As String

    ''CREO LA TABLA EN MEMORIA DE LOS DETALLES DE LAS POCIONES
    'dtDetPosicion = CrearDtDetPosicion()
    Call CargaCrearDtDetPosicion()

    'Call CargaTipoGastos()

    'EL OPTION POR DEFECTO PARA EL USUARIO
    If UCase(My.Settings.OptDefaultGastosMontaje) = "TRANSPORTE" Then
      'EL FILTRO A LA GRILLA PARA CUANDO SON SOLO TRANSPORTES
      mTipoGastosTransp = " AND ID IN (" & obCntv.LeerValorSencillo("Valor", "Parametros", "descripcion='TipoGastosTransp'", My.Settings.cnnModProd) & ")"
      optTransporte.Checked = True
    Else
      optAnticipo.Checked = True
      mTipoGastosTransp = ""

    End If

    'CREO LA TABLA EN MEMORIA DE LOS DETALLES DE LAS POCIONES
    dtDetPosicion = CrearDtDetPosicion()

    'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
    grTipoGastos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "id, Nombre, Estado , Valor", "vw_TipoGastos", "Estado=0" & mTipoGastosTransp)
    Dim miCol As DataGridViewColumn
    miCol = grTipoGastos.Columns("Id") : miCol.Width = 20
    miCol = grTipoGastos.Columns("Nombre") : miCol.Width = 80
    miCol = grTipoGastos.Columns("Valor") : miCol.Width = 80 : miCol.ReadOnly = False
    miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    miCol = grTipoGastos.Columns("Estado") : miCol.Width = 20 : miCol.ReadOnly = False


    miCol = grDetPosicion.Columns("colValor") : miCol.Width = 80 : miCol.ReadOnly = False
    miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    'LA CARGA DE LOS PROVEEDORES
    dtProveedores = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Proveedores", "esactivo=1", "Order by Nombre1")
    cmbProveedores.DataSource = dtProveedores
    cmbProveedores.DisplayMember = "NombreCompleto"
    obCntv = Nothing

End Sub

Private Sub CargaTipoGastos()
  Dim obCntv As New clConectividad, mTipoGastosTransp As String


    If optTransporte.Checked = True Then ' UCase(My.Settings.OptDefaultGastosMontaje) = "TRANSPORTE" Then
      'EL FILTRO A LA GRILLA PARA CUANDO SON SOLO TRANSPORTES
      mTipoGastosTransp = " AND ID IN (" & obCntv.LeerValorSencillo("Valor", "Parametros", "descripcion='TipoGastosTransp'", My.Settings.cnnModProd) & ")"
      'optTransporte.Checked = True
    Else
      'optAnticipo.Checked = True
      mTipoGastosTransp = ""

    End If


    'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
    grTipoGastos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "id, Nombre, Estado , Valor", "vw_TipoGastos", "Estado=0" & mTipoGastosTransp)

   obCntv = Nothing

End Sub


Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedores.SelectedIndexChanged
  Dim selectedItem As DataRowView
  selectedItem = cmbProveedores.SelectedItem

  strProveedor = selectedItem("idCliente").ToString

  strNombreProveedor = selectedItem("NombreCompleto").ToString

End Sub

Private Sub cmbProveedores_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProveedores.KeyDown
      If e.KeyCode = Keys.F3 Then
              If e.Modifiers = Keys.Control Then
                  Call BuscarItem(cmbProveedores.Text, , True)
              Else
                  Call BuscarItem(cmbProveedores.Text)
              End If

      ElseIf e.KeyCode = Keys.F9 Then
              Call BuscarItem("%")

              'ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
              '   Call BuscarItem(cmbProducto.Text, , True)
      End If
  End Sub

  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional ByVal bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbProveedores.BackColor
        cmbProveedores.BackColor = Color.Yellow
        cmbProveedores.Text = strMensaje  '"Buscando ..."
        cmbProveedores.Refresh()


        Dim dtFiltrado As Data.DataTable


        'If bolAvanzada = False Then
          dtFiltrado = dtProveedores.Clone
          strFiltro = "nombrecompleto like '%" & strFiltro & "%'"
          Dim result() As DataRow = dtProveedores.Select(strFiltro)

          For Each row As DataRow In result
            dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11), row(12))
            mCnt = mCnt + 1
          Next

          If mCnt = 0 Then
              MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              Call BuscarItem("%", "Actualizando ...")
              cmbProveedores.BackColor = mColor
              cmbProveedores.Refresh()

          Else
              cmbProveedores.DataSource = dtFiltrado
              cmbProveedores.DisplayMember = "Descripcion"
              cmbProveedores.BackColor = mColor
              cmbProveedores.Refresh()
          End If

    End Sub


    Function CrearDtDetPosicion() As DataTable
        ' Crear una nueva DataTable
        Dim miDataTable As New DataTable()

        ' Agregar las columnas a la DataTable
        miDataTable.Columns.Add("cOT", GetType(Integer))
        miDataTable.Columns.Add("cDescripcion", GetType(String))
        miDataTable.Columns.Add("cValor", GetType(Decimal))
        miDataTable.Columns.Add("cInventarioID", GetType(Integer))
        miDataTable.Columns.Add("cOTCab_Id", GetType(Integer))

       ' Devolver la DataTable
        Return miDataTable
    End Function

    Private Function TotalValor(ByVal cInventarioID As Integer) As Decimal
      Dim ff As Integer, mTotal As Decimal

      For ff = 0 To dtDetPosicion.Rows.Count - 1
        If dtDetPosicion.Rows(ff).Item("cInventarioID") = cInventarioID Then
          mTotal = mTotal + dtDetPosicion.Rows(ff).Item("cValor")
        End If
      Next
      Return mTotal
    End Function


    Sub AddFilaDtDetPosicion(ByRef dataTable As DataTable, ByVal cOT As Integer, ByVal cDescripcion As String, _
      ByVal cValor As Decimal, ByVal cInventarioID As Integer, ByVal cOTCab_Id As Integer)
        ' Crear una nueva fila
        Dim nuevaFila As DataRow = dataTable.NewRow()

        ' Establecer los valores de las columnas para la nueva fila
        nuevaFila("cOT") = cOT
        nuevaFila("cDescripcion") = cDescripcion
        nuevaFila("cValor") = cValor
        nuevaFila("cInventarioID") = cInventarioID
        nuevaFila("cOTCab_Id") = cOTCab_Id

        ' Agregar la fila a la DataTable
        dataTable.Rows.Add(nuevaFila)
    End Sub

Private Sub grDetPosicion_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles grDetPosicion.CellEndEdit

  If (e.ColumnIndex = 0 Or e.ColumnIndex = 2) Then  'grDetPosicion.Columns("colValor").Index Then
    Dim mOTCabId As Integer
    ' Obtener la fila editada
    Dim filaEditada As DataGridViewRow = grDetPosicion.Rows(e.RowIndex)

    ' Obtener el valor de la celda "colValor"
    Dim valorCelda As Object = filaEditada.Cells(e.ColumnIndex).Value 'filaEditada.Cells("colValor").Value



    ' Validar si el valor es un número
    Dim mValorCeldaEditada As Decimal
    If Decimal.TryParse(Convert.ToString(valorCelda), mValorCeldaEditada) Then
        'ACA VALIDO QUE EXISTA LA OT, SOLAMENTE PERMITO LA PALABRA COMERCIAL
        If e.ColumnIndex = 0 Then
          If UCase(filaEditada.Cells("colOT").Value) <> "COMERCIAL" Then

            mOTCabId = BuscaOT(filaEditada.Cells("colOT").Value)

            'SI NO SE ENCONTRO NADA
            If mOTCabId = 0 Then
                MessageBox.Show("No existe este número de OT!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                ' Cancelar la edición de la celda
                filaEditada.Cells("colOT").Value = DBNull.Value ' Puedes restaurar el valor original o asignar DBNull.Value para dejar la celda vacía
                grDetPosicion.CancelEdit()
                Exit Sub
            End If
          End If
        End If

        ' Obtener los valores de las otras celdas editadas
        Dim cOT As Integer = mOTCabId  'Convert.ToInt32(filaEditada.Cells("colOT").Value)
        Dim cDescripcion As String = Convert.ToString(filaEditada.Cells("colDesc").Value)
        Dim cInventarioID As Integer = Convert.ToInt32(mInventarioID)
        Dim cValor As Decimal = Convert.ToDecimal(filaEditada.Cells("colValor").Value)

        ' Agregar la fila al DataTable
        If filaEditada.Cells("colEditada").Value <> "SI" Then 'cuando es nueva la fila
            AddFilaDtDetPosicion(dtDetPosicion, cOT, cDescripcion, cValor, cInventarioID, mOTCabId)
            filaEditada.Cells("colEditada").Value = "SI"
            filaEditada.Cells("colInventarioID").Value = mInventarioID
            filaEditada.Cells("colPKDt").Value = dtDetPosicion.Rows.Count - 1
            filaEditada.Cells("colCab_Id").Value = mOTCabId
        Else
            Call UpdateFilaDtDetPosicion(dtDetPosicion, filaEditada.Cells("colPKDt").Value, cOT, cDescripcion, cValor, cInventarioID)
        End If

        grTipoGastos.Item("Valor", mFilaEnEdicion).Value = TotalValor(filaEditada.Cells("colInventarioID").Value)

    Else
      If e.ColumnIndex = 0 And UCase(filaEditada.Cells("colOT").Value) <> "COMERCIAL" Then

        ' Mostrar un mensaje de error o tomar alguna acción en caso de que el valor no sea un número
        MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        ' Cancelar la edición de la celda
        filaEditada.Cells(e.ColumnIndex).Value = DBNull.Value ' Puedes restaurar el valor original o asignar DBNull.Value para dejar la celda vacía

        grDetPosicion.CancelEdit()
      End If
    End If

  Else
    'SI SE EDITAN OTRAS COLUMNAS
     ' Obtener la fila editada
        Dim filaEditada As DataGridViewRow = grDetPosicion.Rows(e.RowIndex)

        'Manejo el tema COMERCIAL
        Dim mOTCabId As Integer = 0
        If UCase(filaEditada.Cells("colOT").Value) <> "COMERCIAL" Then
          mOTCabId = BuscaOT(filaEditada.Cells("colOT").Value)
        End If

        ' Obtener los valores de las celdas editadas
        'Dim cOT As Integer = Convert.ToInt32(filaEditada.Cells("colOT").Value)
        Dim cOT As String = mOTCabId  'Convert.ToString(filaEditada.Cells("colOT").Value)
        Dim cDescripcion As String = Convert.ToString(filaEditada.Cells("colDesc").Value)
        'Dim cValor As Decimal = Convert.ToDecimal(filaEditada.Cells("colValor").Value)

        Dim cValor As Decimal

        If filaEditada.Cells("colValor").Value IsNot DBNull.Value AndAlso Not IsDBNull(filaEditada.Cells("colValor").Value) Then
            cValor = Convert.ToDecimal(filaEditada.Cells("colValor").Value)
        Else
            ' Manejar el caso en el que la celda tiene un valor DBNull
            ' Puedes asignar un valor predeterminado a cValor o tomar alguna otra acción apropiada.
        End If



        Dim cInventarioID As Integer = Convert.ToInt32(mInventarioID)

        If filaEditada.Cells("colEditada").Value <> "SI" Then 'cuando es nueva la fila
            AddFilaDtDetPosicion(dtDetPosicion, cOT, cDescripcion, cValor, cInventarioID, mOTCabId)
            filaEditada.Cells("colEditada").Value = "SI"
            filaEditada.Cells("colInventarioID").Value = mInventarioID
            filaEditada.Cells("colPKDt").Value = dtDetPosicion.Rows.Count - 1
            filaEditada.Cells("colCab_Id").Value = mOTCabId
        Else
            Call UpdateFilaDtDetPosicion(dtDetPosicion, filaEditada.Cells("colPKDt").Value, cOT, cDescripcion, cValor, cInventarioID)
        End If

    grTipoGastos.Item("Valor", mFilaEnEdicion).Value = TotalValor(filaEditada.Cells("colInventarioID").Value)

  End If
End Sub



    Sub UpdateFilaDtDetPosicion(ByRef dataTable As DataTable, ByVal mFf As Integer, ByVal cOT As Integer, ByVal cDescripcion As String, ByVal cValor As Decimal, ByVal cInventarioID As Integer)
        ' Crear una nueva fila
        Dim nuevaFila As DataRow = dataTable.Rows(mFf)

        ' Establecer los valores de las columnas para la nueva fila
        nuevaFila("cOT") = cOT
        nuevaFila("cDescripcion") = cDescripcion
        nuevaFila("cValor") = cValor
        nuevaFila("cInventarioID") = cInventarioID

        ' Agregar la fila a la DataTable
        'dataTable.Rows.
    End Sub
Private Sub grTipoGastos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grTipoGastos.CellEnter
    mInventarioID = grTipoGastos.Item("id", e.RowIndex).Value
    mFilaEnEdicion = e.RowIndex

    Label1.Text = mInventarioID

    Dim Ff As Integer
    grDetPosicion.Rows.Clear()

    For Ff = 0 To dtDetPosicion.Rows.Count - 1
      Dim mFila As DataRow = dtDetPosicion.Rows(Ff)

      If mFila("cInventarioID") = mInventarioID Then
        Dim strFilaNueva() As String = {
              mFila("cOT"),
              mFila("cDescripcion"),
              mFila("cValor"),
              "SI",
              mFila("cInventarioID"),
              Ff
            }

          grDetPosicion.Rows.Add(strFilaNueva)
      End If
    Next

    grTipoGastos.Item("Valor", mFilaEnEdicion).Value = TotalValor(mInventarioID)


End Sub


Private Sub optTransporte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optTransporte.CheckedChanged, optAnticipo.CheckedChanged
    Call CargaTipoGastos()
End Sub


Private Sub GrabarSolicitudCompra(ByVal strCab_Id As String)
    Dim Ff As Integer, obCntv As New clConectividad
    'Dim obCompras As New clCompras

    For Ff = 0 To dtDetPosicion.Rows.Count - 1
      Dim mFila As DataRow = dtDetPosicion.Rows(Ff)
        'GENERO LA SOLPED SI: SE SELECCIONA PARA COMPRA, SE HA REVISADO Y SI NO SE HA REPORTADO ANTES
        'If grProductosRevisados.Item("colComprar2", Ff).Value = True And grProductosRevisados.Item("colRevisado2", Ff).Value = True And _
        'grProductosRevisados.Item("colSTRevisado2", Ff).Value.ToString <> "E" Then
              Dim obCompras As New clCompras
              Dim NuevaFila = obCompras.TablaDetSolicitud.NewDetSolicitudRow
              NuevaFila("Cab_Id") = mFila("cOTCab_Id")
              NuevaFila("Id") = Ff + 1
              NuevaFila("CodInventario") = "TRANSPORTE " & mFila("cDescripcion")
              NuevaFila("Inventario_ID") = mFila("cInventarioID")
              NuevaFila("Cant") = 1
              NuevaFila("Estado") = "R"
              NuevaFila("FechaRequerida") = Date.Now()
              NuevaFila("DescItem") = strNombreProveedor
              NuevaFila("costo") = mFila("cValor")

              obCompras.TablaDetSolicitud.AddDetSolicitudRow(NuevaFila)

              Dim mTipoDoc As String = "OT"
              If mFila("cOTCab_Id") = 0 Then mTipoDoc = "PM"



              Dim maxId As String = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CabSolicitud", "1=1", My.Settings.cnnModProd)
              obCompras.GrabarSolicitud(My.Settings.cnnModProd, maxId.ToString, Today, mFila("cOTCab_Id"), Date.Now, "R", mTipoDoc, mUsuarioId)
              obCompras = Nothing
        'End If
    Next

    MessageBox.Show("Solicitud guardada con éxito!", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Call FrmInicial()
    obCntv = Nothing

End Sub

Private Sub FrmInicial()
  dtDetPosicion.Rows.Clear()
  grDetPosicion.Rows.Clear()
  Call BuscarItem("%")

  Dim ff As Integer

  For ff = 0 To grTipoGastos.Rows.Count - 1
    grTipoGastos.Item("Valor", ff).Value = 0
  Next




End Sub


Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Call GrabarSolicitudCompra(1)
End Sub


Private Function BuscaOT(ByVal mNumOrden As String) As Integer
  Dim obCntv As New clConectividad

  Dim mOTCabId As String = obCntv.LeerValorSencillo("OTCabCotizacion_Id [ID]", "ID", "CabOT", "NumOrden='" & mNumOrden & "'", My.Settings.cnnModProd)
  If mOTCabId = "" Then
    BuscaOT = 0
  Else
    BuscaOT = mOTCabId
  End If
  'Return mOTCabId

End Function


Private Sub frmGastosMontaje_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try
End Sub
End Class