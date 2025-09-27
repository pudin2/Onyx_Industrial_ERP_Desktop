<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidoManual
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidoManual))
    Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
    Me.pnlControles = New System.Windows.Forms.Panel()
    Me.btnBotonera = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.btnCotizar = New System.Windows.Forms.Button()
    Me.btnAprobar = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.lblUnidad_Id = New System.Windows.Forms.Label()
    Me.Label27 = New System.Windows.Forms.Label()
    Me.txtDescItem = New System.Windows.Forms.TextBox()
    Me.lblTotalMateriales = New System.Windows.Forms.Label()
    Me.lblTipoUnidad = New System.Windows.Forms.Label()
    Me.btnAdicionar = New System.Windows.Forms.Button()
    Me.txtCosto = New System.Windows.Forms.TextBox()
    Me.txtCantidad = New System.Windows.Forms.TextBox()
    Me.grProductos = New System.Windows.Forms.DataGridView()
    Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCodigoInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCostoTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colDescItem = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colAgregar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.colIdUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.cmbProducto = New System.Windows.Forms.ComboBox()
    Me.dtpFechaRequerida = New System.Windows.Forms.DateTimePicker()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.ssBarraEstado = New System.Windows.Forms.StatusStrip()
    Me.sslEstado = New System.Windows.Forms.ToolStripStatusLabel()
    Me.txtOT = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.cmbCliente = New System.Windows.Forms.ComboBox()
    Me.lblOT = New System.Windows.Forms.Label()
    Me.pnlOrdenDeTrabajo = New System.Windows.Forms.Panel()
    Me.flyPanelBotones.SuspendLayout()
    Me.pnlControles.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.ssBarraEstado.SuspendLayout()
    Me.pnlOrdenDeTrabajo.SuspendLayout()
    Me.SuspendLayout()
    '
    'flyPanelBotones
    '
    Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer))
    Me.flyPanelBotones.Controls.Add(Me.pnlControles)
    Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
    Me.flyPanelBotones.Controls.Add(Me.btnCargar)
    Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
    Me.flyPanelBotones.Controls.Add(Me.btnCotizar)
    Me.flyPanelBotones.Controls.Add(Me.btnAprobar)
    Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
    Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
    Me.flyPanelBotones.Location = New System.Drawing.Point(959, 0)
    Me.flyPanelBotones.Name = "flyPanelBotones"
    Me.flyPanelBotones.Size = New System.Drawing.Size(190, 662)
    Me.flyPanelBotones.TabIndex = 4
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
    Me.btnGrabar.TabIndex = 15
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
    Me.btnCargar.TabIndex = 20
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
    Me.btnImprimir.TabIndex = 16
    Me.btnImprimir.Text = "Imprimir"
    Me.btnImprimir.UseVisualStyleBackColor = True
    Me.btnImprimir.Visible = False
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
    Me.btnCotizar.TabIndex = 83
    Me.btnCotizar.Text = "Cot"
    Me.btnCotizar.UseVisualStyleBackColor = True
    Me.btnCotizar.Visible = False
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
    Me.btnAprobar.Location = New System.Drawing.Point(3, 195)
    Me.btnAprobar.Name = "btnAprobar"
    Me.btnAprobar.Size = New System.Drawing.Size(189, 35)
    Me.btnAprobar.TabIndex = 84
    Me.btnAprobar.Text = "Aprobar"
    Me.btnAprobar.UseVisualStyleBackColor = True
    Me.btnAprobar.Visible = False
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.lblUnidad_Id)
    Me.GroupBox1.Controls.Add(Me.Label27)
    Me.GroupBox1.Controls.Add(Me.txtDescItem)
    Me.GroupBox1.Controls.Add(Me.lblTotalMateriales)
    Me.GroupBox1.Controls.Add(Me.lblTipoUnidad)
    Me.GroupBox1.Controls.Add(Me.btnAdicionar)
    Me.GroupBox1.Controls.Add(Me.txtCosto)
    Me.GroupBox1.Controls.Add(Me.txtCantidad)
    Me.GroupBox1.Controls.Add(Me.grProductos)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label4)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.cmbProducto)
    Me.GroupBox1.Location = New System.Drawing.Point(8, 46)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(945, 616)
    Me.GroupBox1.TabIndex = 7
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Productos"
    '
    'lblUnidad_Id
    '
    Me.lblUnidad_Id.AutoSize = True
    Me.lblUnidad_Id.Location = New System.Drawing.Point(592, 41)
    Me.lblUnidad_Id.Name = "lblUnidad_Id"
    Me.lblUnidad_Id.Size = New System.Drawing.Size(52, 13)
    Me.lblUnidad_Id.TabIndex = 25
    Me.lblUnidad_Id.Text = "UnidadID"
    Me.lblUnidad_Id.Visible = False
    '
    'Label27
    '
    Me.Label27.AutoSize = True
    Me.Label27.Location = New System.Drawing.Point(6, 67)
    Me.Label27.Name = "Label27"
    Me.Label27.Size = New System.Drawing.Size(58, 13)
    Me.Label27.TabIndex = 24
    Me.Label27.Text = "Desc Item:"
    '
    'txtDescItem
    '
    Me.txtDescItem.Location = New System.Drawing.Point(69, 67)
    Me.txtDescItem.MaxLength = 200
    Me.txtDescItem.Multiline = True
    Me.txtDescItem.Name = "txtDescItem"
    Me.txtDescItem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtDescItem.Size = New System.Drawing.Size(488, 34)
    Me.txtDescItem.TabIndex = 3
    '
    'lblTotalMateriales
    '
    Me.lblTotalMateriales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lblTotalMateriales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblTotalMateriales.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTotalMateriales.Location = New System.Drawing.Point(784, 15)
    Me.lblTotalMateriales.Name = "lblTotalMateriales"
    Me.lblTotalMateriales.Size = New System.Drawing.Size(155, 44)
    Me.lblTotalMateriales.TabIndex = 23
    Me.lblTotalMateriales.Text = "0000"
    Me.lblTotalMateriales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'lblTipoUnidad
    '
    Me.lblTipoUnidad.AutoSize = True
    Me.lblTipoUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblTipoUnidad.Location = New System.Drawing.Point(207, 43)
    Me.lblTipoUnidad.Name = "lblTipoUnidad"
    Me.lblTipoUnidad.Size = New System.Drawing.Size(12, 15)
    Me.lblTipoUnidad.TabIndex = 17
    Me.lblTipoUnidad.Text = " "
    '
    'btnAdicionar
    '
    Me.btnAdicionar.Location = New System.Drawing.Point(450, 40)
    Me.btnAdicionar.Name = "btnAdicionar"
    Me.btnAdicionar.Size = New System.Drawing.Size(107, 20)
    Me.btnAdicionar.TabIndex = 3
    Me.btnAdicionar.Text = "Adicionar"
    Me.btnAdicionar.UseVisualStyleBackColor = True
    '
    'txtCosto
    '
    Me.txtCosto.Location = New System.Drawing.Point(303, 41)
    Me.txtCosto.Name = "txtCosto"
    Me.txtCosto.Size = New System.Drawing.Size(108, 20)
    Me.txtCosto.TabIndex = 2
    Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'txtCantidad
    '
    Me.txtCantidad.Location = New System.Drawing.Point(69, 41)
    Me.txtCantidad.Name = "txtCantidad"
    Me.txtCantidad.Size = New System.Drawing.Size(132, 20)
    Me.txtCantidad.TabIndex = 1
    Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'grProductos
    '
    Me.grProductos.AllowUserToAddRows = False
    Me.grProductos.AllowUserToOrderColumns = True
    Me.grProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
    Me.grProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colCodigoInventario, Me.colDescripcion, Me.colCantidad, Me.colCosto, Me.colCostoTotal, Me.colDescItem, Me.colAgregar, Me.colIdUnidad})
    DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grProductos.DefaultCellStyle = DataGridViewCellStyle23
    Me.grProductos.Location = New System.Drawing.Point(0, 120)
    Me.grProductos.Name = "grProductos"
    DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle24
    Me.grProductos.RowHeadersWidth = 20
    Me.grProductos.RowTemplate.DefaultCellStyle.Format = "N2"
    Me.grProductos.RowTemplate.DefaultCellStyle.NullValue = Nothing
    Me.grProductos.Size = New System.Drawing.Size(934, 471)
    Me.grProductos.TabIndex = 4
    '
    'colId
    '
    DataGridViewCellStyle18.BackColor = System.Drawing.Color.Silver
    DataGridViewCellStyle18.Format = "N0"
    DataGridViewCellStyle18.NullValue = Nothing
    Me.colId.DefaultCellStyle = DataGridViewCellStyle18
    Me.colId.DividerWidth = 1
    Me.colId.Frozen = True
    Me.colId.HeaderText = "Id"
    Me.colId.Name = "colId"
    Me.colId.ReadOnly = True
    Me.colId.Width = 30
    '
    'colCodigoInventario
    '
    Me.colCodigoInventario.DividerWidth = 1
    Me.colCodigoInventario.HeaderText = "Código"
    Me.colCodigoInventario.Name = "colCodigoInventario"
    Me.colCodigoInventario.ReadOnly = True
    Me.colCodigoInventario.Width = 60
    '
    'colDescripcion
    '
    Me.colDescripcion.DividerWidth = 1
    Me.colDescripcion.HeaderText = "Descripción"
    Me.colDescripcion.Name = "colDescripcion"
    Me.colDescripcion.ReadOnly = True
    Me.colDescripcion.Width = 70
    '
    'colCantidad
    '
    Me.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle19.Format = "N2"
    DataGridViewCellStyle19.NullValue = "0"
    Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle19
    Me.colCantidad.DividerWidth = 1
    Me.colCantidad.HeaderText = "Cantidad"
    Me.colCantidad.Name = "colCantidad"
    Me.colCantidad.Width = 75
    '
    'colCosto
    '
    Me.colCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle20.Format = "N2"
    DataGridViewCellStyle20.NullValue = "0"
    Me.colCosto.DefaultCellStyle = DataGridViewCellStyle20
    Me.colCosto.DividerWidth = 1
    Me.colCosto.HeaderText = "C/U"
    Me.colCosto.MinimumWidth = 71
    Me.colCosto.Name = "colCosto"
    Me.colCosto.Width = 71
    '
    'colCostoTotal
    '
    Me.colCostoTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle21.Format = "N2"
    DataGridViewCellStyle21.NullValue = "0"
    Me.colCostoTotal.DefaultCellStyle = DataGridViewCellStyle21
    Me.colCostoTotal.DividerWidth = 1
    Me.colCostoTotal.HeaderText = "Costo Total"
    Me.colCostoTotal.Name = "colCostoTotal"
    Me.colCostoTotal.ReadOnly = True
    Me.colCostoTotal.Width = 87
    '
    'colDescItem
    '
    DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.colDescItem.DefaultCellStyle = DataGridViewCellStyle22
    Me.colDescItem.HeaderText = "Desc Item"
    Me.colDescItem.MaxInputLength = 200
    Me.colDescItem.Name = "colDescItem"
    '
    'colAgregar
    '
    Me.colAgregar.DividerWidth = 1
    Me.colAgregar.HeaderText = "Adicionar"
    Me.colAgregar.Name = "colAgregar"
    Me.colAgregar.Width = 60
    '
    'colIdUnidad
    '
    Me.colIdUnidad.HeaderText = "UnidadId"
    Me.colIdUnidad.Name = "colIdUnidad"
    Me.colIdUnidad.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(260, 45)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(37, 13)
    Me.Label5.TabIndex = 3
    Me.Label5.Text = "Costo:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(6, 41)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(49, 13)
    Me.Label4.TabIndex = 2
    Me.Label4.Text = "Cantidad"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(6, 18)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "Producto:"
    '
    'cmbProducto
    '
    Me.cmbProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbProducto.FormattingEnabled = True
    Me.cmbProducto.Location = New System.Drawing.Point(69, 15)
    Me.cmbProducto.MaxLength = 2000
    Me.cmbProducto.Name = "cmbProducto"
    Me.cmbProducto.Size = New System.Drawing.Size(709, 21)
    Me.cmbProducto.TabIndex = 0
    '
    'dtpFechaRequerida
    '
    Me.dtpFechaRequerida.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFechaRequerida.Location = New System.Drawing.Point(110, 20)
    Me.dtpFechaRequerida.Name = "dtpFechaRequerida"
    Me.dtpFechaRequerida.Size = New System.Drawing.Size(117, 20)
    Me.dtpFechaRequerida.TabIndex = 8
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 20)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(92, 13)
    Me.Label1.TabIndex = 25
    Me.Label1.Text = "Fecha Requerida:"
    '
    'ssBarraEstado
    '
    Me.ssBarraEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sslEstado})
    Me.ssBarraEstado.Location = New System.Drawing.Point(0, 640)
    Me.ssBarraEstado.Name = "ssBarraEstado"
    Me.ssBarraEstado.Size = New System.Drawing.Size(959, 22)
    Me.ssBarraEstado.TabIndex = 26
    Me.ssBarraEstado.Text = "StatusStrip1"
    '
    'sslEstado
    '
    Me.sslEstado.Name = "sslEstado"
    Me.sslEstado.Size = New System.Drawing.Size(0, 17)
    '
    'txtOT
    '
    Me.txtOT.Location = New System.Drawing.Point(576, 17)
    Me.txtOT.MaxLength = 100
    Me.txtOT.Name = "txtOT"
    Me.txtOT.Size = New System.Drawing.Size(114, 20)
    Me.txtOT.TabIndex = 83
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(3, 17)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(42, 13)
    Me.Label12.TabIndex = 82
    Me.Label12.Text = "Cliente:"
    '
    'cmbCliente
    '
    Me.cmbCliente.FormattingEnabled = True
    Me.cmbCliente.Location = New System.Drawing.Point(51, 16)
    Me.cmbCliente.Name = "cmbCliente"
    Me.cmbCliente.Size = New System.Drawing.Size(450, 21)
    Me.cmbCliente.TabIndex = 81
    '
    'lblOT
    '
    Me.lblOT.AutoSize = True
    Me.lblOT.Location = New System.Drawing.Point(507, 17)
    Me.lblOT.Name = "lblOT"
    Me.lblOT.Size = New System.Drawing.Size(63, 13)
    Me.lblOT.TabIndex = 84
    Me.lblOT.Text = "OT Cliente: "
    '
    'pnlOrdenDeTrabajo
    '
    Me.pnlOrdenDeTrabajo.Controls.Add(Me.txtOT)
    Me.pnlOrdenDeTrabajo.Controls.Add(Me.Label12)
    Me.pnlOrdenDeTrabajo.Controls.Add(Me.lblOT)
    Me.pnlOrdenDeTrabajo.Controls.Add(Me.cmbCliente)
    Me.pnlOrdenDeTrabajo.Location = New System.Drawing.Point(233, 3)
    Me.pnlOrdenDeTrabajo.Name = "pnlOrdenDeTrabajo"
    Me.pnlOrdenDeTrabajo.Size = New System.Drawing.Size(714, 45)
    Me.pnlOrdenDeTrabajo.TabIndex = 85
    Me.pnlOrdenDeTrabajo.Visible = False
    '
    'frmPedidoManual
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1149, 662)
    Me.Controls.Add(Me.pnlOrdenDeTrabajo)
    Me.Controls.Add(Me.ssBarraEstado)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.dtpFechaRequerida)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.flyPanelBotones)
    Me.Name = "frmPedidoManual"
    Me.Text = "Pedido Manual"
    Me.flyPanelBotones.ResumeLayout(False)
    Me.pnlControles.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ssBarraEstado.ResumeLayout(False)
    Me.ssBarraEstado.PerformLayout()
    Me.pnlOrdenDeTrabajo.ResumeLayout(False)
    Me.pnlOrdenDeTrabajo.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCotizar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents txtDescItem As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalMateriales As System.Windows.Forms.Label
    Friend WithEvents lblTipoUnidad As System.Windows.Forms.Label
    Friend WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents txtCosto As System.Windows.Forms.TextBox
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents grProductos As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaRequerida As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents ssBarraEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents lblUnidad_Id As System.Windows.Forms.Label
    Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCodigoInventario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCostoTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDescItem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAgregar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colIdUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sslEstado As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents txtOT As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents lblOT As System.Windows.Forms.Label
    Friend WithEvents pnlOrdenDeTrabajo As System.Windows.Forms.Panel
End Class
