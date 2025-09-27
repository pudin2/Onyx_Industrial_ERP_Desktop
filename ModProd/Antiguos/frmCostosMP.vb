Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO


Public Class frmCostosMP

  Private Sep As Char
  Private strCadena As String
  Private dtProducto As Data.DataTable, mUsuarioId As Integer
  Private strNombreProducto As String, strCodInventario As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
   
  Private Sub frmCostosMP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'TODO: esta línea de código carga datos en la tabla 'DsZiur.Inventarios_Precios' Puede moverla o quitarla según sea necesario.
    'Me.Inventarios_PreciosTableAdapter.Fill(Me.DsZiur.Inventarios_Precios)
    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    'IW = Me.Width
    'IH = Me.Height

    Me.Text = My.Settings.TituloSimulador
    'mEsNuevo = True

    'Detectar el separador decimal de la aplicación.
    Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Dim obCntv As New clConectividad

    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    obCntv.CadenaDeConeccion = strCadena

    dtProducto = obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DataSource = dtProducto  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DisplayMember = "Descripcion"

    Call CargarTodos()

    Me.Cursor = System.Windows.Forms.Cursors.Default
  End Sub

  Private Sub cmbProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbProducto.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")

    End If


  End Sub

  Private Sub cmbProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProducto.SelectedIndexChanged
    Me.Cursor = Cursors.WaitCursor

    Dim selectedItem As DataRowView
    selectedItem = cmbProducto.SelectedItem

    txtCosto.Text = CDec("0").ToString(FCTO_U)

    Dim objCntv As New clConectividad
    Dim drValor As MSSQL.SqlDataReader = objCntv.EjecutaComando("exec pa_BuscaCostoMP '" & selectedItem("CodInventario").ToString & "'", strCadena, True)

    drValor.Read()
    txtCosto.Text = CDec(drValor.Item("Costo").ToString).ToString(FCTO_U)
    strNombreProducto = selectedItem("Descripcion2").ToString
    strCodInventario = selectedItem("CodInventario").ToString
    lblTipoUnidad.Text = selectedItem("NomUnidad").ToString

    Me.Cursor = Cursors.Default

  End Sub

  'cargsr grilla con tabla y estados vacios
  'si modifican en la grilla, poner chulito y actualizar
  'si viene de combo es nuevo


 
  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

    Dim objItem As System.Data.DataRowView
    objItem = cmbProducto.SelectedItem

    Try
      strNombreProducto = cmbProducto.SelectedItem("Descripcion2").ToString  'cmbProducto.Text

    Catch ex As NullReferenceException
      strNombreProducto = cmbProducto.Text

    Catch ex As Exception

      MessageBox.Show("Se ha presentado el siguiente error: " & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try


    If txtCosto.Text <> "" Then

      Dim obMantenimiento As New clMantenimiento

      'obMantenimiento.GrabarCosto(strCadena, strCodInventario.ToString, vbEmpty, CDec(txtCosto.Text.ToString).ToString(FCTO_U), "A")
      obMantenimiento.GrabarCosto(strCadena, strCodInventario, CDec(txtCosto.Text.ToString).ToString(FCTO_U))
      Call CargarTodos()

      txtCosto.Text = ""
      strCodInventario = ""
      MessageBox.Show("Costo Grabado con éxito!", "Datos grabados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Else
      MessageBox.Show("Debe especificar el costo!", "Falta Costo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End If



  End Sub


  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...")
    Dim mCnt As Integer = 0
    Dim mColor As Color = cmbProducto.BackColor
    cmbProducto.BackColor = Color.Yellow
    cmbProducto.Text = strMensaje  '"Buscando ..."
    cmbProducto.Refresh()
    strFiltro = "descripcion like '%" & strFiltro & "%'"

    Dim result() As DataRow = dtProducto.Select(strFiltro)
    Dim dtFiltrado As Data.DataTable = dtProducto.Clone
    'ComboBox1.DisplayMember = "Descripcion"

    For Each row As DataRow In result
      'ComboBox1.Items.Add(row(2))
      'Dim filaNueva As DataRow =
      dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5))
      mCnt = mCnt + 1
    Next

    If mCnt = 0 Then
      MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Call BuscarItem("%", "Actualizando ...")
    End If

    cmbProducto.DataSource = dtFiltrado
    cmbProducto.DisplayMember = "Descripcion"

    cmbProducto.BackColor = mColor
    cmbProducto.Refresh()

  End Sub


  Private Sub CargarTodos()
    Dim objCntv As New clConectividad
    Dim drValor As MSSQL.SqlDataReader = objCntv.EjecutaComando("exec pa_BuscaCostoMP 'MP%',2", strCadena, True)

    grProductos.Rows.Clear()
    drValor.Read()

    Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
      If drValor.HasRows = True Then
        Dim strFilaNueva() As String

        strFilaNueva = {grProductos.Rows.Count + 1,
                        drValor.Item("CodInventario").ToString,
                        drValor.Item("Descripcion2").ToString,
                        drValor.Item("NomUnidad").ToString,
                        CDec(drValor.Item("Costo").ToString).ToString(FCTO_U),
                        drValor.Item("Estado").ToString
                       }
        grProductos.Rows.Add(strFilaNueva)
      End If
    Loop While drValor.Read()
    'grProductos.DataSource = drValor
    'grProductos.DataMember = drValor



  End Sub

End Class

