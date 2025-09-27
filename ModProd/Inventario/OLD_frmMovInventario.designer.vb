<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OLD_frmMovInventario
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OLD_frmMovInventario))
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.btnCargar = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.btnCotizar = New System.Windows.Forms.Button()
Me.grMovInventario = New System.Windows.Forms.DataGridView()
Me.colItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCodInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colDescMaterial = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.Label2 = New System.Windows.Forms.Label()
Me.Label1 = New System.Windows.Forms.Label()
Me.Label3 = New System.Windows.Forms.Label()
Me.rbtEntrada = New System.Windows.Forms.RadioButton()
Me.rbtSalida = New System.Windows.Forms.RadioButton()
Me.txtDocumento = New System.Windows.Forms.TextBox()
Me.cmbTipoDocumento = New System.Windows.Forms.ComboBox()
Me.Panel1 = New System.Windows.Forms.Panel()
Me.cmbMotivo = New System.Windows.Forms.ComboBox()
Me.grpAddMateriales = New System.Windows.Forms.GroupBox()
Me.Label27 = New System.Windows.Forms.Label()
Me.txtDescItem = New System.Windows.Forms.TextBox()
Me.lblTipoUnidad = New System.Windows.Forms.Label()
Me.btnAdicionar = New System.Windows.Forms.Button()
Me.txtCosto = New System.Windows.Forms.TextBox()
Me.txtCantidad = New System.Windows.Forms.TextBox()
Me.Label5 = New System.Windows.Forms.Label()
Me.Label4 = New System.Windows.Forms.Label()
Me.Label6 = New System.Windows.Forms.Label()
Me.cmbProducto = New System.Windows.Forms.ComboBox()
Me.TextBox1 = New System.Windows.Forms.TextBox()
Me.btnBuscarDoc = New System.Windows.Forms.Button()
Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
Me.Label7 = New System.Windows.Forms.Label()
Me.txtObservacion = New System.Windows.Forms.TextBox()
Me.Label8 = New System.Windows.Forms.Label()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
CType(Me.grMovInventario, System.ComponentModel.ISupportInitialize).BeginInit()
Me.Panel1.SuspendLayout()
Me.grpAddMateriales.SuspendLayout()
Me.SuspendLayout()
'
'flyPanelBotones
'
Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
Me.flyPanelBotones.Controls.Add(Me.pnlControles)
Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
Me.flyPanelBotones.Controls.Add(Me.btnCargar)
Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
Me.flyPanelBotones.Controls.Add(Me.btnCotizar)
Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flyPanelBotones.Location = New System.Drawing.Point(785, 0)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(190, 590)
Me.flyPanelBotones.TabIndex = 3
'
'pnlControles
'
Me.pnlControles.Controls.Add(Me.btnBotonera)
Me.pnlControles.Location = New System.Drawing.Point(3, 3)
Me.pnlControles.Name = "pnlControles"
Me.pnlControles.Size = New System.Drawing.Size(174, 22)
Me.pnlControles.TabIndex = 10
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
Me.btnBotonera.Location = New System.Drawing.Point(3, 0)
Me.btnBotonera.Name = "btnBotonera"
Me.btnBotonera.Size = New System.Drawing.Size(28, 19)
Me.btnBotonera.TabIndex = 83
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
'
'btnCargar
'
Me.btnCargar.FlatAppearance.BorderSize = 0
Me.btnCargar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnCargar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnCargar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCargar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCargar.ForeColor = System.Drawing.Color.White
Me.btnCargar.Image = CType(resources.GetObject("btnCargar.Image"), System.Drawing.Image)
Me.btnCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCargar.Location = New System.Drawing.Point(3, 72)
Me.btnCargar.Name = "btnCargar"
Me.btnCargar.Size = New System.Drawing.Size(189, 35)
Me.btnCargar.TabIndex = 12
Me.btnCargar.Text = "Cargar"
Me.btnCargar.UseVisualStyleBackColor = True
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
Me.btnImprimir.Location = New System.Drawing.Point(3, 113)
Me.btnImprimir.Name = "btnImprimir"
Me.btnImprimir.Size = New System.Drawing.Size(189, 35)
Me.btnImprimir.TabIndex = 13
Me.btnImprimir.Text = "Imprimir"
Me.btnImprimir.UseVisualStyleBackColor = True
'
'btnCotizar
'
Me.btnCotizar.FlatAppearance.BorderSize = 0
Me.btnCotizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnCotizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnCotizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCotizar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCotizar.ForeColor = System.Drawing.Color.White
Me.btnCotizar.Image = CType(resources.GetObject("btnCotizar.Image"), System.Drawing.Image)
Me.btnCotizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCotizar.Location = New System.Drawing.Point(3, 154)
Me.btnCotizar.Name = "btnCotizar"
Me.btnCotizar.Size = New System.Drawing.Size(189, 35)
Me.btnCotizar.TabIndex = 14
Me.btnCotizar.Text = "Cot"
Me.btnCotizar.UseVisualStyleBackColor = True
'
'grMovInventario
'
Me.grMovInventario.AllowUserToAddRows = False
Me.grMovInventario.AllowUserToDeleteRows = False
Me.grMovInventario.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grMovInventario.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.grMovInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grMovInventario.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItem, Me.colCodInventario, Me.colDescMaterial, Me.colCant, Me.colUM})
DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grMovInventario.DefaultCellStyle = DataGridViewCellStyle2
Me.grMovInventario.Location = New System.Drawing.Point(4, 258)
Me.grMovInventario.Name = "grMovInventario"
Me.grMovInventario.RowHeadersVisible = False
Me.grMovInventario.Size = New System.Drawing.Size(771, 320)
Me.grMovInventario.TabIndex = 9
'
'colItem
'
Me.colItem.HeaderText = "Item"
Me.colItem.Name = "colItem"
Me.colItem.Width = 30
'
'colCodInventario
'
Me.colCodInventario.HeaderText = "Material"
Me.colCodInventario.Name = "colCodInventario"
'
'colDescMaterial
'
Me.colDescMaterial.HeaderText = "Descripción"
Me.colDescMaterial.Name = "colDescMaterial"
Me.colDescMaterial.Width = 350
'
'colCant
'
Me.colCant.HeaderText = "Cant"
Me.colCant.Name = "colCant"
'
'colUM
'
Me.colUM.HeaderText = "UM"
Me.colUM.Name = "colUM"
Me.colUM.Width = 30
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(7, 29)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(42, 13)
Me.Label2.TabIndex = 19
Me.Label2.Text = "Motivo:"
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(7, 79)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(65, 13)
Me.Label1.TabIndex = 20
Me.Label1.Text = "Documento:"
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(7, 54)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(31, 13)
Me.Label3.TabIndex = 21
Me.Label3.Text = "Tipo:"
'
'rbtEntrada
'
Me.rbtEntrada.AutoSize = True
Me.rbtEntrada.Checked = True
Me.rbtEntrada.Location = New System.Drawing.Point(11, 5)
Me.rbtEntrada.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.rbtEntrada.Name = "rbtEntrada"
Me.rbtEntrada.Size = New System.Drawing.Size(62, 17)
Me.rbtEntrada.TabIndex = 0
Me.rbtEntrada.TabStop = True
Me.rbtEntrada.Text = "Entrada"
Me.rbtEntrada.UseVisualStyleBackColor = True
'
'rbtSalida
'
Me.rbtSalida.AutoSize = True
Me.rbtSalida.Location = New System.Drawing.Point(75, 5)
Me.rbtSalida.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.rbtSalida.Name = "rbtSalida"
Me.rbtSalida.Size = New System.Drawing.Size(54, 17)
Me.rbtSalida.TabIndex = 1
Me.rbtSalida.Text = "Salida"
Me.rbtSalida.UseVisualStyleBackColor = True
'
'txtDocumento
'
Me.txtDocumento.Location = New System.Drawing.Point(89, 77)
Me.txtDocumento.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.txtDocumento.MaxLength = 15
Me.txtDocumento.Name = "txtDocumento"
Me.txtDocumento.Size = New System.Drawing.Size(226, 20)
Me.txtDocumento.TabIndex = 3
'
'cmbTipoDocumento
'
Me.cmbTipoDocumento.FormattingEnabled = True
Me.cmbTipoDocumento.Items.AddRange(New Object() {"Sub Tarea"})
Me.cmbTipoDocumento.Location = New System.Drawing.Point(89, 52)
Me.cmbTipoDocumento.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.cmbTipoDocumento.Name = "cmbTipoDocumento"
Me.cmbTipoDocumento.Size = New System.Drawing.Size(226, 21)
Me.cmbTipoDocumento.TabIndex = 2
'
'Panel1
'
Me.Panel1.Controls.Add(Me.rbtSalida)
Me.Panel1.Controls.Add(Me.rbtEntrada)
Me.Panel1.Enabled = False
Me.Panel1.Location = New System.Drawing.Point(343, 26)
Me.Panel1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(137, 27)
Me.Panel1.TabIndex = 25
'
'cmbMotivo
'
Me.cmbMotivo.FormattingEnabled = True
Me.cmbMotivo.Items.AddRange(New Object() {"Salida a Producción"})
Me.cmbMotivo.Location = New System.Drawing.Point(89, 27)
Me.cmbMotivo.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.cmbMotivo.Name = "cmbMotivo"
Me.cmbMotivo.Size = New System.Drawing.Size(226, 21)
Me.cmbMotivo.TabIndex = 1
'
'grpAddMateriales
'
Me.grpAddMateriales.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grpAddMateriales.Controls.Add(Me.Label27)
Me.grpAddMateriales.Controls.Add(Me.txtDescItem)
Me.grpAddMateriales.Controls.Add(Me.lblTipoUnidad)
Me.grpAddMateriales.Controls.Add(Me.btnAdicionar)
Me.grpAddMateriales.Controls.Add(Me.txtCosto)
Me.grpAddMateriales.Controls.Add(Me.txtCantidad)
Me.grpAddMateriales.Controls.Add(Me.Label5)
Me.grpAddMateriales.Controls.Add(Me.Label4)
Me.grpAddMateriales.Controls.Add(Me.Label6)
Me.grpAddMateriales.Controls.Add(Me.cmbProducto)
Me.grpAddMateriales.Location = New System.Drawing.Point(4, 137)
Me.grpAddMateriales.Name = "grpAddMateriales"
Me.grpAddMateriales.Size = New System.Drawing.Size(769, 115)
Me.grpAddMateriales.TabIndex = 27
Me.grpAddMateriales.TabStop = False
'
'Label27
'
Me.Label27.AutoSize = True
Me.Label27.Location = New System.Drawing.Point(7, 67)
Me.Label27.Name = "Label27"
Me.Label27.Size = New System.Drawing.Size(58, 13)
Me.Label27.TabIndex = 24
Me.Label27.Text = "Desc Item:"
'
'txtDescItem
'
Me.txtDescItem.Location = New System.Drawing.Point(85, 67)
Me.txtDescItem.MaxLength = 200
Me.txtDescItem.Multiline = True
Me.txtDescItem.Name = "txtDescItem"
Me.txtDescItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtDescItem.Size = New System.Drawing.Size(488, 34)
Me.txtDescItem.TabIndex = 7
'
'lblTipoUnidad
'
Me.lblTipoUnidad.AutoSize = True
Me.lblTipoUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblTipoUnidad.Location = New System.Drawing.Point(223, 43)
Me.lblTipoUnidad.Name = "lblTipoUnidad"
Me.lblTipoUnidad.Size = New System.Drawing.Size(12, 15)
Me.lblTipoUnidad.TabIndex = 17
Me.lblTipoUnidad.Text = " "
'
'btnAdicionar
'
Me.btnAdicionar.Location = New System.Drawing.Point(466, 42)
Me.btnAdicionar.Name = "btnAdicionar"
Me.btnAdicionar.Size = New System.Drawing.Size(107, 20)
Me.btnAdicionar.TabIndex = 8
Me.btnAdicionar.Text = "Adicionar"
Me.btnAdicionar.UseVisualStyleBackColor = True
'
'txtCosto
'
Me.txtCosto.Location = New System.Drawing.Point(319, 41)
Me.txtCosto.Name = "txtCosto"
Me.txtCosto.Size = New System.Drawing.Size(108, 20)
Me.txtCosto.TabIndex = 6
Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'txtCantidad
'
Me.txtCantidad.Location = New System.Drawing.Point(85, 41)
Me.txtCantidad.Name = "txtCantidad"
Me.txtCantidad.Size = New System.Drawing.Size(132, 20)
Me.txtCantidad.TabIndex = 5
Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(276, 45)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(37, 13)
Me.Label5.TabIndex = 3
Me.Label5.Text = "Costo:"
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(7, 41)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(49, 13)
Me.Label4.TabIndex = 2
Me.Label4.Text = "Cantidad"
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(7, 18)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(53, 13)
Me.Label6.TabIndex = 1
Me.Label6.Text = "Producto:"
'
'cmbProducto
'
Me.cmbProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.cmbProducto.FormattingEnabled = True
Me.cmbProducto.Location = New System.Drawing.Point(85, 15)
Me.cmbProducto.MaxLength = 2000
Me.cmbProducto.Name = "cmbProducto"
Me.cmbProducto.Size = New System.Drawing.Size(488, 21)
Me.cmbProducto.TabIndex = 4
'
'TextBox1
'
Me.TextBox1.Location = New System.Drawing.Point(75, 53)
Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
Me.TextBox1.MaxLength = 15
Me.TextBox1.Name = "TextBox1"
Me.TextBox1.Size = New System.Drawing.Size(226, 20)
Me.TextBox1.TabIndex = 3
'
'btnBuscarDoc
'
Me.btnBuscarDoc.Location = New System.Drawing.Point(322, 77)
Me.btnBuscarDoc.Name = "btnBuscarDoc"
Me.btnBuscarDoc.Size = New System.Drawing.Size(30, 20)
Me.btnBuscarDoc.TabIndex = 28
Me.btnBuscarDoc.Text = "..."
Me.btnBuscarDoc.UseVisualStyleBackColor = True
'
'dtpFecha
'
Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFecha.Location = New System.Drawing.Point(89, 4)
Me.dtpFecha.Name = "dtpFecha"
Me.dtpFecha.Size = New System.Drawing.Size(106, 20)
Me.dtpFecha.TabIndex = 29
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(7, 104)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(70, 13)
Me.Label7.TabIndex = 31
Me.Label7.Text = "Observación:"
'
'txtObservacion
'
Me.txtObservacion.Location = New System.Drawing.Point(89, 101)
Me.txtObservacion.MaxLength = 500
Me.txtObservacion.Multiline = True
Me.txtObservacion.Name = "txtObservacion"
Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtObservacion.Size = New System.Drawing.Size(415, 37)
Me.txtObservacion.TabIndex = 30
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(7, 6)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(40, 13)
Me.Label8.TabIndex = 32
Me.Label8.Text = "Fecha:"
'
'OLD_frmMovInventario
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(975, 590)
Me.Controls.Add(Me.Label8)
Me.Controls.Add(Me.Label7)
Me.Controls.Add(Me.txtObservacion)
Me.Controls.Add(Me.dtpFecha)
Me.Controls.Add(Me.btnBuscarDoc)
Me.Controls.Add(Me.grpAddMateriales)
Me.Controls.Add(Me.cmbMotivo)
Me.Controls.Add(Me.Panel1)
Me.Controls.Add(Me.cmbTipoDocumento)
Me.Controls.Add(Me.txtDocumento)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.grMovInventario)
Me.Controls.Add(Me.flyPanelBotones)
Me.Name = "OLD_frmMovInventario"
Me.Text = "OLD Inventarios"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
CType(Me.grMovInventario, System.ComponentModel.ISupportInitialize).EndInit()
Me.Panel1.ResumeLayout(False)
Me.Panel1.PerformLayout()
Me.grpAddMateriales.ResumeLayout(False)
Me.grpAddMateriales.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
  Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents pnlControles As System.Windows.Forms.Panel
  Friend WithEvents btnBotonera As System.Windows.Forms.Button
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents btnCargar As System.Windows.Forms.Button
  Friend WithEvents btnImprimir As System.Windows.Forms.Button
  Friend WithEvents grMovInventario As System.Windows.Forms.DataGridView
  Friend WithEvents btnCotizar As System.Windows.Forms.Button
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents rbtEntrada As System.Windows.Forms.RadioButton
  Friend WithEvents rbtSalida As System.Windows.Forms.RadioButton
  Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
  Friend WithEvents cmbTipoDocumento As System.Windows.Forms.ComboBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents cmbMotivo As System.Windows.Forms.ComboBox
  Friend WithEvents grpAddMateriales As System.Windows.Forms.GroupBox
  Friend WithEvents Label27 As System.Windows.Forms.Label
  Friend WithEvents txtDescItem As System.Windows.Forms.TextBox
  Friend WithEvents lblTipoUnidad As System.Windows.Forms.Label
  Friend WithEvents btnAdicionar As System.Windows.Forms.Button
  Friend WithEvents txtCosto As System.Windows.Forms.TextBox
  Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents btnBuscarDoc As System.Windows.Forms.Button
  Friend WithEvents colItem As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colDescMaterial As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colUM As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
  Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
