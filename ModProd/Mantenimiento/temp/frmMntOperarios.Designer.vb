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
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.btnGrabar = New System.Windows.Forms.Button()
    Me.ResponsablesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.ModProdDataSet = New ModProd.ModProdDataSet()
    Me.ResponsablesTableAdapter = New ModProd.ModProdDataSetTableAdapters.ResponsablesTableAdapter()
    Me.IdDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.NombreDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.EstadoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Usuario_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ResponsablesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.AutoGenerateColumns = False
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdDataGridViewTextBoxColumn, Me.NombreDataGridViewTextBoxColumn, Me.EstadoDataGridViewTextBoxColumn, Me.Usuario_Id})
    Me.DataGridView1.DataSource = Me.ResponsablesBindingSource
    Me.DataGridView1.Location = New System.Drawing.Point(11, 12)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.Size = New System.Drawing.Size(551, 287)
    Me.DataGridView1.TabIndex = 0
    '
    'btnGrabar
    '
    Me.btnGrabar.Location = New System.Drawing.Point(439, 305)
    Me.btnGrabar.Name = "btnGrabar"
    Me.btnGrabar.Size = New System.Drawing.Size(123, 30)
    Me.btnGrabar.TabIndex = 1
    Me.btnGrabar.Text = "Grabar"
    Me.btnGrabar.UseVisualStyleBackColor = True
    '
    'ResponsablesBindingSource
    '
    Me.ResponsablesBindingSource.DataMember = "Responsables"
    Me.ResponsablesBindingSource.DataSource = Me.ModProdDataSet
    '
    'ModProdDataSet
    '
    Me.ModProdDataSet.DataSetName = "ModProdDataSet"
    Me.ModProdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'ResponsablesTableAdapter
    '
    Me.ResponsablesTableAdapter.ClearBeforeFill = True
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
    'EstadoDataGridViewTextBoxColumn
    '
    Me.EstadoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.EstadoDataGridViewTextBoxColumn.DataPropertyName = "Estado"
    Me.EstadoDataGridViewTextBoxColumn.HeaderText = "Estado"
    Me.EstadoDataGridViewTextBoxColumn.Name = "EstadoDataGridViewTextBoxColumn"
    Me.EstadoDataGridViewTextBoxColumn.Width = 65
    '
    'Usuario_Id
    '
    Me.Usuario_Id.DataPropertyName = "Usuario_Id"
    Me.Usuario_Id.HeaderText = "Usuario_Id"
    Me.Usuario_Id.Name = "Usuario_Id"
    '
    'frmMntOperarios
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(574, 342)
    Me.Controls.Add(Me.btnGrabar)
    Me.Controls.Add(Me.DataGridView1)
    Me.MaximizeBox = False
    Me.Name = "frmMntOperarios"
    Me.Text = "Responsables"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ResponsablesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub
  Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
  Friend WithEvents ModProdDataSet As ModProd.ModProdDataSet
  Friend WithEvents ResponsablesBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents ResponsablesTableAdapter As ModProd.ModProdDataSetTableAdapters.ResponsablesTableAdapter
  Friend WithEvents btnGrabar As System.Windows.Forms.Button
  Friend WithEvents IdDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents NombreDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents EstadoDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents Usuario_Id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
