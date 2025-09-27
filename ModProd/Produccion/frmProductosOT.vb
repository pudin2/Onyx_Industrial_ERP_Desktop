Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel


Public Class frmProductosOT
  Private obXml As New clManejoXML
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mEstado_Id_Actual As Integer
  Private Sep As Char
  Private strCadena As String
  Private mCabMov_Id As String, strNombreProducto As String, strCodInventario As String
  Private strNombreEmpleado As String, strIdentificacion As String
  Private mTotal As Decimal, strIdCliente As String, strNombreCliente As String
  Private mEsNuevo As Boolean, mNumCotiza As Integer = 0, mId As Integer
  Private dtProducto As Data.DataTable, mUsuarioId As Integer
  Private mGuid As String = ""
  Private mVctAnexos As New Collection, mVctAnexosE As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private mTblCheckList As DataTable, strNumCotizacion As String
  Private mSalidaNumCotiza As String, mNumCotizacionOriginal As String
  Private mNumOrden As String, mCabOrden_Id As Integer, mCantAnexosCot As Integer, mOTCabCotizacion_Id As Integer
  Private mDet_Id As String = "", mTipoOT As String
  Private mBolsa As Decimal, mGastoReal As Decimal, mControlarMateriales As String, mPorc_Consumido As Decimal, mDisp As Decimal
  Public mTipoEntrada As String = ""

  Private Structure OrdenDeTrabajo
    Public NumOrden As String
    Public CabOrden_Id As Integer
    Public CabCotizacion_id As Integer
    Public OTCabCotizacion_Id As Integer
    Public Presupuesto As Decimal
    Public ValMPCotizados As Decimal
    Public ValAIU As Decimal
    Public ValAdicional As Decimal
    Public ValEjecutado As Decimal
    Public Disponible As Decimal
  End Structure

  Private mOrdenDeTrabajo As OrdenDeTrabajo


  Private Enum EstadoPantalla As Integer
    Cargando
    Editando
  End Enum

  Private mEstadoPantalla As EstadoPantalla

  Public Property OTCabCotizacion_Id As Integer
  Get
    Return mOTCabCotizacion_Id
  End Get
  Set(value As Integer)
    mOTCabCotizacion_Id = value
  End Set
  End Property

  Public Property NumeroOT
    Get
      Return mNumOrden
    End Get
    Set(value)
      mNumOrden = value
    End Set
  End Property

  Public ReadOnly Property SalidaNumCotiza
    Get
      Return mSalidaNumCotiza
    End Get

  End Property

  Public Property NumCotizacionOriginal
    Get
      Return mNumCotizacionOriginal
    End Get
    Set(ByVal value)
      mNumCotizacionOriginal = value
    End Set
  End Property

  Public Property CabOrden_Id As Integer
  Get
    Return mCabOrden_Id
  End Get
  Set(value As Integer)
    mCabOrden_Id = value
  End Set
  End Property

  Private Sub frmSimulador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    mEstadoPantalla = EstadoPantalla.Cargando
    tbcContenido.Visible = False
    tbcContenido.SelectedTab = TabPage2


    'El objeto general para leer el XML
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUIMateriales.xml")
    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"
    Call NombrarBotones()


    'Me.Text = My.Settings.TituloSimulador
    mEsNuevo = True

    'Detectar el separador decimal de la aplicación.
    Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Dim obCntv As New clConectividad

    strCadena = My.Settings.cnnModProd 'ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    obCntv.CadenaDeConeccion = strCadena

    

    'obCntv.CadenaDeConeccion = My.Settings.cnnModProd

    dtProducto = obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DataSource = dtProducto  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DisplayMember = "Descripcion"


    cmbEmpleados.DataSource = obCntv.LlenarDataTable(strCadena, "*", "areasplanta", "estado in ('A','O')", "order by id")
    cmbEmpleados.DisplayMember = "Nombre"

    'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
    grTipoGastos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_TipoGastos", "Estado=0")
    Dim miCol As DataGridViewColumn
    miCol = grTipoGastos.Columns(0) : miCol.Width = 20
    miCol = grTipoGastos.Columns(1) : miCol.Width = 80
    miCol = grTipoGastos.Columns(2) : miCol.Width = 80
    miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    miCol = grTipoGastos.Columns(3) : miCol.Width = 20 : miCol.ReadOnly = False


    'LA PARTE DEL CHECKLIST DE MATERIALES
    mTblCheckList = obCntv.LlenarDataTable(strCadena, "*, convert(bit,0) [Valor]", "CheckList", "estado='A'")
    chkCheckListCotizacion.Items.Clear()
    For Each Fila As DataRow In mTblCheckList.Rows
      chkCheckListCotizacion.Items.Add(Fila.Item("Nombre").ToString, False)
    Next


    'PARTE DE LA CARGA DE LOS REPONSABLES
    cmbAsignadaA.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Responsables", "Estado='A'")
    cmbAsignadaA.DisplayMember = "Nombre"



    'EL MANEJO DE LOS ESTADOS
    chkListEstados.ClearSelected()

    Dim mUsuario As String, mDominio As String
    'mUsuario = Environment.UserName '& Environment.UserName.GetHashCode
    'mDominio = Environment.UserDomainName

    Dim obInicio As New clSetUpInicio
    mUsuario = obInicio.Usuario
    mDominio = obInicio.Dominio
    obInicio = Nothing


    Dim strWhere As String = "dominio='" & mDominio & "' and usuario='" & mUsuario & "'"
    mUsuarioId = obCntv.LeerValorSencillo("id", "Usuarios", strWhere, strCadena)

    Dim mRol_I As String = obCntv.LeerValorSencillo("Rol_id", "Usuarios", strWhere, strCadena)
    Dim mEstadoAnulado_Id As String = obCntv.LeerValorSencillo("Valor", "Parametros", "id=11", strCadena)


    Dim rsEstadosXRoles As MSSQL.SqlDataReader
    rsEstadosXRoles = obCntv.LeerValor("*", "EstadosXRoles", "Rol_Id = " & mRol_I & " and Estado_Id = " & mEstadoAnulado_Id, strCadena)

    If rsEstadosXRoles.HasRows Then
      ChkAnulada.Visible = True
    Else
      ChkAnulada.Visible = False

    End If

    obCntv = Nothing

    txtCosto.Text = CDec("0").ToString(FCTO_U)
    txtCantidad.Text = CDec("0").ToString(FCANT)
    txtCantMO.Text = CDec("0").ToString(FCANT)
    txtValorHora.Text = CDec("0").ToString(FCTO_U)
    stNumCotizacion.Text = ""
    stFecha.Text = ""


    Call CargarCotizacion()
    Call cargarDetCotizacionOriginal()

    sender.windowstate = FormWindowState.Maximized
    Me.Cursor = System.Windows.Forms.Cursors.Default
    mEstadoPantalla = EstadoPantalla.Editando

    tbcContenido.Visible = True

    '*********** ESPECIAL PARA LLAMADO MODAL DESDE OT OPCIÓN MAS MATERIAL *******
    If mTipoEntrada = "ModalMasMaterial" Then
        cmdCargar.Visible = False
        btnSigFase.Visible = False
        btnCalcular.Visible = False
        btnCancelarModal.Visible = True


    End If


  End Sub




  Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtCantidad.KeyPress, txtCosto.KeyPress, txtCantMO.KeyPress, txtValorHora.KeyPress, _
    txtTmpEntrega.KeyPress, txtTmpFabricacion.KeyPress, txtValorMontaje.KeyPress



    If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

    If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True


  End Sub

  Private Sub cmbEmpleados_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles cmbEmpleados.KeyPress


    strIdentificacion = ""
  End Sub


  Private Sub cmbEmpleados_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cmbEmpleados.SelectedIndexChanged


    'txtValorHora.Text = "0.00"

    Dim selectedItem As DataRowView
    selectedItem = cmbEmpleados.SelectedItem

    Try
      'txtValorHora.Text = FormatNumber(selectedItem("CostoMO").ToString, 2)
      txtValorHora.Text = CDec(selectedItem("CostoMO").ToString).ToString(FCTO_U)

    Catch ex As Exception
      txtValorHora.Text = 0
    End Try

    strNombreEmpleado = selectedItem("Nombre").ToString
    strIdentificacion = selectedItem("Id").ToString

  End Sub

  Private Sub cmbProducto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProducto.GotFocus
    sender.SelectAll()
  End Sub



  Private Sub cmbProducto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles cmbProducto.KeyPress


    strCodInventario = ""
  End Sub

  Private Sub cmbProductos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles cmbProducto.SelectedIndexChanged



    Dim selectedItem As DataRowView
    selectedItem = cmbProducto.SelectedItem

    txtCosto.Text = CDec("0").ToString(FCTO_U)

    Dim objCntv As New clConectividad

    Dim strFuenteCostoMP As String = objCntv.LeerValorSencillo("valor", "parametros", "id=8", strCadena)

    Dim drValor As MSSQL.SqlDataReader

    If UCase(strFuenteCostoMP) = "ZIUR" Then
      drValor = objCntv.EjecutaComando("exec CalcularCostoPromedioModProd " & selectedItem("id").ToString, strCadena, True)
    Else
      drValor = objCntv.EjecutaComando("exec pa_BuscaCostoMP '" & selectedItem("CodInventario").ToString & "',1", strCadena, True)
    End If



    drValor.Read()
    txtCosto.Text = CDec(drValor.Item("CostoProm").ToString).ToString(FCTO_U)
    strNombreProducto = selectedItem("Descripcion2").ToString
    strCodInventario = selectedItem("CodInventario").ToString
    lblTipoUnidad.Text = selectedItem("NomUnidad").ToString
    txtDisponible.Text = CDec(drValor.Item("Disponible").ToString).ToString(FCANT)
    If drValor.Item("Disponible") < CDec(IIf(txtCantidad.Text = "", 0, txtCantidad.Text.ToString)) Then
      txtAComprar.Text = CDec(IIf(txtCantidad.Text = "", 0, txtCantidad.Text.ToString) - drValor.Item("Disponible").ToString).ToString(FCANT)
    Else
      txtAComprar.Text = CDec("0").ToString(FCANT)
    End If

    '"Cantidad a Comprar: " & (CDec(drValor.Item("Disponible").ToString).ToString(FCTO_U) - IIf(txtCantidad.Text = "", 0, txtCantidad.Text.ToString)).ToString(FCTO_U)


  End Sub



  Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click


    Dim objItem As System.Data.DataRowView
    objItem = cmbProducto.SelectedItem

    Try
      strNombreProducto = cmbProducto.SelectedItem("Descripcion2").ToString  'cmbProducto.Text
    Catch ex As NullReferenceException
      strNombreProducto = cmbProducto.Text
      MessageBox.Show("Código de MP no existe. No se puede adicionar", "Error MP", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub

    Catch ex As Exception
      MessageBox.Show("Se ha presentado el siguiente error: " & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try


    If txtCantidad.Text <> "" Then
      'control del presupuesto
      '(CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))
      If mControlarMateriales = "SI" Then
        'Si el material adicionado, supera el presupuesto disponible
        If (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString)) > mOrdenDeTrabajo.Disponible Then  'mDisp Then
          MessageBox.Show("No se puede adicionar, el valor del material supera el presupuesto disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Exit Sub
        Else
          mOrdenDeTrabajo.Disponible = mOrdenDeTrabajo.Disponible - (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))
          lblDifDinero.Text = CDec(mOrdenDeTrabajo.Disponible).ToString(FCTOTOT)
          lblReal.Text = CDec(mOrdenDeTrabajo.ValEjecutado + (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))).ToString(FCTOTOT)
          mOrdenDeTrabajo.ValEjecutado = mOrdenDeTrabajo.ValEjecutado + (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))
          lblDifPorc.Text = CDec(mOrdenDeTrabajo.ValEjecutado / mOrdenDeTrabajo.Presupuesto).ToString("P")

        End If
      End If


      Dim bolComprar As Boolean = True
      If CDec(txtAComprar.Text) = 0 Then bolComprar = False

      Dim strFilaNueva() As String = {grProductos.Rows.Count + 1,
                                      strCodInventario.ToString,
                                      strNombreProducto.ToString,
                                      CDec(txtCantidad.Text.ToString).ToString(FCANT),
                                      CDec(txtCosto.Text.ToString).ToString(FCTO_U),
                                      (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString)).ToString(FCTOTOT),
                                      txtDescItem.Text,
                                      CDec(txtDisponible.Text.ToString).ToString(FCANT),
                                      CDec(txtAComprar.Text.ToString).ToString(FCANT),
                                      0,
                                      True, bolComprar, "", False, 0} '*** REVISAR PUNTO ACA ***

      grProductos.Rows.Add(strFilaNueva)
      txtCantidad.Text = "" : txtCosto.Text = ""
      txtDescItem.Text = "" : txtDisponible.Text = "" : txtAComprar.Text = ""


      Call Calcular()
      strCodInventario = ""
    Else
      MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End If
  End Sub

  Private Sub Calcular()
      Dim numTotal As Decimal, Ff As Integer, Validacion As Boolean = True


      numTotal = 0
      For Ff = 0 To grProductos.RowCount - 1
        If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
          Dim mCantidad As Decimal, mCosto As Decimal

          mCantidad = CDec(IIf(grProductos.Rows(Ff).Cells(3).Value.ToString <> "", grProductos.Rows(Ff).Cells(3).Value.ToString, 0))
          mCosto = CDec(IIf(grProductos.Rows(Ff).Cells(4).Value.ToString <> "", grProductos.Rows(Ff).Cells(4).Value.ToString, 0))

          numTotal = numTotal + mCantidad * mCosto
          If mCantidad * mCosto = 0 Then
            Validacion = False
          End If
        End If
      Next

      lblTotalMateriales.Text = CDec(numTotal).ToString(FCTOTOT)

      Dim numTotalMP As Decimal
      numTotalMP = 0
      For Ff = 0 To grProductosDC.RowCount - 1
          If grProductosDC.Rows(Ff).Cells("colAdicionar").Value = True Then
              Dim mCantidad As Decimal, mCosto As Decimal

              mCantidad = CDec(IIf(grProductosDC.Rows(Ff).Cells(3).Value.ToString <> "", grProductosDC.Rows(Ff).Cells(3).Value.ToString, 0))
              mCosto = CDec(IIf(grProductosDC.Rows(Ff).Cells(4).Value.ToString <> "", grProductosDC.Rows(Ff).Cells(4).Value.ToString, 0))

              numTotalMP = numTotalMP + mCantidad * mCosto
              If mCantidad * mCosto = 0 Then
                  Validacion = False
              End If
          End If
      Next

      lblTotalMat.Text = CDec(numTotalMP).ToString(FCTOTOT)

      If mControlarMateriales = "SI" Then
        Dim obCntv As New clConectividad
        'Dim strConsulta As String = "SELECT Valor from Parametros WHERE Descripcion='SemaforoVerde'"

        Dim _SemaforoVerde As Decimal = obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion='SemaforoVerde'", My.Settings.cnnModProd)
        Dim _SemaforoAmarillo As Decimal = obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion='SemaforoAmarillo'", My.Settings.cnnModProd)

      End If

      Dim numTotalMO As Decimal

      For Ff = 0 To grEmpleados.RowCount - 1
        If grEmpleados.Rows(Ff).Cells(6).Value = True Then
          Dim mCantidad As Decimal, mCosto As Decimal
          mCantidad = CDec(IIf(grEmpleados.Rows(Ff).Cells(3).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(3).Value.ToString, 0))
          mCosto = CDec(IIf(grEmpleados.Rows(Ff).Cells(4).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(4).Value.ToString, 0))


          numTotal = numTotal + mCantidad * mCosto
          numTotalMO = numTotalMO + mCantidad * mCosto

          If mCantidad * mCosto = 0 Then
            Validacion = False
          End If
        End If
      Next

        lblTotalMO.Text = CDec(numTotalMO).ToString(FCTOTOT)

        'det cotizacion
        Dim numTotalMaO As Decimal
        For Ff = 0 To grEmpleadosDC.RowCount - 1
            If grEmpleadosDC.Rows(Ff).Cells(6).Value = True Then
                Dim mCantidad As Decimal, mCosto As Decimal
                mCantidad = CDec(IIf(grEmpleadosDC.Rows(Ff).Cells(3).Value.ToString <> "", grEmpleadosDC.Rows(Ff).Cells(3).Value.ToString, 0))
                mCosto = CDec(IIf(grEmpleadosDC.Rows(Ff).Cells(4).Value.ToString <> "", grEmpleadosDC.Rows(Ff).Cells(4).Value.ToString, 0))


                numTotal = numTotal + mCantidad * mCosto
                numTotalMaO = numTotalMaO + mCantidad * mCosto

                If mCantidad * mCosto = 0 Then
                    Validacion = False
                End If
            End If
        Next

        lblTotalMaO.Text = CDec(numTotalMaO).ToString(FCTOTOT)


    'If Validacion = False Then
    '  MessageBox.Show("Existe mano de obra sin cantidad o costo!", "Validación mano de obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  Validacion = True
    'End If


    If chkMontaje.Checked = True Then
      For Ff = 0 To grTipoGastos.RowCount - 1
        If grTipoGastos.Rows(Ff).Cells(3).Value = True Then
          Dim mCosto As Decimal

          mCosto = CDec(IIf(grTipoGastos.Rows(Ff).Cells(2).Value.ToString <> "", grTipoGastos.Rows(Ff).Cells(2).Value.ToString, 0))
          numTotal = numTotal + mCosto


          If mCosto = 0 Then
            Validacion = False
          End If
        End If
      Next
    End If
    'If Validacion = False Then
    '  MessageBox.Show("Existe items de montaje sin costo!", "Validación montaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '  Validacion = True
    'End If

    numTotal = numTotal + CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) _
         + CDec(IIf(txtValorMontaje.Text = "", 0, txtValorMontaje.Text))

        txtUtilidad.Text = CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal
    mTotal = numTotal + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal

        lblTotal.Text = CDec(mTotal).ToString(FCTOTOT)

        ' 'det cotizacion
        ' numTotal = numTotal + CDec(IIf(txtImprevistosDC.Text = "", 0, txtImprevistosDC.Text)) _
        '+ CDec(IIf(txtValorMontaje.Text = "", 0, txtValorMontaje.Text))

        ' txtAIUdc.Text = CDec(IIf(txtAIU_MaO.Text = "", 0, txtAIU_MaO.Text)) / 100 * numTotal
        ' mTotal = numTotal + CDec(IIf(txtAIU_MaO.Text = "", 0, txtAIU_MaO.Text)) / 100 * numTotal
        Dim mUtilMontaje As Decimal

        txtUtilidadDC.Text = CDec((CDec(IIf(txtAIUdc.Text = "", 0, txtAIUdc.Text)) / 100 * numTotalMP) + (CDec(IIf(txtAIU_MaO.Text = "", 0, txtAIU_MaO.Text)) / 100 * numTotalMaO) + mUtilMontaje).ToString(FCTOTOT)

        mTotal = (numTotalMP + CDec(IIf(txtAIUdc.Text = "", 0, txtAIUdc.Text)) / 100 * numTotalMP) + _
               (numTotalMaO + CDec(IIf(txtAIU_MaO.Text = "", 0, txtAIU_MaO.Text)) / 100 * numTotalMaO) + _
               CDec(IIf(txtImprevistosDC.Text = "", 0, txtImprevistos.Text))
        lblTotalCot.Text = CDec(mTotal).ToString(FCTOTOT)
  End Sub



  Private Sub btnAdicionarMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarMO.Click


    Dim objItem As System.Data.DataRowView
    objItem = cmbProducto.SelectedItem

    strNombreEmpleado = cmbEmpleados.Text

    If txtCantMO.Text <> "" And txtValorHora.Text <> "" Then
      Dim vlTotal As Decimal
      vlTotal = CDec(txtCantMO.Text.ToString) * CDec(txtValorHora.Text.ToString)


      Dim strFilaNueva() As String = {grEmpleados.Rows.Count + 1,
                                      strIdentificacion.ToString,
                                      strNombreEmpleado.ToString,
                                      CDec(txtCantMO.Text.ToString).ToString(FCANT),
                                      CDec(txtValorHora.Text).ToString(FCTO_U),
                                      CDec(vlTotal.ToString).ToString(FCTOTOT),
                                      True}

      grEmpleados.Rows.Add(strFilaNueva)
      txtCantidad.Text = ""
      txtValorHora.Text = ""
      Call Calcular()
      strIdentificacion = ""
    Else
      MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End If
  End Sub

  Private Sub txtImprevistos_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtValorMontaje.LostFocus


    Call Calcular()
  End Sub



  'Private Sub GrabarProductosOT(ByVal strMensaje As String)

  '  btnGrabar.Text = "Grabando..."
  '  btnGrabar.Enabled = False

  '  Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer

  '  'GRABO LOS PRODUCTOS EN MEMORIA
  '  Ff_ID = 1
  '  For Ff = 0 To grProductos.RowCount - 1
  '    If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
  '      Dim NuevaFila = objCalc.DetCotizacion.NewRow()

  '      Ff_ID = Ff_ID + 1
  '      NuevaFila("Cab_ID") = 0
  '      NuevaFila("id") = Ff_ID
  '      NuevaFila("Tipo") = 1
  '      NuevaFila("CodInventario") = grProductos.Item(2, Ff).Value 'IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(2, Ff).Value)
  '      NuevaFila("Cant") = TxtADec(grProductos.Item(3, Ff).Value) 'CDec(IIf(grProductos.Item(3, Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
  '      NuevaFila("Costo") = TxtADec(grProductos.Item(4, Ff).Value) 'CDec(IIf(grProductos.Item(4, Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
  '      NuevaFila("Inventario_ID") = IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(1, Ff).Value)
  '      If grProductos.Item("colRevisado", Ff).Value = False Then
  '        NuevaFila("Estado") = "A" 'solo se ha registrado
  '      Else
  '        NuevaFila("Estado") = "R" 'cuando se ha revisado, pero no se ha enviado
  '      End If


  '      NuevaFila("CostoTotal") = TxtADec(grProductos.Item("colCostoTotal", Ff).Value) 'CDec(IIf(grProductos.Item("colCostoTotal", Ff).Value = 0, 0, grProductos.Item("colCostoTotal", Ff).Value))
  '      NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value
  '      objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

  '    End If
  '  Next

  '  'GRABO LA MANO DE OBRA EN MEMORIA
  '  For Ff = 0 To grEmpleados.RowCount - 1
  '    If grEmpleados.Rows(Ff).Cells("colAgregarMO").Value = True Then
  '      Dim NuevaFila = objCalc.DetCotizacion.NewRow()

  '      Ff_ID = Ff_ID + 1
  '      NuevaFila("Cab_ID") = 0
  '      NuevaFila("id") = Ff_ID
  '      NuevaFila("Tipo") = 2
  '      NuevaFila("CodInventario") = IIf(grEmpleados.Item(2, Ff).Value = "", 0, grEmpleados.Item(2, Ff).Value)
  '      NuevaFila("Cant") = TxtADec(grEmpleados.Item(3, Ff).Value)  'CDec(IIf(grEmpleados.Item(3, Ff).Value = 0, 0, grEmpleados.Item(3, Ff).Value))
  '      NuevaFila("Costo") = TxtADec(grEmpleados.Item(4, Ff).Value) 'CDec(IIf(grEmpleados.Item(4, Ff).Value = 0, 0, grEmpleados.Item(4, Ff).Value))
  '      NuevaFila("Estado") = "A"
  '      NuevaFila("CostoTotal") = TxtADec(grEmpleados.Item("colValorTotal", Ff).Value) 'CDec(IIf(grEmpleados.Item("colValorTotal", Ff).Value = 0, 0, grEmpleados.Item("colValorTotal", Ff).Value))
  '      objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

  '    End If
  '  Next

  '  'GRABO LOS OTROS REGISTRO DE DETALLE
  '  If txtImprevistos.Text <> "" Then
  '    Ff_ID = Ff_ID + 1
  '    Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
  '    NuevaFila2("Cab_ID") = 0
  '    NuevaFila2("id") = Ff_ID
  '    NuevaFila2("Tipo") = 3
  '    NuevaFila2("CodInventario") = "IMPREVISTOS"
  '    NuevaFila2("Cant") = 1
  '    NuevaFila2("Costo") = TxtADec(txtImprevistos.Text)
  '    NuevaFila2("Estado") = "A"
  '    NuevaFila2("CostoTotal") = TxtADec(txtImprevistos.Text)
  '    objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
  '    NuevaFila2 = Nothing
  '  End If

  '  If txtUtilidad.Text <> "" Then
  '    Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
  '    Ff_ID = Ff_ID + 1
  '    NuevaFila2 = objCalc.DetCotizacion.NewRow()
  '    NuevaFila2("Cab_ID") = 0
  '    NuevaFila2("id") = Ff_ID ' + 1
  '    NuevaFila2("Tipo") = 4
  '    NuevaFila2("CodInventario") = "UTILIDAD"
  '    NuevaFila2("Cant") = 1
  '    NuevaFila2("Costo") = TxtADec(txtUtilidad.Text)
  '    NuevaFila2("Estado") = "A"
  '    NuevaFila2("CostoTotal") = TxtADec(txtUtilidad.Text)
  '    objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
  '    NuevaFila2 = Nothing
  '  End If

  '  If chkMontaje.Checked = True Then
  '    Dim fF2 As Integer
  '    For fF2 = 0 To grTipoGastos.RowCount - 1
  '      Dim filaGrilla As DataGridViewRow = grTipoGastos.Rows(fF2)
  '      If filaGrilla.Cells(3).Value = True Then

  '        Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
  '        Ff_ID = Ff_ID + 1
  '        NuevaFila2 = objCalc.DetCotizacion.NewRow()
  '        NuevaFila2("Cab_ID") = 0
  '        NuevaFila2("id") = Ff_ID ' + 1
  '        NuevaFila2("Tipo") = 5
  '        NuevaFila2("CodInventario") = "MONTAJE - " & Trim(filaGrilla.Cells(1).Value.ToString)
  '        NuevaFila2("Cant") = 1
  '        NuevaFila2("Costo") = TxtADec(filaGrilla.Cells(2).Value)  'txtValorMontaje.Text
  '        NuevaFila2("Estado") = "A"
  '        NuevaFila2("Inventario_ID") = filaGrilla.Cells(0).Value.ToString
  '        NuevaFila2("CostoTotal") = TxtADec(filaGrilla.Cells(2).Value)

  '        objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
  '        NuevaFila2 = Nothing
  '      End If

  '    Next
  '  End If
  '  '********************************  FIN DE LA PARTE DE DETALLE DE LA COTIZACION ************




  '  txtAIU.Text = IIf(txtAIU.Text = "", 0, txtAIU.Text)
  '  txtImprevistos.Text = IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)

  '  Dim strPrecioFinal As Single
  '  If txtPrecioFinal.Text = "" Then
  '    strPrecioFinal = 0
  '  Else
  '    strPrecioFinal = CType(txtPrecioFinal.Text, Single)
  '  End If

  '  'El número del consecutivo
  '  Dim obCntv As New clConectividad
  '  Dim NumCotizacion As String
  '  NumCotizacion = strNumCotizacion


  '  Dim drCabProdOT As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabCotizacion", "NumCotizacion='" & NumCotizacion & "' and tipo='OT'", strCadena)
  '  Dim NuevoID

  '  If drCabProdOT.HasRows = False Then
  '    'HABILITAR
  '    objCalc.GrabarCotizacion(strCadena, dtpFecha.Value, txtObservacion.Text, strIdCliente, strNombreCliente, _
  '      txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
  '      txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, NumCotizacion.ToString, cmbAsignadaA.Text, lblTotal.Text, strPrecioFinal, _
  '      chkVentaDirecta.Checked, txtAIU.Text, txtImprevistos.Text, "R", txtObsInterna.Text, "OT", 0, "", 0, 0, 1)


  '    NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", strCadena)
  '    'GRABO LOS ESTADOS
  '    Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
  '    'strInsert = "Insert EstadosCotizacion values (" & NuevoID & ",1,'" & strHoy & "'," & mUsuarioId & ")"
  '    strInsert = "exec pa_Insert_EstadosCotizacion " & NuevoID & ",1," & mUsuarioId
  '    obCntv.EjecutaComando(strInsert, strCadena, False)

  '  Else
  '    NuevoID = drCabProdOT.Item("id").ToString
  '  End If


  '  'GRABO LOS ANEXOS
  '  If mDocCargado = False Then ' seguro para cuando se copia una cotizacion no de error en los anexos
  '    Dim strRuta As String = GrabarAnexos(NuevoID)
  '    Call ActualizarGUID(strRuta, mGuid, NumCotizacion)
  '  End If

  '  'GRABO LA LISTA DE CHEQUEO
  '  'Call GrabarCheckList(NuevoID)
  '  mId = NuevoID

  '  btnGrabar.Enabled = True
  '  btnGrabar.Text = "Grabar"
  '  obCntv = Nothing

  'End Sub

  Private Sub Imprimir(ByVal Cab_ID As Integer, ByVal VentaDirecta As Boolean)

    If VentaDirecta = True Then
      If MessageBox.Show("Esta cotizacíón es por venta directa." & vbCrLf & "Desea imprimir la lista de materiales?", "Imprimir Cotización", MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then
        VentaDirecta = False
      End If
    End If

    If VentaDirecta = False Then
      Dim Size1 = New Printing.PaperSize()
      Dim Pg1 As New System.Drawing.Printing.PageSettings()

      Dim frm As New frmImprimeCotiza
      frm.strCotizacion = Cab_ID
      frm.rptReporte.ServerReport.ReportPath = "/produccion/05_ImprimeCotizacion"


      Dim vctMedidas1() As String
      vctMedidas1 = Split(My.Settings.MargenesMaterialesCotizacion, ",")
      Pg1.Margins.Top = CInt(vctMedidas1(0))
      Pg1.Margins.Bottom = CInt(vctMedidas1(1))
      Pg1.Margins.Left = CInt(vctMedidas1(2))
      Pg1.Margins.Right = CInt(vctMedidas1(3))
      Pg1.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter
      frm.rptReporte.SetPageSettings(Pg1)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
      frm.rptReporte.RefreshReport()

      frm.Text = Me.Text
      frm.Show()
    End If

    Dim frmCarta As New frmImprimeCotiza
    frmCarta.strCotizacion = Cab_ID
    frmCarta.rptReporte.ServerReport.ReportPath = "/produccion/05_ImprimeCartaCotizacion"

    Dim Pg2 As New System.Drawing.Printing.PageSettings()
    Dim Size2 = New Printing.PaperSize()
    Dim vctMedidas2() As String
    vctMedidas2 = Split(My.Settings.MargenesCartaCotizacion, ",")
    Pg2.Margins.Top = CInt(vctMedidas2(0))
    Pg2.Margins.Bottom = CInt(vctMedidas2(1))
    Pg2.Margins.Left = CInt(vctMedidas2(2))
    Pg2.Margins.Right = CInt(vctMedidas2(3))
    Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter 'Size2
    frmCarta.rptReporte.SetPageSettings(Pg2)

    frmCarta.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
    frmCarta.rptReporte.RefreshReport()

    frmCarta.Text = Me.Text
    frmCarta.Show()



  End Sub



  Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    Try
      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      'INICIO LA ASIGNACIÓN DE CAMPOS
      Dim strMargenes As String = obXml.LeerValor("frmOrdenOT_Margenes")
      Dim Pg2 As New System.Drawing.Printing.PageSettings()
      Dim Size2 = New Printing.PaperSize()
      Dim vctMedidas2() As String
      vctMedidas2 = Split(strMargenes, ",")
      Pg2.Margins.Top = CInt(vctMedidas2(0))
      Pg2.Margins.Bottom = CInt(vctMedidas2(1))
      Pg2.Margins.Left = CInt(vctMedidas2(2))
      Pg2.Margins.Right = CInt(vctMedidas2(3))
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Folio


      Dim strOrden As String = mNumOrden.ToString   'InputBox("Número de Orden de Trabajo")
      Dim frm As New frmImprimeOT
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



  Private Sub cmbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCliente.KeyPress
    strIdCliente = "0"

  End Sub

  Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbCliente.SelectedItem

    strIdCliente = selectedItem("idCliente").ToString
    strNombreCliente = selectedItem("NombreCompleto").ToString


  End Sub



  Private Sub chkMontaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMontaje.CheckedChanged
    'txtValorMontaje.Visible = chkMontaje.Checked
    grTipoGastos.Visible = chkMontaje.Checked

  End Sub

  Private Sub cmdCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargar.Click
        'Call CargarCotizacion()
        Call CargarOTConBuscar()

  End Sub

  '*************** OPCIÓN 1 *****************
  Private Sub CargarCotizacion()
    Try

      Dim Cotiza As Integer
      If mNumCotizacionOriginal = "" Then
        Cotiza = InputBox("Cotizacion", "Carga Cotización", mNumCotizacionOriginal)
      Else
        Cotiza = mNumCotizacionOriginal
      End If

      Me.Cursor = Cursors.WaitCursor
      stEstado.Visible = True
      stEstado.Text = "Cargando cotización ..."
      Me.Refresh()

      Dim obCntv As New clConectividad
      Dim drCabProdOT As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabCotizacion", "NumCotizacion='" & Cotiza & "' and tipo='OT' AND ID=" & mOTCabCotizacion_Id.ToString, strCadena)

      If drCabProdOT.HasRows = False Then

                Call CargarCotizacion(Cotiza, "CN")

      Else
          sslCntAFabricar.Text = obCntv.LeerValorSencillo("CntAFabricar", "CabOt", "NumOrden='" & mNumOrden.ToString & "'", My.Settings.cnnModProd)
          Call CargarCotizacion(Cotiza, "OT")
          Dim mBoton As Button = Me.Tag
          mBoton.Text = mBoton.Text & " " & mNumOrden.ToString
          btnGrabar.Text = "Actualizar"
      End If


      strNumCotizacion = Cotiza
      mSalidaNumCotiza = Cotiza
      stNumOrden.Text = "OT: " & mNumOrden.ToString
      Call EstableceModoColumnas(grProductos)
      Call EstableceModoColumnas(grEmpleados)
      Call EstableceModoColumnas(grProductosRevisados)
      Call IgualaFormatosGrilla()


      'Muestro el estado de la OT
      Dim mEstadoActual As String '= obCntv.LeerValorSencillo("FaseActual", "Vw_EstadosOT", "NumOrden = " & mNumOrden & "", My.Settings.cnnModProd)
      Dim drEstadoActual As MSSQL.SqlDataReader = obCntv.LeerValor("FaseActual, EstadoFaseActual, Tipo", "Vw_EstadosOT", "NumOrden = " & mNumOrden, My.Settings.cnnModProd)

      mEstadoActual = drEstadoActual.Item("FaseActual").ToString
      mTipoOT = drEstadoActual.Item("Tipo").ToString
      stEstadoOT.Text = "Fase Actual: " & UCase(mEstadoActual)

      If drEstadoActual.Item("EstadoFaseActual").ToString = "PM" Then
          btnGrabar.Visible = True
          btnSigFase.Visible = True
      Else

          btnGrabar.Visible = False
          btnSigFase.Visible = False
          btnImprimir.Visible = False
          btnCompraParcial.Visible = False
      End If

      If mTipoOT = "CR" Then
          btnActualizaOTDirecta.Visible = True
      Else
          btnActualizaOTDirecta.Visible = False
      End If

            'validación usuario
            Dim mResponsableId As String  'Integer
            mResponsableId = obCntv.LeerValorSencillo("Usuario_Id", "Responsables", "Nombre = '" & txtAsignadaA.Text & "'", My.Settings.cnnModProd)
            If mResponsableId = "" Then mResponsableId = "0"

            If mUsuarioId <> CInt(mResponsableId) Then
                btnGrabar.Visible = False

            End If

            'APARTADO ESPECIAL PARA EDICION DE MATERIALES POR PARTE DE OSCAR JUNCA, EN CUALQUIER ETAPA
            Dim mRolesSuperioresProd As String = obCntv.LeerValorSencillo("valor", "Parametros", "descripcion='RolesSuperioresProd'", My.Settings.cnnModProd)

            Dim mCant As Integer = obCntv.LeerValorSencillo("Count(1) Cant", "Cant", "rolesxusuario", "rol_id in (" & mRolesSuperioresProd & ") and Usuario_Id = " & mUsuarioId.ToString, My.Settings.cnnModProd)

            If mCant > 0 Then
                btnGrabar.Visible = True
            End If

            Call CargarPresupuestoMateriales()

            stEstado.Text = ""
            stEstado.Visible = False
            Me.Cursor = Cursors.Default




        Catch ex As System.InvalidCastException
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message & vbCrLf & "DETALLE DEL ERROR:" & vbCrLf & ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
  End Sub


  Private Sub Actualizar()
    Dim objCalc As New clCalculadora, strFecha As Date

    strFecha = dtpFecha.Value
    If strIdCliente = "0" Then strNombreCliente = cmbCliente.Text.ToString

    'ORDENO TODO ANTES DE ACTUALIZAR PARA RESPETAR EL ORDEN ANTERIOR
    Call OrdenaParaGuardar(grProductos)
    Call OrdenaParaGuardar(grEmpleados)

    Dim strEstado As String
    If ChkAnulada.CheckState = CheckState.Checked Then
      strEstado = "I"
    Else
      strEstado = ""
    End If

    'ONYX 20180216 - OJO AJUSTAR EG
    objCalc.ActualizarCotizacion(strCadena, mId, strFecha, txtObservacion.Text, strIdCliente, strNombreCliente, _
      txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
      txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, mNumCotiza.ToString, cmbAsignadaA.Text, lblTotal.Text, txtPrecioFinal.Text, _
      chkVentaDirecta.Checked, txtAIU.Text.ToString, txtImprevistos.Text.ToString, txtObsInterna.Text.ToString, "OT", strEstado, 0, "", 0, 0)

    'Call ActualizarDetalle(mId)
    Call ActualizarDetalleOT()
    Call ActualizarAnexos(mCabOrden_Id) 'mId)

    If mTipoEntrada = "" Then
      MessageBox.Show("Actualización realizada con éxito!", "OT actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End If
  End Sub


  Private Sub ActualizarDetalle(ByVal Cab_ID As Integer)
    Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer
    Dim obCntv As New clConectividad ', strComando As String



    Ff_ID = 1
    For Ff = 0 To grProductos.RowCount - 1
      If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then

            Dim NuevaFila = objCalc.DetCotizacion.NewRow()

            Ff_ID = Ff_ID + 1
            NuevaFila("Cab_ID") = 0
            NuevaFila("id") = Ff_ID
            NuevaFila("Tipo") = 1
            NuevaFila("CodInventario") = grProductos.Item(2, Ff).Value 'IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(2, Ff).Value)
            NuevaFila("Cant") = CDec(IIf(grProductos.Item(3, Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
                NuevaFila("Costo") = CDec(IIf(grProductos.Item(4, Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
            If grProductos.Item("colRevisado", Ff).Value = True Then
              If grProductos.Item("colSTRevisado", Ff).Value.ToString = "E" Then
                  NuevaFila("Estado") = "E"
              Else
                  NuevaFila("Estado") = "R"
              End If
            Else
              NuevaFila("Estado") = "A"
            End If

            NuevaFila("CostoTotal") = CDec(IIf(grProductos.Item("ColCostoTotal", Ff).Value = 0, 0, grProductos.Item("ColCostoTotal", Ff).Value))
            NuevaFila("Inventario_ID") = IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(1, Ff).Value)
            NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value
            objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

      End If
    Next


    For Ff = 0 To grEmpleados.RowCount - 1
      If grEmpleados.Rows(Ff).Cells(6).Value = True Then
        Dim NuevaFila = objCalc.DetCotizacion.NewRow()

        Ff_ID = Ff_ID + 1
        NuevaFila("Cab_ID") = 0
        NuevaFila("id") = Ff_ID
        NuevaFila("Tipo") = 2
        NuevaFila("CodInventario") = IIf(grEmpleados.Item(2, Ff).Value = "", 0, grEmpleados.Item(2, Ff).Value)
        NuevaFila("Cant") = CDec(IIf(grEmpleados.Item(3, Ff).Value = 0, 0, grEmpleados.Item(3, Ff).Value))
        NuevaFila("Costo") = CDec(IIf(grEmpleados.Item(4, Ff).Value = 0, 0, grEmpleados.Item(4, Ff).Value))
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = CDec(IIf(grEmpleados.Item("colValorTotal", Ff).Value = 0, 0, grEmpleados.Item("colValorTotal", Ff).Value))
        objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

      End If
    Next

    If txtImprevistos.Text <> "" Then
      Ff_ID = Ff_ID + 1
      Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
      NuevaFila2("Cab_ID") = 0
      NuevaFila2("id") = Ff_ID
      NuevaFila2("Tipo") = 3
      NuevaFila2("CodInventario") = "IMPREVISTOS"
      NuevaFila2("Cant") = 1
      NuevaFila2("Costo") = CDec(txtImprevistos.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = CDec(txtImprevistos.Text)
      objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
      NuevaFila2 = Nothing
    End If

    If txtUtilidad.Text <> "" Then
      Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
      Ff_ID = Ff_ID + 1
      NuevaFila2 = objCalc.DetCotizacion.NewRow()
      NuevaFila2("Cab_ID") = 0
      NuevaFila2("id") = Ff_ID ' + 1
      NuevaFila2("Tipo") = 4
      NuevaFila2("CodInventario") = "UTILIDAD"
      NuevaFila2("Cant") = 1
      NuevaFila2("Costo") = CDec(txtUtilidad.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = CDec(txtUtilidad.Text)
      objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
      NuevaFila2 = Nothing
    End If

    If chkMontaje.Checked = True Then
      Dim fF2 As Integer
      For fF2 = 0 To grTipoGastos.RowCount - 1
        Dim filaGrilla As DataGridViewRow = grTipoGastos.Rows(fF2)
        If filaGrilla.Cells(3).Value = True Then

          Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
          Ff_ID = Ff_ID + 1
          NuevaFila2 = objCalc.DetCotizacion.NewRow()
          NuevaFila2("Cab_ID") = 0
          NuevaFila2("id") = Ff_ID ' + 1
          NuevaFila2("Tipo") = 5
          NuevaFila2("CodInventario") = "MONTAJE - " & Trim(filaGrilla.Cells(1).Value.ToString)
          NuevaFila2("Cant") = 1
          NuevaFila2("Costo") = filaGrilla.Cells(2).Value  'txtValorMontaje.Text
          NuevaFila2("Estado") = "A"
          NuevaFila2("Inventario_ID") = filaGrilla.Cells(0).Value.ToString
          NuevaFila2("CostoTotal") = filaGrilla.Cells(2).Value
          objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
          NuevaFila2 = Nothing
        End If

      Next
    End If


    'ACTUALIZO COMO ELIMINADOS LOS ITEMS QUE SE HAYAN ELIMINADO POR PARTE DEL USUARIO
    If mDet_Id <> "" Then
      mDet_Id = Microsoft.VisualBasic.Strings.Left(mDet_Id, Len(mDet_Id) - 1)
        obCntv.ActualizaValor("Estado='I'", "DetCotizacion", "id in(" & mDet_Id & ")", My.Settings.cnnModProd)
    End If

    'ACTUALIZO EL DETALLE DE LA COTIZACION_OT
    objCalc.ActualizaDetalleCotiza(Cab_ID, strCadena)


  End Sub


  Private Sub GrabarSolicitudCompra(ByVal strCab_Id As String)
    Dim Ff As Integer, obCntv As New clConectividad
    Dim obCompras As New clCompras

    For Ff = 0 To grProductosRevisados.Rows.Count - 1
        'GENERO LA SOLPED SI: SE SELECCIONA PARA COMPRA, SE HA REVISADO Y SI NO SE HA REPORTADO ANTES
        If grProductosRevisados.Item("colComprar2", Ff).Value = True And grProductosRevisados.Item("colRevisado2", Ff).Value = True And _
        grProductosRevisados.Item("colSTRevisado2", Ff).Value.ToString <> "E" Then

              Dim NuevaFila = obCompras.TablaDetSolicitud.NewDetSolicitudRow
              NuevaFila("Cab_Id") = strCab_Id
              NuevaFila("Id") = grProductosRevisados.Item("colDet_ID2", Ff).Value 'Ff + 1
              NuevaFila("CodInventario") = grProductosRevisados.Item("colDescripcion2", Ff).Value
              NuevaFila("Inventario_ID") = grProductosRevisados.Item("colCodigoInventario2", Ff).Value
              NuevaFila("Cant") = grProductosRevisados.Item("colCntComprar2", Ff).Value
              NuevaFila("Estado") = "R"
              NuevaFila("FechaRequerida") = dtpFechaRequerida.Value 'grProductos.Item("colFechaRequerida", Ff).Value
              NuevaFila("DescItem") = grProductosRevisados.Item("colDescItem2", Ff).Value


              obCompras.TablaDetSolicitud.AddDetSolicitudRow(NuevaFila)
        End If
    Next

    grProductosRevisados.Rows.Clear()


    Dim maxId As String = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CabSolicitud", "1=1", strCadena)
    obCompras.GrabarSolicitud(strCadena, maxId.ToString, Today, strCab_Id, dtpFechaRequerida.Value, "R", "OT".ToString, mUsuarioId)
    obCompras = Nothing
    obCntv = Nothing

  End Sub


  Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
    Try

      Dim Cotiza As Integer = InputBox("Cotizacion", , mNumCotiza)

      Dim objCntv As New clConectividad
      Dim strConsulta As String = "UPDATE cabCotizacion set estado='V' where numcotizacion='" & Cotiza & "'"

      Dim strEstadoActual As String = objCntv.LeerValorSencillo("estado", "cabcotizacion", "numcotizacion='" & Cotiza & "'", strCadena)

      If strEstadoActual = "R" Then

        objCntv.EjecutaComando(strConsulta, strCadena, False)
        MessageBox.Show("Cotización Validada con éxito!", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
        MessageBox.Show("Esta cotización no se pude aprobar.", "", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If


    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try


  End Sub




  Private Sub grTipoGastos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grTipoGastos.DataError
    MessageBox.Show("Datos no validos en la celda: " _
        & e.Exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)



    e.ThrowException = False


  End Sub

  Private Sub cmbProducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProducto.TextChanged

    ' Call BuscarItem(cmbProducto.Text)
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



  Private Sub cmbProducto_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProducto.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbProducto.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")

    End If
  End Sub

  Private Sub txtCosto_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCosto.LostFocus, txtValorHora.LostFocus, txtImprevistos.LostFocus


    'sender.Text = Format(CType(IIf(sender.Text = "", 0, sender.text), Decimal), "#,##0.00")
    sender.Text = CDec(IIf(sender.Text = "", 0, sender.text)).ToString(FCTO_U)
    Call Calcular()
  End Sub


  Private Sub txtCantidad_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCantidad.LostFocus, txtCantMO.LostFocus


    'sender.Text = Format(CType(IIf(sender.Text = "", 0, sender.text), Decimal), "#,##0.00")
    sender.Text = CDec(IIf(sender.Text = "", 0, sender.text)).ToString(FCANT)

  End Sub

  Private Sub txtCosto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtCosto.GotFocus, txtValorHora.GotFocus, txtCantidad.GotFocus, _
            txtCantMO.GotFocus, txtPrecioFinal.GotFocus

    sender.SelectAll()
  End Sub


  '****************************  OPCIÓN 2 **************
  Private Sub CargarCotizacion(ByVal mNumCotizacion As Integer, ByVal mTipo As String)
    Try
'Debug.Flush()
'Debug.Print(Now.TimeOfDay.ToString)
      Dim Cotiza As Integer = mNumCotizacion

      Dim objCntv As New clConectividad, fF As Integer
      Dim strConsulta As String = "Select "

      'CARGA LA CABECERA
      Dim drCabCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "CabCotizacion", "NumCotizacion =" & mNumCotizacion & " and tipo='" & mTipo & "' AND Id=" & mOTCabCotizacion_Id.ToString, strCadena)
      'objCntv.LeerValor("*", "CabCotizacion", "NumCotizacion =" & mNumCotizacion & " and estado<>'I'", strCadena)


      strIdCliente = drCabCotiza.Item("IdCliente").ToString
      strNombreCliente = drCabCotiza.Item("NombreCliente").ToString
      cmbCliente.Text = strNombreCliente
            txtCliente.Text = strNombreCliente


      txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
      txtAlcance.Text = drCabCotiza.Item("Alcance").ToString
      txtObservacion.Text = drCabCotiza.Item("Observacion").ToString
      cmbAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString
      cmbAsignadaA.Tag = drCabCotiza.Item("AsignadoA").ToString
      txtAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString
      txtAsignadaA.Tag = drCabCotiza.Item("AsignadoA").ToString

      stAsignadaA.Text = "Asignadada a: " & drCabCotiza.Item("AsignadoA").ToString

      txtTmpFabricacion.Text = drCabCotiza.Item("TiempoFabricacion").ToString
      txtTmpEntrega.Text = drCabCotiza.Item("TiempoEntrega").ToString
      txtReq.Text = drCabCotiza.Item("Requisicion").ToString
      chkMontaje.Checked = CBool(drCabCotiza.Item("RequiereMontaje"))
      chkVentaDirecta.Checked = CBool(drCabCotiza.Item("VentaDirecta"))
      txtDirigidaA.Text = drCabCotiza.Item("DirigidaA").ToString
      txtFormaPago.Text = drCabCotiza.Item("FormaPago").ToString
      'txtPrecioFinal.Text = FormatCurrency(drCabCotiza.Item("PrecioFinal").ToString, 0)
      txtPrecioFinal.Text = CDec(drCabCotiza.Item("PrecioFinal").ToString).ToString(FCTOTOT)
      txtImprevistos.Text = CDec(IIf(drCabCotiza.Item("Imprevistos").ToString <> "", drCabCotiza.Item("Imprevistos").ToString, 0)).ToString(FCTOTOT)
      txtAIU.Text = CInt(drCabCotiza.Item("AIU").ToString)
      lblEstado.Text = drCabCotiza.Item("Estado").ToString
            txtObsInterna.Text = drCabCotiza.Item("ObsInterna").ToString
      stNumCotizacion.Text = "Cotización: " & mNumCotizacion.ToString & "      "
      stFecha.Text = "Fecha de Registro: " & drCabCotiza.Item("Fecha").ToString


                mNumCotiza = mNumCotizacion
                mId = drCabCotiza.Item("id").ToString
                mEsNuevo = False

                'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
                grTipoGastos.DataSource = objCntv.LlenarDataTable(strCadena, "*", _
                                          "fn_TipoGastosGrabados(" & mId.ToString & ")", "0=0")

                Dim miCol As DataGridViewColumn
                miCol = grTipoGastos.Columns(0) : miCol.Width = 20
                miCol = grTipoGastos.Columns(1) : miCol.Width = 80
                miCol = grTipoGastos.Columns(2) : miCol.Width = 80
                miCol.DefaultCellStyle.Format = FCTOTOT : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                miCol = grTipoGastos.Columns(3) : miCol.Width = 20 : miCol.ReadOnly = False


                'CARGA EL DETALLE PRODUCTOS
                grProductos.Rows.Clear()
                grProductosRevisados.Rows.Clear()
                grEmpleados.Rows.Clear()
                Dim drDetCotiza As MSSQL.SqlDataReader = _
                  objCntv.LeerValor("*", "VW_DetalleOTconStock", "Cab_ID =" & drCabCotiza.Item("id").ToString & " and tipo in (1,2) order by id", strCadena)

                Dim pmEstadoRevisado As Boolean = False

'Debug.Print(Now.TimeOfDay.ToString)

                Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
                    If drDetCotiza.HasRows = True Then
                        Dim strFilaNueva() As String
                        If drDetCotiza.Item("Tipo").ToString = "1" Then

                            If drDetCotiza.Item("Estado").ToString = "A" Then
                                pmEstadoRevisado = False
                            Else
                                pmEstadoRevisado = True
                            End If

                            If pmEstadoRevisado = True Then
                                strFilaNueva = {grProductosRevisados.Rows.Count + 1,
                                              drDetCotiza.Item("Inventario_ID").ToString,
                                              drDetCotiza.Item("CodInventario").ToString,
                                              CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                              CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                              drDetCotiza.Item("DescItem").ToString,
                                              CDec(drDetCotiza.Item("Disponible").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Cnt_PDEliminados").ToString).ToString(FCANT),
                                              True, IIf(CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT) > 0, True, False),
                                              "", pmEstadoRevisado, CInt(pmEstadoRevisado), drDetCotiza.Item("ID").ToString} 'ONYX, ACA VOY

                                grProductosRevisados.Rows.Add(strFilaNueva)

                                If drDetCotiza.Item("Estado").ToString = "R" Then ' si el item ya se revisó
                                    grProductosRevisados.Item("colCodigoInventario2", grProductosRevisados.Rows.Count - 1).Style.BackColor = Color.FromArgb(103, 177, 49) '(0, 255, 0)
                                    grProductosRevisados.Item("colDescripcion2", grProductosRevisados.Rows.Count - 1).Style.BackColor = Color.FromArgb(103, 177, 49)

                                ElseIf drDetCotiza.Item("Estado").ToString = "E" Then 'SI EL ITEM YA SE ENVIO A PLANEACIÓN
                                    grProductosRevisados.Rows(grProductosRevisados.Rows.Count - 1).DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
                                    grProductosRevisados.Item("colSTRevisado2", grProductosRevisados.Rows.Count - 1).Value = "E" 'para ser leido al grabar y reportar parcial
                                    grProductosRevisados.Rows(grProductosRevisados.Rows.Count - 1).ReadOnly = True
                                End If

                            Else
                                strFilaNueva = {grProductos.Rows.Count + 1,
                                              drDetCotiza.Item("Inventario_ID").ToString,
                                              drDetCotiza.Item("CodInventario").ToString,
                                              CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                              CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                              drDetCotiza.Item("DescItem").ToString,
                                              CDec(drDetCotiza.Item("Disponible").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT),
                                              CDec(drDetCotiza.Item("Cnt_PDEliminados").ToString).ToString(FCANT),
                                              True, IIf(CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT) > 0, True, False),
                                              "", pmEstadoRevisado, CInt(pmEstadoRevisado), drDetCotiza.Item("ID").ToString} 'ONYX, ACA VOY

                                grProductos.Rows.Add(strFilaNueva)

                            End If


                        ElseIf drDetCotiza.Item("Tipo").ToString = "5" Then
                            strFilaNueva = {grTipoGastos.Rows.Count + 1,
                                            drDetCotiza.Item("CodInventario").ToString,
                                            CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                            True}
                        Else
                            strFilaNueva = {grEmpleados.Rows.Count + 1,
                                            "",
                                            drDetCotiza.Item("CodInventario").ToString,
                                            CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                            CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                            CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                            True}
                            '(drDetCotiza.Item("Cant").ToString * drDetCotiza.Item("Costo").ToString).ToString(FCTOTOT),
                            grEmpleados.Rows.Add(strFilaNueva)
                        End If
                    End If

                Loop While drDetCotiza.Read()
'Debug.Print(Now.TimeOfDay.ToString)

                Call EstableceModoColumnas(grProductos)
                Call EstableceModoColumnas(grProductosRevisados)

                Call Calcular()
'Debug.Print("ANEXOS--> " & Now.TimeOfDay.ToString)

                'CARGO LOS ANEXOS ****************************************************************************
                Dim drAnexos As MSSQL.SqlDataReader ', ii As Integer = 0
                mTablaAnexos = CreaTablaAnexos()

      'drAnexos = objCntv.LeerValor("*", "AnexosOrden", "Cab_ID =" & mCabOrden_Id.ToString & " and estado<>'I'", strCadena)
      drAnexos = objCntv.EjecutaComando("exec pa_Anexos " & mNumOrden, My.Settings.cnnModProd, True)
      lstAnexos.Items.Clear() : mVctAnexos.Clear()

      Do While drAnexos.Read()
        If drAnexos.HasRows = True Then
          lstAnexos.Items.Add(IO.Path.GetFileName(drAnexos.Item("RutaArchivo").ToString))
          mVctAnexos.Add(drAnexos.Item("RutaArchivo").ToString)
          Dim mFila As DataRow = mTablaAnexos.NewRow
          mFila.Item("id") = drAnexos.Item("id")
          mFila.Item("RutaArchivo") = drAnexos.Item("RutaArchivo")
          mFila.Item("Estado") = drAnexos.Item("Estado")
          mTablaAnexos.Rows.Add(mFila)
        End If
      Loop 'While ' drAnexos.Read()

'  Debug.Print("ESTADOS--> " & Now.TimeOfDay.ToString)

      'CARGO PRIMERO LOS ENTREGADOS, SI HAY UNO EN PROCESO DE REVISION, SE MUESTRA DESPUES
      
                'If lstAnexos.Items.Count > 0 Then
                '    Call CargaImagen(mVctAnexos(1).ToString, False)
                'End If

                'LOS ESTADOS DE LA ORDEN
                Dim drEstadosCotiza As MSSQL.SqlDataReader = _
                  objCntv.LeerValor("*", "vw_EstadosCotizacion", "Cab_ID =" & mId.ToString, strCadena)
                Dim mMaxEstado As Integer

                Dim jj As Integer
                For jj = 0 To 4
                    chkListEstados.SetItemCheckState(jj, CheckState.Unchecked)
                Next

                Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
                    chkListEstados.SetItemChecked(drEstadosCotiza("id") - 1, True)
                    mMaxEstado = IIf(drEstadosCotiza("id") > mMaxEstado, drEstadosCotiza("id"), mMaxEstado)
                    fF = fF + 1
                Loop While drEstadosCotiza.Read()

'Debug.Print("CHECH ANULADA--> " & Now.TimeOfDay.ToString)

                cmbCliente.Focus()
                mDocCargado = True

                'Modificado el 20150411. Se agrega el manejo de estados
                If drCabCotiza.Item("Estado").ToString = "I" Then
                    ChkAnulada.CheckState = CheckState.Checked
                    ChkAnulada.Enabled = False
                    'OLD_btnSigFase.Enabled = False
                    'cmdActualizar.Enabled = False
                Else
                    ChkAnulada.CheckState = CheckState.Unchecked
                    ChkAnulada.Enabled = True
                End If
'Debug.Print("ValidaProductosCreados--> " & Now.TimeOfDay.ToString)
                Call ValidaProductosCreados()
                Call CargarPresupuestoMateriales()
                btnGrabar.Text = "Actualizar"
'Debug.Print("FIN-->" & Now.TimeOfDay.ToString)

    Catch ex As System.InvalidCastException

        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

  End Sub



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
        'lvwAnexos.Items.Add(IO.Path.GetFileName(strArchivo))
        'lvwAnexos.Items(lvwAnexos.Items.Count - 1).Checked = True
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



  Private Sub lstAnexos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)

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

  Private Sub lstAnexos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    Dim mLista = CType(sender, CheckedListBox)
    'Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString)

    'Process.Start(mVctAnexos(mLista.SelectedIndex + 1).ToString)
  End Sub


  Private Sub lstAnexos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnexos.SelectedIndexChanged


    If mEstadoPantalla = EstadoPantalla.Editando Then
      Dim mLista = sender 'CType(sender, CheckedListBox)
      If sender.name = "lstAnexos" Then
        Call CargaImagen(mVctAnexos(sender.SelectedIndex + 1).ToString, True)
      Else
        Call CargaImagen(mVctAnexosE(sender.SelectedIndex + 1).ToString, True)
      End If

    End If
  End Sub

   Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
        Dim mImagen As Bitmap

        Try
          Dim obCntv As New clConectividad
          If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then

              If strImagen.Contains(".pdf") = True Then

                pdfVisor.src = strImagen
                pcbAnexos.Visible = False
                pdfVisor.Visible = True

              Else
                mImagen = New Bitmap(strImagen)
                pcbAnexos.Image = CType(mImagen, Image)
                pcbAnexos.Visible = True
                pdfVisor.Visible = False
              End If
            End If

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
    Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=5", strCadena)
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
    If lstAnexos.SelectedItems.Count > 0 Then
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
        strInsert = "insert AnexosCotizacion(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
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
      strUpdate = "UPDATE AnexosCotizacion SET RutaArchivo = REPLACE(rutaarchivo, '" _
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

    strSql = "update AnexosOrden set estado='I' where estado<>'E' and cab_Id=" & Cab_Id.ToString
    obCntv.EjecutaComando(strSql, strCadena, False)

    For Each mFila In mTablaAnexos.Rows
      If mFila("Estado") = "A" Then
        strSql = "update AnexosOrden set estado='A' where Id=" & mFila("Id")
        obCntv.EjecutaComando(strSql, strCadena, False)

      ElseIf mFila("Estado") = "N" Then
        Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=10", strCadena)
        Dim strFecha As Date = obCntv.LeerValorSencillo("fecharegistro", "CabOT", "id=" & Cab_Id.ToString, strCadena)
        Dim strMes As String = StrDup(2 - Len(strFecha.Month.ToString), "0") & strFecha.Month.ToString
        Dim strRutaCotiza As String = mNumCotiza.ToString

        Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
        strRuta = strRuta & strRutaB

        Dim strDestino As String = strRuta & "\" & IO.Path.GetFileName(mFila("NombreArchivo"))

        Try
          IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

          Dim strInsert As String = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumOrden.ToString & "','A')"
          obCntv.EjecutaComando(strInsert, strCadena, False)

        Catch ex As System.IO.DirectoryNotFoundException
          IO.Directory.CreateDirectory(strRuta)
          IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

          Dim strInsert As String = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumOrden.ToString & "','A')"
          obCntv.EjecutaComando(strInsert, strCadena, False)


        End Try

      End If
    Next


  End Sub

  Private Sub txtPrecioFinal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles txtPrecioFinal.LostFocus

    'sender.Text = FormatCurrency(sender.Text, 0)
    sender.Text = CDec(sender.Text).ToString(FCTOTOT)

  End Sub




  Private Sub grProductos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
      Handles grProductos.CellEndEdit, grEmpleados.CellEndEdit

    Dim mGr As DataGridView = CType(sender, DataGridView)

    Select Case e.ColumnIndex
      Case 3, 4
        Dim mCant As Decimal, mCosto As Decimal
        mCant = CDec(IIf(mGr.Rows(e.RowIndex).Cells(3).Value = "", 0, mGr.Rows(e.RowIndex).Cells(3).Value))
        mCosto = CDec(IIf(mGr.Rows(e.RowIndex).Cells(4).Value = "", 0, mGr.Rows(e.RowIndex).Cells(4).Value))
        mGr.Rows(e.RowIndex).Cells(5).Value = CDec(mCant * mCosto).ToString(FCTOTOT)


        mGr.Rows(e.RowIndex).Cells(3).Value = CDec(mCant).ToString(FCANT)
        mGr.Rows(e.RowIndex).Cells(4).Value = CDec(mCosto).ToString(FCTO_U)

        If ValidaExcesoPresupuesto(e.RowIndex) = False Then
          mGr.Rows(e.RowIndex).Cells(13).Value = False

          grProductos.CancelEdit()
        Else
          grProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If


        Call Calcular()
      Case 1
        Call ValidaMaterial(mGr.Rows(e.RowIndex).Cells("colCodigoInventario").Value, e.RowIndex)
      'Case 13
      '    If grProductos.Item("ColCantidad", e.RowIndex).Value <> "" Then
      '      'control del presupuesto
      '      '(CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))
      '      If mControlarMateriales = "SI" Then
      '        'Si el material adicionado, supera el presupuesto disponible
      '        If grProductos.Item("ColCostoTotal", e.RowIndex).Value > mOrdenDeTrabajo.Disponible Then  'mDisp Then
      '          MessageBox.Show("No se puede adicionar, el valor del material supera el presupuesto disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      '          grProductos.Item("ColRevisado", e.RowIndex).Value = False

      '          'Exit Sub

      '        End If
      '      End If
      '    End If


    End Select
  End Sub


  Private Function TxtADec(ByVal strTxt As String) As Decimal
    TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
  End Function

  Private Sub txtAIU_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAIU.LostFocus
    Call Calcular()
  End Sub

  Private Sub GrabarCheckList(ByVal mCab_Id As Integer)
    Dim obCalc As New clCalculadora, Ff As Integer

    For Ff = 0 To chkCheckListCotizacion.Items.Count - 1
      Dim Valor As Boolean = CBool(chkCheckListCotizacion.GetItemCheckState(Ff))
      obCalc.GrabarCheckListCotizacion(strCadena, mCab_Id, mTblCheckList.Rows(Ff).Item("Id").ToString, Valor, Now)
    Next


  End Sub

  Private Sub ActualizarCheckList(ByVal mCab_Id As Integer)
    Dim obCalc As New clCalculadora, Ff As Integer

    For Ff = 0 To chkCheckListCotizacion.Items.Count - 1
      Dim Valor As Integer = IIf(chkCheckListCotizacion.GetItemCheckState(Ff) = CheckState.Checked, 1, 0)
      'obCalc.GrabarCheckListCotizacion(strCadena, mCab_Id, mTblCheckList.Rows(Ff).Item("Id").ToString, Valor, Now)
      obCalc.ActualizarCheckListCotizacion(strCadena, mTblCheckList.Rows(Ff).Item("id").ToString, Valor, Now)
    Next
  End Sub


  Private Sub ValidaMaterial(ByVal strCodInventario As String, ByVal Ff As Integer)
    Dim obCntv As New clConectividad

    Dim mProducto As String = ""
    Dim strWhere As String = "codinventario ='" & strCodInventario & "'"

    mProducto = obCntv.LeerValorSencillo("NombreZiur", "vw_ProductosZiurMP", strWhere, strCadena)

    If mProducto <> "" Then
      grProductos.Rows(Ff).Cells("colCodigoInventario").Value = UCase(strCodInventario)
      grProductos.Rows(Ff).Cells("colDescripcion").Value = UCase(mProducto)

      'If OLD_btnSigFase.Enabled = True And cmdActualizar.Enabled = False Then
      '  btnGrabaMPNueva.Visible = True

      'End If
    Else
      MessageBox.Show("Código no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      grProductos.Rows(Ff).Cells("colCodigoInventario").Value = "0" ': grProductos.Rows(Ff).Cells("colDescripcion").Value = ""
    End If


  End Sub





  Private Sub btnGrabaMPNueva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabaMPNueva.Click
    If MessageBox.Show("Desea grabar los datos del detalle ahora?", "Actualizar Detalle", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

      Call ActualizarDetalle(mId)
    End If
  End Sub

    Private Sub EstableceModoColumnas(ByRef grGrilla As DataGridView)

        Dim ModoColumna As DataGridViewAutoSizeColumnsMode

        Select Case My.Settings.grProductosColumnsMode
            Case 0
                ModoColumna = DataGridViewAutoSizeColumnMode.NotSet

            Case 1
                ModoColumna = DataGridViewAutoSizeColumnMode.None
            Case 2
                ModoColumna = DataGridViewAutoSizeColumnMode.ColumnHeader
            Case 3
                ModoColumna = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader

            Case 4
                ModoColumna = DataGridViewAutoSizeColumnMode.AllCells

            Case 5
                ModoColumna = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader
            Case 6
                ModoColumna = DataGridViewAutoSizeColumnMode.DisplayedCells
            Case 7
                ModoColumna = DataGridViewAutoSizeColumnMode.Fill
        End Select

        Dim Cc As Integer
        For Cc = 0 To grGrilla.Columns.Count - 1
            grGrilla.Columns(Cc).AutoSizeMode = ModoColumna
        Next Cc
        Dim fl As Integer
        If grGrilla.Name = "grProductos" Then
            With grProductos
                For fl = 0 To grProductos.Rows.Count - 1
                    grProductos.Item("colCntComprar", fl).Style.BackColor = Color.Coral

                Next
            End With
        ElseIf grGrilla.Name = "grProductosRevisados" Then
            With grProductosRevisados
                For fl = 0 To grProductosRevisados.Rows.Count - 1
                    grProductosRevisados.Item("colCntComprar2", fl).Style.BackColor = Color.Coral
                Next
            End With
        End If

        ' MessageBox.Show(My.Settings.grProductosColumnsMode)

    End Sub





  Private Sub grProductos_SortCompare(ByVal sender As Object, _
                                      ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) _
                                      Handles grProductos.SortCompare, grEmpleados.SortCompare

    Dim mGr As DataGridView = CType(sender, DataGridView)

    Select Case e.Column.Index
      Case 0
        Dim a As Integer = Int32.Parse(e.CellValue1.ToString)
        Dim b As Integer = Int32.Parse(e.CellValue2.ToString)

        e.SortResult = a.CompareTo(b)
        e.Handled = True

      Case 3, 4, 5
        Dim a As Decimal = CDec(e.CellValue1.ToString).ToString(FCANT)
        Dim b As Decimal = CDec(e.CellValue2.ToString).ToString(FCTO_U)

        e.SortResult = a.CompareTo(b)
        e.Handled = True

    End Select

  End Sub



  Private Sub OrdenaParaGuardar(ByVal mGr As DataGridView)

    Dim newColumn As DataGridViewColumn = mGr.Columns(0)
    Dim direction As ListSortDirection
    direction = ListSortDirection.Ascending

    mGr.Sort(newColumn, direction)

  End Sub


  Private Sub FormatoProductosOT()
    TabPage1.Parent = Nothing
    TabPage3.Parent = Nothing
    'grpOtros.Visible = False
    chkCheckListCotizacion.Visible = False
    lblTotal.Visible = False
    txtPrecioFinal.Visible = False
    'btnCalcular.Visible = False
    Label9.Visible = False
    Label26.Visible = False
    cmdActualizarProdOT.Enabled = True
    lblTotalMateriales.Visible = False
    Label5.Visible = False
    txtCosto.Visible = False
    grProductos.Columns("ColCosto").Visible = False
    grProductos.Columns("ColCostoTotal").Visible = False

    grProductosRevisados.Columns("ColCosto2").Visible = False
    grProductosRevisados.Columns("ColCostoTotal2").Visible = False



    GroupBox2.Visible = False
  End Sub



  Private Sub txtCantidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCantidad.TextChanged
    Dim mDisp As Decimal, mCant As Decimal

    mDisp = CDec(IIf(txtDisponible.Text = "", 0, txtDisponible.Text)) : mCant = CDec(IIf(txtCantidad.Text = "", 0, txtCantidad.Text.ToString))

    If mDisp < mCant Then
        txtAComprar.Text = mCant - mDisp
      Else
        txtAComprar.Text = CDec("0").ToString(FCANT)
      End If

    End Sub



  Private Sub btnSiguienteFaseOT_Click(sender As System.Object, e As System.EventArgs) Handles OLD_btnSiguienteFaseOT.Click

    Dim strCantMPNoCreada As String, dr As MSSQL.SqlDataReader, obCntv As New clConectividad

    dr = obCntv.LeerValor("COUNT(1) [cant]", "VW_MaterialesNoCreados", "Cab_ID=" & mId.ToString, strCadena)
    strCantMPNoCreada = dr.Item("Cant").ToString


    If strCantMPNoCreada <> "0" Then

        MessageBox.Show("La OT contiene items de Materia Prima sin crear." & vbCrLf & "No se puede continuar!", "MP no creada", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'MUESTRO EN PANTALLA LOS ITEMS NO CREADOS DE MP
        'Dim frm As New frmRptMaterialesNoCreados
        'frm.strCotizacion = mNumCotiza
        'frm.Show()
        Exit Sub
        'End If

    Else
        'TODO EL PROCESO DE ESTADOS Y NOTIFICACIÓN
        'MARCO EL CAMPO ESTADO CON EL CUAL QUEDA LA OT EN ESTE MOMENTO
        'INSERTO EL REGISTRO EN ESTADOSOT PARA INIDICAR QUIEN Y CUANDO SE MODIFICO
        Dim mCabIdIT As Integer = obCntv.LeerValorSencillo("Id", "CabOT", "NumOrden=" & mNumOrden, My.Settings.cnnModProd)

        obCntv.ActualizaValor("Estado='P'", "CabOT", "id=" & mCabIdIT.ToString, My.Settings.cnnModProd)

        'GRABO LOS ESTADOS
        Dim strInsert As String
        strInsert = "exec pa_Insert_EstadosOT " & mCabIdIT.ToString & ",9," & mUsuarioId
        obCntv.EjecutaComando(strInsert, strCadena, False)

        'NOTIFICAR
        'PONER ACA LA CLASE DE NOTIFICACIONES
            Dim obNotifica As New clNotificaciones, mUsuarioEnvia As String, mUsuarioDestino As String 'mUsuarioId_AsignadoA As Integer
        mUsuarioEnvia = Environment.UserDomainName & "\" & Environment.UserName

        mUsuarioDestino = obCntv.LeerValorSencillo("Valor", "parametros", "id=19", strCadena)

        Dim mMensaje As String = "Materiales ajustados para la OT número " & mNumOrden.ToString & " con la cotización " & mNumCotiza.ToString _
          & " asignada a " & cmbAsignadaA.Tag.ToString

        obNotifica.GrabarNotificacion(strCadena, "frmOT", mUsuarioEnvia, mUsuarioDestino, String.Format("{0:G}", DateTime.Now), "A", "E", "OT Registrada", mMensaje)


        OLD_btnSiguienteFaseOT.Enabled = False

        MessageBox.Show("La OT se ha pasado a la siguiente fase.", "Cambio de fase", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End If

  End Sub

  Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
    Call Calcular()
  End Sub

  'Private Sub grProductos_CellMouseUp(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grProductos.CellMouseUp
  '  grProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
  'End Sub





  '****** PASO 1 ******'
  Private Sub grProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellContentClick
    If e.ColumnIndex = 13 Then
      If grProductos.Item(e.ColumnIndex, e.RowIndex).Value = False Then
        If ValidaExcesoPresupuesto(e.RowIndex) = False Then
          grProductos.CancelEdit()
        Else
          grProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
      End If
    Else
      grProductos.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End If


  End Sub

  Private Function ValidaExcesoPresupuesto(ByVal Ff) As Boolean
    Dim Salida As Boolean = True
    If grProductos.Item("ColCantidad", Ff).Value <> "" Then
      If mControlarMateriales = "SI" Then
        'Si el material adicionado, supera el presupuesto disponible
        'If grProductos.Item("ColRevisado", Ff).Value = True Then

          If grProductos.Item("ColCostoTotal", Ff).Value > mOrdenDeTrabajo.Disponible Then  'mDisp Then
              Dim _MsgPresu As String

              _MsgPresu = vbCrLf & "Disponible: " & mOrdenDeTrabajo.Disponible.ToString & vbCrLf _
                & "Costo material: " & grProductos.Item("ColCostoTotal", Ff).Value

              'grProductos.Item("ColRevisado", Ff).Value = False
              MessageBox.Show("No se puede adicionar, el valor del material supera el presupuesto disponible!" & _MsgPresu, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
              Salida = False
          End If
        'End If
      End If
    End If

    Return Salida

  End Function

  '****** PASO 2 *******'
  Private Sub grProductos_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellValueChanged

        If grProductos.Columns(e.ColumnIndex).Name = "colRevisado" Then
              grProductos.Item("colStRevisado", e.RowIndex).Value = CInt(Not CBool(grProductos.Item("colstRevisado", e.RowIndex).Value))

              'If grProductos.Item("ColCantidad", e.RowIndex).Value <> "" Then

              ''control del presupuesto
              ''(CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString))
              '  If mControlarMateriales = "SI" Then
              '    'Si el material adicionado, supera el presupuesto disponible
              '    If grProductos.Item("ColRevisado", e.RowIndex).Value = True Then

              '      If grProductos.Item("ColCostoTotal", e.RowIndex).Value > mOrdenDeTrabajo.Disponible Then  'mDisp Then
              '          grProductos.Item("ColRevisado", e.RowIndex).Value = False
              '          MessageBox.Show("No se puede adicionar, el valor del material supera el presupuesto disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
              '         Exit Sub
              '      End If
              '    End If
              '  End If
              'End If


            If CBool(grProductos.Item("colstRevisado", e.RowIndex).Value) = True Then
                grProductos.Item("colCodigoInventario", e.RowIndex).Style.BackColor = Color.FromArgb(103, 177, 49) '(0, 255, 0)
                grProductos.Item("colDescripcion", e.RowIndex).Style.BackColor = Color.FromArgb(103, 177, 49)
            Else
                grProductos.Item("colCodigoInventario", e.RowIndex).Style.BackColor = Color.White
                grProductos.Item("colDescripcion", e.RowIndex).Style.BackColor = Color.White
            End If

        ElseIf grProductos.Columns(e.ColumnIndex).Name = "colComprar" Then
            Dim obcntv As New clConectividad
            If obcntv.LeerValorSencillo("Valor", "Parametros", "Id = 37", My.Settings.cnnModProd) = "SI" Then
                If CDec(grProductos.Item("colStock", e.RowIndex).Value) > 0 And grProductos.Item("colComprar", e.RowIndex).Value = True Then
                    If MessageBox.Show("Realmente desea comprar este item?", "Comprar Item", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = vbNo Then
                        grProductos.Item("colComprar", e.RowIndex).Value = False
                        grProductos.CancelEdit()
                    End If
                End If
            End If
        End If
    End Sub
  

  Private Sub ActualizarDetalleOT()
    Dim Ff As Integer, obCntv As New clConectividad, xCnt As Decimal, xCosto As Decimal, xCampos As String, xValores As String
    Dim xNuevoDetalleId As String

        ''REVISO QUE LO MARCADO PARA COMPRAR TENGA CANTIDADES
        'For Ff = 0 To grProductos.Rows.Count - 1
        '    If grProductos.Item("ColComprar", Ff).Value = True And CDec(grProductos.Item("colCntComprar", Ff).Value) = 0 Then
        '        MessageBox.Show("Se marcaron items para comprar, pero no se especificó cantidad." & vbCrLf & vbCrLf & "No se puede continuar!", "Compras sin unidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '        Exit Sub
        '    End If
        'Next

        '0. SE ESTABLECEN TODOS LOS ITEMS NO ENTREGADOS EN I PARA DEJAR POR FUERA LOS ELIMINADOS
        obCntv.ActualizaValor("Estado='I'", "DetCotizacion", "Tipo=1 AND ESTADO <>'E' and Cab_Id=" & mId.ToString, My.Settings.cnnModProd)


        '1. RECORRO LA GRILLA DE PRODUCTOS SUPERIOR, Y SI ES NUEVO LO INSERTO (TRAIGO EL NUEVO ID) Y SI ES ANTIGUO LO ACTUALIZO
        For Ff = 0 To grProductos.Rows.Count - 1
            'SI EL REGISTRO ES ANTIGUO:
            If grProductos.Item("colRevisado", Ff).Value = True And grProductos.Item("colDet_ID", Ff).Value <> "" Then
                xCnt = CDec(IIf(grProductos.Item("colCantidad", Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
                xCosto = CDec(IIf(grProductos.Item("colCosto", Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
                Dim strUpdate As String

                strUpdate = "Cant=" & xCnt.ToString & ",Costo=" & xCosto.ToString & ", CostoTotal=" & (xCnt * xCosto).ToString
                If grProductos.Item("colCosto", Ff).Value <> "" Then
                  strUpdate = strUpdate & ", DescItem='" & grProductos.Item("colDescItem", Ff).Value & "'"
                End If

                obCntv.ActualizaValor(strUpdate, _
                "DetCotizacion", "Cab_Id=" & mId.ToString & " and id=" & grProductos.Item("colDet_ID", Ff).Value, My.Settings.cnnModProd)

            'SI EL REGISTRO ES NUEVO:
            ElseIf grProductos.Item("colRevisado", Ff).Value = True And IIf(grProductos.Item("colDet_ID", Ff).Value = Nothing, "", grProductos.Item("colDet_ID", Ff).Value) = "" Then
                xCampos = "Cab_id, Tipo, CodInventario, Inventario_ID, Cant,Costo,Estado,CostoTotal,DescItem" '"Cab_id, Tipo, CodInventario, Cant, Costo, Estado, CostoTotal,Inventario_Id, DescItem"
                 '"Cab_id, Tipo, CodInventario, Inventario_ID, Unidad_Id, Cant,Costo,Estado,CostoTotal,DescItem"


                xValores = mId.ToString & _
                    ",1," & _
                    "'" & grProductos.Item("colDescripcion", Ff).Value & "', " & _
                    "'" & grProductos.Item("colCodigoInventario", Ff).Value & "', " & _
                    "" & CDec(IIf(grProductos.Item("colCantidad", Ff).Value = 0, 0, grProductos.Item("colCantidad", Ff).Value)) & ", " & _
                    "" & CDec(IIf(grProductos.Item("colCosto", Ff).Value = 0, 0, grProductos.Item("colCosto", Ff).Value)) & ", " & _
                    "'" & "A" & "', " & _
                    "" & CDec(IIf(grProductos.Item("ColCostoTotal", Ff).Value = 0, 0, grProductos.Item("ColCostoTotal", Ff).Value)) & ", " & _
                    "'" & grProductos.Item("colDescItem", Ff).Value & "'"


                obCntv.InsertarValor(xCampos, xValores, "DetCotizacion", My.Settings.cnnModProd)

                xNuevoDetalleId = obCntv.LeerValorSencillo("max(id) ID", "ID", "DetCotizacion", "Cab_Id=" & mId.ToString, My.Settings.cnnModProd)
                grProductos.Item("colDet_Id", Ff).Value = xNuevoDetalleId

            End If
        Next

        '20020906 Se involucra en el proceso a almacen para que valide todo contra stock
        Dim strRevisaStockAlmacen As String
        strRevisaStockAlmacen = UCase(obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion='RevisaStockAlmacen'", My.Settings.cnnModProd))



        '2. PASO A GRILLA DE REVISADOS LOS MARCADOS COMO REVISADO, LOS QUE NO SE REVISARON LOS MARCO COMO ACTIVOS
        Dim Ff2 As Integer
        For Ff = 0 To grProductos.Rows.Count - 1
          If grProductos.Item("colRevisado", Ff).Value = True And grProductos.Item("colDet_ID", Ff).Value <> "" Then
            Dim mChkCompra As Boolean, mCntComprar As Decimal

            If strRevisaStockAlmacen = "NO" Then
              mChkCompra = grProductos.Item(11, Ff).Value
              mCntComprar = grProductos.Item("colCntComprar", Ff).Value
            Else
              mChkCompra = True
              mCntComprar = grProductos.Item("colCantidad", Ff).Value
            End If

             Dim strFilaNueva() As String = {Ff2,
                  grProductos.Item(1, Ff).Value, grProductos.Item(2, Ff).Value, grProductos.Item(3, Ff).Value,
                  grProductos.Item(4, Ff).Value, grProductos.Item(5, Ff).Value, grProductos.Item(6, Ff).Value,
                  grProductos.Item(7, Ff).Value,
                  mCntComprar,
                  grProductos.Item(9, Ff).Value,
                  grProductos.Item(10, Ff).Value,
                  mChkCompra,
                  grProductos.Item(12, Ff).Value,
                  grProductos.Item(13, Ff).Value, grProductos.Item(14, Ff).Value, grProductos.Item(15, Ff).Value}

              grProductosRevisados.Rows.Add(strFilaNueva)
              'grProductosRevisados.Refresh()
              Ff2 = Ff2 + 1
          ElseIf grProductos.Item("colRevisado", Ff).Value = False And grProductos.Item("colDet_ID", Ff).Value <> "" Then
              obCntv.ActualizaValor("estado='A'", "DetCotizacion", "Tipo =1 and cab_Id=" & mId.ToString & " and Id=" & grProductos.Item("colDet_ID", Ff).Value, My.Settings.cnnModProd)


          End If
        Next


        '3. ACTUALIZO DETALLE DE COTIZACION LOS ITEMS QUE SE NOTIFICARON COMO ENTREGADOS A COMPRAS
        For Ff = 0 To grProductosRevisados.Rows.Count - 1
            obCntv.ActualizaValor("estado='E'", "DetCotizacion", "Tipo =1 and cab_Id=" & mId.ToString & " and Id=" & grProductosRevisados.Item("colDet_ID2", Ff).Value, My.Settings.cnnModProd)
        Next

        '20200906 Todo genera una solicitud, y almacen decide que se compra
        '4. HAGO LOS PEDIDOS DE MATERIALES A COMPRAR
        Dim SolAnt As Integer
        SolAnt = obCntv.LeerValorSencillo("count(1) [Cant]", "Cant", "CabSolicitud", "estado='R' and cab_id=" & mCabOrden_Id.ToString, strCadena)

        If SolAnt = 1 Then
          If MessageBox.Show("Ya existe una solicitud de compra para esta OT!" & vbCrLf & "Desea sobrescribirla?", "Existe solicitud previa", _
                              MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call GrabarSolicitudCompra(mId)
          End If
        Else
          Call GrabarSolicitudCompra(mId)
        End If

        'MessageBox.Show("Actualización realizada con éxito!", "OT actualizada", MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub




Private Sub btnCompraParcial_Click(sender As System.Object, e As System.EventArgs) Handles btnCompraParcial.Click, btnGrabar.Click
  Dim Ff As Integer

  '0. REVISO QUE LO MARCADO PARA COMPRAR TENGA CANTIDADES
    For Ff = 0 To grProductos.Rows.Count - 1
      If grProductos.Item("ColComprar", Ff).Value = True And CDec(grProductos.Item("colCntComprar", Ff).Value) = 0 Then
          MessageBox.Show("Se seleccionaron items para comprar, pero no se especificó cantidad." & vbCrLf & vbCrLf & "No se puede continuar!", "Compras sin unidades", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Exit Sub
      End If

    Next

    '0.1. REVISO LOS PRODUCTOS NUEVOS Y NO MARCADOS COMO REVISADOS
    Dim xMensaje As String = "Existen items nuevos en la OT que no se han marcado como revisados." & vbCrLf & _
        "Si continua grabando, no se tendrán en cuenta estos items!" & vbCrLf & vbCrLf & "Desea continuar?"
    Dim xNuevosSinRevisar As Integer = 0

    For Ff = 0 To grProductos.Rows.Count - 1
      If IIf(grProductos.Item("colDet_ID", Ff).Value = Nothing, "", grProductos.Item("colDet_ID", Ff).Value) = "" And grProductos.Item("colRevisado", Ff).Value = False Then
          xNuevosSinRevisar = xNuevosSinRevisar + 1
      End If
    Next

    If xNuevosSinRevisar > 0 Then
        If MessageBox.Show(xMensaje, "Items nuevos", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If
    End If

  
    Call Calcular()

  '2. GRABO LOS DATOS
    Call Actualizar()
    Dim obCntv As New clConectividad

    'TODOS LOS ANEXOS DE LA ORDEN LOS ACTUALIZO A ENTREGADOS
    obCntv.ActualizaValor("estado='E'", "AnexosOrden", "cab_Id=" & mCabOrden_Id.ToString, My.Settings.cnnModProd)

    'CAMBIO EL ESTADO DE LA SOLICITUD DE PEDIDO PARA BLOQUEARLA EN SU MODIFICACIÓN POR PARTE DE LOS INGENIEROS
    obCntv.ActualizaValor("estado='E'", "CabSolicitud", "TipoDoc='OT' and cab_Id=" & mCabOrden_Id.ToString, My.Settings.cnnModProd)


    'GRABO LOS ESTADOS DE LA OT
    Dim drOt As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabOT", "NumOrden ='" & mNumOrden & "'", My.Settings.cnnModProd)
    Dim mIdEstado As String = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & drOt.Item("Estado").ToString & "'", My.Settings.cnnModProd)
    Dim strInsert As String = "exec pa_Insert_EstadosOT " & drOt.Item("id").ToString & "," & mIdEstado & "," & mUsuarioId & ",'P'"
    obCntv.EjecutaComando(strInsert, strCadena, False)

    btnGrabar.Text = "Grabar"
    If mTipoEntrada = "" Then
      MessageBox.Show("Planos y Materiales reportados con éxito!", "Planos y Materiales", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Call CargarCotizacion(mNumCotiza, "OT")

    ElseIf mTipoEntrada = "ModalMasMaterial" Then
      Me.DialogResult = Windows.Forms.DialogResult.OK
    End If

End Sub


  Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
    If flyPanelBotones.Width = 190 Then
          flyPanelBotones.Width = 45
          tbcContenido.Width = tbcContenido.Width + (190 - 45)
          'tbcContenido.Left = tbcContenido.Left - (255 - 70)
        Else
          flyPanelBotones.Width = 190
          tbcContenido.Width = Me.Width - 190 - 21 'tbcContenido.Width - 190 '- 45)
          'panelContenedor.Left = panelContenedor.Left + (255 - 70)
        End If

  End Sub

   Private Sub frmProductosOT_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException

      End Try


  End Sub



  Private Sub NombrarBotones()
      Dim mColores = Split(obXml.LeerValor("ColorFondoFrm"), ",")
      Me.Text = obXml.LeerValor("frmTitulo")

      btnCompraParcial.Text = obXml.LeerValor("btnCompraParcial")
      lblMsgInformativo.Text = obXml.LeerValor("lblMsgInformativo")


      'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
      If Me.Tag IsNot Nothing Then
        Me.Tag.TEXT = Me.Text
      End If

  End Sub


  Private Sub IgualaFormatosGrilla()
    Dim Cc As Integer

    For Cc = 0 To grProductos.Columns.Count - 1
            grProductosRevisados.Columns(Cc).Width = grProductos.Columns(Cc).Width

    Next


  End Sub

  Private Sub ValidaProductosCreados()
    Dim Ff As Integer, MPsNoCredos As Integer = 0

    For Ff = 0 To grProductos.Rows.Count - 1
      If grProductos.Item("colCodigoInventario", Ff).Value = "0" Then
         MPsNoCredos = MPsNoCredos + 1
         grProductos.Rows(Ff).ReadOnly = True

        Dim Cc As Integer
        For Cc = 0 To grProductos.Columns.Count - 1
          grProductos.Item(Cc, Ff).Style.BackColor = Color.Red
        Next
      End If

      'valido la parte del multiplicador de la OT
      If sslCntAFabricar.Text <> "1" Then
        grProductos.Item("colCantidad", Ff).Style.BackColor = Color.Yellow

      End If


    Next

  End Sub


  Private Sub grProductos_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles grProductos.UserDeletingRow
    'ACUMULO LOS ID PARA ACTUALIZAR AL FINAL
      If grProductos.Item("colDet_ID", e.Row.Index).Value <> Nothing Then
          mDet_Id = mDet_Id & grProductos.Item("colDet_ID", e.Row.Index).Value.ToString & ","
      Else
          grProductos.Item("colAgregar", e.Row.Index).Value = False

      End If
  End Sub

  Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      MessageBox.Show(grProductos.Item("colDet_ID", 0).Value)

      'Dim Ff As Integer, Ff2 As Integer

      'Ff2 = grProductosRevisados.Rows.Count + 1

      ''1. PASO LOS DATOS QUE ESTAN MARCADOS COMO REVISADOS Y QUE SON ANTIGUOS
      'For Ff = 0 To grProductos.Rows.Count - 1
      '  If grProductos.Item("colRevisado", Ff).Value = True And grProductos.Item("colDet_ID", Ff).Value <> "" Then
      '     Dim strFilaNueva() As String = {Ff2,
      '                                      grProductos.Item(1, Ff).Value,
      '                                      grProductos.Item(2, Ff).Value,
      '                                      grProductos.Item(3, Ff).Value,
      '                                      grProductos.Item(4, Ff).Value,
      '                                      grProductos.Item(5, Ff).Value,
      '                                      grProductos.Item(6, Ff).Value,
      '                                      grProductos.Item(7, Ff).Value,
      '                                      grProductos.Item(8, Ff).Value,
      '                                      grProductos.Item(9, Ff).Value,
      '                                      grProductos.Item(10, Ff).Value,
      '                                      grProductos.Item(11, Ff).Value,
      '                                      grProductos.Item(12, Ff).Value,
      '                                      grProductos.Item(13, Ff).Value,
      '                                      grProductos.Item(14, Ff).Value}
      '     grProductosRevisados.Rows.Add(strFilaNueva)

      '     Ff2 = Ff2 + 1
      '  End If
      'Next

      'For Ff = grProductos.Rows.Count - 1 To 0 Step -1
      '  If grProductos.Item("colRevisado", Ff).Value = True And grProductos.Item("colDet_ID", Ff).Value <> "" Then
      '    grProductos.Rows.Remove(grProductos.Rows(Ff))
      '  End If
      'Next

  End Sub


  Private Sub btnSigFase_Click(sender As System.Object, e As System.EventArgs) Handles btnSigFase.Click
      Dim obCntv As New clConectividad, mEstadoXDefecto As String
      Dim strSql As String

      '** El estado por defecto de la etapa de materiales es PM segun la BD
      mEstadoXDefecto = "PM"

      If grProductos.Rows.Count > 0 Then
        MessageBox.Show("Aún quedan materiales sin revisar!" & vbCrLf & "No se puede continuar", "Revisar materiales", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Exit Sub
      End If

      Try
          If MessageBox.Show("Desea dar por terminada la etapa de PLANOS Y MATERIALES?", "Terminar etapa", MessageBoxButtons.YesNo, _
          MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

              Dim drDatosEstado As MSSQL.SqlDataReader = obCntv.LeerValor("*", "Estados", "TipoDoc ='OT' and Estado ='" & mEstadoXDefecto & "'", My.Settings.cnnModProd)
              strSql = "exec PA_TerminaEtapaOT " & mNumOrden.ToString & "," & drDatosEstado.Item("id").ToString

              obCntv.EjecutaComando(strSql, My.Settings.cnnModProd, False)
              MessageBox.Show("Etapa de " & UCase(drDatosEstado.Item("Titulo").ToString) _
              & " terminada para la Orden de Trabajo " & mNumOrden.ToString, "Etapa terminada", MessageBoxButtons.OK, MessageBoxIcon.Information)

              drDatosEstado = Nothing

              'hacer bloque de borrar
              'hacer bloque de cargar de nuevo

          End If

        
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Error ModProd", MessageBoxButtons.OK, MessageBoxIcon.Error)

      End Try
  End Sub


   Private Sub CargarOTConBuscar()
      Dim FrmB As New frmBuscar

      FrmB.Text = "Buscar OT"
      FrmB.lblDoc.Text = "Numero OT" : FrmB.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
      FrmB.txtDocumento.MaxLength = 10

      FrmB.chkTexto.Text = "Alcance"
      FrmB.chkFechas.Text = "Fecha   "
      FrmB.chkTercero.Text = "Cliente  "

      FrmB.txtTexto.Tag = "Alcance"
      FrmB.dtpFechaIni.Tag = "FechaRegistro" : FrmB.dtpFechaFin.Tag = "FechaRegistro"
      FrmB.cmbTercero.Tag = "NombreCliente"

      FrmB.strConsultaSQL = "vw_buscarOT"
      'FrmB.strCamposSQL = "id, NumOrden, Estado, NumCotizacion, NombreCliente, NombreProyecto, FechaRegistro,  FechaInicio, FechaRegistro ,OTCabCotizacion_Id"
      FrmB.strCamposSQL = "id, NumOrden, NumCotizacion, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,  FechaInicio, FechaRegistro ,	Estado, [OC Cliente], CntAFabricar, OTCabCotizacion_Id"
      FrmB.mWhereExterno = " AND Estado in ('PM','C', 'DT', 'PP', 'FB', 'MJ', 'LQ')" '('PM','C')"
      FrmB.StartPosition = FormStartPosition.CenterScreen
      FrmB.ShowDialog()


      Dim dtConsulta As DataTable

      If FrmB.DialogResult = Windows.Forms.DialogResult.OK Then
            dtConsulta = FrmB.dtSeleccionado.Copy

            Dim Cotiza As Integer
            Dim mNumOT = dtConsulta.Rows(0).Item("NumOrden").ToString

            'Dim Frm As New frmProductosOT
            Cotiza = dtConsulta.Rows(0).Item("NumCotizacion").ToString
            Me.NumCotizacionOriginal = Cotiza
            Me.NumeroOT = mNumOT
            Me.CabOrden_Id = dtConsulta.Rows(0).Item("id").ToString
            Me.OTCabCotizacion_Id = IIf(dtConsulta.Rows(0).Item("OTCabCotizacion_Id").ToString = "", 0, dtConsulta.Rows(0).Item("OTCabCotizacion_Id").ToString)

            Call CargarCotizacion()
            Call cargarDetCotizacionOriginal()
            'Call CargarPresupuetoMateriales()

            'AbrirFormInPanel(Frm)

      End If

      FrmB.Dispose()


    End Sub



  'Private Sub NombrarBotones()
  '    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
  '    Dim obXml As New clManejoXML

  '    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUIMateriales.xml.xml")
  '    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"


  '    lblMsgInformativo.Text = obXml.LeerValor("lblMsgInformativo")


  '    obXml = Nothing


  'End Sub



  Private Sub btnActualizaOTDirecta_Click(sender As System.Object, e As System.EventArgs) Handles btnActualizaOTDirecta.Click
        Dim Frm As New frmOrdenDeTrabajo

        Frm.ModoOTDirecta = True
        Frm.Usuario_Id = mUsuarioId
        Call Frm.CargarOT(mNumOrden)
        Frm.ShowDialog()

        Dim strSQL As String = "exec PA_SincronizarOTVentaDirecta " & mNumOrden
        Dim obCntv As New clConectividad
        obCntv.EjecutaComando(strSQL, My.Settings.cnnModProd, False)
        obCntv = Nothing

  End Sub

  Private Sub cargarDetCotizacionOriginal()
        'CARGA EL DETALLE
        grProductosDC.Rows.Clear()
        grEmpleadosDC.Rows.Clear()
        'grProductosDiv.Rows.Clear()
        Dim drDetCotiza As MSSQL.SqlDataReader
        Dim objCntv As New clConectividad

        Dim drCabCotiza As MSSQL.SqlDataReader
        'drCabCotiza = objCntv.LeerValor("*", "VW_CabOT", "NumCotizacion ='" & mNumCotizacion & "' AND NumOrden LIKE '" & mNumOrden.ToString & "'", My.Settings.cnnModProd)
        drCabCotiza = objCntv.LeerValor("*", "DBO.fn_CabOT('%','" & mNumOrden.ToString & "')", "1=1", My.Settings.cnnModProd)


        If mNumOrden = 0 Then
            drDetCotiza = objCntv.LeerValor("*,cant [Faltante] ", "DetCotizacion", "Cab_ID =" & drCabCotiza.Item("id").ToString & " and tipo in (1,2) and estado<>'I' order by id", strCadena)
        Else
            'drDetCotiza = objCntv.LeerValor("*", "VW_DetOTConResumen", "Cab_ID =" & drCabCotiza.Item("OTCabCotizacion_Id").ToString & " and tipo in (1,2) and estado<>'I' order by id", strCadena)
            drDetCotiza = objCntv.LeerValor("*", "VW_DetOTConResumen", "Cab_ID =" & drCabCotiza.Item("CabCotizacion_Id").ToString & " and tipo in (1,2) and estado<>'I' order by id", strCadena)

            'Dim drDetCotizacion As MSSQL.SqlDataReader = objCntv.LeerValor("*", "VW_DetOTConResumen", "cab_id=" & mOTCabCotizacion_Id.ToString & " and tipo=1 and estado='E'", My.Settings.cnnModProd)

        End If

        Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
            If drDetCotiza.HasRows = True Then
                Dim strFilaNueva() As String

                If drDetCotiza.Item("Tipo").ToString = "1" Then
                    strFilaNueva = {grProductosDC.Rows.Count + 1,
                                    drDetCotiza.Item("Inventario_ID").ToString,
                                    drDetCotiza.Item("CodInventario").ToString,
                                    CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                    CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                    CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                    drDetCotiza.Item("DescItem").ToString,
                                    True,
                                    IIf(drDetCotiza.Item("Estado").ToString = "E", True, False),
                                    CDec(drDetCotiza.Item("Faltante").ToString).ToString(FCANT)
                                    }
                    grProductosDC.Rows.Add(strFilaNueva)

                    'With grProductosDC
                    '    .Columns("Adicionar").Visible = False
                    'End With


                    'ACA HAGO EL CARGUE DE MATERIALES AJUSTADOS PARA SUB-TAREAS
                    'strFilaNueva = {grProductosDiv.Rows.Count + 1,
                    '                drDetCotiza.Item("Inventario_ID").ToString,
                    '                drDetCotiza.Item("CodInventario").ToString,
                    '                CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                    '                0,
                    '                False
                    '                }
                    'grProductosDiv.Rows.Add(strFilaNueva)



                ElseIf drDetCotiza.Item("Tipo").ToString = "5" Then
                    strFilaNueva = {grTipoGastosDC.Rows.Count + 1,
                                    drDetCotiza.Item("CodInventario").ToString,
                                    CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                    True}
                Else
                    strFilaNueva = {grEmpleadosDC.Rows.Count + 1,
                                    drDetCotiza.Item("Inventario_ID").ToString,
                                    drDetCotiza.Item("CodInventario").ToString,
                                    CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                    CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                    CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                    True}

                    grEmpleadosDC.Rows.Add(strFilaNueva)
                End If
            End If

            txtImprevistosDC.Text = CDec(IIf(drCabCotiza.Item("Imprevistos").ToString <> "", drCabCotiza.Item("Imprevistos").ToString, 0)).ToString(FCTOTOT)
            txtAIUdc.Text = CInt(drCabCotiza.Item("AIU").ToString)
            txtAIU_MaO.Text = CInt(drCabCotiza.Item("AIU_MO").ToString)
            txtPrecioFinalDC.Text = CDec(drCabCotiza.Item("PrecioFinal").ToString).ToString(FCTOTOT)

        Loop While drDetCotiza.Read()

        Call Calcular()

    End Sub


    Private Sub CargarPresupuestoMateriales()
      Dim obCntv As New clConectividad

      Dim strConsulta As String, RsSalida As MSSQL.SqlDataReader

      strConsulta = "exec PA_RevisaSobreCostoMP " & mNumOrden

      RsSalida = obCntv.EjecutaComando(strConsulta, My.Settings.cnnModProd, True)
      RsSalida.Read()

      lblPresupuesto.Text = CDec(RsSalida.Item("ppto").ToString).ToString(FCTOTOT)
      lblReal.Text = CDec(RsSalida.Item("Real").ToString).ToString(FCTOTOT)
      tslMensajePresupuesto.Text = RsSalida.Item("TextoSemaforo").ToString


      mBolsa = CDec(RsSalida.Item("Bolsa").ToString)
      mGastoReal = CDec(RsSalida.Item("Real").ToString)
      mControlarMateriales = RsSalida.Item("ControlarMateriales").ToString
      mPorc_Consumido = CDec(RsSalida.Item("PORC_CONSUMIDO").ToString)
      mOrdenDeTrabajo.Disponible = CDec(RsSalida.Item("Disp").ToString)
      mBolsa = CDec(RsSalida.Item("Bolsa").ToString)

      'LAS VARIABLES PARA CALCULAR LOS PORCENTAJES
      With mOrdenDeTrabajo
        .Presupuesto = CDec(RsSalida.Item("Ppto").ToString).ToString(FCTOTOT)
        .ValMPCotizados = CDec(RsSalida.Item("MPCotizados").ToString).ToString(FCTOTOT)
        .ValAIU = CDec(RsSalida.Item("ValorAIU").ToString).ToString(FCTOTOT)
        .ValAdicional = CDec(RsSalida.Item("ValAdicional").ToString).ToString(FCTOTOT)
        .ValEjecutado = CDec(RsSalida.Item("Real").ToString).ToString(FCTOTOT)
      End With


      Dim mDiff As Decimal = CDec(RsSalida.Item("bolsa")) - CDec(RsSalida.Item("Real"))
      lblDifDinero.Text = CDec(mDiff).ToString(FCTOTOT)

      Dim mDiffPorc As Decimal '= CDec(RsSalida.Item("Real")) / CDec(RsSalida.Item("Bolsa").ToString)

      If CDec(RsSalida.Item("Bolsa").ToString) = 0 Then
        mDiffPorc = 0
      Else
          mDiffPorc = CDec(RsSalida.Item("Real")) / CDec(RsSalida.Item("Bolsa").ToString)
      End If

      lblDifPorc.Text = mDiffPorc.ToString("P")

      Select Case RsSalida.Item("TipoSemaforo").ToString
        Case "VERDE"
          tslMensajePresupuesto.BackColor = Color.Green
          lblDifDinero.BackColor = Color.Green
          lblDifPorc.BackColor = Color.Green
        Case "AMARILLO"
          tslMensajePresupuesto.BackColor = Color.Yellow
          lblDifDinero.BackColor = Color.Yellow
          lblDifPorc.BackColor = Color.Yellow
        Case "ROJO"
          tslMensajePresupuesto.BackColor = Color.Red
          lblDifDinero.BackColor = Color.Red
          lblDifPorc.BackColor = Color.Red
      End Select



  End Sub
  
  
End Class