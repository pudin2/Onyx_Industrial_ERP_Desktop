<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMenu
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMenu))
    Me.cmdCrearOrden = New System.Windows.Forms.Button()
    Me.btnAsignarAlArea = New System.Windows.Forms.Button()
    Me.btnEntregarResumen = New System.Windows.Forms.Button()
    Me.btnCerrarOrden = New System.Windows.Forms.Button()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.tbpComercial = New System.Windows.Forms.TabPage()
    Me.btnContratos = New System.Windows.Forms.Button()
    Me.btnCambiaEstadoCot = New System.Windows.Forms.Button()
    Me.btnSimulador = New System.Windows.Forms.Button()
    Me.tbpProduccion = New System.Windows.Forms.TabPage()
    Me.btnAjustarMaterialesOT = New System.Windows.Forms.Button()
    Me.Button3 = New System.Windows.Forms.Button()
    Me.btnOrdenCompra = New System.Windows.Forms.Button()
    Me.btnPedirMaterialesOT = New System.Windows.Forms.Button()
    Me.Button2 = New System.Windows.Forms.Button()
    Me.btnCrearPT = New System.Windows.Forms.Button()
    Me.btnAgregarMP = New System.Windows.Forms.Button()
    Me.tbpReportes = New System.Windows.Forms.TabPage()
    Me.btnRptCotAGerencia = New System.Windows.Forms.Button()
    Me.btnBoletas = New System.Windows.Forms.Button()
    Me.btnRptCostosMP = New System.Windows.Forms.Button()
    Me.btnCotizaciones = New System.Windows.Forms.Button()
    Me.cmdEntregasArea = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.tbpMto = New System.Windows.Forms.TabPage()
    Me.btnResponsables = New System.Windows.Forms.Button()
    Me.cmdMpYaCreada = New System.Windows.Forms.Button()
    Me.btnMntCostos = New System.Windows.Forms.Button()
    Me.btnMntoMO = New System.Windows.Forms.Button()
    Me.btnBuscar = New System.Windows.Forms.Button()
    Me.stbEstado = New System.Windows.Forms.StatusStrip()
    Me.stDominio = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stUsuario = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stVersion = New System.Windows.Forms.ToolStripStatusLabel()
    Me.PictureBox1 = New System.Windows.Forms.PictureBox()
    Me.imgLogo = New System.Windows.Forms.PictureBox()
    Me.TabControl1.SuspendLayout()
    Me.tbpComercial.SuspendLayout()
    Me.tbpProduccion.SuspendLayout()
    Me.tbpReportes.SuspendLayout()
    Me.tbpMto.SuspendLayout()
    Me.stbEstado.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdCrearOrden
    '
    Me.cmdCrearOrden.Location = New System.Drawing.Point(12, 6)
    Me.cmdCrearOrden.Name = "cmdCrearOrden"
    Me.cmdCrearOrden.Size = New System.Drawing.Size(150, 25)
    Me.cmdCrearOrden.TabIndex = 0
    Me.cmdCrearOrden.Text = "1. Crear Orden"
    Me.cmdCrearOrden.UseVisualStyleBackColor = True
    '
    'btnAsignarAlArea
    '
    Me.btnAsignarAlArea.Location = New System.Drawing.Point(12, 61)
    Me.btnAsignarAlArea.Name = "btnAsignarAlArea"
    Me.btnAsignarAlArea.Size = New System.Drawing.Size(150, 25)
    Me.btnAsignarAlArea.TabIndex = 1
    Me.btnAsignarAlArea.Text = "Asignar al Area"
    Me.btnAsignarAlArea.UseVisualStyleBackColor = True
    Me.btnAsignarAlArea.Visible = False
    '
    'btnEntregarResumen
    '
    Me.btnEntregarResumen.Location = New System.Drawing.Point(12, 89)
    Me.btnEntregarResumen.Name = "btnEntregarResumen"
    Me.btnEntregarResumen.Size = New System.Drawing.Size(150, 25)
    Me.btnEntregarResumen.TabIndex = 3
    Me.btnEntregarResumen.Text = "Entregar Resumen"
    Me.btnEntregarResumen.UseVisualStyleBackColor = True
    Me.btnEntregarResumen.Visible = False
    '
    'btnCerrarOrden
    '
    Me.btnCerrarOrden.Location = New System.Drawing.Point(12, 117)
    Me.btnCerrarOrden.Name = "btnCerrarOrden"
    Me.btnCerrarOrden.Size = New System.Drawing.Size(150, 25)
    Me.btnCerrarOrden.TabIndex = 4
    Me.btnCerrarOrden.Text = "Cerrar Orden"
    Me.btnCerrarOrden.UseVisualStyleBackColor = True
    Me.btnCerrarOrden.Visible = False
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.tbpComercial)
    Me.TabControl1.Controls.Add(Me.tbpProduccion)
    Me.TabControl1.Controls.Add(Me.tbpReportes)
    Me.TabControl1.Controls.Add(Me.tbpMto)
    Me.TabControl1.Location = New System.Drawing.Point(12, 115)
    Me.TabControl1.Multiline = True
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(338, 228)
    Me.TabControl1.TabIndex = 5
    '
    'tbpComercial
    '
    Me.tbpComercial.BackColor = System.Drawing.SystemColors.Control
    Me.tbpComercial.Controls.Add(Me.btnContratos)
    Me.tbpComercial.Controls.Add(Me.btnCambiaEstadoCot)
    Me.tbpComercial.Controls.Add(Me.btnSimulador)
    Me.tbpComercial.Location = New System.Drawing.Point(4, 22)
    Me.tbpComercial.Name = "tbpComercial"
    Me.tbpComercial.Padding = New System.Windows.Forms.Padding(3)
    Me.tbpComercial.Size = New System.Drawing.Size(330, 202)
    Me.tbpComercial.TabIndex = 2
    Me.tbpComercial.Text = "TabPage3"
    '
    'btnContratos
    '
    Me.btnContratos.Location = New System.Drawing.Point(77, 81)
    Me.btnContratos.Name = "btnContratos"
    Me.btnContratos.Size = New System.Drawing.Size(172, 25)
    Me.btnContratos.TabIndex = 2
    Me.btnContratos.Text = "Cto"
    Me.btnContratos.UseVisualStyleBackColor = True
    '
    'btnCambiaEstadoCot
    '
    Me.btnCambiaEstadoCot.Location = New System.Drawing.Point(77, 112)
    Me.btnCambiaEstadoCot.Name = "btnCambiaEstadoCot"
    Me.btnCambiaEstadoCot.Size = New System.Drawing.Size(172, 25)
    Me.btnCambiaEstadoCot.TabIndex = 1
    Me.btnCambiaEstadoCot.Text = "Cmb Estado Cot"
    Me.btnCambiaEstadoCot.UseVisualStyleBackColor = True
    Me.btnCambiaEstadoCot.Visible = False
    '
    'btnSimulador
    '
    Me.btnSimulador.Location = New System.Drawing.Point(77, 50)
    Me.btnSimulador.Name = "btnSimulador"
    Me.btnSimulador.Size = New System.Drawing.Size(172, 25)
    Me.btnSimulador.TabIndex = 0
    Me.btnSimulador.Text = "Cot"
    Me.btnSimulador.UseVisualStyleBackColor = True
    '
    'tbpProduccion
    '
    Me.tbpProduccion.BackColor = System.Drawing.SystemColors.Control
    Me.tbpProduccion.Controls.Add(Me.btnAjustarMaterialesOT)
    Me.tbpProduccion.Controls.Add(Me.Button3)
    Me.tbpProduccion.Controls.Add(Me.btnOrdenCompra)
    Me.tbpProduccion.Controls.Add(Me.btnPedirMaterialesOT)
    Me.tbpProduccion.Controls.Add(Me.Button2)
    Me.tbpProduccion.Controls.Add(Me.btnCrearPT)
    Me.tbpProduccion.Controls.Add(Me.btnAgregarMP)
    Me.tbpProduccion.Controls.Add(Me.cmdCrearOrden)
    Me.tbpProduccion.Controls.Add(Me.btnCerrarOrden)
    Me.tbpProduccion.Controls.Add(Me.btnAsignarAlArea)
    Me.tbpProduccion.Controls.Add(Me.btnEntregarResumen)
    Me.tbpProduccion.Location = New System.Drawing.Point(4, 22)
    Me.tbpProduccion.Name = "tbpProduccion"
    Me.tbpProduccion.Padding = New System.Windows.Forms.Padding(3)
    Me.tbpProduccion.Size = New System.Drawing.Size(330, 202)
    Me.tbpProduccion.TabIndex = 0
    Me.tbpProduccion.Text = "Transacciones"
    '
    'btnAjustarMaterialesOT
    '
    Me.btnAjustarMaterialesOT.Location = New System.Drawing.Point(177, 145)
    Me.btnAjustarMaterialesOT.Name = "btnAjustarMaterialesOT"
    Me.btnAjustarMaterialesOT.Size = New System.Drawing.Size(150, 25)
    Me.btnAjustarMaterialesOT.TabIndex = 73
    Me.btnAjustarMaterialesOT.Text = "NO VA Ajustar Materiales"
    Me.btnAjustarMaterialesOT.UseVisualStyleBackColor = True
    Me.btnAjustarMaterialesOT.Visible = False
    '
    'Button3
    '
    Me.Button3.Location = New System.Drawing.Point(168, 34)
    Me.Button3.Name = "Button3"
    Me.Button3.Size = New System.Drawing.Size(150, 25)
    Me.Button3.TabIndex = 72
    Me.Button3.Text = "Beta Nuevo Menu"
    Me.Button3.UseVisualStyleBackColor = True
    Me.Button3.Visible = False
    '
    'btnOrdenCompra
    '
    Me.btnOrdenCompra.Location = New System.Drawing.Point(168, 6)
    Me.btnOrdenCompra.Name = "btnOrdenCompra"
    Me.btnOrdenCompra.Size = New System.Drawing.Size(150, 25)
    Me.btnOrdenCompra.TabIndex = 71
    Me.btnOrdenCompra.Text = "Orden de Compra"
    Me.btnOrdenCompra.UseVisualStyleBackColor = True
    '
    'btnPedirMaterialesOT
    '
    Me.btnPedirMaterialesOT.Location = New System.Drawing.Point(12, 33)
    Me.btnPedirMaterialesOT.Name = "btnPedirMaterialesOT"
    Me.btnPedirMaterialesOT.Size = New System.Drawing.Size(150, 25)
    Me.btnPedirMaterialesOT.TabIndex = 70
    Me.btnPedirMaterialesOT.Text = "Ajustar Materiales OT"
    Me.btnPedirMaterialesOT.UseVisualStyleBackColor = True
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(224, 172)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(100, 24)
    Me.Button2.TabIndex = 69
    Me.Button2.Text = "Beta Cot Rapida"
    Me.Button2.UseVisualStyleBackColor = True
    Me.Button2.Visible = False
    '
    'btnCrearPT
    '
    Me.btnCrearPT.Location = New System.Drawing.Point(168, 62)
    Me.btnCrearPT.Name = "btnCrearPT"
    Me.btnCrearPT.Size = New System.Drawing.Size(150, 25)
    Me.btnCrearPT.TabIndex = 68
    Me.btnCrearPT.Text = "Crear Producto PT"
    Me.btnCrearPT.UseVisualStyleBackColor = True
    Me.btnCrearPT.Visible = False
    '
    'btnAgregarMP
    '
    Me.btnAgregarMP.Location = New System.Drawing.Point(12, 145)
    Me.btnAgregarMP.Name = "btnAgregarMP"
    Me.btnAgregarMP.Size = New System.Drawing.Size(150, 25)
    Me.btnAgregarMP.TabIndex = 5
    Me.btnAgregarMP.Text = "Agregar Material OT"
    Me.btnAgregarMP.UseVisualStyleBackColor = True
    Me.btnAgregarMP.Visible = False
    '
    'tbpReportes
    '
    Me.tbpReportes.BackColor = System.Drawing.SystemColors.Control
    Me.tbpReportes.Controls.Add(Me.btnRptCotAGerencia)
    Me.tbpReportes.Controls.Add(Me.btnBoletas)
    Me.tbpReportes.Controls.Add(Me.btnRptCostosMP)
    Me.tbpReportes.Controls.Add(Me.btnCotizaciones)
    Me.tbpReportes.Controls.Add(Me.cmdEntregasArea)
    Me.tbpReportes.Controls.Add(Me.Button1)
    Me.tbpReportes.Location = New System.Drawing.Point(4, 22)
    Me.tbpReportes.Name = "tbpReportes"
    Me.tbpReportes.Padding = New System.Windows.Forms.Padding(3)
    Me.tbpReportes.Size = New System.Drawing.Size(330, 202)
    Me.tbpReportes.TabIndex = 1
    Me.tbpReportes.Text = "Reportes"
    '
    'btnRptCotAGerencia
    '
    Me.btnRptCotAGerencia.Location = New System.Drawing.Point(56, 166)
    Me.btnRptCotAGerencia.Name = "btnRptCotAGerencia"
    Me.btnRptCotAGerencia.Size = New System.Drawing.Size(172, 25)
    Me.btnRptCotAGerencia.TabIndex = 10
    Me.btnRptCotAGerencia.Text = "Cotizaciones a Gerencia"
    Me.btnRptCotAGerencia.UseVisualStyleBackColor = True
    '
    'btnBoletas
    '
    Me.btnBoletas.Location = New System.Drawing.Point(56, 139)
    Me.btnBoletas.Name = "btnBoletas"
    Me.btnBoletas.Size = New System.Drawing.Size(172, 25)
    Me.btnBoletas.TabIndex = 9
    Me.btnBoletas.Text = "Imprime Boletas"
    Me.btnBoletas.UseVisualStyleBackColor = True
    '
    'btnRptCostosMP
    '
    Me.btnRptCostosMP.Location = New System.Drawing.Point(56, 112)
    Me.btnRptCostosMP.Name = "btnRptCostosMP"
    Me.btnRptCostosMP.Size = New System.Drawing.Size(172, 25)
    Me.btnRptCostosMP.TabIndex = 8
    Me.btnRptCostosMP.Text = "Costos MP"
    Me.btnRptCostosMP.UseVisualStyleBackColor = True
    '
    'btnCotizaciones
    '
    Me.btnCotizaciones.Location = New System.Drawing.Point(56, 85)
    Me.btnCotizaciones.Name = "btnCotizaciones"
    Me.btnCotizaciones.Size = New System.Drawing.Size(172, 25)
    Me.btnCotizaciones.TabIndex = 7
    Me.btnCotizaciones.Text = "Cotizaciones"
    Me.btnCotizaciones.UseVisualStyleBackColor = True
    '
    'cmdEntregasArea
    '
    Me.cmdEntregasArea.Location = New System.Drawing.Point(56, 58)
    Me.cmdEntregasArea.Name = "cmdEntregasArea"
    Me.cmdEntregasArea.Size = New System.Drawing.Size(172, 25)
    Me.cmdEntregasArea.TabIndex = 6
    Me.cmdEntregasArea.Text = "Entregas Area"
    Me.cmdEntregasArea.UseVisualStyleBackColor = True
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(56, 32)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(172, 25)
    Me.Button1.TabIndex = 3
    Me.Button1.Text = "Consultar Orden"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'tbpMto
    '
    Me.tbpMto.BackColor = System.Drawing.SystemColors.Control
    Me.tbpMto.Controls.Add(Me.btnResponsables)
    Me.tbpMto.Controls.Add(Me.cmdMpYaCreada)
    Me.tbpMto.Controls.Add(Me.btnMntCostos)
    Me.tbpMto.Controls.Add(Me.btnMntoMO)
    Me.tbpMto.Location = New System.Drawing.Point(4, 22)
    Me.tbpMto.Name = "tbpMto"
    Me.tbpMto.Padding = New System.Windows.Forms.Padding(3)
    Me.tbpMto.Size = New System.Drawing.Size(330, 202)
    Me.tbpMto.TabIndex = 3
    Me.tbpMto.Text = "Mantenimiento"
    '
    'btnResponsables
    '
    Me.btnResponsables.Location = New System.Drawing.Point(45, 116)
    Me.btnResponsables.Name = "btnResponsables"
    Me.btnResponsables.Size = New System.Drawing.Size(171, 24)
    Me.btnResponsables.TabIndex = 72
    Me.btnResponsables.Text = "Responsables"
    Me.btnResponsables.UseVisualStyleBackColor = True
    '
    'cmdMpYaCreada
    '
    Me.cmdMpYaCreada.Location = New System.Drawing.Point(45, 83)
    Me.cmdMpYaCreada.Name = "cmdMpYaCreada"
    Me.cmdMpYaCreada.Size = New System.Drawing.Size(171, 24)
    Me.cmdMpYaCreada.TabIndex = 71
    Me.cmdMpYaCreada.Text = "MP ya Creada"
    Me.cmdMpYaCreada.UseVisualStyleBackColor = True
    '
    'btnMntCostos
    '
    Me.btnMntCostos.Location = New System.Drawing.Point(45, 19)
    Me.btnMntCostos.Name = "btnMntCostos"
    Me.btnMntCostos.Size = New System.Drawing.Size(171, 25)
    Me.btnMntCostos.TabIndex = 70
    Me.btnMntCostos.Text = "Costos MP"
    Me.btnMntCostos.UseVisualStyleBackColor = True
    Me.btnMntCostos.Visible = False
    '
    'btnMntoMO
    '
    Me.btnMntoMO.Location = New System.Drawing.Point(45, 50)
    Me.btnMntoMO.Name = "btnMntoMO"
    Me.btnMntoMO.Size = New System.Drawing.Size(172, 26)
    Me.btnMntoMO.TabIndex = 0
    Me.btnMntoMO.Text = "Mano Obra"
    Me.btnMntoMO.UseVisualStyleBackColor = True
    '
    'btnBuscar
    '
    Me.btnBuscar.Location = New System.Drawing.Point(16, 370)
    Me.btnBuscar.Name = "btnBuscar"
    Me.btnBuscar.Size = New System.Drawing.Size(81, 32)
    Me.btnBuscar.TabIndex = 73
    Me.btnBuscar.Text = "Notificaciones"
    Me.btnBuscar.UseVisualStyleBackColor = True
    Me.btnBuscar.Visible = False
    '
    'stbEstado
    '
    Me.stbEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stDominio, Me.stUsuario, Me.stVersion})
    Me.stbEstado.Location = New System.Drawing.Point(0, 432)
    Me.stbEstado.Name = "stbEstado"
    Me.stbEstado.Size = New System.Drawing.Size(362, 22)
    Me.stbEstado.TabIndex = 8
    Me.stbEstado.Text = "StatusStrip1"
    '
    'stDominio
    '
    Me.stDominio.Name = "stDominio"
    Me.stDominio.Size = New System.Drawing.Size(53, 17)
    Me.stDominio.Text = "Dominio"
    '
    'stUsuario
    '
    Me.stUsuario.Name = "stUsuario"
    Me.stUsuario.Size = New System.Drawing.Size(47, 17)
    Me.stUsuario.Text = "Usuario"
    '
    'stVersion
    '
    Me.stVersion.Name = "stVersion"
    Me.stVersion.Size = New System.Drawing.Size(45, 17)
    Me.stVersion.Text = "version"
    '
    'PictureBox1
    '
    Me.PictureBox1.Image = Global.ModProd.My.Resources.Resources.NuevaMarca
    Me.PictureBox1.Location = New System.Drawing.Point(229, 359)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(117, 61)
    Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.PictureBox1.TabIndex = 7
    Me.PictureBox1.TabStop = False
    '
    'imgLogo
    '
    Me.imgLogo.Location = New System.Drawing.Point(12, 6)
    Me.imgLogo.Name = "imgLogo"
    Me.imgLogo.Size = New System.Drawing.Size(338, 103)
    Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
    Me.imgLogo.TabIndex = 6
    Me.imgLogo.TabStop = False
    '
    'frmMenu
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(362, 454)
    Me.Controls.Add(Me.btnBuscar)
    Me.Controls.Add(Me.stbEstado)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.imgLogo)
    Me.Controls.Add(Me.TabControl1)
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.Name = "frmMenu"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Producción"
    Me.TabControl1.ResumeLayout(False)
    Me.tbpComercial.ResumeLayout(False)
    Me.tbpProduccion.ResumeLayout(False)
    Me.tbpReportes.ResumeLayout(False)
    Me.tbpMto.ResumeLayout(False)
    Me.stbEstado.ResumeLayout(False)
    Me.stbEstado.PerformLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
  Friend WithEvents cmdCrearOrden As System.Windows.Forms.Button
  Friend WithEvents btnAsignarAlArea As System.Windows.Forms.Button
  Friend WithEvents btnEntregarResumen As System.Windows.Forms.Button
  Friend WithEvents btnCerrarOrden As System.Windows.Forms.Button
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents tbpProduccion As System.Windows.Forms.TabPage
  Friend WithEvents tbpReportes As System.Windows.Forms.TabPage
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents cmdEntregasArea As System.Windows.Forms.Button
  Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
  Friend WithEvents tbpComercial As System.Windows.Forms.TabPage
  Friend WithEvents btnSimulador As System.Windows.Forms.Button
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents btnAgregarMP As System.Windows.Forms.Button
  Friend WithEvents stbEstado As System.Windows.Forms.StatusStrip
  Friend WithEvents stUsuario As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents stDominio As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents btnCotizaciones As System.Windows.Forms.Button
  Friend WithEvents stVersion As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents btnCrearPT As System.Windows.Forms.Button
  Friend WithEvents btnRptCostosMP As System.Windows.Forms.Button
  Friend WithEvents tbpMto As System.Windows.Forms.TabPage
  Friend WithEvents btnMntCostos As System.Windows.Forms.Button
  Friend WithEvents btnMntoMO As System.Windows.Forms.Button
  Friend WithEvents cmdMpYaCreada As System.Windows.Forms.Button
  Friend WithEvents btnResponsables As System.Windows.Forms.Button
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents btnBoletas As System.Windows.Forms.Button
  Friend WithEvents btnPedirMaterialesOT As System.Windows.Forms.Button
  Friend WithEvents btnOrdenCompra As System.Windows.Forms.Button
  Friend WithEvents Button3 As System.Windows.Forms.Button
  Friend WithEvents btnCambiaEstadoCot As System.Windows.Forms.Button
  Friend WithEvents btnContratos As System.Windows.Forms.Button
  Friend WithEvents btnRptCotAGerencia As System.Windows.Forms.Button
  Friend WithEvents btnBuscar As System.Windows.Forms.Button
  Friend WithEvents btnAjustarMaterialesOT As System.Windows.Forms.Button
End Class
