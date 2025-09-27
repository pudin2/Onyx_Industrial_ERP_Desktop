<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptEntregasArea
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
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.rptReporte = New Microsoft.Reporting.WinForms.ReportViewer()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.SuspendLayout()
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.rptReporte)
    Me.SplitContainer1.Size = New System.Drawing.Size(837, 489)
    Me.SplitContainer1.SplitterDistance = 42
    Me.SplitContainer1.TabIndex = 0
    '
    'rptReporte
    '
    Me.rptReporte.Dock = System.Windows.Forms.DockStyle.Fill
    Me.rptReporte.Location = New System.Drawing.Point(0, 0)
    Me.rptReporte.Name = "rptReporte"
    Me.rptReporte.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
    Me.rptReporte.ServerReport.ReportPath = "/produccion/02_ConsultaEntregasArea"
    Me.rptReporte.Size = New System.Drawing.Size(837, 443)
    Me.rptReporte.TabIndex = 0
    '
    'frmRptEntregasArea
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(837, 489)
    Me.Controls.Add(Me.SplitContainer1)
    Me.Name = "frmRptEntregasArea"
    Me.Text = "Entregas de Area"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents rptReporte As Microsoft.Reporting.WinForms.ReportViewer
End Class
