Public Class frmAddMONotificacion
  Private dtOperarios As Data.DataTable
  Private strOperatio_Id As String
  Private Sep As Char
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mGrillaOrigen As DataGridView

  Public Property GrillaOrigen
  Get
    Return mGrillaOrigen
  End Get
  Set(ByVal value)
    mGrillaOrigen = value
  End Set
  End Property


  Private Sub frmAddMONotificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Dim obCntv As New clConectividad
      Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

      'PARTE DE LA CARGA DE LOS OPERARIOS
      dtOperarios = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
      cmbOperarios.DataSource = dtOperarios
      cmbOperarios.DisplayMember = "NombreMostrar"
  End Sub



  Private Sub cmbOperarios_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperarios.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbOperarios.SelectedItem

    strOperatio_Id = selectedItem("id").ToString

    If My.Settings.ModoDebug = True Then
      lblOperarioID.Text = strOperatio_Id
      lblOperarioID.Visible = True
    Else
      lblOperarioID.Visible = False
    End If

  End Sub


   Private Sub txtCantMO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantMO.KeyPress
         If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

            If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

    End Sub


  Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
    If grRecursos.Rows.Count > 0 Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
    End If

  End Sub

'Private Sub frmAddMONotificacion_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
'    If e.KeyChar = ChrW(Keys.Escape) Then
'            Close() ' Cierra el formulario modal
'    End If
'End Sub

  Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
      Close()
  End Sub

  Private Sub btnAdicionarMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarMO.Click
    Dim objItem As System.Data.DataRowView, strNombreEmpleado As String
    objItem = cmbOperarios.SelectedItem


        strNombreEmpleado = cmbOperarios.Text

        If txtCantMO.Text <> "" Then
            'Dim vlTotal As Decimal
            'vlTotal = CDec(txtCantMO.Text.ToString) * CDec(txtValorHora.Text.ToString)


            Dim strFilaNueva() As String = {strNombreEmpleado.ToString,
                                            CDec(txtCantMO.Text.ToString).ToString(FCANT),
                                            strOperatio_Id
                                            }

            grRecursos.Rows.Add(strFilaNueva)
            mGrillaOrigen.Rows.Add(strFilaNueva)

            txtCantMO.Text = ""

        Else
            MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
  End Sub

  'Private Sub PonerNombreBoton()
  '  For Ff As Integer 



  '  With grOT
  '    Dim mBoton As New DataGridViewButtonColumn
  '    mBoton.Name = "btnImprimir"
  '    mBoton.Text = "Imprimir"
  '    mBoton.UseColumnTextForButtonValue = True
  '    mBoton.HeaderText = ""

  '    .Columns.Add(mBoton)
  '  End With




  'End Sub

End Class