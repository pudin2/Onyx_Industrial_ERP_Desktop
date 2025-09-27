Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel

'Imports System.Drawing.Printing.PageSettings
'Imports System.Drawing.Printing.PaperSize

Public Class frmSimulador
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mEstado_Id_Actual As Integer
  Private mPreguntaSalida As Boolean
  Private mUsuario As String, mDominio As String


  'Private WithEvents dataGridView1 As New DataGridView()
  Dim Sep As Char
  Private strCadena As String
  Private mCabMov_Id As String, strNombreProducto As String, strCodInventario As String
  Private strNombreEmpleado As String, strIdentificacion As String = ""
  Private mTotal As Decimal, strIdCliente As String, strNombreCliente As String
  Private mReqID As Integer, intContrato_Id As Integer
  Private mEsNuevo As Boolean, mNumCotiza As Integer = 0, mId As Integer
  Private dtProducto As Data.DataTable, mUsuarioId As Integer
  Private mGuid As String = ""
  Private mVctAnexos As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private mTblCheckList As DataTable
  Private mModoLiquidacionVentaDirecta As Boolean, mNumOrden As Integer
  Private mTipoCot As String = "CN"
  Private mIdUnicoAnexo As String



    Public Property NumOrdenTrabajo As Integer
        Get
            Return mNumorden
        End Get
        Set(value As Integer)
            mNumOrden = value
        End Set
    End Property

    Public Property NumCotizacion As Integer
        Get
            Return mNumCotiza
        End Get
        Set(value As Integer)
            mNumCotiza = value
        End Set
    End Property


    Public Property ModoLiquidacionVentaDirecta As Boolean
        Get
            Return mModoLiquidacionVentaDirecta
        End Get
        Set(value As Boolean)
            mModoLiquidacionVentaDirecta = value
        End Set
    End Property


    Public Property Usuario As String
        Get
            Return mUsuario
        End Get
        Set(value As String)
            mUsuario = value
        End Set
    End Property

    Public Property Dominio As String
        Get
            Return mDominio
        End Get
        Set(value As String)
            mDominio = value
        End Set
    End Property



    Private Sub frmSimulador_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      If mPreguntaSalida = True Then
        If mModoLiquidacionVentaDirecta = False Then
            If MsgBox(LeerEtqTextoXml("msgTextoSalir"), MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Cerrando cotización") = MsgBoxResult.No Then
                e.Cancel = True
            End If


            Call CerrarControlBarra()
        Else 'SALIDA DE VENTA DIRECTA
            'PROGRAMAR

        End If
      End If

    End Sub

    Private Sub CerrarControlBarra()
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
      End Sub

    Private Sub frmSimulador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Icon = My.Resources.IconoFrm
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        mPreguntaSalida = True

        Dim obAnexo As New clAnexos
        mIdUnicoAnexo = obAnexo.IdUnico.ToString
        obAnexo = Nothing

        grpOtros.Height = 175 : pnlTotaltes.Top = 174

        'OCULTO POR DEFECTO LA COLUMNA DE CALCULAR
        Dim mCalcular As Boolean
        mCalcular = My.Settings.ColCalcular

        grProductos.Columns("colCalcular").Visible = mCalcular
        grEmpleados.Columns("colCalcularMO").Visible = mCalcular



        Call EstadoInicialBotones()
        Me.Text = My.Settings.TituloSimulador

        'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
        If Me.Tag IsNot Nothing Then
          Me.Tag.TEXT = Me.Text
        End If

        mEsNuevo = True

        'Detectar el separador decimal de la aplicación.
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
        Dim obCntv As New clConectividad

        strCadena = My.Settings.cnnModProd  'ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
        obCntv.CadenaDeConeccion = strCadena


        obCntv.CadenaDeConeccion = My.Settings.cnnModProd
        dtProducto = obCntv.LlenarDataTable(strCadena, False, "pa_ProductosTerminadosOEnProceso", "", "dt_ProductosTerminadosOEnProceso")

        cmbProducto.DataSource = dtProducto  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
        cmbProducto.DisplayMember = "Descripcion"

        If mModoLiquidacionVentaDirecta = False Then
            cmbEmpleados.DataSource = obCntv.LlenarDataTable(strCadena, "*", "areasplanta", "estado in ('A','O')", "order by id")
        Else
            cmbEmpleados.DataSource = obCntv.LlenarDataTable(strCadena, "*", "areasplanta", "estado in ('A','O') and tipo='S'", "order by id")
        End If
        cmbEmpleados.DisplayMember = "Nombre"


        'cmbCliente.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_Clientes", "esactivo=1", "Order by Nombre1")


        cmbCliente.DataSource = obCntv.LlenarDataTable(strCadena, False, "PA_Clientes", "", "dt_PA_Clientes")
        cmbCliente.DisplayMember = "NombreCompleto"

        'PARTE DE LOS TIPOS DE GASTOS DE MONAJE
        grTipoGastos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_TipoGastos", "Estado=0")
        Dim miCol As DataGridViewColumn
        miCol = grTipoGastos.Columns(0) : miCol.Width = 20
        miCol = grTipoGastos.Columns(1) : miCol.Width = 80
        miCol = grTipoGastos.Columns(2) : miCol.Width = 80
        miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        miCol = grTipoGastos.Columns(3) : miCol.Width = 20 : miCol.ReadOnly = False

        grTipoGastos.Columns("TipoPorcUtil").Visible = False


        ''LA PARTE DEL CHECKLIST DE MATERIALES
        'mTblCheckList = obCntv.LlenarDataTable(strCadena, "*", "CheckList", "estado='A'")
        'chkCheckListCotizacion.Items.Clear()
        'For Each Fila As DataRow In mTblCheckList.Rows
        '    chkCheckListCotizacion.Items.Add(Fila.Item("Nombre").ToString, False)
        'Next


        'PARTE DE LA CARGA DE LOS REPONSABLES
        cmbAsignadaA.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Responsables", "Estado='A'")
        cmbAsignadaA.DisplayMember = "Nombre"

        'EL MANEJO DE LOS ESTADOS
        chkListEstados.ClearSelected()


        Dim obInicio As New clSetUpInicio
        mUsuario = obInicio.Usuario
        mDominio = obInicio.Dominio
        obInicio = Nothing


        Dim strWhere As String = "dominio='" & mDominio & "' and usuario='" & mUsuario & "'"
        mUsuarioId = obCntv.LeerValorSencillo("id", "Usuarios", strWhere, strCadena)

        Dim mRol_I As String = obCntv.LeerValorSencillo("Rol_id", "Usuarios", strWhere, strCadena)
        Dim mEstadoAnulado_Id As String = obCntv.LeerValorSencillo("Valor", "Parametros", "id=11", strCadena)


        Dim rsEstadosXRoles As MSSQL.SqlDataReader
        'rsEstadosXRoles = obCntv.LeerValor("*", "EstadosXRoles", "Rol_Id = " & mRol_I & " and Estado_Id = " & mEstadoAnulado_Id, strCadena)
        rsEstadosXRoles = obCntv.LeerValor("*", "VW_EstadosXRolesXDoc", "TipoDoc='CT' and Rol_Id = " & mRol_I & " and Estado_Id = " & mEstadoAnulado_Id, strCadena)

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
        ' marzo 22 de 2016
        Label28.Text = ""
        Label29.Text = ""
        Label30.Text = ""
        Label31.Text = ""
        Label32.Text = ""
        Label33.Text = ""

        sender.windowstate = FormWindowState.Maximized
        Me.Cursor = System.Windows.Forms.Cursors.Default


        Call NombrarBotones()
        mTablaAnexos = Nothing
        mTablaAnexos = CreaTablaAnexos()

        '***********************  ONYX 2019 02 12:
        '******* PARA CUMPLIR CON LA LIQUIDACIÓN DE OT POR VENTA DIRECTA
        If mModoLiquidacionVentaDirecta = True Then
            Call EstablecerModoLiquidacionVentaDirecta()
        End If


    End Sub




    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtCantidad.KeyPress, txtCosto.KeyPress, txtCantMO.KeyPress, txtValorHora.KeyPress, _
      txtTmpEntrega.KeyPress, txtTmpFabricacion.KeyPress, txtValorMontaje.KeyPress, txtAIU_MO.KeyPress, txtAIU.KeyPress


        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Call Calcular()
        End If

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
            Call ManejoError(Me.Name, "btnAdicionar.Click", ex)
            MessageBox.Show("Se ha presentado el siguiente error: " & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try


        If txtCantidad.Text <> "" Then

            Dim strFilaNueva() As String = {grProductos.Rows.Count + 1,
                                            strCodInventario.ToString,
                                            strNombreProducto.ToString,
                                            CDec(txtCantidad.Text.ToString).ToString(FCANT),
                                            CDec(txtCosto.Text.ToString).ToString(FCTO_U),
                                            (CDec(txtCantidad.Text.ToString) * CDec(txtCosto.Text.ToString)).ToString(FCTOTOT),
                                            txtDescItem.Text,
                                            True, True}

            grProductos.Rows.Add(strFilaNueva)
            txtCantidad.Text = ""
            txtCosto.Text = ""
            txtDescItem.Text = ""

            Call Calcular()
            strCodInventario = ""
        Else
            MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
    End Sub

    Private Sub Calcular()
        Dim numTotal As Decimal, Ff As Integer, Validacion As Boolean = True
        Dim numTotalMP As Decimal = 0


        numTotal = 0

        For Ff = 0 To grProductos.RowCount - 1
            If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
                Dim mCantidad As Decimal, mCosto As Decimal, mCalcular As Integer

                mCantidad = CDec(IIf(grProductos.Rows(Ff).Cells(3).Value.ToString <> "", grProductos.Rows(Ff).Cells(3).Value.ToString, 0))
                mCosto = CDec(IIf(grProductos.Rows(Ff).Cells(4).Value.ToString <> "", grProductos.Rows(Ff).Cells(4).Value.ToString, 0))
                mCalcular = IIf(grProductos.Rows(Ff).Cells("colCalcular").Value = True, 1, 0)


                numTotal = numTotal + mCantidad * mCosto * mCalcular
                numTotalMP = numTotalMP + mCantidad * mCosto * mCalcular

                If mCantidad * mCosto = 0 Then
                    Validacion = False
                End If
            End If
        Next

        lblTotalMateriales.Text = CDec(numTotal).ToString(FCTOTOT)


        If Validacion = False Then
            MessageBox.Show("Existen productos sin cantidad o costo!", "Validación productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Validacion = True
        End If


        '*********************************************************************************************************************************
        '*********************************************************************************************************************************
        'LA PARTE DE LA MANO DE OBRA
        Dim numTotalMO As Decimal = 0

        For Ff = 0 To grEmpleados.RowCount - 1
            If grEmpleados.Rows(Ff).Cells("colAgregarMO").Value = True Then
                Dim mCantidad As Decimal, mCosto As Decimal, mCalcular As Integer
                mCantidad = CDec(IIf(grEmpleados.Rows(Ff).Cells(3).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(3).Value.ToString, 0))
                mCosto = CDec(IIf(grEmpleados.Rows(Ff).Cells(4).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(4).Value.ToString, 0))
                mCalcular = IIf(grEmpleados.Rows(Ff).Cells("colCalcularMO").Value = True, 1, 0)

                numTotal = numTotal + mCantidad * mCosto * mCalcular
                numTotalMO = numTotalMO + mCantidad * mCosto * mCalcular

                If mCantidad * mCosto = 0 Then
                    Validacion = False
                End If
            End If
        Next

        lblTotalMO.Text = CDec(numTotalMO).ToString(FCTOTOT)

        If Validacion = False Then
            MessageBox.Show("Existe mano de obra sin cantidad o costo!", "Validación mano de obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Validacion = True
        End If


        'LOS GASTOS DE MONTAJE
        Dim mUtilMontaje As Decimal = 0, numTotalMontaje As Decimal = 0
        If chkMontaje.Checked = True Then
            For Ff = 0 To grTipoGastos.RowCount - 1
                If grTipoGastos.Rows(Ff).Cells(3).Value = True Then
                    Dim mCosto As Decimal

                    mCosto = CDec(IIf(grTipoGastos.Rows(Ff).Cells(2).Value.ToString <> "", grTipoGastos.Rows(Ff).Cells(2).Value.ToString, 0))
                    numTotal = numTotal + mCosto
                    numTotalMontaje = numTotalMontaje + mCosto
                    'numTotalMO = numTotalMO + mCosto


                    If grTipoGastos.Item("TipoPorcUtil", Ff).Value = "MP" Then
                        mUtilMontaje = mUtilMontaje + (CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * mCosto)
                    ElseIf grTipoGastos.Item("TipoPorcUtil", Ff).Value = "MO" Then
                        mUtilMontaje = mUtilMontaje + (CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * mCosto)
                    End If


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
         '*********************************************************************************************************************************
        '*********************************************************************************************************************************


        'ACA YA TENGO TODA LA BASE COMPLETA: MATERIALES, MANO DE OBRA E IMPREVISTOS
        numTotal = numTotal + CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) + CDec(IIf(txtValorMontaje.Text = "", 0, txtValorMontaje.Text))

        'ONYX: LE SUMO A LA BASE DE MO LOS IMPREVISTOS
        numTotalMO = numTotalMO '+ CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text))



        'ESTE CAMPO ES COMPUESTO
        'txtUtilidad.Text = CDec(CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal).ToString(FCTOTOT)
        txtUtilidad.Text = CDec((CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + (CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO) + mUtilMontaje).ToString(FCTOTOT)


       'mTotal = numTotal + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal
        mTotal = (numTotalMP + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + _
                 (numTotalMO + CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO) + _
                 CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) + mUtilMontaje + numTotalMontaje

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
                                            txtDescItemMO.Text.ToString,
                                            True, True}

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
      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiCot.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"
      'chkVentaDirecta.Text = obXml.LeerValor("chkVentaDirecta")


        If cmbAsignadaA.Text.ToString = "" Then
            MessageBox.Show("El campo Asignado A es obligatorio!. No se puede continuar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If MessageBox.Show("Desea " & sender.text & " ahora?", UCase(sender.text), MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If

        If grProductos.RowCount = 0 And grEmpleados.RowCount = 0 Then
            If MessageBox.Show("Desea " & sender.text & " sin datos de productos y mano de obra?", UCase(sender.text), MessageBoxButtons.YesNo, _
                             MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
                Exit Sub
            End If
        End If

        If txtCntAFabricar.Text = "" Then
            MessageBox.Show("El campo Cantidad a Fabricar es obligatorio!. No se puede continuar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If



        'ONYX - 20180521 - VALIDACION DE LISTA DE CHEQUEO
        'Dim strValidaLista As String = ValidarCheckList()

        'If strValidaLista <> "" Then
        '  If MessageBox.Show(obXml.LeerValor("preguntaMensajeValidaChecklist") & vbCrLf & vbCrLf & strValidaLista, obXml.LeerValor("tituloMensajeValidaChecklist"), MessageBoxButtons.YesNo, _
        '                    MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
        '      Exit Sub
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
                NuevaFila("Inventario_ID") = IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(1, Ff).Value)
                NuevaFila("Estado") = "A"
                NuevaFila("CostoTotal") = TxtADec(grProductos.Item("colCostoTotal", Ff).Value) 'CDec(IIf(grProductos.Item("colCostoTotal", Ff).Value = 0, 0, grProductos.Item("colCostoTotal", Ff).Value))
                NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value
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
                NuevaFila("Inventario_ID") = IIf(grEmpleados.Item(1, Ff).Value = "", 0, grEmpleados.Item(1, Ff).Value)
                NuevaFila("DescItem") = grEmpleados.Item("colDescItemMO", Ff).Value
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




        txtAIU.Text = IIf(txtAIU.Text = "", 0, txtAIU.Text)
        txtAIU_MO.Text = IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)
        txtImprevistos.Text = IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)

        Dim strPrecioFinal As Single
        If txtPrecioFinal.Text = "" Then
            strPrecioFinal = 0
        Else
            strPrecioFinal = CType(txtPrecioFinal.Text, Single)
        End If

        'El número del consecutivo
        Dim obCntv As New clConectividad
        Dim NumCotizacion As String
        NumCotizacion = obCntv.LeerValorSencillo("CONVERT(int,valor)+1 [NumCotizacion]", "NumCotizacion", "Parametros", " ID=3", strCadena)
        obCntv.EjecutaComando("update Parametros set Valor='" & NumCotizacion.ToString & "' where id=3", strCadena, False)


        'ONYX 20180216 - OJO AJUSTAR EG
        objCalc.GrabarCotizacion(strCadena, dtpFecha.Value, txtObservacion.Text, strIdCliente, strNombreCliente, _
          txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
          txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, NumCotizacion.ToString, cmbAsignadaA.Text, lblTotal.Text, strPrecioFinal, _
          chkVentaDirecta.Checked, txtAIU.Text, txtImprevistos.Text, "R", txtObsInterna.Text, "CN", mReqID, txtOC_Cliente.Text, _
          intContrato_Id, txtAIU_MO.Text, txtCntAFabricar.Text)


        Dim NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", strCadena)


        'GRABO LOS ESTADOS
        Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        'strInsert = "Insert EstadosCotizacion values (" & NuevoID & ",1,'" & strHoy & "'," & mUsuarioId & ")"
        strInsert = "exec pa_Insert_EstadosCotizacion " & NuevoID & ",1," & mUsuarioId
        obCntv.EjecutaComando(strInsert, strCadena, False)

        'GRABO LOS ANEXOS Y ACTULIZO MO
        If mDocCargado = True Then ' seguro para cuando se copia una cotizacion no de error en los anexos
          If MessageBox.Show("Desea copiar los anexos de la cotización " & mNumCotiza.ToString & "?", "Copiar Anexos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            mTablaAnexos = Nothing
            Call CargaAnexos(NuevoID, 1)


            Dim strRuta As String = GrabarAnexos(NuevoID, mDocCargado)
            Call ActualizarGUID(strRuta, mGuid, NumCotizacion)
          End If

          If MessageBox.Show("Desea actualizar los costos de Mano de Obra de la cotización " & mNumCotiza.ToString & "?", "Actualizar Costos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim strComando As String
            strComando = "exec PA_UpdateDetCotizacionMOActualizada " & NuevoID & ",1"
            obCntv.EjecutaComando(strComando, strCadena, False)

          End If
        Else
          'NumCotizacion
          mNumCotiza = NumCotizacion
          Call ActualizarAnexos(NuevoID)

        End If

        'GRABO LA LISTA DE CHEQUEO
        'Call GrabarCheckList(NuevoID)

        If MessageBox.Show("Desea imprimir los documentos ahora?", "Imprimir", MessageBoxButtons.YesNo, _
                          MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.Yes Then

            btnGrabar.Text = "Generando informe ..."
            Call Imprimir(NuevoID, chkVentaDirecta.Checked)
        End If


        'especial para guardar el estado anulado



        'MessageBox.Show("Cotización Guardada con el número " & NumCotizacion.ToString, "Cotización", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'btnGrabar.Enabled = True
        'btnGrabar.Text = "Grabar"
        'obCntv = Nothing


        'ONYX - 20180528
        If MessageBox.Show("Cotización Guardada con el número " & NumCotizacion.ToString & vbCrLf & "Desea continuar editando la cotización?", "Cotización", _
                           MessageBoxButtons.YesNo, MessageBoxIcon.Information) = Windows.Forms.DialogResult.No Then

            btnGrabar.Enabled = True
            btnGrabar.Text = "Grabar"
            obCntv = Nothing

            Dim frm As New frmSimulador
            Me.Visible = False : mPreguntaSalida = False
            frm.Show()
            Me.Close()

        Else
            Call CargarCotizacion(NumCotizacion)
        End If





        'Dim frm As New frmSimulador
        'Me.Visible = False : mPreguntaSalida = False
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

            Dim Cotiza As Integer = InputBox("Cotización", , IIf(mNumCotiza <> 0, mNumCotiza.ToString, ""))

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
          Call ManejoError(Me.Name, "btnImprimir.Click", ex)
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

        Call CargaContratos(strIdCliente)

    End Sub


    


    Private Sub cmdCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargar.Click
        Try

            If mDocCargado = True Then
              If MsgBox(LeerEtqTextoXml("msgTextoCargar"), MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Cargar cotización") = MsgBoxResult.No Then
                  Exit Sub
              End If
            End If



            Dim Cotiza As Integer = InputBox("Cotizacion")
            Me.Cursor = Cursors.WaitCursor
            strEstado.Visible = True
            strEstado.Text = "Cargando cotización ..."

            ' marzo 22 de 2016
            Label29.Text = ""
            Label30.Text = ""
            Label31.Text = ""
            Label32.Text = ""
            Label33.Text = ""
            Me.Refresh()


            Call CargarCotizacion(Cotiza)
            Call EstableceModoColumnas(grProductos)
            Call EstableceModoColumnas(grEmpleados)
            strEstado.Text = ""
            strEstado.Visible = False
            Me.Cursor = Cursors.Default
            txtAIU.PasswordChar = "*"
            txtAIU_MO.PasswordChar = "*"
            txtUtilidad.PasswordChar = "*"

            Call EstadoInicialBotones()

            'SE COMENTA EN ONYX EL 2019 05 22
            'If mTipoCot = "CR" Then
            '  Call OcultarBotonesVentaDirecta()
            'End If

        Catch ex As System.InvalidCastException
          Call ManejoError(Me.Name, "cmdCargar.Click", ex)
        Catch ex As Exception
          Call ManejoError(Me.Name, "cmdCargar.Click", ex)
          MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub


    Private Sub Actualizar()

        Dim objCalc As New clCalculadora

        Dim strFecha As Date

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

        Dim mTipoCot As String
        If mModoLiquidacionVentaDirecta = True Then
            mTipoCot = "CR"
        Else
            mTipoCot = "CN"
        End If

        'ONYX 20180216 - OJO AJUSTAR EG
        objCalc.ActualizarCotizacion(strCadena, mId, strFecha, txtObservacion.Text, strIdCliente, strNombreCliente, _
          txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
          txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, mNumCotiza.ToString, cmbAsignadaA.Text, lblTotal.Text, txtPrecioFinal.Text, _
          chkVentaDirecta.Checked, IIf(txtAIU.Text.ToString = "", 0, txtAIU.Text.ToString), txtImprevistos.Text.ToString, txtObsInterna.Text.ToString, mTipoCot, strEstado, mReqID, _
          txtOC_Cliente.Text, intContrato_Id, txtAIU_MO.Text.ToString)

        Call ActualizarDetalle(mId)
        Call ActualizarAnexos(mId)
        'Call ActualizarCheckList(mId)

    End Sub

    Private Sub ActualizarDetalle(ByVal Cab_ID As Integer)
        Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer
        Dim obCntv As New clConectividad ', strComando As String


        If mModoLiquidacionVentaDirecta = False Then
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
                    NuevaFila("Estado") = "A"
                    NuevaFila("CostoTotal") = CDec(IIf(grProductos.Item("ColCostoTotal", Ff).Value = 0, 0, grProductos.Item("ColCostoTotal", Ff).Value))
                    NuevaFila("Inventario_ID") = IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(1, Ff).Value)
                    NuevaFila("DescItem") = grProductos.Item("colDescItem", Ff).Value
                    objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila)

                End If
            Next
        End If

        For Ff = 0 To grEmpleados.RowCount - 1
            If grEmpleados.Rows(Ff).Cells(7).Value = True Then
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
                NuevaFila("Inventario_ID") = IIf(grEmpleados.Item(1, Ff).Value = "", 0, grEmpleados.Item(1, Ff).Value)
                NuevaFila("DescItem") = grEmpleados.Item("colDescItemMO", Ff).Value
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

        'strComando = "delete from DetCotizacion where Cab_ID =" & Cab_ID.ToString
        'obCntv.EjecutaComando(strComando, strCadena, False)
        objCalc.ActualizaDetalleCotiza(Cab_ID, strCadena)


    End Sub



    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdActualizar.Click
        If cmbAsignadaA.Text.ToString = "" Then
            MessageBox.Show("El campo Asignado A es obligatorio!. No se puede continuar", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

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

            If mModoLiquidacionVentaDirecta = False Then
                mPreguntaSalida = False
                'frm.Show()
                Me.Visible = False
                Dim frm As New frmSimulador
                Call frmMenuWin10.AbrirFormInPanel(frm)
                Call Me.CerrarControlBarra()
                Me.Close()
            Else
                'LA SALIDA DE LA VENTA DIRECTA A EL FORMULARIO QUE LA HA LLAMADO
                Me.DialogResult = Windows.Forms.DialogResult.OK
            End If
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
            Call ManejoError(Me.Name, "btnAprobar.Click", ex)
            MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub




    Private Sub grTipoGastos_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs)
        MessageBox.Show("Datos no validos en la celda: " _
            & e.Exception.Message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)



        e.ThrowException = False


    End Sub

    Private Sub cmbProducto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbProducto.TextChanged

        ' Call BuscarItem(cmbProducto.Text)
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

            dtFiltrado = obCntv.LlenarDataTable(strCadena, True, "pa_ProductosTerminadosOEnProceso", strFiltro, "dt_ProductosTerminadosOEnProceso")


        End If



        cmbProducto.DataSource = dtFiltrado
        cmbProducto.DisplayMember = "Descripcion"

        cmbProducto.BackColor = mColor
        cmbProducto.Refresh()

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

        If MessageBox.Show("Desea pasar a la siguiente fase de la cotización?", UCase(sender.text), MessageBoxButtons.YesNo, _
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

        'ONYX: SE MANTIENE ESTRA RESTRICCION PARA LA PARTE DE AJUSTE DE MATERIALES
        'ALERTA PARA USUARIO SI HAY MP NO CREADA
        Dim mValidaMP As String
        mValidaMP = obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion='ValidarMPenCotAprobada'", My.Settings.cnnModProd)

        If mValidaMP = "SI" Then
            If Ii = 6 Then '5 Then
                Dim strCantMPNoCreada As String
                Dim dr As MSSQL.SqlDataReader

                dr = obCntv.LeerValor("COUNT(1) [cant]", "VW_MaterialesNoCreados", "Cab_ID=" & mId.ToString, strCadena)
                strCantMPNoCreada = dr.Item("Cant").ToString

                If strCantMPNoCreada <> "0" Then
                    MessageBox.Show("La cotización tiene items de Materia Prima sin crear." & vbCrLf & "No se puede continuar!", "MP no creada", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    'MUESTRO EN PANTALLA LOS ITEMS NO CREADOS DE MP
                    Dim frm As New frmRptMaterialesNoCreados
                    frm.strCotizacion = mNumCotiza
                    frm.Show()
                    Exit Sub
                End If
            End If
        End If

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

        If btnSigFase.Enabled = True Then
            grProductos.Columns("colCodigoInventario").ReadOnly = False
        Else
            grProductos.Columns("colCodigoInventario").ReadOnly = True
        End If



    End Sub



    Private Sub CargarCotizacion(ByVal mNumCotizacion As Integer)
        Try

            Dim Cotiza As Integer = mNumCotizacion
            Dim objCntv As New clConectividad, fF As Integer
            Dim strConsulta As String = "Select "

            'CARGA LA CABECERA
            Dim drCabCotiza As MSSQL.SqlDataReader = _
              objCntv.LeerValor("*", "CabCotizacion", "Tipo<>'OT' and NumCotizacion =" & mNumCotizacion, strCadena)
            'objCntv.LeerValor("*", "CabCotizacion", "NumCotizacion =" & mNumCotizacion & " and estado<>'I'", strCadena)

            'ONYX - LIMPIEZA DE CAMPOS DE REQUERIMIENTO
            mReqID = 0
            cmbRequerimientos.Text = "" : lblDescReq.Text = ""
            txtOC_Cliente.Text = ""


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
            mReqID = IIf(drCabCotiza.Item("Req_Id").ToString = "", 0, drCabCotiza.Item("Req_Id").ToString)
            txtOC_Cliente.Text = drCabCotiza.Item("OC_Cliente").ToString
            mTipoCot = drCabCotiza.Item("Tipo").ToString

            If drCabCotiza.Item("Tipo").ToString = "CR" Then
                stTipoOrigen.Text = "VENTA DIRECTA"
            Else
                stTipoOrigen.Text = "COTIZACION NORMAL"
            End If


            If drCabCotiza.Item("AIU_MO").ToString = "" Then
              txtAIU_MO.Text = 0
            Else
              txtAIU_MO.Text = CInt(drCabCotiza.Item("AIU_MO").ToString)
            End If
            'txtAIU_MO.Text = IIf(drCabCotiza.Item("AIU_MO").ToString = "", 0, CInt(drCabCotiza.Item("AIU_MO").ToString))

            'El requerimiento
            If mReqID <> 0 Then
              Dim drReq As MSSQL.SqlDataReader = _
                objCntv.LeerValor("*", "VW_Requerimientos", "id =" & mReqID.ToString, strCadena)
              cmbRequerimientos.Text = drReq.Item("NumReq").ToString
              lblDescReq.Text = drReq.Item("DescReq").ToString
            End If

            'marzo 22 2016 
            Label28.Text = stNumCotizacion.Text

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
              objCntv.LeerValor("*", "DetCotizacion", "Cab_ID =" & drCabCotiza.Item("id").ToString & " and tipo in (1,2) and estado<>'I' order by id", strCadena)

            Dim mAdicionar As Boolean = True, mCalcular As Boolean = True

            'If mModoLiquidacionVentaDirecta Then mAdicionar = False

            Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
                If drDetCotiza.HasRows = True Then
                    Dim strFilaNueva() As String

                    If drDetCotiza.Item("Tipo").ToString = "1" Then
                        strFilaNueva = {grProductos.Rows.Count + 1,
                                        drDetCotiza.Item("Inventario_ID").ToString,
                                        drDetCotiza.Item("CodInventario").ToString,
                                        CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                        CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                        CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                        drDetCotiza.Item("DescItem").ToString,
                                        mAdicionar, mCalcular}
                        grProductos.Rows.Add(strFilaNueva)
                    ElseIf drDetCotiza.Item("Tipo").ToString = "5" Then
                        strFilaNueva = {grTipoGastos.Rows.Count + 1,
                                        drDetCotiza.Item("CodInventario").ToString,
                                        CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                        mAdicionar}
                    Else
                        strFilaNueva = {grEmpleados.Rows.Count + 1,
                                        drDetCotiza.Item("Inventario_ID").ToString,
                                        drDetCotiza.Item("CodInventario").ToString,
                                        CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                        CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                        CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                        drDetCotiza.Item("DescItem").ToString,
                                        mAdicionar, mCalcular}
                        '(drDetCotiza.Item("Cant").ToString * drDetCotiza.Item("Costo").ToString).ToString(FCTOTOT),
                        grEmpleados.Rows.Add(strFilaNueva)
                    End If
                End If

            Loop While drDetCotiza.Read()

            Call Calcular()

            'CARGO TODOS LOS ANEXOS
            Call CargaAnexos(mId.ToString)

            ''CARGO LOS ANEXOS ****************************************************************************
            'Dim drAnexos As MSSQL.SqlDataReader


            'mTablaAnexos = Nothing
            'mTablaAnexos = CreaTablaAnexos()
            'drAnexos = objCntv.LeerValor("*", "AnexosCotizacion", "Cab_ID =" & mId.ToString & " and estado='A'", strCadena)
            'lstAnexos.Items.Clear() : mVctAnexos.Clear()

            'Do
            '    If drAnexos.HasRows = True Then
            '        lstAnexos.Items.Add(IO.Path.GetFileName(drAnexos.Item("RutaArchivo").ToString), True)
            '        mVctAnexos.Add(drAnexos.Item("RutaArchivo").ToString)

            '        Dim mFila As DataRow = mTablaAnexos.NewRow
            '        mFila.Item("id") = drAnexos.Item("id")
            '        mFila.Item("RutaArchivo") = drAnexos.Item("RutaArchivo")
            '        mFila.Item("NombreArchivo") = IO.Path.GetFileName(drAnexos.Item("RutaArchivo"))
            '        mFila.Item("Estado") = drAnexos.Item("Estado")
            '        mTablaAnexos.Rows.Add(mFila)
            '    End If
            'Loop While drAnexos.Read()

            'If UCase(objCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarAnexoInicio'", My.Settings.cnnModProd)) = "SI" Then
            '  If lstAnexos.Items.Count > 0 Then
            '      Call CargaImagen(mVctAnexos(1).ToString, False)
            '  End If
            'End If




            'EG: ONYX, adicion de pestaña de reporte de estados
            Dim dtEstadosCotizacion As Data.DataTable = objCntv.LlenarDataTable(strCadena, "FECHA, USUARIO, TITULO", "vw_EstadosCotizacion", "Cab_ID =" & mId.ToString)
            grEventos.DataSource = dtEstadosCotizacion
            grEventos.Columns(0).Width = 150 : grEventos.Columns(1).Width = 150






            'LOS ESTADOS DE LA ORDEN
            Dim drEstadosCotiza As MSSQL.SqlDataReader = _
              objCntv.LeerValor("*", "vw_EstadosCotizacion", "Cab_ID =" & mId.ToString, strCadena)
            Dim mMaxEstado As Integer

            Dim jj As Integer
            For jj = 0 To 5 'ONYX 20190519
                chkListEstados.SetItemCheckState(jj, CheckState.Unchecked)
            Next

            imgAnulada.Visible = False
            Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
                'chkListEstados.SetItemChecked(drEstadosCotiza("id") - 1, True)

                'ONYX - 20180521 - MANEJO DE ANULADA
                If drEstadosCotiza.Item("Id") <> 7 Then 'ONYX 20190519 Then
                    chkListEstados.SetItemChecked(drEstadosCotiza("id") - 1, True)
                Else
                    imgAnulada.Visible = True
                End If

                mMaxEstado = IIf(drEstadosCotiza("id") > mMaxEstado, drEstadosCotiza("id"), mMaxEstado)
                fF = fF + 1
            Loop While drEstadosCotiza.Read()


            'PONGO EN ORDEN LOS CONTROLES
            cmdActualizar.Enabled = True : btnAprobar.Enabled = True
            btnSigFase.Enabled = True

            'PARA HABILITAR O NO LA SIGUIENTE FASE
            Call HabilitarSiguienteFase()

            If mMaxEstado >= 4 Then 'ONYX 20190519Then
                cmdActualizar.Enabled = False
            End If

            If mMaxEstado = 6 Then 'ONYX 20190519 Then
                btnSigFase.Enabled = False
                cmdActualizar.Enabled = False
            End If

            If lblEstado.Text = "V" Then
                cmdActualizar.Enabled = False
                btnAprobar.Enabled = False
            End If

            If mModoLiquidacionVentaDirecta = False Then
                btnGrabar.Text = "Copiar " & mNumCotizacion.ToString()
            End If

            cmbCliente.Focus()
            mDocCargado = True

            'Modificado el 20150411. Se agrega el manejo de estados
            If drCabCotiza.Item("Estado").ToString = "I" Then
                ChkAnulada.CheckState = CheckState.Checked
                ChkAnulada.Enabled = False
                btnSigFase.Enabled = False
                cmdActualizar.Enabled = False
            Else
                ChkAnulada.CheckState = CheckState.Unchecked
                ChkAnulada.Enabled = True
            End If


            If mModoLiquidacionVentaDirecta = False Then
                Dim mBoton As Button = Me.Tag
                mBoton.Text = Me.Text & " " & mNumCotizacion.ToString
            End If

            chkListEstados.Visible = True

        Catch ex As System.InvalidCastException

        Catch ex As Exception
          Call ManejoError(Me.Name, "CargarCotizacion", ex)
          MessageBox.Show(ex.Message, ex.GetType.ToString, MessageBoxButtons.OK, MessageBoxIcon.Warning)
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



    'Private Sub btnAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click
    '    'El boton adjuntar, solamente carga el listado a subir
    '    'SE DEJA FILTRO DESDE ARCHIVO DE CONFIGURACION
    '    ofdCargarAdjuntos.Filter = My.Settings.FiltroAdjuntos  '"JPEG|*.jpg;*.jpeg;*.jpe;*.jfif"

    '    If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
    '        Dim strArchivo As String, Ff As Integer = 0
    '        Dim obAnexo As New clAnexos

    '        For Each strArchivo In ofdCargarAdjuntos.FileNames
    '            Dim mImagen As Image = obAnexo.RedimensionarImagen(strArchivo)

    '            lstAnexos.Items.Add(IO.Path.GetFileName(strArchivo), True)
    '            mVctAnexos.Add(strArchivo.ToString)

    '            'para controlar cuando se cargada la cotizacion
    '            'If mDocCargado = True Then
    '                Dim mFila As DataRow = mTablaAnexos.NewRow
    '                mFila.Item("id") = 0
    '                mFila.Item("RutaArchivo") = strArchivo.ToString
    '                mFila.Item("NombreArchivo") = IO.Path.GetFileName(IO.Path.GetFileName(strArchivo))
    '                mFila.Item("Estado") = "N"
    '                mTablaAnexos.Rows.Add(mFila)
    '            'End If
    '        Next

    '        If mVctAnexos.Count > 0 Then
    '            Call CargaImagen(mVctAnexos(1).ToString, False)
    '        End If

    '    End If
    'End Sub


    Private Sub btnAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click
        'El boton adjuntar, solamente carga el listado a subir
        'SE DEJA FILTRO DESDE ARCHIVO DE CONFIGURACION
        ofdCargarAdjuntos.Filter = My.Settings.FiltroAdjuntos  '"JPEG|*.jpg;*.jpeg;*.jpe;*.jfif"

        If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          stAnexos.Visible = True


            Dim strArchivo As String, Ff As Integer = 0
            Dim obAnexo As New clAnexos
            stAnexos.Maximum = ofdCargarAdjuntos.FileNames.Count + 1
            stAnexos.Value = 1

            For Each strArchivo In ofdCargarAdjuntos.FileNames
                'Cargo la imagen a usar redimensionada y la grabo en el folder temporal de la app
                'Dim mImagen As Image = obAnexo.RedimensionarImagen(strArchivo)
                'Dim mTempArchivo = My.Settings.OnyxTempFolder & "\" & IO.Path.GetFileName(strArchivo)
                'obAnexo.GrabarImagen(mImagen, mTempArchivo)

                Dim mImagen As Image, mTempArchivo As String

                mTempArchivo = My.Settings.OnyxTempFolder & "\" & mIdUnicoAnexo & "\" & IO.Path.GetFileName(strArchivo)
                If UCase(strArchivo).Contains(".PDF") = False Then
                  mImagen = obAnexo.RedimensionarImagen(strArchivo)
                  obAnexo.GrabarImagen(mImagen, mTempArchivo)
                Else
                  obAnexo.CopiarArchivo(strArchivo, mTempArchivo)

                End If

                lstAnexos.Items.Add(IO.Path.GetFileName(mTempArchivo), True)
                'lstAnexos.Items.Add(IO.Path.GetFileName(strArchivo), True)
                mVctAnexos.Add(mTempArchivo.ToString)

                'para controlar cuando se cargada la cotizacion
                'If mDocCargado = True Then
                    Dim mFila As DataRow = mTablaAnexos.NewRow
                    mFila.Item("id") = 0
                    mFila.Item("RutaArchivo") = mTempArchivo.ToString
                    mFila.Item("NombreArchivo") = mTempArchivo 'IO.Path.GetFileName(IO.Path.GetFileName(strArchivo))
                    mFila.Item("Estado") = "N"
                    mTablaAnexos.Rows.Add(mFila)
                'End If
                mImagen = Nothing
                stAnexos.Value = stAnexos.Value + 1
            Next

            obAnexo = Nothing

            If mVctAnexos.Count > 0 Then
                Call CargaImagen(mVctAnexos(1).ToString, False)
            End If

            stAnexos.Visible = False
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

    'Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
    '    Dim mImagen As Bitmap

    '    Try
    '      Dim obCntv As New clConectividad
    '      If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then

    '          If strImagen.Contains(".pdf") = True Then

    '            pdfVisor.src = strImagen
    '            pcbAnexos.Visible = False
    '            pdfVisor.Visible = True

    '          Else
    '              mImagen = New Bitmap(strImagen)
    '              pcbAnexos.Image = CType(mImagen, Image)
    '              pcbAnexos.Visible = True
    '              pdfVisor.Visible = False

    '            'End Using
    '          End If
    '      End If
    '        'Catch ex As Exception
    '    Catch ex As System.ArgumentException
    '        If blCargar = True Then
    '            Process.Start(strImagen).ToString()
    '        End If
    '    Catch ex As Exception
    '        Call ManejoError(Me.Name, "CargaImagen", ex)
    '        MessageBox.Show(ex.Message, ex.InnerException.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)

    '    End Try


    'End Sub

Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
    Try
        Dim obCntv As New clConectividad

        If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then
            If strImagen.Contains(".pdf") = True Then
                pdfVisor.src = strImagen
                pcbAnexos.Visible = False
                pdfVisor.Visible = True
            Else
                Using mImagen As New Bitmap(strImagen)
                    ' Redimensiona la imagen si es necesario
                    Dim obAnexo As New clAnexos
                    Dim imagenRedimensionada As Bitmap = obAnexo.RedimensionarImagen(mImagen, My.Settings.TmpMaxWidth, My.Settings.TmpMaxHeight) 'maxWidth, maxHeight) ' Reemplaza maxWidth y maxHeight con los tamaños deseados
                    pcbAnexos.Image = CType(imagenRedimensionada, Image)
                    pcbAnexos.Visible = True
                    pdfVisor.Visible = False
                    obAnexo = Nothing
                End Using
            End If
        End If
    Catch ex As System.ArgumentException
        If blCargar = True Then
            Process.Start(strImagen).ToString()
        End If
    Catch ex As Exception
        Call ManejoError(Me.Name, "CargaImagen", ex)
        MessageBox.Show(ex.Message, ex.InnerException.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try
End Sub

    Private Function GrabarAnexos(ByVal Cab_Id As String, ByVal mDocCargado As Boolean) As String
        Dim obCntv As New clConectividad
        Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=5", strCadena)
        Dim strMes As String = StrDup(2 - Len(Today.Month.ToString), "0") & Today.Month.ToString
        Dim strRutaCotiza As String

        If mNumCotiza = 0 Then
            strRutaCotiza = CrearGUID()
            mGuid = strRutaCotiza
        ElseIf mDocCargado = True Then
          strRutaCotiza = CrearGUID()
          mGuid = strRutaCotiza
        Else
            strRutaCotiza = mNumCotiza.ToString
        End If

        Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
        strRuta = strRuta & strRutaB
        If lstAnexos.CheckedItems.Count > 0 Then
            IO.Directory.CreateDirectory(strRuta)

        'ElseIf mDocCargado = True Then
         ' IO.Directory.CreateDirectory(strRuta)
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
        If lstAnexos.CheckedItems.Count > 0 Then
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

                    Dim strInsert As String = "insert AnexosCotizacion(Cab_id, RutaArchivo,mguid,Estado, usuario_id ) values (" & Cab_Id.ToString & ",'" _
                      & strDestino.ToString & "','" & mNumCotiza.ToString & "','A'," & mUsuarioId & ")"
                    obCntv.EjecutaComando(strInsert, strCadena, False)

                Catch ex As System.IO.DirectoryNotFoundException
                    IO.Directory.CreateDirectory(strRuta)
                    IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

                    Dim strInsert As String = "insert AnexosCotizacion(Cab_id, RutaArchivo,mguid,Estado, usuario_id ) values (" & Cab_Id.ToString & ",'" _
                      & strDestino.ToString & "','" & mNumCotiza.ToString & "','A'," & mUsuarioId & ")"
                    obCntv.EjecutaComando(strInsert, strCadena, False)

                Catch ex As System.IO.IOException
                  Dim _Mensaje As String = strRuta & vbCrLf & ex.Message & vbCrLf & ex.StackTrace
                  MessageBox.Show(_Mensaje, "Error de acceso a ruta para usuario: " & mUsuario, MessageBoxButtons.OK, MessageBoxIcon.Error)

                Catch ex As System.Exception
                  Call ManejoError(Me.Name, "ActualizarAnexos", ex)
                  MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message & vbCrLf & ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End Try

            End If
        Next

        Dim obAnexos As New clAnexos
        obAnexos.BorrarContenidoCarpeta(My.Settings.OnyxTempFolder)
        obAnexos = Nothing

    End Sub

    Private Sub txtPrecioFinal_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) _
      Handles txtPrecioFinal.LostFocus

        'sender.Text = FormatCurrency(sender.Text, 0)
        sender.Text = CDec(IIf(sender.Text = "", 0, sender.text)).ToString(FCTOTOT)

    End Sub




    Private Sub grProductos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
        Handles grProductos.CellEndEdit, grEmpleados.CellEndEdit

        Dim mGr As DataGridView = CType(sender, DataGridView)

        Select Case e.ColumnIndex
            Case 3, 4, 8
                Dim mCant As Decimal, mCosto As Decimal
                mCant = CDec(IIf(mGr.Rows(e.RowIndex).Cells(3).Value = "", 0, mGr.Rows(e.RowIndex).Cells(3).Value))
                mCosto = CDec(IIf(mGr.Rows(e.RowIndex).Cells(4).Value = "", 0, mGr.Rows(e.RowIndex).Cells(4).Value))
                mGr.Rows(e.RowIndex).Cells(5).Value = CDec(mCant * mCosto).ToString(FCTOTOT)


                mGr.Rows(e.RowIndex).Cells(3).Value = CDec(mCant).ToString(FCANT)
                mGr.Rows(e.RowIndex).Cells(4).Value = CDec(mCosto).ToString(FCTO_U)
                Call Calcular()
            Case 1
                Call ValidaMaterial(mGr.Rows(e.RowIndex).Cells("colCodigoInventario").Value, e.RowIndex)

        End Select
    End Sub


    Private Function TxtADec(ByVal strTxt As String) As Decimal
        TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
    End Function

    Private Sub txtAIU_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAIU_MO.LostFocus, txtAIU.LostFocus
        Call Calcular()
    End Sub

    Private Sub GrabarCheckList(ByVal mCab_Id As Integer)
        'Dim obCalc As New clCalculadora, Ff As Integer

        'For Ff = 0 To chkCheckListCotizacion.Items.Count - 1
        '    Dim Valor As Boolean = CBool(chkCheckListCotizacion.GetItemCheckState(Ff))
        '    obCalc.GrabarCheckListCotizacion(strCadena, mCab_Id, mTblCheckList.Rows(Ff).Item("Id").ToString, Valor, Now)
        'Next


    End Sub

    Private Sub ActualizarCheckList(ByVal mCab_Id As Integer)
        'Dim obCalc As New clCalculadora, Ff As Integer

        'For Ff = 0 To chkCheckListCotizacion.Items.Count - 1
        '    Dim Valor As Integer = IIf(chkCheckListCotizacion.GetItemCheckState(Ff) = CheckState.Checked, 1, 0)
        '    'obCalc.ActualizarCheckListCotizacion(strCadena, mTblCheckList.Rows(Ff).Item("id").ToString, Valor, Now)
        '    obCalc.ActualizarCheckListCotizacion(strCadena, mTblCheckList.Rows(Ff).Item("chkLisCot_Id").ToString, Valor, Now)

        'Next
    End Sub



    Private Sub ValidaMaterial(ByVal strCodInventario As String, ByVal Ff As Integer)
        Dim obCntv As New clConectividad

        Dim mProducto As String = ""
        Dim strWhere As String = "codinventario ='" & strCodInventario & "'"

        mProducto = obCntv.LeerValorSencillo("NombreZiur", "vw_ProductosZiurMP", strWhere, strCadena)

        If mProducto <> "" Then
            grProductos.Rows(Ff).Cells("colCodigoInventario").Value = UCase(strCodInventario)
            grProductos.Rows(Ff).Cells("colDescripcion").Value = UCase(mProducto)

            If btnSigFase.Enabled = True And cmdActualizar.Enabled = False Then
                btnGrabaMPNueva.Visible = True

            End If
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

    Private Sub EstableceModoColumnas(ByVal grGrilla As DataGridView)

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


    

    Private Sub ChkAnulada_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkAnulada.CheckedChanged
        'If btnSigFase.Enabled = True Then

        If ChkAnulada.CheckState = CheckState.Checked Then
            btnSigFase.Tag = CInt(btnSigFase.Enabled)
            btnSigFase.Enabled = False
        Else
            If btnSigFase.Tag = -1 Then
                btnSigFase.Enabled = True
            End If
        End If
        'End If
    End Sub

    Private Sub txtAlcance_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtAlcance.KeyDown, _
      txtProyecto.KeyDown, txtObservacion.KeyDown, txtObsInterna.KeyDown

        Dim strTexto As String, Inicio As Integer

        strTexto = sender.SelectedText
        Inicio = sender.SelectionStart

        If e.KeyCode = Keys.Up AndAlso e.Modifiers = Keys.Alt Then
            sender.SelectedText = sender.SelectedText.ToUpper
        ElseIf e.KeyCode = Keys.Down AndAlso e.Modifiers = Keys.Alt Then
            sender.SelectedText = sender.SelectedText.ToLower
        End If

        sender.SelectionStart = Inicio : sender.SelectionLength = Len(strTexto)

    End Sub

    Private Sub chkMostrarClaves_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMostrarClaves.CheckedChanged
        If chkMostrarClaves.Checked = True Then
            txtUtilidad.PasswordChar = ""
            txtAIU.PasswordChar = ""
            txtAIU_MO.PasswordChar = ""
        Else
            txtUtilidad.PasswordChar = "*"
            txtAIU.PasswordChar = "*"
            txtAIU_MO.PasswordChar = "*"
        End If


    End Sub

    Private Function LeerEtqTextoXml(mEtiqueta As String) As String
        Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim obXml As New clManejoXML

        obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiCot.xml")
        obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

        LeerEtqTextoXml = obXml.LeerValor(mEtiqueta)
        obXml = Nothing

    End Function


    Private Sub NombrarBotones()
        Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim obXml As New clManejoXML

        obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiCot.xml")
        obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"


        chkVentaDirecta.Text = obXml.LeerValor("chkVentaDirecta")
        chkMontaje.Text = obXml.LeerValor("chkMontaje")
        btnSigFase.Text = obXml.LeerValor("btnSigFase")
        btnGrabar.Text = obXml.LeerValor("btnGrabar")
        btnAprobar.Text = obXml.LeerValor("btnAprobar")
        btnImprimir.Text = obXml.LeerValor("btnImprimir")
        btnAdicionarMO.Text = obXml.LeerValor("btnAdicionarMO")
        btnAnexos.Text = obXml.LeerValor("btnAnexos")
        tbcContenido.TabPages(3).Text = obXml.LeerValor("etqEventos")
        lblReq.Text = obXml.LeerValor("lblReq")
        lblContrato.Text = obXml.LeerValor("lblContrato")
        txtCntAFabricar.Text = obXml.LeerValor("CantByDefault")

        obXml = Nothing

        'btnGrabar.Visible = True
        'cmdCargar.Visible = True
        'btnAprobar.Visible = False
        'btnSigFase.Visible = True
        'btnImprimir.Visible = True
        'cmdActualizar.Visible = True
        'Button1.Visible = False
        'btnCalcular.Visible = True
        'If mTipoCot = "CR" Then
        '    chkListEstados.Visible = False
        'End If

    End Sub




    Private Sub cmbRequerimientos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbRequerimientos.SelectedIndexChanged
        Dim selectedItem As DataRowView
        selectedItem = cmbRequerimientos.SelectedItem

        mReqID = selectedItem("id").ToString
        lblDescReq.Text = selectedItem("DescReq").ToString  'mReqID

    End Sub



    Private Sub cmbContrato_Id_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbContrato_Id.SelectedIndexChanged
        Dim selectedItem As DataRowView

        intContrato_Id = 0
        selectedItem = cmbContrato_Id.SelectedItem
        intContrato_Id = selectedItem("id").ToString

    End Sub

    Private Sub CargaContratos(Cliente_Id As Integer)
        Dim obCntv As New clConectividad

        cmbContrato_Id.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_ContratosCliente", "idCliente in(0," & Cliente_Id.ToString & ")", "Order by id")
        cmbContrato_Id.DisplayMember = "TextoMostrar"

        'ONYX
        lblDescReq.Text = ""
        cmbRequerimientos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "VW_Requerimientos", "tipo='C' and Atendido=0 and id in (0," & Cliente_Id.ToString & ")", "Order by NumReq")
        cmbRequerimientos.DisplayMember = "NumReq"

        obCntv = Nothing

    End Sub

    Private Sub chkMontaje_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMontaje.CheckedChanged

        grTipoGastos.Visible = chkMontaje.Checked

        If chkMontaje.Checked = True Then
            grpOtros.Height = 358
            pnlTotaltes.Top = 365
        Else
            grpOtros.Height = 175 '165
            pnlTotaltes.Top = 174

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

    Private Sub ManejoError(mFrm As String, mSub As String, mErr As Exception)
        Dim obLog As New clLog
        obLog.NombreArchivo = Application.StartupPath & "\ModProdLog.txt"
        obLog.EscribirLog("/------- INICIO EVENTO -----------------------------------------------------------------------------------/")
        obLog.EscribirLog("Error en " & mFrm & ": Sub " & mSub & ":")
        obLog.EscribirLog(mErr.Message)
        obLog.EscribirLog(mErr.StackTrace)
        obLog.EscribirLog("/------- FIN EVENTO -----------------------------------------------------------------------------------/")
        obLog.EscribirLog("")

        obLog = Nothing
    End Sub


    Private Sub EstablecerModoLiquidacionVentaDirecta()

        Me.Text = "Liquidación OT por Venta Directa"

        Call CargarCotizacion(mNumCotiza)
        Call EstableceModoColumnas(grProductos)
        Call EstableceModoColumnas(grEmpleados)
        strEstado.Text = ""
        strEstado.Visible = False
        Me.Cursor = Cursors.Default
        txtAIU.PasswordChar = "*"
        txtAIU_MO.PasswordChar = "*"
        txtUtilidad.PasswordChar = "*"

        btnGrabar.Visible = False  'True
        cmdCargar.Visible = False
        btnAprobar.Visible = False
        btnSigFase.Visible = False
        btnImprimir.Visible = False
        cmdActualizar.Visible = True : cmdActualizar.Enabled = True
        Button1.Visible = False
        btnCalcular.Visible = True
        btnCalcular.Enabled = True
        grProductos.ReadOnly = True

        'SE PERMITE ADICIONAR MATERIAL POR PARTE DE OSCAR JUNCA, O SU ROL
        'btnAdicionar.Enabled = False
        'btnAdicionarMO.Enabled = False
        txtProyecto.ReadOnly = True
        txtAlcance.ReadOnly = True
        cmbAsignadaA.Enabled = False
        cmbCliente.Enabled = False
        chkListEstados.Visible = False

    End Sub

    Private Sub OcultarBotonesVentaDirecta()
        'btnGrabar.Visible = False
        cmdCargar.Visible = True
        btnAprobar.Visible = False
        btnSigFase.Visible = False
        btnImprimir.Visible = False
        cmdActualizar.Visible = False
        Button1.Visible = False
        btnCalcular.Visible = False
        chkListEstados.Visible = False

        stTipoOrigen.Text = stTipoOrigen.Text & " - SOLO LECTURA"

    End Sub


    Private Sub EstadoInicialBotones()
        btnGrabar.Visible = True
        cmdCargar.Visible = True
        btnAprobar.Visible = False
        btnSigFase.Visible = True
        btnImprimir.Visible = True
        cmdActualizar.Visible = True
        Button1.Visible = False
        btnCalcular.Visible = True
        If mTipoCot = "CR" Then
            chkListEstados.Visible = False
        End If


    End Sub


  Private Sub grEndEditMode(sender As System.Object, e As System.EventArgs) Handles grProductos.CurrentCellDirtyStateChanged, grEmpleados.CurrentCellDirtyStateChanged
    Dim mGr As DataGridView = CType(sender, DataGridView)

   'if current cell of grid is dirty, commits edit
      If mGr.IsCurrentCellDirty Then
          mGr.CommitEdit(DataGridViewDataErrorContexts.Commit)
      End If
  End Sub

  Private Sub grDataGridCellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellValueChanged, grEmpleados.CellValueChanged
    Dim mGr As DataGridView = CType(sender, DataGridView)

    'check that row isn't -1, i.e. creating datagrid header
    If e.RowIndex = -1 Then Exit Sub

     Select Case e.ColumnIndex
            Case 7, 8
              Call Calcular()

        End Select

  End Sub

  Private Sub CargaAnexos(ByVal mCabId As Integer, Optional ByVal mRolId As String = "%")
    'CARGO LOS ANEXOS ****************************************************************************
    Dim drAnexos As MSSQL.SqlDataReader
    Dim objCntv As New clConectividad

    objCntv.CadenaDeConeccion = My.Settings.cnnModProd
    mTablaAnexos = Nothing
    mTablaAnexos = CreaTablaAnexos()
    drAnexos = objCntv.LeerValor("*", "VW_AnexosCotizacion", "Cab_ID =" & mId.ToString _
      & " AND CONVERT(VARCHAR(2), Rol_id) like '" & mRolId & "' and estado='A'", strCadena)
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

    If UCase(objCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarAnexoInicio'", My.Settings.cnnModProd)) = "SI" Then
      If lstAnexos.Items.Count > 0 Then
        Call CargaImagen(mVctAnexos(1).ToString, False)
      End If
    End If

    objCntv = Nothing
  End Sub


End Class



