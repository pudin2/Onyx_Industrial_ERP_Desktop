Option Explicit On
Imports MSSQL = System.Data.SqlClient


Public Class frmPedidoManual
  Private dtProducto As Data.DataTable, strNombreProducto As String, strCodInventario As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private Sep As Char, mNumSolped As Integer, mDocCargado As Boolean, mUsuario_Id As Integer
  Private mRol_Id As Integer = 0

  Public Property Rol_Id As Integer
  Get
    Return mRol_Id
  End Get
  Set(value As Integer)
    mRol_Id = value
  End Set
  End Property


  Private Sub frmPedidoManual_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad, obInicio As New clSetUpInicio

      dtProducto = obCntv.LlenarDataTable(My.Settings.cnnModProd, False, "pa_ProductosTerminadosOEnProceso", "'','SI'", "dt_ProductosTerminadosOEnProceso")
      cmbProducto.DataSource = dtProducto
      cmbProducto.DisplayMember = "Descripcion"
      Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
      Call FormatoGrilla()


      mUsuario_Id = obCntv.LeerValorSencillo("Id", "Usuarios", "dominio='" & obInicio.Dominio & "' AND Usuario='" & obInicio.Usuario & "'", My.Settings.cnnModProd)

      ''HAGO LA PARTE DE MAQUILLAJE CUANDO ENTRAN LOS INGENIEROS
      'If mRol_Id = 1 Then 'Codigo de Rol de los ingenieros
      '  Me.Text = "Solicitud de Materiales"
      '  pnlOrdenDeTrabajo.Visible = True
      'End If
  End Sub


  Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
    If flyPanelBotones.Width = 190 Then
      flyPanelBotones.Width = 45
    Else
      flyPanelBotones.Width = 190
    End If
  End Sub

  Private Sub frmPedidoManual_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
  End Sub


  Private Sub cmbProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
    If e.KeyCode = Keys.F3 Then
        If e.Modifiers = Keys.Control Then
            Call BuscarItem(cmbProducto.Text, , True)
        Else
            Call BuscarItem(cmbProducto.Text)
        End If

    ElseIf e.KeyCode = Keys.F9 Then
        Call BuscarItem("%")

        'ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
        '   Call BuscarItem(cmbProducto.Text, , True)
    End If
    End Sub


  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional bolAvanzada As Boolean = 0)
    Dim mCnt As Integer = 0
    Dim mColor As Color = cmbProducto.BackColor
    cmbProducto.BackColor = Color.Yellow
    cmbProducto.Text = strMensaje  '"Buscando ..."
    cmbProducto.Refresh()


    Dim dtFiltrado As Data.DataTable


    If bolAvanzada = False Then
      dtFiltrado = dtProducto.Clone
      strFiltro = "descripcion like '%" & strFiltro & "%'"
      Dim result() As DataRow = dtProducto.Select(strFiltro)

      For Each row As DataRow In result
        dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5))
        mCnt = mCnt + 1
      Next

      If mCnt = 0 Then
          MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Call BuscarItem("%", "Actualizando ...")
      End If

    Else 'ENTRADA AL FILTRO AVANZADO
        Dim obCntv As New clConectividad

        strFiltro = "'" & strFiltro & "'"
        dtFiltrado = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "pa_ProductosTerminadosOEnProceso", strFiltro, "dt_ProductosTerminadosOEnProceso")
    End If

    cmbProducto.DataSource = dtFiltrado
    cmbProducto.DisplayMember = "Descripcion"
    cmbProducto.BackColor = mColor
    cmbProducto.Refresh()

    End Sub


  Private Sub cmbProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles cmbProducto.SelectedIndexChanged

      Dim selectedItem As DataRowView
      selectedItem = cmbProducto.SelectedItem

      txtCosto.Text = CDec("0").ToString(FCTO_U)

      Dim objCntv As New clConectividad

      Dim strFuenteCostoMP As String = objCntv.LeerValorSencillo("valor", "parametros", "id=8", My.Settings.cnnModProd)

      Dim drValor As MSSQL.SqlDataReader

      If UCase(strFuenteCostoMP) = "ZIUR" Then
          drValor = objCntv.EjecutaComando("exec CalcularCostoPromedioModProd " & selectedItem("id").ToString, My.Settings.cnnModProd, True)
      Else
          drValor = objCntv.EjecutaComando("exec pa_BuscaCostoMP '" & selectedItem("CodInventario").ToString & "',1", My.Settings.cnnModProd, True)
      End If

      drValor.Read()
      txtCosto.Text = CDec(drValor.Item("CostoProm").ToString).ToString(FCTO_U)
      strNombreProducto = selectedItem("Descripcion2").ToString
      strCodInventario = selectedItem("CodInventario").ToString
      lblTipoUnidad.Text = selectedItem("NomUnidad").ToString
      lblUnidad_Id.Text = selectedItem("IdUnidad").ToString


    End Sub

  Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
      Handles btnAdicionar.Click

      Dim objItem As System.Data.DataRowView
      objItem = cmbProducto.SelectedItem

      Try
          strNombreProducto = cmbProducto.SelectedItem("Descripcion2").ToString  'cmbProducto.Text

      Catch ex As NullReferenceException
          strNombreProducto = cmbProducto.Text

      Catch ex As Exception

          MessageBox.Show("Se ha presentado el siguiente error: " & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try


      If txtCantidad.Text <> "" And txtDescItem.Text <> "" Then

          Dim strFilaNueva() As String = {grProductos.Rows.Count + 1,
                                          strCodInventario.ToString,
                                          strNombreProducto.ToString,
                                          CDec(txtCantidad.Text.ToString).ToString(FCANT),
                                          CDec(txtCosto.Text.ToString).ToString(FCTO_U),
                                          (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString)).ToString(FCTOTOT),
                                          txtDescItem.Text,
                                          True, lblUnidad_Id.Text}

          grProductos.Rows.Add(strFilaNueva)
          txtCantidad.Text = ""
          txtCosto.Text = ""
          txtDescItem.Text = ""

          Call Calcular()
          strCodInventario = ""
      Else
          MessageBox.Show("Debe especificar la cantidad y descripción!", "Falta Cantidad y descripcion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtCantidad.KeyPress, txtCosto.KeyPress


        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True


    End Sub


    Private Sub FormatoGrilla()

      With grProductos
        .Columns("colId").Width = 30
        .Columns("colCodigoInventario").Width = 70
        .Columns("colDescripcion").Width = 377
        .Columns("colCantidad").Width = 75
        .Columns("colCosto").Width = 71
        .Columns("colCostoTotal").Width = 87
        .Columns("colDescItem").Width = 377
        .Columns("colAgregar").Width = 60

      End With

    End Sub


  Private Sub Calcular()
    Dim numTotal As Decimal, Ff As Integer, Validacion As Boolean = True
    Dim numTotalMP As Decimal = 0

    numTotal = 0

    For Ff = 0 To grProductos.RowCount - 1
        If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
            Dim mCantidad As Decimal, mCosto As Decimal

            mCantidad = CDec(IIf(grProductos.Rows(Ff).Cells(3).Value.ToString <> "", grProductos.Rows(Ff).Cells(3).Value.ToString, 0))
            mCosto = CDec(IIf(grProductos.Rows(Ff).Cells(4).Value.ToString <> "", grProductos.Rows(Ff).Cells(4).Value.ToString, 0))

            numTotal = numTotal + mCantidad * mCosto
            numTotalMP = numTotalMP + mCantidad * mCosto

            If mCantidad * mCosto = 0 Then
                Validacion = False
            End If
        End If
    Next

    lblTotalMateriales.Text = CDec(numTotal).ToString(FCTOTOT)

  End Sub


  Private Sub GrabarSolicitudCompra(ByVal strCab_Id As String)
    Dim Ff As Integer, obCntv As New clConectividad
    Dim obCompras As New clCompras

    For Ff = 0 To grProductos.Rows.Count - 1
      'GENERO LA SOLPED SI: SE SELECCIONA PARA COMPRA, SE HA REVISADO Y SI NO SE HA REPORTADO ANTES
      If grProductos.Item("colAgregar", Ff).Value = True Then

        Dim NuevaFila = obCompras.TablaDetSolicitud.NewDetSolicitudRow
        NuevaFila("Cab_Id") = strCab_Id
        NuevaFila("Id") = Ff + 1
        NuevaFila("CodInventario") = grProductos.Item("colDescripcion", Ff).Value
        NuevaFila("Inventario_ID") = grProductos.Item("colCodigoInventario", Ff).Value
        NuevaFila("Unidad_ID") = grProductos.Item("colIdUnidad", Ff).Value
        NuevaFila("Cant") = grProductos.Item("colCantidad", Ff).Value
        NuevaFila("Costo") = TxtADec(grProductos.Item("colCosto", Ff).Value)
        NuevaFila("Estado") = "R" 'A
        NuevaFila("FechaRequerida") = dtpFechaRequerida.Value 'grProductos.Item("colFechaRequerida", Ff).Value
        NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value


        obCompras.TablaDetSolicitud.AddDetSolicitudRow(NuevaFila)
      End If
    Next

    Dim maxId As String = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CabSolicitud", "1=1", My.Settings.cnnModProd )
    obCompras.GrabarSolicitud(My.Settings.cnnModProd, maxId.ToString, Today, strCab_Id, dtpFechaRequerida.Value, "R", "PM", mUsuario_Id)


    MessageBox.Show("Pedido grabado con el número " & maxId.ToString, "Pedido grabado", MessageBoxButtons.OK, MessageBoxIcon.Information)




  End Sub


  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
    Dim strMensaje As String = ""

    If mDocCargado = True Then
      strMensaje = "Desea actualizar la solicitud ahora?"
    Else
      strMensaje = "Desea generar la solicitud ahora?"
    End If

    If grProductos.Rows.Count <= 0 Then
      MessageBox.Show("No se han adicionado items al pedido!", "Pedido vacio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      Exit Sub
    End If


    If MessageBox.Show(strMensaje, "Grabar Pedido", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
      If mDocCargado = False Then
        Call GrabarSolicitudCompra(0)
      Else
        ActualizarPedido(mNumSolped, False)
      End If



    End If
  End Sub

  




  Private Sub cmdCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
    Dim Frm As New frmBuscar

    Frm.Text = "Buscar Pedido"
    Frm.lblDoc.Text = "Numero Ped" : Frm.txtDocumento.Tag = "id" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    Frm.txtDocumento.MaxLength = 10

    Frm.chkTexto.Text = "Alcance" : Frm.chkTexto.Visible = False
    Frm.chkFechas.Text = "Fecha   "
    Frm.chkTercero.Text = "Cliente  " : Frm.chkTercero.Visible = False


    Frm.txtTexto.Tag = "Alcance" : Frm.txtTexto.Visible = False
    Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
    Frm.cmbTercero.Tag = "NombreCliente" : Frm.cmbTercero.Visible = False

    Frm.strConsultaSQL = "CabSolicitud" : Frm.strCamposSQL = "Id, Fecha, Fecharequerida [Fecha Requerida], Estado"
    Frm.mWhereExterno = " AND estado in ('R','A') and tipodoc='PM'"

    Frm.ShowDialog()

    Dim dtConsulta As DataTable

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
      dtConsulta = Frm.dtSeleccionado.Copy
      ssBarraEstado.Text = "Pedido Número: " & dtConsulta.Rows(0).Item("Id")
      mNumSolped = dtConsulta.Rows(0).Item("Id")

      Call CargarPedido(mNumSolped)

      Dim mBoton As Button = Me.Tag
      mBoton.Text = Me.Text & " " & mNumSolped
      btnGrabar.Text = "Actualizar"

      mDocCargado = True
      btnGrabar.Text = "Actualizar"
    End If

    Frm.Dispose()
  End Sub

  Private Sub CargarPedido(mId As Integer)
    Dim obCntv As New clConectividad, strEstado As String


    Dim drDetSolped As MSSQL.SqlDataReader = _
    obCntv.LeerValor("*", "VW_DetalleSolicitud", "Cab_ID =" & mId.ToString, My.Settings.cnnModProd)


    strEstado = drDetSolped.Item("Estado").ToString
    dtpFechaRequerida.Value = drDetSolped.Item("FechaRequerida").ToString
    grProductos.Rows.Clear()



    Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
        'If drDetSolped.HasRows = True Then
            Dim strFilaNueva() As String


                strFilaNueva = {grProductos.Rows.Count + 1,
                                drDetSolped.Item("Inventario_ID").ToString,
                                drDetSolped.Item("CodInventario").ToString,
                                CDec(drDetSolped.Item("Cant").ToString).ToString(FCANT),
                                CDec(drDetSolped.Item("Costo").ToString).ToString(FCTO_U),
                                CDec(drDetSolped.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                drDetSolped.Item("DescItem").ToString,
                                True, drDetSolped.Item("IdUnidad").ToString}
                grProductos.Rows.Add(strFilaNueva)

        'End If
    Loop While drDetSolped.Read()



    btnGrabar.Visible = True
    If strEstado = "R" Then
      btnAprobar.Visible = True
      sslEstado.Text = "Pedido Manual: Registrado"
    Else
      btnAprobar.Visible = False
      btnGrabar.Visible = False
      sslEstado.Text = "Pedido Manual: Aprobado"
    End If




  End Sub

   Private Function TxtADec(ByVal strTxt As String) As Decimal
        TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
    End Function


  Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click
    Call ActualizarPedido(mNumSolped, True)
    Call CargarPedido(mNumSolped)

  End Sub


  Private Sub ActualizarPedido(strCab_Id As Integer, mAprobar As Boolean)
   Dim Ff As Integer, obCntv As New clConectividad
    Dim obCompras As New clCompras

    For Ff = 0 To grProductos.Rows.Count - 1
      'GENERO LA SOLPED SI: SE SELECCIONA PARA COMPRA, SE HA REVISADO Y SI NO SE HA REPORTADO ANTES
      If grProductos.Item("colAgregar", Ff).Value = True Then

        Dim NuevaFila = obCompras.TablaDetSolicitud.NewDetSolicitudRow
        NuevaFila("Cab_Id") = strCab_Id
        NuevaFila("Id") = Ff + 1
        NuevaFila("CodInventario") = grProductos.Item("colDescripcion", Ff).Value
        NuevaFila("Inventario_ID") = grProductos.Item("colCodigoInventario", Ff).Value
        NuevaFila("Unidad_ID") = grProductos.Item("colIdUnidad", Ff).Value
        NuevaFila("Cant") = grProductos.Item("colCantidad", Ff).Value
        NuevaFila("Costo") = TxtADec(grProductos.Item("colCosto", Ff).Value)
        NuevaFila("Estado") = "R"
        NuevaFila("FechaRequerida") = dtpFechaRequerida.Value 'grProductos.Item("colFechaRequerida", Ff).Value
        NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value

        obCompras.TablaDetSolicitud.AddDetSolicitudRow(NuevaFila)
      End If
    Next

    Dim strEstado As String = "R", strMensaje As String, strTitulo As String
    If mAprobar = True Then
      strEstado = "A"
      strMensaje = "Solicitud aprobada con éxito!"
      strTitulo = "Solicitud Aprobada"
    Else
      strMensaje = "Pedido actualizado éxito!"
      strTitulo = "Pedido grabado"
    End If

    obCompras.ActualizarSolicitud(strCab_Id, Today, strCab_Id, dtpFechaRequerida.Value, strEstado)
    obCompras = Nothing

    MessageBox.Show(strMensaje, strTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub

End Class
