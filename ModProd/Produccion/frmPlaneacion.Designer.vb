<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlaneacion
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
    Me.DataGridView1 = New System.Windows.Forms.DataGridView()
    Me.grid1 = New System.Windows.Forms.DataGridView()
    Me.colTarea = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Grid2 = New System.Windows.Forms.DataGridView()
    Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Lunes = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Martes = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Miercoles = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Juenves = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.Viernes = New System.Windows.Forms.DataGridViewTextBoxColumn()
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.grid1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Grid2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGridView1
    '
    Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.DataGridView1.Location = New System.Drawing.Point(36, 12)
    Me.DataGridView1.Name = "DataGridView1"
    Me.DataGridView1.Size = New System.Drawing.Size(621, 185)
    Me.DataGridView1.TabIndex = 0
    '
    'grid1
    '
    Me.grid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grid1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTarea})
    Me.grid1.Location = New System.Drawing.Point(26, 12)
    Me.grid1.Name = "grid1"
    Me.grid1.Size = New System.Drawing.Size(633, 170)
    Me.grid1.TabIndex = 0
    '
    'colTarea
    '
    Me.colTarea.HeaderText = "Tarea"
    Me.colTarea.Name = "colTarea"
    '
    'Grid2
    '
    Me.Grid2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.Grid2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Lunes, Me.Martes, Me.Miercoles, Me.Juenves, Me.Viernes})
    Me.Grid2.Location = New System.Drawing.Point(26, 213)
    Me.Grid2.Name = "Grid2"
    Me.Grid2.Size = New System.Drawing.Size(713, 170)
    Me.Grid2.TabIndex = 1
    '
    'DataGridViewTextBoxColumn1
    '
    Me.DataGridViewTextBoxColumn1.HeaderText = "Tarea"
    Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
    '
    'Lunes
    '
    Me.Lunes.HeaderText = "Lunes"
    Me.Lunes.Name = "Lunes"
    '
    'Martes
    '
    Me.Martes.HeaderText = "Martes"
    Me.Martes.Name = "Martes"
    '
    'Miercoles
    '
    Me.Miercoles.HeaderText = "Miercoles"
    Me.Miercoles.Name = "Miercoles"
    '
    'Juenves
    '
    Me.Juenves.HeaderText = "Jueves"
    Me.Juenves.Name = "Juenves"
    '
    'Viernes
    '
    Me.Viernes.HeaderText = "Viernes"
    Me.Viernes.Name = "Viernes"
    '
    'frmPlaneacion
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(837, 467)
    Me.Controls.Add(Me.Grid2)
    Me.Controls.Add(Me.grid1)
    Me.Name = "frmPlaneacion"
    Me.Text = "frmPlaneacion"
    CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.grid1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Grid2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents grid1 As System.Windows.Forms.DataGridView
    Friend WithEvents colTarea As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Grid2 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Lunes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Martes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Miercoles As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Juenves As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Viernes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
