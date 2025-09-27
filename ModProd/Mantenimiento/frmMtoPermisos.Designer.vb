<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMtoPermisos
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMtoPermisos))
    Me.cmbRoles = New System.Windows.Forms.ComboBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.grMenus = New System.Windows.Forms.DataGridView()
    Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
    Me.pnlControles = New System.Windows.Forms.Panel()
    Me.btnBotonera = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.chkUsuarios = New System.Windows.Forms.CheckedListBox()
    CType(Me.grMenus, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.flyPanelBotones.SuspendLayout()
    Me.pnlControles.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmbRoles
    '
    Me.cmbRoles.FormattingEnabled = True
    Me.cmbRoles.Location = New System.Drawing.Point(55, 7)
    Me.cmbRoles.Name = "cmbRoles"
    Me.cmbRoles.Size = New System.Drawing.Size(278, 21)
    Me.cmbRoles.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 10)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(37, 13)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Roles:"
    '
    'grMenus
    '
    Me.grMenus.AllowUserToAddRows = False
    Me.grMenus.AllowUserToDeleteRows = False
    Me.grMenus.AllowUserToOrderColumns = True
    Me.grMenus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grMenus.Location = New System.Drawing.Point(12, 33)
    Me.grMenus.Name = "grMenus"
    Me.grMenus.Size = New System.Drawing.Size(465, 544)
    Me.grMenus.TabIndex = 2
    '
    'flyPanelBotones
    '
    Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(83, Byte), Integer))
    Me.flyPanelBotones.Controls.Add(Me.pnlControles)
    Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
    Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
    Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
    Me.flyPanelBotones.Location = New System.Drawing.Point(860, 0)
    Me.flyPanelBotones.Name = "flyPanelBotones"
    Me.flyPanelBotones.Size = New System.Drawing.Size(181, 582)
    Me.flyPanelBotones.TabIndex = 3
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
    'chkUsuarios
    '
    Me.chkUsuarios.FormattingEnabled = True
    Me.chkUsuarios.Location = New System.Drawing.Point(483, 33)
    Me.chkUsuarios.Name = "chkUsuarios"
    Me.chkUsuarios.Size = New System.Drawing.Size(310, 544)
    Me.chkUsuarios.TabIndex = 4
    '
    'frmMtoPermisos
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1041, 582)
    Me.Controls.Add(Me.chkUsuarios)
    Me.Controls.Add(Me.flyPanelBotones)
    Me.Controls.Add(Me.grMenus)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cmbRoles)
    Me.MaximizeBox = False
    Me.Name = "frmMtoPermisos"
    Me.Text = "Permisos por Roles"
    CType(Me.grMenus, System.ComponentModel.ISupportInitialize).EndInit()
    Me.flyPanelBotones.ResumeLayout(False)
    Me.pnlControles.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents cmbRoles As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grMenus As System.Windows.Forms.DataGridView
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents chkUsuarios As System.Windows.Forms.CheckedListBox
End Class
