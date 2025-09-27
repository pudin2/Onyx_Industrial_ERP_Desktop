<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPedidos
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPedidos))
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.btnCargar = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.btnCotizar = New System.Windows.Forms.Button()
Me.grPedidos = New System.Windows.Forms.DataGridView()
Me.lblProveedor = New System.Windows.Forms.Label()
Me.Label1 = New System.Windows.Forms.Label()
Me.txtObservacion = New System.Windows.Forms.TextBox()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtOT = New System.Windows.Forms.TextBox()
Me.Label5 = New System.Windows.Forms.Label()
Me.txtOC = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.txtMP = New System.Windows.Forms.TextBox()
Me.GroupBox1 = New System.Windows.Forms.GroupBox()
Me.optOCActivas = New System.Windows.Forms.RadioButton()
Me.optOCEliminadas = New System.Windows.Forms.RadioButton()
Me.optOCTodas = New System.Windows.Forms.RadioButton()
Me.cmbProveedores = New System.Windows.Forms.ComboBox()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
Me.GroupBox1.SuspendLayout()
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
Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
Me.flyPanelBotones.Location = New System.Drawing.Point(1171, 0)
Me.flyPanelBotones.Margin = New System.Windows.Forms.Padding(4)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(253, 731)
Me.flyPanelBotones.TabIndex = 3
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
Me.btnGrabar.TabIndex = 15
Me.btnGrabar.Text = "No se usa Grabar"
Me.btnGrabar.UseVisualStyleBackColor = True
Me.btnGrabar.Visible = False
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
Me.btnCargar.Location = New System.Drawing.Point(4, 90)
Me.btnCargar.Margin = New System.Windows.Forms.Padding(4)
Me.btnCargar.Name = "btnCargar"
Me.btnCargar.Size = New System.Drawing.Size(252, 43)
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
Me.btnImprimir.Location = New System.Drawing.Point(4, 141)
Me.btnImprimir.Margin = New System.Windows.Forms.Padding(4)
Me.btnImprimir.Name = "btnImprimir"
Me.btnImprimir.Size = New System.Drawing.Size(252, 43)
Me.btnImprimir.TabIndex = 16
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
Me.btnCotizar.Location = New System.Drawing.Point(4, 192)
Me.btnCotizar.Margin = New System.Windows.Forms.Padding(4)
Me.btnCotizar.Name = "btnCotizar"
Me.btnCotizar.Size = New System.Drawing.Size(252, 43)
Me.btnCotizar.TabIndex = 83
Me.btnCotizar.Text = "Cot"
Me.btnCotizar.UseVisualStyleBackColor = True
'
'grPedidos
'
Me.grPedidos.AllowUserToAddRows = False
Me.grPedidos.AllowUserToDeleteRows = False
Me.grPedidos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grPedidos.Location = New System.Drawing.Point(11, 111)
Me.grPedidos.Margin = New System.Windows.Forms.Padding(4)
Me.grPedidos.Name = "grPedidos"
Me.grPedidos.RowHeadersVisible = False
Me.grPedidos.Size = New System.Drawing.Size(1152, 605)
Me.grPedidos.TabIndex = 5
'
'lblProveedor
'
Me.lblProveedor.AutoSize = True
Me.lblProveedor.Location = New System.Drawing.Point(7, 20)
Me.lblProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.lblProveedor.Name = "lblProveedor"
Me.lblProveedor.Size = New System.Drawing.Size(74, 17)
Me.lblProveedor.TabIndex = 6
Me.lblProveedor.Text = "Proveedor"
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(7, 53)
Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(92, 17)
Me.Label1.TabIndex = 7
Me.Label1.Text = "Observación:"
'
'txtObservacion
'
Me.txtObservacion.Location = New System.Drawing.Point(96, 48)
Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4)
Me.txtObservacion.MaxLength = 500
Me.txtObservacion.Multiline = True
Me.txtObservacion.Name = "txtObservacion"
Me.txtObservacion.Size = New System.Drawing.Size(699, 51)
Me.txtObservacion.TabIndex = 8
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(820, 20)
Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(32, 17)
Me.Label2.TabIndex = 23
Me.Label2.Text = "OT:"
'
'txtOT
'
Me.txtOT.Location = New System.Drawing.Point(861, 17)
Me.txtOT.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtOT.MaxLength = 15
Me.txtOT.Name = "txtOT"
Me.txtOT.Size = New System.Drawing.Size(133, 22)
Me.txtOT.TabIndex = 20
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(820, 49)
Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(32, 17)
Me.Label5.TabIndex = 21
Me.Label5.Text = "OC:"
'
'txtOC
'
Me.txtOC.Location = New System.Drawing.Point(861, 46)
Me.txtOC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtOC.MaxLength = 15
Me.txtOC.Name = "txtOC"
Me.txtOC.Size = New System.Drawing.Size(133, 22)
Me.txtOC.TabIndex = 22
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(820, 77)
Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(32, 17)
Me.Label3.TabIndex = 25
Me.Label3.Text = "MP:"
'
'txtMP
'
Me.txtMP.Location = New System.Drawing.Point(861, 75)
Me.txtMP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtMP.MaxLength = 15
Me.txtMP.Name = "txtMP"
Me.txtMP.Size = New System.Drawing.Size(133, 22)
Me.txtMP.TabIndex = 24
'
'GroupBox1
'
Me.GroupBox1.Controls.Add(Me.optOCActivas)
Me.GroupBox1.Controls.Add(Me.optOCEliminadas)
Me.GroupBox1.Controls.Add(Me.optOCTodas)
Me.GroupBox1.Location = New System.Drawing.Point(1019, 0)
Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
Me.GroupBox1.Name = "GroupBox1"
Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
Me.GroupBox1.Size = New System.Drawing.Size(139, 103)
Me.GroupBox1.TabIndex = 26
Me.GroupBox1.TabStop = False
Me.GroupBox1.Text = "Estado OC"
'
'optOCActivas
'
Me.optOCActivas.AutoSize = True
Me.optOCActivas.Checked = True
Me.optOCActivas.Location = New System.Drawing.Point(13, 19)
Me.optOCActivas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCActivas.Name = "optOCActivas"
Me.optOCActivas.Size = New System.Drawing.Size(74, 21)
Me.optOCActivas.TabIndex = 27
Me.optOCActivas.TabStop = True
Me.optOCActivas.Text = "Activas"
Me.optOCActivas.UseVisualStyleBackColor = True
'
'optOCEliminadas
'
Me.optOCEliminadas.AutoSize = True
Me.optOCEliminadas.Location = New System.Drawing.Point(13, 46)
Me.optOCEliminadas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCEliminadas.Name = "optOCEliminadas"
Me.optOCEliminadas.Size = New System.Drawing.Size(97, 21)
Me.optOCEliminadas.TabIndex = 26
Me.optOCEliminadas.Text = "Eliminadas"
Me.optOCEliminadas.UseVisualStyleBackColor = True
'
'optOCTodas
'
Me.optOCTodas.AutoSize = True
Me.optOCTodas.Location = New System.Drawing.Point(13, 73)
Me.optOCTodas.Margin = New System.Windows.Forms.Padding(4)
Me.optOCTodas.Name = "optOCTodas"
Me.optOCTodas.Size = New System.Drawing.Size(69, 21)
Me.optOCTodas.TabIndex = 25
Me.optOCTodas.Text = "Todas"
Me.optOCTodas.UseVisualStyleBackColor = True
'
'cmbProveedores
'
Me.cmbProveedores.FormattingEnabled = True
Me.cmbProveedores.Location = New System.Drawing.Point(96, 18)
Me.cmbProveedores.Margin = New System.Windows.Forms.Padding(4)
Me.cmbProveedores.Name = "cmbProveedores"
Me.cmbProveedores.Size = New System.Drawing.Size(699, 24)
Me.cmbProveedores.TabIndex = 4
'
'frmPedidos
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1424, 731)
Me.Controls.Add(Me.GroupBox1)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.txtMP)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtOT)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.txtOC)
Me.Controls.Add(Me.txtObservacion)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.lblProveedor)
Me.Controls.Add(Me.grPedidos)
Me.Controls.Add(Me.cmbProveedores)
Me.Controls.Add(Me.flyPanelBotones)
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmPedidos"
Me.Text = "Pedidos"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).EndInit()
Me.GroupBox1.ResumeLayout(False)
Me.GroupBox1.PerformLayout()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents grPedidos As System.Windows.Forms.DataGridView
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents btnCotizar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOT As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtOC As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMP As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents optOCEliminadas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCTodas As System.Windows.Forms.RadioButton
    Friend WithEvents optOCActivas As System.Windows.Forms.RadioButton
    Friend WithEvents cmbProveedores As System.Windows.Forms.ComboBox
End Class
