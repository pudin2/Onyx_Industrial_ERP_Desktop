<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCrearOrden
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
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Me.TipoOrdenBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.ModProdDataSet = New ModProd.ModProdDataSet()
    Me.AreasPlantaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.PlantasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.SedesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.SedesTableAdapter = New ModProd.ModProdDataSetTableAdapters.SedesTableAdapter()
    Me.PlantasTableAdapter = New ModProd.ModProdDataSetTableAdapters.PlantasTableAdapter()
    Me.AreasPlantaTableAdapter = New ModProd.ModProdDataSetTableAdapters.AreasPlantaTableAdapter()
    Me.TipoOrdenTableAdapter = New ModProd.ModProdDataSetTableAdapters.TipoOrdenTableAdapter()
    Me.Vw_ProductosZiurBindingSource = New System.Windows.Forms.BindingSource(Me.components)
    Me.Vw_ProductosZiurTableAdapter = New ModProd.ModProdDataSetTableAdapters.vw_ProductosZiurTableAdapter()
    Me.TableAdapterManager = New ModProd.ModProdDataSetTableAdapters.TableAdapterManager()
    Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
    Me.stNumOrden = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stFecha = New System.Windows.Forms.ToolStripStatusLabel()
    Me.stEstado = New System.Windows.Forms.ToolStripStatusLabel()
    Me.TabControl1 = New System.Windows.Forms.TabControl()
    Me.TabPage1 = New System.Windows.Forms.TabPage()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.cmbTipoOrden = New System.Windows.Forms.ComboBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.cmbArea = New System.Windows.Forms.ComboBox()
    Me.cmbPlanta = New System.Windows.Forms.ComboBox()
    Me.cmbSede = New System.Windows.Forms.ComboBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
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
    Me.grDetalleOrden = New System.Windows.Forms.DataGridView()
    Me.Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCodigoInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.IdInventario = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.colAgregar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.cmdAgregarItem = New System.Windows.Forms.Button()
    Me.txtCantidad = New System.Windows.Forms.MaskedTextBox()
    Me.cmbProducto = New System.Windows.Forms.ComboBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.cmdActualizaMateriales = New System.Windows.Forms.Button()
    Me.Label14 = New System.Windows.Forms.Label()
    Me.cmbResponsable = New System.Windows.Forms.ComboBox()
    Me.Label13 = New System.Windows.Forms.Label()
    Me.txtOc = New System.Windows.Forms.TextBox()
    Me.btnCrearCotizacionRapida = New System.Windows.Forms.Button()
    Me.btnCargar = New System.Windows.Forms.Button()
    Me.btnImprimir = New System.Windows.Forms.Button()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.txtNumCotizacion = New System.Windows.Forms.MaskedTextBox()
    Me.cmdValidar = New System.Windows.Forms.Button()
    Me.lblNumeroOrden = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.cmdGuardar = New System.Windows.Forms.Button()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.dtpFechaRegistro = New System.Windows.Forms.DateTimePicker()
    Me.TabPage3 = New System.Windows.Forms.TabPage()
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.btnAnexos = New System.Windows.Forms.Button()
    Me.lstAnexos = New System.Windows.Forms.CheckedListBox()
    Me.pcbAnexos = New System.Windows.Forms.PictureBox()
    Me.ofdCargarAdjuntos = New System.Windows.Forms.OpenFileDialog()
    Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
    CType(Me.TipoOrdenBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.AreasPlantaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.PlantasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SedesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Vw_ProductosZiurBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.StatusStrip1.SuspendLayout()
    Me.TabControl1.SuspendLayout()
    Me.TabPage1.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox3.SuspendLayout()
    CType(Me.grDetalleOrden, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox1.SuspendLayout()
    Me.TabPage3.SuspendLayout()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.pcbAnexos, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TipoOrdenBindingSource
    '
    Me.TipoOrdenBindingSource.DataMember = "TipoOrden"
    Me.TipoOrdenBindingSource.DataSource = Me.ModProdDataSet
    '
    'ModProdDataSet
    '
    Me.ModProdDataSet.DataSetName = "ModProdDataSet"
    Me.ModProdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
    '
    'AreasPlantaBindingSource
    '
    Me.AreasPlantaBindingSource.DataMember = "AreasPlanta"
    Me.AreasPlantaBindingSource.DataSource = Me.ModProdDataSet
    '
    'PlantasBindingSource
    '
    Me.PlantasBindingSource.DataMember = "Plantas"
    Me.PlantasBindingSource.DataSource = Me.ModProdDataSet
    '
    'SedesBindingSource
    '
    Me.SedesBindingSource.DataMember = "Sedes"
    Me.SedesBindingSource.DataSource = Me.ModProdDataSet
    '
    'SedesTableAdapter
    '
    Me.SedesTableAdapter.ClearBeforeFill = True
    '
    'PlantasTableAdapter
    '
    Me.PlantasTableAdapter.ClearBeforeFill = True
    '
    'AreasPlantaTableAdapter
    '
    Me.AreasPlantaTableAdapter.ClearBeforeFill = True
    '
    'TipoOrdenTableAdapter
    '
    Me.TipoOrdenTableAdapter.ClearBeforeFill = True
    '
    'Vw_ProductosZiurBindingSource
    '
    Me.Vw_ProductosZiurBindingSource.DataMember = "vw_ProductosZiur"
    Me.Vw_ProductosZiurBindingSource.DataSource = Me.ModProdDataSet
    '
    'Vw_ProductosZiurTableAdapter
    '
    Me.Vw_ProductosZiurTableAdapter.ClearBeforeFill = True
    '
    'TableAdapterManager
    '
    Me.TableAdapterManager.AreasPlantaTableAdapter = Me.AreasPlantaTableAdapter
    Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
    Me.TableAdapterManager.CabOrdenTableAdapter = Nothing
    Me.TableAdapterManager.DetOrdenTableAdapter = Nothing
    Me.TableAdapterManager.PlantasTableAdapter = Me.PlantasTableAdapter
    Me.TableAdapterManager.ResponsablesTableAdapter = Nothing
    Me.TableAdapterManager.SedesTableAdapter = Me.SedesTableAdapter
    Me.TableAdapterManager.TipoOrdenTableAdapter = Me.TipoOrdenTableAdapter
    Me.TableAdapterManager.UpdateOrder = ModProd.ModProdDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
    '
    'StatusStrip1
    '
    Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stNumOrden, Me.stFecha, Me.stEstado})
    Me.StatusStrip1.Location = New System.Drawing.Point(0, 711)
    Me.StatusStrip1.Name = "StatusStrip1"
    Me.StatusStrip1.Size = New System.Drawing.Size(1179, 22)
    Me.StatusStrip1.TabIndex = 7
    Me.StatusStrip1.Text = "StatusStrip1"
    '
    'stNumOrden
    '
    Me.stNumOrden.Name = "stNumOrden"
    Me.stNumOrden.Size = New System.Drawing.Size(43, 17)
    Me.stNumOrden.Text = "Orden:"
    '
    'stFecha
    '
    Me.stFecha.Name = "stFecha"
    Me.stFecha.Size = New System.Drawing.Size(41, 17)
    Me.stFecha.Text = "Fecha:"
    '
    'stEstado
    '
    Me.stEstado.AutoSize = False
    Me.stEstado.Name = "stEstado"
    Me.stEstado.Size = New System.Drawing.Size(300, 17)
    Me.stEstado.Text = "Cargando ..."
    Me.stEstado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    Me.stEstado.Visible = False
    '
    'TabControl1
    '
    Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.TabControl1.Controls.Add(Me.TabPage1)
    Me.TabControl1.Controls.Add(Me.TabPage3)
    Me.TabControl1.Location = New System.Drawing.Point(6, 8)
    Me.TabControl1.Name = "TabControl1"
    Me.TabControl1.SelectedIndex = 0
    Me.TabControl1.Size = New System.Drawing.Size(1173, 696)
    Me.TabControl1.TabIndex = 8
    '
    'TabPage1
    '
    Me.TabPage1.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage1.Controls.Add(Me.GroupBox4)
    Me.TabPage1.Controls.Add(Me.grProductos)
    Me.TabPage1.Controls.Add(Me.GroupBox3)
    Me.TabPage1.Controls.Add(Me.grDetalleOrden)
    Me.TabPage1.Controls.Add(Me.GroupBox2)
    Me.TabPage1.Controls.Add(Me.GroupBox1)
    Me.TabPage1.Location = New System.Drawing.Point(4, 22)
    Me.TabPage1.Name = "TabPage1"
    Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage1.Size = New System.Drawing.Size(1165, 670)
    Me.TabPage1.TabIndex = 3
    Me.TabPage1.Text = "OT"
    '
    'GroupBox4
    '
    Me.GroupBox4.Controls.Add(Me.TextBox1)
    Me.GroupBox4.Controls.Add(Me.cmbTipoOrden)
    Me.GroupBox4.Controls.Add(Me.Label4)
    Me.GroupBox4.Controls.Add(Me.cmbArea)
    Me.GroupBox4.Controls.Add(Me.cmbPlanta)
    Me.GroupBox4.Controls.Add(Me.cmbSede)
    Me.GroupBox4.Controls.Add(Me.Label3)
    Me.GroupBox4.Controls.Add(Me.Label2)
    Me.GroupBox4.Location = New System.Drawing.Point(1000, 6)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(138, 40)
    Me.GroupBox4.TabIndex = 7
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "GroupBox4"
    Me.GroupBox4.Visible = False
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(123, 126)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(100, 20)
    Me.TextBox1.TabIndex = 15
    Me.TextBox1.Text = "REQUISISION OC"
    Me.TextBox1.Visible = False
    '
    'cmbTipoOrden
    '
    Me.cmbTipoOrden.DataSource = Me.TipoOrdenBindingSource
    Me.cmbTipoOrden.DisplayMember = "Nombre"
    Me.cmbTipoOrden.FormattingEnabled = True
    Me.cmbTipoOrden.Location = New System.Drawing.Point(102, 99)
    Me.cmbTipoOrden.Name = "cmbTipoOrden"
    Me.cmbTipoOrden.Size = New System.Drawing.Size(121, 21)
    Me.cmbTipoOrden.TabIndex = 14
    Me.cmbTipoOrden.Visible = False
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(18, 102)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(78, 13)
    Me.Label4.TabIndex = 13
    Me.Label4.Text = "Tipo de Orden:"
    Me.Label4.Visible = False
    '
    'cmbArea
    '
    Me.cmbArea.DataSource = Me.AreasPlantaBindingSource
    Me.cmbArea.DisplayMember = "Nombre"
    Me.cmbArea.FormattingEnabled = True
    Me.cmbArea.Location = New System.Drawing.Point(67, 74)
    Me.cmbArea.Name = "cmbArea"
    Me.cmbArea.Size = New System.Drawing.Size(156, 21)
    Me.cmbArea.TabIndex = 12
    Me.cmbArea.Visible = False
    '
    'cmbPlanta
    '
    Me.cmbPlanta.DataSource = Me.PlantasBindingSource
    Me.cmbPlanta.DisplayMember = "Nombre"
    Me.cmbPlanta.FormattingEnabled = True
    Me.cmbPlanta.Location = New System.Drawing.Point(67, 49)
    Me.cmbPlanta.Name = "cmbPlanta"
    Me.cmbPlanta.Size = New System.Drawing.Size(156, 21)
    Me.cmbPlanta.TabIndex = 11
    Me.cmbPlanta.Visible = False
    '
    'cmbSede
    '
    Me.cmbSede.DataSource = Me.SedesBindingSource
    Me.cmbSede.DisplayMember = "Nombre"
    Me.cmbSede.FormattingEnabled = True
    Me.cmbSede.Location = New System.Drawing.Point(67, 25)
    Me.cmbSede.Name = "cmbSede"
    Me.cmbSede.Size = New System.Drawing.Size(156, 21)
    Me.cmbSede.TabIndex = 10
    Me.cmbSede.Visible = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(19, 77)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(32, 13)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Area:"
    Me.Label3.Visible = False
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(21, 54)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 13)
    Me.Label2.TabIndex = 8
    Me.Label2.Text = "Planta:"
    Me.Label2.Visible = False
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
    Me.grProductos.Location = New System.Drawing.Point(557, 158)
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
    Me.grProductos.Size = New System.Drawing.Size(602, 525)
    Me.grProductos.TabIndex = 6
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
    Me.GroupBox3.Location = New System.Drawing.Point(6, 231)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(545, 436)
    Me.GroupBox3.TabIndex = 5
    Me.GroupBox3.TabStop = False
    '
    'txtObsInterna
    '
    Me.txtObsInterna.Location = New System.Drawing.Point(96, 354)
    Me.txtObsInterna.Multiline = True
    Me.txtObsInterna.Name = "txtObsInterna"
    Me.txtObsInterna.ReadOnly = True
    Me.txtObsInterna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObsInterna.Size = New System.Drawing.Size(443, 76)
    Me.txtObsInterna.TabIndex = 27
    '
    'Label12
    '
    Me.Label12.Location = New System.Drawing.Point(12, 354)
    Me.Label12.Name = "Label12"
    Me.Label12.Size = New System.Drawing.Size(81, 31)
    Me.Label12.TabIndex = 26
    Me.Label12.Text = "Observaciones Internas:"
    '
    'txtObservaciones
    '
    Me.txtObservaciones.Location = New System.Drawing.Point(96, 248)
    Me.txtObservaciones.Multiline = True
    Me.txtObservaciones.Name = "txtObservaciones"
    Me.txtObservaciones.ReadOnly = True
    Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtObservaciones.Size = New System.Drawing.Size(443, 100)
    Me.txtObservaciones.TabIndex = 25
    '
    'txtProyecto
    '
    Me.txtProyecto.Location = New System.Drawing.Point(96, 142)
    Me.txtProyecto.Multiline = True
    Me.txtProyecto.Name = "txtProyecto"
    Me.txtProyecto.ReadOnly = True
    Me.txtProyecto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtProyecto.Size = New System.Drawing.Size(443, 100)
    Me.txtProyecto.TabIndex = 24
    '
    'txtAlcance
    '
    Me.txtAlcance.Location = New System.Drawing.Point(96, 36)
    Me.txtAlcance.Multiline = True
    Me.txtAlcance.Name = "txtAlcance"
    Me.txtAlcance.ReadOnly = True
    Me.txtAlcance.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.txtAlcance.Size = New System.Drawing.Size(443, 100)
    Me.txtAlcance.TabIndex = 23
    '
    'lblCliente
    '
    Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblCliente.Location = New System.Drawing.Point(96, 12)
    Me.lblCliente.Name = "lblCliente"
    Me.lblCliente.Size = New System.Drawing.Size(443, 21)
    Me.lblCliente.TabIndex = 22
    Me.lblCliente.Text = " "
    '
    'Label8
    '
    Me.Label8.AutoSize = True
    Me.Label8.Location = New System.Drawing.Point(12, 251)
    Me.Label8.Name = "Label8"
    Me.Label8.Size = New System.Drawing.Size(81, 13)
    Me.Label8.TabIndex = 21
    Me.Label8.Text = "Observaciones:"
    '
    'Label9
    '
    Me.Label9.AutoSize = True
    Me.Label9.Location = New System.Drawing.Point(12, 142)
    Me.Label9.Name = "Label9"
    Me.Label9.Size = New System.Drawing.Size(52, 13)
    Me.Label9.TabIndex = 20
    Me.Label9.Text = "Proyecto:"
    '
    'Label10
    '
    Me.Label10.AutoSize = True
    Me.Label10.CausesValidation = False
    Me.Label10.Location = New System.Drawing.Point(12, 46)
    Me.Label10.Name = "Label10"
    Me.Label10.Size = New System.Drawing.Size(49, 13)
    Me.Label10.TabIndex = 19
    Me.Label10.Text = "Alcance:"
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Location = New System.Drawing.Point(14, 20)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(42, 13)
    Me.Label11.TabIndex = 18
    Me.Label11.Text = "Cliente:"
    '
    'grDetalleOrden
    '
    Me.grDetalleOrden.AllowUserToAddRows = False
    DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grDetalleOrden.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
    Me.grDetalleOrden.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
    Me.grDetalleOrden.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Id, Me.colCodigoInventario, Me.colDescripcion, Me.colCantidad, Me.IdInventario, Me.colAgregar})
    DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
    DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.grDetalleOrden.DefaultCellStyle = DataGridViewCellStyle10
    Me.grDetalleOrden.Location = New System.Drawing.Point(6, 158)
    Me.grDetalleOrden.Name = "grDetalleOrden"
    DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
    DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
    DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.grDetalleOrden.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
    Me.grDetalleOrden.RowHeadersWidth = 20
    Me.grDetalleOrden.Size = New System.Drawing.Size(545, 82)
    Me.grDetalleOrden.TabIndex = 4
    '
    'Id
    '
    Me.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
    Me.Id.DefaultCellStyle = DataGridViewCellStyle8
    Me.Id.Frozen = True
    Me.Id.HeaderText = "Id"
    Me.Id.Name = "Id"
    Me.Id.ReadOnly = True
    Me.Id.Width = 41
    '
    'colCodigoInventario
    '
    Me.colCodigoInventario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.colCodigoInventario.Frozen = True
    Me.colCodigoInventario.HeaderText = "Código"
    Me.colCodigoInventario.Name = "colCodigoInventario"
    Me.colCodigoInventario.ReadOnly = True
    Me.colCodigoInventario.Width = 65
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
    Me.colCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
    Me.colCantidad.DefaultCellStyle = DataGridViewCellStyle9
    Me.colCantidad.Frozen = True
    Me.colCantidad.HeaderText = "Cantidad"
    Me.colCantidad.Name = "colCantidad"
    Me.colCantidad.Width = 74
    '
    'IdInventario
    '
    Me.IdInventario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.IdInventario.Frozen = True
    Me.IdInventario.HeaderText = "IdInventario"
    Me.IdInventario.Name = "IdInventario"
    Me.IdInventario.ReadOnly = True
    Me.IdInventario.Visible = False
    '
    'colAgregar
    '
    Me.colAgregar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells
    Me.colAgregar.HeaderText = "Adicionar"
    Me.colAgregar.Name = "colAgregar"
    Me.colAgregar.Width = 57
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.Label1)
    Me.GroupBox2.Controls.Add(Me.cmdAgregarItem)
    Me.GroupBox2.Controls.Add(Me.txtCantidad)
    Me.GroupBox2.Controls.Add(Me.cmbProducto)
    Me.GroupBox2.Location = New System.Drawing.Point(448, 6)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(546, 146)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Producto terminado a Fabricar"
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(6, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(52, 13)
    Me.Label1.TabIndex = 5
    Me.Label1.Text = "Cantidad:"
    '
    'cmdAgregarItem
    '
    Me.cmdAgregarItem.Location = New System.Drawing.Point(179, 44)
    Me.cmdAgregarItem.Name = "cmdAgregarItem"
    Me.cmdAgregarItem.Size = New System.Drawing.Size(132, 20)
    Me.cmdAgregarItem.TabIndex = 4
    Me.cmdAgregarItem.Text = "Adicionar"
    Me.cmdAgregarItem.UseVisualStyleBackColor = True
    '
    'txtCantidad
    '
    Me.txtCantidad.Location = New System.Drawing.Point(64, 44)
    Me.txtCantidad.Mask = "99999"
    Me.txtCantidad.Name = "txtCantidad"
    Me.txtCantidad.Size = New System.Drawing.Size(109, 20)
    Me.txtCantidad.TabIndex = 3
    Me.txtCantidad.ValidatingType = GetType(Integer)
    '
    'cmbProducto
    '
    Me.cmbProducto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
    Me.cmbProducto.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
    Me.cmbProducto.DataSource = Me.Vw_ProductosZiurBindingSource
    Me.cmbProducto.DisplayMember = "NomInventario"
    Me.cmbProducto.FormattingEnabled = True
    Me.cmbProducto.Location = New System.Drawing.Point(6, 19)
    Me.cmbProducto.Name = "cmbProducto"
    Me.cmbProducto.Size = New System.Drawing.Size(533, 21)
    Me.cmbProducto.TabIndex = 2
    Me.ToolTip1.SetToolTip(Me.cmbProducto, "Presione F3 para buscar ó F9 para Recargar")
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmdActualizaMateriales)
    Me.GroupBox1.Controls.Add(Me.Label14)
    Me.GroupBox1.Controls.Add(Me.cmbResponsable)
    Me.GroupBox1.Controls.Add(Me.Label13)
    Me.GroupBox1.Controls.Add(Me.txtOc)
    Me.GroupBox1.Controls.Add(Me.btnCrearCotizacionRapida)
    Me.GroupBox1.Controls.Add(Me.btnCargar)
    Me.GroupBox1.Controls.Add(Me.btnImprimir)
    Me.GroupBox1.Controls.Add(Me.Label7)
    Me.GroupBox1.Controls.Add(Me.txtNumCotizacion)
    Me.GroupBox1.Controls.Add(Me.cmdValidar)
    Me.GroupBox1.Controls.Add(Me.lblNumeroOrden)
    Me.GroupBox1.Controls.Add(Me.Label6)
    Me.GroupBox1.Controls.Add(Me.cmdGuardar)
    Me.GroupBox1.Controls.Add(Me.Label5)
    Me.GroupBox1.Controls.Add(Me.dtpFechaRegistro)
    Me.GroupBox1.Location = New System.Drawing.Point(6, 3)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(436, 149)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "General"
    '
    'cmdActualizaMateriales
    '
    Me.cmdActualizaMateriales.Location = New System.Drawing.Point(317, 61)
    Me.cmdActualizaMateriales.Name = "cmdActualizaMateriales"
    Me.cmdActualizaMateriales.Size = New System.Drawing.Size(106, 23)
    Me.cmdActualizaMateriales.TabIndex = 25
    Me.cmdActualizaMateriales.Text = "Materiales"
    Me.cmdActualizaMateriales.UseVisualStyleBackColor = True
    '
    'Label14
    '
    Me.Label14.AutoSize = True
    Me.Label14.Location = New System.Drawing.Point(5, 116)
    Me.Label14.Name = "Label14"
    Me.Label14.Size = New System.Drawing.Size(72, 13)
    Me.Label14.TabIndex = 24
    Me.Label14.Text = "Responsable:"
    '
    'cmbResponsable
    '
    Me.cmbResponsable.FormattingEnabled = True
    Me.cmbResponsable.Location = New System.Drawing.Point(77, 113)
    Me.cmbResponsable.Name = "cmbResponsable"
    Me.cmbResponsable.Size = New System.Drawing.Size(346, 21)
    Me.cmbResponsable.TabIndex = 23
    '
    'Label13
    '
    Me.Label13.AutoSize = True
    Me.Label13.Location = New System.Drawing.Point(6, 93)
    Me.Label13.Name = "Label13"
    Me.Label13.Size = New System.Drawing.Size(65, 13)
    Me.Label13.TabIndex = 22
    Me.Label13.Text = "Requisición:"
    '
    'txtOc
    '
    Me.txtOc.Location = New System.Drawing.Point(77, 89)
    Me.txtOc.Name = "txtOc"
    Me.txtOc.Size = New System.Drawing.Size(113, 20)
    Me.txtOc.TabIndex = 21
    '
    'btnCrearCotizacionRapida
    '
    Me.btnCrearCotizacionRapida.Location = New System.Drawing.Point(317, 12)
    Me.btnCrearCotizacionRapida.Name = "btnCrearCotizacionRapida"
    Me.btnCrearCotizacionRapida.Size = New System.Drawing.Size(106, 23)
    Me.btnCrearCotizacionRapida.TabIndex = 20
    Me.btnCrearCotizacionRapida.Text = "Cotizacion Rapida"
    Me.btnCrearCotizacionRapida.UseVisualStyleBackColor = True
    '
    'btnCargar
    '
    Me.btnCargar.Location = New System.Drawing.Point(317, 37)
    Me.btnCargar.Name = "btnCargar"
    Me.btnCargar.Size = New System.Drawing.Size(106, 23)
    Me.btnCargar.TabIndex = 19
    Me.btnCargar.Text = "Cargar"
    Me.btnCargar.UseVisualStyleBackColor = True
    '
    'btnImprimir
    '
    Me.btnImprimir.Location = New System.Drawing.Point(205, 61)
    Me.btnImprimir.Name = "btnImprimir"
    Me.btnImprimir.Size = New System.Drawing.Size(106, 22)
    Me.btnImprimir.TabIndex = 18
    Me.btnImprimir.Text = "Imprimir"
    Me.btnImprimir.UseVisualStyleBackColor = True
    '
    'Label7
    '
    Me.Label7.AutoSize = True
    Me.Label7.Location = New System.Drawing.Point(6, 69)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(59, 13)
    Me.Label7.TabIndex = 17
    Me.Label7.Text = "Cotización:"
    '
    'txtNumCotizacion
    '
    Me.txtNumCotizacion.Location = New System.Drawing.Point(77, 64)
    Me.txtNumCotizacion.Mask = "999999"
    Me.txtNumCotizacion.Name = "txtNumCotizacion"
    Me.txtNumCotizacion.Size = New System.Drawing.Size(113, 20)
    Me.txtNumCotizacion.TabIndex = 13
    '
    'cmdValidar
    '
    Me.cmdValidar.Location = New System.Drawing.Point(205, 37)
    Me.cmdValidar.Name = "cmdValidar"
    Me.cmdValidar.Size = New System.Drawing.Size(106, 22)
    Me.cmdValidar.TabIndex = 13
    Me.cmdValidar.Text = "Validar"
    Me.cmdValidar.UseVisualStyleBackColor = True
    '
    'lblNumeroOrden
    '
    Me.lblNumeroOrden.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.lblNumeroOrden.Location = New System.Drawing.Point(77, 38)
    Me.lblNumeroOrden.Name = "lblNumeroOrden"
    Me.lblNumeroOrden.Size = New System.Drawing.Size(113, 21)
    Me.lblNumeroOrden.TabIndex = 12
    '
    'Label6
    '
    Me.Label6.AutoSize = True
    Me.Label6.Location = New System.Drawing.Point(6, 42)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(47, 13)
    Me.Label6.TabIndex = 11
    Me.Label6.Text = "Número:"
    '
    'cmdGuardar
    '
    Me.cmdGuardar.Location = New System.Drawing.Point(205, 12)
    Me.cmdGuardar.Name = "cmdGuardar"
    Me.cmdGuardar.Size = New System.Drawing.Size(106, 23)
    Me.cmdGuardar.TabIndex = 10
    Me.cmdGuardar.Text = "Guardar"
    Me.cmdGuardar.UseVisualStyleBackColor = True
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.CausesValidation = False
    Me.Label5.Location = New System.Drawing.Point(8, 18)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(40, 13)
    Me.Label5.TabIndex = 9
    Me.Label5.Text = "Fecha:"
    '
    'dtpFechaRegistro
    '
    Me.dtpFechaRegistro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtpFechaRegistro.Location = New System.Drawing.Point(77, 15)
    Me.dtpFechaRegistro.Name = "dtpFechaRegistro"
    Me.dtpFechaRegistro.Size = New System.Drawing.Size(113, 20)
    Me.dtpFechaRegistro.TabIndex = 8
    '
    'TabPage3
    '
    Me.TabPage3.BackColor = System.Drawing.SystemColors.Control
    Me.TabPage3.Controls.Add(Me.SplitContainer1)
    Me.TabPage3.Location = New System.Drawing.Point(4, 22)
    Me.TabPage3.Name = "TabPage3"
    Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
    Me.TabPage3.Size = New System.Drawing.Size(1165, 670)
    Me.TabPage3.TabIndex = 2
    Me.TabPage3.Text = "Anexos"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
    Me.SplitContainer1.Name = "SplitContainer1"
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.btnAnexos)
    Me.SplitContainer1.Panel1.Controls.Add(Me.lstAnexos)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.pcbAnexos)
    Me.SplitContainer1.Size = New System.Drawing.Size(1159, 664)
    Me.SplitContainer1.SplitterDistance = 307
    Me.SplitContainer1.TabIndex = 0
    '
    'btnAnexos
    '
    Me.btnAnexos.Location = New System.Drawing.Point(3, 3)
    Me.btnAnexos.Name = "btnAnexos"
    Me.btnAnexos.Size = New System.Drawing.Size(116, 28)
    Me.btnAnexos.TabIndex = 26
    Me.btnAnexos.Text = "Adjuntar..."
    Me.btnAnexos.UseVisualStyleBackColor = True
    '
    'lstAnexos
    '
    Me.lstAnexos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.lstAnexos.FormattingEnabled = True
    Me.lstAnexos.Location = New System.Drawing.Point(3, 37)
    Me.lstAnexos.Name = "lstAnexos"
    Me.lstAnexos.Size = New System.Drawing.Size(297, 604)
    Me.lstAnexos.TabIndex = 23
    '
    'pcbAnexos
    '
    Me.pcbAnexos.Dock = System.Windows.Forms.DockStyle.Fill
    Me.pcbAnexos.Location = New System.Drawing.Point(0, 0)
    Me.pcbAnexos.Name = "pcbAnexos"
    Me.pcbAnexos.Size = New System.Drawing.Size(844, 660)
    Me.pcbAnexos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.pcbAnexos.TabIndex = 0
    Me.pcbAnexos.TabStop = False
    '
    'ofdCargarAdjuntos
    '
    Me.ofdCargarAdjuntos.Multiselect = True
    '
    'ToolTip1
    '
    Me.ToolTip1.AutomaticDelay = 200
    '
    'frmCrearOrden
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(1179, 733)
    Me.Controls.Add(Me.TabControl1)
    Me.Controls.Add(Me.StatusStrip1)
    Me.Name = "frmCrearOrden"
    Me.Text = "Crear Orden"
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.TipoOrdenBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ModProdDataSet, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.AreasPlantaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.PlantasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SedesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Vw_ProductosZiurBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
    Me.StatusStrip1.ResumeLayout(False)
    Me.StatusStrip1.PerformLayout()
    Me.TabControl1.ResumeLayout(False)
    Me.TabPage1.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox4.PerformLayout()
    CType(Me.grProductos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox3.PerformLayout()
    CType(Me.grDetalleOrden, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox2.PerformLayout()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox1.PerformLayout()
    Me.TabPage3.ResumeLayout(False)
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.pcbAnexos, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

End Sub
  Friend WithEvents ModProdDataSet As ModProd.ModProdDataSet
  Friend WithEvents SedesBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents SedesTableAdapter As ModProd.ModProdDataSetTableAdapters.SedesTableAdapter
  Friend WithEvents PlantasBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents PlantasTableAdapter As ModProd.ModProdDataSetTableAdapters.PlantasTableAdapter
  Friend WithEvents AreasPlantaBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents AreasPlantaTableAdapter As ModProd.ModProdDataSetTableAdapters.AreasPlantaTableAdapter
  Friend WithEvents TipoOrdenBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents TipoOrdenTableAdapter As ModProd.ModProdDataSetTableAdapters.TipoOrdenTableAdapter
  Friend WithEvents Vw_ProductosZiurBindingSource As System.Windows.Forms.BindingSource
  Friend WithEvents Vw_ProductosZiurTableAdapter As ModProd.ModProdDataSetTableAdapters.vw_ProductosZiurTableAdapter
  Friend WithEvents TableAdapterManager As ModProd.ModProdDataSetTableAdapters.TableAdapterManager
  Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
  Friend WithEvents stNumOrden As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents stFecha As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
  Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
  Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents btnAnexos As System.Windows.Forms.Button
  Friend WithEvents lstAnexos As System.Windows.Forms.CheckedListBox
  Friend WithEvents pcbAnexos As System.Windows.Forms.PictureBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents cmbTipoOrden As System.Windows.Forms.ComboBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents cmbArea As System.Windows.Forms.ComboBox
  Friend WithEvents cmbPlanta As System.Windows.Forms.ComboBox
  Friend WithEvents cmbSede As System.Windows.Forms.ComboBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
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
  Friend WithEvents grDetalleOrden As System.Windows.Forms.DataGridView
  Friend WithEvents Id As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCodigoInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colCantidad As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents IdInventario As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents colAgregar As System.Windows.Forms.DataGridViewCheckBoxColumn
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents cmdAgregarItem As System.Windows.Forms.Button
  Friend WithEvents txtCantidad As System.Windows.Forms.MaskedTextBox
  Friend WithEvents cmbProducto As System.Windows.Forms.ComboBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents txtOc As System.Windows.Forms.TextBox
  Friend WithEvents btnCrearCotizacionRapida As System.Windows.Forms.Button
  Friend WithEvents btnCargar As System.Windows.Forms.Button
  Friend WithEvents btnImprimir As System.Windows.Forms.Button
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents txtNumCotizacion As System.Windows.Forms.MaskedTextBox
  Friend WithEvents cmdValidar As System.Windows.Forms.Button
  Friend WithEvents lblNumeroOrden As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents cmdGuardar As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents dtpFechaRegistro As System.Windows.Forms.DateTimePicker
  Friend WithEvents ofdCargarAdjuntos As System.Windows.Forms.OpenFileDialog
  Friend WithEvents Label13 As System.Windows.Forms.Label
  Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
  Friend WithEvents Label14 As System.Windows.Forms.Label
  Friend WithEvents cmbResponsable As System.Windows.Forms.ComboBox
  Friend WithEvents cmdActualizaMateriales As System.Windows.Forms.Button
  Friend WithEvents stEstado As System.Windows.Forms.ToolStripStatusLabel
End Class
