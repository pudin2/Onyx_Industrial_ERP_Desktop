Public Class frmMtoAreasPlanta

  Public strConexion As String

  Private Sub frmMtoAreasPlanta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.AreasPlanta' Puede moverla o quitarla según sea necesario.

    'dsCabMovAdp.Connection.ConnectionString = strConexion
    strConexion = My.Settings.cnnModProd

    Me.AreasPlantaTableAdapter.Connection.ConnectionString = strConexion
    Me.AreasPlantaTableAdapter.Fill(Me.ModProdDataSet.AreasPlanta)



  End Sub

  
  
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    AreasPlantaTableAdapter.Update(Me.AreasPlantaBindingSource.DataSource) ' , DataTable))
    Me.AreasPlantaTableAdapter.Fill(Me.ModProdDataSet.AreasPlanta)

    MessageBox.Show("Datos grabados con éxito!", "Datos Grabados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    'Me.dataAdapter.Update(CType(Me.bindingSource1.DataSource, DataTable))

  End Sub
End Class