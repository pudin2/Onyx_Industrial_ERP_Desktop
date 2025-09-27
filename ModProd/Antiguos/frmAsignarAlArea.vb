
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient


Public Class frmAsignarAlArea

  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private strCadena As String, mNumCotiza As Integer = 0
  Private dtEmpleados As Data.DataTable


Private Sub frmAsignarAlArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim obConectividad As New clConectividad

    Me.Cursor = Cursors.WaitCursor
    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString

    obConectividad.CadenaDeConeccion = strCadena

    cmbOrdenes.DataSource = obConectividad.LlenarDataTable(strCadena, "id, Observacion", "CabOrden", "estado like 'V'")
    cmbOrdenes.DisplayMember = "id"

    'cmbMotivo.DataSource = obConectividad.LlenarDataTable(strCadena, "NCorto + ' - ' + Descripcion [Mostrar]", "Motivos", "estado = 'A'")
    'cmbMotivo.DisplayMember = "Mostrar"

    cmbArea.DataSource = obConectividad.LlenarDataTable(strCadena, "id, nombre", "AreasPlanta", "id>1 and estado='A'")
    cmbArea.DisplayMember = "nombre"

    dtEmpleados = obConectividad.LlenarDataTable(strCadena, "idcliente, NombreCompleto, NombreCompleto2", "vw_empleados", _
                                                             "esactivo = 1", "order by nombrecompleto2")
    cmbEmpleados.DataSource = dtEmpleados
    cmbEmpleados.DisplayMember = "NombreCompleto2" : cmbEmpleados.ValueMember = "idcliente"


    obConectividad = Nothing
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub cmbOrdenes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbOrdenes.KeyPress

  End Sub

  

Private Sub cmbOrdenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrdenes.SelectedIndexChanged
    'Dim selectedItem As DataRowView
    'selectedItem = cmbOrdenes.SelectedItem
    'Dim CabOrden_ID = selectedItem(0).ToString()

    Call CargarOrden()
  End Sub

  Private Sub CargarOrden(Optional ByVal CabOrden_ID As String = "")

    If CabOrden_ID = "" Then
      Dim selectedItem As DataRowView
      selectedItem = cmbOrdenes.SelectedItem
      'Dim CabOrden_ID = selectedItem(0).ToString()
      CabOrden_ID = selectedItem(0).ToString()
    End If
    Dim obCntv As New clConectividad

    grDetalle.DataSource = obCntv.LlenarDataTable(strCadena, "CodInventario, Descripcion, Cantidad, [Cantidad Asignada], NomUnidad, [Cantidad por Asignar], [Entregar al Area], [Producto_ID], [Unidad_ID]", _
     "vw_ConsultarDetalleOrden", "caborden_id=" & CabOrden_ID)

    Dim MyEstilo As New DataGridViewCellStyle
    MyEstilo.BackColor = Color.Cyan

    grDetalle.Columns(0).ReadOnly = True : grDetalle.Columns(0).DefaultCellStyle = MyEstilo
    grDetalle.Columns(1).ReadOnly = True : grDetalle.Columns(1).DefaultCellStyle = MyEstilo
    grDetalle.Columns(2).ReadOnly = True : grDetalle.Columns(2).DefaultCellStyle = MyEstilo
    grDetalle.Columns(3).ReadOnly = True : grDetalle.Columns(3).DefaultCellStyle = MyEstilo
    grDetalle.Columns(4).ReadOnly = True : grDetalle.Columns(4).DefaultCellStyle = MyEstilo
    grDetalle.Columns(6 + 1).Visible = False : grDetalle.Columns(7 + 1).Visible = False
    grDetalle.Columns(2).DefaultCellStyle.Format = FCANT
    grDetalle.Columns(3).DefaultCellStyle.Format = FCANT
    grDetalle.Columns(4 + 1).DefaultCellStyle.Format = FCANT
    'grDetalle.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


    Dim Ff As Integer
    For Ff = 0 To 7
      grDetalle.Columns(Ff).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
    Next

    'CARGO LOS DATOS DE LA COTIZACION
    Call CargarCotizacion(CabOrden_ID)


    For Ff = 0 To grDetalle.RowCount - 1
      If TxtADec(grDetalle.Item("Cantidad por Asignar", Ff).Value) <= 0 Then
        grDetalle.Item(6, Ff).ReadOnly = True
        grDetalle.Item(5, Ff).ReadOnly = True
      End If
    Next
    'TxtADec(grProductos.Item(3, Ff).Value)


  End Sub

  Private Function TxtADec(ByVal strTxt As String) As Decimal
    TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
  End Function

Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
  Dim obMov As New clMovimiento
  Dim obCntv As New clConectividad
  Dim blnSeleccionado As Boolean = False
  Dim Ff As Integer

  For Ff = 0 To grDetalle.Rows.Count - 1
      If grDetalle.Item("Entregar al Area", Ff).Value = True Then
        Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

        NuevaFila("CabMov_ID") = 0
        NuevaFila("id") = Ff + 1
        NuevaFila("Producto_ID") = CInt(grDetalle.Item("Producto_ID", Ff).Value) '  .Rows(Ff).Cells(4).ToString
        NuevaFila("Cantidad") = grDetalle.Item("Cantidad por Asignar", Ff).Value
        NuevaFila("Unidad_ID") = grDetalle.Item("Unidad_ID", Ff).Value


        obMov.DetMovimiento.AddDetMovRow(NuevaFila)
        blnSeleccionado = True
      End If
  Next

  If blnSeleccionado = True Then
      Dim selectedItem As DataRowView
      selectedItem = cmbOrdenes.SelectedItem
      Dim CabOrden_ID = selectedItem(0).ToString()

      'LLAVE PARA EL AREA
      selectedItem = cmbArea.SelectedItem
      Dim AreaID = selectedItem(0).ToString

      selectedItem = cmbEmpleados.SelectedItem
      Dim strEmpleado_Id As String = selectedItem("idcliente").ToString

      Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(numero),0)+1 [Maximo]", "Maximo", "CabMov", "Motivo_ID = 2", strCadena)
      obMov.GrabarMovimiento(strCadena, 2, NuevoMov, AreaID, dtpFecha.Value, "A", txtObservacion.Text, CabOrden_ID, strEmpleado_Id)

      Dim strNumeroSalida As String = obCntv.LeerValorSencillo("[Salida al Area] as NumeroSalida", "NumeroSalida", "vw_ConsultaMov", "Motivo_ID = 2 and cabmov_id=" & NuevoMov, strCadena)
      Dim strMensaje As String = "Datos guardados correctamente!" & vbCrLf & "Documento generado: " & strNumeroSalida

      MessageBox.Show(strMensaje, "Guardando...", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Call CargarOrden()

  Else
    MessageBox.Show("Debe seleccionar los items para el área!", "Asignar al área", MessageBoxButtons.OK, MessageBoxIcon.Error)

  End If
  End Sub

  Private Sub grDetalle_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalle.CellEndEdit
    If e.ColumnIndex = 5 Then
      If grDetalle.Item(e.ColumnIndex, e.RowIndex).Value > grDetalle.Item(2, e.RowIndex).Value - grDetalle.Item(3, e.RowIndex).Value Then
        MessageBox.Show("Cantidad excede el valor por asignar!", "Cantidad no valida", MessageBoxButtons.OK, MessageBoxIcon.Error)
        grDetalle.Item(e.ColumnIndex, e.RowIndex).Value = grDetalle.Item(2, e.RowIndex).Value - grDetalle.Item(3, e.RowIndex).Value
      End If


    End If


  End Sub



  Private Sub grDetalle_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grDetalle.DataError
     MessageBox.Show(e.Exception.Message, "Se ha presentado un error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    'If (e.Context = DataGridViewDataErrorContexts.Commit) _
    '    Then
    '    MessageBox.Show("Commit error")
    'End If
    'If (e.Context = DataGridViewDataErrorContexts _
    '    .CurrentCellChange) Then
    '    MessageBox.Show("Cell change")
    'End If
    'If (e.Context = DataGridViewDataErrorContexts.Parsing) _
    '    Then
    '    MessageBox.Show("parsing error")
    'End If
    'If (e.Context = _
    '    DataGridViewDataErrorContexts.LeaveControl) Then
    '    MessageBox.Show("leave control error")
    'End If

    'If (TypeOf (e.Exception) Is ConstraintException) Then
    '    Dim view As DataGridView = CType(sender, DataGridView)
    '    view.Rows(e.RowIndex).ErrorText = "an error"
    '    view.Rows(e.RowIndex).Cells(e.ColumnIndex) _
    '        .ErrorText = "an error"

    '    e.ThrowException = False
    'End If
  End Sub

Private Sub cmdValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidar.Click
    Dim Frm As New frmMov

    Frm.strMotivo_ID = "2"
    Frm.ShowDialog()
    Call CargarOrden()
End Sub


  Private Sub CargarCotizacion(ByVal mNumOrden As Integer)


    Dim Orden As Integer = mNumOrden

    Dim objCntv As New clConectividad
    Dim strConsulta As String = "Select "

    'CARGA LA CABECERA
    Dim drCabCotiza As MSSQL.SqlDataReader = _
    objCntv.LeerValor("*", "vw_ConsultaOTconCotizacion", "CabOrden_Id ='" & mNumOrden & "'", strCadena)

    If drCabCotiza.HasRows = True Then

      lblCotizacion.Text = drCabCotiza.Item("NumCotizacion").ToString
      lblCliente.Text = drCabCotiza.Item("NombreCliente").ToString
      txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
    End If




  End Sub

  Private Sub cmbEmpleados_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbEmpleados.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbEmpleados.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")
    End If
  End Sub
  
  


  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...")
    Dim mCnt As Integer = 0
    Dim mColor As Color = cmbEmpleados.BackColor
    cmbEmpleados.BackColor = Color.Yellow
    cmbEmpleados.Text = strMensaje  '"Buscando ..."
    cmbEmpleados.Refresh()
    strFiltro = "NombreCompleto2 like '%" & strFiltro & "%'"

    Dim result() As DataRow = dtEmpleados.Select(strFiltro)
    Dim dtFiltrado As Data.DataTable = dtEmpleados.Clone
    'ComboBox1.DisplayMember = "Descripcion"

    For Each row As DataRow In result
      'ComboBox1.Items.Add(row(2))
      'Dim filaNueva As DataRow =
      dtFiltrado.Rows.Add(row(0), row(1), row(2))
      mCnt = mCnt + 1
    Next

    If mCnt = 0 Then
      MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Call BuscarItem("%", "Actualizando ...")
    End If

    cmbEmpleados.DataSource = dtFiltrado
    cmbEmpleados.DisplayMember = "NombreCompleto2"

    cmbEmpleados.BackColor = mColor
    cmbEmpleados.Refresh()

  End Sub

  
  
  
  
End Class
