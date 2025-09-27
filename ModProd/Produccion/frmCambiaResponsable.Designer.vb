<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiaResponsable
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
Me.grpCambiaEstado = New System.Windows.Forms.GroupBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.lblSubtarea = New System.Windows.Forms.Label()
Me.lstOperarios = New System.Windows.Forms.ListBox()
Me.btnCancelar = New System.Windows.Forms.Button()
Me.btnCambiarEstado = New System.Windows.Forms.Button()
Me.txtSubtarea = New System.Windows.Forms.TextBox()
Me.grpCambiaEstado.SuspendLayout()
Me.SuspendLayout()
'
'grpCambiaEstado
'
Me.grpCambiaEstado.Controls.Add(Me.txtSubtarea)
Me.grpCambiaEstado.Controls.Add(Me.Label1)
Me.grpCambiaEstado.Controls.Add(Me.lblSubtarea)
Me.grpCambiaEstado.Controls.Add(Me.lstOperarios)
Me.grpCambiaEstado.Controls.Add(Me.btnCancelar)
Me.grpCambiaEstado.Controls.Add(Me.btnCambiarEstado)
Me.grpCambiaEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.grpCambiaEstado.Location = New System.Drawing.Point(13, 7)
Me.grpCambiaEstado.Margin = New System.Windows.Forms.Padding(4)
Me.grpCambiaEstado.Name = "grpCambiaEstado"
Me.grpCambiaEstado.Padding = New System.Windows.Forms.Padding(4)
Me.grpCambiaEstado.Size = New System.Drawing.Size(831, 470)
Me.grpCambiaEstado.TabIndex = 95
Me.grpCambiaEstado.TabStop = False
Me.grpCambiaEstado.Text = "Cambiar Responsable"
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(380, 435)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(59, 20)
Me.Label1.TabIndex = 96
Me.Label1.Text = "Label1"
Me.Label1.Visible = False
'
'lblSubtarea
'
Me.lblSubtarea.AutoSize = True
Me.lblSubtarea.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lblSubtarea.Location = New System.Drawing.Point(7, 410)
Me.lblSubtarea.Name = "lblSubtarea"
Me.lblSubtarea.Size = New System.Drawing.Size(45, 25)
Me.lblSubtarea.TabIndex = 85
Me.lblSubtarea.Text = "000"
Me.lblSubtarea.Visible = False
'
'lstOperarios
'
Me.lstOperarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.lstOperarios.FormattingEnabled = True
Me.lstOperarios.ItemHeight = 22
Me.lstOperarios.Location = New System.Drawing.Point(7, 125)
Me.lstOperarios.Name = "lstOperarios"
Me.lstOperarios.Size = New System.Drawing.Size(817, 290)
Me.lstOperarios.TabIndex = 84
'
'btnCancelar
'
Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCancelar.Location = New System.Drawing.Point(506, 424)
Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
Me.btnCancelar.Name = "btnCancelar"
Me.btnCancelar.Size = New System.Drawing.Size(225, 37)
Me.btnCancelar.TabIndex = 83
Me.btnCancelar.Text = "Cancelar"
Me.btnCancelar.UseVisualStyleBackColor = True
'
'btnCambiarEstado
'
Me.btnCambiarEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCambiarEstado.Location = New System.Drawing.Point(101, 424)
Me.btnCambiarEstado.Margin = New System.Windows.Forms.Padding(4)
Me.btnCambiarEstado.Name = "btnCambiarEstado"
Me.btnCambiarEstado.Size = New System.Drawing.Size(225, 37)
Me.btnCambiarEstado.TabIndex = 82
Me.btnCambiarEstado.Text = "Actualizar"
Me.btnCambiarEstado.UseVisualStyleBackColor = True
'
'txtSubtarea
'
Me.txtSubtarea.Location = New System.Drawing.Point(7, 27)
Me.txtSubtarea.Multiline = True
Me.txtSubtarea.Name = "txtSubtarea"
Me.txtSubtarea.ReadOnly = True
Me.txtSubtarea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtSubtarea.Size = New System.Drawing.Size(817, 92)
Me.txtSubtarea.TabIndex = 97
'
'frmCambiaResponsable
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnCancelar
Me.ClientSize = New System.Drawing.Size(857, 490)
Me.Controls.Add(Me.grpCambiaEstado)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmCambiaResponsable"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "frmCambiaResponsable"
Me.grpCambiaEstado.ResumeLayout(False)
Me.grpCambiaEstado.PerformLayout()
Me.ResumeLayout(False)

End Sub
    Friend WithEvents grpCambiaEstado As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnCambiarEstado As System.Windows.Forms.Button
    Friend WithEvents lstOperarios As System.Windows.Forms.ListBox
    Friend WithEvents lblSubtarea As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSubtarea As System.Windows.Forms.TextBox
End Class
