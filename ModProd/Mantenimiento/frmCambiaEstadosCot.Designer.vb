<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambiaEstadosCot
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
    Me.txtObsInterna = New System.Windows.Forms.TextBox()
    Me.Label25 = New System.Windows.Forms.Label()
    Me.chkListEstados = New System.Windows.Forms.CheckedListBox()
    Me.Label18 = New System.Windows.Forms.Label()
    Me.txtObservacion = New System.Windows.Forms.TextBox()
    Me.Label10 = New System.Windows.Forms.Label()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.txtProyecto = New System.Windows.Forms.TextBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.Label12 = New System.Windows.Forms.Label()
    Me.txtAlcance = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmbCot = New System.Windows.Forms.ComboBox()
    Me.lblNombreCliente = New System.Windows.Forms.Label()
    Me.lblNombreAsignadaA = New System.Windows.Forms.Label()
    Me.cmbNuevoEstado = New System.Windows.Forms.ComboBox()
    Me.btnCabiarEstado = New System.Windows.Forms.Button()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'txtObsInterna
    '
    Me.txtObsInterna.Location = New System.Drawing.Point(86, 374)
    Me.txtObsInterna.MaxLength = 8000
    Me.txtObsInterna.Multiline = True
    Me.txtObsInterna.Name = "txtObsInterna"
    Me.txtObsInterna.ReadOnly = True
    Me.txtObsInterna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObsInterna.Size = New System.Drawing.Size(558, 76)
    Me.txtObsInterna.TabIndex = 6
    '
    'Label25
    '
    Me.Label25.Location = New System.Drawing.Point(17, 377)
    Me.Label25.Name = "Label25"
    Me.Label25.Size = New System.Drawing.Size(70, 35)
    Me.Label25.TabIndex = 78
    Me.Label25.Text = "Observación Interna:"
    '
    'chkListEstados
    '
    Me.chkListEstados.FormattingEnabled = True
    Me.chkListEstados.Items.AddRange(New Object() {"Registrada", "Ingeniería", "Costeada", "Visto bueno", "Enviada", "Aprobada", "Anulada"})
    Me.chkListEstados.Location = New System.Drawing.Point(86, 481)
    Me.chkListEstados.Name = "chkListEstados"
    Me.chkListEstados.SelectionMode = System.Windows.Forms.SelectionMode.None
    Me.chkListEstados.Size = New System.Drawing.Size(114, 109)
    Me.chkListEstados.TabIndex = 8
    '
    'Label18
    '
    Me.Label18.AutoSize = True
    Me.Label18.Location = New System.Drawing.Point(17, 459)
    Me.Label18.Name = "Label18"
    Me.Label18.Size = New System.Drawing.Size(64, 13)
    Me.Label18.TabIndex = 76
    Me.Label18.Text = "Asignada A:"
    '
    'txtObservacion
    '
    Me.txtObservacion.Location = New System.Drawing.Point(86, 294)
    Me.txtObservacion.MaxLength = 8000
    Me.txtObservacion.Multiline = True
    Me.txtObservacion.Name = "txtObservacion"
    Me.txtObservacion.ReadOnly = True
    Me.txtObservacion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservacion.Size = New System.Drawing.Size(558, 76)
    Me.txtObservacion.TabIndex = 5
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.Location = New System.Drawing.Point(17, 298)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(70, 13)
    Me.Label10.TabIndex = 75
    Me.Label10.Text = "Observación:"
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(17, 142)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(49, 13)
    Me.Label14.TabIndex = 74
    Me.Label14.Text = "Alcance:"
    '
    'txtProyecto
    '
    Me.txtProyecto.Location = New System.Drawing.Point(86, 65)
    Me.txtProyecto.MaxLength = 400
    Me.txtProyecto.Multiline = True
    Me.txtProyecto.Name = "txtProyecto"
    Me.txtProyecto.ReadOnly = True
    Me.txtProyecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtProyecto.Size = New System.Drawing.Size(558, 70)
    Me.txtProyecto.TabIndex = 3
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(17, 68)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(52, 13)
    Me.Label13.TabIndex = 71
    Me.Label13.Text = "Proyecto:"
    '
    'Label12
    '
    Me.Label12.AutoSize = True
    Me.Label12.Location = New System.Drawing.Point(17, 42)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(42, 13)
    Me.Label12.TabIndex = 69
    Me.Label12.Text = "Cliente:"
    '
    'txtAlcance
    '
    Me.txtAlcance.Location = New System.Drawing.Point(86, 139)
    Me.txtAlcance.MaxLength = 8000
    Me.txtAlcance.Multiline = True
    Me.txtAlcance.Name = "txtAlcance"
    Me.txtAlcance.ReadOnly = True
    Me.txtAlcance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtAlcance.Size = New System.Drawing.Size(558, 151)
    Me.txtAlcance.TabIndex = 4
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(17, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(59, 13)
    Me.Label1.TabIndex = 80
    Me.Label1.Text = "Cotización:"
    '
    'cmbCot
    '
    Me.cmbCot.FormattingEnabled = True
    Me.cmbCot.Location = New System.Drawing.Point(86, 15)
    Me.cmbCot.Name = "cmbCot"
    Me.cmbCot.Size = New System.Drawing.Size(103, 21)
    Me.cmbCot.TabIndex = 1
    '
    'lblNombreCliente
    '
    Me.lblNombreCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblNombreCliente.Location = New System.Drawing.Point(86, 40)
    Me.lblNombreCliente.Name = "lblNombreCliente"
    Me.lblNombreCliente.Size = New System.Drawing.Size(558, 22)
    Me.lblNombreCliente.TabIndex = 2
    '
    'lblNombreAsignadaA
    '
    Me.lblNombreAsignadaA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblNombreAsignadaA.Location = New System.Drawing.Point(86, 456)
    Me.lblNombreAsignadaA.Name = "lblNombreAsignadaA"
    Me.lblNombreAsignadaA.Size = New System.Drawing.Size(558, 22)
    Me.lblNombreAsignadaA.TabIndex = 7
    '
    'cmbNuevoEstado
    '
    Me.cmbNuevoEstado.FormattingEnabled = True
    Me.cmbNuevoEstado.Location = New System.Drawing.Point(6, 19)
    Me.cmbNuevoEstado.Name = "cmbNuevoEstado"
    Me.cmbNuevoEstado.Size = New System.Drawing.Size(169, 21)
    Me.cmbNuevoEstado.TabIndex = 81
    '
    'btnCabiarEstado
    '
    Me.btnCabiarEstado.Location = New System.Drawing.Point(6, 46)
    Me.btnCabiarEstado.Name = "btnCabiarEstado"
    Me.btnCabiarEstado.Size = New System.Drawing.Size(169, 30)
    Me.btnCabiarEstado.TabIndex = 82
    Me.btnCabiarEstado.Text = "Actualizar"
    Me.btnCabiarEstado.UseVisualStyleBackColor = True
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmbNuevoEstado)
    Me.GroupBox1.Controls.Add(Me.btnCabiarEstado)
    Me.GroupBox1.Location = New System.Drawing.Point(291, 481)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(182, 82)
    Me.GroupBox1.TabIndex = 83
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Cambiar Estado"
    '
    'frmCambiaEstadosCot
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(674, 616)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.lblNombreAsignadaA)
    Me.Controls.Add(Me.lblNombreCliente)
    Me.Controls.Add(Me.cmbCot)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.txtAlcance)
    Me.Controls.Add(Me.txtObsInterna)
    Me.Controls.Add(Me.Label25)
    Me.Controls.Add(Me.chkListEstados)
    Me.Controls.Add(Me.Label18)
    Me.Controls.Add(Me.txtObservacion)
    Me.Controls.Add(Me.Label10)
    Me.Controls.Add(Me.Label14)
    Me.Controls.Add(Me.txtProyecto)
    Me.Controls.Add(Me.Label13)
    Me.Controls.Add(Me.Label12)
    Me.MaximizeBox = False
    Me.Name = "frmCambiaEstadosCot"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "frmCambiaEstadosCot"
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
    Friend WithEvents txtObsInterna As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents chkListEstados As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtObservacion As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtProyecto As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAlcance As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCot As System.Windows.Forms.ComboBox
    Friend WithEvents lblNombreCliente As System.Windows.Forms.Label
    Friend WithEvents lblNombreAsignadaA As System.Windows.Forms.Label
    Friend WithEvents cmbNuevoEstado As System.Windows.Forms.ComboBox
    Friend WithEvents btnCabiarEstado As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
