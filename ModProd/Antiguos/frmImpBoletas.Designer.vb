<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImpBoletas
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
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.optEntradas = New System.Windows.Forms.RadioButton()
    Me.optSalidas = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.optCerradas = New System.Windows.Forms.RadioButton()
    Me.optValidadas = New System.Windows.Forms.RadioButton()
    Me.lstOrdenes = New System.Windows.Forms.ListBox()
    Me.lstDocumentos = New System.Windows.Forms.ListBox()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.optEntradas)
    Me.GroupBox1.Controls.Add(Me.optSalidas)
    Me.GroupBox1.Location = New System.Drawing.Point(270, 22)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(121, 74)
    Me.GroupBox1.TabIndex = 0
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Tipo Documento"
    '
    'optEntradas
    '
    Me.optEntradas.AutoSize = True
    Me.optEntradas.Location = New System.Drawing.Point(15, 45)
    Me.optEntradas.Name = "optEntradas"
    Me.optEntradas.Size = New System.Drawing.Size(67, 17)
    Me.optEntradas.TabIndex = 1
    Me.optEntradas.Text = "Entradas"
    Me.optEntradas.UseVisualStyleBackColor = True
    '
    'optSalidas
    '
    Me.optSalidas.AutoSize = True
    Me.optSalidas.Checked = True
    Me.optSalidas.Location = New System.Drawing.Point(15, 22)
    Me.optSalidas.Name = "optSalidas"
    Me.optSalidas.Size = New System.Drawing.Size(59, 17)
    Me.optSalidas.TabIndex = 0
    Me.optSalidas.TabStop = True
    Me.optSalidas.Text = "Salidas"
    Me.optSalidas.UseVisualStyleBackColor = True
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.optCerradas)
    Me.GroupBox2.Controls.Add(Me.optValidadas)
    Me.GroupBox2.Location = New System.Drawing.Point(9, 22)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(121, 74)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Estado Orden"
    '
    'optCerradas
    '
    Me.optCerradas.AutoSize = True
    Me.optCerradas.Location = New System.Drawing.Point(15, 42)
    Me.optCerradas.Name = "optCerradas"
    Me.optCerradas.Size = New System.Drawing.Size(67, 17)
    Me.optCerradas.TabIndex = 1
    Me.optCerradas.Text = "Cerradas"
    Me.optCerradas.UseVisualStyleBackColor = True
    '
    'optValidadas
    '
    Me.optValidadas.AutoSize = True
    Me.optValidadas.Checked = True
    Me.optValidadas.Location = New System.Drawing.Point(15, 19)
    Me.optValidadas.Name = "optValidadas"
    Me.optValidadas.Size = New System.Drawing.Size(71, 17)
    Me.optValidadas.TabIndex = 0
    Me.optValidadas.TabStop = True
    Me.optValidadas.Text = "Validadas"
    Me.optValidadas.UseVisualStyleBackColor = True
    '
    'lstOrdenes
    '
    Me.lstOrdenes.FormattingEnabled = True
    Me.lstOrdenes.Location = New System.Drawing.Point(9, 102)
    Me.lstOrdenes.Name = "lstOrdenes"
    Me.lstOrdenes.Size = New System.Drawing.Size(250, 277)
    Me.lstOrdenes.TabIndex = 3
    '
    'lstDocumentos
    '
    Me.lstDocumentos.FormattingEnabled = True
    Me.lstDocumentos.Location = New System.Drawing.Point(270, 102)
    Me.lstDocumentos.Name = "lstDocumentos"
    Me.lstDocumentos.Size = New System.Drawing.Size(250, 277)
    Me.lstDocumentos.TabIndex = 4
    '
    'btnImprimir
    '
    Me.btnImprimir.Location = New System.Drawing.Point(456, 22)
    Me.btnImprimir.Name = "btnImprimir"
    Me.btnImprimir.Size = New System.Drawing.Size(63, 27)
    Me.btnImprimir.TabIndex = 5
    Me.btnImprimir.Text = "Imprimir"
    Me.btnImprimir.UseVisualStyleBackColor = True
    '
    'frmImpBoletas
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(531, 384)
    Me.Controls.Add(Me.btnImprimir)
    Me.Controls.Add(Me.lstDocumentos)
    Me.Controls.Add(Me.lstOrdenes)
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.MaximizeBox = False
    Me.Name = "frmImpBoletas"
    Me.Text = "Imprimir notas"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents optEntradas As System.Windows.Forms.RadioButton
  Friend WithEvents optSalidas As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents optCerradas As System.Windows.Forms.RadioButton
  Friend WithEvents optValidadas As System.Windows.Forms.RadioButton
  Friend WithEvents lstOrdenes As System.Windows.Forms.ListBox
  Friend WithEvents lstDocumentos As System.Windows.Forms.ListBox
  Friend WithEvents btnImprimir As System.Windows.Forms.Button
End Class
