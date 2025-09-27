<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscar
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
Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscar))
Me.grDet = New System.Windows.Forms.DataGridView()
Me.txtDocumento = New System.Windows.Forms.TextBox()
Me.txtTexto = New System.Windows.Forms.TextBox()
Me.cmbTercero = New System.Windows.Forms.ComboBox()
Me.dtpFechaIni = New System.Windows.Forms.DateTimePicker()
Me.dtpFechaFin = New System.Windows.Forms.DateTimePicker()
Me.lblDoc = New System.Windows.Forms.Label()
Me.btnBuscar = New System.Windows.Forms.Button()
Me.chkFechas = New System.Windows.Forms.CheckBox()
Me.chkTexto = New System.Windows.Forms.CheckBox()
Me.chkTercero = New System.Windows.Forms.CheckBox()
Me.btnAceptar = New System.Windows.Forms.Button()
Me.btnCancelar = New System.Windows.Forms.Button()
CType(Me.grDet, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'grDet
'
Me.grDet.AllowUserToAddRows = False
Me.grDet.AllowUserToDeleteRows = False
Me.grDet.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
Me.grDet.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
Me.grDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grDet.Location = New System.Drawing.Point(15, 160)
Me.grDet.MultiSelect = False
Me.grDet.Name = "grDet"
Me.grDet.ReadOnly = True
Me.grDet.RowHeadersVisible = False
Me.grDet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
Me.grDet.Size = New System.Drawing.Size(793, 270)
Me.grDet.TabIndex = 4
'
'txtDocumento
'
Me.txtDocumento.Location = New System.Drawing.Point(99, 12)
Me.txtDocumento.Name = "txtDocumento"
Me.txtDocumento.Size = New System.Drawing.Size(342, 20)
Me.txtDocumento.TabIndex = 1
'
'txtTexto
'
Me.txtTexto.BackColor = System.Drawing.SystemColors.Window
Me.txtTexto.Enabled = False
Me.txtTexto.Location = New System.Drawing.Point(99, 38)
Me.txtTexto.Name = "txtTexto"
Me.txtTexto.Size = New System.Drawing.Size(342, 20)
Me.txtTexto.TabIndex = 2
'
'cmbTercero
'
Me.cmbTercero.Enabled = False
Me.cmbTercero.FormattingEnabled = True
Me.cmbTercero.Location = New System.Drawing.Point(99, 90)
Me.cmbTercero.Name = "cmbTercero"
Me.cmbTercero.Size = New System.Drawing.Size(342, 21)
Me.cmbTercero.TabIndex = 5
'
'dtpFechaIni
'
Me.dtpFechaIni.Enabled = False
Me.dtpFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFechaIni.Location = New System.Drawing.Point(99, 64)
Me.dtpFechaIni.Name = "dtpFechaIni"
Me.dtpFechaIni.Size = New System.Drawing.Size(159, 20)
Me.dtpFechaIni.TabIndex = 3
'
'dtpFechaFin
'
Me.dtpFechaFin.Enabled = False
Me.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFechaFin.Location = New System.Drawing.Point(274, 64)
Me.dtpFechaFin.Name = "dtpFechaFin"
Me.dtpFechaFin.Size = New System.Drawing.Size(167, 20)
Me.dtpFechaFin.TabIndex = 4
'
'lblDoc
'
Me.lblDoc.AutoSize = True
Me.lblDoc.Location = New System.Drawing.Point(12, 12)
Me.lblDoc.Name = "lblDoc"
Me.lblDoc.Size = New System.Drawing.Size(62, 13)
Me.lblDoc.TabIndex = 16
Me.lblDoc.Text = "Documento"
'
'btnBuscar
'
Me.btnBuscar.Location = New System.Drawing.Point(99, 117)
Me.btnBuscar.Name = "btnBuscar"
Me.btnBuscar.Size = New System.Drawing.Size(102, 27)
Me.btnBuscar.TabIndex = 6
Me.btnBuscar.Text = "Buscar"
Me.btnBuscar.UseVisualStyleBackColor = True
'
'chkFechas
'
Me.chkFechas.AutoSize = True
Me.chkFechas.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.chkFechas.Location = New System.Drawing.Point(12, 64)
Me.chkFechas.Name = "chkFechas"
Me.chkFechas.Size = New System.Drawing.Size(61, 17)
Me.chkFechas.TabIndex = 22
Me.chkFechas.Text = "Fechas"
Me.chkFechas.TextAlign = System.Drawing.ContentAlignment.BottomLeft
Me.chkFechas.UseVisualStyleBackColor = True
'
'chkTexto
'
Me.chkTexto.AutoSize = True
Me.chkTexto.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.chkTexto.Location = New System.Drawing.Point(12, 38)
Me.chkTexto.Name = "chkTexto"
Me.chkTexto.Size = New System.Drawing.Size(53, 17)
Me.chkTexto.TabIndex = 23
Me.chkTexto.Text = "Texto"
Me.chkTexto.TextAlign = System.Drawing.ContentAlignment.BottomLeft
Me.chkTexto.UseVisualStyleBackColor = True
'
'chkTercero
'
Me.chkTercero.AutoSize = True
Me.chkTercero.CheckAlign = System.Drawing.ContentAlignment.TopRight
Me.chkTercero.Location = New System.Drawing.Point(12, 90)
Me.chkTercero.Name = "chkTercero"
Me.chkTercero.Size = New System.Drawing.Size(63, 17)
Me.chkTercero.TabIndex = 24
Me.chkTercero.Text = "Tercero"
Me.chkTercero.TextAlign = System.Drawing.ContentAlignment.BottomLeft
Me.chkTercero.UseVisualStyleBackColor = True
'
'btnAceptar
'
Me.btnAceptar.Enabled = False
Me.btnAceptar.Location = New System.Drawing.Point(339, 117)
Me.btnAceptar.Name = "btnAceptar"
Me.btnAceptar.Size = New System.Drawing.Size(102, 27)
Me.btnAceptar.TabIndex = 7
Me.btnAceptar.Text = "Aceptar"
Me.btnAceptar.UseVisualStyleBackColor = True
'
'btnCancelar
'
Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancelar.Location = New System.Drawing.Point(217, 117)
Me.btnCancelar.Name = "btnCancelar"
Me.btnCancelar.Size = New System.Drawing.Size(102, 27)
Me.btnCancelar.TabIndex = 25
Me.btnCancelar.Text = "Cancelar"
Me.btnCancelar.UseVisualStyleBackColor = True
'
'frmBuscar
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(820, 442)
Me.Controls.Add(Me.btnCancelar)
Me.Controls.Add(Me.chkTercero)
Me.Controls.Add(Me.chkTexto)
Me.Controls.Add(Me.chkFechas)
Me.Controls.Add(Me.btnBuscar)
Me.Controls.Add(Me.btnAceptar)
Me.Controls.Add(Me.lblDoc)
Me.Controls.Add(Me.dtpFechaFin)
Me.Controls.Add(Me.dtpFechaIni)
Me.Controls.Add(Me.cmbTercero)
Me.Controls.Add(Me.txtTexto)
Me.Controls.Add(Me.txtDocumento)
Me.Controls.Add(Me.grDet)
Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
Me.Name = "frmBuscar"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "Buscar"
CType(Me.grDet, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents grDet As System.Windows.Forms.DataGridView
    Friend WithEvents txtDocumento As System.Windows.Forms.TextBox
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents cmbTercero As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFechaIni As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFin As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkFechas As System.Windows.Forms.CheckBox
    Friend WithEvents chkTexto As System.Windows.Forms.CheckBox
    Friend WithEvents chkTercero As System.Windows.Forms.CheckBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
