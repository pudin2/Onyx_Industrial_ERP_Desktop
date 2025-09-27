Imports System.Configuration



Public Class frmAgregarMP

  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal


Private strCadena As String

Private Sub frmAgregarMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim obConectividad As New clConectividad

  strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString

  obConectividad.CadenaDeConeccion = strCadena

  cmbOrdenes.DataSource = obConectividad.LlenarDataTable(strCadena, "id, Observacion", "CabOrden", "estado like 'V'")
  cmbOrdenes.DisplayMember = "id"

    cmbProducto.DataSource = obConectividad.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    'cmbProducto.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosZiurMP", "id>0")
    cmbProducto.DisplayMember = "Descripcion"



  obConectividad = Nothing

End Sub

  

Private Sub cmbOrdenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrdenes.SelectedIndexChanged

    Dim selectedItem As DataRowView
    selectedItem = cmbOrdenes.SelectedItem

    Dim CabOrden_ID = selectedItem(0).ToString()
    Dim obCntv As New clConectividad

    'grDetalle.DataSource = obCntv.LlenarDataTable(strCadena, "CodInventario, Descripcion, Cantidad, NomUnidad, [Cantidad para Area], [Entregar al Area], [Producto_ID], [Unidad_ID]", _
    '  "vw_ConsultarDetalleOrden", "caborden_id=" & CabOrden_ID)

    grDetalle.DataSource = obCntv.LlenarDataTable(strCadena, "CodInventario, Descripcion, Cantidad, [Cantidad Asignada], NomUnidad, [Cantidad por Asignar], [Entregar al Area], [Producto_ID], [Unidad_ID]", _
      "vw_ConsultarDetalleOrden", "caborden_id=" & CabOrden_ID)


    Dim MyEstilo As New DataGridViewCellStyle

    'MyEstilo.BackColor = Color.Silver
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


End Sub



Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
  Dim obMov As New clMovimiento
  Dim obCntv As New clConectividad
  Dim blnSeleccionado As Boolean = False
  Dim Ff As Integer

    For Ff = 0 To grDetalleNuevo.Rows.Count - 1
      If grDetalleNuevo.Item(5, Ff).Value = True Then
        Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

        NuevaFila("CabMov_ID") = 0
        NuevaFila("id") = Ff + 1
        NuevaFila("Producto_ID") = CInt(grDetalleNuevo.Item("IdInventario", Ff).Value) '  .Rows(Ff).Cells(4).ToString
        NuevaFila("Cantidad") = grDetalleNuevo.Item("colCantidad", Ff).Value
        NuevaFila("Unidad_ID") = grDetalleNuevo.Item("IdUnidad", Ff).Value


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
      Dim AreaID = 1 'El area por default (SIN ASIGNAR) 'selectedItem(0).ToString



      Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(numero),0)+1 [Maximo]", "Maximo", "CabMov", "Motivo_ID = 1", strCadena)
      obMov.GrabarMovimiento(strCadena, 1, NuevoMov, AreaID, dtpFecha.Value, "A", txtObservacion.Text, CabOrden_ID)
      MessageBox.Show("Datos guardados correctamente!", "Guardando...", MessageBoxButtons.OK, MessageBoxIcon.Information)
      grDetalleNuevo.Rows.Clear()
      Call cmbOrdenes_SelectedIndexChanged(cmbOrdenes, New System.EventArgs)

  Else
    MessageBox.Show("Debe seleccionar los items para el área!", "Asignar al área", MessageBoxButtons.OK, MessageBoxIcon.Error)

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
    Frm.Show()
End Sub

  Private Sub txtObservacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservacion.TextChanged

  End Sub

  Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

  End Sub

  Private Sub grDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalle.CellContentClick

  End Sub

  Private Sub cmdAgregarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarItem.Click
    Dim objItem As System.Data.DataRowView
    objItem = cmbProducto.SelectedItem

    If txtCantidad.Text <> "" Then

      Dim strFilaNueva() As String = {grDetalleNuevo.Rows.Count + 1, objItem.Row("CodInventario").ToString(), objItem.Row("Descripcion").ToString() _
        , txtCantidad.Text, objItem.Row("Id").ToString(), objItem.Row("IdUnidad").ToString, True}
      'strFilaNueva = "1"

      grDetalleNuevo.Rows.Add(strFilaNueva)
      txtCantidad.Text = ""
    Else
      MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End If
  End Sub

  
End Class
