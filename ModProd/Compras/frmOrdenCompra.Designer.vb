<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOrdenCompra
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrdenCompra))
Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
Me.grOrdenesCompra = New System.Windows.Forms.DataGridView()
Me.Panel1 = New System.Windows.Forms.Panel()
Me.GroupBox1 = New System.Windows.Forms.GroupBox()
Me.optOCRegistradas = New System.Windows.Forms.RadioButton()
Me.optOCAprobadas = New System.Windows.Forms.RadioButton()
Me.optOCTodas = New System.Windows.Forms.RadioButton()
Me.dtpInicial = New System.Windows.Forms.DateTimePicker()
Me.Label11 = New System.Windows.Forms.Label()
Me.dtpFinal = New System.Windows.Forms.DateTimePicker()
Me.txtOC = New System.Windows.Forms.TextBox()
Me.Button1 = New System.Windows.Forms.Button()
Me.lblObsAnulacion = New System.Windows.Forms.Label()
Me.txtObsAnulacion = New System.Windows.Forms.TextBox()
Me.chkAnular = New System.Windows.Forms.CheckBox()
Me.chkValidar = New System.Windows.Forms.CheckBox()
Me.Label10 = New System.Windows.Forms.Label()
Me.txtLugarEntrega = New System.Windows.Forms.TextBox()
Me.Label9 = New System.Windows.Forms.Label()
Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
Me.Label8 = New System.Windows.Forms.Label()
Me.txtObservacion = New System.Windows.Forms.TextBox()
Me.Label7 = New System.Windows.Forms.Label()
Me.txtTotalOC = New System.Windows.Forms.TextBox()
Me.Label6 = New System.Windows.Forms.Label()
Me.txtIVA = New System.Windows.Forms.TextBox()
Me.Label5 = New System.Windows.Forms.Label()
Me.txtSubTotal = New System.Windows.Forms.TextBox()
Me.Label4 = New System.Windows.Forms.Label()
Me.txtDescuento = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.txtValorOC = New System.Windows.Forms.TextBox()
Me.txtOCompra = New System.Windows.Forms.TextBox()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtProveedor = New System.Windows.Forms.TextBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.grDetalle = New System.Windows.Forms.DataGridView()
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
CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
Me.Panel1.SuspendLayout()
Me.GroupBox1.SuspendLayout()
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
Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(4)
Me.SplitContainer1.Name = "SplitContainer1"
'
'SplitContainer1.Panel1
'
Me.SplitContainer1.Panel1.Controls.Add(Me.grOrdenesCompra)
Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
'
'SplitContainer1.Panel2
'
Me.SplitContainer1.Panel2.Controls.Add(Me.lblObsAnulacion)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtObsAnulacion)
Me.SplitContainer1.Panel2.Controls.Add(Me.chkAnular)
Me.SplitContainer1.Panel2.Controls.Add(Me.chkValidar)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label10)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtLugarEntrega)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label9)
Me.SplitContainer1.Panel2.Controls.Add(Me.dtpFechaEntrega)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label8)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtObservacion)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label7)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtTotalOC)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label6)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtIVA)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtSubTotal)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtDescuento)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtValorOC)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtOCompra)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
Me.SplitContainer1.Panel2.Controls.Add(Me.txtProveedor)
Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
Me.SplitContainer1.Panel2.Controls.Add(Me.grDetalle)
Me.SplitContainer1.Size = New System.Drawing.Size(1535, 855)
Me.SplitContainer1.SplitterDistance = 420
Me.SplitContainer1.SplitterWidth = 5
Me.SplitContainer1.TabIndex = 0
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
Me.grOrdenesCompra.Location = New System.Drawing.Point(4, 138)
Me.grOrdenesCompra.Margin = New System.Windows.Forms.Padding(4)
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
Me.grOrdenesCompra.Size = New System.Drawing.Size(423, 328)
Me.grOrdenesCompra.TabIndex = 21
'
'Panel1
'
Me.Panel1.Controls.Add(Me.GroupBox1)
Me.Panel1.Controls.Add(Me.dtpInicial)
Me.Panel1.Controls.Add(Me.Label11)
Me.Panel1.Controls.Add(Me.dtpFinal)
Me.Panel1.Controls.Add(Me.txtOC)
Me.Panel1.Controls.Add(Me.Button1)
Me.Panel1.Location = New System.Drawing.Point(2, 0)
Me.Panel1.Name = "Panel1"
Me.Panel1.Size = New System.Drawing.Size(428, 131)
Me.Panel1.TabIndex = 20
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.optOCRegistradas)
Me.GroupBox1.Controls.Add(Me.optOCAprobadas)
Me.GroupBox1.Controls.Add(Me.optOCTodas)
Me.GroupBox1.Location = New System.Drawing.Point(8, 4)
Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
Me.GroupBox1.Size = New System.Drawing.Size(165, 119)
Me.GroupBox1.TabIndex = 7
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Estado OC"
'
'optOCRegistradas
'
Me.optOCRegistradas.AutoSize = True
Me.optOCRegistradas.Checked = True
Me.optOCRegistradas.Location = New System.Drawing.Point(13, 20)
Me.optOCRegistradas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCRegistradas.Name = "optOCRegistradas"
Me.optOCRegistradas.Size = New System.Drawing.Size(105, 21)
Me.optOCRegistradas.TabIndex = 1
Me.optOCRegistradas.TabStop = True
Me.optOCRegistradas.Text = "Registradas"
Me.optOCRegistradas.UseVisualStyleBackColor = True
'
'optOCAprobadas
'
Me.optOCAprobadas.AutoSize = True
Me.optOCAprobadas.Location = New System.Drawing.Point(13, 49)
Me.optOCAprobadas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCAprobadas.Name = "optOCAprobadas"
Me.optOCAprobadas.Size = New System.Drawing.Size(98, 21)
Me.optOCAprobadas.TabIndex = 2
Me.optOCAprobadas.TabStop = True
Me.optOCAprobadas.Text = "Aprobadas"
Me.optOCAprobadas.UseVisualStyleBackColor = True
'
'optOCTodas
'
Me.optOCTodas.AutoSize = True
Me.optOCTodas.Location = New System.Drawing.Point(13, 79)
Me.optOCTodas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCTodas.Name = "optOCTodas"
Me.optOCTodas.Size = New System.Drawing.Size(69, 21)
Me.optOCTodas.TabIndex = 3
Me.optOCTodas.TabStop = True
Me.optOCTodas.Text = "Todas"
Me.optOCTodas.UseVisualStyleBackColor = True
'
'dtpInicial
'
Me.dtpInicial.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpInicial.Location = New System.Drawing.Point(181, 38)
Me.dtpInicial.Margin = New System.Windows.Forms.Padding(4)
Me.dtpInicial.Name = "dtpInicial"
Me.dtpInicial.Size = New System.Drawing.Size(148, 22)
Me.dtpInicial.TabIndex = 6
'
'Label11
'
Me.Label11.AutoSize = True
Me.Label11.Location = New System.Drawing.Point(182, 17)
Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label11.Name = "Label11"
Me.Label11.Size = New System.Drawing.Size(32, 17)
Me.Label11.TabIndex = 16
Me.Label11.Text = "OC:"
'
'dtpFinal
'
Me.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFinal.Location = New System.Drawing.Point(181, 65)
Me.dtpFinal.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFinal.Name = "dtpFinal"
Me.dtpFinal.Size = New System.Drawing.Size(148, 22)
Me.dtpFinal.TabIndex = 5
'
'txtOC
'
Me.txtOC.BackColor = System.Drawing.SystemColors.MenuHighlight
Me.txtOC.Location = New System.Drawing.Point(222, 12)
Me.txtOC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtOC.MaxLength = 15
Me.txtOC.Name = "txtOC"
Me.txtOC.Size = New System.Drawing.Size(107, 22)
Me.txtOC.TabIndex = 6
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(180, 90)
Me.Button1.Margin = New System.Windows.Forms.Padding(4)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(148, 32)
Me.Button1.TabIndex = 8
Me.Button1.Text = "Cargar"
Me.Button1.UseVisualStyleBackColor = True
'
'lblObsAnulacion
'
Me.lblObsAnulacion.AutoSize = True
Me.lblObsAnulacion.Location = New System.Drawing.Point(358, 162)
Me.lblObsAnulacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblObsAnulacion.Name = "lblObsAnulacion"
Me.lblObsAnulacion.Size = New System.Drawing.Size(104, 17)
Me.lblObsAnulacion.TabIndex = 24
Me.lblObsAnulacion.Text = "Obs. Anulación"
Me.lblObsAnulacion.Visible = False
'
'txtObsAnulacion
'
Me.txtObsAnulacion.Location = New System.Drawing.Point(467, 162)
Me.txtObsAnulacion.Margin = New System.Windows.Forms.Padding(4)
Me.txtObsAnulacion.MaxLength = 1000
Me.txtObsAnulacion.Multiline = True
Me.txtObsAnulacion.Name = "txtObsAnulacion"
Me.txtObsAnulacion.Size = New System.Drawing.Size(637, 42)
Me.txtObsAnulacion.TabIndex = 23
Me.txtObsAnulacion.Visible = False
'
'chkAnular
'
Me.chkAnular.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chkAnular.Location = New System.Drawing.Point(358, 140)
Me.chkAnular.Margin = New System.Windows.Forms.Padding(4)
Me.chkAnular.Name = "chkAnular"
Me.chkAnular.Size = New System.Drawing.Size(125, 22)
Me.chkAnular.TabIndex = 22
Me.chkAnular.Text = "Anular"
Me.chkAnular.UseVisualStyleBackColor = True
Me.chkAnular.Visible = False
'
'chkValidar
'
Me.chkValidar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
Me.chkValidar.Location = New System.Drawing.Point(521, 139)
Me.chkValidar.Margin = New System.Windows.Forms.Padding(4)
Me.chkValidar.Name = "chkValidar"
Me.chkValidar.Size = New System.Drawing.Size(125, 23)
Me.chkValidar.TabIndex = 21
Me.chkValidar.Text = "Validar"
Me.chkValidar.UseVisualStyleBackColor = True
Me.chkValidar.Visible = False
'
'Label10
'
Me.Label10.AutoSize = True
Me.Label10.Location = New System.Drawing.Point(358, 90)
Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label10.Name = "Label10"
Me.Label10.Size = New System.Drawing.Size(99, 17)
Me.Label10.TabIndex = 20
Me.Label10.Text = "Lugar Entrega"
'
'txtLugarEntrega
'
Me.txtLugarEntrega.Location = New System.Drawing.Point(465, 86)
Me.txtLugarEntrega.Margin = New System.Windows.Forms.Padding(4)
Me.txtLugarEntrega.MaxLength = 2000
Me.txtLugarEntrega.Multiline = True
Me.txtLugarEntrega.Name = "txtLugarEntrega"
Me.txtLugarEntrega.Size = New System.Drawing.Size(637, 52)
Me.txtLugarEntrega.TabIndex = 19
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Location = New System.Drawing.Point(13, 193)
Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(101, 17)
Me.Label9.TabIndex = 18
Me.Label9.Text = "Fecha Entrega"
'
'dtpFechaEntrega
'
Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFechaEntrega.Location = New System.Drawing.Point(177, 194)
Me.dtpFechaEntrega.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
Me.dtpFechaEntrega.Size = New System.Drawing.Size(133, 22)
Me.dtpFechaEntrega.TabIndex = 4
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(358, 34)
Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(103, 17)
Me.Label8.TabIndex = 17
Me.Label8.Text = "Observaciones"
'
'txtObservacion
'
Me.txtObservacion.Location = New System.Drawing.Point(465, 31)
Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4)
Me.txtObservacion.MaxLength = 2000
Me.txtObservacion.Multiline = True
Me.txtObservacion.Name = "txtObservacion"
Me.txtObservacion.Size = New System.Drawing.Size(637, 52)
Me.txtObservacion.TabIndex = 16
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(13, 171)
Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(157, 17)
Me.Label7.TabIndex = 15
Me.Label7.Text = "Total Orden de Compra"
'
'txtTotalOC
'
Me.txtTotalOC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtTotalOC.Location = New System.Drawing.Point(177, 167)
Me.txtTotalOC.Margin = New System.Windows.Forms.Padding(4)
Me.txtTotalOC.Name = "txtTotalOC"
Me.txtTotalOC.ReadOnly = True
Me.txtTotalOC.Size = New System.Drawing.Size(155, 23)
Me.txtTotalOC.TabIndex = 14
Me.txtTotalOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(13, 144)
Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(61, 17)
Me.Label6.TabIndex = 13
Me.Label6.Text = "IVA 19%"
'
'txtIVA
'
Me.txtIVA.Location = New System.Drawing.Point(177, 140)
Me.txtIVA.Margin = New System.Windows.Forms.Padding(4)
Me.txtIVA.Name = "txtIVA"
Me.txtIVA.ReadOnly = True
Me.txtIVA.Size = New System.Drawing.Size(155, 22)
Me.txtIVA.TabIndex = 12
Me.txtIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(13, 117)
Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(69, 17)
Me.Label5.TabIndex = 11
Me.Label5.Text = "Sub Total"
'
'txtSubTotal
'
Me.txtSubTotal.Location = New System.Drawing.Point(177, 113)
Me.txtSubTotal.Margin = New System.Windows.Forms.Padding(4)
Me.txtSubTotal.Name = "txtSubTotal"
Me.txtSubTotal.ReadOnly = True
Me.txtSubTotal.Size = New System.Drawing.Size(155, 22)
Me.txtSubTotal.TabIndex = 10
Me.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(13, 90)
Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(76, 17)
Me.Label4.TabIndex = 9
Me.Label4.Text = "Descuento"
'
'txtDescuento
'
Me.txtDescuento.Location = New System.Drawing.Point(177, 86)
Me.txtDescuento.Margin = New System.Windows.Forms.Padding(4)
Me.txtDescuento.MaxLength = 12
Me.txtDescuento.Name = "txtDescuento"
Me.txtDescuento.Size = New System.Drawing.Size(155, 22)
Me.txtDescuento.TabIndex = 8
Me.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(13, 63)
Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(158, 17)
Me.Label3.TabIndex = 7
Me.Label3.Text = "Valor Orden de Compra"
'
'txtValorOC
'
Me.txtValorOC.Location = New System.Drawing.Point(177, 59)
Me.txtValorOC.Margin = New System.Windows.Forms.Padding(4)
Me.txtValorOC.Name = "txtValorOC"
Me.txtValorOC.ReadOnly = True
Me.txtValorOC.Size = New System.Drawing.Size(155, 22)
Me.txtValorOC.TabIndex = 6
Me.txtValorOC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'txtOCompra
'
Me.txtOCompra.Location = New System.Drawing.Point(177, 31)
Me.txtOCompra.Margin = New System.Windows.Forms.Padding(4)
Me.txtOCompra.Name = "txtOCompra"
Me.txtOCompra.ReadOnly = True
Me.txtOCompra.Size = New System.Drawing.Size(127, 22)
Me.txtOCompra.TabIndex = 5
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(13, 34)
Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(125, 17)
Me.Label2.TabIndex = 4
Me.Label2.Text = "Orden de Compra:"
'
'txtProveedor
'
Me.txtProveedor.Location = New System.Drawing.Point(177, 4)
Me.txtProveedor.Margin = New System.Windows.Forms.Padding(4)
Me.txtProveedor.Name = "txtProveedor"
Me.txtProveedor.ReadOnly = True
Me.txtProveedor.Size = New System.Drawing.Size(676, 22)
Me.txtProveedor.TabIndex = 3
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(13, 12)
Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(78, 17)
Me.Label1.TabIndex = 2
Me.Label1.Text = "Proveedor:"
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
Me.grDetalle.Location = New System.Drawing.Point(4, 238)
Me.grDetalle.Margin = New System.Windows.Forms.Padding(4)
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
Me.grDetalle.Size = New System.Drawing.Size(1097, 610)
Me.grDetalle.TabIndex = 1
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
Me.flyPanelBotones.Location = New System.Drawing.Point(1543, 0)
Me.flyPanelBotones.Margin = New System.Windows.Forms.Padding(4)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(253, 855)
Me.flyPanelBotones.TabIndex = 8
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
Me.btnBotonera.Location = New System.Drawing.Point(4, 0)
Me.btnBotonera.Margin = New System.Windows.Forms.Padding(4)
Me.btnBotonera.Name = "btnBotonera"
Me.btnBotonera.Size = New System.Drawing.Size(37, 23)
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
Me.btnActualizar.Location = New System.Drawing.Point(4, 39)
Me.btnActualizar.Margin = New System.Windows.Forms.Padding(4)
Me.btnActualizar.Name = "btnActualizar"
Me.btnActualizar.Size = New System.Drawing.Size(252, 43)
Me.btnActualizar.TabIndex = 84
Me.btnActualizar.Text = "Actualizar"
Me.btnActualizar.UseVisualStyleBackColor = True
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
Me.btnGrabar.Location = New System.Drawing.Point(4, 90)
Me.btnGrabar.Margin = New System.Windows.Forms.Padding(4)
Me.btnGrabar.Name = "btnGrabar"
Me.btnGrabar.Size = New System.Drawing.Size(252, 43)
Me.btnGrabar.TabIndex = 15
Me.btnGrabar.Text = "Grabar"
Me.btnGrabar.UseVisualStyleBackColor = True
Me.btnGrabar.Visible = False
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
Me.btnImprimir.Location = New System.Drawing.Point(4, 192)
Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4)
Me.btnImprimir.Name = "btnImprimir"
Me.btnImprimir.Size = New System.Drawing.Size(252, 43)
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
Me.btnOrdenCompra.Location = New System.Drawing.Point(4, 243)
Me.btnOrdenCompra.Margin = New System.Windows.Forms.Padding(4)
Me.btnOrdenCompra.Name = "btnOrdenCompra"
Me.btnOrdenCompra.Size = New System.Drawing.Size(252, 43)
Me.btnOrdenCompra.TabIndex = 83
Me.btnOrdenCompra.Text = "      Orden de Compra"
Me.btnOrdenCompra.UseVisualStyleBackColor = True
Me.btnOrdenCompra.Visible = False
'
'frmOrdenCompra
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1796, 855)
Me.Controls.Add(Me.flyPanelBotones)
Me.Controls.Add(Me.SplitContainer1)
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmOrdenCompra"
Me.Text = "Orden de Compra"
Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
Me.SplitContainer1.Panel1.ResumeLayout(False)
Me.SplitContainer1.Panel2.ResumeLayout(False)
Me.SplitContainer1.Panel2.PerformLayout()
CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
Me.SplitContainer1.ResumeLayout(False)
CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
Me.Panel1.ResumeLayout(False)
Me.Panel1.PerformLayout()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnOrdenCompra As System.Windows.Forms.Button
    Friend WithEvents txtProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtOCompra As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalOC As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIVA As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtValorOC As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtLugarEntrega As System.Windows.Forms.TextBox
    Friend WithEvents chkValidar As System.Windows.Forms.CheckBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents optOCTodas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCAprobadas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCRegistradas As System.Windows.Forms.RadioButton
    Friend WithEvents dtpInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkAnular As System.Windows.Forms.CheckBox
    Friend WithEvents lblObsAnulacion As System.Windows.Forms.Label
  Friend WithEvents txtObsAnulacion As System.Windows.Forms.TextBox
  Friend WithEvents txtOC As System.Windows.Forms.TextBox
  Friend WithEvents Panel1 As System.Windows.Forms.Panel
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents grOrdenesCompra As System.Windows.Forms.DataGridView
End Class
