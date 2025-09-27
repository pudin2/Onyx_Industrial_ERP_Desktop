<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMntOperarios
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
Me.components = New System.ComponentModel.Container()
Me.OperariosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
Me.ModProdDataSet = New ModProd.ModProdDataSet()
Me.btnGrabar = New System.Windows.Forms.Button()
Me.OperariosTableAdapter = New ModProd.ModProdDataSetTableAdapters.OperariosTableAdapter()
Me.DataGridView1 = New System.Windows.Forms.DataGridView()
Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.NombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.CargoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
CType(Me.OperariosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
Me.SuspendLayout()
'
'OperariosBindingSource
'
Me.OperariosBindingSource.DataMember = "Operarios"
Me.OperariosBindingSource.DataSource = Me.ModProdDataSet
'
'ModProdDataSet
'
Me.ModProdDataSet.DataSetName = "ModProdDataSet"
Me.ModProdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
'
'btnGrabar
'
Me.btnGrabar.Location = New System.Drawing.Point(439, 530)
Me.btnGrabar.Name = "btnGrabar"
Me.btnGrabar.Size = New System.Drawing.Size(123, 30)
Me.btnGrabar.TabIndex = 1
Me.btnGrabar.Text = "Grabar"
Me.btnGrabar.UseVisualStyleBackColor = True
'
'OperariosTableAdapter
'
Me.OperariosTableAdapter.ClearBeforeFill = True
'
'DataGridView1
'
Me.DataGridView1.AutoGenerateColumns = False
Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NombreDataGridViewTextBoxColumn, Me.CargoDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn})
Me.DataGridView1.DataSource = Me.OperariosBindingSource
Me.DataGridView1.Location = New System.Drawing.Point(12, 12)
Me.DataGridView1.Name = "DataGridView1"
Me.DataGridView1.Size = New System.Drawing.Size(550, 512)
Me.DataGridView1.TabIndex = 2
'
'IdDataGridViewTextBoxColumn
'
Me.IdDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
Me.IdDataGridViewTextBoxColumn.DataPropertyName = "Id"
Me.IdDataGridViewTextBoxColumn.HeaderText = "Id"
Me.IdDataGridViewTextBoxColumn.Name = "IdDataGridViewTextBoxColumn"
Me.IdDataGridViewTextBoxColumn.Width = 41
'
'NombreDataGridViewTextBoxColumn
'
Me.NombreDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
Me.NombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre"
Me.NombreDataGridViewTextBoxColumn.HeaderText = "Nombre"
Me.NombreDataGridViewTextBoxColumn.Name = "NombreDataGridViewTextBoxColumn"
Me.NombreDataGridViewTextBoxColumn.Width = 69
'
'CargoDataGridViewTextBoxColumn
'
Me.CargoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
Me.CargoDataGridViewTextBoxColumn.DataPropertyName = "Cargo"
Me.CargoDataGridViewTextBoxColumn.HeaderText = "Cargo"
Me.CargoDataGridViewTextBoxColumn.Name = "CargoDataGridViewTextBoxColumn"
Me.CargoDataGridViewTextBoxColumn.Width = 60
'
'EstadoDataGridViewTextBoxColumn
'
Me.EstadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "Estado"
Me.EstadoDataGridViewTextBoxColumn.HeaderText = "Estado"
Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
Me.EstadoDataGridViewTextBoxColumn.Width = 65
'
'frmMntOperarios
'
Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
Me.ClientSize = New System.Drawing.Size(574, 572)
Me.Controls.Add(Me.DataGridView1)
Me.Controls.Add(Me.btnGrabar)
Me.MaximizeBox = False
Me.Name = "frmMntOperarios"
Me.Text = "Operarios"
CType(Me.OperariosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).EndInit()
CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
Me.ResumeLayout(False)

End Sub
  Friend WithEvents ModProdDataSet As ModProd.ModProdDataSet
  Friend WithEvents OperariosBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents OperariosTableAdapter As ModProd.ModProdDataSetTableAdapters.OperariosTableAdapter
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NombreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents CargoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EstadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
