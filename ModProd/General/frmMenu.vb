Imports System.Configuration
'Imports ModProdVER = System.Version

Public Class frmMenu
  Private mUsuario_Id As Integer
  Private strCadena As String

  'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCrearOrden.Click
  '  Dim Frm As New frmOT  'frmCrearOrden

  '  Frm.Show()
  'End Sub

  Private Sub btnAsignarAlArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarAlArea.Click
    Dim Frm As New frmAsignarAlArea

    Frm.Show()
  End Sub

  Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim Frm As New frmReporte
    Frm.Show()
  End Sub

  Private Sub btnEntregarResumen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntregarResumen.Click
    Dim Frm As New frmEntregarResumen
    Frm.Show()

  End Sub

  Private Sub btnCerrarOrden_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarOrden.Click
    Dim Frm As New frmCerrarOrden

    Frm.Show()
  End Sub

  Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Dim Frm As New frmRptOrdenes

    Frm.Show()

  End Sub

  Private Sub cmdEntregasArea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEntregasArea.Click
    Dim Frm As New frmRptEntregasArea

    Frm.Show()
  End Sub

  Private Sub frmMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()

    imgLogo.Image = Image.FromFile(strRutaApp & "\img\" & My.Settings.NombreLogoMenu)
    stUsuario.Text = Environment.UserName '& Environment.UserName.GetHashCode
    stDominio.Text = Environment.UserDomainName

    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    Call ValidaUsuario(stDominio.Text, stUsuario.Text)
    Call NombrarBotones()

    stVersion.Text = LeerVersion()

    'ONYX - Inicio de notificaciones
    'HABILITAR CON SALIDA A PRODUCCION DE MODULO DE PRODUCCION
    'IniciarNotificaciones()

  End Sub

  Private Sub btnSimulador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimulador.Click
    Dim frm As New frmSimulador
    frm.Show()
  End Sub

  Private Sub ValidaUsuario(ByVal Dominio As String, ByVal Usuario As String)
    Dim obCntv As New clConectividad

    Dim EsAdmin As Boolean, strWhere As String, strEsAdmin As String

    'PARTE PARA VERIFICAR QUE EL MODULO ESTA ACTUALIZADO
    Dim VersionServidor As String = obCntv.LeerValorSencillo("Valor", "parametros", "id=7", strCadena)

    If VersionServidor <> LeerVersion() Then
      MessageBox.Show("Debe actualizar la Versión de ModProd" & vbCrLf & "Comuniquese con el administrador del sistema.", _
        "ModProd Desactualizado", MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    Else
      Dim strComando As String
      strComando = "exec pa_UsuarioActualizado '" & Dominio & "', '" & Usuario & "'"
      obCntv.EjecutaComando(strComando, strCadena, False)
    End If


    strWhere = "dominio='" & Dominio & "' and usuario='" & Usuario & "' and estado='A'"
    strEsAdmin = obCntv.LeerValorSencillo("EsAdmin", "Usuarios", strWhere, strCadena)
    mUsuario_Id = obCntv.LeerValorSencillo("Id", "Usuarios", strWhere, strCadena)


    If strEsAdmin = "" Then
      EsAdmin = False
      MessageBox.Show("Usuario " & Dominio & "\" & Usuario & " no autorizado!" & vbCrLf & " Comuníquese con el administrador del sistema", "ModProd - Error de autorización", _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    Else
      EsAdmin = CBool(strEsAdmin) ' True
    End If

    'EsAdmin = obCntv.LeerValorSencillo("EsAdmin", "Usuarios", strWhere, strCadena)

    If EsAdmin = True Then
      btnAgregarMP.Visible = True
      btnCrearPT.Visible = True
      btnMntCostos.Visible = True
      btnCambiaEstadoCot.Visible = True
    End If

    obCntv = Nothing
  End Sub

  Private Sub btnAgregarMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarMP.Click
    Dim frm As New frmAgregarMP

    frm.Show()
  End Sub

  Private Sub btnCotizaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCotizaciones.Click
    Dim Frm As New frmRptCotizacion
    Frm.mTipoReporte = frmRptCotizacion.enTiposReporte.Normal
    Frm.Show()

  End Sub

  Private Function LeerVersion() As String
    Dim mVer As New System.Version

        LeerVersion = "2.0.0.0" 'mVer.Major.ToString & "." & mVer.Minor.ToString & "." & mVer.Revision.ToString
  End Function

  Private Sub btnCrearPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearPT.Click
    Try

      Dim mNumCotiza As Integer = InputBox("Cotización")
      'Call CargarCotizacion(Cotiza)
      'cmdCrearPT.Visible = True

      Select Case ExistePTporCotizacion(mNumCotiza)
        Case 1
          Dim strMensaje As String
          strMensaje = "Cotización no ha sido Aprobada por el Cliente!" & vbCrLf & vbCrLf & "No se puede continuar."

          MessageBox.Show(strMensaje, "Creación de PT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
          Exit Sub

        Case 2
          Dim strMensaje As String
          strMensaje = "Ya existen productos terminados en Ziur para esta Cotización." & vbCrLf & vbCrLf & "Desea continuar?"

          If MessageBox.Show(strMensaje, "Creación de PT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
            Exit Sub
          End If
      End Select

      'If ExistePTporCotizacion(mNumCotiza) = True Then
      '  Dim strMensaje As String
      '  strMensaje = "Ya existen productos terminados en Ziur para esta Cotización." & vbCrLf & vbCrLf & "Desea continuar?"

      '  If MessageBox.Show(strMensaje, "Creación de PT", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
      '    Exit Sub
      '  End If
      'End If


      Dim Frm As New frmCrearPT
      Frm.mNumCotizacion = mNumCotiza
      Frm.ShowDialog(Me)


    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try

  End Sub

  Private Function ExistePTporCotizacion(ByVal mNumCotizacion As Integer) As Integer
    Dim obCntv As New clConectividad
    Dim strCab_ID As Integer = obCntv.LeerValorSencillo("ID", "CabCotizacion", "NumCotizacion = " & mNumCotizacion.ToString, strCadena)
    Dim strResultado As String = obCntv.LeerValorSencillo("COUNT(1) [Cantidad]", "Cantidad", "PTporCotizacion", "Cab_id = " & strCab_ID.ToString, strCadena)
    Dim strEstado As String = obCntv.LeerValorSencillo("Estado", "CabCotizacion", "NumCotizacion = " & mNumCotizacion.ToString, strCadena)

    ExistePTporCotizacion = 0

    If strEstado <> "A" Then
      ExistePTporCotizacion = 1
      Exit Function
    End If

    If CInt(strResultado) > 0 Then
      ExistePTporCotizacion = 2
    Else
      ExistePTporCotizacion = 0
    End If
  End Function

  
 

  Private Sub btnRptCostosMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptCostosMP.Click
    Dim Frm As New frmRptCostosMP

    Frm.Show()

  End Sub

  Private Sub btnMntCostos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMntCostos.Click
    Dim Frm As New frmCostosMP

    Frm.Show()
  End Sub

  Private Sub btnMntoMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMntoMO.Click
    Dim Frm As New frmMtoAreasPlanta
    Frm.strConexion = strCadena

    Frm.Show()
  End Sub

  Private Sub cmdMpYaCreada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMpYaCreada.Click

    Dim Frm As New frmMntMPNoCreada
    'Frm.strCadena = strCadena
    Frm.Show()

  End Sub

  Private Sub btnResponsables_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResponsables.Click
    Dim Frm As New frmMntResponsables
    Frm.Show()
  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim frm As New frmSimuladorRapida
    frm.Show()

  End Sub

  Private Sub btnBoletas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoletas.Click
    Dim frm As New frmImpBoletas
    frm.Show()

  End Sub

  'Private Sub btnAjustarMaterialesOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPedirMaterialesOT.Click
  '  Dim frm As New frmProductosOT_V2
  '  Dim mNumOT As Integer
  '  Try

  '    Dim Cotiza As Integer
  '    mNumOT = InputBox("Orden de Trabajo", "Carga OT")

  '    If mNumOT <> vbEmpty Then
  '      Dim obCntv As New clConectividad
  '      Cotiza = obCntv.LeerValorSencillo("NumCotizacion", "vw_CotizacionOT", "EstadoOT='M' and NumOrden=" & mNumOT, My.Settings.cnnModProd)

  '      'Cotiza = InputBox("Cotizacion", "Carga Cotización")
  '      frm.NumCotizacionOriginal = Cotiza
  '      frm.NumeroOT = mNumOT
  '      frm.Show()

  '      obCntv = Nothing
  '    End If
  '  Catch ex As System.InvalidCastException
  '    'Me.Close()
  '    If mNumOT <> vbEmpty Then
  '      MessageBox.Show("OT no existe o no esta en fase de ajuste de materiales!", "No se puede cargar", MessageBoxButtons.OK, MessageBoxIcon.Error)
  '    End If
  '  Catch ex As Exception
  '    MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  '  End Try
  'End Sub

  Private Sub btnOrdenCompra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrdenCompra.Click
    Dim frm As New frmOrdenCompra
    frm.Usuario_Id = mUsuario_Id
    frm.Show()
  End Sub


  Private Sub NombrarBotones()
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
    Dim obXml As New clManejoXML

    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUi.xml")

    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"
    TabControl1.TabPages("tbpProduccion").Text = obXml.LeerValor("etqTran")
    TabControl1.TabPages("tbpReportes").Text = obXml.LeerValor("etqRpt")
    TabControl1.TabPages("tbpComercial").Text = obXml.LeerValor("etqCalcCom")
    TabControl1.TabPages("tbpMto").Text = obXml.LeerValor("etqMnt")

    cmdCrearOrden.Text = obXml.LeerValor("TranBtn01")
    btnAsignarAlArea.Text = obXml.LeerValor("TranBtn02")
    btnEntregarResumen.Text = obXml.LeerValor("TranBtn03")
    btnCerrarOrden.Text = obXml.LeerValor("TranBtn04")
    btnAgregarMP.Text = obXml.LeerValor("TranBtn05")

    cmdEntregasArea.Text = obXml.LeerValor("RptBtn02")
    btnCotizaciones.Text = obXml.LeerValor("RptBtn03")

    btnSimulador.Text = obXml.LeerValor("CalcComBtn01")
    btnCambiaEstadoCot.Text = obXml.LeerValor("BtnCambiaEstadosCot")


    btnCrearPT.Text = obXml.LeerValor("MntBtn01")
    btnContratos.Text = obXml.LeerValor("btnContratos")

    btnRptCotAGerencia.Text = obXml.LeerValor("btnRptCotAGerencia")


    

    Me.PictureBox1.Image = My.Resources.NuevaMarca




  End Sub

'Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
'    Dim frm As New frmNuevoMenu

'    frm.Show()


'End Sub

Private Sub btnCambiaEstadoCot_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiaEstadoCot.Click
    Dim frm As New frmCambiaEstadosCot
    frm.mUsuario_Id = mUsuario_Id
    frm.Show()

End Sub

Private Sub btnContratos_Click(sender As System.Object, e As System.EventArgs) Handles btnContratos.Click
    Dim frm As New frmMtoContratos
    frm.mUsuario_Id = mUsuario_Id
    frm.Show()
End Sub

Private Sub btnRptCotAGerencia_Click(sender As System.Object, e As System.EventArgs) Handles btnRptCotAGerencia.Click
    Dim Frm As New frmRptCotizacion
    Frm.mTipoReporte = frmRptCotizacion.enTiposReporte.A_Gerencia
    Frm.Show()
End Sub

Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
    'Dim Frm As New frmBuscar

    'Frm.Text = "Buscar OT"
    'Frm.lblDoc.Text = "Numero OT" : Frm.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    'Frm.txtDocumento.MaxLength = 10

    'Frm.chkTexto.Text = "Alcance"
    'Frm.chkFechas.Text = "Fecha   "
    'Frm.chkTercero.Text = "Cliente  "

    'Frm.txtTexto.Tag = "Alcance"
    'Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
    'Frm.cmbTercero.Tag = "NombreCliente"

    'Frm.strConsultaSQL = "vw_buscarOT" : Frm.strCamposSQL = "*"

    'frm.ShowDialog()


    'Dim dtConsulta As DataTable

    'If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
    '  dtConsulta = Frm.dtSeleccionado.Copy
    'End If

    'Frm.Dispose()

  'Call IniciarNotificaciones()


End Sub

Private Sub IniciarNotificaciones()
    Dim frm As New frmNotifica
    frm.Show()
    frm.WindowState = FormWindowState.Minimized
    frm.Hide()

End Sub

  'Private Sub btnAjustarMaterialesOT_Click_1(sender As System.Object, e As System.EventArgs) Handles btnAjustarMaterialesOT.Click
  '  Dim frm As New frmAjustarCotizacion
  '  'frm.mUsuario_Id = mUsuario_Id
  '  frm.Show()

  'End Sub
End Class