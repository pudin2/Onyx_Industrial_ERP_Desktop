Imports Microsoft.Reporting.WinForms

Public Class frmImprimeOP
  Public strOrdenID As String, strNombreReporte As String

  Private Sub frmImprimeOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    'CONFIGURACION DEL REPORTE
    Dim Pg2 As New System.Drawing.Printing.PageSettings()
    Dim Size2 = New Printing.PaperSize()
    Dim vctMedidas2() As String
    vctMedidas2 = Split(My.Settings.MargenesRptGeneral, ",")
    Pg2.Margins.Top = CInt(vctMedidas2(0))
    Pg2.Margins.Bottom = CInt(vctMedidas2(1))
    Pg2.Margins.Left = CInt(vctMedidas2(2))
    Pg2.Margins.Right = CInt(vctMedidas2(3))
    Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter 'Size2
    rptReporte.SetPageSettings(Pg2)
    rptReporte.SetDisplayMode(DisplayMode.PrintLayout)


    Me.rptReporte.ServerReport.ReportPath = "/produccion/" & strNombreReporte  '03_ImprimeOP"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)





    Dim parametros As New List(Of ReportParameter)
    parametros.Add(New ReportParameter("OrdenID", strOrdenID))
    Me.rptReporte.ServerReport.SetParameters(parametros)

    Me.rptReporte.RefreshReport()
  End Sub
End Class