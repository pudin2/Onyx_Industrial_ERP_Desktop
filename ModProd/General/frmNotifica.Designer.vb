<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNotifica
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
    Me.components = New System.ComponentModel.Container()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNotifica))
    Me.grNotifica = New System.Windows.Forms.DataGridView()
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.optLeidos = New System.Windows.Forms.RadioButton()
    Me.optSinLeer = New System.Windows.Forms.RadioButton()
    CType(Me.grNotifica, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'grNotifica
    '
    Me.grNotifica.AllowUserToAddRows = False
    Me.grNotifica.AllowUserToDeleteRows = False
    Me.grNotifica.AllowUserToResizeRows = False
    Me.grNotifica.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grNotifica.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.grNotifica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grNotifica.Location = New System.Drawing.Point(12, 84)
    Me.grNotifica.Name = "grNotifica"
    Me.grNotifica.RowHeadersVisible = False
    Me.grNotifica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.grNotifica.Size = New System.Drawing.Size(862, 315)
    Me.grNotifica.TabIndex = 0
    '
    'btnCargar
    '
    Me.btnCargar.Location = New System.Drawing.Point(100, 42)
    Me.btnCargar.Name = "btnCargar"
    Me.btnCargar.Size = New System.Drawing.Size(116, 31)
    Me.btnCargar.TabIndex = 1
    Me.btnCargar.Text = "Cargar"
    Me.btnCargar.UseVisualStyleBackColor = True
    '
    'NotifyIcon1
    '
    Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
    Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
    Me.NotifyIcon1.Text = "ModProd"
    Me.NotifyIcon1.Visible = True
    '
    'Timer1
    '
    Me.Timer1.Interval = 10000
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.optLeidos)
    Me.GroupBox1.Controls.Add(Me.optSinLeer)
    Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(82, 63)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    '
    'optLeidos
    '
    Me.optLeidos.AutoSize = True
    Me.optLeidos.Location = New System.Drawing.Point(6, 37)
    Me.optLeidos.Name = "optLeidos"
    Me.optLeidos.Size = New System.Drawing.Size(56, 17)
    Me.optLeidos.TabIndex = 4
    Me.optLeidos.Text = "Leidos"
    Me.optLeidos.UseVisualStyleBackColor = True
    '
    'optSinLeer
    '
    Me.optSinLeer.AutoSize = True
    Me.optSinLeer.Checked = True
    Me.optSinLeer.Location = New System.Drawing.Point(6, 14)
    Me.optSinLeer.Name = "optSinLeer"
    Me.optSinLeer.Size = New System.Drawing.Size(60, 17)
    Me.optSinLeer.TabIndex = 3
    Me.optSinLeer.TabStop = True
    Me.optSinLeer.Text = "Sin leer"
    Me.optSinLeer.UseVisualStyleBackColor = True
    '
    'frmNotifica
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(886, 411)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.btnCargar)
    Me.Controls.Add(Me.grNotifica)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.Name = "frmNotifica"
    Me.Text = "Notificaciones"
    CType(Me.grNotifica, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents grNotifica As System.Windows.Forms.DataGridView
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optLeidos As System.Windows.Forms.RadioButton
    Friend WithEvents optSinLeer As System.Windows.Forms.RadioButton
End Class
