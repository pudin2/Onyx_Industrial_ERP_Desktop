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
Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
Me.pnlControles = New System.Windows.Forms.Panel()
Me.btnBotonera = New System.Windows.Forms.Button()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.cmdCargar = New System.Windows.Forms.Button()
Me.btnAprobar = New System.Windows.Forms.Button()
Me.btnSigFase = New System.Windows.Forms.Button()
Me.btnImprimir = New System.Windows.Forms.Button()
Me.flyPanelBotones.SuspendLayout()
Me.pnlControles.SuspendLayout()
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
Me.flyPanelBotones.Location = New System.Drawing.Point(1017, 0)
Me.flyPanelBotones.Name = "flyPanelBotones"
Me.flyPanelBotones.Size = New System.Drawing.Size(190, 724)
Me.flyPanelBotones.TabIndex = 7
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
'frmSeguimientoOT
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(1207, 724)
Me.Controls.Add(Me.flyPanelBotones)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Name = "frmSeguimientoOT"
Me.Text = "frmSeguimientoOT"
Me.flyPanelBotones.ResumeLayout(False)
Me.pnlControles.ResumeLayout(False)
Me.ResumeLayout(False)

End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnSigFase As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
