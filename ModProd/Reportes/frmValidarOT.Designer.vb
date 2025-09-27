<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidarOT
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
        Me.chkPlanos = New System.Windows.Forms.CheckBox()
        Me.cmbAsignadaA = New System.Windows.Forms.ComboBox()
        Me.cmdValidar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.lblOT = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'chkPlanos
        '
        Me.chkPlanos.AutoSize = True
        Me.chkPlanos.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPlanos.Location = New System.Drawing.Point(22, 12)
        Me.chkPlanos.Name = "chkPlanos"
        Me.chkPlanos.Size = New System.Drawing.Size(82, 17)
        Me.chkPlanos.TabIndex = 9
        Me.chkPlanos.Text = "Planos        "
        Me.chkPlanos.UseVisualStyleBackColor = True
        '
        'cmbAsignadaA
        '
        Me.cmbAsignadaA.BackColor = System.Drawing.SystemColors.Window
        Me.cmbAsignadaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAsignadaA.FormattingEnabled = True
        Me.cmbAsignadaA.Location = New System.Drawing.Point(22, 35)
        Me.cmbAsignadaA.MaxDropDownItems = 10
        Me.cmbAsignadaA.Name = "cmbAsignadaA"
        Me.cmbAsignadaA.Size = New System.Drawing.Size(462, 21)
        Me.cmbAsignadaA.TabIndex = 8
        '
        'cmdValidar
        '
        Me.cmdValidar.Location = New System.Drawing.Point(22, 62)
        Me.cmdValidar.Name = "cmdValidar"
        Me.cmdValidar.Size = New System.Drawing.Size(121, 26)
        Me.cmdValidar.TabIndex = 10
        Me.cmdValidar.Text = "Validar"
        Me.cmdValidar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Location = New System.Drawing.Point(149, 62)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(121, 26)
        Me.cmdCancelar.TabIndex = 11
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'lblOT
        '
        Me.lblOT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOT.Location = New System.Drawing.Point(376, 5)
        Me.lblOT.Name = "lblOT"
        Me.lblOT.Size = New System.Drawing.Size(108, 22)
        Me.lblOT.TabIndex = 12
        Me.lblOT.Text = "OT"
        '
        'frmValidarOT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 107)
        Me.Controls.Add(Me.lblOT)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdValidar)
        Me.Controls.Add(Me.chkPlanos)
        Me.Controls.Add(Me.cmbAsignadaA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmValidarOT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validar OT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub
    Friend WithEvents chkPlanos As System.Windows.Forms.CheckBox
    Friend WithEvents cmbAsignadaA As System.Windows.Forms.ComboBox
    Friend WithEvents cmdValidar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents lblOT As System.Windows.Forms.Label
End Class
