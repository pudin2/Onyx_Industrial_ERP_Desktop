<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBuscaOP
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
    Me.grDet = New System.Windows.Forms.DataGridView()
    Me.btnAceptar = New System.Windows.Forms.Button()
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
    Me.grDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDet.Location = New System.Drawing.Point(12, 126)
    Me.grDet.Name = "grDet"
    Me.grDet.Size = New System.Drawing.Size(633, 324)
    Me.grDet.TabIndex = 3
    '
    'btnAceptar
    '
    Me.btnAceptar.Location = New System.Drawing.Point(421, 49)
    Me.btnAceptar.Name = "btnAceptar"
    Me.btnAceptar.Size = New System.Drawing.Size(121, 29)
    Me.btnAceptar.TabIndex = 4
    Me.btnAceptar.Text = "Aceptar"
    Me.btnAceptar.UseVisualStyleBackColor = True
    '
    'frmBuscaOP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(657, 462)
    Me.Controls.Add(Me.btnAceptar)
    Me.Controls.Add(Me.grDet)
    Me.Name = "frmBuscaOP"
    Me.Text = "frmBuscaOP"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.grDet, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents grDet As System.Windows.Forms.DataGridView
  Friend WithEvents btnAceptar As System.Windows.Forms.Button
End Class
