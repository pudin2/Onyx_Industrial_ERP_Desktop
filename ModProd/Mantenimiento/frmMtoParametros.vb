Option Explicit On


Public Class frmMtoParametros
  Private strParametroValor As String, strParametroId As String


  Private Sub frmMtoParametros_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim mBoton As Button = Me.Tag
          Try
            frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
          Catch ex As System.NullReferenceException
            'no hago nada
          End Try
  End Sub

  Private Sub frmMtoParametros_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad

    cmbParametro.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "parametros", "1=1", "Order by id")
    cmbParametro.DisplayMember = "Descripcion"

    obCntv = Nothing
  End Sub


  Private Sub cmbParametro_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbParametro.SelectedIndexChanged
    Dim selectedItem As DataRowView
        selectedItem = cmbParametro.SelectedItem

        strParametroId = selectedItem("id").ToString
        strParametroValor = selectedItem("valor").ToString

        txtValor.Text = strParametroValor
  End Sub

  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
    Dim obCntv As New clConectividad

    obCntv.ActualizaValor("valor='" & txtValor.Text & "'", "parametros", "id=" & strParametroId, My.Settings.cnnModProd)

    MessageBox.Show("Parámetro actualizado con éxito!", "Actualización de parámetros", MessageBoxButtons.OK, MessageBoxIcon.Information)


    obCntv = Nothing
  End Sub
End Class