Imports Microsoft.Reporting.WinForms
Public Class frmRptCotizacion
  Public Enum enTiposReporte
    Normal
    A_Gerencia
  End Enum

  Public mTipoReporte As enTiposReporte

    Private Sub frmRptCotizacion_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
       Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try
  End Sub


  Private Sub frmRptCotizacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim strUriReportes As String, strNombreReporte As String
    strUriReportes = My.Settings.UrlReportes.ToString

    'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
        If Me.Tag IsNot Nothing Then
          Me.Tag.TEXT = Me.Text
        End If



    If mTipoReporte = enTiposReporte.Normal Then
      strNombreReporte = "06_ConsultaCotizaciones"
    Else
      strNombreReporte = "06b_ConsultaCotizaciones"
    End If

    'Me.rptReporte.ServerReport.ReportPath = "/produccion/06_ConsultaCotizaciones"
    Me.rptReporte.ServerReport.ReportPath = "/produccion/" & strNombreReporte
    Me.rptReporte.ServerReport.ReportServerUrl = _
             New System.Uri(strUriReportes)

    Me.rptReporte.RefreshReport()
  End Sub
End Class