<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMtoContratos
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMtoContratos))
    Me.ofdCargarAdjuntos = New System.Windows.Forms.OpenFileDialog()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.chkEstado = New System.Windows.Forms.CheckBox()
    Me.cmdCargar = New System.Windows.Forms.Button()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.lblValor = New System.Windows.Forms.Label()
    Me.lblF_Final = New System.Windows.Forms.Label()
    Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
    Me.lblF_Inicial = New System.Windows.Forms.Label()
    Me.txtValor = New System.Windows.Forms.TextBox()
    Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
    Me.txtAlcance = New System.Windows.Forms.TextBox()
    Me.lblNumero = New System.Windows.Forms.Label()
    Me.cmbCliente = New System.Windows.Forms.ComboBox()
    Me.txtContrato = New System.Windows.Forms.TextBox()
    Me.lblCliente = New System.Windows.Forms.Label()
    Me.lblAlcance = New System.Windows.Forms.Label()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.btnAnexos = New System.Windows.Forms.Button()
    Me.lstAnexos = New System.Windows.Forms.CheckedListBox()
    Me.mnuAbrirPdf = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.AbrirPDFToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.pcbAnexos = New System.Windows.Forms.PictureBox()
    Me.pdfVisor = New AxAcroPDFLib.AxAcroPDF()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    Me.mnuAbrirPdf.SuspendLayout()
    CType(Me.pcbAnexos, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.pdfVisor, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'ofdCargarAdjuntos
    '
    Me.ofdCargarAdjuntos.Multiselect = True
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.TabControl1.Location = New System.Drawing.Point(0, 0)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1057, 758)
    Me.TabControl1.TabIndex = 2
    '
    'TabPage1
    '
    Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage1.Controls.Add(Me.chkEstado)
    Me.TabPage1.Controls.Add(Me.cmdCargar)
    Me.TabPage1.Controls.Add(Me.btnGrabar)
    Me.TabPage1.Controls.Add(Me.lblValor)
    Me.TabPage1.Controls.Add(Me.lblF_Final)
    Me.TabPage1.Controls.Add(Me.dtpFechaFin)
    Me.TabPage1.Controls.Add(Me.lblF_Inicial)
    Me.TabPage1.Controls.Add(Me.txtValor)
    Me.TabPage1.Controls.Add(Me.dtpFechaIni)
    Me.TabPage1.Controls.Add(Me.txtAlcance)
    Me.TabPage1.Controls.Add(Me.lblNumero)
    Me.TabPage1.Controls.Add(Me.cmbCliente)
    Me.TabPage1.Controls.Add(Me.txtContrato)
    Me.TabPage1.Controls.Add(Me.lblCliente)
    Me.TabPage1.Controls.Add(Me.lblAlcance)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(1049, 732)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Cabecera"
    '
    'chkEstado
    '
    Me.chkEstado.AutoSize = True
    Me.chkEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
    Me.chkEstado.Location = New System.Drawing.Point(430, 142)
    Me.chkEstado.Name = "chkEstado"
    Me.chkEstado.Size = New System.Drawing.Size(64, 17)
    Me.chkEstado.TabIndex = 27
    Me.chkEstado.Text = "Inactivo"
    Me.chkEstado.UseVisualStyleBackColor = True
    '
    'cmdCargar
    '
    Me.cmdCargar.Location = New System.Drawing.Point(295, 166)
    Me.cmdCargar.Name = "cmdCargar"
    Me.cmdCargar.Size = New System.Drawing.Size(114, 26)
    Me.cmdCargar.TabIndex = 34
    Me.cmdCargar.Text = "Cargar"
    Me.cmdCargar.UseVisualStyleBackColor = True
    '
    'btnGrabar
    '
    Me.btnGrabar.Location = New System.Drawing.Point(91, 166)
    Me.btnGrabar.Name = "btnGrabar"
    Me.btnGrabar.Size = New System.Drawing.Size(114, 28)
    Me.btnGrabar.TabIndex = 33
    Me.btnGrabar.Text = "Button1"
    Me.btnGrabar.UseVisualStyleBackColor = True
    '
    'lblValor
    '
    Me.lblValor.AutoSize = True
    Me.lblValor.Location = New System.Drawing.Point(430, 119)
    Me.lblValor.Name = "lblValor"
    Me.lblValor.Size = New System.Drawing.Size(34, 13)
    Me.lblValor.TabIndex = 32
    Me.lblValor.Text = "Valor:"
    '
    'lblF_Final
    '
    Me.lblF_Final.AutoSize = True
    Me.lblF_Final.Location = New System.Drawing.Point(224, 146)
    Me.lblF_Final.Name = "lblF_Final"
    Me.lblF_Final.Size = New System.Drawing.Size(65, 13)
    Me.lblF_Final.TabIndex = 31
    Me.lblF_Final.Text = "Fecha Final:"
    '
    'dtpFechaFin
    '
    Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFechaFin.Location = New System.Drawing.Point(295, 140)
    Me.dtpFechaFin.Name = "dtpFechaFin"
    Me.dtpFechaFin.Size = New System.Drawing.Size(114, 20)
    Me.dtpFechaFin.TabIndex = 26
    '
    'lblF_Inicial
    '
    Me.lblF_Inicial.AutoSize = True
    Me.lblF_Inicial.Location = New System.Drawing.Point(13, 146)
    Me.lblF_Inicial.Name = "lblF_Inicial"
    Me.lblF_Inicial.Size = New System.Drawing.Size(70, 13)
    Me.lblF_Inicial.TabIndex = 30
    Me.lblF_Inicial.Text = "Fecha Inicial:"
    '
    'txtValor
    '
    Me.txtValor.Location = New System.Drawing.Point(481, 116)
    Me.txtValor.MaxLength = 12
    Me.txtValor.Name = "txtValor"
    Me.txtValor.Size = New System.Drawing.Size(166, 20)
    Me.txtValor.TabIndex = 24
    Me.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'dtpFechaIni
    '
    Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFechaIni.Location = New System.Drawing.Point(91, 140)
    Me.dtpFechaIni.Name = "dtpFechaIni"
    Me.dtpFechaIni.Size = New System.Drawing.Size(114, 20)
    Me.dtpFechaIni.TabIndex = 25
    '
    'txtAlcance
    '
    Me.txtAlcance.Location = New System.Drawing.Point(91, 42)
    Me.txtAlcance.MaxLength = 500
    Me.txtAlcance.Multiline = True
    Me.txtAlcance.Name = "txtAlcance"
    Me.txtAlcance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtAlcance.Size = New System.Drawing.Size(558, 70)
    Me.txtAlcance.TabIndex = 22
    '
    'lblNumero
    '
    Me.lblNumero.AutoSize = True
    Me.lblNumero.Location = New System.Drawing.Point(13, 119)
    Me.lblNumero.Name = "lblNumero"
    Me.lblNumero.Size = New System.Drawing.Size(47, 13)
    Me.lblNumero.TabIndex = 29
    Me.lblNumero.Text = "Número:"
    '
    'cmbCliente
    '
    Me.cmbCliente.FormattingEnabled = True
    Me.cmbCliente.Location = New System.Drawing.Point(91, 17)
    Me.cmbCliente.Name = "cmbCliente"
    Me.cmbCliente.Size = New System.Drawing.Size(558, 21)
    Me.cmbCliente.TabIndex = 21
    '
    'txtContrato
    '
    Me.txtContrato.Location = New System.Drawing.Point(91, 116)
    Me.txtContrato.MaxLength = 50
    Me.txtContrato.Name = "txtContrato"
    Me.txtContrato.Size = New System.Drawing.Size(318, 20)
    Me.txtContrato.TabIndex = 23
    '
    'lblCliente
    '
    Me.lblCliente.AutoSize = True
    Me.lblCliente.Location = New System.Drawing.Point(13, 17)
    Me.lblCliente.Name = "lblCliente"
    Me.lblCliente.Size = New System.Drawing.Size(42, 13)
    Me.lblCliente.TabIndex = 27
    Me.lblCliente.Text = "Cliente:"
    '
    'lblAlcance
    '
    Me.lblAlcance.AutoSize = True
    Me.lblAlcance.Location = New System.Drawing.Point(13, 42)
    Me.lblAlcance.Name = "lblAlcance"
    Me.lblAlcance.Size = New System.Drawing.Size(49, 13)
    Me.lblAlcance.TabIndex = 28
    Me.lblAlcance.Text = "Alcance:"
    '
    'TabPage3
    '
    Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage3.Controls.Add(Me.SplitContainer1)
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(1049, 732)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "Anexos"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnAnexos)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lstAnexos)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.pdfVisor)
    Me.SplitContainer1.Panel2.Controls.Add(Me.pcbAnexos)
    Me.SplitContainer1.Size = New System.Drawing.Size(1043, 726)
    Me.SplitContainer1.SplitterDistance = 276
    Me.SplitContainer1.TabIndex = 0
    '
    'btnAnexos
    '
    Me.btnAnexos.Location = New System.Drawing.Point(3, 3)
    Me.btnAnexos.Name = "btnAnexos"
    Me.btnAnexos.Size = New System.Drawing.Size(99, 28)
    Me.btnAnexos.TabIndex = 26
    Me.btnAnexos.Text = "Adjuntar..."
    Me.btnAnexos.UseVisualStyleBackColor = True
    '
    'lstAnexos
    '
    Me.lstAnexos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstAnexos.ContextMenuStrip = Me.mnuAbrirPdf
    Me.lstAnexos.FormattingEnabled = True
    Me.lstAnexos.Location = New System.Drawing.Point(3, 37)
    Me.lstAnexos.Name = "lstAnexos"
    Me.lstAnexos.Size = New System.Drawing.Size(266, 664)
    Me.lstAnexos.TabIndex = 23
    '
    'mnuAbrirPdf
    '
    Me.mnuAbrirPdf.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirPDFToolStripMenuItem})
    Me.mnuAbrirPdf.Name = "mnuAbrirPdf"
    Me.mnuAbrirPdf.Size = New System.Drawing.Size(125, 26)
    '
    'AbrirPDFToolStripMenuItem
    '
    Me.AbrirPDFToolStripMenuItem.Name = "AbrirPDFToolStripMenuItem"
    Me.AbrirPDFToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
    Me.AbrirPDFToolStripMenuItem.Text = "Abrir PDF"
    '
    'pcbAnexos
    '
    Me.pcbAnexos.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pcbAnexos.Location = New System.Drawing.Point(0, 0)
    Me.pcbAnexos.Name = "pcbAnexos"
    Me.pcbAnexos.Size = New System.Drawing.Size(759, 722)
    Me.pcbAnexos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.pcbAnexos.TabIndex = 0
    Me.pcbAnexos.TabStop = False
    '
    'pdfVisor
    '
    Me.pdfVisor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.pdfVisor.Enabled = True
    Me.pdfVisor.Location = New System.Drawing.Point(4, 3)
    Me.pdfVisor.Name = "pdfVisor"
    Me.pdfVisor.OcxState = CType(resources.GetObject("pdfVisor.OcxState"), System.Windows.Forms.AxHost.State)
    Me.pdfVisor.Size = New System.Drawing.Size(750, 716)
    Me.pdfVisor.TabIndex = 2
    Me.pdfVisor.Visible = False
    '
    'frmMtoContratos
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1057, 758)
    Me.Controls.Add(Me.TabControl1)
    Me.Name = "frmMtoContratos"
    Me.Text = "frmMtoContratos"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.TabPage1.PerformLayout()
    Me.TabPage3.ResumeLayout(False)
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    Me.mnuAbrirPdf.ResumeLayout(False)
    CType(Me.pcbAnexos, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.pdfVisor, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents ofdCargarAdjuntos As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents btnGrabar As System.Windows.Forms.Button
    Friend WithEvents lblValor As System.Windows.Forms.Label
    Friend WithEvents lblF_Final As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblF_Inicial As System.Windows.Forms.Label
    Friend WithEvents txtValor As System.Windows.Forms.TextBox
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtAlcance As System.Windows.Forms.TextBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
    Friend WithEvents txtContrato As System.Windows.Forms.TextBox
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents lblAlcance As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnAnexos As System.Windows.Forms.Button
    Friend WithEvents lstAnexos As System.Windows.Forms.CheckedListBox
    Friend WithEvents pcbAnexos As System.Windows.Forms.PictureBox
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents mnuAbrirPdf As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents AbrirPDFToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkEstado As System.Windows.Forms.CheckBox
    Friend WithEvents pdfVisor As AxAcroPDFLib.AxAcroPDF
End Class
