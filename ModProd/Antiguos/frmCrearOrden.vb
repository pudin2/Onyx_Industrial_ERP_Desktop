Imports MSSQL = System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Reporting.WinForms

Public Class frmCrearOrden
  Private strCadena As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mNumCotiza As Integer = 0
  Private dtProducto As Data.DataTable
  Private mIdNumeroCotizacionRapida As String
  Private mGuid As String = ""
  Private mVctAnexos As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private mTblCheckList As DataTable

  Private Sub frmCrearOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.vw_ProductosZiur' Puede moverla o quitarla según sea necesario.
    ' Me.Vw_ProductosZiurTableAdapter.Fill(Me.ModProdDataSet.vw_ProductosZiur)
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.TipoOrden' Puede moverla o quitarla según sea necesario.
    Me.TipoOrdenTableAdapter.Fill(Me.ModProdDataSet.TipoOrden)
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.AreasPlanta' Puede moverla o quitarla según sea necesario.
    Me.AreasPlantaTableAdapter.Fill(Me.ModProdDataSet.AreasPlanta)
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.Plantas' Puede moverla o quitarla según sea necesario.
    Me.PlantasTableAdapter.Fill(Me.ModProdDataSet.Plantas)
    'TODO: esta línea de código carga datos en la tabla 'ModProdDataSet.Sedes' Puede moverla o quitarla según sea necesario.
    Me.SedesTableAdapter.Fill(Me.ModProdDataSet.Sedes)


    Dim obCntv As New clConectividad
    strCadena = My.Settings.cnnModProd
    dtProducto = obCntv.LlenarDataTable(strCadena, "*", "Vw_ProductosZiur", "0=0")
    cmbProducto.DataSource = dtProducto  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DisplayMember = "Descripcion"


    cmbResponsable.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Responsables", "Estado='A'")
    cmbResponsable.DisplayMember = "Nombre" : cmbResponsable.ValueMember = "Id"

    mIdNumeroCotizacionRapida = My.Settings.IDNumeroCotizacionRapida

    stNumOrden.Text = ""
    stFecha.Text = ""


  End Sub



  Private Sub grDetalleOrden_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalleOrden.CellContentClick

  End Sub

  Private Sub cmdAgregarItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregarItem.Click

    If grDetalleOrden.RowCount < 1 Then
      Dim objItem As System.Data.DataRowView
      objItem = cmbProducto.SelectedItem

      If txtCantidad.Text <> "" Then

        Dim strFilaNueva() As String = {grDetalleOrden.Rows.Count + 1, objItem.Row("CodInventario").ToString(), objItem.Row("NomInventario").ToString() _
          , txtCantidad.Text, objItem.Row("IdInventario").ToString(), True}
        'strFilaNueva = "1"

        grDetalleOrden.Rows.Add(strFilaNueva)
        txtCantidad.Text = ""
      Else
        MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End If

    Else
      MessageBox.Show("Solamente se puede asignar un producto por orden!", "No se puede asignar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
    End If

    'MessageBox.Show(objItem.Row("CodInventario").ToString())
    'grDetalleOrden.Rows.Add( 
  End Sub
  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardar.Click
    If mDocCargado = False Then
      Call GrabarOrden("I", 0)
    Else
      Call GrabarOrden("U", CInt(lblNumeroOrden.Text.ToString))
    End If



  End Sub
  

  Private Sub GrabarOrden(ByVal Accion As String, ByVal Id As Integer)

    If grDetalleOrden.Rows.Count > 0 Then

      Dim cnn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString)
      Dim Cmd As New Data.SqlClient.SqlCommand

      cnn.Open()
      Cmd.Connection = cnn
      Cmd.CommandText = "pa_Insert_CabOrden @Accion,@Id, @TipoOrden_ID, @AreaPlanta_ID, @FechaRegistro, @CentroCosto_Id, @Tercero_Id, @Clase," _
        & "@Estado, @Observacion, @NotaSalidaInv, @NotaEntradaInv, @NumCotizacion, @Ocompra, @Responsable_Id"

      'Cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int)
      Cmd.Parameters.Add("@Accion", SqlDbType.Char, 1)
      Cmd.Parameters.Add("@Id", SqlDbType.BigInt)

      Cmd.Parameters.Add("@TipoOrden_ID", SqlDbType.Int)
      Cmd.Parameters.Add("@AreaPlanta_ID", SqlDbType.Int)
      Cmd.Parameters.Add("@FechaRegistro", SqlDbType.DateTime)
      Cmd.Parameters.Add("@CentroCosto_Id", SqlDbType.Int)
      Cmd.Parameters.Add("@Tercero_Id", SqlDbType.Int)
      Cmd.Parameters.Add("@Clase", SqlDbType.VarChar, 1)
      Cmd.Parameters.Add("@Estado", SqlDbType.VarChar, 1)
      Cmd.Parameters.Add("@Observacion", SqlDbType.VarChar, 600)
      Cmd.Parameters.Add("@NotaSalidaInv", SqlDbType.Int)
      Cmd.Parameters.Add("@NotaEntradaInv", SqlDbType.Int)
      Cmd.Parameters.Add("@NumCotizacion", SqlDbType.Int)
      Cmd.Parameters.Add("@Ocompra", SqlDbType.VarChar, 30)
      Cmd.Parameters.Add("@Responsable_ID", SqlDbType.Int)


      Dim objItem As System.Data.DataRowView

      objItem = cmbTipoOrden.SelectedItem
      Cmd.Parameters("@TipoOrden_ID").Value = objItem.Row("Id").ToString
      Dim TipoOrden_ID As Integer = objItem.Row("Id").ToString

      objItem = cmbArea.SelectedItem()
      Cmd.Parameters("@AreaPlanta_ID").Value = objItem.Row("Id").ToString
      Dim AreaPlanta_ID As Integer = objItem.Row("Id").ToString

      Cmd.Parameters("@FechaRegistro").Value = dtpFechaRegistro.Value
      Cmd.Parameters("@CentroCosto_Id").Value = 0
      Cmd.Parameters("@Tercero_Id").Value = 0
      Cmd.Parameters("@Clase").Value = "P"
      Cmd.Parameters("@Estado").Value = "R"
      Cmd.Parameters("@Observacion").Value = ""
      Cmd.Parameters("@NotaSalidaInv").Value = 0
      Cmd.Parameters("@NotaEntradaInv").Value = 0
      Cmd.Parameters("@NumCotizacion").Value = IIf(mNumCotiza = 0, txtNumCotizacion.Text, mNumCotiza)
      Cmd.Parameters("@Ocompra").Value = IIf(txtOc.Text = "", vbNull, txtOc.Text)

      objItem = cmbResponsable.SelectedItem()
      Cmd.Parameters("@Responsable_ID").Value = objItem.Row("Id").ToString

      Cmd.Parameters("@Accion").Value = Accion
      Cmd.Parameters("@id").Value = Id


      Dim NumeroOrden As String = Cmd.ExecuteScalar

      'MessageBox.Show("Listo " & NumeroOrden)

      cnn.Close()
      cnn = Nothing

      Call GrabarDetalleOrden(Accion, NumeroOrden, TipoOrden_ID, AreaPlanta_ID)

      lblNumeroOrden.Text = NumeroOrden.ToString
      'MessageBox.Show("Datos guardados correctamente!" & vbCrLf & "Orden número: " & NumeroOrden.ToString)



      'GRABO LOS ANEXOS

      Dim obCntv As New clConectividad
      Dim NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabOrden", "id > 0", strCadena)

      Dim NumCotizacion As String
      NumCotizacion = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabOrden", "id > 0", strCadena)
      '("CONVERT(int,valor)+1 [NumCotizacion]", "NumCotizacion", "Parametros", " ID=3", strCadena)

      If mDocCargado = False Then ' seguro para cuando se copia una cotizacion no de error en los anexos
        Dim strRuta As String = GrabarAnexos(NuevoID)
        Call ActualizarGUID(strRuta, mGuid, NumCotizacion)
      End If

      If MessageBox.Show("Datos guardados correctamente!" & vbCrLf & vbCrLf & "Orden número: " & NumeroOrden.ToString _
                         & vbCrLf & "Desea continuar editando la orden?", "Datos grabados", _
                       MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then

        Dim frm As New frmCrearOrden
        Me.Visible = False
        frm.Show()
        Me.Close()
      Else
        'Call CargarCotizacion(mNumCotiza)
        Call CargarOrden(NumeroOrden.ToString)
      End If

    End If

  End Sub

  Private Sub GrabarDetalleOrden(ByVal Accion As String, ByVal NumeroOrden As String, ByVal TipoOrden_ID As Integer, ByVal AreaPlanta_ID As Integer)
    Dim cnn As New Data.SqlClient.SqlConnection(ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString)
    Dim Cmd As New Data.SqlClient.SqlCommand

    cnn.Open()
    Cmd.Connection = cnn
    Cmd.CommandText = "pa_Insert_DetOrden @Accion,  @NumeroOrden, @TipoOrden_ID, @AreaPlanta_ID, @Id, @Inventario_Id, @Cantidad, @Costo"

    Cmd.Parameters.Add("@Accion", SqlDbType.Char, 1)
    Cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int)
    Cmd.Parameters.Add("@TipoOrden_ID", SqlDbType.Int)
    Cmd.Parameters.Add("@AreaPlanta_ID", SqlDbType.Int)
    Cmd.Parameters.Add("@Id", SqlDbType.Int)
    Cmd.Parameters.Add("@Inventario_Id", SqlDbType.Int)
    Cmd.Parameters.Add("@Cantidad", SqlDbType.Int)
    Cmd.Parameters.Add("@Costo", SqlDbType.Money)


    Dim Ff As Integer
    For Ff = 0 To grDetalleOrden.Rows.Count - 1
      Cmd.Parameters("@Accion").Value = Accion
      Cmd.Parameters("@NumeroOrden").Value = NumeroOrden
      Cmd.Parameters("@TipoOrden_ID").Value = TipoOrden_ID
      Cmd.Parameters("@AreaPlanta_ID").Value = AreaPlanta_ID
      Cmd.Parameters("@Id").Value = Ff
      Cmd.Parameters("@Inventario_Id").Value = CInt(grDetalleOrden.Rows(0).Cells(4).Value.ToString)
      Cmd.Parameters("@Cantidad").Value = CInt(grDetalleOrden.Rows(0).Cells(3).Value.ToString)
      Cmd.Parameters("@Costo").Value = 0

      Cmd.ExecuteNonQuery()

    Next Ff


  End Sub

  Private Sub cmdValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdValidar.Click
    Dim CabOrden_Id As String


    CabOrden_Id = InputBox("Orden a Validar: ", "Validar Orden", lblNumeroOrden.Text)

    If IsNumeric(CabOrden_Id) = True Then
      Dim obCntv As New clConectividad
      Dim strComando As String
      Dim strCadenaCnn As String = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString


      strComando = "pa_ValidaOrdenProduccion " & CabOrden_Id.ToString
      obCntv.EjecutaComando(strComando, strCadenaCnn, False)

      MessageBox.Show("Orden Validada con éxito!")

      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      'INICIO LA ASIGNACIÓN DE CAMPOS
      Dim strMargenes As String = obXml.LeerValor("frmOrdenProduccion_Margenes")
      Dim Pg2 As New System.Drawing.Printing.PageSettings()
      Dim Size2 = New Printing.PaperSize()
      Dim vctMedidas2() As String
      vctMedidas2 = Split(strMargenes, ",")
      Pg2.Margins.Top = CInt(vctMedidas2(0))
      Pg2.Margins.Bottom = CInt(vctMedidas2(1))
      Pg2.Margins.Left = CInt(vctMedidas2(2))
      Pg2.Margins.Right = CInt(vctMedidas2(3))
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


      Dim frm As New frmImprimeOP
      frm.strOrdenID = CabOrden_Id.ToString
      frm.strNombreReporte = My.Settings.NombreRptOrdenProduccion

      frm.rptReporte.SetPageSettings(Pg2)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
      frm.rptReporte.RefreshReport()


      frm.Show()

    Else
      MessageBox.Show("El valor escrito no es valido!", "Valor no valido")
    End If

  End Sub

  Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click


    Try
      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      'INICIO LA ASIGNACIÓN DE CAMPOS
      Dim strMargenes As String = obXml.LeerValor("frmOrdenProduccion_Margenes")
      Dim Pg2 As New System.Drawing.Printing.PageSettings()
      Dim Size2 = New Printing.PaperSize()
      Dim vctMedidas2() As String
      vctMedidas2 = Split(strMargenes, ",")
      Pg2.Margins.Top = CInt(vctMedidas2(0))
      Pg2.Margins.Bottom = CInt(vctMedidas2(1))
      Pg2.Margins.Left = CInt(vctMedidas2(2))
      Pg2.Margins.Right = CInt(vctMedidas2(3))
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


      Dim strOrden As String = InputBox("Número de Orden de Trabajo")
      Dim frm As New frmImprimeOP
      frm.strOrdenID = strOrden
      frm.strNombreReporte = My.Settings.NombreRptOrdenProduccion

      frm.rptReporte.SetPageSettings(Pg2)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
      frm.rptReporte.RefreshReport()

      frm.Show()

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Try


  End Sub

  Private Sub txtNumCotizacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNumCotizacion.KeyDown
    If e.KeyCode = Keys.Enter Then
      If txtNumCotizacion.Text <> "" Then
        Call CargaCotizacion(txtNumCotizacion.Text.ToString)
      End If
    End If

  End Sub


  Private Sub CargaCotizacion(ByVal strCotizacion As String)
    Dim obCntv As New clConectividad, strComando As String, strCab_Id As String

    grProductos.Rows.Clear()

    'PARTE ESPECIAL POR SI TIENE COTIZACION AJUSTADA
    Dim strTipo As String = ""


    If obCntv.LeerValorSencillo("count(1) [Cant]", "Cant", "CabCotizacion", _
                                "NumCotizacion= '" & strCotizacion.ToString & "' AND Tipo='OT'", strCadena) = 0 Then
      strTipo = " AND Estado='A' and tipo='CN'"
    Else
      strTipo = " AND Estado='R' and tipo='OT'"
    End If


    'strComando = "select id from CabCotizacion where NumCotizacion = '" & strCotizacion.ToString & "'"
    strCab_Id = obCntv.LeerValorSencillo("id", "CabCotizacion", _
                                        "NumCotizacion= '" & strCotizacion.ToString & "'" & strTipo _
                                        , strCadena)

    If strCab_Id = "" Then
      MessageBox.Show("Número de Cotización no encontrado!", "Buscar Cotización", MessageBoxButtons.OK, MessageBoxIcon.Error)
      txtNumCotizacion.SelectAll() : txtNumCotizacion.Focus()
      Exit Sub
    End If

    strComando = "pa_RPT_ConsulaCotizacion " & strCab_Id.ToString

    Dim drConsulta As SqlClient.SqlDataReader = _
      obCntv.EjecutaComando(strComando, strCadena, True)

    drConsulta.Read()
    If drConsulta.HasRows = True Then



      lblCliente.Text = drConsulta.Item("NombreCliente").ToString
      txtAlcance.Text = drConsulta.Item("Alcance").ToString
      txtProyecto.Text = drConsulta.Item("NombreProyecto").ToString
      txtObservaciones.Text = drConsulta.Item("Observacion").ToString
      txtObsInterna.Text = drConsulta.Item("ObsInterna").ToString
      mNumCotiza = drConsulta.Item("NumCotizacion").ToString
      txtNumCotizacion.Text = mNumCotiza.ToString

      Dim strFila() As String
      Do
        If drConsulta.Item("CodTipo") <> 4 Then

          strFila = {drConsulta.Item("CodInventario").ToString, _
                        CDec(drConsulta.Item("Cant").ToString()).ToString(FCANT), _
                        CDec(drConsulta.Item("Costo").ToString()).ToString(FCTO_U), _
                        CDec(drConsulta.Item("Total").ToString()).ToString(FCTOTOT)}

          grProductos.Rows.Add(strFila)
        End If
      Loop While drConsulta.Read()
    End If
  End Sub

  Private Sub cmbProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbProducto.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")

    End If
  End Sub


  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...")
    Dim mCnt As Integer = 0
    Dim mColor As Color = cmbProducto.BackColor
    cmbProducto.BackColor = Color.Yellow
    cmbProducto.Text = strMensaje  '"Buscando ..."
    cmbProducto.Refresh()
    strFiltro = "NomInventario like '%" & strFiltro & "%'"

    Dim result() As DataRow = dtProducto.Select(strFiltro)
    Dim dtFiltrado As Data.DataTable = dtProducto.Clone
    'ComboBox1.DisplayMember = "Descripcion"

    For Each row As DataRow In result
      'ComboBox1.Items.Add(row(2))
      'Dim filaNueva As DataRow =
      dtFiltrado.Rows.Add(row(0), row(1), row(2))
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


  Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
    Try

      Dim Orden As Integer = InputBox("Orden de Trabajo")
      stEstado.Visible = True : stEstado.BackColor = Color.Yellow
      Me.Refresh()
      Me.Cursor = Cursors.WaitCursor
      Call CargarOrden(Orden)
      cmdGuardar.Text = "Actualizar"
      mDocCargado = True
      stEstado.Visible = False
      Me.Cursor = Cursors.Default
    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try

  End Sub


  Private Sub CargarOrden(ByVal mOrden As Integer)
    Dim obCntv As New clConectividad, mNumCotizacion As Integer, mFecha As String = ""

    grDetalleOrden.Rows.Clear()

    Dim drOrden As MSSQL.SqlDataReader = _
      obCntv.LeerValor("*", "vw_ConsultarDetalleOrdenPT", "CabOrden_Id =" & mOrden, strCadena)

    If drOrden.HasRows = True Then
      Dim ff As Integer = 1
      cmbResponsable.SelectedIndex = drOrden.Item("Responsable_Id") '.ToString
      Do
        grDetalleOrden.Rows.Add({ _
              ff.ToString, _
              drOrden.Item("CodInventario").ToString, _
              drOrden.Item("Descripcion").ToString, _
              CDec(drOrden.Item("Cantidad").ToString).ToString(FCANT), _
              drOrden.Item("Producto_ID").ToString, _
              True})
        mNumCotizacion = drOrden.Item("NumCotizacion").ToString
        mFecha = drOrden.Item("FechaRegistro").ToString
      Loop While drOrden.Read

      


      Call CargaCotizacion(mNumCotizacion)
      ' cmbResponsable.SelectedIndex = 1
    End If

    stNumOrden.Text = "Orden: " & mOrden.ToString & Space(10)
    stFecha.Text = "Fecha: " & mFecha.ToString
    lblNumeroOrden.Text = mOrden.ToString
  End Sub


  Private Sub btnCrearCotizacionRapida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearCotizacionRapida.Click
    Dim frm As New frmSimuladorRapida
    frm.ShowDialog(Me)

    'El número del consecutivo
    Dim obCntv As New clConectividad
    Dim NumCotizacion As String
    NumCotizacion = obCntv.LeerValorSencillo("CONVERT(int,valor) [NumCotizacion]", "NumCotizacion", "Parametros", " ID=" & mIdNumeroCotizacionRapida, strCadena)
    txtNumCotizacion.Text = NumCotizacion
    Call CargaCotizacion(txtNumCotizacion.Text.ToString)


  End Sub


#Region "Manejo de Anexos"

  Private Function CrearGUID() As String
    Dim g As Guid
    ' Create and display the value of two GUIDs.
    g = Guid.NewGuid()
    CrearGUID = g.ToString
    'Console.WriteLine(g)
    'Console.WriteLine(Guid.NewGuid())
  End Function



  Private Sub btnAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click
    'El boton adjuntar, solamente carga el listado a subir
    'SE DEJA FILTRO DESDE ARCHIVO DE CONFIGURACION
    ofdCargarAdjuntos.Filter = My.Settings.FiltroAdjuntos  '"JPEG|*.jpg;*.jpeg;*.jpe;*.jfif"

    If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
      Dim strArchivo As String, Ff As Integer = 0

      For Each strArchivo In ofdCargarAdjuntos.FileNames
        lstAnexos.Items.Add(IO.Path.GetFileName(strArchivo), True)
        mVctAnexos.Add(strArchivo.ToString)

        'para controlar cuando se cargada la cotizacion
        If mDocCargado = True Then
          Dim mFila As DataRow = mTablaAnexos.NewRow
          mFila.Item("id") = 0
          mFila.Item("RutaArchivo") = strArchivo.ToString
          mFila.Item("NombreArchivo") = IO.Path.GetFileName(IO.Path.GetFileName(strArchivo))
          mFila.Item("Estado") = "N"
          mTablaAnexos.Rows.Add(mFila)
        End If
      Next

      If mVctAnexos.Count > 0 Then
        Call CargaImagen(mVctAnexos(1).ToString, False)
      End If

    End If


  End Sub

  Private Sub lstAnexos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstAnexos.KeyDown

    If e.KeyCode = Keys.Delete Then
      Dim Ff As Integer, VctAnexos As New Collection

      For Ff = 0 To lstAnexos.Items.Count - 1
        If lstAnexos.GetItemChecked(Ff) = True Then
          VctAnexos.Add(mVctAnexos(Ff + 1))
        End If
      Next

      lstAnexos.Items.Clear()
      mVctAnexos.Clear()

      For Each mItem In VctAnexos
        lstAnexos.Items.Add(IO.Path.GetFileName(mItem.ToString), True)
        mVctAnexos.Add(mItem)
      Next

      If mDocCargado = True Then ' CUANDO EL DOCUMENTO HA SIDO CARGADO TIENE OTRO MANEJO
        For Each mFila In mTablaAnexos.Rows
          mFila("Estado") = "I"
        Next

        For Each mItem In lstAnexos.Items
          Dim mFila() As DataRow = mTablaAnexos.Select("NombreArchivo = '" & mItem.ToString & "'")
          mFila(0)("Estado") = "A"
          'Dim mFila As DataRow = mTablaAnexos.NewRow

        Next

      End If
    End If

  End Sub

  Private Sub lstAnexos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAnexos.MouseDoubleClick
    Dim mLista = CType(sender, CheckedListBox)
    'Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString)

    'Process.Start(mVctAnexos(mLista.SelectedIndex + 1).ToString)
  End Sub


  Private Sub lstAnexos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnexos.SelectedIndexChanged

    Dim mLista = CType(sender, CheckedListBox)
    Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)

  End Sub

  Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
    Dim mImagen As Bitmap

    Try
      mImagen = New Bitmap(strImagen)
      pcbAnexos.Image = CType(mImagen, Image)

      'Catch ex As Exception
    Catch ex As System.ArgumentException
      If blCargar = True Then
        Process.Start(strImagen).ToString()
      End If
    Catch ex As Exception
      MessageBox.Show(ex.Message, ex.InnerException.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Try


  End Sub

  'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  '  Call GrabarAnexos()
  'End Sub

  Private Function GrabarAnexos(ByVal Cab_Id As String) As String
    Dim obCntv As New clConectividad
    Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=10", strCadena)
    Dim strMes As String = StrDup(2 - Len(Today.Month.ToString), "0") & Today.Month.ToString
    Dim strRutaCotiza As String

    If mNumCotiza = 0 Then
      strRutaCotiza = CrearGUID()
      mGuid = strRutaCotiza
    Else
      strRutaCotiza = mNumCotiza.ToString
    End If

    Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
    strRuta = strRuta & strRutaB
    If lstAnexos.SelectedItems.Count >= 0 Then
      IO.Directory.CreateDirectory(strRuta)
    End If
    'presento el cuadro para cargar los archivos
    'If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    Dim strArchivo As String, Ff As Integer

    'For Each strArchivo In mVctAnexos
    For Ff = 0 To lstAnexos.Items.Count - 1
      If lstAnexos.GetItemChecked(Ff) = True Then
        strArchivo = mVctAnexos(Ff + 1).ToString

        Dim strDestino As String = strRuta & "\" & IO.Path.GetFileName(strArchivo)
        Dim strInsert As String

        IO.File.Copy(strArchivo, strDestino)
        strInsert = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
          & strDestino.ToString & "','" & mGuid & "','A')"
        obCntv.EjecutaComando(strInsert, strCadena, False)
      End If
    Next
    'End If

    'FileIO.FileSystem.RenameDirectory(strRuta, "00AA")

    GrabarAnexos = strRuta
  End Function
  Private Sub ActualizarGUID(ByVal strRuta As String, ByVal Guid As String, ByVal NumCotizacion As String)
    'renombro la carpeta
    If lstAnexos.SelectedItems.Count > 0 Then
      FileIO.FileSystem.RenameDirectory(strRuta, NumCotizacion)

      Dim strUpdate As String
      strUpdate = "UPDATE AnexosOrden SET RutaArchivo = REPLACE(rutaarchivo, '" _
        & Guid & "' ,'" & NumCotizacion & "')" _
        & ", mGUID = '" & NumCotizacion & "' WHERE mGUID ='" & Guid & "'"

      Dim obCntv As New clConectividad
      obCntv.EjecutaComando(strUpdate, strCadena, False)

      Guid = ""
    End If
  End Sub

  Private Function CreaTablaAnexos() As Data.DataTable
    Dim mTabla As Data.DataTable
    mTabla = New DataTable("tblAnexos")

    Dim m_Id As DataColumn = New DataColumn("Id")
    m_Id.DataType = System.Type.GetType("System.Int32")

    Dim mRutaArchivo As DataColumn = New DataColumn("RutaArchivo")
    mRutaArchivo.DataType = System.Type.GetType("System.String")

    Dim mNombreArchivo As DataColumn = New DataColumn("NombreArchivo")
    mNombreArchivo.DataType = System.Type.GetType("System.String")

    Dim mEstado As DataColumn = New DataColumn("Estado")
    mEstado.DataType = System.Type.GetType("System.String")



    mTabla.Columns.Add(m_Id)
    mTabla.Columns.Add(mRutaArchivo)
    mTabla.Columns.Add(mNombreArchivo)
    mTabla.Columns.Add(mEstado)

    CreaTablaAnexos = mTabla
  End Function

  Private Sub ActualizarAnexos(ByVal Cab_Id As String)
    Dim obCntv As New clConectividad, strSql As String

    strSql = "update AnexosOrden set estado='I' where cab_Id=" & Cab_Id.ToString
    obCntv.EjecutaComando(strSql, strCadena, False)

    For Each mFila In mTablaAnexos.Rows
      If mFila("Estado") = "A" Then
        strSql = "update AnexosOrden set estado='A' where Id=" & mFila("Id")
        obCntv.EjecutaComando(strSql, strCadena, False)

      ElseIf mFila("Estado") = "N" Then
        Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=5", strCadena)
        Dim strFecha As Date = obCntv.LeerValorSencillo("fecha", "CabCotizacion", "id=" & Cab_Id.ToString, strCadena)
        Dim strMes As String = StrDup(2 - Len(strFecha.Month.ToString), "0") & strFecha.Month.ToString
        Dim strRutaCotiza As String = mNumCotiza.ToString

        Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
        strRuta = strRuta & strRutaB

        Dim strDestino As String = strRuta & "\" & IO.Path.GetFileName(mFila("NombreArchivo"))

        Try
          IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

          Dim strInsert As String = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumCotiza.ToString & "','A')"
          obCntv.EjecutaComando(strInsert, strCadena, False)

        Catch ex As System.IO.DirectoryNotFoundException
          IO.Directory.CreateDirectory(strRuta)
          IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

          Dim strInsert As String = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumCotiza.ToString & "','A')"
          obCntv.EjecutaComando(strInsert, strCadena, False)


        End Try

      End If
    Next


  End Sub




#End Region





  
  
  'Private Sub cmdActualizaMateriales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizaMateriales.Click
  '  Dim frm As New frmProductosOT_V2
  '  frm.NumCotizacionOriginal = txtNumCotizacion.Text
  '  frm.ShowDialog()
  '  CargaCotizacion(frm.SalidaNumCotiza)

  'End Sub

 

End Class