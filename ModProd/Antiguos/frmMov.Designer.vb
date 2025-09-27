<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMov
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
    Me.grCabMov = New System.Windows.Forms.DataGridView()
    Me.grDetMov = New System.Windows.Forms.DataGridView()
    CType(Me.grCabMov, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grDetMov, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'grCabMov
    '
    Me.grCabMov.AllowUserToAddRows = False
    Me.grCabMov.AllowUserToDeleteRows = False
    Me.grCabMov.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grCabMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grCabMov.Location = New System.Drawing.Point(12, 12)
    Me.grCabMov.Name = "grCabMov"
    Me.grCabMov.Size = New System.Drawing.Size(835, 192)
    Me.grCabMov.TabIndex = 0
    '
    'grDetMov
    '
    Me.grDetMov.AllowUserToAddRows = False
    Me.grDetMov.AllowUserToDeleteRows = False
    Me.grDetMov.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grDetMov.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetMov.Location = New System.Drawing.Point(12, 219)
    Me.grDetMov.Name = "grDetMov"
    Me.grDetMov.Size = New System.Drawing.Size(835, 352)
    Me.grDetMov.TabIndex = 1
    '
    'frmMov
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(859, 583)
    Me.Controls.Add(Me.grDetMov)
    Me.Controls.Add(Me.grCabMov)
    Me.Name = "frmMov"
    Me.Text = "frmMov"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.grCabMov, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grDetMov, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents grCabMov As System.Windows.Forms.DataGridView
    Friend WithEvents grDetMov As System.Windows.Forms.DataGridView
End Class
