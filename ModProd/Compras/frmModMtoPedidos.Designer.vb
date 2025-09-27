<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmModMtoPedidos
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
Me.txtCntDepurar = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.txtCntCompra = New System.Windows.Forms.TextBox()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtCntPedido = New System.Windows.Forms.TextBox()
Me.Label1 = New System.Windows.Forms.Label()
Me.txtObservacion = New System.Windows.Forms.TextBox()
Me.btnCancelar = New System.Windows.Forms.Button()
Me.btnActualizar = New System.Windows.Forms.Button()
Me.txtBorrados = New System.Windows.Forms.TextBox()
Me.Label4 = New System.Windows.Forms.Label()
Me.grpCambiaEstado.SuspendLayout()
Me.SuspendLayout()
'
'grpCambiaEstado
'
Me.grpCambiaEstado.Controls.Add(Me.txtBorrados)
Me.grpCambiaEstado.Controls.Add(Me.Label4)
Me.grpCambiaEstado.Controls.Add(Me.txtCntDepurar)
Me.grpCambiaEstado.Controls.Add(Me.Label3)
Me.grpCambiaEstado.Controls.Add(Me.txtCntCompra)
Me.grpCambiaEstado.Controls.Add(Me.Label2)
Me.grpCambiaEstado.Controls.Add(Me.txtCntPedido)
Me.grpCambiaEstado.Controls.Add(Me.Label1)
Me.grpCambiaEstado.Controls.Add(Me.txtObservacion)
Me.grpCambiaEstado.Controls.Add(Me.btnCancelar)
Me.grpCambiaEstado.Controls.Add(Me.btnActualizar)
Me.grpCambiaEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.grpCambiaEstado.Location = New System.Drawing.Point(16, 15)
Me.grpCambiaEstado.Margin = New System.Windows.Forms.Padding(4)
Me.grpCambiaEstado.Name = "grpCambiaEstado"
Me.grpCambiaEstado.Padding = New System.Windows.Forms.Padding(4)
Me.grpCambiaEstado.Size = New System.Drawing.Size(747, 312)
Me.grpCambiaEstado.TabIndex = 95
Me.grpCambiaEstado.TabStop = False
Me.grpCambiaEstado.Text = "Eliminar Pedido no procesado"
'
'txtCntDepurar
'
Me.txtCntDepurar.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtCntDepurar.Location = New System.Drawing.Point(308, 58)
Me.txtCntDepurar.Name = "txtCntDepurar"
Me.txtCntDepurar.Size = New System.Drawing.Size(100, 22)
Me.txtCntDepurar.TabIndex = 90
Me.txtCntDepurar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label3.Location = New System.Drawing.Point(239, 61)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(62, 17)
Me.Label3.TabIndex = 89
Me.Label3.Text = "Eliminar:"
'
'txtCntCompra
'
Me.txtCntCompra.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtCntCompra.Location = New System.Drawing.Point(97, 61)
Me.txtCntCompra.Name = "txtCntCompra"
Me.txtCntCompra.ReadOnly = True
Me.txtCntCompra.Size = New System.Drawing.Size(100, 22)
Me.txtCntCompra.TabIndex = 88
Me.txtCntCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label2.Location = New System.Drawing.Point(9, 64)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(86, 17)
Me.Label2.TabIndex = 87
Me.Label2.Text = "Cnt Compra:"
'
'txtCntPedido
'
Me.txtCntPedido.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtCntPedido.Location = New System.Drawing.Point(97, 33)
Me.txtCntPedido.Name = "txtCntPedido"
Me.txtCntPedido.ReadOnly = True
Me.txtCntPedido.Size = New System.Drawing.Size(100, 22)
Me.txtCntPedido.TabIndex = 86
Me.txtCntPedido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label1.Location = New System.Drawing.Point(9, 36)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(81, 17)
Me.Label1.TabIndex = 85
Me.Label1.Text = "Cnt Pedido:"
'
'txtObservacion
'
Me.txtObservacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtObservacion.Location = New System.Drawing.Point(8, 90)
Me.txtObservacion.Margin = New System.Windows.Forms.Padding(4)
Me.txtObservacion.MaxLength = 500
Me.txtObservacion.Multiline = True
Me.txtObservacion.Name = "txtObservacion"
Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtObservacion.Size = New System.Drawing.Size(727, 161)
Me.txtObservacion.TabIndex = 84
'
'btnCancelar
'
Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnCancelar.Location = New System.Drawing.Point(413, 259)
Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4)
Me.btnCancelar.Name = "btnCancelar"
Me.btnCancelar.Size = New System.Drawing.Size(225, 37)
Me.btnCancelar.TabIndex = 83
Me.btnCancelar.Text = "Cancelar"
Me.btnCancelar.UseVisualStyleBackColor = True
'
'btnActualizar
'
Me.btnActualizar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.btnActualizar.Location = New System.Drawing.Point(110, 259)
Me.btnActualizar.Margin = New System.Windows.Forms.Padding(4)
Me.btnActualizar.Name = "btnActualizar"
Me.btnActualizar.Size = New System.Drawing.Size(225, 37)
Me.btnActualizar.TabIndex = 82
Me.btnActualizar.Text = "Actualizar"
Me.btnActualizar.UseVisualStyleBackColor = True
'
'txtBorrados
'
Me.txtBorrados.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.txtBorrados.Location = New System.Drawing.Point(308, 32)
Me.txtBorrados.Name = "txtBorrados"
Me.txtBorrados.ReadOnly = True
Me.txtBorrados.Size = New System.Drawing.Size(100, 22)
Me.txtBorrados.TabIndex = 92
Me.txtBorrados.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
'
'Label4
'
Me.Label4.AutoSize = True
Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
Me.Label4.Location = New System.Drawing.Point(239, 35)
Me.Label4.Name = "Label4"
Me.Label4.Size = New System.Drawing.Size(70, 17)
Me.Label4.TabIndex = 91
Me.Label4.Text = "Borrados:"
'
'frmModMtoPedidos
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.CancelButton = Me.btnCancelar
Me.ClientSize = New System.Drawing.Size(776, 352)
Me.Controls.Add(Me.grpCambiaEstado)
Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
Me.Margin = New System.Windows.Forms.Padding(4)
Me.Name = "frmModMtoPedidos"
Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
Me.Text = "frmModMtoPedidos"
Me.grpCambiaEstado.ResumeLayout(False)
Me.grpCambiaEstado.PerformLayout()
Me.ResumeLayout(False)

End Sub
  Friend WithEvents grpCambiaEstado As System.Windows.Forms.GroupBox
  Friend WithEvents btnCancelar As System.Windows.Forms.Button
  Friend WithEvents btnActualizar As System.Windows.Forms.Button
  Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtCntDepurar As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents txtCntCompra As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents txtCntPedido As System.Windows.Forms.TextBox
  Friend WithEvents txtBorrados As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
