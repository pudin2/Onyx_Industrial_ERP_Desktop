<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearPT
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
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.grProductos = New System.Windows.Forms.DataGridView()
    Me.CodIventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Costo = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Total = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.txtObsInterna = New System.Windows.Forms.TextBox()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.txtObservaciones = New System.Windows.Forms.TextBox()
    Me.txtProyecto = New System.Windows.Forms.TextBox()
    Me.txtAlcance = New System.Windows.Forms.TextBox()
    Me.lblCliente = New System.Windows.Forms.Label()
    Me.Label8 = New System.Windows.Forms.Label()
    Me.Label9 = New System.Windows.Forms.Label()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label11 = New System.Windows.Forms.Label()
    Me.btnCrearPT = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Button1 = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.txtCodInventario = New System.Windows.Forms.TextBox()
    Me.txtNombrePT = New System.Windows.Forms.TextBox()
    Me.lblNumCotizacion = New System.Windows.Forms.Label()
    Me.Label7 = New System.Windows.Forms.Label()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'grProductos
    '
    Me.grProductos.AllowUserToAddRows = False
    Me.grProductos.AllowUserToDeleteRows = False
    Me.grProductos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
    Me.grProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodIventario, Me.Cantidad, Me.Costo, Me.Total})
    DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grProductos.DefaultCellStyle = DataGridViewCellStyle5
    Me.grProductos.Location = New System.Drawing.Point(553, 7)
    Me.grProductos.Name = "grProductos"
    Me.grProductos.ReadOnly = True
    DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
    Me.grProductos.RowHeadersWidth = 20
    Me.grProductos.Size = New System.Drawing.Size(529, 618)
    Me.grProductos.TabIndex = 7
    '
    'CodIventario
    '
    Me.CodIventario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.CodIventario.HeaderText = "Producto"
    Me.CodIventario.Name = "CodIventario"
    Me.CodIventario.ReadOnly = True
    Me.CodIventario.Width = 75
    '
    'Cantidad
    '
    Me.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
    Me.Cantidad.HeaderText = "Cantidad"
    Me.Cantidad.Name = "Cantidad"
    Me.Cantidad.ReadOnly = True
    Me.Cantidad.Width = 74
    '
    'Costo
    '
    Me.Costo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle3.Format = "N2"
    DataGridViewCellStyle3.NullValue = Nothing
    Me.Costo.DefaultCellStyle = DataGridViewCellStyle3
    Me.Costo.HeaderText = "Costo"
    Me.Costo.Name = "Costo"
    Me.Costo.ReadOnly = True
    Me.Costo.Width = 59
    '
    'Total
    '
    Me.Total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle4.Format = "N2"
    Me.Total.DefaultCellStyle = DataGridViewCellStyle4
    Me.Total.HeaderText = "Total"
    Me.Total.Name = "Total"
    Me.Total.ReadOnly = True
    Me.Total.Width = 56
    '
    'GroupBox3
    '
    Me.GroupBox3.Controls.Add(Me.txtObsInterna)
    Me.GroupBox3.Controls.Add(Me.Label12)
    Me.GroupBox3.Controls.Add(Me.txtObservaciones)
    Me.GroupBox3.Controls.Add(Me.txtProyecto)
    Me.GroupBox3.Controls.Add(Me.txtAlcance)
    Me.GroupBox3.Controls.Add(Me.lblCliente)
    Me.GroupBox3.Controls.Add(Me.Label8)
    Me.GroupBox3.Controls.Add(Me.Label9)
    Me.GroupBox3.Controls.Add(Me.Label10)
    Me.GroupBox3.Controls.Add(Me.Label11)
    Me.GroupBox3.Location = New System.Drawing.Point(2, 162)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(545, 463)
    Me.GroupBox3.TabIndex = 6
    Me.GroupBox3.TabStop = False
    '
    'txtObsInterna
    '
    Me.txtObsInterna.Location = New System.Drawing.Point(87, 354)
    Me.txtObsInterna.Multiline = True
    Me.txtObsInterna.Name = "txtObsInterna"
    Me.txtObsInterna.ReadOnly = True
    Me.txtObsInterna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObsInterna.Size = New System.Drawing.Size(452, 100)
    Me.txtObsInterna.TabIndex = 27
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(5, 354)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(81, 31)
    Me.Label12.TabIndex = 26
    Me.Label12.Text = "Observaciones Internas:"
    '
    'txtObservaciones
    '
    Me.txtObservaciones.Location = New System.Drawing.Point(87, 248)
    Me.txtObservaciones.Multiline = True
    Me.txtObservaciones.Name = "txtObservaciones"
    Me.txtObservaciones.ReadOnly = True
    Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservaciones.Size = New System.Drawing.Size(452, 100)
    Me.txtObservaciones.TabIndex = 25
    '
    'txtProyecto
    '
    Me.txtProyecto.Location = New System.Drawing.Point(87, 142)
    Me.txtProyecto.Multiline = True
    Me.txtProyecto.Name = "txtProyecto"
    Me.txtProyecto.ReadOnly = True
    Me.txtProyecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtProyecto.Size = New System.Drawing.Size(452, 100)
    Me.txtProyecto.TabIndex = 24
    '
    'txtAlcance
    '
    Me.txtAlcance.Location = New System.Drawing.Point(87, 36)
    Me.txtAlcance.Multiline = True
    Me.txtAlcance.Name = "txtAlcance"
    Me.txtAlcance.ReadOnly = True
    Me.txtAlcance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtAlcance.Size = New System.Drawing.Size(452, 100)
    Me.txtAlcance.TabIndex = 23
    '
    'lblCliente
    '
    Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblCliente.Location = New System.Drawing.Point(87, 12)
    Me.lblCliente.Name = "lblCliente"
    Me.lblCliente.Size = New System.Drawing.Size(452, 21)
    Me.lblCliente.TabIndex = 22
    Me.lblCliente.Text = " "
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(5, 251)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(81, 13)
    Me.Label8.TabIndex = 21
    Me.Label8.Text = "Observaciones:"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(5, 142)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(52, 13)
    Me.Label9.TabIndex = 20
    Me.Label9.Text = "Proyecto:"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.CausesValidation = False
    Me.Label10.Location = New System.Drawing.Point(5, 46)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(49, 13)
    Me.Label10.TabIndex = 19
    Me.Label10.Text = "Alcance:"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(5, 20)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(42, 13)
    Me.Label11.TabIndex = 18
    Me.Label11.Text = "Cliente:"
    '
    'btnCrearPT
    '
    Me.btnCrearPT.Location = New System.Drawing.Point(449, 10)
    Me.btnCrearPT.Name = "btnCrearPT"
    Me.btnCrearPT.Size = New System.Drawing.Size(90, 26)
    Me.btnCrearPT.TabIndex = 30
    Me.btnCrearPT.Text = "Crear PT"
    Me.btnCrearPT.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.Button1)
    Me.GroupBox1.Controls.Add(Me.Label2)
    Me.GroupBox1.Controls.Add(Me.btnCrearPT)
    Me.GroupBox1.Controls.Add(Me.Label1)
    Me.GroupBox1.Controls.Add(Me.txtCodInventario)
    Me.GroupBox1.Controls.Add(Me.txtNombrePT)
    Me.GroupBox1.Controls.Add(Me.lblNumCotizacion)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Location = New System.Drawing.Point(2, 0)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(545, 161)
    Me.GroupBox1.TabIndex = 33
    Me.GroupBox1.TabStop = False
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(347, 10)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(96, 26)
    Me.Button1.TabIndex = 41
    Me.Button1.Text = "MP No Creada"
    Me.Button1.UseVisualStyleBackColor = True
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(5, 45)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(47, 13)
    Me.Label2.TabIndex = 40
    Me.Label2.Text = "Nombre:"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(189, 14)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(43, 13)
    Me.Label1.TabIndex = 39
    Me.Label1.Text = "Código:"
    '
    'txtCodInventario
    '
    Me.txtCodInventario.Location = New System.Drawing.Point(238, 14)
    Me.txtCodInventario.MaxLength = 50
    Me.txtCodInventario.Name = "txtCodInventario"
    Me.txtCodInventario.Size = New System.Drawing.Size(98, 20)
    Me.txtCodInventario.TabIndex = 38
    '
    'txtNombrePT
    '
    Me.txtNombrePT.Location = New System.Drawing.Point(87, 38)
    Me.txtNombrePT.MaxLength = 500
    Me.txtNombrePT.Multiline = True
    Me.txtNombrePT.Name = "txtNombrePT"
    Me.txtNombrePT.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtNombrePT.Size = New System.Drawing.Size(452, 117)
    Me.txtNombrePT.TabIndex = 37
    '
    'lblNumCotizacion
    '
    Me.lblNumCotizacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblNumCotizacion.Location = New System.Drawing.Point(87, 14)
    Me.lblNumCotizacion.Name = "lblNumCotizacion"
    Me.lblNumCotizacion.Size = New System.Drawing.Size(90, 20)
    Me.lblNumCotizacion.TabIndex = 36
    Me.lblNumCotizacion.Text = " "
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(5, 14)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(59, 13)
    Me.Label7.TabIndex = 35
    Me.Label7.Text = "Cotización:"
    '
    'frmCrearPT
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1094, 631)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.grProductos)
    Me.Controls.Add(Me.GroupBox3)
    Me.Name = "frmCrearPT"
    Me.Text = "Crear PT Ziur"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents grProductos As System.Windows.Forms.DataGridView
  Friend WithEvents CodIventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Costo As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Total As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents txtObsInterna As System.Windows.Forms.TextBox
  Friend WithEvents Label12 As System.Windows.Forms.Label
  Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
  Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
  Friend WithEvents txtAlcance As System.Windows.Forms.TextBox
  Friend WithEvents lblCliente As System.Windows.Forms.Label
  Friend WithEvents Label8 As System.Windows.Forms.Label
  Friend WithEvents Label9 As System.Windows.Forms.Label
  Friend WithEvents Label10 As System.Windows.Forms.Label
  Friend WithEvents Label11 As System.Windows.Forms.Label
  Friend WithEvents btnCrearPT As System.Windows.Forms.Button
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents txtCodInventario As System.Windows.Forms.TextBox
  Friend WithEvents txtNombrePT As System.Windows.Forms.TextBox
  Friend WithEvents lblNumCotizacion As System.Windows.Forms.Label
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
