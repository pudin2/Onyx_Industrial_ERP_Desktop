<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAsignarAlArea
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
    Me.cmbArea = New System.Windows.Forms.ComboBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.lblCotizacion = New System.Windows.Forms.Label()
    Me.txtProyecto = New System.Windows.Forms.TextBox()
    Me.lblCliente = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.cmbEmpleados = New System.Windows.Forms.ComboBox()
    Me.Label6 = New System.Windows.Forms.Label()
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'cmdGrabar
    '
    Me.cmdGrabar.Location = New System.Drawing.Point(264, 105)
    Me.cmdGrabar.Name = "cmdGrabar"
    Me.cmdGrabar.Size = New System.Drawing.Size(117, 23)
    Me.cmdGrabar.TabIndex = 5
    Me.cmdGrabar.Text = "Grabar"
    Me.cmdGrabar.UseVisualStyleBackColor = True
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 13)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(65, 13)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Número OT:"
    '
    'cmbOrdenes
    '
    Me.cmbOrdenes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
    Me.cmbOrdenes.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.cmbOrdenes.FormattingEnabled = True
    Me.cmbOrdenes.Location = New System.Drawing.Point(88, 10)
    Me.cmbOrdenes.Name = "cmbOrdenes"
    Me.cmbOrdenes.Size = New System.Drawing.Size(170, 21)
    Me.cmbOrdenes.TabIndex = 1
    '
    'dtpFecha
    '
    Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFecha.Location = New System.Drawing.Point(88, 105)
    Me.dtpFecha.Name = "dtpFecha"
    Me.dtpFecha.Size = New System.Drawing.Size(170, 20)
    Me.dtpFecha.TabIndex = 2
    '
    'grDetalle
    '
    Me.grDetalle.AllowUserToAddRows = False
    Me.grDetalle.AllowUserToDeleteRows = False
    Me.grDetalle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalle.Location = New System.Drawing.Point(12, 192)
    Me.grDetalle.Name = "grDetalle"
    Me.grDetalle.RowHeadersWidth = 20
    Me.grDetalle.Size = New System.Drawing.Size(1117, 215)
    Me.grDetalle.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 176)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(111, 13)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Productos de la orden"
    '
    'txtObservacion
    '
    Me.txtObservacion.Location = New System.Drawing.Point(88, 35)
    Me.txtObservacion.MaxLength = 500
    Me.txtObservacion.Multiline = True
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservacion.Size = New System.Drawing.Size(480, 64)
    Me.txtObservacion.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 40)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Observación:"
    '
    'cmdValidar
    '
    Me.cmdValidar.Location = New System.Drawing.Point(387, 105)
    Me.cmdValidar.Name = "cmdValidar"
    Me.cmdValidar.Size = New System.Drawing.Size(117, 23)
    Me.cmdValidar.TabIndex = 6
    Me.cmdValidar.Text = "Validar"
    Me.cmdValidar.UseVisualStyleBackColor = True
    '
    'cmbArea
    '
    Me.cmbArea.FormattingEnabled = True
    Me.cmbArea.Location = New System.Drawing.Point(318, 10)
    Me.cmbArea.Name = "cmbArea"
    Me.cmbArea.Size = New System.Drawing.Size(250, 21)
    Me.cmbArea.TabIndex = 3
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(280, 9)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(32, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Area:"
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(12, 105)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 29
    Me.Label5.Text = "Fecha:"
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Controls.Add(Me.lblCotizacion)
    Me.GroupBox1.Controls.Add(Me.txtProyecto)
    Me.GroupBox1.Controls.Add(Me.lblCliente)
    Me.GroupBox1.Controls.Add(Me.Label9)
    Me.GroupBox1.Controls.Add(Me.Label11)
    Me.GroupBox1.Location = New System.Drawing.Point(574, -3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(554, 189)
    Me.GroupBox1.TabIndex = 30
    Me.GroupBox1.TabStop = False
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(5, 38)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(59, 13)
    Me.Label7.TabIndex = 34
    Me.Label7.Text = "Cotización:"
    '
    'lblCotizacion
    '
    Me.lblCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblCotizacion.Location = New System.Drawing.Point(70, 38)
    Me.lblCotizacion.Name = "lblCotizacion"
    Me.lblCotizacion.Size = New System.Drawing.Size(443, 21)
    Me.lblCotizacion.TabIndex = 33
    Me.lblCotizacion.Text = " "
    '
    'txtProyecto
    '
    Me.txtProyecto.Location = New System.Drawing.Point(70, 65)
    Me.txtProyecto.Multiline = True
    Me.txtProyecto.Name = "txtProyecto"
    Me.txtProyecto.ReadOnly = True
    Me.txtProyecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtProyecto.Size = New System.Drawing.Size(443, 108)
    Me.txtProyecto.TabIndex = 32
    '
    'lblCliente
    '
    Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblCliente.Location = New System.Drawing.Point(70, 11)
    Me.lblCliente.Name = "lblCliente"
    Me.lblCliente.Size = New System.Drawing.Size(443, 21)
    Me.lblCliente.TabIndex = 31
    Me.lblCliente.Text = " "
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(5, 65)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(52, 13)
    Me.Label9.TabIndex = 30
    Me.Label9.Text = "Proyecto:"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(6, 9)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(42, 13)
    Me.Label11.TabIndex = 29
    Me.Label11.Text = "Cliente:"
    '
    'cmbEmpleados
    '
    Me.cmbEmpleados.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
    Me.cmbEmpleados.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.cmbEmpleados.FormattingEnabled = True
    Me.cmbEmpleados.Location = New System.Drawing.Point(88, 134)
    Me.cmbEmpleados.Name = "cmbEmpleados"
    Me.cmbEmpleados.Size = New System.Drawing.Size(416, 21)
    Me.cmbEmpleados.TabIndex = 31
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(12, 137)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(57, 13)
    Me.Label6.TabIndex = 32
    Me.Label6.Text = "Empleado:"
    '
    'frmAsignarAlArea
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1139, 415)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.cmbEmpleados)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.cmbArea)
    Me.Controls.Add(Me.cmdValidar)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.txtObservacion)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.grDetalle)
    Me.Controls.Add(Me.dtpFecha)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.cmbOrdenes)
    Me.Controls.Add(Me.cmdGrabar)
    Me.Name = "frmAsignarAlArea"
    Me.Text = "Asignar al Area"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
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
  Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
  Friend WithEvents lblCliente As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents lblCotizacion As System.Windows.Forms.Label
  Friend WithEvents cmbEmpleados As System.Windows.Forms.ComboBox
  Friend WithEvents Label6 As System.Windows.Forms.Label
End Class
