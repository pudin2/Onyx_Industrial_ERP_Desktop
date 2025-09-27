Option Explicit On
  Imports System.Runtime.InteropServices
  Imports System.Configuration
  Imports System.Reflection

Public Class frmMenuWin10
  Private clcDezplazadosBtnComercial As New Collection
  Private clcDezplazadosBtnProduccion As New Collection
  Private mNumPestana As Integer = 1
  Private mUsuario_Id As Integer, mRol_Id As Integer
  Private strCadena As String



    <DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    Private Shared Sub ReleaseCapture()
    End Sub

    <DllImport("user32.DLL", EntryPoint:="SendMessage")>
    Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    End Sub

  Private Function LeerVersion() As String
    Dim mVer As New System.Version

    LeerVersion = "2.0.0.18" 'mVer.Major.ToString & "." & mVer.Minor.ToString & "." & mVer.Revision.ToString



      '  Dim assem As Assembly = Assembly.GetEntryAssembly()
      'Dim assemName As AssemblyName = assem.GetName()
      'Dim ver As Version = assemName.Version
      'Console.WriteLine("Application {0}, Version {1}", assemName.Name, ver.ToString())
  End Function



  Private Sub frmMenuWin10_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    'borro los temporales
    Dim obAnexos As New clAnexos
    obAnexos.BorrarContenidoCarpeta(My.Settings.OnyxTempFolder)


    Dim obLog As New clLog
    obLog.IniciarArchivo(Application.StartupPath & "\ModProdLog.txt")
    obLog = Nothing

    'Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    'iconRestaurar.Visible = True
    'iconMaximizar.Visible = False



    'LA PARTE DE CARGA BÁSICA DE MODPROD
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()

    Dim obInicio As New clSetUpInicio
    stUsuario.Text = obInicio.Usuario
    stDominio.Text = obInicio.Dominio
    obInicio = Nothing

    'EL ESQUEMA DE SEGURIDAD DEL MENU
    Call SeguridadMenu()

    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    Call ValidaUsuario(stDominio.Text, stUsuario.Text)
    'Call NombrarBotones()

    stVersion.Text = LeerVersion()

    If UCase(My.Settings.Notificar) = "SI" Then
      Call IniciarNotificaciones()
    End If

    Me.ToolTip1.SetToolTip(Me.imgLogo, My.Settings.cnnModProd)

    stAmbiente.Text = My.Settings.stAmbiente
    If My.Settings.stAmbiente <> "" Then
      lblAmbiente.Visible = True
      lblAmbiente.Text = My.Settings.stAmbiente

    End If

  End Sub


  Private Sub btnSlide_Click(sender As System.Object, e As System.EventArgs)
     If mnuVertical.Width = 255 Then
        mnuVertical.Width = 70
        'panelContenedor.Width = panelContenedor.Width + (255 - 70)
        'panelContenedor.Left = panelContenedor.Left - (255 - 70)

        'cierro los submenus
        submenuComercial.Visible = False
        submenuProduccion.Visible = False
        submenuReportes.Visible = False
        subMenuCompras.Visible = False
        subMenuInventario.Visible = False
      Else
        mnuVertical.Width = 255
        'panelContenedor.Width = panelContenedor.Width - (255 - 70)
        'panelContenedor.Left = panelContenedor.Left + (255 - 70)
      End If

  End Sub

  Private Sub iconCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Application.Exit()
  End Sub

  Private Sub iconMaximizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.Size = Screen.PrimaryScreen.WorkingArea.Size
    Me.Location = Screen.PrimaryScreen.WorkingArea.Location
    'iconRestaurar.Visible = True
    'iconMaximizar.Visible = False


  End Sub

  Private Sub iconRestaurar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Me.Size = New Size(1120, 570)
    'iconRestaurar.Visible = False
    'iconMaximizar.Visible = True
  End Sub

  Private Sub iconMinizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles icoMinimizar.Click
    Me.WindowState = FormWindowState.Minimized

  End Sub

  Private Sub barraTitulo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles mnuVertical.MouseDown, imgLogo.MouseDown
    ReleaseCapture()
    SendMessage(Me.Handle, &H112&, &HF012&, 0)
  End Sub


  Private Sub btnComercial_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComercial.Click
    submenuComercial.Visible = Not submenuComercial.Visible
  End Sub

  Private Sub btnReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReportes.Click
    submenuReportes.Visible = Not submenuReportes.Visible
  End Sub



  Private Sub TodosLosBotones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
  Handles btnCotizar.Click, btnContratos.Click, btnRegistroOT.Click, btnMateriales.Click, btnPedidos.Click, _
          btnRptCotizaciones.Click, btnActualizaPrecios.Click, btnCriterios.Click, btnOrdenCompra.Click, btnPedidoManual.Click, _
          btnMPNoCreada.Click, btnParametros.Click, btnValidarOrdenes.Click, btnRptCotAGerencia.Click, btnCambiaEstadoCotizacion.Click, _
          btnBorrarPedido.Click, btnRptPedidos.Click, btnMntoMO.Click, btnIngresoOC.Click, btnRptOT.Click, btnResumen.Click, _
          btnRemision.Click, btnResponsables.Click, btnReversaEstadosOT.Click, btnControlImpresion.Click, btnValidarOT.Click, _
          btnConResumen.Click, btnValidacionRes.Click, btnLiberaPedidoAlmacen.Click, BtnOperarios.Click, btnMtoPedidos.Click, _
          btnMtoOrdenCompra.Click, btnDividirOT.Click, BtnProgramador.Click, btnRptSubTareas.Click, btnRptSubTareasGeneral.Click, _
          btnRegistroMov.Click, btnGastosMontaje.Click, btnRptNotificar.Click


    submenuComercial.Visible = False

    Select Case sender.name
      Case "btnCotizar"
        Dim frm As New frmSimulador

        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized


      Case "btnContratos"
        Dim frm As New frmMtoContratos

        AbrirFormInPanel(frm)
        frm.mUsuario_Id = mUsuario_Id
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnCambiaEstadoCotizacion"
        Dim frm As New frmCambiaEstadosCot

        frm.mUsuario_Id = mUsuario_Id
        frm.Text = "Estados Cotización"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnRegistroOT"
        submenuProduccion.Visible = False
        Dim frm As New frmOrdenDeTrabajo  'frmOT

        AbrirFormInPanel(frm)
        frm.Text = "Registro OT"
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnMateriales"
        Call CargarOTConBuscar()


      Case "btnValidacionRes"
        subMenuCompras.Visible = False
        Dim frm As New frmValidacionRemision

        frm.Usuario_Id = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnPedidos"
        Dim frm As New frmPedidos
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized
        frm.FormatoItemsCotizados()

      Case "btnRptCotizaciones"
        submenuReportes.Visible = False
        Dim Frm As New frmRptCotizacion
        Frm.mTipoReporte = frmRptCotizacion.enTiposReporte.Normal

        AbrirFormInPanel(Frm)
        Frm.Show() : Frm.WindowState = FormWindowState.Maximized

      Case "btnRptCotAGerencia"
        submenuReportes.Visible = False
        Dim Frm As New frmRptCotizacion
        Frm.mTipoReporte = frmRptCotizacion.enTiposReporte.A_Gerencia

        AbrirFormInPanel(Frm)
        Frm.Show() : Frm.WindowState = FormWindowState.Maximized

      Case "btnRptPedidos"
        submenuReportes.Visible = False
        Dim Frm As New frmRptPedidos
        AbrirFormInPanel(Frm)
        Frm.Show() : Frm.WindowState = FormWindowState.Maximized

      Case "btnActualizaPrecios"
        subMenuCompras.Visible = False
        Dim frm As New frmActualizaPrecios
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnCriterios"
        subMenuCompras.Visible = False
        Dim frm As New frmComparativoCompras
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnOrdenCompra"
        subMenuCompras.Visible = False
        Dim frm As New frmOrdenCompra
        frm.Usuario_Id = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.chkAnular.Visible = True
        frm.ModoPrograma = "REGISTRAR"
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnPedidoManual"
        subMenuCompras.Visible = False
        Dim frm As New frmPedidoManual

        'frm.Rol_Id = mRol_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnValidarOrdenes"
        subMenuCompras.Visible = False
        Dim frm As New frmOrdenCompra
        AbrirFormInPanel(frm)
        frm.btnAprobar.Visible = True : frm.btnActualizar.Visible = False
        frm.Text = "Aprobar Orden de Compra"
        frm.ModoPrograma = "VALIDAR"
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnMPNoCreada"
        subMenuMto.Visible = False
        Dim frm As New frmMntMPNoCreada
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnParametros"
        subMenuMto.Visible = False
        Dim frm As New frmMtoParametros
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnBorrarPedido"
        subMenuCompras.Visible = False
        Dim frm As New frmPedidos
        AbrirFormInPanel(frm)
        Call frm.PantallaAdminCompras()
        frm.Text = "Eliminar Pedidos"
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnMntoMO"
        subMenuCompras.Visible = False
        Dim Frm As New frmMtoAreasPlanta
        AbrirFormInPanel(Frm)
        Frm.strConexion = My.Settings.cnnModProd
        Frm.Text = "Mantenimiento Mano de Obra"
        Frm.Show()

      Case "btnIngresoOC"
        subMenuCompras.Visible = False
        Dim Frm As New frmIngresosOC
        AbrirFormInPanel(Frm)
        Frm.Text = "Ingresos OC"
        Frm.Show() : Frm.WindowState = FormWindowState.Maximized

      Case "btnRptOT"
        submenuReportes.Visible = False
        Dim Frm As New frmRptOrdenes
        'Frm.mTipoReporte = frmRptCotizacion.enTiposReporte.Normal

        AbrirFormInPanel(Frm)
        Frm.Show() : Frm.WindowState = FormWindowState.Maximized
      Case "btnResumen"
        submenuProduccion.Visible = False
        Dim frm As New frmResumenProduccion   'frmOT
        frm.UsuarioId = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Text = "Notificación de producción"
        frm.Show() : frm.WindowState = FormWindowState.Maximized


      Case "btnRemision"
        submenuProduccion.Visible = False
        Dim frm As New frmRemision    'frmOT

        AbrirFormInPanel(frm)
        frm.Text = "Remisión de Entrega"
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnResponsables"
        subMenuMto.Visible = False
        Dim frm As New frmMntResponsables
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnReversaEstadosOT"
        Dim frm As New frmReversaEstadosOT

        frm.mUsuario_Id = mUsuario_Id
        frm.Text = "Estados OT"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnControlImpresion"
        Dim frm As New frmConsolaControl
        frm.Text = "Control de Impresiones"
        frm.UsuarioId = mUsuario_Id
        frm.TipoConsola = "IMPRIMIR"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized


      Case "btnValidarOT"
        Dim frm As New frmConsolaControl
        frm.Text = "Control de Impresiones"
        frm.UsuarioId = mUsuario_Id
        frm.TipoConsola = "VALIDAR"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnConResumen"
        Dim frm As New frmValidaResumenes
        frm.Text = "Validacion Resumenes"
        'frm.UsuarioId = mUsuario_Id
        'frm.TipoConsola = "VALIDAR"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnLiberaPedidoAlmacen"
        Dim frm As New frmLiberaPedidoAlmacen
        frm.Text = "Liberar Pedidos"
        'frm.UsuarioId = mUsuario_Id
        'frm.TipoConsola = "VALIDAR"
        AbrirFormInPanel(frm, "Lib. Ped.")
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "BtnOperarios"
        Dim frm As New frmMntOperarios
        frm.Text = "Operarios"
        AbrirFormInPanel(frm)
        frm.Show()

      Case "btnMtoPedidos"
        Dim frm As New frmMtoPedidos
        frm.TipoConsola = "PEDIDOS"
        frm.UsuarioId = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized
        frm.FormatoItemsCotizados()


      Case "btnMtoOrdenCompra"
        Dim frm As New frmMtoPedidos
        frm.TipoConsola = "OC"
        frm.UsuarioId = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized
        frm.FormatoItemsCotizados()


      Case "BtnProgramador"
        Dim frm As New frmProgramador
        'frm.TipoConsola = "OC"
        frm.UsuarioId = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized
        'frm.FormatoItemsCotizados()

      Case "btnRptSubTareas"
        Dim frm As New frmRptSubTareas
        frm.strNombreReporte = "18_RPT_SubTareas"
        frm.Text = "Reporte de Subtareas"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnRptSubTareasGeneral"
        Dim frm As New frmRptSubTareas
        frm.strNombreReporte = "19_RPT_SubTareasGeneral"
        frm.Text = "Reporte de General Subtareas"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized

      Case "btnRptNotificar"
        Dim frm As New frmRptSubTareas
        frm.strNombreReporte = "21_RPT_Notificaciones"
        frm.Text = "Reporte de Notificaciones"
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized



      Case "btnRegistroMov"
        Dim frm As New frmMovInventario
        frm.UsuarioId = mUsuario_Id
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized
        'frm.FormatoItemsCotizados()

      Case "btnGastosMontaje"
        Dim frm As New frmGastosMontaje
        'frm.strNombreReporte = "19_RPT_SubTareasGeneral"
        frm.mUsuarioId = mUsuario_Id
        frm.Text = "Control de costos de montaje"
        Call frm.CargaCrearDtDetPosicion()
        AbrirFormInPanel(frm)
        frm.Show() : frm.WindowState = FormWindowState.Maximized


    End Select



    Me.SendToBack()
    Me.WindowState = FormWindowState.Minimized


  End Sub


  Private Sub btnProduccion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProduccion.Click
    submenuProduccion.Visible = Not submenuProduccion.Visible
  End Sub



  Private Sub MostrarVentana(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim frm As Form

    For Each Boton In flpVentanas.Controls
      frm = Boton.tag
      'frm.Visible = False
      frm.SendToBack()
      Boton.BackColor = Nothing

    Next

    frm = sender.tag
    'frm.Visible = True
    frm.BringToFront() : frm.StartPosition = FormStartPosition.CenterScreen
    frm.Icon = My.Resources.IconoFrm
    sender.BackColor = Color.Gray
    Call FormatoBarraTitulo(True)

  End Sub

  Public Sub AbrirFormInPanel(ByRef frmHijo As Form, Optional ByVal mTextoBoton As String = "")

    'frmHijo.Visible = False
    'frmHijo.TopLevel = False
    'frmHijo.Dock = DockStyle.Fill
    'panelContenedor.Controls.Add(frmHijo)
    'panelContenedor.Tag = frmHijo


      Dim mBoton As New Button

      mBoton.Name = "btnVentana" & mNumPestana.ToString
      If mTextoBoton = "" Then
        mBoton.Text = frmHijo.Text
      Else
        mBoton.Text = mTextoBoton
      End If

      mBoton.FlatStyle = FlatStyle.Flat
      mBoton.FlatAppearance.BorderSize = 0
      mBoton.FlatAppearance.MouseDownBackColor = Color.FromArgb(73, 75, 83) 'Color.Gray
      mBoton.FlatAppearance.MouseOverBackColor = Color.FromArgb(73, 75, 83)
      mBoton.Size = New Size(100, 25)
      mBoton.Font = New Font("Century Gothic", 10)
      mBoton.ForeColor = Color.White
      mBoton.Tag = frmHijo
      mBoton.AutoSize = True

      frmHijo.Tag = mBoton 'LO USO PARA RENOMBRAR EL BOTON DE TITULO CUANDO SE CARGE EL FRM
      AddHandler mBoton.Click, AddressOf MostrarVentana
      flpVentanas.Controls.Add(mBoton)
      mNumPestana = mNumPestana + 1

      Call MostrarVentana(mBoton, New System.EventArgs)

      frmHijo.Visible = True

    frmHijo.Show()
  End Sub



  Private Sub flpVentanas_ControlRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ControlEventArgs)
    If flpVentanas.Controls.Count > 0 Then
      Call MostrarVentana(flpVentanas.Controls.Item(flpVentanas.Controls.Count - 1), New System.EventArgs)
    End If
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
    mRol_Id = obCntv.LeerValorSencillo("Rol_Id", "Usuarios", strWhere, strCadena)

    If strEsAdmin = "" Then
      EsAdmin = False
      MessageBox.Show("Usuario " & Dominio & "\" & Usuario & " no autorizado!" & vbCrLf & " Comuníquese con el administrador del sistema", "ModProd - Error de autorización", _
                      MessageBoxButtons.OK, MessageBoxIcon.Error)
      End
    Else
      EsAdmin = CBool(strEsAdmin) ' True
    End If


    If EsAdmin = True Then
    '  btnAgregarMP.Visible = True
    '  btnCrearPT.Visible = True
    '  btnMntCostos.Visible = True
      btnCambiaEstadoCotizacion.Visible = True
    End If

    obCntv = Nothing
  End Sub




  Private Sub btnCompras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompras.Click
    subMenuCompras.Visible = Not subMenuCompras.Visible
  End Sub

Private Sub btnInventarios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventarios.Click
    subMenuInventario.Visible = Not subMenuInventario.Visible

End Sub


  Private Sub CargarOTConBuscar()
     Dim FrmB As New frmBuscar, xNumOrden As String, obCntv As New clConectividad

    FrmB.Text = "Buscar OT"
    FrmB.lblDoc.Text = "Numero OT" : FrmB.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    FrmB.txtDocumento.MaxLength = 10

    xNumOrden = obCntv.LeerValorSencillo("valor", "parametros", "id=16", My.Settings.cnnModProd)
    obCntv = Nothing
    FrmB.txtDocumento.Text = Strings.Left(xNumOrden, 2) & "*"


    FrmB.chkTexto.Text = "Alcance"
    FrmB.chkFechas.Text = "Fecha   "
    FrmB.chkTercero.Text = "Cliente  "

    FrmB.txtTexto.Tag = "Alcance"
    FrmB.dtpFechaIni.Tag = "FechaRegistro" : FrmB.dtpFechaFin.Tag = "FechaRegistro"
    FrmB.cmbTercero.Tag = "NombreCliente"

    FrmB.strConsultaSQL = "vw_buscarOT"
    'FrmB.strCamposSQL = "id, NumOrden, Estado, NumCotizacion, NombreCliente, NombreProyecto, FechaRegistro,  FechaInicio, FechaRegistro ,OTCabCotizacion_Id"
    FrmB.strCamposSQL = "id, NumOrden, NumCotizacion, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,  FechaInicio, FechaRegistro ,	Estado, [OC Cliente], CntAFabricar, OTCabCotizacion_Id"
    FrmB.mWhereExterno = " AND Estado in('PM','C', 'DT', 'PP', 'FB', 'MJ', 'LQ')"
    FrmB.StartPosition = FormStartPosition.CenterScreen
    FrmB.ShowDialog()


    Dim dtConsulta As DataTable

    If FrmB.DialogResult = Windows.Forms.DialogResult.OK Then
      dtConsulta = FrmB.dtSeleccionado.Copy

      Dim Cotiza As Integer
      Dim mNumOT = dtConsulta.Rows(0).Item("NumOrden").ToString
      Dim Frm As New frmProductosOT
      Cotiza = dtConsulta.Rows(0).Item("NumCotizacion").ToString
      Frm.NumCotizacionOriginal = Cotiza
      Frm.NumeroOT = mNumOT
      Frm.CabOrden_Id = dtConsulta.Rows(0).Item("id").ToString
      Frm.OTCabCotizacion_Id = IIf(dtConsulta.Rows(0).Item("OTCabCotizacion_Id").ToString = "", 0, dtConsulta.Rows(0).Item("OTCabCotizacion_Id").ToString)

      AbrirFormInPanel(Frm)

    End If

    FrmB.Dispose()


  End Sub


  Private Sub IniciarNotificaciones()
      Dim frm As New frmNotifica
      frm.Show()
      frm.WindowState = FormWindowState.Minimized
      frm.Hide()

  End Sub


  Public Sub AbreFrmOrdenDeTrabajoDesdeNotificacion(ByVal frm As frmOrdenDeTrabajo)
    'Dim frm As New frmOrdenDeTrabajo  'frmOT
    AbrirFormInPanel(frm)
    'frm.KeyEnPadre = frm.Name.ToString & Me.panelContenedor.Controls.IndexOf(frm).ToString


  End Sub


  Private Sub btnMto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMto.Click
    subMenuMto.Visible = Not subMenuMto.Visible
  End Sub


  Private Sub SeguridadMenu()
    Dim ObCntv As New clConectividad, mTablaMenu As Data.DataTable
    Dim obInicio As New clSetUpInicio
    Dim mParametros As String = "'" & obInicio.Dominio & "','" & obInicio.Usuario & "'"


    Dim clcBotones As New Collection

    With clcBotones
      .Add(Me.btnComercial, "btnComercial")
      .Add(Me.btnCotizar, "btnCotizar")
      .Add(Me.btnContratos, "btnContratos")
      .Add(Me.btnCambiaEstadoCotizacion, "btnCambiaestadoCotizacion")
      .Add(Me.btnProduccion, "btnProduccion")
      .Add(Me.btnRegistroOT, "btnRegistroOT")
      .Add(Me.btnMateriales, "btnMateriales")
      .Add(Me.btnDividirOT, "btnDividirOT")
      .Add(Me.btnCompras, "btnCompras")
      .Add(Me.btnPedidos, "btnPedidos")
      .Add(Me.btnActualizaPrecios, "btnActualizaPrecios")
      .Add(Me.btnCriterios, "btnCriterios")
      .Add(Me.btnOrdenCompra, "btnOrdenCompra")
      .Add(Me.btnPedidoManual, "btnPedidoManual")
      .Add(Me.btnInventarios, "btnInventarios")
      .Add(Me.btnRegistroMov, "btnRegistroMov")
      .Add(Me.btnGeneraReporteInventario, "btnGeneraReporteInventario")
      .Add(Me.btnReportes, "btnReportes")
      .Add(Me.btnRptCotizaciones, "btnRptCotizaciones")
      .Add(Me.btnRptOT, "btnRptOT")
      .Add(Me.btnMto, "btnMto")
      .Add(Me.btnMPNoCreada, "btnMPNoCreada")
      .Add(Me.btnParametros, "btnParametros")
      .Add(Me.btnValidarOrdenes, "btnValidarOrdenes")
      .Add(Me.btnRptCotAGerencia, "btnRptCotAGerencia")
      .Add(Me.btnBorrarPedido, "btnBorrarPedido")
      .Add(Me.btnRptPedidos, "btnRptPedidos")
      .Add(Me.btnMntoMO, "btnMntoMO")
      .Add(Me.btnIngresoOC, "btnIngresoOC")
      .Add(Me.btnResumen, "btnResumen")
      .Add(Me.btnRemision, "btnRemision")
      .Add(Me.btnResponsables, "btnResponsables")
      .Add(Me.btnReversaEstadosOT, "btnReversaEstadosOT")
      .Add(Me.btnControlImpresion, "btnControlImpresion")
      .Add(Me.btnValidarOT, "btnValidarOT")
      .Add(Me.btnConResumen, "btnConResumen")
      .Add(Me.btnLiberaPedidoAlmacen, "btnLiberaPedidoAlmacen")
      .Add(Me.BtnOperarios, "BtnOperarios")
      .Add(Me.btnMtoPedidos, "btnMtoPedidos")
      .Add(Me.btnMtoOrdenCompra, "btnMtoOrdenCompra")
      .Add(Me.BtnProgramador, "BtnProgramador")
      .Add(Me.btnRptSubTareas, "btnRptSubTareas")
      .Add(Me.btnRptSubTareasGeneral, "btnRptSubTareasGeneral")
      .Add(Me.btnGastosMontaje, "btnGastosMontaje")
      .Add(Me.btnRptNotificar, "btnRptNotificar")


    End With

    Dim Ff As Integer ', mBoton As Button

    For Ff = 1 To clcBotones.Count
      Dim mBoton As Button
      mBoton = clcBotones(Ff)
      mBoton.Visible = False
    Next

    mTablaMenu = ObCntv.LlenarDataTable(My.Settings.cnnModProd, True, "PA_MenuXUsuario", mParametros, "mTablaMenu")

    'cuadro los submenus para que se carguen los botones
    submenuComercial.Visible = True
    submenuProduccion.Visible = True
    subMenuCompras.Visible = True
    subMenuMto.Visible = True
    submenuReportes.Visible = True
    subMenuInventario.Visible = True

    For Ff = 0 To mTablaMenu.Rows.Count - 1
      Dim mBoton As Button
      mBoton = clcBotones(mTablaMenu.Rows(Ff).Item("nombre").ToString)
      If mBoton.Visible = False Then
        mBoton.Visible = mTablaMenu.Rows(Ff).Item("Valor")
      End If

      'If mTablaMenu.Rows(Ff).Item("nombre") = "btnMtoOrdenCompra" Then
      '  Debug.Print(mTablaMenu.Rows(Ff).Item("Titulo"))
      'End If

      mBoton.Text = mTablaMenu.Rows(Ff).Item("Titulo").ToString

      'Debug.Print(mBoton.Name)
    Next


    'oculto los submenus
    Call FormatoSubMenus(submenuComercial)
    Call FormatoSubMenus(submenuProduccion)
    Call FormatoSubMenus(subMenuCompras)
    Call FormatoSubMenus(subMenuMto)
    Call FormatoSubMenus(submenuReportes)
    Call FormatoSubMenus(subMenuInventario)

    submenuComercial.Visible = False
    submenuProduccion.Visible = False
    subMenuCompras.Visible = False
    subMenuMto.Visible = False
    submenuReportes.Visible = False
    subMenuInventario.Visible = False


    obInicio = Nothing : ObCntv = Nothing : mTablaMenu = Nothing
  End Sub

  Private Sub FormatoSubMenus(ByVal SubMenu As Panel)
    Dim mCant As Integer = 0, Ii As Integer, mBoton As Button, mDisp As Integer
    Dim HhFlp As Integer = 40, mTop As Integer = 0

    mCant = SubMenu.Controls.Count

    'For Ii = 0 To mCant - 1
    For Ii = mCant - 1 To 0 Step -1
      mBoton = SubMenu.Controls(Ii)

      If mBoton.Visible = True Then
        mDisp = mDisp + 1
        mBoton.Top = mTop : mTop = mTop + HhFlp
      End If

    Next

   SubMenu.Height = (mDisp * HhFlp) + 12

  End Sub


  Public Sub FormatoBarraTitulo(Optional ByVal Colapsar As Boolean = False)
    Dim HhFlp As Integer = 35, mCant As Integer

    If flpVentanas.Controls.Count > 10 Then
      mCant = 10
    ElseIf flpVentanas.Controls.Count = 0 Then
      mCant = 1
    Else
      mCant = flpVentanas.Controls.Count
    End If

    If Colapsar = True Then
      mCant = 1
    End If


    flpVentanas.Height = HhFlp * mCant
    barraTitulo.Height = (HhFlp * mCant) + 10
    flpVentanas.Top = 5 'margen constante



  End Sub

  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
    Call FormatoBarraTitulo()
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApagar.Click
      Application.Exit()
  End Sub


  Private Sub CrearLog()
    'Dim strRuta As String = Application.StartupPath & "\ModProdLog.txt"

    'Dim Escritor As System.IO.StreamWriter

    'System.IO.File.Delete(strRuta)


    'Escritor = System.IO.File.AppendText(strRuta)
    '  Escritor.Write("INICIO LOG MODPROD " & Date.Today & " " & Date.Now)
    '  Escritor.Flush()
    '  Escritor.Close()

    Dim obLog As New clLog


    obLog.IniciarArchivo(Application.StartupPath & "\ModProdLog.txt")

  End Sub

Private Sub icoMinimizar_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles icoMinimizar.MouseMove
    icoMinimizar.BackColor = Color.Gray
End Sub

Private Sub icoMinimizar_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles icoMinimizar.MouseLeave
  icoMinimizar.BackColor = Nothing
End Sub

Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    Dim frm As New frmMtoPermisos
    frm.Show()
End Sub





Private Sub btnRptNotificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRptNotificar.Click

End Sub
End Class
