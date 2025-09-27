Imports Microsoft.Reporting.WinForms

'Imports System.Configuration
Public Class frmRptSubTareas
  Public strNumOrden As String, strNombreReporte As String, OT_Cab_ID As String

    Private Sub frmRptSubTareas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
         Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        Debug.Print(ex.Message)
      End Try

  End Sub


  Private Sub frmRptOrdenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString

    'Me.rptReporte.ServerReport.ReportPath = "/produccion/16_RPT_BoletasDeTrabajo.rdl"
    Me.rptReporte.ServerReport.ReportPath = "/produccion/" & strNombreReporte  '03_ImprimeOP"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)

    Dim Parametros As New List(Of ReportParameter)
    'Parametros.Add(New ReportParameter("NumOrden", strNumOrden))
    'Parametros.Add(New ReportParameter("OT_Cab_ID", OT_Cab_ID))

    'Me.rptReporte.ServerReport.SetParameters(Parametros)
    Me.rptReporte.RefreshReport()

  End Sub
End Class
