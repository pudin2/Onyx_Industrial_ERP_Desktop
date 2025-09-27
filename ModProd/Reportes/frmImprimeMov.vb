Imports Microsoft.Reporting.WinForms
'Imports System.Configuration

Public Class frmImprimeMov
  Public strCabOrden_ID As String, strMotivo_ID As String, strNumero As String


  Private Sub frmImprimeMov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    Dim strUriReportes As String
    strUriReportes = My.Settings.UrlReportes.ToString


    Me.rptReporte.ServerReport.ReportPath = "/produccion/04_ImprimeMov"
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)


    Dim Parametros As New List(Of ReportParameter)
    Parametros.Add(New ReportParameter("CabOrden_Id", strCabOrden_ID))
    Parametros.Add(New ReportParameter("Motivo_ID", strMotivo_ID))
    Parametros.Add(New ReportParameter("Numero", strNumero))
    Me.rptReporte.ServerReport.SetParameters(Parametros)


    Me.rptReporte.RefreshReport()

  End Sub
End Class