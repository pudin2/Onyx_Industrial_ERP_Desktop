<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngresosOC
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
Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresosOC))
Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
Me.lblMensaje = New System.Windows.Forms.Label()
Me.chkIngresosZiur = New System.Windows.Forms.CheckBox()
Me.Button2 = New System.Windows.Forms.Button()
Me.Label5 = New System.Windows.Forms.Label()
Me.txtOC = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.Label4 = New System.Windows.Forms.Label()
Me.Button1 = New System.Windows.Forms.Button()
Me.grpEstados = New System.Windows.Forms.GroupBox()
Me.optOCRegistradas = New System.Windows.Forms.RadioButton()
Me.optOCAprobadas = New System.Windows.Forms.RadioButton()
Me.optOCTodas = New System.Windows.Forms.RadioButton()
Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
Me.grOrdenesCompra = New System.Windows.Forms.DataGridView()
Me.tbcDetalle = New System.Windows.Forms.TabControl()
Me.TabPage1 = New System.Windows.Forms.TabPage()
Me.chkIngresaTodo = New System.Windows.Forms.CheckBox()
Me.grIngresosOC = New System.Windows.Forms.DataGridView()
Me.colTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colNumZiur = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colRemisionCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCodInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colProducto = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colIdEncabMov = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colEstadoFila = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.grDetalle = New System.Windows.Forms.DataGridView()
Me.colOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCodInventario2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colProducto2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colCantidad2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colValorUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colValortotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colUnidad2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colIngresos = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colBoton = New System.Windows.Forms.DataGridViewButtonColumn()
Me.lblItemsOnyx = New System.Windows.Forms.TextBox()
Me.Label7 = New System.Windows.Forms.Label()
Me.lblItemsZiur = New System.Windows.Forms.TextBox()
Me.Label6 = New System.Windows.Forms.Label()
Me.txtOCompra = New System.Windows.Forms.TextBox()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtProveedor = New System.Windows.Forms.TextBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.TabPage2 = New System.Windows.Forms.TabPage()
Me.grRemisionZiur = New System.Windows.Forms.DataGridView()
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnActualizar = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.btnAprobar = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.btnOrdenCompra = New System.Windows.Forms.Button()
CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SplitContainer1.Panel1.SuspendLayout()
Me.SplitContainer1.Panel2.SuspendLayout()
Me.SplitContainer1.SuspendLayout()
Me.grpEstados.SuspendLayout()
CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
Me.tbcDetalle.SuspendLayout()
Me.TabPage1.SuspendLayout()
CType(Me.grIngresosOC, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
Me.TabPage2.SuspendLayout()
CType(Me.grRemisionZiur, System.ComponentModel.ISupportInitialize).BeginInit()
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
Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
Me.SplitContainer1.Name = "SplitContainer1"
'
'SplitContainer1.Panel1
'
Me.SplitContainer1.Panel1.Controls.Add(Me.lblMensaje)
Me.SplitContainer1.Panel1.Controls.Add(Me.chkIngresosZiur)
Me.SplitContainer1.Panel1.Controls.Add(Me.Button2)
Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
Me.SplitContainer1.Panel1.Controls.Add(Me.txtOC)
Me.SplitContainer1.Panel1.Controls.Add(Me.Label3)
Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
Me.SplitContainer1.Panel1.Controls.Add(Me.Button1)
Me.SplitContainer1.Panel1.Controls.Add(Me.grpEstados)
Me.SplitContainer1.Panel1.Controls.Add(Me.dtpInicial)
Me.SplitContainer1.Panel1.Controls.Add(Me.dtpFinal)
Me.SplitContainer1.Panel1.Controls.Add(Me.grOrdenesCompra)
'
'SplitContainer1.Panel2
'
Me.SplitContainer1.Panel2.Controls.Add(Me.tbcDetalle)
Me.SplitContainer1.Size = New System.Drawing.Size(1154, 695)
Me.SplitContainer1.SplitterDistance = 275
Me.SplitContainer1.TabIndex = 0
'
'lblMensaje
'
Me.lblMensaje.AutoSize = True
Me.lblMensaje.Location = New System.Drawing.Point(175, 8)
Me.lblMensaje.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
Me.lblMensaje.Name = "lblMensaje"
Me.lblMensaje.Size = New System.Drawing.Size(78, 13)
Me.lblMensaje.TabIndex = 15
Me.lblMensaje.Text = "Consultando ..."
'
'chkIngresosZiur
'
Me.chkIngresosZiur.AutoSize = True
Me.chkIngresosZiur.Location = New System.Drawing.Point(55, 7)
Me.chkIngresosZiur.Name = "chkIngresosZiur"
Me.chkIngresosZiur.Size = New System.Drawing.Size(108, 17)
Me.chkIngresosZiur.TabIndex = 14
Me.chkIngresosZiur.Text = "Con ingresos Ziur"
Me.chkIngresosZiur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
Me.chkIngresosZiur.UseVisualStyleBackColor = True
'
'Button2
'
Me.Button2.Location = New System.Drawing.Point(164, 98)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(101, 23)
Me.Button2.TabIndex = 13
Me.Button2.Text = "Confirmar"
Me.Button2.UseVisualStyleBackColor = True
Me.Button2.Visible = False
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(10, 73)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(25, 13)
Me.Label5.TabIndex = 12
Me.Label5.Text = "OC:"
'
'txtOC
'
Me.txtOC.Location = New System.Drawing.Point(57, 73)
Me.txtOC.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.txtOC.MaxLength = 15
Me.txtOC.Name = "txtOC"
Me.txtOC.Size = New System.Drawing.Size(101, 20)
Me.txtOC.TabIndex = 11
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(10, 29)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(41, 13)
Me.Label3.TabIndex = 10
Me.Label3.Text = "Desde:"
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(10, 50)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(38, 13)
Me.Label4.TabIndex = 9
Me.Label4.Text = "Hasta:"
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(57, 98)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(101, 23)
Me.Button1.TabIndex = 8
Me.Button1.Text = "Cargar"
Me.Button1.UseVisualStyleBackColor = True
'
'grpEstados
'
Me.grpEstados.Controls.Add(Me.optOCRegistradas)
Me.grpEstados.Controls.Add(Me.optOCAprobadas)
Me.grpEstados.Controls.Add(Me.optOCTodas)
Me.grpEstados.Location = New System.Drawing.Point(164, 20)
Me.grpEstados.Name = "grpEstados"
Me.grpEstados.Size = New System.Drawing.Size(101, 73)
Me.grpEstados.TabIndex = 7
Me.grpEstados.TabStop = False
'
'optOCRegistradas
'
Me.optOCRegistradas.AutoSize = True
Me.optOCRegistradas.Location = New System.Drawing.Point(10, 10)
Me.optOCRegistradas.Name = "optOCRegistradas"
Me.optOCRegistradas.Size = New System.Drawing.Size(81, 17)
Me.optOCRegistradas.TabIndex = 1
Me.optOCRegistradas.Text = "Registradas"
Me.optOCRegistradas.UseVisualStyleBackColor = True
'
'optOCAprobadas
'
Me.optOCAprobadas.AutoSize = True
Me.optOCAprobadas.Checked = True
Me.optOCAprobadas.Location = New System.Drawing.Point(10, 28)
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
Me.optOCTodas.Location = New System.Drawing.Point(10, 49)
Me.optOCTodas.Name = "optOCTodas"
Me.optOCTodas.Size = New System.Drawing.Size(55, 17)
Me.optOCTodas.TabIndex = 3
Me.optOCTodas.Text = "Todas"
Me.optOCTodas.UseVisualStyleBackColor = True
'
'dtpInicial
'
Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpInicial.Location = New System.Drawing.Point(57, 26)
Me.dtpInicial.Name = "dtpInicial"
Me.dtpInicial.Size = New System.Drawing.Size(101, 20)
Me.dtpInicial.TabIndex = 6
'
'dtpFinal
'
Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFinal.Location = New System.Drawing.Point(57, 49)
Me.dtpFinal.Name = "dtpFinal"
Me.dtpFinal.Size = New System.Drawing.Size(101, 20)
Me.dtpFinal.TabIndex = 5
'
'grOrdenesCompra
'
Me.grOrdenesCompra.AllowUserToAddRows = False
Me.grOrdenesCompra.AllowUserToDeleteRows = False
Me.grOrdenesCompra.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grOrdenesCompra.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.grOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grOrdenesCompra.DefaultCellStyle = DataGridViewCellStyle2
Me.grOrdenesCompra.Location = New System.Drawing.Point(3, 127)
Me.grOrdenesCompra.MultiSelect = False
Me.grOrdenesCompra.Name = "grOrdenesCompra"
Me.grOrdenesCompra.ReadOnly = True
DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grOrdenesCompra.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
Me.grOrdenesCompra.RowHeadersVisible = False
Me.grOrdenesCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.grOrdenesCompra.Size = New System.Drawing.Size(265, 560)
Me.grOrdenesCompra.TabIndex = 0
'
'tbcDetalle
'
Me.tbcDetalle.Controls.Add(Me.TabPage1)
Me.tbcDetalle.Controls.Add(Me.TabPage2)
Me.tbcDetalle.Dock = System.Windows.Forms.DockStyle.Fill
Me.tbcDetalle.Location = New System.Drawing.Point(0, 0)
Me.tbcDetalle.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.tbcDetalle.Name = "tbcDetalle"
Me.tbcDetalle.SelectedIndex = 0
Me.tbcDetalle.Size = New System.Drawing.Size(871, 691)
Me.tbcDetalle.TabIndex = 10
'
'TabPage1
'
Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
Me.TabPage1.Controls.Add(Me.chkIngresaTodo)
Me.TabPage1.Controls.Add(Me.grIngresosOC)
Me.TabPage1.Controls.Add(Me.grDetalle)
Me.TabPage1.Controls.Add(Me.lblItemsOnyx)
Me.TabPage1.Controls.Add(Me.Label7)
Me.TabPage1.Controls.Add(Me.lblItemsZiur)
Me.TabPage1.Controls.Add(Me.Label6)
Me.TabPage1.Controls.Add(Me.txtOCompra)
Me.TabPage1.Controls.Add(Me.Label2)
Me.TabPage1.Controls.Add(Me.txtProveedor)
Me.TabPage1.Controls.Add(Me.Label1)
Me.TabPage1.Location = New System.Drawing.Point(4, 22)
Me.TabPage1.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.TabPage1.Name = "TabPage1"
Me.TabPage1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.TabPage1.Size = New System.Drawing.Size(863, 665)
Me.TabPage1.TabIndex = 0
Me.TabPage1.Text = "Detalle OC"
'
'chkIngresaTodo
'
Me.chkIngresaTodo.AutoSize = True
Me.chkIngresaTodo.Location = New System.Drawing.Point(416, 10)
Me.chkIngresaTodo.Name = "chkIngresaTodo"
Me.chkIngresaTodo.Size = New System.Drawing.Size(92, 17)
Me.chkIngresaTodo.TabIndex = 16
Me.chkIngresaTodo.Text = "Ingresar Todo"
Me.chkIngresaTodo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
Me.chkIngresaTodo.UseVisualStyleBackColor = True
'
'grIngresosOC
'
Me.grIngresosOC.AllowUserToAddRows = False
Me.grIngresosOC.AllowUserToDeleteRows = False
Me.grIngresosOC.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grIngresosOC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grIngresosOC.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
Me.grIngresosOC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grIngresosOC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTipo, Me.colNumZiur, Me.colRemisionCliente, Me.colFecha, Me.colCodInventario, Me.colProducto, Me.colCantidad, Me.colUnidad, Me.colIdEncabMov, Me.colEstadoFila})
DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grIngresosOC.DefaultCellStyle = DataGridViewCellStyle6
Me.grIngresosOC.Location = New System.Drawing.Point(3, 474)
Me.grIngresosOC.Name = "grIngresosOC"
Me.grIngresosOC.ReadOnly = True
DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grIngresosOC.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
Me.grIngresosOC.RowHeadersVisible = False
Me.grIngresosOC.Size = New System.Drawing.Size(855, 188)
Me.grIngresosOC.TabIndex = 19
'
'colTipo
'
Me.colTipo.HeaderText = "TIPO"
Me.colTipo.Name = "colTipo"
Me.colTipo.ReadOnly = True
Me.colTipo.Width = 57
'
'colNumZiur
'
Me.colNumZiur.HeaderText = "NUM ZIUR"
Me.colNumZiur.Name = "colNumZiur"
Me.colNumZiur.ReadOnly = True
Me.colNumZiur.Width = 79
'
'colRemisionCliente
'
Me.colRemisionCliente.HeaderText = "REMISION CLIENTE"
Me.colRemisionCliente.Name = "colRemisionCliente"
Me.colRemisionCliente.ReadOnly = True
Me.colRemisionCliente.Width = 122
'
'colFecha
'
Me.colFecha.HeaderText = "FECHA"
Me.colFecha.Name = "colFecha"
Me.colFecha.ReadOnly = True
Me.colFecha.Width = 67
'
'colCodInventario
'
Me.colCodInventario.HeaderText = "COD INVENTARIO"
Me.colCodInventario.Name = "colCodInventario"
Me.colCodInventario.ReadOnly = True
Me.colCodInventario.Width = 114
'
'colProducto
'
Me.colProducto.HeaderText = "PRODUCTO"
Me.colProducto.Name = "colProducto"
Me.colProducto.ReadOnly = True
Me.colProducto.Width = 93
'
'colCantidad
'
DataGridViewCellStyle5.Format = "N2"
DataGridViewCellStyle5.NullValue = Nothing
Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle5
Me.colCantidad.HeaderText = "CANTIDAD"
Me.colCantidad.Name = "colCantidad"
Me.colCantidad.ReadOnly = True
Me.colCantidad.Width = 87
'
'colUnidad
'
Me.colUnidad.HeaderText = "UNIDAD"
Me.colUnidad.Name = "colUnidad"
Me.colUnidad.ReadOnly = True
Me.colUnidad.Width = 74
'
'colIdEncabMov
'
Me.colIdEncabMov.HeaderText = "IdEncabMov"
Me.colIdEncabMov.Name = "colIdEncabMov"
Me.colIdEncabMov.ReadOnly = True
Me.colIdEncabMov.Width = 93
'
'colEstadoFila
'
Me.colEstadoFila.HeaderText = "Estado Fila"
Me.colEstadoFila.Name = "colEstadoFila"
Me.colEstadoFila.ReadOnly = True
Me.colEstadoFila.Width = 78
'
'grDetalle
'
Me.grDetalle.AllowUserToAddRows = False
Me.grDetalle.AllowUserToDeleteRows = False
Me.grDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grDetalle.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOrden, Me.colID, Me.colCodInventario2, Me.colProducto2, Me.colCantidad2, Me.colValorUnitario, Me.colValortotal, Me.colUnidad2, Me.colIngresos, Me.colBoton})
DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grDetalle.DefaultCellStyle = DataGridViewCellStyle13
Me.grDetalle.Location = New System.Drawing.Point(3, 61)
Me.grDetalle.Name = "grDetalle"
Me.grDetalle.ReadOnly = True
DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grDetalle.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
Me.grDetalle.RowHeadersVisible = False
Me.grDetalle.Size = New System.Drawing.Size(855, 354)
Me.grDetalle.TabIndex = 18
'
'colOrden
'
Me.colOrden.HeaderText = "ORDEN"
Me.colOrden.Name = "colOrden"
Me.colOrden.ReadOnly = True
Me.colOrden.Width = 71
'
'colID
'
Me.colID.HeaderText = "ID"
Me.colID.Name = "colID"
Me.colID.ReadOnly = True
Me.colID.Width = 43
'
'colCodInventario2
'
Me.colCodInventario2.HeaderText = "COD INVENTARIO"
Me.colCodInventario2.Name = "colCodInventario2"
Me.colCodInventario2.ReadOnly = True
Me.colCodInventario2.Width = 114
'
'colProducto2
'
Me.colProducto2.HeaderText = "PRODUCTO"
Me.colProducto2.Name = "colProducto2"
Me.colProducto2.ReadOnly = True
Me.colProducto2.Width = 93
'
'colCantidad2
'
DataGridViewCellStyle9.Format = "N2"
DataGridViewCellStyle9.NullValue = Nothing
Me.colCantidad2.DefaultCellStyle = DataGridViewCellStyle9
Me.colCantidad2.HeaderText = "CANTIDAD"
Me.colCantidad2.Name = "colCantidad2"
Me.colCantidad2.ReadOnly = True
Me.colCantidad2.Width = 87
'
'colValorUnitario
'
DataGridViewCellStyle10.Format = "N2"
DataGridViewCellStyle10.NullValue = Nothing
Me.colValorUnitario.DefaultCellStyle = DataGridViewCellStyle10
Me.colValorUnitario.HeaderText = "VALOR UNITARIO"
Me.colValorUnitario.Name = "colValorUnitario"
Me.colValorUnitario.ReadOnly = True
Me.colValorUnitario.Width = 113
'
'colValortotal
'
DataGridViewCellStyle11.Format = "N2"
DataGridViewCellStyle11.NullValue = Nothing
Me.colValortotal.DefaultCellStyle = DataGridViewCellStyle11
Me.colValortotal.HeaderText = "VALOR TOTAL"
Me.colValortotal.Name = "colValortotal"
Me.colValortotal.ReadOnly = True
Me.colValortotal.Width = 97
'
'colUnidad2
'
Me.colUnidad2.HeaderText = "UNIDAD"
Me.colUnidad2.Name = "colUnidad2"
Me.colUnidad2.ReadOnly = True
Me.colUnidad2.Width = 74
'
'colIngresos
'
DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
DataGridViewCellStyle12.Format = "N2"
DataGridViewCellStyle12.NullValue = Nothing
Me.colIngresos.DefaultCellStyle = DataGridViewCellStyle12
Me.colIngresos.HeaderText = "INGRESOS"
Me.colIngresos.Name = "colIngresos"
Me.colIngresos.ReadOnly = True
Me.colIngresos.Width = 88
'
'colBoton
'
Me.colBoton.HeaderText = ""
Me.colBoton.Name = "colBoton"
Me.colBoton.ReadOnly = True
Me.colBoton.Text = "Ingresar"
Me.colBoton.Width = 5
'
'lblItemsOnyx
'
Me.lblItemsOnyx.Location = New System.Drawing.Point(340, 9)
Me.lblItemsOnyx.Name = "lblItemsOnyx"
Me.lblItemsOnyx.ReadOnly = True
Me.lblItemsOnyx.Size = New System.Drawing.Size(55, 20)
Me.lblItemsOnyx.TabIndex = 17
Me.lblItemsOnyx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(278, 11)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(62, 13)
Me.Label7.TabIndex = 16
Me.Label7.Text = "Items Onyx:"
'
'lblItemsZiur
'
Me.lblItemsZiur.Location = New System.Drawing.Point(208, 9)
Me.lblItemsZiur.Name = "lblItemsZiur"
Me.lblItemsZiur.ReadOnly = True
Me.lblItemsZiur.Size = New System.Drawing.Size(55, 20)
Me.lblItemsZiur.TabIndex = 15
Me.lblItemsZiur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(150, 11)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(56, 13)
Me.Label6.TabIndex = 14
Me.Label6.Text = "Items Ziur:"
'
'txtOCompra
'
Me.txtOCompra.Location = New System.Drawing.Point(69, 9)
Me.txtOCompra.Name = "txtOCompra"
Me.txtOCompra.ReadOnly = True
Me.txtOCompra.Size = New System.Drawing.Size(74, 20)
Me.txtOCompra.TabIndex = 13
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(4, 11)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(63, 13)
Me.Label2.TabIndex = 12
Me.Label2.Text = "Orden Cmp:"
'
'txtProveedor
'
Me.txtProveedor.Location = New System.Drawing.Point(69, 37)
Me.txtProveedor.Name = "txtProveedor"
Me.txtProveedor.ReadOnly = True
Me.txtProveedor.Size = New System.Drawing.Size(450, 20)
Me.txtProveedor.TabIndex = 11
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(4, 37)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(59, 13)
Me.Label1.TabIndex = 10
Me.Label1.Text = "Proveedor:"
'
'TabPage2
'
Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
Me.TabPage2.Controls.Add(Me.grRemisionZiur)
Me.TabPage2.Location = New System.Drawing.Point(4, 22)
Me.TabPage2.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.TabPage2.Name = "TabPage2"
Me.TabPage2.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.TabPage2.Size = New System.Drawing.Size(864, 665)
Me.TabPage2.TabIndex = 1
Me.TabPage2.Text = "Ingresos ZIUR"
'
'grRemisionZiur
'
Me.grRemisionZiur.AllowUserToAddRows = False
Me.grRemisionZiur.AllowUserToDeleteRows = False
Me.grRemisionZiur.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grRemisionZiur.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
Me.grRemisionZiur.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grRemisionZiur.Location = New System.Drawing.Point(2, 2)
Me.grRemisionZiur.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.grRemisionZiur.Name = "grRemisionZiur"
Me.grRemisionZiur.RowHeadersVisible = False
Me.grRemisionZiur.RowTemplate.Height = 24
Me.grRemisionZiur.Size = New System.Drawing.Size(856, 663)
Me.grRemisionZiur.TabIndex = 0
'
'flyPanelBotones
'
Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer))
Me.flyPanelBotones.Controls.Add(Me.pnlControles)
Me.flyPanelBotones.Controls.Add(Me.btnActualizar)
Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
Me.flyPanelBotones.Controls.Add(Me.btnAprobar)
Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
Me.flyPanelBotones.Controls.Add(Me.btnOrdenCompra)
Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flyPanelBotones.Location = New System.Drawing.Point(1157, 0)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(190, 695)
Me.flyPanelBotones.TabIndex = 8
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
'btnActualizar
'
Me.btnActualizar.FlatAppearance.BorderSize = 0
Me.btnActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnActualizar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnActualizar.ForeColor = System.Drawing.Color.White
Me.btnActualizar.Image = CType(resources.GetObject("btnActualizar.Image"), System.Drawing.Image)
Me.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnActualizar.Location = New System.Drawing.Point(3, 31)
Me.btnActualizar.Name = "btnActualizar"
Me.btnActualizar.Size = New System.Drawing.Size(189, 35)
Me.btnActualizar.TabIndex = 84
Me.btnActualizar.Text = "Actualizar"
Me.btnActualizar.UseVisualStyleBackColor = True
Me.btnActualizar.Visible = False
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
Me.btnGrabar.Location = New System.Drawing.Point(3, 72)
Me.btnGrabar.Name = "btnGrabar"
Me.btnGrabar.Size = New System.Drawing.Size(189, 35)
Me.btnGrabar.TabIndex = 15
Me.btnGrabar.Text = "Grabar"
Me.btnGrabar.UseVisualStyleBackColor = True
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
Me.btnAprobar.Location = New System.Drawing.Point(3, 113)
Me.btnAprobar.Name = "btnAprobar"
Me.btnAprobar.Size = New System.Drawing.Size(189, 35)
Me.btnAprobar.TabIndex = 20
Me.btnAprobar.Text = "Aprobar"
Me.btnAprobar.UseVisualStyleBackColor = True
Me.btnAprobar.Visible = False
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
Me.btnImprimir.Location = New System.Drawing.Point(3, 154)
Me.btnImprimir.Name = "btnImprimir"
Me.btnImprimir.Size = New System.Drawing.Size(189, 35)
Me.btnImprimir.TabIndex = 16
Me.btnImprimir.Text = "Imprimir"
Me.btnImprimir.UseVisualStyleBackColor = True
'
'btnOrdenCompra
'
Me.btnOrdenCompra.FlatAppearance.BorderSize = 0
Me.btnOrdenCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnOrdenCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.btnOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnOrdenCompra.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnOrdenCompra.ForeColor = System.Drawing.Color.White
Me.btnOrdenCompra.Image = CType(resources.GetObject("btnOrdenCompra.Image"), System.Drawing.Image)
Me.btnOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnOrdenCompra.Location = New System.Drawing.Point(3, 195)
Me.btnOrdenCompra.Name = "btnOrdenCompra"
Me.btnOrdenCompra.Size = New System.Drawing.Size(189, 35)
Me.btnOrdenCompra.TabIndex = 83
Me.btnOrdenCompra.Text = "      Orden de Compra"
Me.btnOrdenCompra.UseVisualStyleBackColor = True
Me.btnOrdenCompra.Visible = False
'
'frmIngresosOC
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1347, 695)
Me.Controls.Add(Me.flyPanelBotones)
Me.Controls.Add(Me.SplitContainer1)
Me.Name = "frmIngresosOC"
Me.Text = "Ingresos OC"
Me.SplitContainer1.Panel1.ResumeLayout(False)
Me.SplitContainer1.Panel1.PerformLayout()
Me.SplitContainer1.Panel2.ResumeLayout(False)
CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
Me.SplitContainer1.ResumeLayout(False)
Me.grpEstados.ResumeLayout(False)
Me.grpEstados.PerformLayout()
CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
Me.tbcDetalle.ResumeLayout(False)
Me.TabPage1.ResumeLayout(False)
Me.TabPage1.PerformLayout()
CType(Me.grIngresosOC, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
Me.TabPage2.ResumeLayout(False)
CType(Me.grRemisionZiur, System.ComponentModel.ISupportInitialize).EndInit()
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents grOrdenesCompra As System.Windows.Forms.DataGridView
  Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents pnlControles As System.Windows.Forms.Panel
  Friend WithEvents btnBotonera As System.Windows.Forms.Button
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents btnAprobar As System.Windows.Forms.Button
  Friend WithEvents btnImprimir As System.Windows.Forms.Button
  Friend WithEvents btnOrdenCompra As System.Windows.Forms.Button
  Friend WithEvents btnActualizar As System.Windows.Forms.Button
  Friend WithEvents optOCTodas As System.Windows.Forms.RadioButton
  Friend WithEvents optOCAprobadas As System.Windows.Forms.RadioButton
  Friend WithEvents optOCRegistradas As System.Windows.Forms.RadioButton
  Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
  Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
  Friend WithEvents grpEstados As System.Windows.Forms.GroupBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtOC As System.Windows.Forms.TextBox
  Friend WithEvents chkIngresosZiur As System.Windows.Forms.CheckBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents lblMensaje As System.Windows.Forms.Label
  Friend WithEvents tbcDetalle As System.Windows.Forms.TabControl
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents grIngresosOC As System.Windows.Forms.DataGridView
  Friend WithEvents colTipo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colNumZiur As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colRemisionCliente As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colFecha As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colProducto As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colIdEncabMov As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colEstadoFila As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
  Friend WithEvents colOrden As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodInventario2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colProducto2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCantidad2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colValorUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colValortotal As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colUnidad2 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colIngresos As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colBoton As System.Windows.Forms.DataGridViewButtonColumn
  Friend WithEvents lblItemsOnyx As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents lblItemsZiur As System.Windows.Forms.TextBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtOCompra As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents grRemisionZiur As System.Windows.Forms.DataGridView
  Friend WithEvents chkIngresaTodo As System.Windows.Forms.CheckBox
End Class
