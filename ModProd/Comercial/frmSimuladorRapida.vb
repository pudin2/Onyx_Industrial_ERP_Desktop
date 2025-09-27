Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
'Imports System.Drawing.Printing.PageSettings
'Imports System.Drawing.Printing.PaperSize

Public Class frmSimuladorRapida
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mIdNumeroCotizacionRapida As String

  'Dim CW As Integer = Me.Width ' Current Width
  'Dim CH As Integer = Me.Height ' Current Height
  'Dim IW As Integer = Me.Width ' Initial Width
  'Dim IH As Integer = Me.Height ' Initial Height


  'Private WithEvents dataGridView1 As New DataGridView()
  Dim Sep As Char
  Private strCadena As String
  Private mCabMov_Id As String, strNombreProducto As String, strCodInventario As String
  Private strNombreEmpleado As String, strIdentificacion As String
  Private mTotal As Decimal, strIdCliente As String, strNombreCliente As String
  Private mEsNuevo As Boolean, mId As Integer
  Private dtProducto As Data.DataTable, mUsuarioId As Integer
  Private mGuid As String = ""
  Private mVctAnexos As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private mTblCheckList As DataTable
  Public mNumCotiza As Integer = 0, mCabCotiza As Integer


  Private Sub frmSimulador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    'IW = Me.Width
    'IH = Me.Height

    Me.Text = My.Settings.TituloSimulador & " Rápida"
    mIdNumeroCotizacionRapida = My.Settings.IDNumeroCotizacionRapida
    mEsNuevo = True

    'Detectar el separador decimal de la aplicación.
    Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
    Dim obCntv As New clConectividad

    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    obCntv.CadenaDeConeccion = strCadena

    dtProducto = obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DataSource = dtProducto  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbProducto.DisplayMember = "Descripcion"


    cmbEmpleados.DataSource = obCntv.LlenarDataTable(strCadena, "*", "areasplanta", "estado in ('A','O')", "order by id")
    cmbEmpleados.DisplayMember = "Nombre"

    cmbCliente.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_Clientes", "esactivo=1", "Order by Nombre1")
    cmbCliente.DisplayMember = "NombreCompleto"


    'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
    grTipoGastos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_TipoGastos", "Estado=0")
    Dim miCol As DataGridViewColumn
    miCol = grTipoGastos.Columns(0) : miCol.Width = 20
    miCol = grTipoGastos.Columns(1) : miCol.Width = 80
    miCol = grTipoGastos.Columns(2) : miCol.Width = 80
    miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    miCol = grTipoGastos.Columns(3) : miCol.Width = 20 : miCol.ReadOnly = False


    'LA PARTE DEL CHECKLIST DE AMTERIALES
    mTblCheckList = obCntv.LlenarDataTable(strCadena, "*", "CheckList", "estado='A'")
    chkCheckListCotizacion.Items.Clear()
    For Each Fila As DataRow In mTblCheckList.Rows
      chkCheckListCotizacion.Items.Add(Fila.Item("Nombre").ToString, False)
    Next


    'PARTE DE LA CARGA DE LOS REPONSABLES

    Dim strWhereCotRapida As String = obCntv.LeerValorSencillo("Valor", "Parametros", "id=9", strCadena)
    cmbAsignadaA.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Responsables", "Estado='A' " & strWhereCotRapida)
    cmbAsignadaA.DisplayMember = "Nombre"

    'EL MANEJO DE LOS ESTADOS
    chkListEstados.ClearSelected()

    Dim mUsuario As String, mDominio As String, obInicio As New clSetUpInicio
    mUsuario = obInicio.Usuario ' Environment.UserName '& Environment.UserName.GetHashCode
    mDominio = obInicio.Dominio ' Environment.UserDomainName
    obInicio = Nothing


    Dim strWhere As String = "dominio='" & mDominio & "' and usuario='" & mUsuario & "'"
    mUsuarioId = obCntv.LeerValorSencillo("id", "Usuarios", strWhere, strCadena)

    obCntv = Nothing

    txtCosto.Text = CDec("0").ToString(FCTO_U)
    txtCantidad.Text = CDec("0").ToString(FCANT)
    txtCantMO.Text = CDec("0").ToString(FCANT)
    txtValorHora.Text = CDec("0").ToString(FCTO_U)
    stNumCotizacion.Text = ""
    stFecha.Text = ""

    sender.windowstate = FormWindowState.Maximized
    Me.Cursor = System.Windows.Forms.Cursors.Default
    TabPage2.Parent = Nothing


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

    Dim drValor As MSSQL.SqlDataReader = objCntv.EjecutaComando("exec CalcularCostoPromedioModProd " & selectedItem("id").ToString, strCadena, True)
    drValor.Read()
    txtCosto.Text = CDec(drValor.Item("CostoProm").ToString).ToString(FCTO_U)
    strNombreProducto = selectedItem("Descripcion2").ToString
    strCodInventario = selectedItem("CodInventario").ToString
    lblTipoUnidad.Text = selectedItem("NomUnidad").ToString

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


    If txtCantidad.Text <> "" Then

      Dim strFilaNueva() As String = {grProductos.Rows.Count + 1,
                                      strCodInventario.ToString,
                                      strNombreProducto.ToString,
                                      CDec(txtCantidad.Text.ToString).ToString(FCANT),
                                      CDec(txtCosto.Text.ToString).ToString(FCTO_U),
                                      (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString)).ToString(FCTOTOT),
                                      True}

      grProductos.Rows.Add(strFilaNueva)
      txtCantidad.Text = ""
      txtCosto.Text = ""

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
      If grProductos.Rows(Ff).Cells(5).Value = True Then
        Dim mCantidad As Decimal, mCosto As Decimal

        mCantidad = CDec(IIf(grProductos.Rows(Ff).Cells(3).Value.ToString <> "", grProductos.Rows(Ff).Cells(3).Value.ToString, 0))
        mCosto = CDec(IIf(grProductos.Rows(Ff).Cells(4).Value.ToString <> "", grProductos.Rows(Ff).Cells(4).Value.ToString, 0))

        numTotal = numTotal + mCantidad * mCosto
        If mCantidad * mCosto = 0 Then
          Validacion = False
        End If
      End If
    Next

    If Validacion = False Then
      MessageBox.Show("Existen productos sin cantidad o costo!", "Validación productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Validacion = True
    End If


    For Ff = 0 To grEmpleados.RowCount - 1
      If grEmpleados.Rows(Ff).Cells(6).Value = True Then
        Dim mCantidad As Decimal, mCosto As Decimal
        mCantidad = CDec(IIf(grEmpleados.Rows(Ff).Cells(3).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(3).Value.ToString, 0))
        mCosto = CDec(IIf(grEmpleados.Rows(Ff).Cells(4).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(4).Value.ToString, 0))


        numTotal = numTotal + mCantidad * mCosto

        If mCantidad * mCosto = 0 Then
          Validacion = False
        End If
      End If
    Next
    If Validacion = False Then
      MessageBox.Show("Existe mano de obra sin cantidad o costo!", "Validación mano de obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Validacion = True
    End If


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
    If Validacion = False Then
      MessageBox.Show("Existe items de montaje sin costo!", "Validación montaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Validacion = True
    End If

    numTotal = numTotal + CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) _
         + CDec(IIf(txtValorMontaje.Text = "", 0, txtValorMontaje.Text))

    txtUtilidad.Text = CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal
    mTotal = numTotal + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal

    lblTotal.Text = CDec(mTotal).ToString(FCTOTOT)
  End Sub



  Private Sub btnAdicionarMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles btnAdicionarMO.Click

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


  Private Sub btnGrabar_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click

    If MessageBox.Show("Desea " & sender.text & " ahora?", UCase(sender.text), MessageBoxButtons.YesNo, _
                       MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    'If grProductos.RowCount = 0 And grEmpleados.RowCount = 0 Then
    '  If MessageBox.Show("Desea " & sender.text & " sin datos de productos y mano de obra?", UCase(sender.text), MessageBoxButtons.YesNo, _
    '                   MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
    '    Exit Sub
    '  End If
    'End If

    btnGrabar.Text = "Grabando..."
    btnGrabar.Enabled = False

    Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer

    'GRABO LOS PRODUCTOS EN MEMORIA
    Ff_ID = 1
    For Ff = 0 To grProductos.RowCount - 1
      If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
        Dim NuevaFila = objCalc.DetCotizacion.NewRow()

        Ff_ID = Ff_ID + 1
        NuevaFila("Cab_ID") = 0
        NuevaFila("id") = Ff_ID
        NuevaFila("Tipo") = 1
        NuevaFila("CodInventario") = grProductos.Item(2, Ff).Value 'IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(2, Ff).Value)
        NuevaFila("Cant") = TxtADec(grProductos.Item(3, Ff).Value) 'CDec(IIf(grProductos.Item(3, Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
        NuevaFila("Costo") = TxtADec(grProductos.Item(4, Ff).Value) 'CDec(IIf(grProductos.Item(4, Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = TxtADec(grProductos.Item("colCostoTotal", Ff).Value) 'CDec(IIf(grProductos.Item("colCostoTotal", Ff).Value = 0, 0, grProductos.Item("colCostoTotal", Ff).Value))
        objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

      End If
    Next

    'GRABO LA MANO DE OBRA EN MEMORIA
    For Ff = 0 To grEmpleados.RowCount - 1
      If grEmpleados.Rows(Ff).Cells("colAgregarMO").Value = True Then
        Dim NuevaFila = objCalc.DetCotizacion.NewRow()

        Ff_ID = Ff_ID + 1
        NuevaFila("Cab_ID") = 0
        NuevaFila("id") = Ff_ID
        NuevaFila("Tipo") = 2
        NuevaFila("CodInventario") = IIf(grEmpleados.Item(2, Ff).Value = "", 0, grEmpleados.Item(2, Ff).Value)
        NuevaFila("Cant") = TxtADec(grEmpleados.Item(3, Ff).Value)  'CDec(IIf(grEmpleados.Item(3, Ff).Value = 0, 0, grEmpleados.Item(3, Ff).Value))
        NuevaFila("Costo") = TxtADec(grEmpleados.Item(4, Ff).Value) 'CDec(IIf(grEmpleados.Item(4, Ff).Value = 0, 0, grEmpleados.Item(4, Ff).Value))
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = TxtADec(grEmpleados.Item("colValorTotal", Ff).Value) 'CDec(IIf(grEmpleados.Item("colValorTotal", Ff).Value = 0, 0, grEmpleados.Item("colValorTotal", Ff).Value))
        objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

      End If
    Next

    'GRABO LOS OTROS REGISTRO DE DETALLE
    If txtImprevistos.Text <> "" Then
      Ff_ID = Ff_ID + 1
      Dim NuevaFila2 = objCalc.DetCotizacion.NewRow()
      NuevaFila2("Cab_ID") = 0
      NuevaFila2("id") = Ff_ID
      NuevaFila2("Tipo") = 3
      NuevaFila2("CodInventario") = "IMPREVISTOS"
      NuevaFila2("Cant") = 1
      NuevaFila2("Costo") = TxtADec(txtImprevistos.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = TxtADec(txtImprevistos.Text)
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
      NuevaFila2("Costo") = TxtADec(txtUtilidad.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = TxtADec(txtUtilidad.Text)
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
          NuevaFila2("Costo") = TxtADec(filaGrilla.Cells(2).Value)  'txtValorMontaje.Text
          NuevaFila2("Estado") = "A"
          NuevaFila2("Inventario_ID") = filaGrilla.Cells(0).Value.ToString
          NuevaFila2("CostoTotal") = TxtADec(filaGrilla.Cells(2).Value)

          objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
          NuevaFila2 = Nothing
        End If

      Next
    End If
    '********************************  FIN DE LA PARTE DE DETALLE DE LA COTIZACION ************


    'El número del consecutivo
    Dim obCntv As New clConectividad
    Dim NumCotizacion As String
    NumCotizacion = obCntv.LeerValorSencillo("CONVERT(int,valor)+1 [NumCotizacion]", "NumCotizacion", "Parametros", " ID=" & mIdNumeroCotizacionRapida, strCadena)

    txtAIU.Text = IIf(txtAIU.Text = "", 0, txtAIU.Text)
    txtAIU_MO.Text = IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)

    txtImprevistos.Text = IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)

    Dim strPrecioFinal As Single
    If txtPrecioFinal.Text = "" Then
      strPrecioFinal = 0
    Else
      strPrecioFinal = CType(txtPrecioFinal.Text, Single)
    End If


    Dim mReq As Integer = 0


    'ONYX 20180216 - OJO AJUSTAR EG

    Dim xEstado As String = obCntv.LeerValorSencillo("Estado", "Estados", "id=" & My.Settings.EstadoxRol_Id, My.Settings.cnnModProd)

    objCalc.GrabarCotizacion(strCadena, dtpFecha.Value, txtObservacion.Text, strIdCliente, strNombreCliente, _
      txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
      txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, NumCotizacion.ToString, cmbAsignadaA.Text, lblTotal.Text, strPrecioFinal, _
      chkVentaDirecta.Checked, txtAIU.Text, txtImprevistos.Text, xEstado, txtObsInterna.Text, "CR", mReq, "", 0, txtAIU_MO.Text, 1)


    Dim NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0 and tipo='CR'", strCadena)


    'GRABO LOS ESTADOS
    Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
    Dim mEstadoxRol_Id As String = My.Settings.EstadoxRol_Id
    strInsert = "exec pa_Insert_EstadosCotizacion " & NuevoID & "," & mEstadoxRol_Id & "," & mUsuarioId
    obCntv.EjecutaComando(strInsert, strCadena, False)

    'GRABO LOS ANEXOS
    Dim strRuta As String = GrabarAnexos(NuevoID)
    Call ActualizarGUID(strRuta, mGuid, NumCotizacion)

    'GRABO LA LISTA DE CHEQUEO
    Call GrabarCheckList(NuevoID)

    If MessageBox.Show("Desea imprimir los documentos ahora?", UCase("IMPRIMIR"), MessageBoxButtons.YesNo, _
                      MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

      btnGrabar.Text = "Generando informe ..."
      Call Imprimir(NuevoID, chkVentaDirecta.Checked)
    End If

    obCntv.EjecutaComando("update Parametros set Valor='" & NumCotizacion.ToString & "' where id=" & mIdNumeroCotizacionRapida, strCadena, False)

    MessageBox.Show("Cotización Guardada con el número " & NumCotizacion.ToString, "Cotización", MessageBoxButtons.OK)
    btnGrabar.Enabled = True
    btnGrabar.Text = "Grabar"
    obCntv = Nothing

    mNumCotiza = NumCotizacion : mCabCotiza = NuevoID

    Me.DialogResult = Windows.Forms.DialogResult.OK

    'Dim frm As New frmSimuladorRapida
    'Me.Visible = False
    'frm.Show()
    'Me.Close()



  End Sub

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

      Dim Cotiza As Integer = InputBox("Cotizacion")

      Dim objCntv As New clConectividad
      Dim strConsulta As String = "Select "

      Dim drCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("ID, VentaDirecta, NumCotizacion", "CabCotizacion", "NumCotizacion ='" & Cotiza & "'", strCadena)

      Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
      Call Imprimir(drCotiza.Item("ID"), drCotiza.Item("VentaDirecta"))
      Me.Cursor = System.Windows.Forms.Cursors.Default

    Catch ex As System.InvalidCastException
      'SE DEJA EN BLANCO PARA MANEJAR EL ERROR CUANDO CANCELAN CON EL BOTON DEL INPUTBOX
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
    Try

      Dim Cotiza As Integer = InputBox("Cotizacion")
      Call CargarCotizacion(Cotiza)



    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try
  End Sub


  Private Sub Actualizar()

    Dim objCalc As New clCalculadora

    Dim strFecha As Date

    strFecha = dtpFecha.Value
    If strIdCliente = "0" Then strNombreCliente = cmbCliente.Text.ToString


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
      chkVentaDirecta.Checked, txtAIU.Text.ToString, txtImprevistos.Text.ToString, txtObsInterna.Text.ToString, "CR", strEstado, 0, "", 0, IIf(txtAIU_MO.Text.ToString = "", 0, txtAIU_MO.Text.ToString))

    ''ONYX 20180216 - OJO AJUSTAR EG
    'objCalc.ActualizarCotizacion(strCadena, mId, strFecha, txtObservacion.Text, strIdCliente, strNombreCliente, _
    '  txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
    '  txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, mNumCotiza.ToString, cmbAsignadaA.Text, lblTotal.Text, txtPrecioFinal.Text, _
    '  chkVentaDirecta.Checked, txtAIU.Text.ToString, txtImprevistos.Text.ToString, txtObsInterna.Text.ToString, "CN", strEstado, mReqID, _
    '  txtOC_Cliente.Text, intContrato_Id, txtAIU_MO.Text.ToString)

    Call ActualizarDetalle(mId)
    Call ActualizarAnexos(mId)
    Call ActualizarCheckList(mId)

  End Sub

  Private Sub ActualizarDetalle(ByVal Cab_ID As Integer)
    Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer
    Dim obCntv As New clConectividad, strComando As String

    strComando = "delete from DetCotizacion where Cab_ID =" & Cab_ID.ToString
    obCntv.EjecutaComando(strComando, strCadena, False)


    Ff_ID = 1
    For Ff = 0 To grProductos.RowCount - 1
      If grProductos.Rows(Ff).Cells(6).Value = True Then
        Dim NuevaFila = objCalc.DetCotizacion.NewRow()

        Ff_ID = Ff_ID + 1
        NuevaFila("Cab_ID") = 0
        NuevaFila("id") = Ff_ID
        NuevaFila("Tipo") = 1
        NuevaFila("CodInventario") = grProductos.Item(2, Ff).Value 'IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(2, Ff).Value)
        NuevaFila("Cant") = CDec(IIf(grProductos.Item(3, Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
        NuevaFila("Costo") = CDec(IIf(grProductos.Item(4, Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = CDec(IIf(grProductos.Item("ColCostoTotal", Ff).Value = 0, 0, grProductos.Item("ColCostoTotal", Ff).Value))
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


    objCalc.ActualizaDetalleCotiza(Cab_ID, strCadena)


  End Sub



  Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizar.Click
    If MessageBox.Show("Desea " & sender.text & " ahora?", UCase(sender.text), MessageBoxButtons.YesNo, _
                      MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    Call Actualizar()
    cmdActualizar.Enabled = False
    btnGrabar.Text = "Grabar"
    btnGrabar.Enabled = False

    If MessageBox.Show("Datos actualizados con éxito!" & vbCrLf & "Desea continuar editando la cotización?", "Datos grabados", _
                       MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then

      Dim frm As New frmSimuladorRapida
      Me.Visible = False
      frm.Show()
      Me.Close()
    Else
      Call CargarCotizacion(mNumCotiza)
    End If

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


  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSigFase.Click

    If MessageBox.Show("Desea pasar a la siguiente fase la cotización?", UCase(sender.text), MessageBoxButtons.YesNo, _
                   MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
      Exit Sub
    End If

    Call Actualizar()

    Dim obCntv As New clConectividad, fF As Integer = 0, Ii As Integer

    For fF = 0 To chkListEstados.Items.Count - 1
      If chkListEstados.GetItemCheckState(fF) = False Then
        Ii = fF + 1
        Exit For
      End If
    Next fF


    'GRABO LOS ESTADOS
    Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")

    'strInsert = "Insert EstadosCotizacion values (" & mId.ToString & "," & Ii.ToString & ",'" & strHoy & "'," & mUsuarioId & ")"
    strInsert = "exec pa_Insert_EstadosCotizacion " & mId.ToString & "," & Ii.ToString & "," & mUsuarioId
    obCntv.EjecutaComando(strInsert, strCadena, False)


    MessageBox.Show("Cotización se ha pasado a la siguiente fase.")

    cmdActualizar.Enabled = False
    btnGrabar.Text = "Grabar"
    btnGrabar.Enabled = False

    'PARA HABILITAR O NO LA SIGUIENTE FASE
    Call HabilitarSiguienteFase()

    obCntv = Nothing

  End Sub


  Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

    Call HabilitarSiguienteFase()
  End Sub

  Private Sub HabilitarSiguienteFase()
    Dim obCntv As New clConectividad

    Dim strComando As String
    strComando = "EXEC pa_RevisarPermisoSiguienteFase " & mUsuarioId.ToString & "," & mId.ToString
    Dim drResult As MSSQL.SqlDataReader = obCntv.EjecutaComando(strComando, strCadena, True)
    drResult.Read()
    btnSigFase.Enabled = drResult.Item(0)

  End Sub



  Private Sub CargarCotizacion(ByVal mNumCotizacion As Integer)
    Try

      Dim Cotiza As Integer = mNumCotizacion

      Dim objCntv As New clConectividad, fF As Integer
      Dim strConsulta As String = "Select "

      'CARGA LA CABECERA
      Dim drCabCotiza As MSSQL.SqlDataReader = _
      objCntv.LeerValor("*", "CabCotizacion", "NumCotizacion ='" & mNumCotizacion & "' and tipo='CR'", strCadena)

      strIdCliente = drCabCotiza.Item("IdCliente").ToString
      strNombreCliente = drCabCotiza.Item("NombreCliente").ToString
      cmbCliente.Text = strNombreCliente

      txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
      txtAlcance.Text = drCabCotiza.Item("Alcance").ToString
      txtObservacion.Text = drCabCotiza.Item("Observacion").ToString
      cmbAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString
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


      'CARGA EL DETALLE
      grProductos.Rows.Clear()
      grEmpleados.Rows.Clear()
      Dim drDetCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "DetCotizacion", "Cab_ID =" & drCabCotiza.Item("id").ToString & " and tipo in (1,2)", strCadena)

      Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
        If drDetCotiza.HasRows = True Then
          Dim strFilaNueva() As String
          If drDetCotiza.Item("Tipo").ToString = "1" Then
            strFilaNueva = {grProductos.Rows.Count + 1,
                            "",
                            drDetCotiza.Item("CodInventario").ToString,
                            CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                            CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                            CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                            True}
            grProductos.Rows.Add(strFilaNueva)
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

      Call Calcular()

      'CARGO LOS ANEXOS ****************************************************************************
      Dim drAnexos As MSSQL.SqlDataReader
      mTablaAnexos = CreaTablaAnexos()
      drAnexos = objCntv.LeerValor("*", "AnexosCotizacion", "Cab_ID =" & mId.ToString & " and estado='A'", strCadena)
      lstAnexos.Items.Clear() : mVctAnexos.Clear()

      Do
        If drAnexos.HasRows = True Then
          lstAnexos.Items.Add(IO.Path.GetFileName(drAnexos.Item("RutaArchivo").ToString), True)
          mVctAnexos.Add(drAnexos.Item("RutaArchivo").ToString)

          Dim mFila As DataRow = mTablaAnexos.NewRow
          mFila.Item("id") = drAnexos.Item("id")
          mFila.Item("RutaArchivo") = drAnexos.Item("RutaArchivo")
          mFila.Item("NombreArchivo") = IO.Path.GetFileName(drAnexos.Item("RutaArchivo"))
          mFila.Item("Estado") = drAnexos.Item("Estado")
          mTablaAnexos.Rows.Add(mFila)
        End If
      Loop While drAnexos.Read()

      If lstAnexos.Items.Count > 0 Then
        Call CargaImagen(mVctAnexos(1).ToString, False)
      End If

      'LOS ESTADOS DE LA ORDEN
      Dim drEstadosCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "vw_EstadosCotizacion", "Cab_ID =" & mId.ToString, strCadena)

      Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
        chkListEstados.SetItemChecked(fF, True)
        fF = fF + 1
      Loop While drEstadosCotiza.Read()


      'CARGO LA LISTA DE CHEQUEO
      Dim drCheckListCotizacion As MSSQL.SqlDataReader = _
        objCntv.LeerValor("CheckList_Id, valor", "CheckListCotizacion", "Cab_ID =" & mId.ToString, strCadena)
      chkCheckListCotizacion.ClearSelected()
      fF = 0

      If drCheckListCotizacion.HasRows = True Then
        Do
          Dim Valor As Boolean = drCheckListCotizacion.Item("valor")
          chkCheckListCotizacion.SetItemChecked(fF, Valor)
          fF = fF + 1
        Loop While drCheckListCotizacion.Read()
      End If

      'PONGO EN ORDEN LOS CONTROLES
      cmdActualizar.Enabled = True : btnAprobar.Enabled = True
      btnSigFase.Enabled = True
      If fF = 5 Then
        btnSigFase.Enabled = False
        cmdActualizar.Enabled = False
      End If

      If lblEstado.Text = "V" Then
        cmdActualizar.Enabled = False
        btnAprobar.Enabled = False
      End If

      btnGrabar.Text = "Copiar " & mNumCotizacion.ToString()

      'PARA HABILITAR O NO LA SIGUIENTE FASE
      Call HabilitarSiguienteFase()
      cmbCliente.Focus()
      mDocCargado = True

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try
  End Sub




  Private Sub btnCalcular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcular.Click
    Call Calcular()
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

    strSql = "update AnexosCotizacion set estado='I' where cab_Id=" & Cab_Id.ToString
    obCntv.EjecutaComando(strSql, strCadena, False)

    For Each mFila In mTablaAnexos.Rows
      If mFila("Estado") = "A" Then
        strSql = "update AnexosCotizacion set estado='A' where Id=" & mFila("Id")
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

          Dim strInsert As String = "insert AnexosCotizacion(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumCotiza.ToString & "','A')"
          obCntv.EjecutaComando(strInsert, strCadena, False)

        Catch ex As System.IO.DirectoryNotFoundException
          IO.Directory.CreateDirectory(strRuta)
          IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

          Dim strInsert As String = "insert AnexosCotizacion(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
            & strDestino.ToString & "','" & mNumCotiza.ToString & "','A')"
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
        Call Calcular()


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

  Private Sub ChkAnulada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnulada.CheckedChanged
    'If btnSigFase.Enabled = True Then
    '  btnSigFase.Enabled = Not CBool(ChkAnulada.CheckState)
    'End If

    If btnSigFase.Enabled = True Then

      If ChkAnulada.CheckState = CheckState.Checked Then
        btnSigFase.Enabled = False
        btnSigFase.Tag = 1
      Else
        If btnSigFase.Tag = 1 Then
          btnSigFase.Enabled = True
        End If
      End If
    End If

  End Sub

Private Sub btnSeleccionar_Click(sender As System.Object, e As System.EventArgs) Handles btnSeleccionar.Click
     'mNumCotiza = NumCotizacion : mCabCotiza = NuevoID

    Me.DialogResult = Windows.Forms.DialogResult.OK
End Sub
End Class



