Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Drawing.Printing




Public Class frmSeguimientoOT

Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click

        If flyPanelBotones.Width = 190 Then
            flyPanelBotones.Width = 45
            'grpDetalle.Width = grpDetalle.Width + (190 - 45)
        Else
            flyPanelBotones.Width = 190
            'grpDetalle.Width = grpDetalle.Width - (190 - 45)
        End If

End Sub
End Class