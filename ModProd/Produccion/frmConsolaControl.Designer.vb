<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolaControl
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
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.grpImprimir = New System.Windows.Forms.GroupBox()
    Me.optOTSinImprimir = New System.Windows.Forms.RadioButton()
    Me.optOTImpresas = New System.Windows.Forms.RadioButton()
    Me.optOTTodas = New System.Windows.Forms.RadioButton()
    Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
    Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
    Me.grOT = New System.Windows.Forms.DataGridView()
    Me.btnCargarValidadas = New System.Windows.Forms.Button()
    Me.grpValidar = New System.Windows.Forms.GroupBox()
    Me.optOTSinValidar = New System.Windows.Forms.RadioButton()
    Me.optOTValidadas = New System.Windows.Forms.RadioButton()
    Me.optOTTodasValidadas = New System.Windows.Forms.RadioButton()
    Me.grpImprimir.SuspendLayout()
    CType(Me.grOT, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpValidar.SuspendLayout()
    Me.SuspendLayout()
    '
    'btnCargar
    '
    Me.btnCargar.Location = New System.Drawing.Point(270, 16)
    Me.btnCargar.Name = "btnCargar"
    Me.btnCargar.Size = New System.Drawing.Size(80, 43)
    Me.btnCargar.TabIndex = 13
    Me.btnCargar.Text = "Cargar"
    Me.btnCargar.UseVisualStyleBackColor = True
    '
    'grpImprimir
    '
    Me.grpImprimir.Controls.Add(Me.optOTSinImprimir)
    Me.grpImprimir.Controls.Add(Me.optOTImpresas)
    Me.grpImprimir.Controls.Add(Me.optOTTodas)
    Me.grpImprimir.Location = New System.Drawing.Point(19, 5)
    Me.grpImprimir.Name = "grpImprimir"
    Me.grpImprimir.Size = New System.Drawing.Size(124, 90)
    Me.grpImprimir.TabIndex = 12
    Me.grpImprimir.TabStop = False
    Me.grpImprimir.Text = "Estado Impresión"
    '
    'optOTSinImprimir
    '
    Me.optOTSinImprimir.AutoSize = True
    Me.optOTSinImprimir.Checked = True
    Me.optOTSinImprimir.Location = New System.Drawing.Point(10, 16)
    Me.optOTSinImprimir.Name = "optOTSinImprimir"
    Me.optOTSinImprimir.Size = New System.Drawing.Size(78, 17)
    Me.optOTSinImprimir.TabIndex = 1
    Me.optOTSinImprimir.TabStop = True
    Me.optOTSinImprimir.Text = "Sin Imprimir"
    Me.optOTSinImprimir.UseVisualStyleBackColor = True
    '
    'optOTImpresas
    '
    Me.optOTImpresas.AutoSize = True
    Me.optOTImpresas.Location = New System.Drawing.Point(10, 40)
    Me.optOTImpresas.Name = "optOTImpresas"
    Me.optOTImpresas.Size = New System.Drawing.Size(67, 17)
    Me.optOTImpresas.TabIndex = 2
    Me.optOTImpresas.TabStop = True
    Me.optOTImpresas.Text = "Impresas"
    Me.optOTImpresas.UseVisualStyleBackColor = True
    '
    'optOTTodas
    '
    Me.optOTTodas.AutoSize = True
    Me.optOTTodas.Location = New System.Drawing.Point(10, 64)
    Me.optOTTodas.Name = "optOTTodas"
    Me.optOTTodas.Size = New System.Drawing.Size(55, 17)
    Me.optOTTodas.TabIndex = 3
    Me.optOTTodas.TabStop = True
    Me.optOTTodas.Text = "Todas"
    Me.optOTTodas.UseVisualStyleBackColor = True
    '
    'dtpInicial
    '
    Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpInicial.Location = New System.Drawing.Point(149, 16)
    Me.dtpInicial.Name = "dtpInicial"
    Me.dtpInicial.Size = New System.Drawing.Size(101, 20)
    Me.dtpInicial.TabIndex = 11
    '
    'dtpFinal
    '
    Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFinal.Location = New System.Drawing.Point(149, 39)
    Me.dtpFinal.Name = "dtpFinal"
    Me.dtpFinal.Size = New System.Drawing.Size(101, 20)
    Me.dtpFinal.TabIndex = 10
    '
    'grOT
    '
    Me.grOT.AllowUserToAddRows = False
    Me.grOT.AllowUserToDeleteRows = False
    Me.grOT.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grOT.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grOT.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.grOT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grOT.DefaultCellStyle = DataGridViewCellStyle5
    Me.grOT.Location = New System.Drawing.Point(12, 101)
    Me.grOT.MultiSelect = False
    Me.grOT.Name = "grOT"
    Me.grOT.ReadOnly = True
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grOT.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
    Me.grOT.RowHeadersVisible = False
    Me.grOT.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.grOT.Size = New System.Drawing.Size(626, 257)
    Me.grOT.TabIndex = 9
    '
    'btnCargarValidadas
    '
    Me.btnCargarValidadas.Location = New System.Drawing.Point(558, 16)
    Me.btnCargarValidadas.Name = "btnCargarValidadas"
    Me.btnCargarValidadas.Size = New System.Drawing.Size(80, 43)
    Me.btnCargarValidadas.TabIndex = 14
    Me.btnCargarValidadas.Text = "Cargar"
    Me.btnCargarValidadas.UseVisualStyleBackColor = True
    '
    'grpValidar
    '
    Me.grpValidar.Controls.Add(Me.optOTSinValidar)
    Me.grpValidar.Controls.Add(Me.optOTValidadas)
    Me.grpValidar.Controls.Add(Me.optOTTodasValidadas)
    Me.grpValidar.Location = New System.Drawing.Point(428, 5)
    Me.grpValidar.Name = "grpValidar"
    Me.grpValidar.Size = New System.Drawing.Size(124, 90)
    Me.grpValidar.TabIndex = 15
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
    'frmConsolaControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(650, 370)
    Me.Controls.Add(Me.grpValidar)
    Me.Controls.Add(Me.btnCargarValidadas)
    Me.Controls.Add(Me.btnCargar)
    Me.Controls.Add(Me.grpImprimir)
    Me.Controls.Add(Me.dtpInicial)
    Me.Controls.Add(Me.dtpFinal)
    Me.Controls.Add(Me.grOT)
    Me.Name = "frmConsolaControl"
    Me.Text = "Impresión OT"
    Me.grpImprimir.ResumeLayout(False)
    Me.grpImprimir.PerformLayout()
    CType(Me.grOT, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpValidar.ResumeLayout(False)
    Me.grpValidar.PerformLayout()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents grpImprimir As System.Windows.Forms.GroupBox
    Friend WithEvents optOTSinImprimir As System.Windows.Forms.RadioButton
    Friend WithEvents optOTImpresas As System.Windows.Forms.RadioButton
    Friend WithEvents optOTTodas As System.Windows.Forms.RadioButton
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents grOT As System.Windows.Forms.DataGridView
    Friend WithEvents btnCargarValidadas As System.Windows.Forms.Button
    Friend WithEvents grpValidar As System.Windows.Forms.GroupBox
    Friend WithEvents optOTSinValidar As System.Windows.Forms.RadioButton
    Friend WithEvents optOTValidadas As System.Windows.Forms.RadioButton
    Friend WithEvents optOTTodasValidadas As System.Windows.Forms.RadioButton
End Class
