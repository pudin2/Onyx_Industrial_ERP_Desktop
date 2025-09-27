Public Class frmMntOperarios

  Private Sub frmMntOperarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.Operarios' Puede moverla o quitarla según sea necesario.
Me.OperariosTableAdapter.Fill(Me.ModProdDataSet.Operarios)
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.Responsables' Puede moverla o quitarla según sea necesario.

    Dim strConexion As String = My.Settings.cnnModProd
    Me.OperariosTableAdapter.Connection.ConnectionString = strConexion

    Me.OperariosTableAdapter.Fill(Me.ModProdDataSet.Operarios)

  End Sub

  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Me.OperariosTableAdapter.Update(Me.ModProdDataSet.Operarios)
    MessageBox.Show("Datos actualizados con éxito!", "Mantenimiento Operarios", MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub

Private Sub frmMntOperarios_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    Call CerrarControlBarra()
End Sub


 Private Sub CerrarControlBarra()
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
  End Sub


End Class