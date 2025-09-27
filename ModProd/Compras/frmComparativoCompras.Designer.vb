<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmComparativoCompras
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmComparativoCompras))
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.flyPanelBotones = New System.Windows.Forms.FlowLayoutPanel()
    Me.pnlControles = New System.Windows.Forms.Panel()
    Me.btnBotonera = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.btnOrdenCompra = New System.Windows.Forms.Button()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Panel1 = New System.Windows.Forms.Panel()
    Me.btnMenuLista = New System.Windows.Forms.Button()
    Me.chkCotizaciones = New System.Windows.Forms.CheckedListBox()
    Me.pnlDerecha = New System.Windows.Forms.Panel()
    Me.grComparativo = New System.Windows.Forms.DataGridView()
    Me.flyPanelBotones.SuspendLayout()
    Me.pnlControles.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.pnlDerecha.SuspendLayout()
    CType(Me.grComparativo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'flyPanelBotones
    '
    Me.flyPanelBotones.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(103, Byte), Integer))
    Me.flyPanelBotones.Controls.Add(Me.pnlControles)
    Me.flyPanelBotones.Controls.Add(Me.btnGrabar)
    Me.flyPanelBotones.Controls.Add(Me.btnCargar)
    Me.flyPanelBotones.Controls.Add(Me.btnImprimir)
    Me.flyPanelBotones.Controls.Add(Me.btnOrdenCompra)
    Me.flyPanelBotones.Controls.Add(Me.Button1)
    Me.flyPanelBotones.Dock = System.Windows.Forms.DockStyle.Right
    Me.flyPanelBotones.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
    Me.flyPanelBotones.Location = New System.Drawing.Point(745, 0)
    Me.flyPanelBotones.Name = "flyPanelBotones"
    Me.flyPanelBotones.Size = New System.Drawing.Size(190, 711)
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
    Me.btnImprimir.Visible = False
    '
    'btnOrdenCompra
    '
    Me.btnOrdenCompra.FlatAppearance.BorderSize = 0
    Me.btnOrdenCompra.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.btnOrdenCompra.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.btnOrdenCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnOrdenCompra.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnOrdenCompra.ForeColor = System.Drawing.Color.White
    Me.btnOrdenCompra.Image = CType(resources.GetObject("btnOrdenCompra.Image"), System.Drawing.Image)
    Me.btnOrdenCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.btnOrdenCompra.Location = New System.Drawing.Point(3, 154)
    Me.btnOrdenCompra.Name = "btnOrdenCompra"
    Me.btnOrdenCompra.Size = New System.Drawing.Size(189, 35)
    Me.btnOrdenCompra.TabIndex = 83
    Me.btnOrdenCompra.Text = "      Orden de Compra"
    Me.btnOrdenCompra.UseVisualStyleBackColor = True
    Me.btnOrdenCompra.Visible = False
    '
    'Button1
    '
    Me.Button1.FlatAppearance.BorderSize = 0
    Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.Button1.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Button1.ForeColor = System.Drawing.Color.White
    Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
    Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.Button1.Location = New System.Drawing.Point(3, 195)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(189, 35)
    Me.Button1.TabIndex = 84
    Me.Button1.Text = "TEST"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'Panel1
    '
    Me.Panel1.BackColor = System.Drawing.SystemColors.Control
    Me.Panel1.Controls.Add(Me.btnMenuLista)
    Me.Panel1.Location = New System.Drawing.Point(0, 0)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(400, 22)
    Me.Panel1.TabIndex = 82
    '
    'btnMenuLista
    '
    Me.btnMenuLista.FlatAppearance.BorderSize = 0
    Me.btnMenuLista.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.btnMenuLista.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer), CType(CType(171, Byte), Integer))
    Me.btnMenuLista.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.btnMenuLista.Font = New System.Drawing.Font("Century Gothic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.btnMenuLista.ForeColor = System.Drawing.Color.White
    Me.btnMenuLista.Image = CType(resources.GetObject("btnMenuLista.Image"), System.Drawing.Image)
    Me.btnMenuLista.Location = New System.Drawing.Point(3, 0)
    Me.btnMenuLista.Name = "btnMenuLista"
    Me.btnMenuLista.Size = New System.Drawing.Size(28, 19)
    Me.btnMenuLista.TabIndex = 83
    Me.btnMenuLista.UseVisualStyleBackColor = True
    '
    'chkCotizaciones
    '
    Me.chkCotizaciones.BackColor = System.Drawing.SystemColors.Control
    Me.chkCotizaciones.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.chkCotizaciones.ForeColor = System.Drawing.Color.Black
    Me.chkCotizaciones.FormattingEnabled = True
    Me.chkCotizaciones.Items.AddRange(New Object() {"Item 1", "Item 2", "Item 3"})
    Me.chkCotizaciones.Location = New System.Drawing.Point(3, 31)
    Me.chkCotizaciones.Name = "chkCotizaciones"
    Me.chkCotizaciones.Size = New System.Drawing.Size(394, 675)
    Me.chkCotizaciones.TabIndex = 9
    '
    'pnlDerecha
    '
    Me.pnlDerecha.BackColor = System.Drawing.SystemColors.Control
    Me.pnlDerecha.Controls.Add(Me.chkCotizaciones)
    Me.pnlDerecha.Controls.Add(Me.Panel1)
    Me.pnlDerecha.Location = New System.Drawing.Point(0, 0)
    Me.pnlDerecha.Name = "pnlDerecha"
    Me.pnlDerecha.Size = New System.Drawing.Size(400, 22)
    Me.pnlDerecha.TabIndex = 83
    '
    'grComparativo
    '
    Me.grComparativo.AllowUserToAddRows = False
    Me.grComparativo.AllowUserToDeleteRows = False
    Me.grComparativo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grComparativo.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.grComparativo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grComparativo.DefaultCellStyle = DataGridViewCellStyle2
    Me.grComparativo.Location = New System.Drawing.Point(3, 25)
    Me.grComparativo.Name = "grComparativo"
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grComparativo.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
    Me.grComparativo.RowHeadersVisible = False
    Me.grComparativo.Size = New System.Drawing.Size(739, 681)
    Me.grComparativo.TabIndex = 84
    '
    'frmComparativoCompras
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(935, 711)
    Me.Controls.Add(Me.pnlDerecha)
    Me.Controls.Add(Me.grComparativo)
    Me.Controls.Add(Me.flyPanelBotones)
    Me.Name = "frmComparativoCompras"
    Me.Text = "Comparativo Cotizaciones"
    Me.flyPanelBotones.ResumeLayout(False)
    Me.pnlControles.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    Me.pnlDerecha.ResumeLayout(False)
    CType(Me.grComparativo, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents flyPanelBotones As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents btnBotonera As System.Windows.Forms.Button
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents btnCargar As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnOrdenCompra As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnMenuLista As System.Windows.Forms.Button
    Friend WithEvents chkCotizaciones As System.Windows.Forms.CheckedListBox
    Friend WithEvents pnlDerecha As System.Windows.Forms.Panel
    Friend WithEvents grComparativo As System.Windows.Forms.DataGridView
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
