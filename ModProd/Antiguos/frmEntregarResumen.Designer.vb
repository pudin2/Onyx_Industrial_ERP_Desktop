<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEntregarResumen
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
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmbEntregas = New System.Windows.Forms.ComboBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.lblSede = New System.Windows.Forms.Label()
    Me.lblPlanta = New System.Windows.Forms.Label()
    Me.lblArea = New System.Windows.Forms.Label()
    Me.cmbProductos = New System.Windows.Forms.ComboBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.txtCantidad = New System.Windows.Forms.MaskedTextBox()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtObservacion = New System.Windows.Forms.TextBox()
    Me.btnValidar = New System.Windows.Forms.Button()
    Me.grDetalle = New System.Windows.Forms.DataGridView()
    Me.cmbMotivos = New System.Windows.Forms.ComboBox()
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(16, 25)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(85, 13)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Notas de Salida:"
    '
    'cmbEntregas
    '
    Me.cmbEntregas.FormattingEnabled = True
    Me.cmbEntregas.Location = New System.Drawing.Point(107, 22)
    Me.cmbEntregas.Name = "cmbEntregas"
    Me.cmbEntregas.Size = New System.Drawing.Size(187, 21)
    Me.cmbEntregas.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(16, 46)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(35, 13)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "Sede:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(16, 73)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(40, 13)
    Me.Label3.TabIndex = 4
    Me.Label3.Text = "Planta:"
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(16, 98)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(32, 13)
    Me.Label4.TabIndex = 5
    Me.Label4.Text = "Area:"
    '
    'lblSede
    '
    Me.lblSede.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblSede.Location = New System.Drawing.Point(107, 46)
    Me.lblSede.Name = "lblSede"
    Me.lblSede.Size = New System.Drawing.Size(187, 21)
    Me.lblSede.TabIndex = 6
    '
    'lblPlanta
    '
    Me.lblPlanta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblPlanta.Location = New System.Drawing.Point(107, 72)
    Me.lblPlanta.Name = "lblPlanta"
    Me.lblPlanta.Size = New System.Drawing.Size(187, 21)
    Me.lblPlanta.TabIndex = 7
    '
    'lblArea
    '
    Me.lblArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblArea.Location = New System.Drawing.Point(107, 97)
    Me.lblArea.Name = "lblArea"
    Me.lblArea.Size = New System.Drawing.Size(187, 21)
    Me.lblArea.TabIndex = 8
    '
    'cmbProductos
    '
    Me.cmbProductos.FormattingEnabled = True
    Me.cmbProductos.Location = New System.Drawing.Point(107, 164)
    Me.cmbProductos.Name = "cmbProductos"
    Me.cmbProductos.Size = New System.Drawing.Size(496, 21)
    Me.cmbProductos.TabIndex = 9
    Me.cmbProductos.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(16, 167)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(53, 13)
    Me.Label5.TabIndex = 10
    Me.Label5.Text = "Producto:"
    Me.Label5.Visible = False
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(16, 194)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(52, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "Cantidad:"
    Me.Label6.Visible = False
    '
    'txtCantidad
    '
    Me.txtCantidad.Location = New System.Drawing.Point(107, 191)
    Me.txtCantidad.Mask = "99999"
    Me.txtCantidad.Name = "txtCantidad"
    Me.txtCantidad.Size = New System.Drawing.Size(109, 20)
    Me.txtCantidad.TabIndex = 12
    Me.txtCantidad.ValidatingType = GetType(Integer)
    Me.txtCantidad.Visible = False
    '
    'btnGrabar
    '
    Me.btnGrabar.Location = New System.Drawing.Point(289, 191)
    Me.btnGrabar.Name = "btnGrabar"
    Me.btnGrabar.Size = New System.Drawing.Size(103, 28)
    Me.btnGrabar.TabIndex = 13
    Me.btnGrabar.Text = "&Grabar"
    Me.btnGrabar.UseVisualStyleBackColor = True
    '
    'dtpFecha
    '
    Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFecha.Location = New System.Drawing.Point(300, 25)
    Me.dtpFecha.Name = "dtpFecha"
    Me.dtpFecha.Size = New System.Drawing.Size(106, 20)
    Me.dtpFecha.TabIndex = 14
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(16, 124)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(70, 13)
    Me.Label7.TabIndex = 16
    Me.Label7.Text = "Observación:"
    '
    'txtObservacion
    '
    Me.txtObservacion.Location = New System.Drawing.Point(107, 121)
    Me.txtObservacion.MaxLength = 500
    Me.txtObservacion.Multiline = True
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservacion.Size = New System.Drawing.Size(415, 37)
    Me.txtObservacion.TabIndex = 15
    '
    'btnValidar
    '
    Me.btnValidar.Location = New System.Drawing.Point(398, 191)
    Me.btnValidar.Name = "btnValidar"
    Me.btnValidar.Size = New System.Drawing.Size(103, 28)
    Me.btnValidar.TabIndex = 17
    Me.btnValidar.Text = "Validar"
    Me.btnValidar.UseVisualStyleBackColor = True
    '
    'grDetalle
    '
    Me.grDetalle.AllowUserToAddRows = False
    Me.grDetalle.AllowUserToDeleteRows = False
    Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalle.Location = New System.Drawing.Point(12, 225)
    Me.grDetalle.Name = "grDetalle"
    Me.grDetalle.Size = New System.Drawing.Size(811, 242)
    Me.grDetalle.TabIndex = 18
    '
    'cmbMotivos
    '
    Me.cmbMotivos.FormattingEnabled = True
    Me.cmbMotivos.Location = New System.Drawing.Point(520, 72)
    Me.cmbMotivos.Name = "cmbMotivos"
    Me.cmbMotivos.Size = New System.Drawing.Size(223, 21)
    Me.cmbMotivos.TabIndex = 19
    '
    'frmEntregarResumen
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(835, 474)
    Me.Controls.Add(Me.cmbMotivos)
    Me.Controls.Add(Me.grDetalle)
    Me.Controls.Add(Me.btnValidar)
    Me.Controls.Add(Me.Label7)
    Me.Controls.Add(Me.txtObservacion)
    Me.Controls.Add(Me.dtpFecha)
    Me.Controls.Add(Me.btnGrabar)
    Me.Controls.Add(Me.txtCantidad)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.cmbProductos)
    Me.Controls.Add(Me.lblArea)
    Me.Controls.Add(Me.lblPlanta)
    Me.Controls.Add(Me.lblSede)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.cmbEntregas)
    Me.Controls.Add(Me.Label1)
    Me.MaximizeBox = False
    Me.Name = "frmEntregarResumen"
    Me.Text = "Resumen de producción"
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmbEntregas As System.Windows.Forms.ComboBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents lblSede As System.Windows.Forms.Label
  Friend WithEvents lblPlanta As System.Windows.Forms.Label
  Friend WithEvents lblArea As System.Windows.Forms.Label
  Friend WithEvents cmbProductos As System.Windows.Forms.ComboBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents txtCantidad As System.Windows.Forms.MaskedTextBox
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
  Friend WithEvents btnValidar As System.Windows.Forms.Button
  Friend WithEvents grDetalle As System.Windows.Forms.DataGridView
  Friend WithEvents cmbMotivos As System.Windows.Forms.ComboBox
End Class
