<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidaResumenes
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpValidar = New System.Windows.Forms.GroupBox()
        Me.optOTSinValidar = New System.Windows.Forms.RadioButton()
        Me.optOTValidadas = New System.Windows.Forms.RadioButton()
        Me.optOTTodasValidadas = New System.Windows.Forms.RadioButton()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.grResumen = New System.Windows.Forms.DataGridView()
        Me.grpValidar.SuspendLayout()
        CType(Me.grResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpValidar
        '
        Me.grpValidar.Controls.Add(Me.optOTSinValidar)
        Me.grpValidar.Controls.Add(Me.optOTValidadas)
        Me.grpValidar.Controls.Add(Me.optOTTodasValidadas)
        Me.grpValidar.Location = New System.Drawing.Point(12, 12)
        Me.grpValidar.Name = "grpValidar"
        Me.grpValidar.Size = New System.Drawing.Size(124, 89)
        Me.grpValidar.TabIndex = 22
        Me.grpValidar.TabStop = False
        Me.grpValidar.Text = "Estado Validación"
        '
        'optOTSinValidar
        '
        Me.optOTSinValidar.AutoSize = True
        Me.optOTSinValidar.Checked = True
        Me.optOTSinValidar.Location = New System.Drawing.Point(10, 16)
        Me.optOTSinValidar.Name = "optOTSinValidar"
        Me.optOTSinValidar.Size = New System.Drawing.Size(75, 17)
        Me.optOTSinValidar.TabIndex = 1
        Me.optOTSinValidar.TabStop = True
        Me.optOTSinValidar.Text = "Sin Validar"
        Me.optOTSinValidar.UseVisualStyleBackColor = True
        '
        'optOTValidadas
        '
        Me.optOTValidadas.AutoSize = True
        Me.optOTValidadas.Location = New System.Drawing.Point(10, 40)
        Me.optOTValidadas.Name = "optOTValidadas"
        Me.optOTValidadas.Size = New System.Drawing.Size(71, 17)
        Me.optOTValidadas.TabIndex = 2
        Me.optOTValidadas.TabStop = True
        Me.optOTValidadas.Text = "Validadas"
        Me.optOTValidadas.UseVisualStyleBackColor = True
        '
        'optOTTodasValidadas
        '
        Me.optOTTodasValidadas.AutoSize = True
        Me.optOTTodasValidadas.Location = New System.Drawing.Point(10, 64)
        Me.optOTTodasValidadas.Name = "optOTTodasValidadas"
        Me.optOTTodasValidadas.Size = New System.Drawing.Size(55, 17)
        Me.optOTTodasValidadas.TabIndex = 3
        Me.optOTTodasValidadas.TabStop = True
        Me.optOTTodasValidadas.Text = "Todas"
        Me.optOTTodasValidadas.UseVisualStyleBackColor = True
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(263, 26)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(80, 43)
        Me.btnCargar.TabIndex = 20
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'dtpInicial
        '
        Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicial.Location = New System.Drawing.Point(145, 22)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(101, 20)
        Me.dtpInicial.TabIndex = 18
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(145, 45)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(101, 20)
        Me.dtpFinal.TabIndex = 17
        '
        'grResumen
        '
        Me.grResumen.AllowUserToAddRows = False
        Me.grResumen.AllowUserToDeleteRows = False
        Me.grResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grResumen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grResumen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grResumen.DefaultCellStyle = DataGridViewCellStyle5
        Me.grResumen.Location = New System.Drawing.Point(3, 107)
        Me.grResumen.MultiSelect = False
        Me.grResumen.Name = "grResumen"
        Me.grResumen.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grResumen.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grResumen.RowHeadersVisible = False
        Me.grResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grResumen.Size = New System.Drawing.Size(652, 307)
        Me.grResumen.TabIndex = 16
        '
        'frmValidaResumenes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 425)
        Me.Controls.Add(Me.dtpFinal)
        Me.Controls.Add(Me.dtpInicial)
        Me.Controls.Add(Me.grpValidar)
        Me.Controls.Add(Me.btnCargar)
        Me.Controls.Add(Me.grResumen)
        Me.Name = "frmValidaResumenes"
        Me.Text = "frmValidaResumenes"
        Me.grpValidar.ResumeLayout(False)
        Me.grpValidar.PerformLayout()
        CType(Me.grResumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpValidar As System.Windows.Forms.GroupBox
    Friend WithEvents optOTSinValidar As System.Windows.Forms.RadioButton
    Friend WithEvents optOTValidadas As System.Windows.Forms.RadioButton
    Friend WithEvents optOTTodasValidadas As System.Windows.Forms.RadioButton
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents grResumen As System.Windows.Forms.DataGridView
End Class
