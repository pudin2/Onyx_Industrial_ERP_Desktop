<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntMPNoCreada
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
    Me.cmbCotizacion = New System.Windows.Forms.ComboBox()
    Me.grProductos = New System.Windows.Forms.DataGridView()
    Me.brnGrabar = New System.Windows.Forms.Button()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmbCotizacion
    '
    Me.cmbCotizacion.FormattingEnabled = True
    Me.cmbCotizacion.Location = New System.Drawing.Point(12, 12)
    Me.cmbCotizacion.Name = "cmbCotizacion"
    Me.cmbCotizacion.Size = New System.Drawing.Size(167, 21)
    Me.cmbCotizacion.TabIndex = 0
    '
    'grProductos
    '
    Me.grProductos.AllowUserToAddRows = False
    Me.grProductos.AllowUserToDeleteRows = False
    Me.grProductos.AllowUserToOrderColumns = True
    Me.grProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
    Me.grProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grProductos.Location = New System.Drawing.Point(12, 39)
    Me.grProductos.Name = "grProductos"
    Me.grProductos.Size = New System.Drawing.Size(625, 238)
    Me.grProductos.TabIndex = 1
    '
    'brnGrabar
    '
    Me.brnGrabar.Location = New System.Drawing.Point(185, 12)
    Me.brnGrabar.Name = "brnGrabar"
    Me.brnGrabar.Size = New System.Drawing.Size(90, 24)
    Me.brnGrabar.TabIndex = 2
    Me.brnGrabar.Text = "Grabar"
    Me.brnGrabar.UseVisualStyleBackColor = True
    '
    'frmMntMPNoCreada
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(649, 289)
    Me.Controls.Add(Me.brnGrabar)
    Me.Controls.Add(Me.grProductos)
    Me.Controls.Add(Me.cmbCotizacion)
    Me.MaximizeBox = False
    Me.Name = "frmMntMPNoCreada"
    Me.Text = "Mantenimiento MP No Creada"
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents cmbCotizacion As System.Windows.Forms.ComboBox
  Friend WithEvents grProductos As System.Windows.Forms.DataGridView
  Friend WithEvents brnGrabar As System.Windows.Forms.Button
End Class
