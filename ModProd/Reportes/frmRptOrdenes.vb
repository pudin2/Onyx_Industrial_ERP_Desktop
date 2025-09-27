
'Imports System.Configuration
Public Class frmRptOrdenes

  Private Sub frmRptOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    'Me.rptReporte.ServerReport.ReportPath = "/produccion/01_ConsultaOrdenesProduccion"
    Me.rptReporte.ServerReport.ReportPath = "/produccion/14_RPT_OrdenesDeTrabajo"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Me.rptReporte.RefreshReport()
  End Sub
End Class