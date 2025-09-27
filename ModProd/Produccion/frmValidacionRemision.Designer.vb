<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidacionRemision
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidacionRemision))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.optOCRegistradas = New System.Windows.Forms.RadioButton()
        Me.optOCAprobadas = New System.Windows.Forms.RadioButton()
        Me.optOCTodas = New System.Windows.Forms.RadioButton()
        Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
        Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
        Me.grCabResumen = New System.Windows.Forms.DataGridView()
        Me.grDetalle = New System.Windows.Forms.DataGridView()
        Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.btnBotonera = New System.Windows.Forms.Button()
        Me.btnGrabar = New System.Windows.Forms.Button()
        Me.cmdCargar = New System.Windows.Forms.Button()
        Me.btnSigFase = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.grCabResumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.flyPanelBotones.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.SplitContainer1.Location = New System.Drawing.Point(2, 1)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpInicial)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFinal)
        Me.SplitContainer1.Panel1.Controls.Add(Me.grCabResumen)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grDetalle)
        Me.SplitContainer1.Size = New System.Drawing.Size(1154, 695)
        Me.SplitContainer1.SplitterDistance = 539
        Me.SplitContainer1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(261, 21)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 43)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Cargar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.optOCRegistradas)
        Me.GroupBox1.Controls.Add(Me.optOCAprobadas)
        Me.GroupBox1.Controls.Add(Me.optOCTodas)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(124, 90)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado Remision"
        '
        'optOCRegistradas
        '
        Me.optOCRegistradas.AutoSize = True
        Me.optOCRegistradas.Checked = True
        Me.optOCRegistradas.Location = New System.Drawing.Point(10, 16)
        Me.optOCRegistradas.Name = "optOCRegistradas"
        Me.optOCRegistradas.Size = New System.Drawing.Size(81, 17)
        Me.optOCRegistradas.TabIndex = 1
        Me.optOCRegistradas.TabStop = True
        Me.optOCRegistradas.Text = "Registradas"
        Me.optOCRegistradas.UseVisualStyleBackColor = True
        '
        'optOCAprobadas
        '
        Me.optOCAprobadas.AutoSize = True
        Me.optOCAprobadas.Location = New System.Drawing.Point(10, 40)
        Me.optOCAprobadas.Name = "optOCAprobadas"
        Me.optOCAprobadas.Size = New System.Drawing.Size(76, 17)
        Me.optOCAprobadas.TabIndex = 2
        Me.optOCAprobadas.TabStop = True
        Me.optOCAprobadas.Text = "Aprobadas"
        Me.optOCAprobadas.UseVisualStyleBackColor = True
        '
        'optOCTodas
        '
        Me.optOCTodas.AutoSize = True
        Me.optOCTodas.Location = New System.Drawing.Point(10, 64)
        Me.optOCTodas.Name = "optOCTodas"
        Me.optOCTodas.Size = New System.Drawing.Size(55, 17)
        Me.optOCTodas.TabIndex = 3
        Me.optOCTodas.TabStop = True
        Me.optOCTodas.Text = "Todas"
        Me.optOCTodas.UseVisualStyleBackColor = True
        '
        'dtpInicial
        '
        Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpInicial.Location = New System.Drawing.Point(140, 21)
        Me.dtpInicial.Name = "dtpInicial"
        Me.dtpInicial.Size = New System.Drawing.Size(101, 20)
        Me.dtpInicial.TabIndex = 6
        '
        'dtpFinal
        '
        Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFinal.Location = New System.Drawing.Point(140, 44)
        Me.dtpFinal.Name = "dtpFinal"
        Me.dtpFinal.Size = New System.Drawing.Size(101, 20)
        Me.dtpFinal.TabIndex = 5
        '
        'grCabResumen
        '
        Me.grCabResumen.AllowUserToAddRows = False
        Me.grCabResumen.AllowUserToDeleteRows = False
        Me.grCabResumen.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grCabResumen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grCabResumen.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grCabResumen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grCabResumen.DefaultCellStyle = DataGridViewCellStyle2
        Me.grCabResumen.Location = New System.Drawing.Point(3, 106)
        Me.grCabResumen.MultiSelect = False
        Me.grCabResumen.Name = "grCabResumen"
        Me.grCabResumen.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grCabResumen.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.grCabResumen.RowHeadersVisible = False
        Me.grCabResumen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grCabResumen.Size = New System.Drawing.Size(529, 582)
        Me.grCabResumen.TabIndex = 0
        '
        'grDetalle
        '
        Me.grDetalle.AllowUserToAddRows = False
        Me.grDetalle.AllowUserToDeleteRows = False
        Me.grDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grDetalle.DefaultCellStyle = DataGridViewCellStyle5
        Me.grDetalle.Location = New System.Drawing.Point(3, 21)
        Me.grDetalle.Name = "grDetalle"
        Me.grDetalle.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.grDetalle.RowHeadersVisible = False
        Me.grDetalle.Size = New System.Drawing.Size(601, 667)
        Me.grDetalle.TabIndex = 1
        '
        'flyPanelBotones
        '
        Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(70, Byte), Integer))
        Me.flyPanelBotones.Controls.Add(Me.pnlControles)
        Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
        Me.flyPanelBotones.Controls.Add(Me.cmdCargar)
        Me.flyPanelBotones.Controls.Add(Me.btnSigFase)
        Me.flyPanelBotones.Controls.Add(Me.btnAprobar)
        Me.flyPanelBotones.Controls.Add(Me.Panel1)
        Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flyPanelBotones.Location = New System.Drawing.Point(1157, 0)
        Me.flyPanelBotones.Name = "flyPanelBotones"
        Me.flyPanelBotones.Size = New System.Drawing.Size(190, 695)
        Me.flyPanelBotones.TabIndex = 10
        '
        'pnlControles
        '
        Me.pnlControles.Controls.Add(Me.btnBotonera)
        Me.pnlControles.Location = New System.Drawing.Point(3, 3)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(174, 22)
        Me.pnlControles.TabIndex = 82
        '
        'btnBotonera
        '
        Me.btnBotonera.FlatAppearance.BorderSize = 0
        Me.btnBotonera.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnBotonera.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnBotonera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBotonera.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBotonera.ForeColor = System.Drawing.Color.White
        Me.btnBotonera.Image = CType(resources.GetObject("btnBotonera.Image"), System.Drawing.Image)
        Me.btnBotonera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBotonera.Location = New System.Drawing.Point(3, 1)
        Me.btnBotonera.Name = "btnBotonera"
        Me.btnBotonera.Size = New System.Drawing.Size(28, 19)
        Me.btnBotonera.TabIndex = 84
        Me.btnBotonera.UseVisualStyleBackColor = True
        '
        'btnGrabar
        '
        Me.btnGrabar.FlatAppearance.BorderSize = 0
        Me.btnGrabar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnGrabar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnGrabar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGrabar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGrabar.ForeColor = System.Drawing.Color.White
        Me.btnGrabar.Image = CType(resources.GetObject("btnGrabar.Image"), System.Drawing.Image)
        Me.btnGrabar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGrabar.Location = New System.Drawing.Point(3, 31)
        Me.btnGrabar.Name = "btnGrabar"
        Me.btnGrabar.Size = New System.Drawing.Size(189, 35)
        Me.btnGrabar.TabIndex = 11
        Me.btnGrabar.Text = "Grabar"
        Me.btnGrabar.UseVisualStyleBackColor = True
        Me.btnGrabar.Visible = False
        '
        'cmdCargar
        '
        Me.cmdCargar.FlatAppearance.BorderSize = 0
        Me.cmdCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.cmdCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.cmdCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdCargar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCargar.ForeColor = System.Drawing.Color.White
        Me.cmdCargar.Image = CType(resources.GetObject("cmdCargar.Image"), System.Drawing.Image)
        Me.cmdCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCargar.Location = New System.Drawing.Point(3, 72)
        Me.cmdCargar.Name = "cmdCargar"
        Me.cmdCargar.Size = New System.Drawing.Size(189, 35)
        Me.cmdCargar.TabIndex = 12
        Me.cmdCargar.Text = "Cargar"
        Me.cmdCargar.UseVisualStyleBackColor = True
        Me.cmdCargar.Visible = False
        '
        'btnSigFase
        '
        Me.btnSigFase.FlatAppearance.BorderSize = 0
        Me.btnSigFase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnSigFase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnSigFase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSigFase.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSigFase.ForeColor = System.Drawing.Color.White
        Me.btnSigFase.Image = CType(resources.GetObject("btnSigFase.Image"), System.Drawing.Image)
        Me.btnSigFase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSigFase.Location = New System.Drawing.Point(3, 113)
        Me.btnSigFase.Name = "btnSigFase"
        Me.btnSigFase.Size = New System.Drawing.Size(189, 35)
        Me.btnSigFase.TabIndex = 85
        Me.btnSigFase.Text = "Terminar Etapa"
        Me.btnSigFase.UseVisualStyleBackColor = True
        Me.btnSigFase.Visible = False
        '
        'btnAprobar
        '
        Me.btnAprobar.FlatAppearance.BorderSize = 0
        Me.btnAprobar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnAprobar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.btnAprobar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAprobar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAprobar.ForeColor = System.Drawing.Color.White
        Me.btnAprobar.Image = CType(resources.GetObject("btnAprobar.Image"), System.Drawing.Image)
        Me.btnAprobar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAprobar.Location = New System.Drawing.Point(3, 154)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(189, 35)
        Me.btnAprobar.TabIndex = 13
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(3, 195)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(187, 44)
        Me.Panel1.TabIndex = 84
        '
        'frmValidacionRemision
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1347, 695)
        Me.Controls.Add(Me.flyPanelBotones)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmValidacionRemision"
        Me.Text = "Validación Remisión"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.grCabResumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.flyPanelBotones.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optOCRegistradas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCAprobadas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCTodas As System.Windows.Forms.RadioButton
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents grCabResumen As System.Windows.Forms.DataGridView
    Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents btnSigFase As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
