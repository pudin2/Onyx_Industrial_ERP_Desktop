Imports Microsoft.Reporting.WinForms

Public Class frmImprimeRemision
 Public strOrdenID As String, strNombreReporte As String

  Private Sub frmImprimeRemision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Dim strUriReportes As String
      strUriReportes = My.Settings.UrlReportes.ToString
      Me.Cursor = Cursors.WaitCursor
      Dim mTextAnt As String = Me.Text
      Me.Text = "Cargando reporte ..."
      Me.rptReporte.Visible = False
      Me.rptReporte.ServerReport.ReportPath = strNombreReporte  '03_ImprimeOP"
      Me.rptReporte.ServerReport.ReportServerUrl = _
                New System.Uri(strUriReportes)


      Dim parametros As New List(Of ReportParameter)
      parametros.Add(New ReportParameter("NumRemision", strOrdenID))
      Me.rptReporte.ServerReport.SetParameters(parametros)

      Me.rptReporte.RefreshReport()
      Me.rptReporte.Visible = True
      Me.Cursor = Cursors.Default
      Me.Text = mTextAnt
  End Sub
End Class