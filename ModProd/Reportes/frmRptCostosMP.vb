Imports Microsoft.Reporting.WinForms

Public Class frmRptCostosMP
  'Public strCotizacion As Integer
  Private Sub frmRptCostosMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    Me.rptReporte.ServerReport.ReportPath = "/produccion/08_ConsultaCostosMP"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim Parametros As New List(Of ReportParameter)
    Parametros.Add(New ReportParameter("Inventario_ID", "MP%"))
    Parametros.Add(New ReportParameter("Tipo", "2"))
    Me.rptReporte.ServerReport.SetParameters(Parametros)




    Me.rptReporte.RefreshReport()
  End Sub
End Class