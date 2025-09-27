<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenuWin10
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
Me.components = New System.ComponentModel.Container()
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenuWin10))
Me.mnuVertical = New System.Windows.Forms.Panel()
Me.lblAmbiente = New System.Windows.Forms.Label()
Me.icoMinimizar = New System.Windows.Forms.PictureBox()
Me.btnApagar = New System.Windows.Forms.Button()
Me.barraTitulo = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.flpVentanas = New System.Windows.Forms.FlowLayoutPanel()
Me.stbEstado = New System.Windows.Forms.StatusStrip()
Me.stDominio = New System.Windows.Forms.ToolStripStatusLabel()
Me.stUsuario = New System.Windows.Forms.ToolStripStatusLabel()
Me.stVersion = New System.Windows.Forms.ToolStripStatusLabel()
Me.stAmbiente = New System.Windows.Forms.ToolStripStatusLabel()
Me.flpMenu = New System.Windows.Forms.FlowLayoutPanel()
Me.btnComercial = New System.Windows.Forms.Button()
Me.submenuComercial = New System.Windows.Forms.Panel()
Me.btnContratos = New System.Windows.Forms.Button()
Me.btnCotizar = New System.Windows.Forms.Button()
Me.btnProduccion = New System.Windows.Forms.Button()
Me.submenuProduccion = New System.Windows.Forms.Panel()
Me.btnGastosMontaje = New System.Windows.Forms.Button()
Me.BtnProgramador = New System.Windows.Forms.Button()
Me.btnValidacionRes = New System.Windows.Forms.Button()
Me.btnConResumen = New System.Windows.Forms.Button()
Me.btnValidarOT = New System.Windows.Forms.Button()
Me.btnControlImpresion = New System.Windows.Forms.Button()
Me.btnRemision = New System.Windows.Forms.Button()
Me.btnResumen = New System.Windows.Forms.Button()
Me.btnDividirOT = New System.Windows.Forms.Button()
Me.btnMateriales = New System.Windows.Forms.Button()
Me.btnRegistroOT = New System.Windows.Forms.Button()
Me.btnCompras = New System.Windows.Forms.Button()
Me.subMenuCompras = New System.Windows.Forms.Panel()
Me.btnMtoOrdenCompra = New System.Windows.Forms.Button()
Me.btnMtoPedidos = New System.Windows.Forms.Button()
Me.btnLiberaPedidoAlmacen = New System.Windows.Forms.Button()
Me.btnIngresoOC = New System.Windows.Forms.Button()
Me.btnBorrarPedido = New System.Windows.Forms.Button()
Me.btnValidarOrdenes = New System.Windows.Forms.Button()
Me.btnPedidoManual = New System.Windows.Forms.Button()
Me.btnCriterios = New System.Windows.Forms.Button()
Me.btnOrdenCompra = New System.Windows.Forms.Button()
Me.btnActualizaPrecios = New System.Windows.Forms.Button()
Me.btnPedidos = New System.Windows.Forms.Button()
Me.btnInventarios = New System.Windows.Forms.Button()
Me.subMenuInventario = New System.Windows.Forms.Panel()
Me.btnGeneraReporteInventario = New System.Windows.Forms.Button()
Me.btnRegistroMov = New System.Windows.Forms.Button()
Me.btnReportes = New System.Windows.Forms.Button()
Me.submenuReportes = New System.Windows.Forms.Panel()
Me.btnRptNotificar = New System.Windows.Forms.Button()
Me.btnRptSubTareasGeneral = New System.Windows.Forms.Button()
Me.btnRptSubTareas = New System.Windows.Forms.Button()
Me.btnRptPedidos = New System.Windows.Forms.Button()
Me.btnRptCotAGerencia = New System.Windows.Forms.Button()
Me.btnRptOT = New System.Windows.Forms.Button()
Me.btnRptCotizaciones = New System.Windows.Forms.Button()
Me.btnMto = New System.Windows.Forms.Button()
Me.subMenuMto = New System.Windows.Forms.Panel()
Me.BtnOperarios = New System.Windows.Forms.Button()
Me.btnReversaEstadosOT = New System.Windows.Forms.Button()
Me.btnResponsables = New System.Windows.Forms.Button()
Me.btnMntoMO = New System.Windows.Forms.Button()
Me.btnCambiaEstadoCotizacion = New System.Windows.Forms.Button()
Me.btnParametros = New System.Windows.Forms.Button()
Me.btnMPNoCreada = New System.Windows.Forms.Button()
Me.imgLogo = New System.Windows.Forms.PictureBox()
Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
Me.mnuVertical.SuspendLayout()
CType(Me.icoMinimizar, System.ComponentModel.ISupportInitialize).BeginInit()
Me.barraTitulo.SuspendLayout()
Me.stbEstado.SuspendLayout()
Me.flpMenu.SuspendLayout()
Me.submenuComercial.SuspendLayout()
Me.submenuProduccion.SuspendLayout()
Me.subMenuCompras.SuspendLayout()
Me.subMenuInventario.SuspendLayout()
Me.submenuReportes.SuspendLayout()
Me.subMenuMto.SuspendLayout()
CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'mnuVertical
'
Me.mnuVertical.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(41, Byte), Integer))
Me.mnuVertical.Controls.Add(Me.lblAmbiente)
Me.mnuVertical.Controls.Add(Me.icoMinimizar)
Me.mnuVertical.Controls.Add(Me.btnApagar)
Me.mnuVertical.Controls.Add(Me.barraTitulo)
Me.mnuVertical.Controls.Add(Me.stbEstado)
Me.mnuVertical.Controls.Add(Me.flpMenu)
Me.mnuVertical.Controls.Add(Me.imgLogo)
Me.mnuVertical.Cursor = System.Windows.Forms.Cursors.Default
Me.mnuVertical.Dock = System.Windows.Forms.DockStyle.Left
Me.mnuVertical.Location = New System.Drawing.Point(0, 0)
Me.mnuVertical.Name = "mnuVertical"
Me.mnuVertical.Size = New System.Drawing.Size(277, 718)
Me.mnuVertical.TabIndex = 0
'
'lblAmbiente
'
Me.lblAmbiente.AutoSize = True
Me.lblAmbiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblAmbiente.ForeColor = System.Drawing.Color.Yellow
Me.lblAmbiente.Location = New System.Drawing.Point(133, 9)
Me.lblAmbiente.Name = "lblAmbiente"
Me.lblAmbiente.Size = New System.Drawing.Size(103, 20)
Me.lblAmbiente.TabIndex = 17
Me.lblAmbiente.Text = "lblAmbiente"
Me.lblAmbiente.Visible = False
'
'icoMinimizar
'
Me.icoMinimizar.Cursor = System.Windows.Forms.Cursors.Hand
Me.icoMinimizar.Image = CType(resources.GetObject("icoMinimizar.Image"), System.Drawing.Image)
Me.icoMinimizar.Location = New System.Drawing.Point(242, 3)
Me.icoMinimizar.Name = "icoMinimizar"
Me.icoMinimizar.Size = New System.Drawing.Size(30, 34)
Me.icoMinimizar.TabIndex = 16
Me.icoMinimizar.TabStop = False
'
'btnApagar
'
Me.btnApagar.FlatAppearance.BorderSize = 0
Me.btnApagar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnApagar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnApagar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnApagar.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnApagar.ForeColor = System.Drawing.Color.White
Me.btnApagar.Image = CType(resources.GetObject("btnApagar.Image"), System.Drawing.Image)
Me.btnApagar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnApagar.Location = New System.Drawing.Point(6, 648)
Me.btnApagar.Name = "btnApagar"
Me.btnApagar.Size = New System.Drawing.Size(44, 40)
Me.btnApagar.TabIndex = 15
Me.btnApagar.UseVisualStyleBackColor = True
'
'barraTitulo
'
Me.barraTitulo.BackColor = System.Drawing.Color.WhiteSmoke
Me.barraTitulo.Controls.Add(Me.btnBotonera)
Me.barraTitulo.Controls.Add(Me.flpVentanas)
Me.barraTitulo.Location = New System.Drawing.Point(0, 48)
Me.barraTitulo.Name = "barraTitulo"
Me.barraTitulo.Size = New System.Drawing.Size(277, 45)
Me.barraTitulo.TabIndex = 14
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
Me.btnBotonera.Location = New System.Drawing.Point(253, 5)
Me.btnBotonera.Name = "btnBotonera"
Me.btnBotonera.Size = New System.Drawing.Size(21, 35)
Me.btnBotonera.TabIndex = 85
Me.btnBotonera.UseVisualStyleBackColor = True
'
'flpVentanas
'
Me.flpVentanas.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.flpVentanas.AutoScroll = True
Me.flpVentanas.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(41, Byte), Integer))
Me.flpVentanas.Location = New System.Drawing.Point(3, 5)
Me.flpVentanas.Name = "flpVentanas"
Me.flpVentanas.Size = New System.Drawing.Size(247, 35)
Me.flpVentanas.TabIndex = 5
'
'stbEstado
'
Me.stbEstado.BackColor = System.Drawing.SystemColors.Control
Me.stbEstado.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.stbEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stDominio, Me.stUsuario, Me.stVersion, Me.stAmbiente})
Me.stbEstado.Location = New System.Drawing.Point(0, 696)
Me.stbEstado.Name = "stbEstado"
Me.stbEstado.Size = New System.Drawing.Size(277, 22)
Me.stbEstado.TabIndex = 12
Me.stbEstado.Text = "StatusStrip1"
'
'stDominio
'
Me.stDominio.Name = "stDominio"
Me.stDominio.Size = New System.Drawing.Size(57, 17)
Me.stDominio.Text = "Dominio"
'
'stUsuario
'
Me.stUsuario.Name = "stUsuario"
Me.stUsuario.Size = New System.Drawing.Size(51, 17)
Me.stUsuario.Text = "Usuario"
'
'stVersion
'
Me.stVersion.Name = "stVersion"
Me.stVersion.Size = New System.Drawing.Size(51, 17)
Me.stVersion.Text = "version"
'
'stAmbiente
'
Me.stAmbiente.Name = "stAmbiente"
Me.stAmbiente.Size = New System.Drawing.Size(0, 17)
'
'flpMenu
'
Me.flpMenu.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.flpMenu.AutoScroll = True
Me.flpMenu.Controls.Add(Me.btnComercial)
Me.flpMenu.Controls.Add(Me.submenuComercial)
Me.flpMenu.Controls.Add(Me.btnProduccion)
Me.flpMenu.Controls.Add(Me.submenuProduccion)
Me.flpMenu.Controls.Add(Me.btnCompras)
Me.flpMenu.Controls.Add(Me.subMenuCompras)
Me.flpMenu.Controls.Add(Me.btnInventarios)
Me.flpMenu.Controls.Add(Me.subMenuInventario)
Me.flpMenu.Controls.Add(Me.btnReportes)
Me.flpMenu.Controls.Add(Me.submenuReportes)
Me.flpMenu.Controls.Add(Me.btnMto)
Me.flpMenu.Controls.Add(Me.subMenuMto)
Me.flpMenu.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flpMenu.Location = New System.Drawing.Point(0, 99)
Me.flpMenu.Name = "flpMenu"
Me.flpMenu.Size = New System.Drawing.Size(277, 558)
Me.flpMenu.TabIndex = 1
Me.flpMenu.WrapContents = False
'
'btnComercial
'
Me.btnComercial.FlatAppearance.BorderSize = 0
Me.btnComercial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnComercial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnComercial.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnComercial.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnComercial.ForeColor = System.Drawing.Color.White
Me.btnComercial.Image = CType(resources.GetObject("btnComercial.Image"), System.Drawing.Image)
Me.btnComercial.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnComercial.Location = New System.Drawing.Point(3, 3)
Me.btnComercial.Name = "btnComercial"
Me.btnComercial.Size = New System.Drawing.Size(230, 40)
Me.btnComercial.TabIndex = 1
Me.btnComercial.Text = "Comercial"
Me.btnComercial.UseVisualStyleBackColor = True
'
'submenuComercial
'
Me.submenuComercial.Controls.Add(Me.btnContratos)
Me.submenuComercial.Controls.Add(Me.btnCotizar)
Me.submenuComercial.Location = New System.Drawing.Point(3, 49)
Me.submenuComercial.Name = "submenuComercial"
Me.submenuComercial.Size = New System.Drawing.Size(230, 90)
Me.submenuComercial.TabIndex = 7
Me.submenuComercial.Visible = False
'
'btnContratos
'
Me.btnContratos.FlatAppearance.BorderSize = 0
Me.btnContratos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnContratos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnContratos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnContratos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnContratos.ForeColor = System.Drawing.Color.White
Me.btnContratos.Image = CType(resources.GetObject("btnContratos.Image"), System.Drawing.Image)
Me.btnContratos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnContratos.Location = New System.Drawing.Point(20, 49)
Me.btnContratos.Name = "btnContratos"
Me.btnContratos.Size = New System.Drawing.Size(205, 40)
Me.btnContratos.TabIndex = 7
Me.btnContratos.Text = "Contratos"
Me.btnContratos.UseVisualStyleBackColor = True
'
'btnCotizar
'
Me.btnCotizar.FlatAppearance.BorderSize = 0
Me.btnCotizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnCotizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnCotizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCotizar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCotizar.ForeColor = System.Drawing.Color.White
Me.btnCotizar.Image = CType(resources.GetObject("btnCotizar.Image"), System.Drawing.Image)
Me.btnCotizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCotizar.Location = New System.Drawing.Point(20, 3)
Me.btnCotizar.Name = "btnCotizar"
Me.btnCotizar.Size = New System.Drawing.Size(205, 40)
Me.btnCotizar.TabIndex = 6
Me.btnCotizar.Text = "Cotización"
Me.btnCotizar.UseVisualStyleBackColor = True
'
'btnProduccion
'
Me.btnProduccion.FlatAppearance.BorderSize = 0
Me.btnProduccion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnProduccion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnProduccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnProduccion.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnProduccion.ForeColor = System.Drawing.Color.White
Me.btnProduccion.Image = CType(resources.GetObject("btnProduccion.Image"), System.Drawing.Image)
Me.btnProduccion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnProduccion.Location = New System.Drawing.Point(3, 145)
Me.btnProduccion.Name = "btnProduccion"
Me.btnProduccion.Size = New System.Drawing.Size(230, 40)
Me.btnProduccion.TabIndex = 2
Me.btnProduccion.Tag = "btnComercial"
Me.btnProduccion.Text = "Produccion"
Me.btnProduccion.UseVisualStyleBackColor = True
'
'submenuProduccion
'
Me.submenuProduccion.Controls.Add(Me.btnGastosMontaje)
Me.submenuProduccion.Controls.Add(Me.BtnProgramador)
Me.submenuProduccion.Controls.Add(Me.btnValidacionRes)
Me.submenuProduccion.Controls.Add(Me.btnConResumen)
Me.submenuProduccion.Controls.Add(Me.btnValidarOT)
Me.submenuProduccion.Controls.Add(Me.btnControlImpresion)
Me.submenuProduccion.Controls.Add(Me.btnRemision)
Me.submenuProduccion.Controls.Add(Me.btnResumen)
Me.submenuProduccion.Controls.Add(Me.btnDividirOT)
Me.submenuProduccion.Controls.Add(Me.btnMateriales)
Me.submenuProduccion.Controls.Add(Me.btnRegistroOT)
Me.submenuProduccion.Location = New System.Drawing.Point(3, 191)
Me.submenuProduccion.Name = "submenuProduccion"
Me.submenuProduccion.Size = New System.Drawing.Size(230, 504)
Me.submenuProduccion.TabIndex = 9
Me.submenuProduccion.Visible = False
'
'btnGastosMontaje
'
Me.btnGastosMontaje.FlatAppearance.BorderSize = 0
Me.btnGastosMontaje.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnGastosMontaje.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnGastosMontaje.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnGastosMontaje.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnGastosMontaje.ForeColor = System.Drawing.Color.White
Me.btnGastosMontaje.Image = CType(resources.GetObject("btnGastosMontaje.Image"), System.Drawing.Image)
Me.btnGastosMontaje.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnGastosMontaje.Location = New System.Drawing.Point(19, 461)
Me.btnGastosMontaje.Name = "btnGastosMontaje"
Me.btnGastosMontaje.Size = New System.Drawing.Size(205, 40)
Me.btnGastosMontaje.TabIndex = 16
Me.btnGastosMontaje.Text = "Gastos Montaje"
Me.btnGastosMontaje.UseVisualStyleBackColor = True
'
'BtnProgramador
'
Me.BtnProgramador.FlatAppearance.BorderSize = 0
Me.BtnProgramador.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BtnProgramador.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.BtnProgramador.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BtnProgramador.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnProgramador.ForeColor = System.Drawing.Color.White
Me.BtnProgramador.Image = CType(resources.GetObject("BtnProgramador.Image"), System.Drawing.Image)
Me.BtnProgramador.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.BtnProgramador.Location = New System.Drawing.Point(19, 414)
Me.BtnProgramador.Name = "BtnProgramador"
Me.BtnProgramador.Size = New System.Drawing.Size(205, 40)
Me.BtnProgramador.TabIndex = 15
Me.BtnProgramador.Text = "Programación"
Me.BtnProgramador.UseVisualStyleBackColor = True
'
'btnValidacionRes
'
Me.btnValidacionRes.FlatAppearance.BorderSize = 0
Me.btnValidacionRes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnValidacionRes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnValidacionRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnValidacionRes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnValidacionRes.ForeColor = System.Drawing.Color.White
Me.btnValidacionRes.Image = CType(resources.GetObject("btnValidacionRes.Image"), System.Drawing.Image)
Me.btnValidacionRes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnValidacionRes.Location = New System.Drawing.Point(20, 370)
Me.btnValidacionRes.Name = "btnValidacionRes"
Me.btnValidacionRes.Size = New System.Drawing.Size(205, 37)
Me.btnValidacionRes.TabIndex = 14
Me.btnValidacionRes.Text = "Validación Remision"
Me.btnValidacionRes.UseVisualStyleBackColor = True
'
'btnConResumen
'
Me.btnConResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(41, Byte), Integer))
Me.btnConResumen.FlatAppearance.BorderSize = 0
Me.btnConResumen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnConResumen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnConResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnConResumen.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnConResumen.ForeColor = System.Drawing.Color.White
Me.btnConResumen.Image = CType(resources.GetObject("btnConResumen.Image"), System.Drawing.Image)
Me.btnConResumen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnConResumen.Location = New System.Drawing.Point(20, 324)
Me.btnConResumen.Name = "btnConResumen"
Me.btnConResumen.Size = New System.Drawing.Size(205, 40)
Me.btnConResumen.TabIndex = 13
Me.btnConResumen.Text = "Consola Resumen"
Me.btnConResumen.UseVisualStyleBackColor = False
'
'btnValidarOT
'
Me.btnValidarOT.FlatAppearance.BorderSize = 0
Me.btnValidarOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnValidarOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnValidarOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnValidarOT.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnValidarOT.ForeColor = System.Drawing.Color.White
Me.btnValidarOT.Image = CType(resources.GetObject("btnValidarOT.Image"), System.Drawing.Image)
Me.btnValidarOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnValidarOT.Location = New System.Drawing.Point(20, 276)
Me.btnValidarOT.Name = "btnValidarOT"
Me.btnValidarOT.Size = New System.Drawing.Size(205, 37)
Me.btnValidarOT.TabIndex = 12
Me.btnValidarOT.Text = "Validación OT"
Me.btnValidarOT.UseVisualStyleBackColor = True
'
'btnControlImpresion
'
Me.btnControlImpresion.FlatAppearance.BorderSize = 0
Me.btnControlImpresion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnControlImpresion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnControlImpresion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnControlImpresion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnControlImpresion.ForeColor = System.Drawing.Color.White
Me.btnControlImpresion.Image = CType(resources.GetObject("btnControlImpresion.Image"), System.Drawing.Image)
Me.btnControlImpresion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnControlImpresion.Location = New System.Drawing.Point(20, 233)
Me.btnControlImpresion.Name = "btnControlImpresion"
Me.btnControlImpresion.Size = New System.Drawing.Size(205, 37)
Me.btnControlImpresion.TabIndex = 11
Me.btnControlImpresion.Text = "Control Impresiones"
Me.btnControlImpresion.UseVisualStyleBackColor = True
'
'btnRemision
'
Me.btnRemision.FlatAppearance.BorderSize = 0
Me.btnRemision.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRemision.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRemision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRemision.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRemision.ForeColor = System.Drawing.Color.White
Me.btnRemision.Image = CType(resources.GetObject("btnRemision.Image"), System.Drawing.Image)
Me.btnRemision.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRemision.Location = New System.Drawing.Point(20, 187)
Me.btnRemision.Name = "btnRemision"
Me.btnRemision.Size = New System.Drawing.Size(205, 40)
Me.btnRemision.TabIndex = 10
Me.btnRemision.Text = "Remisión"
Me.btnRemision.UseVisualStyleBackColor = True
'
'btnResumen
'
Me.btnResumen.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(14, Byte), Integer), CType(CType(41, Byte), Integer))
Me.btnResumen.FlatAppearance.BorderSize = 0
Me.btnResumen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnResumen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnResumen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnResumen.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnResumen.ForeColor = System.Drawing.Color.White
Me.btnResumen.Image = CType(resources.GetObject("btnResumen.Image"), System.Drawing.Image)
Me.btnResumen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnResumen.Location = New System.Drawing.Point(20, 141)
Me.btnResumen.Name = "btnResumen"
Me.btnResumen.Size = New System.Drawing.Size(205, 40)
Me.btnResumen.TabIndex = 9
Me.btnResumen.Text = "Resumen"
Me.btnResumen.UseVisualStyleBackColor = False
'
'btnDividirOT
'
Me.btnDividirOT.FlatAppearance.BorderSize = 0
Me.btnDividirOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnDividirOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnDividirOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnDividirOT.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnDividirOT.ForeColor = System.Drawing.Color.White
Me.btnDividirOT.Image = CType(resources.GetObject("btnDividirOT.Image"), System.Drawing.Image)
Me.btnDividirOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnDividirOT.Location = New System.Drawing.Point(20, 95)
Me.btnDividirOT.Name = "btnDividirOT"
Me.btnDividirOT.Size = New System.Drawing.Size(205, 40)
Me.btnDividirOT.TabIndex = 8
Me.btnDividirOT.Text = "Dividir OT"
Me.btnDividirOT.UseVisualStyleBackColor = True
'
'btnMateriales
'
Me.btnMateriales.FlatAppearance.BorderSize = 0
Me.btnMateriales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMateriales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMateriales.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMateriales.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMateriales.ForeColor = System.Drawing.Color.White
Me.btnMateriales.Image = CType(resources.GetObject("btnMateriales.Image"), System.Drawing.Image)
Me.btnMateriales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMateriales.Location = New System.Drawing.Point(20, 49)
Me.btnMateriales.Name = "btnMateriales"
Me.btnMateriales.Size = New System.Drawing.Size(205, 40)
Me.btnMateriales.TabIndex = 7
Me.btnMateriales.Text = "Materiales"
Me.btnMateriales.UseVisualStyleBackColor = True
'
'btnRegistroOT
'
Me.btnRegistroOT.FlatAppearance.BorderSize = 0
Me.btnRegistroOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRegistroOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRegistroOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRegistroOT.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRegistroOT.ForeColor = System.Drawing.Color.White
Me.btnRegistroOT.Image = CType(resources.GetObject("btnRegistroOT.Image"), System.Drawing.Image)
Me.btnRegistroOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRegistroOT.Location = New System.Drawing.Point(20, 3)
Me.btnRegistroOT.Name = "btnRegistroOT"
Me.btnRegistroOT.Size = New System.Drawing.Size(205, 40)
Me.btnRegistroOT.TabIndex = 6
Me.btnRegistroOT.Text = "Orden de Trabajo"
Me.btnRegistroOT.UseVisualStyleBackColor = True
'
'btnCompras
'
Me.btnCompras.FlatAppearance.BorderSize = 0
Me.btnCompras.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnCompras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnCompras.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCompras.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCompras.ForeColor = System.Drawing.Color.White
Me.btnCompras.Image = CType(resources.GetObject("btnCompras.Image"), System.Drawing.Image)
Me.btnCompras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCompras.Location = New System.Drawing.Point(3, 701)
Me.btnCompras.Name = "btnCompras"
Me.btnCompras.Size = New System.Drawing.Size(230, 40)
Me.btnCompras.TabIndex = 3
Me.btnCompras.Text = "Compras"
Me.btnCompras.UseVisualStyleBackColor = True
'
'subMenuCompras
'
Me.subMenuCompras.Controls.Add(Me.btnMtoOrdenCompra)
Me.subMenuCompras.Controls.Add(Me.btnMtoPedidos)
Me.subMenuCompras.Controls.Add(Me.btnLiberaPedidoAlmacen)
Me.subMenuCompras.Controls.Add(Me.btnIngresoOC)
Me.subMenuCompras.Controls.Add(Me.btnBorrarPedido)
Me.subMenuCompras.Controls.Add(Me.btnValidarOrdenes)
Me.subMenuCompras.Controls.Add(Me.btnPedidoManual)
Me.subMenuCompras.Controls.Add(Me.btnCriterios)
Me.subMenuCompras.Controls.Add(Me.btnOrdenCompra)
Me.subMenuCompras.Controls.Add(Me.btnActualizaPrecios)
Me.subMenuCompras.Controls.Add(Me.btnPedidos)
Me.subMenuCompras.Location = New System.Drawing.Point(3, 747)
Me.subMenuCompras.Name = "subMenuCompras"
Me.subMenuCompras.Size = New System.Drawing.Size(230, 509)
Me.subMenuCompras.TabIndex = 12
Me.subMenuCompras.Visible = False
'
'btnMtoOrdenCompra
'
Me.btnMtoOrdenCompra.FlatAppearance.BorderSize = 0
Me.btnMtoOrdenCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMtoOrdenCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMtoOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMtoOrdenCompra.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMtoOrdenCompra.ForeColor = System.Drawing.Color.White
Me.btnMtoOrdenCompra.Image = CType(resources.GetObject("btnMtoOrdenCompra.Image"), System.Drawing.Image)
Me.btnMtoOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMtoOrdenCompra.Location = New System.Drawing.Point(20, 461)
Me.btnMtoOrdenCompra.Name = "btnMtoOrdenCompra"
Me.btnMtoOrdenCompra.Size = New System.Drawing.Size(205, 40)
Me.btnMtoOrdenCompra.TabIndex = 15
Me.btnMtoOrdenCompra.Text = "Mto OC"
Me.btnMtoOrdenCompra.UseVisualStyleBackColor = True
'
'btnMtoPedidos
'
Me.btnMtoPedidos.FlatAppearance.BorderSize = 0
Me.btnMtoPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMtoPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMtoPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMtoPedidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMtoPedidos.ForeColor = System.Drawing.Color.White
Me.btnMtoPedidos.Image = CType(resources.GetObject("btnMtoPedidos.Image"), System.Drawing.Image)
Me.btnMtoPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMtoPedidos.Location = New System.Drawing.Point(20, 417)
Me.btnMtoPedidos.Name = "btnMtoPedidos"
Me.btnMtoPedidos.Size = New System.Drawing.Size(205, 40)
Me.btnMtoPedidos.TabIndex = 14
Me.btnMtoPedidos.Text = "Mto Pedidos"
Me.btnMtoPedidos.UseVisualStyleBackColor = True
'
'btnLiberaPedidoAlmacen
'
Me.btnLiberaPedidoAlmacen.FlatAppearance.BorderSize = 0
Me.btnLiberaPedidoAlmacen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnLiberaPedidoAlmacen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnLiberaPedidoAlmacen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnLiberaPedidoAlmacen.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnLiberaPedidoAlmacen.ForeColor = System.Drawing.Color.White
Me.btnLiberaPedidoAlmacen.Image = CType(resources.GetObject("btnLiberaPedidoAlmacen.Image"), System.Drawing.Image)
Me.btnLiberaPedidoAlmacen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnLiberaPedidoAlmacen.Location = New System.Drawing.Point(20, 371)
Me.btnLiberaPedidoAlmacen.Name = "btnLiberaPedidoAlmacen"
Me.btnLiberaPedidoAlmacen.Size = New System.Drawing.Size(205, 40)
Me.btnLiberaPedidoAlmacen.TabIndex = 13
Me.btnLiberaPedidoAlmacen.Text = "Liberar Pedidos"
Me.btnLiberaPedidoAlmacen.UseVisualStyleBackColor = True
'
'btnIngresoOC
'
Me.btnIngresoOC.FlatAppearance.BorderSize = 0
Me.btnIngresoOC.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnIngresoOC.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnIngresoOC.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnIngresoOC.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnIngresoOC.ForeColor = System.Drawing.Color.White
Me.btnIngresoOC.Image = CType(resources.GetObject("btnIngresoOC.Image"), System.Drawing.Image)
Me.btnIngresoOC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnIngresoOC.Location = New System.Drawing.Point(20, 325)
Me.btnIngresoOC.Name = "btnIngresoOC"
Me.btnIngresoOC.Size = New System.Drawing.Size(205, 40)
Me.btnIngresoOC.TabIndex = 12
Me.btnIngresoOC.Text = "Ingresos OC"
Me.btnIngresoOC.UseVisualStyleBackColor = True
'
'btnBorrarPedido
'
Me.btnBorrarPedido.FlatAppearance.BorderSize = 0
Me.btnBorrarPedido.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnBorrarPedido.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnBorrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnBorrarPedido.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnBorrarPedido.ForeColor = System.Drawing.Color.White
Me.btnBorrarPedido.Image = CType(resources.GetObject("btnBorrarPedido.Image"), System.Drawing.Image)
Me.btnBorrarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnBorrarPedido.Location = New System.Drawing.Point(20, 279)
Me.btnBorrarPedido.Name = "btnBorrarPedido"
Me.btnBorrarPedido.Size = New System.Drawing.Size(205, 40)
Me.btnBorrarPedido.TabIndex = 7
Me.btnBorrarPedido.Text = "Eliminar Pedidos"
Me.btnBorrarPedido.UseVisualStyleBackColor = True
'
'btnValidarOrdenes
'
Me.btnValidarOrdenes.FlatAppearance.BorderSize = 0
Me.btnValidarOrdenes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnValidarOrdenes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnValidarOrdenes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnValidarOrdenes.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnValidarOrdenes.ForeColor = System.Drawing.Color.White
Me.btnValidarOrdenes.Image = CType(resources.GetObject("btnValidarOrdenes.Image"), System.Drawing.Image)
Me.btnValidarOrdenes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnValidarOrdenes.Location = New System.Drawing.Point(20, 233)
Me.btnValidarOrdenes.Name = "btnValidarOrdenes"
Me.btnValidarOrdenes.Size = New System.Drawing.Size(205, 40)
Me.btnValidarOrdenes.TabIndex = 11
Me.btnValidarOrdenes.Text = "Validar Ordenes"
Me.btnValidarOrdenes.UseVisualStyleBackColor = True
'
'btnPedidoManual
'
Me.btnPedidoManual.FlatAppearance.BorderSize = 0
Me.btnPedidoManual.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnPedidoManual.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnPedidoManual.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnPedidoManual.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnPedidoManual.ForeColor = System.Drawing.Color.White
Me.btnPedidoManual.Image = CType(resources.GetObject("btnPedidoManual.Image"), System.Drawing.Image)
Me.btnPedidoManual.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnPedidoManual.Location = New System.Drawing.Point(20, 187)
Me.btnPedidoManual.Name = "btnPedidoManual"
Me.btnPedidoManual.Size = New System.Drawing.Size(205, 40)
Me.btnPedidoManual.TabIndex = 10
Me.btnPedidoManual.Text = "Pedido Manual"
Me.btnPedidoManual.UseVisualStyleBackColor = True
'
'btnCriterios
'
Me.btnCriterios.FlatAppearance.BorderSize = 0
Me.btnCriterios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnCriterios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnCriterios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCriterios.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCriterios.ForeColor = System.Drawing.Color.White
Me.btnCriterios.Image = CType(resources.GetObject("btnCriterios.Image"), System.Drawing.Image)
Me.btnCriterios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCriterios.Location = New System.Drawing.Point(20, 95)
Me.btnCriterios.Name = "btnCriterios"
Me.btnCriterios.Size = New System.Drawing.Size(205, 40)
Me.btnCriterios.TabIndex = 9
Me.btnCriterios.Text = "Criterios"
Me.btnCriterios.UseVisualStyleBackColor = True
'
'btnOrdenCompra
'
Me.btnOrdenCompra.FlatAppearance.BorderSize = 0
Me.btnOrdenCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnOrdenCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnOrdenCompra.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnOrdenCompra.ForeColor = System.Drawing.Color.White
Me.btnOrdenCompra.Image = CType(resources.GetObject("btnOrdenCompra.Image"), System.Drawing.Image)
Me.btnOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnOrdenCompra.Location = New System.Drawing.Point(20, 141)
Me.btnOrdenCompra.Name = "btnOrdenCompra"
Me.btnOrdenCompra.Size = New System.Drawing.Size(205, 40)
Me.btnOrdenCompra.TabIndex = 8
Me.btnOrdenCompra.Text = "Orden de Compra"
Me.btnOrdenCompra.UseVisualStyleBackColor = True
'
'btnActualizaPrecios
'
Me.btnActualizaPrecios.FlatAppearance.BorderSize = 0
Me.btnActualizaPrecios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnActualizaPrecios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnActualizaPrecios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnActualizaPrecios.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnActualizaPrecios.ForeColor = System.Drawing.Color.White
Me.btnActualizaPrecios.Image = CType(resources.GetObject("btnActualizaPrecios.Image"), System.Drawing.Image)
Me.btnActualizaPrecios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnActualizaPrecios.Location = New System.Drawing.Point(20, 49)
Me.btnActualizaPrecios.Name = "btnActualizaPrecios"
Me.btnActualizaPrecios.Size = New System.Drawing.Size(205, 40)
Me.btnActualizaPrecios.TabIndex = 7
Me.btnActualizaPrecios.Text = "Actualizar Precios"
Me.btnActualizaPrecios.UseVisualStyleBackColor = True
'
'btnPedidos
'
Me.btnPedidos.FlatAppearance.BorderSize = 0
Me.btnPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnPedidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnPedidos.ForeColor = System.Drawing.Color.White
Me.btnPedidos.Image = CType(resources.GetObject("btnPedidos.Image"), System.Drawing.Image)
Me.btnPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnPedidos.Location = New System.Drawing.Point(20, 3)
Me.btnPedidos.Name = "btnPedidos"
Me.btnPedidos.Size = New System.Drawing.Size(205, 40)
Me.btnPedidos.TabIndex = 6
Me.btnPedidos.Text = "Pedidos"
Me.btnPedidos.UseVisualStyleBackColor = True
'
'btnInventarios
'
Me.btnInventarios.FlatAppearance.BorderSize = 0
Me.btnInventarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnInventarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnInventarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnInventarios.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnInventarios.ForeColor = System.Drawing.Color.White
Me.btnInventarios.Image = CType(resources.GetObject("btnInventarios.Image"), System.Drawing.Image)
Me.btnInventarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnInventarios.Location = New System.Drawing.Point(3, 1262)
Me.btnInventarios.Name = "btnInventarios"
Me.btnInventarios.Size = New System.Drawing.Size(230, 40)
Me.btnInventarios.TabIndex = 4
Me.btnInventarios.Text = "Inventario"
Me.btnInventarios.UseVisualStyleBackColor = True
'
'subMenuInventario
'
Me.subMenuInventario.Controls.Add(Me.btnGeneraReporteInventario)
Me.subMenuInventario.Controls.Add(Me.btnRegistroMov)
Me.subMenuInventario.Location = New System.Drawing.Point(3, 1308)
Me.subMenuInventario.Name = "subMenuInventario"
Me.subMenuInventario.Size = New System.Drawing.Size(230, 95)
Me.subMenuInventario.TabIndex = 12
Me.subMenuInventario.Visible = False
'
'btnGeneraReporteInventario
'
Me.btnGeneraReporteInventario.FlatAppearance.BorderSize = 0
Me.btnGeneraReporteInventario.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnGeneraReporteInventario.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnGeneraReporteInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnGeneraReporteInventario.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnGeneraReporteInventario.ForeColor = System.Drawing.Color.White
Me.btnGeneraReporteInventario.Image = CType(resources.GetObject("btnGeneraReporteInventario.Image"), System.Drawing.Image)
Me.btnGeneraReporteInventario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnGeneraReporteInventario.Location = New System.Drawing.Point(20, 49)
Me.btnGeneraReporteInventario.Name = "btnGeneraReporteInventario"
Me.btnGeneraReporteInventario.Size = New System.Drawing.Size(205, 40)
Me.btnGeneraReporteInventario.TabIndex = 7
Me.btnGeneraReporteInventario.Text = "Reporte Inventario"
Me.btnGeneraReporteInventario.UseVisualStyleBackColor = True
'
'btnRegistroMov
'
Me.btnRegistroMov.FlatAppearance.BorderSize = 0
Me.btnRegistroMov.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRegistroMov.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRegistroMov.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRegistroMov.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRegistroMov.ForeColor = System.Drawing.Color.White
Me.btnRegistroMov.Image = CType(resources.GetObject("btnRegistroMov.Image"), System.Drawing.Image)
Me.btnRegistroMov.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRegistroMov.Location = New System.Drawing.Point(20, 3)
Me.btnRegistroMov.Name = "btnRegistroMov"
Me.btnRegistroMov.Size = New System.Drawing.Size(205, 40)
Me.btnRegistroMov.TabIndex = 6
Me.btnRegistroMov.Text = "Movimientos"
Me.btnRegistroMov.UseVisualStyleBackColor = True
'
'btnReportes
'
Me.btnReportes.FlatAppearance.BorderSize = 0
Me.btnReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnReportes.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnReportes.ForeColor = System.Drawing.Color.White
Me.btnReportes.Image = CType(resources.GetObject("btnReportes.Image"), System.Drawing.Image)
Me.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnReportes.Location = New System.Drawing.Point(3, 1409)
Me.btnReportes.Name = "btnReportes"
Me.btnReportes.Size = New System.Drawing.Size(230, 40)
Me.btnReportes.TabIndex = 5
Me.btnReportes.Text = "Reportes"
Me.btnReportes.UseVisualStyleBackColor = True
'
'submenuReportes
'
Me.submenuReportes.Controls.Add(Me.btnRptNotificar)
Me.submenuReportes.Controls.Add(Me.btnRptSubTareasGeneral)
Me.submenuReportes.Controls.Add(Me.btnRptSubTareas)
Me.submenuReportes.Controls.Add(Me.btnRptPedidos)
Me.submenuReportes.Controls.Add(Me.btnRptCotAGerencia)
Me.submenuReportes.Controls.Add(Me.btnRptOT)
Me.submenuReportes.Controls.Add(Me.btnRptCotizaciones)
Me.submenuReportes.Location = New System.Drawing.Point(3, 1455)
Me.submenuReportes.Name = "submenuReportes"
Me.submenuReportes.Size = New System.Drawing.Size(230, 327)
Me.submenuReportes.TabIndex = 6
Me.submenuReportes.Visible = False
'
'btnRptNotificar
'
Me.btnRptNotificar.FlatAppearance.BorderSize = 0
Me.btnRptNotificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptNotificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptNotificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptNotificar.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptNotificar.ForeColor = System.Drawing.Color.White
Me.btnRptNotificar.Image = CType(resources.GetObject("btnRptNotificar.Image"), System.Drawing.Image)
Me.btnRptNotificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptNotificar.Location = New System.Drawing.Point(20, 280)
Me.btnRptNotificar.Name = "btnRptNotificar"
Me.btnRptNotificar.Size = New System.Drawing.Size(203, 40)
Me.btnRptNotificar.TabIndex = 12
Me.btnRptNotificar.Text = "Notificación"
Me.btnRptNotificar.UseVisualStyleBackColor = True
'
'btnRptSubTareasGeneral
'
Me.btnRptSubTareasGeneral.FlatAppearance.BorderSize = 0
Me.btnRptSubTareasGeneral.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptSubTareasGeneral.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptSubTareasGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptSubTareasGeneral.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptSubTareasGeneral.ForeColor = System.Drawing.Color.White
Me.btnRptSubTareasGeneral.Image = CType(resources.GetObject("btnRptSubTareasGeneral.Image"), System.Drawing.Image)
Me.btnRptSubTareasGeneral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptSubTareasGeneral.Location = New System.Drawing.Point(19, 233)
Me.btnRptSubTareasGeneral.Name = "btnRptSubTareasGeneral"
Me.btnRptSubTareasGeneral.Size = New System.Drawing.Size(205, 40)
Me.btnRptSubTareasGeneral.TabIndex = 11
Me.btnRptSubTareasGeneral.Text = "Sub tareas General"
Me.btnRptSubTareasGeneral.UseVisualStyleBackColor = True
'
'btnRptSubTareas
'
Me.btnRptSubTareas.FlatAppearance.BorderSize = 0
Me.btnRptSubTareas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptSubTareas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptSubTareas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptSubTareas.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptSubTareas.ForeColor = System.Drawing.Color.White
Me.btnRptSubTareas.Image = CType(resources.GetObject("btnRptSubTareas.Image"), System.Drawing.Image)
Me.btnRptSubTareas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptSubTareas.Location = New System.Drawing.Point(19, 187)
Me.btnRptSubTareas.Name = "btnRptSubTareas"
Me.btnRptSubTareas.Size = New System.Drawing.Size(205, 40)
Me.btnRptSubTareas.TabIndex = 10
Me.btnRptSubTareas.Text = "Sub tareas"
Me.btnRptSubTareas.UseVisualStyleBackColor = True
'
'btnRptPedidos
'
Me.btnRptPedidos.FlatAppearance.BorderSize = 0
Me.btnRptPedidos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptPedidos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptPedidos.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptPedidos.ForeColor = System.Drawing.Color.White
Me.btnRptPedidos.Image = CType(resources.GetObject("btnRptPedidos.Image"), System.Drawing.Image)
Me.btnRptPedidos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptPedidos.Location = New System.Drawing.Point(20, 141)
Me.btnRptPedidos.Name = "btnRptPedidos"
Me.btnRptPedidos.Size = New System.Drawing.Size(205, 40)
Me.btnRptPedidos.TabIndex = 9
Me.btnRptPedidos.Text = "Pedidos EG"
Me.btnRptPedidos.UseVisualStyleBackColor = True
'
'btnRptCotAGerencia
'
Me.btnRptCotAGerencia.FlatAppearance.BorderSize = 0
Me.btnRptCotAGerencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptCotAGerencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptCotAGerencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptCotAGerencia.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptCotAGerencia.ForeColor = System.Drawing.Color.White
Me.btnRptCotAGerencia.Image = CType(resources.GetObject("btnRptCotAGerencia.Image"), System.Drawing.Image)
Me.btnRptCotAGerencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptCotAGerencia.Location = New System.Drawing.Point(20, 95)
Me.btnRptCotAGerencia.Name = "btnRptCotAGerencia"
Me.btnRptCotAGerencia.Size = New System.Drawing.Size(205, 40)
Me.btnRptCotAGerencia.TabIndex = 8
Me.btnRptCotAGerencia.Text = "Cot.  Gerencia"
Me.btnRptCotAGerencia.UseVisualStyleBackColor = True
'
'btnRptOT
'
Me.btnRptOT.FlatAppearance.BorderSize = 0
Me.btnRptOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptOT.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptOT.ForeColor = System.Drawing.Color.White
Me.btnRptOT.Image = CType(resources.GetObject("btnRptOT.Image"), System.Drawing.Image)
Me.btnRptOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptOT.Location = New System.Drawing.Point(20, 49)
Me.btnRptOT.Name = "btnRptOT"
Me.btnRptOT.Size = New System.Drawing.Size(205, 40)
Me.btnRptOT.TabIndex = 7
Me.btnRptOT.Text = "Ordenes de Trabajo"
Me.btnRptOT.UseVisualStyleBackColor = True
'
'btnRptCotizaciones
'
Me.btnRptCotizaciones.FlatAppearance.BorderSize = 0
Me.btnRptCotizaciones.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnRptCotizaciones.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnRptCotizaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnRptCotizaciones.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnRptCotizaciones.ForeColor = System.Drawing.Color.White
Me.btnRptCotizaciones.Image = CType(resources.GetObject("btnRptCotizaciones.Image"), System.Drawing.Image)
Me.btnRptCotizaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnRptCotizaciones.Location = New System.Drawing.Point(20, 3)
Me.btnRptCotizaciones.Name = "btnRptCotizaciones"
Me.btnRptCotizaciones.Size = New System.Drawing.Size(205, 40)
Me.btnRptCotizaciones.TabIndex = 6
Me.btnRptCotizaciones.Text = "Cotizaciones"
Me.btnRptCotizaciones.UseVisualStyleBackColor = True
'
'btnMto
'
Me.btnMto.FlatAppearance.BorderSize = 0
Me.btnMto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMto.Font = New System.Drawing.Font("Century Gothic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMto.ForeColor = System.Drawing.Color.White
Me.btnMto.Image = CType(resources.GetObject("btnMto.Image"), System.Drawing.Image)
Me.btnMto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMto.Location = New System.Drawing.Point(3, 1788)
Me.btnMto.Name = "btnMto"
Me.btnMto.Size = New System.Drawing.Size(230, 40)
Me.btnMto.TabIndex = 11
Me.btnMto.Text = "Mantenimiento"
Me.btnMto.UseVisualStyleBackColor = True
'
'subMenuMto
'
Me.subMenuMto.Controls.Add(Me.BtnOperarios)
Me.subMenuMto.Controls.Add(Me.btnReversaEstadosOT)
Me.subMenuMto.Controls.Add(Me.btnResponsables)
Me.subMenuMto.Controls.Add(Me.btnMntoMO)
Me.subMenuMto.Controls.Add(Me.btnCambiaEstadoCotizacion)
Me.subMenuMto.Controls.Add(Me.btnParametros)
Me.subMenuMto.Controls.Add(Me.btnMPNoCreada)
Me.subMenuMto.Location = New System.Drawing.Point(3, 1834)
Me.subMenuMto.Name = "subMenuMto"
Me.subMenuMto.Size = New System.Drawing.Size(230, 317)
Me.subMenuMto.TabIndex = 11
Me.subMenuMto.Visible = False
'
'BtnOperarios
'
Me.BtnOperarios.FlatAppearance.BorderSize = 0
Me.BtnOperarios.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.BtnOperarios.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.BtnOperarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.BtnOperarios.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.BtnOperarios.ForeColor = System.Drawing.Color.White
Me.BtnOperarios.Image = CType(resources.GetObject("BtnOperarios.Image"), System.Drawing.Image)
Me.BtnOperarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.BtnOperarios.Location = New System.Drawing.Point(20, 279)
Me.BtnOperarios.Name = "BtnOperarios"
Me.BtnOperarios.Size = New System.Drawing.Size(205, 40)
Me.BtnOperarios.TabIndex = 13
Me.BtnOperarios.Text = "Operarios"
Me.BtnOperarios.UseVisualStyleBackColor = True
'
'btnReversaEstadosOT
'
Me.btnReversaEstadosOT.FlatAppearance.BorderSize = 0
Me.btnReversaEstadosOT.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnReversaEstadosOT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnReversaEstadosOT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnReversaEstadosOT.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnReversaEstadosOT.ForeColor = System.Drawing.Color.White
Me.btnReversaEstadosOT.Image = CType(resources.GetObject("btnReversaEstadosOT.Image"), System.Drawing.Image)
Me.btnReversaEstadosOT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnReversaEstadosOT.Location = New System.Drawing.Point(20, 233)
Me.btnReversaEstadosOT.Name = "btnReversaEstadosOT"
Me.btnReversaEstadosOT.Size = New System.Drawing.Size(205, 40)
Me.btnReversaEstadosOT.TabIndex = 12
Me.btnReversaEstadosOT.Text = "Estado OTx"
Me.btnReversaEstadosOT.UseVisualStyleBackColor = True
'
'btnResponsables
'
Me.btnResponsables.FlatAppearance.BorderSize = 0
Me.btnResponsables.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnResponsables.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnResponsables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnResponsables.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnResponsables.ForeColor = System.Drawing.Color.White
Me.btnResponsables.Image = CType(resources.GetObject("btnResponsables.Image"), System.Drawing.Image)
Me.btnResponsables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnResponsables.Location = New System.Drawing.Point(20, 187)
Me.btnResponsables.Name = "btnResponsables"
Me.btnResponsables.Size = New System.Drawing.Size(205, 40)
Me.btnResponsables.TabIndex = 11
Me.btnResponsables.Text = "Responsables"
Me.btnResponsables.UseVisualStyleBackColor = True
'
'btnMntoMO
'
Me.btnMntoMO.FlatAppearance.BorderSize = 0
Me.btnMntoMO.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMntoMO.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMntoMO.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMntoMO.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMntoMO.ForeColor = System.Drawing.Color.White
Me.btnMntoMO.Image = CType(resources.GetObject("btnMntoMO.Image"), System.Drawing.Image)
Me.btnMntoMO.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMntoMO.Location = New System.Drawing.Point(20, 141)
Me.btnMntoMO.Name = "btnMntoMO"
Me.btnMntoMO.Size = New System.Drawing.Size(205, 40)
Me.btnMntoMO.TabIndex = 10
Me.btnMntoMO.Text = "Mano de Obra"
Me.btnMntoMO.UseVisualStyleBackColor = True
'
'btnCambiaEstadoCotizacion
'
Me.btnCambiaEstadoCotizacion.FlatAppearance.BorderSize = 0
Me.btnCambiaEstadoCotizacion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnCambiaEstadoCotizacion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnCambiaEstadoCotizacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnCambiaEstadoCotizacion.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCambiaEstadoCotizacion.ForeColor = System.Drawing.Color.White
Me.btnCambiaEstadoCotizacion.Image = CType(resources.GetObject("btnCambiaEstadoCotizacion.Image"), System.Drawing.Image)
Me.btnCambiaEstadoCotizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnCambiaEstadoCotizacion.Location = New System.Drawing.Point(20, 95)
Me.btnCambiaEstadoCotizacion.Name = "btnCambiaEstadoCotizacion"
Me.btnCambiaEstadoCotizacion.Size = New System.Drawing.Size(205, 40)
Me.btnCambiaEstadoCotizacion.TabIndex = 9
Me.btnCambiaEstadoCotizacion.Text = "Estado cotización"
Me.btnCambiaEstadoCotizacion.UseVisualStyleBackColor = True
'
'btnParametros
'
Me.btnParametros.FlatAppearance.BorderSize = 0
Me.btnParametros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnParametros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnParametros.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnParametros.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnParametros.ForeColor = System.Drawing.Color.White
Me.btnParametros.Image = CType(resources.GetObject("btnParametros.Image"), System.Drawing.Image)
Me.btnParametros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnParametros.Location = New System.Drawing.Point(20, 49)
Me.btnParametros.Name = "btnParametros"
Me.btnParametros.Size = New System.Drawing.Size(205, 40)
Me.btnParametros.TabIndex = 7
Me.btnParametros.Text = "Parámetros"
Me.btnParametros.UseVisualStyleBackColor = True
'
'btnMPNoCreada
'
Me.btnMPNoCreada.FlatAppearance.BorderSize = 0
Me.btnMPNoCreada.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray
Me.btnMPNoCreada.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray
Me.btnMPNoCreada.FlatStyle = System.Windows.Forms.FlatStyle.Flat
Me.btnMPNoCreada.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnMPNoCreada.ForeColor = System.Drawing.Color.White
Me.btnMPNoCreada.Image = CType(resources.GetObject("btnMPNoCreada.Image"), System.Drawing.Image)
Me.btnMPNoCreada.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
Me.btnMPNoCreada.Location = New System.Drawing.Point(20, 3)
Me.btnMPNoCreada.Name = "btnMPNoCreada"
Me.btnMPNoCreada.Size = New System.Drawing.Size(205, 40)
Me.btnMPNoCreada.TabIndex = 6
Me.btnMPNoCreada.Text = "MP No Creada"
Me.btnMPNoCreada.UseVisualStyleBackColor = True
'
'imgLogo
'
Me.imgLogo.Cursor = System.Windows.Forms.Cursors.SizeAll
Me.imgLogo.Image = Global.ModProd.My.Resources.Resources.OnyxBlanco
Me.imgLogo.Location = New System.Drawing.Point(3, 3)
Me.imgLogo.Name = "imgLogo"
Me.imgLogo.Size = New System.Drawing.Size(125, 44)
Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
Me.imgLogo.TabIndex = 0
Me.imgLogo.TabStop = False
'
'frmMenuWin10
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(277, 718)
Me.Controls.Add(Me.mnuVertical)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Name = "frmMenuWin10"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "ONYX"
Me.mnuVertical.ResumeLayout(False)
Me.mnuVertical.PerformLayout()
CType(Me.icoMinimizar, System.ComponentModel.ISupportInitialize).EndInit()
Me.barraTitulo.ResumeLayout(False)
Me.stbEstado.ResumeLayout(False)
Me.stbEstado.PerformLayout()
Me.flpMenu.ResumeLayout(False)
Me.submenuComercial.ResumeLayout(False)
Me.submenuProduccion.ResumeLayout(False)
Me.subMenuCompras.ResumeLayout(False)
Me.subMenuInventario.ResumeLayout(False)
Me.submenuReportes.ResumeLayout(False)
Me.subMenuMto.ResumeLayout(False)
CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
  Friend WithEvents mnuVertical As System.Windows.Forms.Panel
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents btnComercial As System.Windows.Forms.Button
  Friend WithEvents btnReportes As System.Windows.Forms.Button
  Friend WithEvents btnInventarios As System.Windows.Forms.Button
  Friend WithEvents btnCompras As System.Windows.Forms.Button
  Friend WithEvents btnProduccion As System.Windows.Forms.Button
  Friend WithEvents submenuReportes As System.Windows.Forms.Panel
  Friend WithEvents btnRptCotizaciones As System.Windows.Forms.Button
  Friend WithEvents btnRptOT As System.Windows.Forms.Button
  Friend WithEvents submenuComercial As System.Windows.Forms.Panel
  Friend WithEvents btnContratos As System.Windows.Forms.Button
  Friend WithEvents btnCotizar As System.Windows.Forms.Button
  Friend WithEvents submenuProduccion As System.Windows.Forms.Panel
  Friend WithEvents btnDividirOT As System.Windows.Forms.Button
  Friend WithEvents btnMateriales As System.Windows.Forms.Button
  Friend WithEvents btnRegistroOT As System.Windows.Forms.Button
  Friend WithEvents flpMenu As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents subMenuCompras As System.Windows.Forms.Panel
  Friend WithEvents btnOrdenCompra As System.Windows.Forms.Button
  Friend WithEvents btnActualizaPrecios As System.Windows.Forms.Button
  Friend WithEvents btnPedidos As System.Windows.Forms.Button
  Friend WithEvents subMenuInventario As System.Windows.Forms.Panel
  Friend WithEvents btnGeneraReporteInventario As System.Windows.Forms.Button
  Friend WithEvents btnRegistroMov As System.Windows.Forms.Button
  Friend WithEvents stbEstado As System.Windows.Forms.StatusStrip
  Friend WithEvents stDominio As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents stUsuario As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents stVersion As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents btnCriterios As System.Windows.Forms.Button
  Friend WithEvents btnPedidoManual As System.Windows.Forms.Button
  Friend WithEvents btnMto As System.Windows.Forms.Button
  Friend WithEvents subMenuMto As System.Windows.Forms.Panel
  Friend WithEvents btnParametros As System.Windows.Forms.Button
  Friend WithEvents btnMPNoCreada As System.Windows.Forms.Button
  Friend WithEvents btnValidarOrdenes As System.Windows.Forms.Button
  Friend WithEvents btnRptCotAGerencia As System.Windows.Forms.Button
  Friend WithEvents btnCambiaEstadoCotizacion As System.Windows.Forms.Button
  Friend WithEvents barraTitulo As System.Windows.Forms.Panel
  Friend WithEvents flpVentanas As System.Windows.Forms.FlowLayoutPanel
  Friend WithEvents btnBotonera As System.Windows.Forms.Button
  Friend WithEvents btnApagar As System.Windows.Forms.Button
  Friend WithEvents icoMinimizar As System.Windows.Forms.PictureBox
  Friend WithEvents btnBorrarPedido As System.Windows.Forms.Button
  Friend WithEvents btnRptPedidos As System.Windows.Forms.Button
  Friend WithEvents btnMntoMO As System.Windows.Forms.Button
  Friend WithEvents btnIngresoOC As System.Windows.Forms.Button
  Friend WithEvents btnResumen As System.Windows.Forms.Button
  Friend WithEvents btnRemision As System.Windows.Forms.Button
  Friend WithEvents btnResponsables As System.Windows.Forms.Button
  Friend WithEvents btnReversaEstadosOT As System.Windows.Forms.Button
  Friend WithEvents btnControlImpresion As System.Windows.Forms.Button
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents btnValidarOT As System.Windows.Forms.Button
  Friend WithEvents btnConResumen As System.Windows.Forms.Button
  Friend WithEvents btnValidacionRes As System.Windows.Forms.Button
  Friend WithEvents btnLiberaPedidoAlmacen As System.Windows.Forms.Button
  Friend WithEvents BtnOperarios As System.Windows.Forms.Button
  Friend WithEvents stAmbiente As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents lblAmbiente As System.Windows.Forms.Label
  Friend WithEvents btnMtoPedidos As System.Windows.Forms.Button
  Friend WithEvents btnMtoOrdenCompra As System.Windows.Forms.Button
  Friend WithEvents BtnProgramador As System.Windows.Forms.Button
  Friend WithEvents btnRptSubTareas As System.Windows.Forms.Button
  Friend WithEvents btnRptSubTareasGeneral As System.Windows.Forms.Button
  Friend WithEvents btnGastosMontaje As System.Windows.Forms.Button
  Friend WithEvents btnRptNotificar As System.Windows.Forms.Button
End Class
