<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmActualizaPrecios
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmActualizaPrecios))
    Me.grDetalle = New System.Windows.Forms.DataGridView()
    Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
    Me.pnlControles = New System.Windows.Forms.Panel()
    Me.btnBotonera = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.btnCotizar = New System.Windows.Forms.Button()
    Me.txtNumOrden = New System.Windows.Forms.TextBox()
    Me.Label20 = New System.Windows.Forms.Label()
    Me.lblProveedor = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.sstEstado = New System.Windows.Forms.StatusStrip()
    Me.tssNumeroCot = New System.Windows.Forms.ToolStripStatusLabel()
    Me.dtpFechaEntrega = New System.Windows.Forms.DateTimePicker()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.txtNumCotProveedor = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.lblFecha = New System.Windows.Forms.TextBox()
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.flyPanelBotones.SuspendLayout()
    Me.pnlControles.SuspendLayout()
    Me.sstEstado.SuspendLayout()
    Me.SuspendLayout()
    '
    'grDetalle
    '
    Me.grDetalle.AllowUserToAddRows = False
    Me.grDetalle.AllowUserToDeleteRows = False
    Me.grDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalle.Location = New System.Drawing.Point(12, 61)
    Me.grDetalle.Name = "grDetalle"
    Me.grDetalle.RowHeadersVisible = False
    Me.grDetalle.Size = New System.Drawing.Size(904, 417)
    Me.grDetalle.TabIndex = 7
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
    Me.flyPanelBotones.Location = New System.Drawing.Point(917, 0)
    Me.flyPanelBotones.Name = "flyPanelBotones"
    Me.flyPanelBotones.Size = New System.Drawing.Size(190, 518)
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
    'txtNumOrden
    '
    Me.txtNumOrden.Location = New System.Drawing.Point(92, 12)
    Me.txtNumOrden.MaxLength = 8
    Me.txtNumOrden.Name = "txtNumOrden"
    Me.txtNumOrden.Size = New System.Drawing.Size(120, 20)
    Me.txtNumOrden.TabIndex = 8
    '
    'Label20
    '
    Me.Label20.AutoSize = True
    Me.Label20.Location = New System.Drawing.Point(9, 15)
    Me.Label20.Name = "Label20"
    Me.Label20.Size = New System.Drawing.Size(59, 13)
    Me.Label20.TabIndex = 9
    Me.Label20.Text = "Cotización:"
    '
    'lblProveedor
    '
    Me.lblProveedor.AutoSize = True
    Me.lblProveedor.Location = New System.Drawing.Point(461, 15)
    Me.lblProveedor.Name = "lblProveedor"
    Me.lblProveedor.Size = New System.Drawing.Size(118, 13)
    Me.lblProveedor.TabIndex = 11
    Me.lblProveedor.Text = "                                     "
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(9, 33)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(82, 13)
    Me.Label3.TabIndex = 12
    Me.Label3.Text = "Fecha Registro:"
    '
    'sstEstado
    '
    Me.sstEstado.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tssNumeroCot})
    Me.sstEstado.Location = New System.Drawing.Point(0, 496)
    Me.sstEstado.Name = "sstEstado"
    Me.sstEstado.Size = New System.Drawing.Size(917, 22)
    Me.sstEstado.TabIndex = 14
    Me.sstEstado.Text = "StatusStrip1"
    '
    'tssNumeroCot
    '
    Me.tssNumeroCot.Name = "tssNumeroCot"
    Me.tssNumeroCot.Size = New System.Drawing.Size(0, 17)
    '
    'dtpFechaEntrega
    '
    Me.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFechaEntrega.Location = New System.Drawing.Point(335, 12)
    Me.dtpFechaEntrega.Name = "dtpFechaEntrega"
    Me.dtpFechaEntrega.Size = New System.Drawing.Size(120, 20)
    Me.dtpFechaEntrega.TabIndex = 15
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(222, 12)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 13)
    Me.Label2.TabIndex = 16
    Me.Label2.Text = "Fecha Entrega:"
    '
    'txtNumCotProveedor
    '
    Me.txtNumCotProveedor.Location = New System.Drawing.Point(335, 35)
    Me.txtNumCotProveedor.MaxLength = 30
    Me.txtNumCotProveedor.Name = "txtNumCotProveedor"
    Me.txtNumCotProveedor.Size = New System.Drawing.Size(120, 20)
    Me.txtNumCotProveedor.TabIndex = 17
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(222, 34)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(111, 13)
    Me.Label1.TabIndex = 18
    Me.Label1.Text = "Cotización Proveedor:"
    '
    'lblFecha
    '
    Me.lblFecha.Location = New System.Drawing.Point(92, 35)
    Me.lblFecha.MaxLength = 30
    Me.lblFecha.Name = "lblFecha"
    Me.lblFecha.ReadOnly = True
    Me.lblFecha.Size = New System.Drawing.Size(120, 20)
    Me.lblFecha.TabIndex = 19
    '
    'frmActualizaPrecios
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1107, 518)
    Me.Controls.Add(Me.lblFecha)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtNumCotProveedor)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.dtpFechaEntrega)
    Me.Controls.Add(Me.sstEstado)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.lblProveedor)
    Me.Controls.Add(Me.txtNumOrden)
    Me.Controls.Add(Me.Label20)
    Me.Controls.Add(Me.grDetalle)
    Me.Controls.Add(Me.flyPanelBotones)
    Me.Name = "frmActualizaPrecios"
    Me.Text = "Actualiza Precios"
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
    Me.flyPanelBotones.ResumeLayout(False)
    Me.pnlControles.ResumeLayout(False)
    Me.sstEstado.ResumeLayout(False)
    Me.sstEstado.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnCotizar As System.Windows.Forms.Button
    Friend WithEvents txtNumOrden As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents lblProveedor As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents sstEstado As System.Windows.Forms.StatusStrip
    Friend WithEvents tssNumeroCot As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents dtpFechaEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNumCotProveedor As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.TextBox
End Class
