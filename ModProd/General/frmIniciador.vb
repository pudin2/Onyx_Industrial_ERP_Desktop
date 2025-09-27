
Public Class frmIniciador

  Private Sub frmIniciador_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Timer1.Interval = My.Settings.IntervaloSplash
    Timer1.Start()




  End Sub


Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
  Dim frm As Form

  If My.Settings.ModoInicio = "Win10" Then
    frm = New frmMenuWin10
  Else
    frm = New frmMenu
  End If

  Timer1.Stop()
  Me.Hide()
  frm.ShowDialog()
  Me.Close()

End Sub
End Class