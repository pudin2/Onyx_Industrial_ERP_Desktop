<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddMONotificacion
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
Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
Me.lblOperarioID = New System.Windows.Forms.Label()
Me.cmbOperarios = New System.Windows.Forms.ComboBox()
Me.Label24 = New System.Windows.Forms.Label()
Me.btnAdicionarMO = New System.Windows.Forms.Button()
Me.Label13 = New System.Windows.Forms.Label()
Me.txtCantMO = New System.Windows.Forms.TextBox()
Me.Label48 = New System.Windows.Forms.Label()
Me.grRecursos = New System.Windows.Forms.DataGridView()
Me.colRecurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colHoraRecurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.colRecurso_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.btnAceptar = New System.Windows.Forms.Button()
Me.btnCancelar = New System.Windows.Forms.Button()
CType(Me.grRecursos, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'lblOperarioID
'
Me.lblOperarioID.AutoSize = True
Me.lblOperarioID.Location = New System.Drawing.Point(440, 15)
Me.lblOperarioID.Name = "lblOperarioID"
Me.lblOperarioID.Size = New System.Drawing.Size(45, 13)
Me.lblOperarioID.TabIndex = 120
Me.lblOperarioID.Text = "Label10"
'
'cmbOperarios
'
Me.cmbOperarios.FormattingEnabled = True
Me.cmbOperarios.Location = New System.Drawing.Point(65, 7)
Me.cmbOperarios.Name = "cmbOperarios"
Me.cmbOperarios.Size = New System.Drawing.Size(333, 21)
Me.cmbOperarios.TabIndex = 119
'
'Label24
'
Me.Label24.AutoSize = True
Me.Label24.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
Me.Label24.Location = New System.Drawing.Point(217, 36)
Me.Label24.Name = "Label24"
Me.Label24.Size = New System.Drawing.Size(37, 15)
Me.Label24.TabIndex = 118
Me.Label24.Text = "Horas"
'
'btnAdicionarMO
'
Me.btnAdicionarMO.Location = New System.Drawing.Point(260, 33)
Me.btnAdicionarMO.Name = "btnAdicionarMO"
Me.btnAdicionarMO.Size = New System.Drawing.Size(139, 20)
Me.btnAdicionarMO.TabIndex = 117
Me.btnAdicionarMO.Text = "Adicionar"
Me.btnAdicionarMO.UseVisualStyleBackColor = True
'
'Label13
'
Me.Label13.AutoSize = True
Me.Label13.Location = New System.Drawing.Point(7, 37)
Me.Label13.Name = "Label13"
Me.Label13.Size = New System.Drawing.Size(49, 13)
Me.Label13.TabIndex = 116
Me.Label13.Text = "Cantidad"
'
'txtCantMO
'
Me.txtCantMO.Location = New System.Drawing.Point(65, 33)
Me.txtCantMO.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.txtCantMO.Name = "txtCantMO"
Me.txtCantMO.Size = New System.Drawing.Size(146, 20)
Me.txtCantMO.TabIndex = 114
'
'Label48
'
Me.Label48.AutoSize = True
Me.Label48.Location = New System.Drawing.Point(7, 10)
Me.Label48.Name = "Label48"
Me.Label48.Size = New System.Drawing.Size(47, 13)
Me.Label48.TabIndex = 115
Me.Label48.Text = "Operario"
'
'grRecursos
'
Me.grRecursos.AllowUserToAddRows = False
Me.grRecursos.AllowUserToDeleteRows = False
DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grRecursos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
Me.grRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grRecursos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRecurso, Me.colHoraRecurso, Me.colRecurso_Id})
DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
Me.grRecursos.DefaultCellStyle = DataGridViewCellStyle2
Me.grRecursos.Location = New System.Drawing.Point(65, 59)
Me.grRecursos.Name = "grRecursos"
Me.grRecursos.ReadOnly = True
DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
Me.grRecursos.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
Me.grRecursos.RowHeadersVisible = False
Me.grRecursos.Size = New System.Drawing.Size(489, 284)
Me.grRecursos.TabIndex = 113
'
'colRecurso
'
Me.colRecurso.HeaderText = "Recurso"
Me.colRecurso.Name = "colRecurso"
Me.colRecurso.ReadOnly = True
Me.colRecurso.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
Me.colRecurso.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
Me.colRecurso.Width = 300
'
'colHoraRecurso
'
Me.colHoraRecurso.HeaderText = "Horas"
Me.colHoraRecurso.Name = "colHoraRecurso"
Me.colHoraRecurso.ReadOnly = True
'
'colRecurso_Id
'
Me.colRecurso_Id.HeaderText = "colRecurso_Id"
Me.colRecurso_Id.Name = "colRecurso_Id"
Me.colRecurso_Id.ReadOnly = True
Me.colRecurso_Id.Visible = False
'
'btnAceptar
'
Me.btnAceptar.Location = New System.Drawing.Point(452, 352)
Me.btnAceptar.Name = "btnAceptar"
Me.btnAceptar.Size = New System.Drawing.Size(102, 27)
Me.btnAceptar.TabIndex = 122
Me.btnAceptar.Text = "Aceptar"
Me.btnAceptar.UseVisualStyleBackColor = True
'
'btnCancelar
'
Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancelar.Location = New System.Drawing.Point(65, 352)
Me.btnCancelar.Name = "btnCancelar"
Me.btnCancelar.Size = New System.Drawing.Size(102, 27)
Me.btnCancelar.TabIndex = 123
Me.btnCancelar.Text = "Cancelar"
Me.btnCancelar.UseVisualStyleBackColor = True
'
'frmAddMONotificacion
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(567, 387)
Me.Controls.Add(Me.btnCancelar)
Me.Controls.Add(Me.btnAceptar)
Me.Controls.Add(Me.lblOperarioID)
Me.Controls.Add(Me.cmbOperarios)
Me.Controls.Add(Me.Label24)
Me.Controls.Add(Me.btnAdicionarMO)
Me.Controls.Add(Me.Label13)
Me.Controls.Add(Me.txtCantMO)
Me.Controls.Add(Me.Label48)
Me.Controls.Add(Me.grRecursos)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
Me.MaximizeBox = False
Me.MinimizeBox = False
Me.Name = "frmAddMONotificacion"
Me.Text = "Adicionar Mano de Obra"
CType(Me.grRecursos, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents lblOperarioID As System.Windows.Forms.Label
    Friend WithEvents cmbOperarios As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents btnAdicionarMO As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtCantMO As System.Windows.Forms.TextBox
    Public WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents grRecursos As System.Windows.Forms.DataGridView
    Friend WithEvents colRecurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHoraRecurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecurso_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
