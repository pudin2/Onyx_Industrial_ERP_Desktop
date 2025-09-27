<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGastosMontaje
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGastosMontaje))
Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.cmdCargar = New System.Windows.Forms.Button()
Me.btnAprobar = New System.Windows.Forms.Button()
Me.btnSigFase = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.GroupBox1 = New System.Windows.Forms.GroupBox()
Me.optTransporte = New System.Windows.Forms.RadioButton()
Me.optAnticipo = New System.Windows.Forms.RadioButton()
Me.grTipoGastos = New System.Windows.Forms.DataGridView()
Me.grDetPosicion = New System.Windows.Forms.DataGridView()
Me.colOT = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colValor = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colEditada = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colInventarioID = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colPKDt = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCab_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.lblProveedor = New System.Windows.Forms.Label()
Me.cmbProveedores = New System.Windows.Forms.ComboBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
Me.GroupBox1.SuspendLayout()
CType(Me.grTipoGastos, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.grDetPosicion, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'flyPanelBotones
'
Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(70, Byte), Integer))
Me.flyPanelBotones.Controls.Add(Me.pnlControles)
Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
Me.flyPanelBotones.Controls.Add(Me.cmdCargar)
Me.flyPanelBotones.Controls.Add(Me.btnAprobar)
Me.flyPanelBotones.Controls.Add(Me.btnSigFase)
Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flyPanelBotones.Location = New System.Drawing.Point(1356, 0)
Me.flyPanelBotones.Margin = New System.Windows.Forms.Padding(4)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(253, 901)
Me.flyPanelBotones.TabIndex = 7
'
'pnlControles
'
Me.pnlControles.Controls.Add(Me.btnBotonera)
Me.pnlControles.Location = New System.Drawing.Point(4, 4)
Me.pnlControles.Margin = New System.Windows.Forms.Padding(4)
Me.pnlControles.Name = "pnlControles"
Me.pnlControles.Size = New System.Drawing.Size(232, 27)
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
Me.btnBotonera.Location = New System.Drawing.Point(5, 0)
Me.btnBotonera.Margin = New System.Windows.Forms.Padding(4)
Me.btnBotonera.Name = "btnBotonera"
Me.btnBotonera.Size = New System.Drawing.Size(37, 23)
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
Me.btnGrabar.Location = New System.Drawing.Point(4, 39)
Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4)
Me.btnGrabar.Name = "btnGrabar"
Me.btnGrabar.Size = New System.Drawing.Size(252, 43)
Me.btnGrabar.TabIndex = 20
Me.btnGrabar.Tag = "SI"
Me.btnGrabar.Text = "Grabar"
Me.btnGrabar.UseVisualStyleBackColor = True
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
Me.cmdCargar.Location = New System.Drawing.Point(4, 90)
Me.cmdCargar.Margin = New System.Windows.Forms.Padding(4)
Me.cmdCargar.Name = "cmdCargar"
Me.cmdCargar.Size = New System.Drawing.Size(252, 43)
Me.cmdCargar.TabIndex = 21
Me.cmdCargar.Text = "Cargar"
Me.cmdCargar.UseVisualStyleBackColor = True
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
Me.btnAprobar.Location = New System.Drawing.Point(4, 141)
Me.btnAprobar.Margin = New System.Windows.Forms.Padding(4)
Me.btnAprobar.Name = "btnAprobar"
Me.btnAprobar.Size = New System.Drawing.Size(252, 43)
Me.btnAprobar.TabIndex = 22
Me.btnAprobar.Text = "Aprobar"
Me.btnAprobar.UseVisualStyleBackColor = True
Me.btnAprobar.Visible = False
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
Me.btnSigFase.Location = New System.Drawing.Point(4, 192)
Me.btnSigFase.Margin = New System.Windows.Forms.Padding(4)
Me.btnSigFase.Name = "btnSigFase"
Me.btnSigFase.Size = New System.Drawing.Size(252, 43)
Me.btnSigFase.TabIndex = 23
Me.btnSigFase.Text = "Terminar Etapa"
Me.btnSigFase.UseVisualStyleBackColor = True
Me.btnSigFase.Visible = False
'
'btnImprimir
'
Me.btnImprimir.FlatAppearance.BorderSize = 0
Me.btnImprimir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnImprimir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnImprimir.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnImprimir.ForeColor = System.Drawing.Color.White
Me.btnImprimir.Image = CType(resources.GetObject("btnImprimir.Image"), System.Drawing.Image)
Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnImprimir.Location = New System.Drawing.Point(4, 243)
Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4)
Me.btnImprimir.Name = "btnImprimir"
Me.btnImprimir.Size = New System.Drawing.Size(252, 43)
Me.btnImprimir.TabIndex = 24
Me.btnImprimir.Text = "Imprimir"
Me.btnImprimir.UseVisualStyleBackColor = True
Me.btnImprimir.Visible = False
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.optTransporte)
Me.GroupBox1.Controls.Add(Me.optAnticipo)
Me.GroupBox1.Location = New System.Drawing.Point(12, 1)
Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.GroupBox1.Size = New System.Drawing.Size(212, 36)
Me.GroupBox1.TabIndex = 9
Me.GroupBox1.TabStop = False
'
'optTransporte
'
Me.optTransporte.AutoSize = True
Me.optTransporte.Location = New System.Drawing.Point(109, 10)
Me.optTransporte.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.optTransporte.Name = "optTransporte"
Me.optTransporte.Size = New System.Drawing.Size(99, 21)
Me.optTransporte.TabIndex = 10
Me.optTransporte.Text = "Transporte"
Me.optTransporte.UseVisualStyleBackColor = True
'
'optAnticipo
'
Me.optAnticipo.AutoSize = True
Me.optAnticipo.Checked = True
Me.optAnticipo.Location = New System.Drawing.Point(11, 10)
Me.optAnticipo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.optAnticipo.Name = "optAnticipo"
Me.optAnticipo.Size = New System.Drawing.Size(79, 21)
Me.optAnticipo.TabIndex = 9
Me.optAnticipo.TabStop = True
Me.optAnticipo.Text = "Anticipo"
Me.optAnticipo.UseVisualStyleBackColor = True
'
'grTipoGastos
'
Me.grTipoGastos.AllowUserToAddRows = False
Me.grTipoGastos.AllowUserToDeleteRows = False
DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grTipoGastos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
Me.grTipoGastos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grTipoGastos.ColumnHeadersVisible = False
DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grTipoGastos.DefaultCellStyle = DataGridViewCellStyle9
Me.grTipoGastos.Location = New System.Drawing.Point(15, 76)
Me.grTipoGastos.Margin = New System.Windows.Forms.Padding(4)
Me.grTipoGastos.Name = "grTipoGastos"
DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grTipoGastos.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
Me.grTipoGastos.RowHeadersVisible = False
Me.grTipoGastos.Size = New System.Drawing.Size(313, 380)
Me.grTipoGastos.TabIndex = 18
'
'grDetPosicion
'
DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grDetPosicion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
Me.grDetPosicion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grDetPosicion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOT, Me.colDesc, Me.colValor, Me.colEditada, Me.colInventarioID, Me.colPKDt, Me.colCab_Id})
DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grDetPosicion.DefaultCellStyle = DataGridViewCellStyle13
Me.grDetPosicion.Location = New System.Drawing.Point(332, 75)
Me.grDetPosicion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grDetPosicion.Name = "grDetPosicion"
DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grDetPosicion.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
Me.grDetPosicion.RowTemplate.Height = 24
Me.grDetPosicion.Size = New System.Drawing.Size(731, 380)
Me.grDetPosicion.TabIndex = 19
'
'colOT
'
Me.colOT.HeaderText = "OT"
Me.colOT.MaxInputLength = 9
Me.colOT.Name = "colOT"
Me.colOT.Width = 80
'
'colDesc
'
Me.colDesc.HeaderText = "Descripción"
Me.colDesc.Name = "colDesc"
Me.colDesc.Width = 300
'
'colValor
'
DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
DataGridViewCellStyle12.Format = "C0"
DataGridViewCellStyle12.NullValue = Nothing
Me.colValor.DefaultCellStyle = DataGridViewCellStyle12
Me.colValor.HeaderText = "Valor"
Me.colValor.Name = "colValor"
Me.colValor.Width = 120
'
'colEditada
'
Me.colEditada.HeaderText = "colEditada"
Me.colEditada.Name = "colEditada"
Me.colEditada.Visible = False
'
'colInventarioID
'
Me.colInventarioID.HeaderText = "colInventarioID"
Me.colInventarioID.Name = "colInventarioID"
Me.colInventarioID.Visible = False
'
'colPKDt
'
Me.colPKDt.HeaderText = "colPKDt"
Me.colPKDt.Name = "colPKDt"
Me.colPKDt.Visible = False
'
'colCab_Id
'
Me.colCab_Id.HeaderText = "colCab_Id"
Me.colCab_Id.Name = "colCab_Id"
Me.colCab_Id.Visible = False
'
'lblProveedor
'
Me.lblProveedor.AutoSize = True
Me.lblProveedor.Location = New System.Drawing.Point(12, 46)
Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblProveedor.Name = "lblProveedor"
Me.lblProveedor.Size = New System.Drawing.Size(74, 17)
Me.lblProveedor.TabIndex = 21
Me.lblProveedor.Text = "Proveedor"
'
'cmbProveedores
'
Me.cmbProveedores.FormattingEnabled = True
Me.cmbProveedores.Location = New System.Drawing.Point(89, 44)
Me.cmbProveedores.Margin = New System.Windows.Forms.Padding(4)
Me.cmbProveedores.Name = "cmbProveedores"
Me.cmbProveedores.Size = New System.Drawing.Size(975, 24)
Me.cmbProveedores.TabIndex = 20
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(565, 7)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(51, 17)
Me.Label1.TabIndex = 22
Me.Label1.Text = "Label1"
Me.Label1.Visible = False
'
'frmGastosMontaje
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1609, 901)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.lblProveedor)
Me.Controls.Add(Me.cmbProveedores)
Me.Controls.Add(Me.grDetPosicion)
Me.Controls.Add(Me.grTipoGastos)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.flyPanelBotones)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmGastosMontaje"
Me.Text = "Control de costos en montaje"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
CType(Me.grTipoGastos, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.grDetPosicion, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnSigFase As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optTransporte As System.Windows.Forms.RadioButton
    Friend WithEvents optAnticipo As System.Windows.Forms.RadioButton
    Friend WithEvents grTipoGastos As System.Windows.Forms.DataGridView
    Friend WithEvents grDetPosicion As System.Windows.Forms.DataGridView
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents cmbProveedores As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colOT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colValor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEditada As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInventarioID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPKDt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCab_Id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
