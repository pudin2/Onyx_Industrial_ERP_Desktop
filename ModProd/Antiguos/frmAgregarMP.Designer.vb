<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAgregarMP
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
    Me.cmdAgregarItem = New System.Windows.Forms.Button()
    Me.txtCantidad = New System.Windows.Forms.MaskedTextBox()
    Me.cmbProducto = New System.Windows.Forms.ComboBox()
    Me.grDetalleNuevo = New System.Windows.Forms.DataGridView()
    Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCodigoInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IdInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IdUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colAgregar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grDetalleNuevo, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'cmdGrabar
    '
    Me.cmdGrabar.Location = New System.Drawing.Point(452, 8)
    Me.cmdGrabar.Name = "cmdGrabar"
    Me.cmdGrabar.Size = New System.Drawing.Size(75, 23)
    Me.cmdGrabar.TabIndex = 5
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
    Me.dtpFecha.TabIndex = 2
    '
    'grDetalle
    '
    Me.grDetalle.AllowUserToAddRows = False
    Me.grDetalle.AllowUserToDeleteRows = False
    Me.grDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalle.Location = New System.Drawing.Point(112, 286)
    Me.grDetalle.Name = "grDetalle"
    Me.grDetalle.Size = New System.Drawing.Size(685, 157)
    Me.grDetalle.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 270)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(114, 13)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Productos de la orden:"
    '
    'txtObservacion
    '
    Me.txtObservacion.Location = New System.Drawing.Point(112, 37)
    Me.txtObservacion.MaxLength = 500
    Me.txtObservacion.Multiline = True
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservacion.Size = New System.Drawing.Size(415, 37)
    Me.txtObservacion.TabIndex = 4
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 37)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(70, 13)
    Me.Label3.TabIndex = 7
    Me.Label3.Text = "Observación:"
    '
    'cmdValidar
    '
    Me.cmdValidar.Enabled = False
    Me.cmdValidar.Location = New System.Drawing.Point(533, 8)
    Me.cmdValidar.Name = "cmdValidar"
    Me.cmdValidar.Size = New System.Drawing.Size(75, 23)
    Me.cmdValidar.TabIndex = 6
    Me.cmdValidar.Text = "Validar"
    Me.cmdValidar.UseVisualStyleBackColor = True
    '
    'cmbArea
    '
    Me.cmbArea.FormattingEnabled = True
    Me.cmbArea.Location = New System.Drawing.Point(615, 40)
    Me.cmbArea.Name = "cmbArea"
    Me.cmbArea.Size = New System.Drawing.Size(111, 21)
    Me.cmbArea.TabIndex = 3
    Me.cmbArea.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(576, 48)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(32, 13)
    Me.Label4.TabIndex = 10
    Me.Label4.Text = "Area:"
    Me.Label4.Visible = False
    '
    'cmdAgregarItem
    '
    Me.cmdAgregarItem.Location = New System.Drawing.Point(227, 107)
    Me.cmdAgregarItem.Name = "cmdAgregarItem"
    Me.cmdAgregarItem.Size = New System.Drawing.Size(132, 19)
    Me.cmdAgregarItem.TabIndex = 14
    Me.cmdAgregarItem.Text = "Adicionar"
    Me.cmdAgregarItem.UseVisualStyleBackColor = True
    '
    'txtCantidad
    '
    Me.txtCantidad.Location = New System.Drawing.Point(112, 107)
    Me.txtCantidad.Mask = "99999"
    Me.txtCantidad.Name = "txtCantidad"
    Me.txtCantidad.Size = New System.Drawing.Size(109, 20)
    Me.txtCantidad.TabIndex = 13
    Me.txtCantidad.ValidatingType = GetType(Integer)
    '
    'cmbProducto
    '
    Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
    Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.cmbProducto.DisplayMember = "NomInventario"
    Me.cmbProducto.FormattingEnabled = True
    Me.cmbProducto.Location = New System.Drawing.Point(112, 80)
    Me.cmbProducto.Name = "cmbProducto"
    Me.cmbProducto.Size = New System.Drawing.Size(599, 21)
    Me.cmbProducto.TabIndex = 12
    '
    'grDetalleNuevo
    '
    Me.grDetalleNuevo.AllowUserToAddRows = False
    Me.grDetalleNuevo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalleNuevo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.colCodigoInventario, Me.colDescripcion, Me.colCantidad, Me.IdInventario, Me.IdUnidad, Me.colAgregar})
    Me.grDetalleNuevo.Location = New System.Drawing.Point(112, 133)
    Me.grDetalleNuevo.Name = "grDetalleNuevo"
    Me.grDetalleNuevo.Size = New System.Drawing.Size(685, 134)
    Me.grDetalleNuevo.TabIndex = 11
    '
    'Id
    '
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
    Me.Id.DefaultCellStyle = DataGridViewCellStyle1
    Me.Id.Frozen = True
    Me.Id.HeaderText = "Id"
    Me.Id.Name = "Id"
    Me.Id.ReadOnly = True
    Me.Id.Width = 50
    '
    'colCodigoInventario
    '
    Me.colCodigoInventario.Frozen = True
    Me.colCodigoInventario.HeaderText = "Código"
    Me.colCodigoInventario.Name = "colCodigoInventario"
    Me.colCodigoInventario.ReadOnly = True
    Me.colCodigoInventario.Width = 70
    '
    'colDescripcion
    '
    Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.colDescripcion.Frozen = True
    Me.colDescripcion.HeaderText = "Descripción"
    Me.colDescripcion.Name = "colDescripcion"
    Me.colDescripcion.ReadOnly = True
    Me.colDescripcion.Width = 88
    '
    'colCantidad
    '
    Me.colCantidad.Frozen = True
    Me.colCantidad.HeaderText = "Cantidad"
    Me.colCantidad.Name = "colCantidad"
    Me.colCantidad.Width = 50
    '
    'IdInventario
    '
    Me.IdInventario.Frozen = True
    Me.IdInventario.HeaderText = "IdInventario"
    Me.IdInventario.Name = "IdInventario"
    Me.IdInventario.ReadOnly = True
    Me.IdInventario.Visible = False
    '
    'IdUnidad
    '
    Me.IdUnidad.HeaderText = "IdUnidad"
    Me.IdUnidad.Name = "IdUnidad"
    Me.IdUnidad.Visible = False
    '
    'colAgregar
    '
    Me.colAgregar.HeaderText = "Adicionar"
    Me.colAgregar.Name = "colAgregar"
    '
    'frmAgregarMP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(814, 455)
    Me.Controls.Add(Me.cmdAgregarItem)
    Me.Controls.Add(Me.txtCantidad)
    Me.Controls.Add(Me.cmbProducto)
    Me.Controls.Add(Me.grDetalleNuevo)
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
    Me.MaximizeBox = False
    Me.Name = "frmAgregarMP"
    Me.Text = "Agregar Material"
    CType(Me.grDetalle, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grDetalleNuevo, System.ComponentModel.ISupportInitialize).EndInit()
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
  Friend WithEvents cmdAgregarItem As System.Windows.Forms.Button
  Friend WithEvents txtCantidad As System.Windows.Forms.MaskedTextBox
  Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
  Friend WithEvents grDetalleNuevo As System.Windows.Forms.DataGridView
  Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodigoInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IdInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IdUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colAgregar As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
