Option Explicit On
  
Public Class frmValidarOC
  Private Sep As Char
  Public Usuario_Id As Integer
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mIVA As Decimal, mCab_Id As Integer


Private Sub CargarCabeceras()
    Dim obCntv As New clConectividad, strCampos As String

    strCampos = "Id [ORDEN], NOMBRECOMPLETO [PROVEEDOR], ESTADO, FECHA, FechaEntrega [FECHA ENTREGA], FechaValidacion [FECHA VALIDACIÓN]" _
      & ", Observacion, LugarEntrega, descuento" _
      & ",convert(bit,0) [APROBAR]"

    grOrdenesCompra.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_CabOrdenCompra", "Estado ='R'")

    grOrdenesCompra.Columns("Observacion").Visible = False
    grOrdenesCompra.Columns("LugarEntrega").Visible = False
    grOrdenesCompra.Columns("Descuento").Visible = False

    mIVA = obCntv.LeerValorSencillo("Valor", "Parametros", "id=21", My.Settings.cnnModProd)
    obCntv = Nothing
    Call FormatoGrilla()
End Sub


Private Sub cmdActualizar_Click(sender As System.Object, e As System.EventArgs) Handles cmdActualizar.Click
  Call CargarCabeceras()

End Sub

  Private Sub frmValidarOC_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Call CargarCabeceras()
  End Sub

  Private Sub FormatoGrilla()
    Dim Cc As Integer

    With grOrdenesCompra
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).ReadOnly = True
        .Columns(Cc).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

      Next

      .Columns("ORDEN").Width = 63
      .Columns("PROVEEDOR").Width = 400
      .Columns("ESTADO").Width = 68
      .Columns("FECHA").Width = 120
      .Columns("FECHA ENTREGA").Width = 130
      .Columns("FECHA VALIDACIÓN").Width = 110
      .Columns("OBSERVACION").Width = 100
      .Columns("APROBAR").Width = 80

      .Columns("APROBAR").ReadOnly = False
      .Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End With
  End Sub

  'Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click
  '  If (MessageBox.Show("Desea actualizar la Orden de Compra ?", "Aprobar Orden Compra", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then

  '      Dim obCompras As New clCompras, obCntv As New clConectividad, Ff As Integer

  '      Dim obInicio As New clSetUpInicio, mUsuario As String, mDominio As String, mUsuario_id As Integer
  '      mUsuario = obInicio.Usuario
  '      mDominio = obInicio.Dominio
  '      obInicio = Nothing

  '      mUsuario_id = obCntv.LeerValorSencillo("id", "usuarios", "Dominio='" & mDominio & "' and usuario='" & mUsuario & "'", My.Settings.cnnModProd)

  '      For Ff = 0 To grOrdenesCompra.Rows.Count - 1
  '        mCab_Id = grOrdenesCompra.Item("orden", Ff).Value
  '        If grOrdenesCompra.Item("aprobar", Ff).Value = True Then
  '          obCntv.ActualizaValor("Estado='V', Usuario_ID_Aprueba=" & mUsuario_id.ToString, "CabOCompra", "id=" & mCab_Id.ToString, My.Settings.cnnModProd)
  '          obCntv.EjecutaComando("EXEC PA_ActualizaSolpedConOCompra " & mCab_Id.ToString, My.Settings.cnnModProd, False)
  '        End If
  '      Next

  '      MessageBox.Show("Ordenes aprobadas con éxito", "Ordenes de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
  '      Call CargarCabeceras()

  '      obCompras = Nothing : obCntv = Nothing
  '  End If
  'End Sub

Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
     If flyPanelBotones.Width = 190 Then
          flyPanelBotones.Width = 45
          grOrdenesCompra.Width = grOrdenesCompra.Width + (190 - 45)
        Else
          flyPanelBotones.Width = 190
          grOrdenesCompra.Width = Me.Width - 190 - 30 'tbcContenido.Width - 190 '- 45)
        End If

End Sub


    
End Class