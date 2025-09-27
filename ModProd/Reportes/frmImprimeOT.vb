Imports Microsoft.Reporting.WinForms


Public Class frmImprimeOT

  Public strOrdenID As String, strNombreReporte As String, strCabSubt_Id As String

  Private Sub frmImprimeOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    'CONFIGURACION DEL REPORTE
    'SE HACE DESDE LA INVOCACIÓN

    'Dim Pg2 As New System.Drawing.Printing.PageSettings()
    'Dim Size2 = New Printing.PaperSize()
    'Dim vctMedidas2() As String
    'vctMedidas2 = Split(My.Settings.MargenesRptImprieOT, ",")
    'Pg2.Margins.Top = CInt(vctMedidas2(0))
    'Pg2.Margins.Bottom = CInt(vctMedidas2(1))
    'Pg2.Margins.Left = CInt(vctMedidas2(2))
    'Pg2.Margins.Right = CInt(vctMedidas2(3))
    'Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Folio
    'rptReporte.SetPageSettings(Pg2)
    'rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
    Me.Cursor = Cursors.WaitCursor
    Dim mTextAnt As String = Me.Text
    Me.Text = "Cargando reporte ..."
    Me.rptReporte.Visible = False
    Me.rptReporte.ServerReport.ReportPath = strNombreReporte  '03_ImprimeOP"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim parametros As New List(Of ReportParameter)
    parametros.Add(New ReportParameter("NumOrden", strOrdenID))
    parametros.Add(New ReportParameter("CabSubt_Id", strCabSubt_Id))


    Me.rptReporte.ServerReport.SetParameters(parametros)




    Me.rptReporte.RefreshReport()
    Me.rptReporte.Visible = True
    Me.Cursor = Cursors.Default
    Me.Text = mTextAnt
  End Sub
End Class