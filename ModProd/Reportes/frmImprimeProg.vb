Imports Microsoft.Reporting.WinForms


Public Class frmImprimeProg

  Public dteFecha As Date, intOperario_Id As Integer, strNombreReporte As String, strCabSubt_Id As String

  Private Sub frmImprimeProg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    'CONFIGURACION DEL REPORTE
    'SE HACE DESDE LA INVOCACIÓN

    Me.Cursor = Cursors.WaitCursor
    Dim mTextAnt As String = Me.Text
    Me.Text = "Cargando reporte ..."
    Me.rptReporte.Visible = False
    Me.rptReporte.ServerReport.ReportPath = strNombreReporte  '03_ImprimeOP"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim parametros As New List(Of ReportParameter)
    parametros.Add(New ReportParameter("FechaProg", dteFecha))
    parametros.Add(New ReportParameter("Operario_Id", intOperario_Id))

    Me.rptReporte.ServerReport.SetParameters(parametros)

    Me.rptReporte.RefreshReport()
    Me.rptReporte.Visible = True
    Me.Cursor = Cursors.Default
    Me.Text = mTextAnt
  End Sub
End Class