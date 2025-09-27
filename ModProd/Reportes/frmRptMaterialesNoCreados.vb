Imports Microsoft.Reporting.WinForms

Public Class frmRptMaterialesNoCreados
  Public strCotizacion As String
  Private Sub frmRptMaterialesNoCreados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    Me.rptReporte.ServerReport.ReportPath = "/produccion/07_ConsultaMaterialesNoCreados"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim Parametros As New List(Of ReportParameter)
    Parametros.Add(New ReportParameter("NumCotizacion", strCotizacion))
    Me.rptReporte.ServerReport.SetParameters(Parametros)


    Me.rptReporte.RefreshReport()
  End Sub
End Class