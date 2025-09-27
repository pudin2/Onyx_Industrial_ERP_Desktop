<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCostosMP
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
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.lblTipoUnidad = New System.Windows.Forms.Label()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.txtCosto = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.cmbProducto = New System.Windows.Forms.ComboBox()
    Me.TabPage2 = New System.Windows.Forms.TabPage()
    Me.grProductos = New System.Windows.Forms.DataGridView()
    Me.colId = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCodigoInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colUnidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCosto = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colEstado = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TabPage2.SuspendLayout()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TabControl1
    '
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage2)
    Me.TabControl1.Location = New System.Drawing.Point(12, 12)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(644, 435)
    Me.TabControl1.TabIndex = 8
    '
    'TabPage1
    '
    Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(636, 409)
    Me.TabPage1.TabIndex = 0
    Me.TabPage1.Text = "Nuevo"
    '
    'GroupBox1
    '
    Me.GroupBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.GroupBox1.Controls.Add(Me.lblTipoUnidad)
    Me.GroupBox1.Controls.Add(Me.btnGrabar)
    Me.GroupBox1.Controls.Add(Me.txtCosto)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.Label3)
    Me.GroupBox1.Controls.Add(Me.cmbProducto)
    Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(616, 325)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Productos"
    '
    'lblTipoUnidad
    '
    Me.lblTipoUnidad.AutoSize = True
    Me.lblTipoUnidad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblTipoUnidad.Location = New System.Drawing.Point(207, 43)
    Me.lblTipoUnidad.Name = "lblTipoUnidad"
    Me.lblTipoUnidad.Size = New System.Drawing.Size(12, 15)
    Me.lblTipoUnidad.TabIndex = 17
    Me.lblTipoUnidad.Text = " "
    '
    'btnGrabar
    '
    Me.btnGrabar.Location = New System.Drawing.Point(288, 42)
    Me.btnGrabar.Name = "btnGrabar"
    Me.btnGrabar.Size = New System.Drawing.Size(107, 20)
    Me.btnGrabar.TabIndex = 3
    Me.btnGrabar.Text = "Grabar"
    Me.btnGrabar.UseVisualStyleBackColor = True
    '
    'txtCosto
    '
    Me.txtCosto.Location = New System.Drawing.Point(69, 42)
    Me.txtCosto.Name = "txtCosto"
    Me.txtCosto.Size = New System.Drawing.Size(108, 20)
    Me.txtCosto.TabIndex = 2
    Me.txtCosto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Location = New System.Drawing.Point(26, 46)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(37, 13)
    Me.Label5.TabIndex = 3
    Me.Label5.Text = "Costo:"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(6, 18)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(53, 13)
    Me.Label3.TabIndex = 1
    Me.Label3.Text = "Producto:"
    '
    'cmbProducto
    '
    Me.cmbProducto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.cmbProducto.FormattingEnabled = True
    Me.cmbProducto.Location = New System.Drawing.Point(69, 15)
    Me.cmbProducto.MaxLength = 2000
    Me.cmbProducto.Name = "cmbProducto"
    Me.cmbProducto.Size = New System.Drawing.Size(434, 21)
    Me.cmbProducto.TabIndex = 0
    '
    'TabPage2
    '
    Me.TabPage2.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage2.Controls.Add(Me.grProductos)
    Me.TabPage2.Location = New System.Drawing.Point(4, 22)
    Me.TabPage2.Name = "TabPage2"
    Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage2.Size = New System.Drawing.Size(636, 409)
    Me.TabPage2.TabIndex = 1
    Me.TabPage2.Text = "Actuales"
    '
    'grProductos
    '
    Me.grProductos.AllowUserToAddRows = False
    Me.grProductos.AllowUserToDeleteRows = False
    Me.grProductos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
    Me.grProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grProductos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colId, Me.colCodigoInventario, Me.colDescripcion, Me.colUnidad, Me.colCosto, Me.colEstado})
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grProductos.DefaultCellStyle = DataGridViewCellStyle11
    Me.grProductos.Location = New System.Drawing.Point(6, 6)
    Me.grProductos.Name = "grProductos"
    Me.grProductos.ReadOnly = True
    DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grProductos.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
    Me.grProductos.RowHeadersWidth = 20
    Me.grProductos.RowTemplate.DefaultCellStyle.Format = "N2"
    Me.grProductos.RowTemplate.DefaultCellStyle.NullValue = Nothing
    Me.grProductos.Size = New System.Drawing.Size(618, 332)
    Me.grProductos.TabIndex = 5
    '
    'colId
    '
    Me.colId.HeaderText = "ID"
    Me.colId.Name = "colId"
    Me.colId.ReadOnly = True
    Me.colId.Width = 50
    '
    'colCodigoInventario
    '
    Me.colCodigoInventario.DividerWidth = 1
    Me.colCodigoInventario.HeaderText = "Código"
    Me.colCodigoInventario.Name = "colCodigoInventario"
    Me.colCodigoInventario.ReadOnly = True
    Me.colCodigoInventario.Width = 60
    '
    'colDescripcion
    '
    Me.colDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
    Me.colDescripcion.DividerWidth = 1
    Me.colDescripcion.HeaderText = "Descripción"
    Me.colDescripcion.Name = "colDescripcion"
    Me.colDescripcion.ReadOnly = True
    Me.colDescripcion.Width = 250
    '
    'colUnidad
    '
    Me.colUnidad.HeaderText = "Unidad"
    Me.colUnidad.Name = "colUnidad"
    Me.colUnidad.ReadOnly = True
    Me.colUnidad.Width = 50
    '
    'colCosto
    '
    Me.colCosto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    DataGridViewCellStyle10.Format = "N2"
    DataGridViewCellStyle10.NullValue = "0"
    Me.colCosto.DefaultCellStyle = DataGridViewCellStyle10
    Me.colCosto.DividerWidth = 1
    Me.colCosto.HeaderText = "C/U"
    Me.colCosto.MinimumWidth = 71
    Me.colCosto.Name = "colCosto"
    Me.colCosto.ReadOnly = True
    Me.colCosto.Width = 71
    '
    'colEstado
    '
    Me.colEstado.HeaderText = "Estado"
    Me.colEstado.Name = "colEstado"
    Me.colEstado.ReadOnly = True
    Me.colEstado.Width = 50
    '
    'frmCostosMP
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(664, 458)
    Me.Controls.Add(Me.TabControl1)
    Me.MaximizeBox = False
    Me.Name = "frmCostosMP"
    Me.Text = "frmCostosMP"
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TabPage2.ResumeLayout(False)
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents lblTipoUnidad As System.Windows.Forms.Label
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents txtCosto As System.Windows.Forms.TextBox
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
  Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
  Friend WithEvents grProductos As System.Windows.Forms.DataGridView
  Friend WithEvents colId As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodigoInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colUnidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCosto As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colEstado As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
