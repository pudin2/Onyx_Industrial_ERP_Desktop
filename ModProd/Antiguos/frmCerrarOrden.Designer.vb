<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCerrarOrden
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
Me.cmdGrabar = New System.Windows.Forms.Button()
Me.Label1 = New System.Windows.Forms.Label()
Me.cmbOrdenes = New System.Windows.Forms.ComboBox()
Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
Me.grDetalle = New System.Windows.Forms.DataGridView()
Me.Label2 = New System.Windows.Forms.Label()
Me.txtObservacion = New System.Windows.Forms.TextBox()
Me.Label3 = New System.Windows.Forms.Label()
Me.cmdValidar = New System.Windows.Forms.Button()
CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'cmdGrabar
'
Me.cmdGrabar.Location = New System.Drawing.Point(452, 8)
Me.cmdGrabar.Name = "cmdGrabar"
Me.cmdGrabar.Size = New System.Drawing.Size(75, 23)
Me.cmdGrabar.TabIndex = 0
Me.cmdGrabar.Text = "Grabar"
Me.cmdGrabar.UseVisualStyleBackColor = True
'
'Label1
'
Me.Label1.AutoSize = True
Me.Label1.Location = New System.Drawing.Point(12, 13)
Me.Label1.Name = "Label1"
Me.Label1.Size = New System.Drawing.Size(94, 13)
Me.Label1.TabIndex = 2
Me.Label1.Text = "Numero de Orden:"
'
'cmbOrdenes
'
Me.cmbOrdenes.FormattingEnabled = True
Me.cmbOrdenes.Location = New System.Drawing.Point(112, 10)
Me.cmbOrdenes.Name = "cmbOrdenes"
Me.cmbOrdenes.Size = New System.Drawing.Size(206, 21)
Me.cmbOrdenes.TabIndex = 1
'
'dtpFecha
'
Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
Me.dtpFecha.Location = New System.Drawing.Point(331, 11)
Me.dtpFecha.Name = "dtpFecha"
Me.dtpFecha.Size = New System.Drawing.Size(106, 20)
Me.dtpFecha.TabIndex = 3
'
'grDetalle
'
Me.grDetalle.AllowUserToAddRows = False
Me.grDetalle.AllowUserToDeleteRows = False
Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.grDetalle.Location = New System.Drawing.Point(12, 100)
Me.grDetalle.Name = "grDetalle"
Me.grDetalle.Size = New System.Drawing.Size(685, 242)
Me.grDetalle.TabIndex = 4
'
'Label2
'
Me.Label2.AutoSize = True
Me.Label2.Location = New System.Drawing.Point(12, 84)
Me.Label2.Name = "Label2"
Me.Label2.Size = New System.Drawing.Size(111, 13)
Me.Label2.TabIndex = 5
Me.Label2.Text = "Productos de la orden"
'
'txtObservacion
'
Me.txtObservacion.Location = New System.Drawing.Point(112, 35)
Me.txtObservacion.MaxLength = 500
Me.txtObservacion.Multiline = True
Me.txtObservacion.Name = "txtObservacion"
Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
Me.txtObservacion.Size = New System.Drawing.Size(415, 37)
Me.txtObservacion.TabIndex = 6
'
'Label3
'
Me.Label3.AutoSize = True
Me.Label3.Location = New System.Drawing.Point(15, 38)
Me.Label3.Name = "Label3"
Me.Label3.Size = New System.Drawing.Size(70, 13)
Me.Label3.TabIndex = 7
Me.Label3.Text = "Observación:"
'
'cmdValidar
'
Me.cmdValidar.Location = New System.Drawing.Point(533, 8)
Me.cmdValidar.Name = "cmdValidar"
Me.cmdValidar.Size = New System.Drawing.Size(75, 23)
Me.cmdValidar.TabIndex = 8
Me.cmdValidar.Text = "Validar"
Me.cmdValidar.UseVisualStyleBackColor = True
'
'frmCerrarOrden
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(712, 354)
Me.Controls.Add(Me.cmdValidar)
Me.Controls.Add(Me.Label3)
Me.Controls.Add(Me.txtObservacion)
Me.Controls.Add(Me.Label2)
Me.Controls.Add(Me.grDetalle)
Me.Controls.Add(Me.dtpFecha)
Me.Controls.Add(Me.Label1)
Me.Controls.Add(Me.cmbOrdenes)
Me.Controls.Add(Me.cmdGrabar)
Me.MaximizeBox = False
Me.Name = "frmCerrarOrden"
Me.Text = "Cerrar Orden"
CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)
Me.PerformLayout()

End Sub
    Friend WithEvents cmdGrabar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbOrdenes As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdValidar As System.Windows.Forms.Button
End Class
