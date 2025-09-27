<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSeguimientoOT
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSeguimientoOT))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
    Me.pnlControles = New System.Windows.Forms.Panel()
    Me.btnBotonera = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.cmdCargar = New System.Windows.Forms.Button()
    Me.btnAprobar = New System.Windows.Forms.Button()
    Me.btnSigFase = New System.Windows.Forms.Button()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.grpDetalle = New System.Windows.Forms.GroupBox()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.optOtParcial = New System.Windows.Forms.RadioButton()
    Me.optOtTotal = New System.Windows.Forms.RadioButton()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.txtOCCliente = New System.Windows.Forms.TextBox()
    Me.btnBuscarOT = New System.Windows.Forms.Button()
    Me.txtNumOrden = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtProyecto = New System.Windows.Forms.TextBox()
    Me.grDetalleRemision = New System.Windows.Forms.DataGridView()
    Me.colNumOrden = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCant = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colProyecto = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colOCCliente = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colTipoDespacho = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCab_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colRemDet_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colOTCab_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.txtCantidad = New System.Windows.Forms.TextBox()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.btnAdicionar = New System.Windows.Forms.Button()
    Me.grpCabecera = New System.Windows.Forms.GroupBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
    Me.txtDespachado = New System.Windows.Forms.TextBox()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.txtTransporta = New System.Windows.Forms.TextBox()
    Me.txtPlacas = New System.Windows.Forms.TextBox()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.cmbCliente = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.txtObservacion = New System.Windows.Forms.TextBox()
    Me.txtNumResumen = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
    Me.stNumOrden = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stNumRemision = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stEstadoRemision = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stEstadoOT = New System.Windows.Forms.ToolStripStatusLabel()
    Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
    Me.flyPanelBotones.SuspendLayout()
    Me.pnlControles.SuspendLayout()
    Me.grpDetalle.SuspendLayout()
    Me.Panel1.SuspendLayout()
    CType(Me.grDetalleRemision, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.grpCabecera.SuspendLayout()
    Me.StatusStrip1.SuspendLayout()
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
    Me.flyPanelBotones.Location = New System.Drawing.Point(1068, 0)
    Me.flyPanelBotones.Name = "flyPanelBotones"
    Me.flyPanelBotones.Size = New System.Drawing.Size(190, 728)
    Me.flyPanelBotones.TabIndex = 6
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
    Me.btnBotonera.Location = New System.Drawing.Point(4, 0)
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
    Me.btnGrabar.TabIndex = 20
    Me.btnGrabar.Tag = "SI"
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
    Me.btnAprobar.Location = New System.Drawing.Point(3, 113)
    Me.btnAprobar.Name = "btnAprobar"
    Me.btnAprobar.Size = New System.Drawing.Size(189, 35)
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
    Me.btnSigFase.Location = New System.Drawing.Point(3, 154)
    Me.btnSigFase.Name = "btnSigFase"
    Me.btnSigFase.Size = New System.Drawing.Size(189, 35)
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
    Me.btnImprimir.Location = New System.Drawing.Point(3, 195)
    Me.btnImprimir.Name = "btnImprimir"
    Me.btnImprimir.Size = New System.Drawing.Size(189, 35)
    Me.btnImprimir.TabIndex = 24
    Me.btnImprimir.Text = "Imprimir"
    Me.btnImprimir.UseVisualStyleBackColor = True
    Me.btnImprimir.Visible = False
    '
    'grpDetalle
    '
    Me.grpDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grpDetalle.Controls.Add(Me.Panel1)
    Me.grpDetalle.Controls.Add(Me.Label4)
    Me.grpDetalle.Controls.Add(Me.txtOCCliente)
    Me.grpDetalle.Controls.Add(Me.btnBuscarOT)
    Me.grpDetalle.Controls.Add(Me.txtNumOrden)
    Me.grpDetalle.Controls.Add(Me.Label1)
    Me.grpDetalle.Controls.Add(Me.Label2)
    Me.grpDetalle.Controls.Add(Me.txtProyecto)
    Me.grpDetalle.Controls.Add(Me.grDetalleRemision)
    Me.grpDetalle.Controls.Add(Me.txtCantidad)
    Me.grpDetalle.Controls.Add(Me.Label6)
    Me.grpDetalle.Controls.Add(Me.btnAdicionar)
    Me.grpDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.grpDetalle.Location = New System.Drawing.Point(12, 189)
    Me.grpDetalle.Name = "grpDetalle"
    Me.grpDetalle.Size = New System.Drawing.Size(1030, 469)
    Me.grpDetalle.TabIndex = 33
    Me.grpDetalle.TabStop = False
    Me.grpDetalle.Text = "Detalle Remisión"
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.optOtParcial)
    Me.Panel1.Controls.Add(Me.optOtTotal)
    Me.Panel1.Location = New System.Drawing.Point(367, 42)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(196, 28)
    Me.Panel1.TabIndex = 32
    '
    'optOtParcial
    '
    Me.optOtParcial.AutoSize = True
    Me.optOtParcial.Location = New System.Drawing.Point(96, 7)
    Me.optOtParcial.Name = "optOtParcial"
    Me.optOtParcial.Size = New System.Drawing.Size(75, 17)
    Me.optOtParcial.TabIndex = 1
    Me.optOtParcial.Text = "OT Parcial"
    Me.optOtParcial.UseVisualStyleBackColor = True
    '
    'optOtTotal
    '
    Me.optOtTotal.AutoSize = True
    Me.optOtTotal.Checked = True
    Me.optOtTotal.Location = New System.Drawing.Point(3, 7)
    Me.optOtTotal.Name = "optOtTotal"
    Me.optOtTotal.Size = New System.Drawing.Size(67, 17)
    Me.optOtTotal.TabIndex = 0
    Me.optOtTotal.TabStop = True
    Me.optOtTotal.Text = "OT Total"
    Me.optOtTotal.UseVisualStyleBackColor = True
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(10, 47)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(60, 13)
    Me.Label4.TabIndex = 30
    Me.Label4.Text = "OC Cliente:"
    '
    'txtOCCliente
    '
    Me.txtOCCliente.Location = New System.Drawing.Point(104, 46)
    Me.txtOCCliente.MaxLength = 50
    Me.txtOCCliente.Name = "txtOCCliente"
    Me.txtOCCliente.Size = New System.Drawing.Size(133, 20)
    Me.txtOCCliente.TabIndex = 12
    Me.txtOCCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'btnBuscarOT
    '
    Me.btnBuscarOT.Location = New System.Drawing.Point(242, 21)
    Me.btnBuscarOT.Name = "btnBuscarOT"
    Me.btnBuscarOT.Size = New System.Drawing.Size(28, 20)
    Me.btnBuscarOT.TabIndex = 11
    Me.btnBuscarOT.Text = "..."
    Me.btnBuscarOT.UseVisualStyleBackColor = True
    '
    'txtNumOrden
    '
    Me.txtNumOrden.Location = New System.Drawing.Point(104, 21)
    Me.txtNumOrden.MaxLength = 8
    Me.txtNumOrden.Name = "txtNumOrden"
    Me.txtNumOrden.Size = New System.Drawing.Size(133, 20)
    Me.txtNumOrden.TabIndex = 10
    Me.txtNumOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(10, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(25, 13)
    Me.Label1.TabIndex = 10
    Me.Label1.Text = "OT:"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(10, 86)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(52, 13)
    Me.Label2.TabIndex = 11
    Me.Label2.Text = "Proyecto:"
    '
    'txtProyecto
    '
    Me.txtProyecto.Location = New System.Drawing.Point(104, 86)
    Me.txtProyecto.MaxLength = 400
    Me.txtProyecto.Multiline = True
    Me.txtProyecto.Name = "txtProyecto"
    Me.txtProyecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtProyecto.Size = New System.Drawing.Size(608, 74)
    Me.txtProyecto.TabIndex = 14
    '
    'grDetalleRemision
    '
    Me.grDetalleRemision.AllowUserToAddRows = False
    Me.grDetalleRemision.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grDetalleRemision.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.grDetalleRemision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalleRemision.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colNumOrden, Me.colCant, Me.colProyecto, Me.colOCCliente, Me.colTipoDespacho, Me.colCab_Id, Me.colRemDet_ID, Me.colOTCab_ID})
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grDetalleRemision.DefaultCellStyle = DataGridViewCellStyle2
    Me.grDetalleRemision.Location = New System.Drawing.Point(104, 190)
    Me.grDetalleRemision.Name = "grDetalleRemision"
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grDetalleRemision.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.grDetalleRemision.RowHeadersWidth = 20
    Me.grDetalleRemision.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.grDetalleRemision.Size = New System.Drawing.Size(920, 273)
    Me.grDetalleRemision.TabIndex = 16
    '
    'colNumOrden
    '
    Me.colNumOrden.HeaderText = "OT"
    Me.colNumOrden.Name = "colNumOrden"
    '
    'colCant
    '
    Me.colCant.HeaderText = "CANTIDAD"
    Me.colCant.Name = "colCant"
    '
    'colProyecto
    '
    Me.colProyecto.HeaderText = "PROYECTO"
    Me.colProyecto.Name = "colProyecto"
    '
    'colOCCliente
    '
    Me.colOCCliente.HeaderText = "OC CLIENTE"
    Me.colOCCliente.Name = "colOCCliente"
    '
    'colTipoDespacho
    '
    Me.colTipoDespacho.HeaderText = "DESPACHO"
    Me.colTipoDespacho.Name = "colTipoDespacho"
    Me.colTipoDespacho.ReadOnly = True
    '
    'colCab_Id
    '
    Me.colCab_Id.HeaderText = "colCab_Id"
    Me.colCab_Id.Name = "colCab_Id"
    Me.colCab_Id.Visible = False
    '
    'colRemDet_ID
    '
    Me.colRemDet_ID.HeaderText = "colRemDet_ID"
    Me.colRemDet_ID.Name = "colRemDet_ID"
    Me.colRemDet_ID.Visible = False
    '
    'colOTCab_ID
    '
    Me.colOTCab_ID.HeaderText = "colOTCab_ID"
    Me.colOTCab_ID.Name = "colOTCab_ID"
    Me.colOTCab_ID.Visible = False
    '
    'txtCantidad
    '
    Me.txtCantidad.Location = New System.Drawing.Point(301, 46)
    Me.txtCantidad.MaxLength = 8
    Me.txtCantidad.Name = "txtCantidad"
    Me.txtCantidad.Size = New System.Drawing.Size(45, 20)
    Me.txtCantidad.TabIndex = 13
    Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(243, 50)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(52, 13)
    Me.Label6.TabIndex = 21
    Me.Label6.Text = "Cantidad:"
    '
    'btnAdicionar
    '
    Me.btnAdicionar.Location = New System.Drawing.Point(569, 46)
    Me.btnAdicionar.Name = "btnAdicionar"
    Me.btnAdicionar.Size = New System.Drawing.Size(107, 20)
    Me.btnAdicionar.TabIndex = 15
    Me.btnAdicionar.Text = "Adicionar"
    Me.btnAdicionar.UseVisualStyleBackColor = True
    '
    'grpCabecera
    '
    Me.grpCabecera.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grpCabecera.Controls.Add(Me.Button1)
    Me.grpCabecera.Controls.Add(Me.Label5)
    Me.grpCabecera.Controls.Add(Me.dtpFecha)
    Me.grpCabecera.Controls.Add(Me.txtDespachado)
    Me.grpCabecera.Controls.Add(Me.Label9)
    Me.grpCabecera.Controls.Add(Me.txtTransporta)
    Me.grpCabecera.Controls.Add(Me.txtPlacas)
    Me.grpCabecera.Controls.Add(Me.Label8)
    Me.grpCabecera.Controls.Add(Me.Label7)
    Me.grpCabecera.Controls.Add(Me.Label12)
    Me.grpCabecera.Controls.Add(Me.cmbCliente)
    Me.grpCabecera.Controls.Add(Me.Label3)
    Me.grpCabecera.Controls.Add(Me.txtObservacion)
    Me.grpCabecera.Controls.Add(Me.txtNumResumen)
    Me.grpCabecera.Controls.Add(Me.Label20)
    Me.grpCabecera.Location = New System.Drawing.Point(13, 0)
    Me.grpCabecera.Name = "grpCabecera"
    Me.grpCabecera.Size = New System.Drawing.Size(1030, 183)
    Me.grpCabecera.TabIndex = 32
    Me.grpCabecera.TabStop = False
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(682, 52)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(148, 73)
    Me.Button1.TabIndex = 42
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(208, 19)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 41
    Me.Label5.Text = "Fecha:"
    '
    'dtpFecha
    '
    Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFecha.Location = New System.Drawing.Point(254, 16)
    Me.dtpFecha.Name = "dtpFecha"
    Me.dtpFecha.Size = New System.Drawing.Size(117, 20)
    Me.dtpFecha.TabIndex = 2
    '
    'txtDespachado
    '
    Me.txtDespachado.Location = New System.Drawing.Point(103, 89)
    Me.txtDespachado.MaxLength = 100
    Me.txtDespachado.Name = "txtDespachado"
    Me.txtDespachado.Size = New System.Drawing.Size(464, 20)
    Me.txtDespachado.TabIndex = 8
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(6, 90)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(89, 13)
    Me.Label9.TabIndex = 38
    Me.Label9.Text = "Despachado por:"
    '
    'txtTransporta
    '
    Me.txtTransporta.Location = New System.Drawing.Point(103, 65)
    Me.txtTransporta.MaxLength = 100
    Me.txtTransporta.Name = "txtTransporta"
    Me.txtTransporta.Size = New System.Drawing.Size(350, 20)
    Me.txtTransporta.TabIndex = 6
    '
    'txtPlacas
    '
    Me.txtPlacas.Location = New System.Drawing.Point(507, 64)
    Me.txtPlacas.MaxLength = 6
    Me.txtPlacas.Name = "txtPlacas"
    Me.txtPlacas.Size = New System.Drawing.Size(60, 20)
    Me.txtPlacas.TabIndex = 7
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(459, 64)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(42, 13)
    Me.Label8.TabIndex = 35
    Me.Label8.Text = "Placas:"
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(6, 64)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(91, 13)
    Me.Label7.TabIndex = 34
    Me.Label7.Text = "Transportado por:"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(6, 42)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(42, 13)
    Me.Label12.TabIndex = 33
    Me.Label12.Text = "Cliente:"
    '
    'cmbCliente
    '
    Me.cmbCliente.FormattingEnabled = True
    Me.cmbCliente.Location = New System.Drawing.Point(103, 40)
    Me.cmbCliente.Name = "cmbCliente"
    Me.cmbCliente.Size = New System.Drawing.Size(464, 21)
    Me.cmbCliente.TabIndex = 5
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(6, 113)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 13)
    Me.Label3.TabIndex = 30
    Me.Label3.Text = "Observación:"
    '
    'txtObservacion
    '
    Me.txtObservacion.Location = New System.Drawing.Point(103, 113)
    Me.txtObservacion.MaxLength = 400
    Me.txtObservacion.Multiline = True
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservacion.Size = New System.Drawing.Size(464, 50)
    Me.txtObservacion.TabIndex = 9
    '
    'txtNumResumen
    '
    Me.txtNumResumen.Location = New System.Drawing.Point(103, 16)
    Me.txtNumResumen.Name = "txtNumResumen"
    Me.txtNumResumen.ReadOnly = True
    Me.txtNumResumen.Size = New System.Drawing.Size(86, 20)
    Me.txtNumResumen.TabIndex = 1
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(6, 16)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(47, 13)
    Me.Label20.TabIndex = 28
    Me.Label20.Text = "Número:"
    '
    'StatusStrip1
    '
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stNumOrden, Me.stNumRemision, Me.stEstadoRemision, Me.stEstadoOT, Me.ToolStripStatusLabel1})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 704)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(1068, 24)
    Me.StatusStrip1.TabIndex = 31
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'stNumOrden
    '
    Me.stNumOrden.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.stNumOrden.Name = "stNumOrden"
    Me.stNumOrden.Size = New System.Drawing.Size(66, 19)
    Me.stNumOrden.Text = "Remisión: "
    '
    'stNumRemision
    '
    Me.stNumRemision.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.stNumRemision.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
    Me.stNumRemision.Name = "stNumRemision"
    Me.stNumRemision.Size = New System.Drawing.Size(4, 19)
    '
    'stEstadoRemision
    '
    Me.stEstadoRemision.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.stEstadoRemision.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
    Me.stEstadoRemision.Name = "stEstadoRemision"
    Me.stEstadoRemision.Size = New System.Drawing.Size(49, 19)
    Me.stEstadoRemision.Text = "Estado:"
    Me.stEstadoRemision.Visible = False
    '
    'stEstadoOT
    '
    Me.stEstadoOT.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
    Me.stEstadoOT.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
    Me.stEstadoOT.Name = "stEstadoOT"
    Me.stEstadoOT.Size = New System.Drawing.Size(52, 19)
    Me.stEstadoOT.Text = "Estado: "
    Me.stEstadoOT.Visible = False
    '
    'ToolStripStatusLabel1
    '
    Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
    Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(61, 19)
    Me.ToolStripStatusLabel1.Text = "2020 08 26"
    '
    'frmSeguimientoOT
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1258, 728)
    Me.Controls.Add(Me.grpDetalle)
    Me.Controls.Add(Me.grpCabecera)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Controls.Add(Me.flyPanelBotones)
    Me.Name = "frmSeguimientoOT"
    Me.Text = "Remisión de Entrega"
    Me.flyPanelBotones.ResumeLayout(False)
    Me.pnlControles.ResumeLayout(False)
    Me.grpDetalle.ResumeLayout(False)
    Me.grpDetalle.PerformLayout()
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    CType(Me.grDetalleRemision, System.ComponentModel.ISupportInitialize).EndInit()
    Me.grpCabecera.ResumeLayout(False)
    Me.grpCabecera.PerformLayout()
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents grpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
    Friend WithEvents grDetalleRemision As System.Windows.Forms.DataGridView
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents grpCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents txtNumResumen As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stNumOrden As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stNumRemision As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stEstadoRemision As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stEstadoOT As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDespachado As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtTransporta As System.Windows.Forms.TextBox
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents btnBuscarOT As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtOCCliente As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents optOtParcial As System.Windows.Forms.RadioButton
    Friend WithEvents optOtTotal As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents colNumOrden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCant As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProyecto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOCCliente As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTipoDespacho As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCab_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRemDet_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOTCab_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
End Class
