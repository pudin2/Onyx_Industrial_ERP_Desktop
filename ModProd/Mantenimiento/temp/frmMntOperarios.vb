Public Class frmMntOperarios

  Private Sub frmMntOperarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.Responsables' Puede moverla o quitarla según sea necesario.

    Dim strConexion As String = My.Settings.cnnModProd
    Me.ResponsablesTableAdapter.Connection.ConnectionString = strConexion

    Me.ResponsablesTableAdapter.Fill(Me.ModProdDataSet.Responsables)

  End Sub

  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Me.ResponsablesTableAdapter.Update(Me.ModProdDataSet.Responsables)
    MessageBox.Show("Datos actualizados con éxito!")

  End Sub
End Class