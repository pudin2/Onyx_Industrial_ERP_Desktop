Imports Microsoft.Reporting.WinForms

Public Class frmImprimeCotiza
  Public strCotizacion As Integer
  Private Sub frmImprimeCotiza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    'Me.rptReporte.ServerReport.ReportPath = "/produccion/05_ImprimeCotizacion"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim Parametros As New List(Of ReportParameter)
    Parametros.Add(New ReportParameter("Cab_ID", strCotizacion))
    Me.rptReporte.ServerReport.SetParameters(Parametros)




    Me.rptReporte.RefreshReport()
  End Sub
End Class