<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProgramador
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProgramador))
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.cmdCargar = New System.Windows.Forms.Button()
Me.btnAprobar = New System.Windows.Forms.Button()
Me.btnSigFase = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.cmdBuscar = New System.Windows.Forms.Button()
Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
Me.stNumOrden = New System.Windows.Forms.ToolStripStatusLabel()
Me.stNumRemision = New System.Windows.Forms.ToolStripStatusLabel()
Me.stEstadoRemision = New System.Windows.Forms.ToolStripStatusLabel()
Me.stEstadoOT = New System.Windows.Forms.ToolStripStatusLabel()
Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
Me.Label48 = New System.Windows.Forms.Label()
Me.cmbOperarios = New System.Windows.Forms.ComboBox()
Me.lstSubTareas = New System.Windows.Forms.ListBox()
Me.dtpFI_SubT = New System.Windows.Forms.DateTimePicker()
Me.Label54 = New System.Windows.Forms.Label()
Me.Button1 = New System.Windows.Forms.Button()
Me.btnAdicionar = New System.Windows.Forms.Button()
Me.btnRemover = New System.Windows.Forms.Button()
Me.grPrograma = New System.Windows.Forms.DataGridView()
Me.Button2 = New System.Windows.Forms.Button()
Me.Button3 = New System.Windows.Forms.Button()
Me.Label1 = New System.Windows.Forms.Label()
Me.dtpFF_SubT = New System.Windows.Forms.DateTimePicker()
Me.Label2 = New System.Windows.Forms.Label()
Me.tbcProgramador = New System.Windows.Forms.TabControl()
Me.tbpProgramador = New System.Windows.Forms.TabPage()
Me.dtpFF_SubT_Prog = New System.Windows.Forms.DateTimePicker()
Me.Label7 = New System.Windows.Forms.Label()
Me.dtpFI_SubT_Prog = New System.Windows.Forms.DateTimePicker()
Me.Label9 = New System.Windows.Forms.Label()
Me.Label6 = New System.Windows.Forms.Label()
Me.lblCntHoras3 = New System.Windows.Forms.Label()
Me.Label8 = New System.Windows.Forms.Label()
Me.lblCntSubTareas3 = New System.Windows.Forms.Label()
Me.lblTituloCntHoras2 = New System.Windows.Forms.Label()
Me.lblCntHoras2 = New System.Windows.Forms.Label()
Me.lblTituloCntSubTareas2 = New System.Windows.Forms.Label()
Me.lblCntSubTareas2 = New System.Windows.Forms.Label()
Me.tbpConsulta = New System.Windows.Forms.TabPage()
Me.lblTituloCntHoras = New System.Windows.Forms.Label()
Me.lblCntHoras = New System.Windows.Forms.Label()
Me.lblTituloCntSubTareas = New System.Windows.Forms.Label()
Me.lblCntSubTareas = New System.Windows.Forms.Label()
Me.lblStrOperario_Id = New System.Windows.Forms.Label()
Me.lblSiDatos = New System.Windows.Forms.Label()
Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
Me.dtpFF_Prog = New System.Windows.Forms.DateTimePicker()
Me.Label3 = New System.Windows.Forms.Label()
Me.dtpFI_Prog = New System.Windows.Forms.DateTimePicker()
Me.Label4 = New System.Windows.Forms.Label()
Me.Label5 = New System.Windows.Forms.Label()
Me.cmbOperariosConsulta = New System.Windows.Forms.ComboBox()
Me.lblProgCab_Id = New System.Windows.Forms.Label()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
Me.StatusStrip1.SuspendLayout()
CType(Me.grPrograma, System.ComponentModel.ISupportInitialize).BeginInit()
Me.tbcProgramador.SuspendLayout()
Me.tbpProgramador.SuspendLayout()
Me.tbpConsulta.SuspendLayout()
CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
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
Me.flyPanelBotones.Controls.Add(Me.cmdBuscar)
Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flyPanelBotones.Location = New System.Drawing.Point(1424, 0)
Me.flyPanelBotones.Margin = New System.Windows.Forms.Padding(4)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(253, 896)
Me.flyPanelBotones.TabIndex = 6
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
Me.cmdCargar.Visible = False
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
'cmdBuscar
'
Me.cmdBuscar.FlatAppearance.BorderSize = 0
Me.cmdBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.cmdBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
Me.cmdBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.cmdBuscar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.cmdBuscar.ForeColor = System.Drawing.Color.White
Me.cmdBuscar.Image = CType(resources.GetObject("cmdBuscar.Image"), System.Drawing.Image)
Me.cmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.cmdBuscar.Location = New System.Drawing.Point(4, 294)
Me.cmdBuscar.Margin = New System.Windows.Forms.Padding(4)
Me.cmdBuscar.Name = "cmdBuscar"
Me.cmdBuscar.Size = New System.Drawing.Size(252, 43)
Me.cmdBuscar.TabIndex = 83
Me.cmdBuscar.Text = "Buscar"
Me.cmdBuscar.UseVisualStyleBackColor = True
'
'StatusStrip1
'
Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stNumOrden, Me.stNumRemision, Me.stEstadoRemision, Me.stEstadoOT, Me.ToolStripStatusLabel1})
Me.StatusStrip1.Location = New System.Drawing.Point(0, 867)
Me.StatusStrip1.Name = "StatusStrip1"
Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
Me.StatusStrip1.Size = New System.Drawing.Size(1424, 29)
Me.StatusStrip1.TabIndex = 31
Me.StatusStrip1.Text = "StatusStrip1"
'
'stNumOrden
'
Me.stNumOrden.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
Me.stNumOrden.Name = "stNumOrden"
Me.stNumOrden.Size = New System.Drawing.Size(81, 24)
Me.stNumOrden.Text = "Remisión: "
'
'stNumRemision
'
Me.stNumRemision.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
Me.stNumRemision.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
Me.stNumRemision.Name = "stNumRemision"
Me.stNumRemision.Size = New System.Drawing.Size(4, 24)
'
'stEstadoRemision
'
Me.stEstadoRemision.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
Me.stEstadoRemision.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner
Me.stEstadoRemision.Name = "stEstadoRemision"
Me.stEstadoRemision.Size = New System.Drawing.Size(61, 24)
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
Me.stEstadoOT.Size = New System.Drawing.Size(65, 24)
Me.stEstadoOT.Text = "Estado: "
Me.stEstadoOT.Visible = False
'
'ToolStripStatusLabel1
'
Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(0, 24)
'
'Label48
'
Me.Label48.AutoSize = True
Me.Label48.Location = New System.Drawing.Point(26, 69)
Me.Label48.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(68, 17)
Me.Label48.TabIndex = 96
Me.Label48.Text = "Operario:"
'
'cmbOperarios
'
Me.cmbOperarios.BackColor = System.Drawing.SystemColors.Window
Me.cmbOperarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbOperarios.FormattingEnabled = True
Me.cmbOperarios.Location = New System.Drawing.Point(121, 66)
Me.cmbOperarios.Margin = New System.Windows.Forms.Padding(4)
Me.cmbOperarios.MaxDropDownItems = 10
Me.cmbOperarios.Name = "cmbOperarios"
Me.cmbOperarios.Size = New System.Drawing.Size(457, 24)
Me.cmbOperarios.TabIndex = 105
'
'lstSubTareas
'
Me.lstSubTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lstSubTareas.FormattingEnabled = True
Me.lstSubTareas.ItemHeight = 18
Me.lstSubTareas.Location = New System.Drawing.Point(24, 102)
Me.lstSubTareas.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.lstSubTareas.Name = "lstSubTareas"
Me.lstSubTareas.Size = New System.Drawing.Size(613, 508)
Me.lstSubTareas.TabIndex = 106
'
'dtpFI_SubT
'
Me.dtpFI_SubT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFI_SubT.Location = New System.Drawing.Point(121, 10)
Me.dtpFI_SubT.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFI_SubT.Name = "dtpFI_SubT"
Me.dtpFI_SubT.Size = New System.Drawing.Size(165, 22)
Me.dtpFI_SubT.TabIndex = 102
'
'Label54
'
Me.Label54.AutoSize = True
Me.Label54.Location = New System.Drawing.Point(26, 10)
Me.Label54.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label54.Name = "Label54"
Me.Label54.Size = New System.Drawing.Size(83, 17)
Me.Label54.TabIndex = 103
Me.Label54.Text = "Fecha Inicio"
'
'Button1
'
Me.Button1.Location = New System.Drawing.Point(1237, 15)
Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.Button1.Name = "Button1"
Me.Button1.Size = New System.Drawing.Size(77, 40)
Me.Button1.TabIndex = 104
Me.Button1.Text = "Button1"
Me.Button1.UseVisualStyleBackColor = True
Me.Button1.Visible = False
'
'btnAdicionar
'
Me.btnAdicionar.Image = CType(resources.GetObject("btnAdicionar.Image"), System.Drawing.Image)
Me.btnAdicionar.Location = New System.Drawing.Point(661, 218)
Me.btnAdicionar.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnAdicionar.Name = "btnAdicionar"
Me.btnAdicionar.Size = New System.Drawing.Size(43, 47)
Me.btnAdicionar.TabIndex = 107
Me.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
Me.btnAdicionar.UseVisualStyleBackColor = True
'
'btnRemover
'
Me.btnRemover.Image = CType(resources.GetObject("btnRemover.Image"), System.Drawing.Image)
Me.btnRemover.Location = New System.Drawing.Point(661, 271)
Me.btnRemover.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.btnRemover.Name = "btnRemover"
Me.btnRemover.Size = New System.Drawing.Size(43, 47)
Me.btnRemover.TabIndex = 108
Me.btnRemover.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
Me.btnRemover.UseVisualStyleBackColor = True
'
'grPrograma
'
Me.grPrograma.AllowUserToAddRows = False
Me.grPrograma.AllowUserToDeleteRows = False
Me.grPrograma.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grPrograma.ColumnHeadersVisible = False
Me.grPrograma.Location = New System.Drawing.Point(727, 102)
Me.grPrograma.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.grPrograma.MultiSelect = False
Me.grPrograma.Name = "grPrograma"
Me.grPrograma.RowHeadersVisible = False
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft
Me.grPrograma.RowsDefaultCellStyle = DataGridViewCellStyle1
Me.grPrograma.RowTemplate.Height = 50
Me.grPrograma.Size = New System.Drawing.Size(613, 508)
Me.grPrograma.TabIndex = 111
'
'Button2
'
Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
Me.Button2.Location = New System.Drawing.Point(661, 334)
Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.Button2.Name = "Button2"
Me.Button2.Size = New System.Drawing.Size(43, 47)
Me.Button2.TabIndex = 109
Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
Me.Button2.UseVisualStyleBackColor = True
'
'Button3
'
Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
Me.Button3.Location = New System.Drawing.Point(661, 385)
Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.Button3.Name = "Button3"
Me.Button3.Size = New System.Drawing.Size(43, 47)
Me.Button3.TabIndex = 110
Me.Button3.UseVisualStyleBackColor = True
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(1166, 25)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(51, 17)
Me.Label1.TabIndex = 111
Me.Label1.Text = "Label1"
Me.Label1.Visible = False
'
'dtpFF_SubT
'
Me.dtpFF_SubT.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFF_SubT.Location = New System.Drawing.Point(121, 38)
Me.dtpFF_SubT.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFF_SubT.Name = "dtpFF_SubT"
Me.dtpFF_SubT.Size = New System.Drawing.Size(165, 22)
Me.dtpFF_SubT.TabIndex = 103
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(26, 38)
Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(70, 17)
Me.Label2.TabIndex = 113
Me.Label2.Text = "Fecha Fin"
'
'tbcProgramador
'
Me.tbcProgramador.Controls.Add(Me.tbpProgramador)
Me.tbcProgramador.Controls.Add(Me.tbpConsulta)
Me.tbcProgramador.Location = New System.Drawing.Point(16, 15)
Me.tbcProgramador.Margin = New System.Windows.Forms.Padding(4)
Me.tbcProgramador.Name = "tbcProgramador"
Me.tbcProgramador.SelectedIndex = 0
Me.tbcProgramador.Size = New System.Drawing.Size(1372, 836)
Me.tbcProgramador.TabIndex = 114
'
'tbpProgramador
'
Me.tbpProgramador.BackColor = System.Drawing.SystemColors.Control
Me.tbpProgramador.Controls.Add(Me.lblProgCab_Id)
Me.tbpProgramador.Controls.Add(Me.dtpFF_SubT_Prog)
Me.tbpProgramador.Controls.Add(Me.Label7)
Me.tbpProgramador.Controls.Add(Me.dtpFI_SubT_Prog)
Me.tbpProgramador.Controls.Add(Me.Label9)
Me.tbpProgramador.Controls.Add(Me.Label6)
Me.tbpProgramador.Controls.Add(Me.lblCntHoras3)
Me.tbpProgramador.Controls.Add(Me.Label8)
Me.tbpProgramador.Controls.Add(Me.lblCntSubTareas3)
Me.tbpProgramador.Controls.Add(Me.lblTituloCntHoras2)
Me.tbpProgramador.Controls.Add(Me.lblCntHoras2)
Me.tbpProgramador.Controls.Add(Me.lblTituloCntSubTareas2)
Me.tbpProgramador.Controls.Add(Me.lblCntSubTareas2)
Me.tbpProgramador.Controls.Add(Me.lstSubTareas)
Me.tbpProgramador.Controls.Add(Me.Button1)
Me.tbpProgramador.Controls.Add(Me.dtpFF_SubT)
Me.tbpProgramador.Controls.Add(Me.btnAdicionar)
Me.tbpProgramador.Controls.Add(Me.Label2)
Me.tbpProgramador.Controls.Add(Me.btnRemover)
Me.tbpProgramador.Controls.Add(Me.Label1)
Me.tbpProgramador.Controls.Add(Me.Button2)
Me.tbpProgramador.Controls.Add(Me.grPrograma)
Me.tbpProgramador.Controls.Add(Me.dtpFI_SubT)
Me.tbpProgramador.Controls.Add(Me.Label54)
Me.tbpProgramador.Controls.Add(Me.Button3)
Me.tbpProgramador.Controls.Add(Me.Label48)
Me.tbpProgramador.Controls.Add(Me.cmbOperarios)
Me.tbpProgramador.Location = New System.Drawing.Point(4, 25)
Me.tbpProgramador.Margin = New System.Windows.Forms.Padding(4)
Me.tbpProgramador.Name = "tbpProgramador"
Me.tbpProgramador.Padding = New System.Windows.Forms.Padding(4)
Me.tbpProgramador.Size = New System.Drawing.Size(1364, 807)
Me.tbpProgramador.TabIndex = 0
Me.tbpProgramador.Text = "Programador"
'
'dtpFF_SubT_Prog
'
Me.dtpFF_SubT_Prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFF_SubT_Prog.Location = New System.Drawing.Point(825, 38)
Me.dtpFF_SubT_Prog.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFF_SubT_Prog.Name = "dtpFF_SubT_Prog"
Me.dtpFF_SubT_Prog.Size = New System.Drawing.Size(165, 22)
Me.dtpFF_SubT_Prog.TabIndex = 141
'
'Label7
'
Me.Label7.AutoSize = True
Me.Label7.Location = New System.Drawing.Point(727, 38)
Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label7.Name = "Label7"
Me.Label7.Size = New System.Drawing.Size(70, 17)
Me.Label7.TabIndex = 142
Me.Label7.Text = "Fecha Fin"
'
'dtpFI_SubT_Prog
'
Me.dtpFI_SubT_Prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFI_SubT_Prog.Location = New System.Drawing.Point(825, 10)
Me.dtpFI_SubT_Prog.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFI_SubT_Prog.Name = "dtpFI_SubT_Prog"
Me.dtpFI_SubT_Prog.Size = New System.Drawing.Size(165, 22)
Me.dtpFI_SubT_Prog.TabIndex = 139
'
'Label9
'
Me.Label9.AutoSize = True
Me.Label9.Location = New System.Drawing.Point(727, 10)
Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label9.Name = "Label9"
Me.Label9.Size = New System.Drawing.Size(83, 17)
Me.Label9.TabIndex = 140
Me.Label9.Text = "Fecha Inicio"
'
'Label6
'
Me.Label6.AutoSize = True
Me.Label6.Location = New System.Drawing.Point(26, 658)
Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label6.Name = "Label6"
Me.Label6.Size = New System.Drawing.Size(87, 17)
Me.Label6.TabIndex = 138
Me.Label6.Text = "Cant. Horas:"
'
'lblCntHoras3
'
Me.lblCntHoras3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntHoras3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntHoras3.Location = New System.Drawing.Point(125, 658)
Me.lblCntHoras3.Name = "lblCntHoras3"
Me.lblCntHoras3.Size = New System.Drawing.Size(211, 30)
Me.lblCntHoras3.TabIndex = 137
Me.lblCntHoras3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'Label8
'
Me.Label8.AutoSize = True
Me.Label8.Location = New System.Drawing.Point(26, 624)
Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label8.Name = "Label8"
Me.Label8.Size = New System.Drawing.Size(86, 17)
Me.Label8.TabIndex = 136
Me.Label8.Text = "Sub Tareas:"
'
'lblCntSubTareas3
'
Me.lblCntSubTareas3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntSubTareas3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntSubTareas3.Location = New System.Drawing.Point(125, 624)
Me.lblCntSubTareas3.Name = "lblCntSubTareas3"
Me.lblCntSubTareas3.Size = New System.Drawing.Size(211, 30)
Me.lblCntSubTareas3.TabIndex = 135
Me.lblCntSubTareas3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblTituloCntHoras2
'
Me.lblTituloCntHoras2.AutoSize = True
Me.lblTituloCntHoras2.Location = New System.Drawing.Point(727, 658)
Me.lblTituloCntHoras2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblTituloCntHoras2.Name = "lblTituloCntHoras2"
Me.lblTituloCntHoras2.Size = New System.Drawing.Size(87, 17)
Me.lblTituloCntHoras2.TabIndex = 134
Me.lblTituloCntHoras2.Text = "Cant. Horas:"
'
'lblCntHoras2
'
Me.lblCntHoras2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntHoras2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntHoras2.Location = New System.Drawing.Point(825, 658)
Me.lblCntHoras2.Name = "lblCntHoras2"
Me.lblCntHoras2.Size = New System.Drawing.Size(211, 30)
Me.lblCntHoras2.TabIndex = 133
Me.lblCntHoras2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblTituloCntSubTareas2
'
Me.lblTituloCntSubTareas2.AutoSize = True
Me.lblTituloCntSubTareas2.Location = New System.Drawing.Point(727, 624)
Me.lblTituloCntSubTareas2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblTituloCntSubTareas2.Name = "lblTituloCntSubTareas2"
Me.lblTituloCntSubTareas2.Size = New System.Drawing.Size(86, 17)
Me.lblTituloCntSubTareas2.TabIndex = 132
Me.lblTituloCntSubTareas2.Text = "Sub Tareas:"
'
'lblCntSubTareas2
'
Me.lblCntSubTareas2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntSubTareas2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntSubTareas2.Location = New System.Drawing.Point(825, 624)
Me.lblCntSubTareas2.Name = "lblCntSubTareas2"
Me.lblCntSubTareas2.Size = New System.Drawing.Size(211, 30)
Me.lblCntSubTareas2.TabIndex = 131
Me.lblCntSubTareas2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'tbpConsulta
'
Me.tbpConsulta.BackColor = System.Drawing.SystemColors.Control
Me.tbpConsulta.Controls.Add(Me.lblTituloCntHoras)
Me.tbpConsulta.Controls.Add(Me.lblCntHoras)
Me.tbpConsulta.Controls.Add(Me.lblTituloCntSubTareas)
Me.tbpConsulta.Controls.Add(Me.lblCntSubTareas)
Me.tbpConsulta.Controls.Add(Me.lblStrOperario_Id)
Me.tbpConsulta.Controls.Add(Me.lblSiDatos)
Me.tbpConsulta.Controls.Add(Me.Chart1)
Me.tbpConsulta.Controls.Add(Me.dtpFF_Prog)
Me.tbpConsulta.Controls.Add(Me.Label3)
Me.tbpConsulta.Controls.Add(Me.dtpFI_Prog)
Me.tbpConsulta.Controls.Add(Me.Label4)
Me.tbpConsulta.Controls.Add(Me.Label5)
Me.tbpConsulta.Controls.Add(Me.cmbOperariosConsulta)
Me.tbpConsulta.Location = New System.Drawing.Point(4, 25)
Me.tbpConsulta.Margin = New System.Windows.Forms.Padding(4)
Me.tbpConsulta.Name = "tbpConsulta"
Me.tbpConsulta.Padding = New System.Windows.Forms.Padding(4)
Me.tbpConsulta.Size = New System.Drawing.Size(1364, 807)
Me.tbpConsulta.TabIndex = 1
Me.tbpConsulta.Text = "Consultar"
'
'lblTituloCntHoras
'
Me.lblTituloCntHoras.AutoSize = True
Me.lblTituloCntHoras.Location = New System.Drawing.Point(685, 53)
Me.lblTituloCntHoras.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblTituloCntHoras.Name = "lblTituloCntHoras"
Me.lblTituloCntHoras.Size = New System.Drawing.Size(87, 17)
Me.lblTituloCntHoras.TabIndex = 130
Me.lblTituloCntHoras.Text = "Cant. Horas:"
'
'lblCntHoras
'
Me.lblCntHoras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntHoras.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntHoras.Location = New System.Drawing.Point(778, 46)
Me.lblCntHoras.Name = "lblCntHoras"
Me.lblCntHoras.Size = New System.Drawing.Size(211, 30)
Me.lblCntHoras.TabIndex = 129
Me.lblCntHoras.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblTituloCntSubTareas
'
Me.lblTituloCntSubTareas.AutoSize = True
Me.lblTituloCntSubTareas.Location = New System.Drawing.Point(685, 19)
Me.lblTituloCntSubTareas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblTituloCntSubTareas.Name = "lblTituloCntSubTareas"
Me.lblTituloCntSubTareas.Size = New System.Drawing.Size(86, 17)
Me.lblTituloCntSubTareas.TabIndex = 128
Me.lblTituloCntSubTareas.Text = "Sub Tareas:"
'
'lblCntSubTareas
'
Me.lblCntSubTareas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblCntSubTareas.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblCntSubTareas.Location = New System.Drawing.Point(778, 12)
Me.lblCntSubTareas.Name = "lblCntSubTareas"
Me.lblCntSubTareas.Size = New System.Drawing.Size(211, 30)
Me.lblCntSubTareas.TabIndex = 127
Me.lblCntSubTareas.TextAlign = System.Drawing.ContentAlignment.MiddleRight
'
'lblStrOperario_Id
'
Me.lblStrOperario_Id.AutoSize = True
Me.lblStrOperario_Id.Location = New System.Drawing.Point(1168, 76)
Me.lblStrOperario_Id.Name = "lblStrOperario_Id"
Me.lblStrOperario_Id.Size = New System.Drawing.Size(51, 17)
Me.lblStrOperario_Id.TabIndex = 122
Me.lblStrOperario_Id.Text = "Label6"
'
'lblSiDatos
'
Me.lblSiDatos.AutoSize = True
Me.lblSiDatos.Location = New System.Drawing.Point(568, 72)
Me.lblSiDatos.Name = "lblSiDatos"
Me.lblSiDatos.Size = New System.Drawing.Size(95, 17)
Me.lblSiDatos.TabIndex = 121
Me.lblSiDatos.Text = "No hay datos!"
Me.lblSiDatos.Visible = False
'
'Chart1
'
ChartArea1.Name = "ChartArea1"
Me.Chart1.ChartAreas.Add(ChartArea1)
Me.Chart1.Location = New System.Drawing.Point(104, 102)
Me.Chart1.Margin = New System.Windows.Forms.Padding(4)
Me.Chart1.Name = "Chart1"
Me.Chart1.Size = New System.Drawing.Size(1093, 694)
Me.Chart1.TabIndex = 120
Me.Chart1.Text = "Chart1"
'
'dtpFF_Prog
'
Me.dtpFF_Prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFF_Prog.Location = New System.Drawing.Point(104, 36)
Me.dtpFF_Prog.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFF_Prog.Name = "dtpFF_Prog"
Me.dtpFF_Prog.Size = New System.Drawing.Size(165, 22)
Me.dtpFF_Prog.TabIndex = 117
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(8, 38)
Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(70, 17)
Me.Label3.TabIndex = 119
Me.Label3.Text = "Fecha Fin"
'
'dtpFI_Prog
'
Me.dtpFI_Prog.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFI_Prog.Location = New System.Drawing.Point(104, 7)
Me.dtpFI_Prog.Margin = New System.Windows.Forms.Padding(4)
Me.dtpFI_Prog.Name = "dtpFI_Prog"
Me.dtpFI_Prog.Size = New System.Drawing.Size(165, 22)
Me.dtpFI_Prog.TabIndex = 115
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Location = New System.Drawing.Point(8, 10)
Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(83, 17)
Me.Label4.TabIndex = 116
Me.Label4.Text = "Fecha Inicio"
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(8, 69)
Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(68, 17)
Me.Label5.TabIndex = 114
Me.Label5.Text = "Operario:"
'
'cmbOperariosConsulta
'
Me.cmbOperariosConsulta.BackColor = System.Drawing.SystemColors.Window
Me.cmbOperariosConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
Me.cmbOperariosConsulta.FormattingEnabled = True
Me.cmbOperariosConsulta.Location = New System.Drawing.Point(104, 69)
Me.cmbOperariosConsulta.Margin = New System.Windows.Forms.Padding(4)
Me.cmbOperariosConsulta.MaxDropDownItems = 10
Me.cmbOperariosConsulta.Name = "cmbOperariosConsulta"
Me.cmbOperariosConsulta.Size = New System.Drawing.Size(457, 24)
Me.cmbOperariosConsulta.TabIndex = 118
'
'lblProgCab_Id
'
Me.lblProgCab_Id.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.lblProgCab_Id.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblProgCab_Id.Location = New System.Drawing.Point(727, 66)
Me.lblProgCab_Id.Name = "lblProgCab_Id"
Me.lblProgCab_Id.Size = New System.Drawing.Size(457, 24)
Me.lblProgCab_Id.TabIndex = 143
Me.lblProgCab_Id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
'
'frmProgramador
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1677, 896)
Me.Controls.Add(Me.tbcProgramador)
Me.Controls.Add(Me.StatusStrip1)
Me.Controls.Add(Me.flyPanelBotones)
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmProgramador"
Me.Text = "Consola Programador Actividades"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
Me.StatusStrip1.ResumeLayout(False)
Me.StatusStrip1.PerformLayout()
CType(Me.grPrograma, System.ComponentModel.ISupportInitialize).EndInit()
Me.tbcProgramador.ResumeLayout(False)
Me.tbpProgramador.ResumeLayout(False)
Me.tbpProgramador.PerformLayout()
Me.tbpConsulta.ResumeLayout(False)
Me.tbpConsulta.PerformLayout()
CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stNumOrden As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stNumRemision As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stEstadoRemision As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stEstadoOT As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cmbOperarios As System.Windows.Forms.ComboBox
    Friend WithEvents lstSubTareas As System.Windows.Forms.ListBox
    Friend WithEvents dtpFI_SubT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents btnAdicionar As System.Windows.Forms.Button
    Friend WithEvents btnRemover As System.Windows.Forms.Button
    Friend WithEvents grPrograma As System.Windows.Forms.DataGridView
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFF_SubT As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbcProgramador As System.Windows.Forms.TabControl
    Friend WithEvents tbpProgramador As System.Windows.Forms.TabPage
    Friend WithEvents tbpConsulta As System.Windows.Forms.TabPage
    Friend WithEvents dtpFF_Prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFI_Prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbOperariosConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents lblSiDatos As System.Windows.Forms.Label
    Friend WithEvents lblStrOperario_Id As System.Windows.Forms.Label
    Friend WithEvents lblTituloCntHoras2 As System.Windows.Forms.Label
    Friend WithEvents lblCntHoras2 As System.Windows.Forms.Label
    Friend WithEvents lblTituloCntSubTareas2 As System.Windows.Forms.Label
    Friend WithEvents lblCntSubTareas2 As System.Windows.Forms.Label
    Friend WithEvents lblTituloCntHoras As System.Windows.Forms.Label
    Friend WithEvents lblCntHoras As System.Windows.Forms.Label
    Friend WithEvents lblTituloCntSubTareas As System.Windows.Forms.Label
    Friend WithEvents lblCntSubTareas As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblCntHoras3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblCntSubTareas3 As System.Windows.Forms.Label
    Friend WithEvents dtpFF_SubT_Prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFI_SubT_Prog As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblProgCab_Id As System.Windows.Forms.Label
End Class
