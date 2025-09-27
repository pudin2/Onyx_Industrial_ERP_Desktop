<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImprimeRemision
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Me.rptReporte = New Microsoft.Reporting.WinForms.ReportViewer()
    Me.SuspendLayout()
    '
    'rptReporte
    '
    Me.rptReporte.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rptReporte.Location = New System.Drawing.Point(0, 0)
    Me.rptReporte.Name = "rptReporte"
    Me.rptReporte.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
    Me.rptReporte.ServerReport.ReportPath = "/produccion/03_ImprimeOP"
    Me.rptReporte.ShowParameterPrompts = False
    Me.rptReporte.Size = New System.Drawing.Size(781, 466)
    Me.rptReporte.TabIndex = 1
    '
    'frmImprimeRemision
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(781, 466)
    Me.Controls.Add(Me.rptReporte)
    Me.Name = "frmImprimeRemision"
    Me.Text = "frmImprimeRemision"
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents rptReporte As Microsoft.Reporting.WinForms.ReportViewer
End Class
