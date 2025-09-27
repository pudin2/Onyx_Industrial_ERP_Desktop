<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidarOC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidarOC))
        Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.btnBotonera = New System.Windows.Forms.Button()
        Me.btnAprobar = New System.Windows.Forms.Button()
        Me.cmdActualizar = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.grOrdenesCompra = New System.Windows.Forms.DataGridView()
        Me.flyPanelBotones.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'flyPanelBotones
        '
        Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer))
        Me.flyPanelBotones.Controls.Add(Me.pnlControles)
        Me.flyPanelBotones.Controls.Add(Me.btnAprobar)
        Me.flyPanelBotones.Controls.Add(Me.cmdActualizar)
        Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
        Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
        Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.flyPanelBotones.Location = New System.Drawing.Point(684, 0)
        Me.flyPanelBotones.Name = "flyPanelBotones"
        Me.flyPanelBotones.Size = New System.Drawing.Size(190, 549)
        Me.flyPanelBotones.TabIndex = 9
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
        Me.btnAprobar.Location = New System.Drawing.Point(3, 31)
        Me.btnAprobar.Name = "btnAprobar"
        Me.btnAprobar.Size = New System.Drawing.Size(189, 35)
        Me.btnAprobar.TabIndex = 20
        Me.btnAprobar.Text = "Aprobar"
        Me.btnAprobar.UseVisualStyleBackColor = True
        '
        'cmdActualizar
        '
        Me.cmdActualizar.FlatAppearance.BorderSize = 0
        Me.cmdActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.cmdActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
        Me.cmdActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdActualizar.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActualizar.ForeColor = System.Drawing.Color.White
        Me.cmdActualizar.Image = CType(resources.GetObject("cmdActualizar.Image"), System.Drawing.Image)
        Me.cmdActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdActualizar.Location = New System.Drawing.Point(3, 72)
        Me.cmdActualizar.Name = "cmdActualizar"
        Me.cmdActualizar.Size = New System.Drawing.Size(189, 35)
        Me.cmdActualizar.TabIndex = 85
        Me.cmdActualizar.Text = "Refrescar"
        Me.cmdActualizar.UseVisualStyleBackColor = True
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
        Me.btnImprimir.Visible = False
        '
        'grOrdenesCompra
        '
        Me.grOrdenesCompra.AllowUserToAddRows = False
        Me.grOrdenesCompra.AllowUserToDeleteRows = False
        Me.grOrdenesCompra.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grOrdenesCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grOrdenesCompra.Location = New System.Drawing.Point(6, 12)
        Me.grOrdenesCompra.Name = "grOrdenesCompra"
        Me.grOrdenesCompra.RowHeadersVisible = False
        Me.grOrdenesCompra.Size = New System.Drawing.Size(672, 525)
        Me.grOrdenesCompra.TabIndex = 10
        '
        'frmValidarOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 549)
        Me.Controls.Add(Me.grOrdenesCompra)
        Me.Controls.Add(Me.flyPanelBotones)
        Me.Name = "frmValidarOC"
        Me.Text = "NO USAR Validación de Ordenes de Compra"
        Me.flyPanelBotones.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        CType(Me.grOrdenesCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnAprobar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents cmdActualizar As System.Windows.Forms.Button
    Friend WithEvents grOrdenesCompra As System.Windows.Forms.DataGridView
End Class
