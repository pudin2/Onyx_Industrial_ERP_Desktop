Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel


Public Class OLD_frmMovInventario
  Private mWhere As String
  Private obXml As New clManejoXML
  Private strProveedor As String
  Private mEntradaFrmAdmin As Boolean
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private dtProveedores As Data.DataTable
  Private strNombreProducto As String
  Private strCodInventario As String
  Private dtProducto As Data.DataTable
  Private mTipoMov As Integer
  Private strMotivo_Id As Integer

  Private mUsuarioId As Integer, mTipoConsola As String

  Public Property UsuarioId As Integer
    Get
      Return mUsuarioId
    End Get
    Set(ByVal value As Integer)
      mUsuarioId = value
    End Set
  End Property

  Public Property TipoConsola As String
    Get
      Return mTipoConsola
    End Get
    Set(ByVal value As String)
      mTipoConsola = value
    End Set
  End Property

'Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

'    'If txtCantidad.Text <> "" Then

'    Dim obMov As New clMovimiento
'    Dim obCntv As New clConectividad
'    Dim blnSeleccionado As Boolean = False
'    Dim Ff As Integer

'    Dim selectedItem As DataRowView
'    selectedItem = cmbProductos.SelectedItem

'    'Dim CabMov_ID = selectedItem("Salida_CabMov_ID").ToString()

'    For Ff = 0 To grDetalle.Rows.Count - 1
'      If grDetalle.Item(5, Ff).Value = True Then
'        Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

'        NuevaFila("CabMov_ID") = 0
'        NuevaFila("id") = Ff + 1
'        NuevaFila("Producto_ID") = CInt(grDetalle.Item(6, Ff).Value) '  .Rows(Ff).Cells(4).ToString
'        NuevaFila("Cantidad") = grDetalle.Item(4, Ff).Value
'        NuevaFila("Unidad_ID") = grDetalle.Item(7, Ff).Value


'        obMov.DetMovimiento.AddDetMovRow(NuevaFila)
'        blnSeleccionado = True
'      End If
'    Next

'    Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(numero),0)+1 [Maximo]", "Maximo", "CabMov", "Motivo_ID = 3", strCadena)
'    Dim CabOrden_Id = obCntv.LeerValorSencillo("CabOrden_Id", "CabMov", "id=" & mCabMov_Id, strCadena)
'    obMov.GrabarMovimiento(strCadena, strMotivo_Id, NuevoMov, 1, dtpFecha.Value, "A", txtObservacion.Text, CabOrden_Id)

'    Dim strMsg As String = "Datos guardados correctamente!" & vbCrLf & "Se generó la nota de entrada: " & NuevoMov
'    MessageBox.Show(strMsg, "Guardado...", MessageBoxButtons.OK, MessageBoxIcon.Information)

'End Sub

  Private Sub frmMovInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad

    obCntv.CadenaDeConeccion = My.Settings.cnnModProd
    dtProducto = obCntv.LlenarDataTable(My.Settings.cnnModProd, False, "pa_ProductosTerminadosOEnProceso", "", "dt_ProductosTerminadosOEnProceso")

    cmbProducto.DataSource = dtProducto 'obCntv.LlenarDataTable(My.Settings.cnnModProd, False, "pa_ProductosTerminadosOEnProceso", "", "dt_ProductosTerminadosOEnProceso")
    cmbProducto.DisplayMember = "Descripcion"


    cmbMotivo.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Motivos", "Estado='A'", "Order by Id")
    cmbMotivo.DisplayMember = "Descripcion"


    'cmbMotivo.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "MMotivoProd", "Estado='A'", "Order by Id")
    'cmbMotivo.DisplayMember = "Descripcion"


  End Sub

  Private Sub cmbProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cmbProducto.SelectedIndexChanged

        Dim selectedItem As DataRowView
        selectedItem = cmbProducto.SelectedItem
        Dim strCadena As String = My.Settings.cnnModProd

        txtCosto.Text = CDec("0").ToString(FCTO_U)

        Dim objCntv As New clConectividad

        Dim strFuenteCostoMP As String = objCntv.LeerValorSencillo("valor", "parametros", "id=8", strCadena)

        Dim drValor As MSSQL.SqlDataReader

        If UCase(strFuenteCostoMP) = "ZIUR" Then
            drValor = objCntv.EjecutaComando("exec CalcularCostoPromedioModProd " & selectedItem("id").ToString, strCadena, True)
        Else
            drValor = objCntv.EjecutaComando("exec pa_BuscaCostoMP '" & selectedItem("CodInventario").ToString & "',1", strCadena, True)
        End If

        drValor.Read()
        txtCosto.Text = CDec(drValor.Item("CostoProm").ToString).ToString(FCTO_U)
        strNombreProducto = selectedItem("Descripcion2").ToString
        strCodInventario = selectedItem("CodInventario").ToString
        lblTipoUnidad.Text = selectedItem("NomUnidad").ToString

    End Sub


  Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnAdicionar.Click

        Dim objItem As System.Data.DataRowView
        objItem = cmbProducto.SelectedItem

        Try
            strNombreProducto = cmbProducto.SelectedItem("Descripcion2").ToString  'cmbProducto.Text

        Catch ex As NullReferenceException
            strNombreProducto = cmbProducto.Text

        Catch ex As Exception
            Call ManejoError(Me.Name, "btnAdicionar.Click", ex)
            MessageBox.Show("Se ha presentado el siguiente error: " & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        If txtCantidad.Text <> "" Then

            Dim strFilaNueva() As String = {grMovInventario.Rows.Count + 1,
                                            strCodInventario.ToString,
                                            strNombreProducto.ToString,
                                            CDec(txtCantidad.Text.ToString).ToString(FCANT),
                                            "UN"}

            grMovInventario.Rows.Add(strFilaNueva)
            txtCantidad.Text = ""
            txtCosto.Text = ""
            txtDescItem.Text = ""

            'Call Calcular()
            strCodInventario = ""
        Else
            MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub ManejoError(ByVal mFrm As String, ByVal mSub As String, ByVal mErr As Exception)
        Dim obLog As New clLog
        obLog.NombreArchivo = Application.StartupPath & "\ModProdLog.txt"
        obLog.EscribirLog("/------- INICIO EVENTO -----------------------------------------------------------------------------------/")
        obLog.EscribirLog("Error en " & mFrm & ": Sub " & mSub & ":")
        obLog.EscribirLog(mErr.Message)
        obLog.EscribirLog(mErr.StackTrace)
        obLog.EscribirLog("/------- FIN EVENTO -----------------------------------------------------------------------------------/")
        obLog.EscribirLog("")

        obLog = Nothing
    End Sub

    Private Sub cmbProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
        If e.KeyCode = Keys.F3 Then
            If e.Modifiers = Keys.Control Then
                Call BuscarItem(cmbProducto.Text, , True)
            Else
                Call BuscarItem(cmbProducto.Text)
            End If

        ElseIf e.KeyCode = Keys.F9 Then
            Call BuscarItem("%")

            'ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
            '   Call BuscarItem(cmbProducto.Text, , True)
        End If
    End Sub

    Private Sub cmbProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles cmbProducto.KeyPress

        strCodInventario = ""
    End Sub

    Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional ByVal bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbProducto.BackColor
        cmbProducto.BackColor = Color.Yellow
        cmbProducto.Text = strMensaje  '"Buscando ..."
        cmbProducto.Refresh()

        Dim dtFiltrado As Data.DataTable

        If bolAvanzada = False Then
          dtFiltrado = dtProducto.Clone
          strFiltro = "descripcion like '%" & strFiltro & "%'"
          Dim result() As DataRow = dtProducto.Select(strFiltro)

          For Each row As DataRow In result
            dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5))
            mCnt = mCnt + 1
          Next

          If mCnt = 0 Then
              MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              Call BuscarItem("%", "Actualizando ...")
          End If

        Else 'ENTRADA AL FILTRO AVANZADO
            Dim obCntv As New clConectividad

            strFiltro = "'" & strFiltro & "'"

            dtFiltrado = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "pa_ProductosTerminadosOEnProceso", strFiltro, "dt_ProductosTerminadosOEnProceso")


        End If

        cmbProducto.DataSource = dtFiltrado
        cmbProducto.DisplayMember = "Descripcion"

        cmbProducto.BackColor = mColor
        cmbProducto.Refresh()

    End Sub



  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Call GrabarMovimiento()
  End Sub


  Private Sub cmbMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivo.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbMotivo.SelectedItem

    strMotivo_Id = selectedItem("Id").ToString
    mTipoMov = selectedItem("Naturaleza").ToString

    If mTipoMov = 1 Then
      rbtEntrada.Checked = True
    Else
      rbtSalida.Checked = True
    End If


    Dim obCntv As New clConectividad

    cmbTipoDocumento.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "documentosxmotivo", "Estado='A' and motivo_id=" & strMotivo_Id, "")
    cmbTipoDocumento.DisplayMember = "TipoDoc"
    'cmbMotivo.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Motivos", "Estado='A'", "Order by Id")
    'cmbMotivo.DisplayMember = "Descripcion"

    obCntv = Nothing

  End Sub

  Private Sub txtDocumento_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtDocumento.Validating
    If txtDocumento.Text = "" Then Exit Sub
      If IsNumeric(sender.text.ToString) = False Then
              MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              e.Cancel = True
      End If
  End Sub


    Private Sub txtCantidad_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtCantidad.Validating
    If txtCantidad.Text = "" Then Exit Sub
      If IsNumeric(sender.text.ToString) = False Then
              MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              e.Cancel = True
      End If
  End Sub



  Private Sub btnBuscarDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarDoc.Click
    If txtDocumento.Text <> "" Then
      Call CargarDocumento()
    Else
    grpAddMateriales.Enabled = True

    End If
  End Sub


  Private Sub CargarDocumento()
      If cmbTipoDocumento.Text = "Sub Tareas" Then
        Dim obCntv As New clConectividad

        'Valido que no tengo movimiento previo
        If obCntv.LeerValorSencillo("Count(1) [Cant]", "Cant", "CabMov", _
          "TipoDoc='ST' and NumDocumento=" & txtDocumento.Text, My.Settings.cnnModProd) > 1 Then

          MessageBox.Show("Este movimiento ya se encuentra registrado" & vbCrLf & "Debe ser anulado primero!", _
            "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Exit Sub

        End If



        Dim dtDetSubT As DataTable
        dtDetSubT = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_DetSubT", "Tipo='ST' and cab_Id=" & txtDocumento.Text, "order by id")

        Dim ff As Integer

        For ff = 0 To dtDetSubT.Rows.Count - 1
          Dim strFilaNueva() As String
          strFilaNueva =
            {dtDetSubT.Rows(ff).Item("Id"),
              dtDetSubT.Rows(ff).Item("Inventario_Id"),
              dtDetSubT.Rows(ff).Item("CodInventario"),
              CDec(dtDetSubT.Rows(ff).Item("Cant")).ToString(FCANT),
              "UN"
          }

          grMovInventario.Rows.Add(strFilaNueva)

        Next

        Call FormatoGrilla()

        grpAddMateriales.Enabled = False

      End If
  End Sub

  Private Sub FormatoGrilla()
    With grMovInventario
      .Columns("colCant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End With
  End Sub

  Private Sub GrabarMovimiento()
    Dim obMov As New clMovimiento
    Dim obCntv As New clConectividad
    Dim blnSeleccionado As Boolean = False
    Dim Ff As Integer

    'Dim selectedItem As DataRowView
    'selectedItem = cmbProductos.SelectedItem

    'Dim CabMov_ID = selectedItem("Salida_CabMov_ID").ToString()

    For Ff = 0 To grMovInventario.Rows.Count - 1
      'If grMovInventario.Item(5, Ff).Value = True Then
        Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

        NuevaFila("CabMov_ID") = 0
        NuevaFila("id") = Ff + 1
        'NuevaFila("Producto_ID") = CInt(grMovInventario.Item(6, Ff).Value) '  .Rows(Ff).Cells(4).ToString
        NuevaFila("Cantidad") = grMovInventario.Item("colCant", Ff).Value
        NuevaFila("Unidad_ID") = 1 ' grMovInventario.Item("colUM", Ff).Value
        NuevaFila("Inventario_ID") = grMovInventario.Item("colCodInventario", Ff).Value
        NuevaFila("Estado") = "A"

        obMov.DetMovimiento.AddDetMovRow(NuevaFila)
        blnSeleccionado = True
      'End If
    Next

    Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(Id),0)+1 [Maximo]", "Maximo", "CabMov", "1=1", My.Settings.cnnModProd)
    Dim CabOrden_Id = 0 'obCntv.LeerValorSencillo("CabOrden_Id", "CabMov", "id=" & mCabMov_Id, strCadena)
    obMov.GrabarMovimiento(My.Settings.cnnModProd, strMotivo_Id, NuevoMov, 1, dtpFecha.Value, "A", _
      txtObservacion.Text, CabOrden_Id, mUsuarioId, "ST", txtDocumento.Text)

    Dim strMsg As String = "Datos guardados correctamente!" & vbCrLf & "Se generó la nota de entrada: " & NuevoMov
    MessageBox.Show(strMsg, "Guardado...", MessageBoxButtons.OK, MessageBoxIcon.Information)




  End Sub



Private Sub txtDocumento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDocumento.KeyDown
    If e.KeyCode = Keys.Enter Then
       Call CargarDocumento()
 End If
End Sub

Private Sub txtDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDocumento.TextChanged

End Sub

Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click

End Sub

Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click

End Sub
End Class