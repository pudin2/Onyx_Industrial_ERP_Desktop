Public Class frmRptEntregasArea

    Private Sub frmRptEntregasArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    Me.rptReporte.ServerReport.ReportPath = "/produccion/02_ConsultaEntregasArea"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Me.rptReporte.RefreshReport()
    End Sub
End Class