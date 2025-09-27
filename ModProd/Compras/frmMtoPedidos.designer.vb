<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMtoPedidos
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMtoPedidos))
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.btnCargar = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.btnCotizar = New System.Windows.Forms.Button()
Me.grPedidos = New System.Windows.Forms.DataGridView()
Me.Label5 = New System.Windows.Forms.Label()
Me.txtOC = New System.Windows.Forms.TextBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.txtMP = New System.Windows.Forms.TextBox()
Me.grpEstados = New System.Windows.Forms.GroupBox()
Me.optSolNormal = New System.Windows.Forms.RadioButton()
Me.optSolManual = New System.Windows.Forms.RadioButton()
Me.optSolTodas = New System.Windows.Forms.RadioButton()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtOT = New System.Windows.Forms.TextBox()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).BeginInit()
Me.grpEstados.SuspendLayout()
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
Me.flyPanelBotones.Location = New System.Drawing.Point(932, 0)
Me.flyPanelBotones.Margin = New System.Windows.Forms.Padding(4)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(253, 553)
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
Me.grPedidos.Location = New System.Drawing.Point(11, 100)
Me.grPedidos.Margin = New System.Windows.Forms.Padding(4)
Me.grPedidos.Name = "grPedidos"
Me.grPedidos.RowHeadersVisible = False
Me.grPedidos.Size = New System.Drawing.Size(913, 438)
Me.grPedidos.TabIndex = 5
'
'Label5
'
Me.Label5.AutoSize = True
Me.Label5.Location = New System.Drawing.Point(18, 44)
Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label5.Name = "Label5"
Me.Label5.Size = New System.Drawing.Size(32, 17)
Me.Label5.TabIndex = 14
Me.Label5.Text = "OC:"
'
'txtOC
'
Me.txtOC.Location = New System.Drawing.Point(59, 38)
Me.txtOC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtOC.MaxLength = 15
Me.txtOC.Name = "txtOC"
Me.txtOC.Size = New System.Drawing.Size(133, 22)
Me.txtOC.TabIndex = 14
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(18, 70)
Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(32, 17)
Me.Label1.TabIndex = 16
Me.Label1.Text = "MP:"
'
'txtMP
'
Me.txtMP.Location = New System.Drawing.Point(59, 65)
Me.txtMP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtMP.MaxLength = 15
Me.txtMP.Name = "txtMP"
Me.txtMP.Size = New System.Drawing.Size(133, 22)
Me.txtMP.TabIndex = 15
'
'grpEstados
'
Me.grpEstados.Controls.Add(Me.optSolNormal)
Me.grpEstados.Controls.Add(Me.optSolManual)
Me.grpEstados.Controls.Add(Me.optSolTodas)
Me.grpEstados.Location = New System.Drawing.Point(199, -6)
Me.grpEstados.Margin = New System.Windows.Forms.Padding(4)
Me.grpEstados.Name = "grpEstados"
Me.grpEstados.Padding = New System.Windows.Forms.Padding(4)
Me.grpEstados.Size = New System.Drawing.Size(130, 98)
Me.grpEstados.TabIndex = 17
Me.grpEstados.TabStop = False
'
'optSolNormal
'
Me.optSolNormal.AutoSize = True
Me.optSolNormal.Checked = True
Me.optSolNormal.Location = New System.Drawing.Point(13, 18)
Me.optSolNormal.Margin = New System.Windows.Forms.Padding(4)
Me.optSolNormal.Name = "optSolNormal"
Me.optSolNormal.Size = New System.Drawing.Size(74, 21)
Me.optSolNormal.TabIndex = 16
Me.optSolNormal.TabStop = True
Me.optSolNormal.Text = "Normal"
Me.optSolNormal.UseVisualStyleBackColor = True
'
'optSolManual
'
Me.optSolManual.AutoSize = True
Me.optSolManual.Location = New System.Drawing.Point(13, 46)
Me.optSolManual.Margin = New System.Windows.Forms.Padding(4)
Me.optSolManual.Name = "optSolManual"
Me.optSolManual.Size = New System.Drawing.Size(75, 21)
Me.optSolManual.TabIndex = 17
Me.optSolManual.Text = "Manual"
Me.optSolManual.UseVisualStyleBackColor = True
'
'optSolTodas
'
Me.optSolTodas.AutoSize = True
Me.optSolTodas.Location = New System.Drawing.Point(13, 72)
Me.optSolTodas.Margin = New System.Windows.Forms.Padding(4)
Me.optSolTodas.Name = "optSolTodas"
Me.optSolTodas.Size = New System.Drawing.Size(69, 21)
Me.optSolTodas.TabIndex = 18
Me.optSolTodas.Text = "Todas"
Me.optSolTodas.UseVisualStyleBackColor = True
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(18, 16)
Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(32, 17)
Me.Label2.TabIndex = 19
Me.Label2.Text = "OT:"
'
'txtOT
'
Me.txtOT.Location = New System.Drawing.Point(59, 11)
Me.txtOT.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
Me.txtOT.MaxLength = 15
Me.txtOT.Name = "txtOT"
Me.txtOT.Size = New System.Drawing.Size(133, 22)
Me.txtOT.TabIndex = 13
'
'frmMovInv
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1185, 553)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.txtOT)
Me.Controls.Add(Me.grpEstados)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.txtMP)
Me.Controls.Add(Me.Label5)
Me.Controls.Add(Me.txtOC)
Me.Controls.Add(Me.grPedidos)
Me.Controls.Add(Me.flyPanelBotones)
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmMovInv"
Me.Text = "Mantenimiento Pedidos"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
CType(Me.grPedidos, System.ComponentModel.ISupportInitialize).EndInit()
Me.grpEstados.ResumeLayout(False)
Me.grpEstados.PerformLayout()
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
  Friend WithEvents btnCotizar As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents txtOC As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtMP As System.Windows.Forms.TextBox
  Friend WithEvents grpEstados As System.Windows.Forms.GroupBox
  Friend WithEvents optSolNormal As System.Windows.Forms.RadioButton
  Friend WithEvents optSolManual As System.Windows.Forms.RadioButton
  Friend WithEvents optSolTodas As System.Windows.Forms.RadioButton
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtOT As System.Windows.Forms.TextBox
End Class
