
Imports System.Configuration



Public Class frmCerrarOrden

Private strCadena As String

Private Sub frmCerrarOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim obConectividad As New clConectividad

  strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString

  obConectividad.CadenaDeConeccion = strCadena

  cmbOrdenes.DataSource = obConectividad.LlenarDataTable(strCadena, "id, Observacion", "CabOrden", "estado like 'V'")
  cmbOrdenes.DisplayMember = "id"

  'cmbMotivo.DataSource = obConectividad.LlenarDataTable(strCadena, "NCorto + ' - ' + Descripcion [Mostrar]", "Motivos", "estado = 'A'")
  'cmbMotivo.DisplayMember = "Mostrar"

  obConectividad = Nothing

End Sub

  

Private Sub cmbOrdenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOrdenes.SelectedIndexChanged

    Dim selectedItem As DataRowView
    selectedItem = cmbOrdenes.SelectedItem

    Dim CabOrden_ID = selectedItem(0).ToString()
    Dim obCntv As New clConectividad

    grDetalle.DataSource = obCntv.LlenarDataTable(strCadena, "CodInventario, Descripcion, Cantidad, [Cantidad para Area], [Entregar a Bodega], [Producto_ID], [Unidad_ID]", _
      "vw_ConsultarDetalleOrdenPT", "caborden_id=" & CabOrden_ID)

    Dim MyEstilo As New DataGridViewCellStyle

    'MyEstilo.BackColor = Color.Silver
    MyEstilo.BackColor = Color.Cyan


    grDetalle.Columns(0).ReadOnly = True : grDetalle.Columns(0).DefaultCellStyle = MyEstilo
    grDetalle.Columns(1).ReadOnly = True : grDetalle.Columns(1).DefaultCellStyle = MyEstilo
    grDetalle.Columns(2).ReadOnly = True : grDetalle.Columns(2).DefaultCellStyle = MyEstilo
    grDetalle.Columns(3).ReadOnly = True : grDetalle.Columns(3).DefaultCellStyle = MyEstilo
    'grDetalle.Columns(6).Visible = False : grDetalle.Columns(7).Visible = False


End Sub



Private Sub cmdGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGrabar.Click
  Dim obMov As New clMovimiento
  Dim obCntv As New clConectividad
  Dim blnSeleccionado As Boolean = False
  Dim Ff As Integer

  For Ff = 0 To grDetalle.Rows.Count - 1
    If grDetalle.Item(4, Ff).Value = True Then
      Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

      NuevaFila("CabMov_ID") = 0
      NuevaFila("id") = Ff + 1
      NuevaFila("Producto_ID") = CInt(grDetalle.Item(5, Ff).Value) '  .Rows(Ff).Cells(4).ToString
      NuevaFila("Cantidad") = grDetalle.Item(3, Ff).Value
      NuevaFila("Unidad_ID") = grDetalle.Item(6, Ff).Value


      obMov.DetMovimiento.AddDetMovRow(NuevaFila)
      blnSeleccionado = True
    End If
  Next

  If blnSeleccionado = True Then

    Dim selectedItem As DataRowView
    selectedItem = cmbOrdenes.SelectedItem
    Dim CabOrden_ID = selectedItem(0).ToString()


    Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(numero),0)+1 [Maximo]", "Maximo", "CabMov", "Motivo_ID = 4", strCadena)
    obMov.GrabarMovimiento(strCadena, 4, NuevoMov, 1, dtpFecha.Value, "A", txtObservacion.Text, CabOrden_ID)
    MessageBox.Show("Datos guardados correctamente!", "Guardando...", MessageBoxButtons.OK, MessageBoxIcon.Information)
  Else
    MessageBox.Show("Debe seleccionar los items para la bodega!", "Entregar a bodega", MessageBoxButtons.OK, MessageBoxIcon.Error)

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

    Frm.strMotivo_ID = "4"
    Frm.Show()
End Sub
End Class
