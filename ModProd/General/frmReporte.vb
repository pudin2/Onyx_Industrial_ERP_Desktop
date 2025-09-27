Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Public Class frmReporte
  Inherits Form

  <STAThread()> _
  Shared Sub Main()
    Application.EnableVisualStyles()
    Application.Run(New frmReporte())

  End Sub

  'Public Sub New()

  '    End Sub


  Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.pa_RPT_CosultaOrdenes' Puede moverla o quitarla según sea necesario.


    Me.pa_RPT_CosultaOrdenesTableAdapter.Fill(Me.ModProdDataSet.pa_RPT_CosultaOrdenes, "%", "%")
    

    Me.ReportViewer1.RefreshReport()
    Me.ReportViewer1.RefreshReport()
  End Sub
  
End Class

