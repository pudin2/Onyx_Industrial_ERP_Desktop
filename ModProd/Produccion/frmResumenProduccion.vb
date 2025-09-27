Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports VBNet = Microsoft.VisualBasic

Public Class frmResumenProduccion
  Private mMaquina_Id As Integer, mNombreMaquina As String
  Private mOperarion_Id As Integer, mNombreOperario As String
  Private Sep As Char
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mUsuario_Id As Integer
  Private mNumResumen As Integer, mDocCargado As Boolean
  Private mNumOrden As Integer ', mUsuario_Id As Integer
  Private mCabOt_Id As Integer, mOTCabCotizacion_Id As Integer
  Private mMotivo_Id As Integer, mDescMotivo As String
  Private mFF_mp As Integer
  Private mObProd As New clProduccion
  Private dtDetSubT As Data.DataTable
  Private dtOperarios As Data.DataTable
  Private strOperatio_Id As String, mPorcIni As Decimal
  Private mVctAnexos As New Collection
  Private mTablaAnexos As DataTable, mCantAnexosCot As Integer


 Public Property UsuarioId As Integer
  Get
    Return mUsuario_Id
  End Get
  Set(ByVal value As Integer)
    mUsuario_Id = value
  End Set
  End Property

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

  End Structure

  Private mOrdenDeTrabajo As OrdenDeTrabajo


  Private Structure CabSubt
    Public OT_Cab_ID As Integer
    Public Descripcion As String
    Public AsignadaA As String
  End Structure

  Private mCabSubT As CabSubt


    Private Sub frmResumenProduccion_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
         Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          Debug.Print(ex.Message)
        End Try
    End Sub

  Private Sub frmResumenProduccion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Dim obCntv As New clConectividad, xCargosAMostrarEnOT As String
      Dim obInicio As New clSetUpInicio


      'ONYX 20220701  Por ahora se remueve tab de MO
      'Detectar el separador decimal de la aplicación.
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

      tbcContenido.TabPages.Remove(tbpResumenMO_old)
      tbcContenido.TabPages.Remove(tbpResumenMP)
      tbcContenido.TabPages.Remove(tbpConsolidado)
      'tbcContenido.TabPages.Remove(tbpResumenMO)


       'PARTE DE LA CARGA DE LOS OPERARIOS
      dtOperarios = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
      cmbOperarios.DataSource = dtOperarios
      cmbOperarios.DisplayMember = "NombreMostrar"


      'Detectar el separador decimal de la aplicación.
      Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

      ''SE LLENAN LOS COMBOS
      'cmbMaquinas.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "maquinas", "Estado='A'", "Order by Id")
      'cmbMaquinas.DisplayMember = "Nombre"

      cmbMotivo.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "MMotivoProd", "Estado='A'", "Order by Id")
      cmbMotivo.DisplayMember = "Descripcion"

      

      Dim mUsuario As String, mDominio As String ', obInicio As New clSetUpInicio
      mUsuario = obInicio.Usuario 'Environment.UserName '& Environment.UserName.GetHashCode
      mDominio = obInicio.Dominio  'Environment.UserDomainName
      obInicio = Nothing

      Call FormatoGrilla()

      Call CargarOTConBuscar()

      mTablaAnexos = CreaTablaAnexos()

      tbcContenido.SelectedTab = tbcContenido.TabPages("tbpSubTareas")


      obCntv = Nothing
  End Sub




  Private Sub cmbMaquinas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbMaquinas.SelectedIndexChanged
      Dim selectedItem As DataRowView
      selectedItem = cmbMaquinas.SelectedItem

      mMaquina_Id = selectedItem("id").ToString
      mNombreMaquina = selectedItem("Nombre").ToString

        'Call CargaContratos(strIdCliente)
      lblControDesarrollo.Text = mMaquina_Id.ToString & " - " & mOperarion_Id.ToString
  End Sub

  Private Sub cmbOperarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim selectedItem As DataRowView
      selectedItem = cmbOperarios.SelectedItem

      mOperarion_Id = selectedItem("idCliente").ToString
      mNombreOperario = selectedItem("NombreEmpleado").ToString

        'Call CargaContratos(strIdCliente)
      lblControDesarrollo.Text = mMaquina_Id.ToString & " - " & mOperarion_Id.ToString
  End Sub


  Private Sub txtCantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) _
  Handles txtCantidad.KeyPress, txtCosto.KeyPress, txtNumOrden.KeyPress, txtHoras.KeyPress, txtCntAReportar.KeyPress

        lblAdvertencia.Visible = False
        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

        If Asc(e.KeyChar) = Keys.Enter Then
            Call AdicionarMP()
        End If

  End Sub


  Private Sub btnAdicionar_Click(sender As System.Object, e As System.EventArgs) Handles btnAdicionar.Click
      Dim xCostoU As Decimal

      If txtHoras.Text <> "" And txtTarea.Text <> "" Then
          xCostoU = IIf(txtCosto.Text = "", 0, txtCosto.Text)
          txtCantidad.Text = 1
          Dim strFilaNueva() As String = { _
                cmbOperarios.Text, cmbMaquinas.Text, txtTarea.Text, txtCantidad.Text, CDec(txtHoras.Text).ToString(FCANT), CDec(xCostoU).ToString(FCANT), _
                (CDec(txtCantidad.Text) * xCostoU).ToString(FCTOTOT), mMaquina_Id, mOperarion_Id}

          grDetalleResumen.Rows.Add(strFilaNueva)

          txtCantidad.Text = "" : txtHoras.Text = "" : txtCosto.Text = ""
          txtTarea.Text = ""
          cmbOperarios.SelectedIndex = 0
          cmbMaquinas.SelectedIndex = 0

          If btnGrabar.Tag = "SI" Then
                btnGrabar.Visible = True
          End If

    End If


  End Sub


  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
    Dim obCntv As New clConectividad, Ff As Integer, obProd As New clProduccion

    For Ff = 0 To grSubTareas.RowCount - 1
      'Si se ha marcado para notificar
      If grSubTareas.Item("colNotificar", Ff).Value = True Then
        'Sin encuentra un item vacio y se marcó para notificar
        If grSubTareas.Item("colHorasReal", Ff).Value = "" Then
          If grRecursos.Rows.Count - 1 < 0 Then
              MessageBox.Show("Debe especificar las horas para cada sub tarea reportada!", "Falta de horas", MessageBoxButtons.OK, MessageBoxIcon.Error)
              Exit Sub
          End If
        End If

        'No continuar si esta en blanco el porcentaje, es obligatorio
        'If txtPorcNoti.Text = "" Then
        If grSubTareas.Item("colPorc", Ff).Value = "" Then
          MessageBox.Show("Debe especificar un porcentaje de avance!", "Falta de avance", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Exit Sub

        End If


        'Reviso que los detalles esten notificados, con base en parámetro CntMinMateNotif
        Dim mCntMinMateNotif As Integer = CInt(obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion ='CntMinMateNotif'", My.Settings.cnnModProd))

        Dim Ff2 As Integer, CntMatConValor As Integer = 0

        For Ff2 = 0 To grSubTareasDet.Rows.Count - 1
          If grSubTareasDet.Item("Real", Ff2).Value > 0 Then
            CntMatConValor = CntMatConValor + 1
          End If
        Next Ff2

        'Valido si hay la canditad de items notificados es igual o superior al parametro
        If CntMatConValor < mCntMinMateNotif Then
          MessageBox.Show("Debe especificar los materiales para cada sub tarea reportada!", "Falta de material", MessageBoxButtons.OK, MessageBoxIcon.Error)
          Exit Sub
        End If

      End If
    Next

    'SE EJECUTA LA NOTIFICACIÓN
    For Ff = 0 To grSubTareas.RowCount - 1
      If grSubTareas.Item("colNotificar", Ff).Value = True Then
          Call NotificarSubTarea(Ff)

      End If
    Next


    'GRABO LOS ESTADOS
    Dim mIdEstado As Integer = obCntv.LeerValorSencillo("id", "estados ", "tipodoc='OT' and estado ='FB'", My.Settings.cnnModProd)
    Dim strInsert = "exec pa_Insert_EstadosOT " & mCabOt_Id & "," & mIdEstado & "," & mUsuario_Id & ",'P'"
    obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

    MessageBox.Show("Resumen de producción de OT " & mNumOrden.ToString & " grabado con éxito!", "Resumen de producción", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Call LimpiarFrm()
    Call CargarResumen(mNumOrden)
    Call CargaOT(mNumOrden)


  End Sub

  Private Sub NotificarSubTarea(ByVal Ff_p As Integer)
    Dim obCntv As New clConectividad, Ff As Integer ', obProd As New clProduccion
    Dim mObCntv As New clConectividad, mCab_Id As Integer
    Dim mObProd As New clProduccion

    mCab_Id = mObCntv.LeerValorSencillo("ISNULL(MAX(id)+1,1) [MaxCabId]", "MaxCabId", "CabSubT", "1=1", My.Settings.cnnModProd)


    'LOS MATERIALES
    For Ff = 0 To dtDetSubT.Rows.Count - 1
      If dtDetSubT.Rows(Ff).Item("Editado") = "SI" And dtDetSubT.Rows(Ff).Item(1) = grSubTareas.Item("Col_mCabSutT", Ff_p).Value Then
        Dim NuevaFila = mObProd.TablaDetSubT.NewDetSubTRow

        NuevaFila("Cab_Id") = mCab_Id
        NuevaFila("Id") = Ff + 1
        NuevaFila("CodInventario") = dtDetSubT.Rows(Ff).Item("CodInventario")
        NuevaFila("Inventario_ID") = dtDetSubT.Rows(Ff).Item("Inventario_ID")
        NuevaFila("Cant") = dtDetSubT.Rows(Ff).Item("Real")
        NuevaFila("Unidad_Id") = 1
        NuevaFila("Estado") = "A"
        NuevaFila("DetCotizacion_Id") = dtDetSubT.Rows(Ff).Item("DetCotizacion_Id")
        NuevaFila("Tipo") = 1
        '_Ff = _Ff + 1
        mObProd.TablaDetSubT.AddDetSubTRow(NuevaFila)


      End If
    Next

    'LAS HORAS
    Dim _mId As Integer = Ff + 1
    For Ff = 0 To grRecursos.Rows.Count - 1
      Dim NuevaFila = mObProd.TablaDetSubT.NewDetSubTRow
      NuevaFila("Cab_Id") = mCab_Id
      NuevaFila("Id") = _mId  'Ff + 1
      NuevaFila("CodInventario") = grRecursos.Item("colRecurso", Ff).Value   'dtDetSubT.Rows(Ff).Item("CodInventario")
      NuevaFila("Inventario_ID") = grRecursos.Item("ColRecurso_Id", Ff).Value
      NuevaFila("Cant") = grRecursos.Item("colHoraRecurso", Ff).Value  'dtDetSubT.Rows(Ff).Item("colHoraRecurso")
      NuevaFila("Unidad_Id") = 1
      NuevaFila("Estado") = "A"
      NuevaFila("DetCotizacion_Id") = 0 'dtDetSubT.Rows(Ff).Item("DetCotizacion_Id")
      NuevaFila("Tipo") = 2
      mObProd.TablaDetSubT.AddDetSubTRow(NuevaFila)
      _mId = _mId + 1
    Next

    Dim mPorc As Decimal = CDec(grSubTareas.Item("colPorc", Ff_p).Value) / 100
    Dim mHorasResp As Integer

    mHorasResp = IIf(grSubTareas.Item("colHorasReal", Ff_p).Value = "", 0, grSubTareas.Item("colHorasReal", Ff_p).Value)



    Dim mMaxItem As Integer = mObCntv.LeerValorSencillo("ISNULL(Max(item) +1,1) as [Item]", "Item", "CabSubT", "Tipo='NT' and OT_Cab_ID = " & mCabOt_Id, My.Settings.cnnModProd)

    mObProd.GrabarSubTarea(My.Settings.cnnModProd, "INSERT", _
              grSubTareas.Item("Col_mCabSutT", Ff_p).Value, mCab_Id, mCabOt_Id, grSubTareas.Item("colDescSubT", Ff_p).Value, _
              Date.Now, grSubTareas.Item("colSubTAsignadaA", Ff_p).Value, "A", "NT", _
              mHorasResp, grSubTareas.Item("ColOperario_Id", Ff_p).Value, mMaxItem, Observacion:=txtObservacion.Text)

    Dim mEstado As String
    If mPorc = 1 Then
      mEstado = "T" 'TErminada
    Else
      mEstado = "N" 'Notificada
    End If
    obCntv.ActualizaValor("Estado='" & mEstado & "', Porc=" & mPorc, "CabSubT", "Id=" & grSubTareas.Item("Col_mCabSutT", Ff_p).Value, My.Settings.cnnModProd)

    'Grabo los anexos
    If lstAnexos.Items.Count > 0 Then
      Call GrabarAnexos(mNumOrden, mCab_Id)
    End If

  End Sub





  Private Sub LimpiarFrm()
      'cmbMaquinas.SelectedIndex = 0
      'cmbOperarios.SelectedIndex = 0
      txtNumOrden.Text = ""
      txtProyecto.Text = ""
      txtCantidad.Text = ""
      txtHoras.Text = ""
      txtCosto.Text = ""
      txtTarea.Text = ""
      txtCliente.Text = ""
      txtAlcance.Text = ""
      grDetalleResumen.Rows.Clear()
      grSubTareas.Rows.Clear()
      grSubTareasDet.DataSource = Nothing
      grSubTareasDet.Rows.Clear()
      txtObservacion.Text = ""
      grRecursos.Rows.Clear()
      'dtDetSubT = Nothing

      Dim obCntv As New clConectividad
      Dim mObligaAnexoNotif As String = obCntv.LeerValorSencillo("Valor", "parametros", "Descripcion='ObligaAnexoNotif'", My.Settings.cnnModProd)

      If UCase(mObligaAnexoNotif) = "SI" Then
        btnGrabar.Visible = False
      Else
        btnGrabar.Visible = True
      End If
      obCntv = Nothing



  End Sub

  Private Sub FormatoGrilla()

    With grSubTareas
      .Columns("colHorasReal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End With

    'Dim checkBoxColumn As DataGridViewCheckBoxColumn = DirectCast(grSubTareas.Columns("colNotificar"), DataGridViewCheckBoxColumn)

    '' Establecer el estilo de alineación para la columna
    'checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    'checkBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter


  End Sub

  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
    If flyPanelBotones.Width = 190 Then
      flyPanelBotones.Width = 45
      grpDetalle.Width = grpDetalle.Width + (190 - 45)
    Else
      flyPanelBotones.Width = 190

      grpDetalle.Width = grpDetalle.Width - (190 - 45)

    End If
  End Sub


  Private Sub cmdCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCargar.Click
      Call CargarOTConBuscar()
  End Sub


  Private Sub CargarResumen(ByVal mNumOrden As Integer)
      Dim obCntv As New clConectividad
      Dim drCabResumen As MSSQL.SqlDataReader = obCntv.LeerValor("*", "VW_ResumenProduccion", "NumOrden=" & mNumOrden.ToString & " ORDER BY ResCab_ID, ResDet_ID ", My.Settings.cnnModProd)
      Dim strFilaNueva() As String

      grConsolidado.Rows.Clear()
      grDetalleResumen.Rows.Clear()
      grReportar.Rows.Clear()

      If drCabResumen.HasRows = True Then
        Do
            txtNumOrden.Text = drCabResumen.Item("NumOrden").ToString
            txtProyecto.Text = drCabResumen.Item("NombreProyecto").ToString
            txtCliente.Text = drCabResumen.Item("NombreCliente").ToString
            txtAlcance.Text = drCabResumen.Item("Alcance").ToString
            txtFechaOT.Text = drCabResumen.Item("FechaRegistro").ToString

            mNumResumen = IIf(drCabResumen.Item("ResCab_ID").ToString = "", 0, drCabResumen.Item("ResCab_ID").ToString)
            If drCabResumen.Item("ResDet_Id").ToString <> "" Then
              If drCabResumen.Item("Tipo").ToString = 2 Then
                      strFilaNueva = {
                              drCabResumen.Item("Operario").ToString,
                              drCabResumen.Item("Maquina").ToString,
                              drCabResumen.Item("Tarea").ToString,
                              drCabResumen.Item("Cantidad").ToString,
                              CDec(drCabResumen.Item("Horas").ToString).ToString(FCANT),
                              drCabResumen.Item("CostoUnitario").ToString,
                              drCabResumen.Item("CostoTotal").ToString,
                              drCabResumen.Item("Maquina_Id").ToString,
                              drCabResumen.Item("idCliente").ToString,
                              drCabResumen.Item("ResDet_Id").ToString
                          }
                      grDetalleResumen.Rows.Add(strFilaNueva)
                Else
                      strFilaNueva = {
                          drCabResumen.Item("CotDet_Id").ToString,
                          drCabResumen.Item("Maquina").ToString,
                          drCabResumen.Item("Operario").ToString,
                          drCabResumen.Item("Desc_Motivo").ToString,
                          CDec(drCabResumen.Item("Cantidad").ToString).ToString(FCANT),
                          drCabResumen.Item("Motivo_Id").ToString,
                          drCabResumen.Item("ResDet_Id").ToString
                        }

                      grReportar.Rows.Add(strFilaNueva)
                End If

                  strFilaNueva = {
                      drCabResumen.Item("ResCab_ID").ToString,
                      drCabResumen.Item("ResDet_ID").ToString,
                      drCabResumen.Item("Maquina").ToString,
                      drCabResumen.Item("Operario").ToString,
                      drCabResumen.Item("Tarea").ToString,
                      CDec(drCabResumen.Item("Horas").ToString).ToString(FCANT)
                  }

                grConsolidado.Rows.Add(strFilaNueva)
            End If
        Loop While drCabResumen.Read()
      End If
  End Sub


 Private Sub CargarOTConBuscar()
      Dim FrmB As New frmBuscar, xNumOrden As String, obCntv As New clConectividad


      FrmB.Text = "Buscar OT"
      FrmB.lblDoc.Text = "Numero OT" : FrmB.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
      FrmB.txtDocumento.MaxLength = 10

      xNumOrden = obCntv.LeerValorSencillo("valor", "parametros", "id=16", My.Settings.cnnModProd)

      FrmB.txtDocumento.Text = Strings.Left(xNumOrden, 2) & "*"
      FrmB.txtDocumento.MaxLength = 10


      FrmB.chkTexto.Text = "Alcance"
      FrmB.chkFechas.Text = "Fecha   "
      FrmB.chkTercero.Text = "Cliente  "

      FrmB.txtTexto.Tag = "Alcance"
      FrmB.dtpFechaIni.Tag = "FechaRegistro" : FrmB.dtpFechaFin.Tag = "FechaRegistro"
      FrmB.cmbTercero.Tag = "NombreCliente"

      FrmB.strConsultaSQL = "vw_buscarOT"
      ': FrmB.strCamposSQL = "id, NumOrden, Estado, NumCotizacion, NombreCliente, NombreProyecto, FechaRegistro,  FechaInicio, FechaRegistro ,OTCabCotizacion_Id, [Titulo Estado]"

       'Frm.strConsultaSQL = "vw_buscarOT"
      FrmB.strCamposSQL = "id, NumOrden, NumCotizacion, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,  " _
      & " FechaInicio, FechaRegistro ,	Estado, [OC Cliente], CntAFabricar, CntDespachada, CntXDespachar, EstadoOTCierre [Estado Cierre],CabCotizacion_Id,OTCabCotizacion_Id"


      'FrmB.mWhereExterno = " AND Estado in('PM','C','DT','PP','FB','MJ')"
      Dim mParamEstadosOT_id As String = obCntv.LeerValorSencillo("Valor", "parametros", "Descripcion='EstOTaCargarEnResuProd'", My.Settings.cnnModProd)
      FrmB.mWhereExterno = " AND [EstadoOT_Id] in(" & mParamEstadosOT_id & ") and TipoCot in('CN','CR')"
      FrmB.StartPosition = FormStartPosition.CenterScreen
      FrmB.ShowDialog()


      Dim dtConsulta As DataTable
      Call LimpiarFrm()
      If FrmB.DialogResult = Windows.Forms.DialogResult.OK Then
            stCargando.Visible = True
            Me.Refresh()
            dtConsulta = FrmB.dtSeleccionado.Copy
            'mNumResumen = dtConsulta.Rows(0).Item("Id")
            mNumOrden = dtConsulta.Rows(0).Item("NumOrden")
            mCabOt_Id = dtConsulta.Rows(0).Item("Id")
            mOTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id")
            stEstadoOT.Text = "EstadoOT: " & dtConsulta.Rows(0).Item("Titulo Estado") : stEstadoOT.Visible = True
            mOrdenDeTrabajo.CabOrden_Id = dtConsulta.Rows(0).Item("id").ToString

            'ONYX 2022 06 11 USO LA ESTRUCTURA PARA ALMACENAR LOS DATOS DE OT
            With mOrdenDeTrabajo
              .CabCotizacion_id = dtConsulta.Rows(0).Item("CabCotizacion_Id")   'mCabCotizacion_Id
              .CabOrden_Id = dtConsulta.Rows(0).Item("Id")  'mCabOrden_Id
              '.NumOrden = mNumOrden
              .NumOrden = dtConsulta.Rows(0).Item("NumOrden")
              .OTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id") 'mOTCabCotizacion_Id

            End With

            Call CargarResumen(mNumOrden)
            'SE LLENAN LOS PRODUCTOS
            'GrProductos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "id, Inventario_Id, CodInventario, Cant, 0", "detCotizacion", "cab_id=" & mOTCabCotizacion_Id.ToString & " and tipo=1", "Order by Id")
            Call CargarProductosOT()
            Call CargaSubTareas(mOrdenDeTrabajo.CabOrden_Id)

            stNumResumen.Text = "Resumen Número: " & mNumResumen.ToString
            stNumOrden.Text = "OT: " & mNumOrden.ToString
            Dim mBoton As Button = Me.Tag
            mBoton.Text = Me.Text & " " & mNumResumen
            mDocCargado = True
            'btnGrabar.Text = "Actualizar"

            Call HabilitarBotones()
            ''btnGrabar.Visible = False 'lo oculto siempre, pues no hay cambios, se habilita al adicionar un nuevo registro
            stCargando.Visible = False

      Else
        Me.Close()

      End If
      dtConsulta = Nothing
      obCntv = Nothing
      FrmB.Dispose()
    End Sub


  Private Sub CargaOT(ByVal mNumOrden As String)
    Dim dtConsulta As DataTable, obCntv As New clConectividad
    Dim strCamposSQL As String, strTabla As String, mWhere As String

    stCargando.Visible = True
    'Me.Refresh()

    strCamposSQL = "id, NumOrden, NumCotizacion, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,   FechaInicio, FechaRegistro , Estado, [OC Cliente], CntAFabricar, CntDespachada, CntXDespachar, EstadoOTCierre [Estado Cierre],CabCotizacion_Id,OTCabCotizacion_Id"
    strTabla = "vw_buscarOT"
    mWhere = "NumOrden like '" & mNumOrden & "'"


    dtConsulta = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCamposSQL, strTabla, mWhere, "")

    'mNumResumen = dtConsulta.Rows(0).Item("Id")
    mNumOrden = dtConsulta.Rows(0).Item("NumOrden")
    mCabOt_Id = dtConsulta.Rows(0).Item("Id")
    mOTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id")
    stEstadoOT.Text = "EstadoOT: " & dtConsulta.Rows(0).Item("Titulo Estado") : stEstadoOT.Visible = True
    mOrdenDeTrabajo.CabOrden_Id = dtConsulta.Rows(0).Item("id").ToString

    'ONYX 2022 06 11 USO LA ESTRUCTURA PARA ALMACENAR LOS DATOS DE OT
    With mOrdenDeTrabajo
      .CabCotizacion_id = dtConsulta.Rows(0).Item("CabCotizacion_Id")   'mCabCotizacion_Id
      .CabOrden_Id = dtConsulta.Rows(0).Item("Id")  'mCabOrden_Id
      '.NumOrden = mNumOrden
      .NumOrden = dtConsulta.Rows(0).Item("NumOrden")
      .OTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id") 'mOTCabCotizacion_Id

    End With

    Call CargarResumen(mNumOrden)
    'SE LLENAN LOS PRODUCTOS
    'GrProductos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "id, Inventario_Id, CodInventario, Cant, 0", "detCotizacion", "cab_id=" & mOTCabCotizacion_Id.ToString & " and tipo=1", "Order by Id")
    Call CargarProductosOT()
    Call CargaSubTareas(mOrdenDeTrabajo.CabOrden_Id)

    stNumResumen.Text = "Resumen Número: " & mNumResumen.ToString
    stNumOrden.Text = "OT: " & mNumOrden.ToString
    Dim mBoton As Button = Me.Tag
    mBoton.Text = Me.Text & " " & mNumResumen
    mDocCargado = True
    'btnGrabar.Text = "Actualizar"

    Call HabilitarBotones()
    ''btnGrabar.Visible = False 'lo oculto siempre, pues no hay cambios, se habilita al adicionar un nuevo registro
    stCargando.Visible = False
  End Sub





  Private Sub btnSigFase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSigFase.Click
    Dim obCntv As New clConectividad ', mEstadoXDefecto As String = "FB"

    Dim strSql As String

    Try
        Dim xEstadoActual As String = obCntv.LeerValorSencillo("Estado", "CabOT", "numorden=" & mNumOrden, My.Settings.cnnModProd)
        Dim drDatosEstado As MSSQL.SqlDataReader = obCntv.LeerValor("*", "Estados", "TipoDoc ='OT' and Estado ='" & xEstadoActual & "'", My.Settings.cnnModProd)
        Dim xIDEstadoActual As Integer, xTituloEtapa As String

        'OJO PROVISIONAL SOLO PARA VENTA DIRECTA
        If drDatosEstado.Item("id") < 13 Then
            xIDEstadoActual = 13 : xTituloEtapa = "FABRICACIÓN"
        Else
            xIDEstadoActual = drDatosEstado.Item("id") : xTituloEtapa = drDatosEstado.Item("Titulo").ToString
        End If


        'ASEGURO QUE EXISTA EL REGISTRO DEL ESTADO DE LA OT QUE SE VA A TERMINAR
        Dim strInsert = "exec pa_Insert_EstadosOT " & mCabOt_Id & "," & xIDEstadoActual.ToString & "," & mUsuario_Id & ",'P'"
        obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)


        strSql = "exec PA_TerminaEtapaOT " & mNumOrden.ToString & "," & xIDEstadoActual.ToString
        obCntv.EjecutaComando(strSql, My.Settings.cnnModProd, False)
        MessageBox.Show("Etapa de " & UCase(xTituloEtapa.ToString) & " terminada para la Orden de Trabajo " & mNumOrden.ToString, "Etapa terminada", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call LimpiarFrm()
      Catch ex As Exception
        MessageBox.Show(ex.Message, "Error ModProd", MessageBoxButtons.OK, MessageBoxIcon.Error)

      End Try
  End Sub

  Private Sub HabilitarBotones()
      Dim obCntv As New clConectividad, drCabOT As MSSQL.SqlDataReader, dtEstados As DataTable
      Dim mParamEstadosOT_id As String
      Dim Ff As Integer

      'btnGrabar.Visible = False
      'btnSigFase.Visible = False

      drCabOT = obCntv.LeerValor("TipoCot,Estado, EstadoOT_Id", "vw_buscarOT", "NumOrden=" & mNumOrden.ToString, My.Settings.cnnModProd)


      If drCabOT.Item("TipoCot") = "CR" Then
          mParamEstadosOT_id = obCntv.LeerValorSencillo("Valor", "parametros", "Descripcion='EstOTaCargarEnResuProd'", My.Settings.cnnModProd)
      Else
          'PARA LAS OT NORMALES, DEBEN ESTARN POR LO MENOS EN ESTADO DE FABRICACIÓN
          mParamEstadosOT_id = obCntv.LeerValorSencillo("Valor", "parametros", "Descripcion='EstOTNormalaCargarEnResuProd'", My.Settings.cnnModProd)
      End If

      dtEstados = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Estados", "id in (" & mParamEstadosOT_id & ")")
      'For Ff = 0 To dtEstados.Rows.Count - 1
      '    If dtEstados.Rows(Ff).Item("Estado") = drCabOT.Item("Estado") Then
      '          btnGrabar.Visible = MostrarBoton(btnGrabar, mUsuario_Id)
      '          btnSigFase.Visible = MostrarBoton(btnSigFase, mUsuario_Id)
      '    End If
      'Next

      If grSubTareas.Rows.Count > 1 Then btnGrabar.Visible = True
      If lstAnexos.Items.Count > 1 Then btnGrabar.Visible = True


      obCntv = Nothing
  End Sub

  Private Function MostrarBoton(ByVal mNombreBoton As String, ByVal xUsuario_Id As Integer) As Boolean
      Dim mCantidad As Integer, obCntv As New clConectividad
      Dim mWhere As String, drCantidad As MSSQL.SqlDataReader
      MostrarBoton = False
      mWhere = "FRM='" & Me.Name & "' and objeto='" & mNombreBoton & "' and usuario_id=" & xUsuario_Id.ToString

      'mCantidad = obCntv.LeerValorSencillo("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)

      drCantidad = obCntv.LeerValor("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)


      If drCantidad.HasRows Then
        mCantidad = drCantidad.Item("Cantidad")
          If mCantidad > 0 Then
              MostrarBoton = True ': Me.Controls(mNombreBoton).Tag = "SI"
          Else
              MostrarBoton = False ': Controls(mNombreBoton).Tag = "NO"
          End If
      End If

      obCntv = Nothing
  End Function


    Private Function MostrarBoton(ByVal mBoton As Button, ByVal xUsuario_Id As Integer) As Boolean
      Dim mCantidad As Integer, obCntv As New clConectividad
      Dim mWhere As String, drCantidad As MSSQL.SqlDataReader
      MostrarBoton = False
      mWhere = "FRM='" & Me.Name & "' and objeto='" & mBoton.Name & "' and usuario_id=" & xUsuario_Id.ToString

      'mCantidad = obCntv.LeerValorSencillo("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)

      drCantidad = obCntv.LeerValor("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)


      If drCantidad.HasRows Then
        mCantidad = drCantidad.Item("Cantidad")
          If mCantidad > 0 Then
              MostrarBoton = True : mBoton.Tag = "SI"
          Else
              MostrarBoton = False : mBoton.Tag = "NO"
          End If
      End If

      obCntv = Nothing
  End Function

    Private Sub CargarProductosOT()
        'LOS MATERIALES QUE SE ESPECIFICARON EN EL AJUSTE DE MATERIALES
        Dim obCntv As New clConectividad
        'Dim drDetCotizacion As MSSQL.SqlDataReader = obCntv.LeerValor("id, Inventario_Id, CodInventario, Cant, 0 [Faltante]", "detCotizacion", "cab_id=" & mOTCabCotizacion_Id.ToString & " and tipo=1 and estado='E'", My.Settings.cnnModProd)
        Dim drDetCotizacion As MSSQL.SqlDataReader = obCntv.LeerValor("*", "VW_DetOTConResumen", "cab_id=" & mOTCabCotizacion_Id.ToString & " and tipo=1 and estado='E'", My.Settings.cnnModProd)



        Dim strFilaNueva() As String

        grProductos.Rows.Clear()
        If drDetCotizacion.HasRows = True Then
        Do
            strFilaNueva = {
                drDetCotizacion.Item("Id").ToString,
                drDetCotizacion.Item("Inventario_Id").ToString,
                drDetCotizacion.Item("CodInventario").ToString,
                CDec(drDetCotizacion.Item("Cant").ToString).ToString(FCANT),
                CDec(drDetCotizacion.Item("Faltante").ToString).ToString(FCANT)
              }

            grProductos.Rows.Add(strFilaNueva)

        Loop While drDetCotizacion.Read()
        End If

    End Sub

    Private Sub grProductos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellEnter
        Dim gr As DataGridView = sender

        'txtProveedor.Text = gr.Item("PROVEEDOR", e.RowIndex).Value.ToString
        lblCodigo.Text = gr.Item("colCodInventario", e.RowIndex).Value.ToString
        lblColId.Text = gr.Item("colId", e.RowIndex).Value.ToString
        lblDescripcion.Text = gr.Item("colDescripcion", e.RowIndex).Value.ToString
        txtCntAReportar.Text = gr.Item("colCntFaltante", e.RowIndex).Value.ToString
        mFF_mp = e.RowIndex

        BtnAdicionarMP.Enabled = True
        If CDec(gr.Item("colCntFaltante", e.RowIndex).Value.ToString) = 0 Then BtnAdicionarMP.Enabled = False



    End Sub

    Private Sub BtnAdicionarMP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAdicionarMP.Click
        Call AdicionarMP()
    End Sub

    Private Sub AdicionarMP()
        Dim strFilaNueva() As String = { _
            lblColId.Text, lblCodigo.Text, lblDescripcion.Text, mDescMotivo.ToString, txtCntAReportar.Text.ToString, mMotivo_Id.ToString}

        lblAdvertencia.Visible = False

        If CDec(IIf(txtCntAReportar.Text = "", 0, txtCntAReportar.Text)) > 0 Then
            If CDec(txtCntAReportar.Text) > CDec(grProductos.Item("colCntFaltante", mFF_mp).Value) Then
              lblAdvertencia.Visible = True
              txtCntAReportar.SelectAll()
              Exit Sub
            End If



            grReportar.Rows.Add(strFilaNueva)
            grProductos.Item("colCntFaltante", mFF_mp).Value = CDec(grProductos.Item("colCntFaltante", mFF_mp).Value) - CDec(txtCntAReportar.Text)
            txtCntAReportar.Text = CDec(0).ToString(FCANT)
        End If

        If btnGrabar.Tag = "SI" Then
                btnGrabar.Visible = True
        End If

    End Sub


    Private Sub cmbMotivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim selectedItem As DataRowView
        selectedItem = cmbMotivo.SelectedItem
        mMotivo_Id = selectedItem("id").ToString
        mDescMotivo = selectedItem("Descripcion").ToString

    End Sub

    Private Sub txtCntAReportar_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCntAReportar.Enter
        txtCantidad.SelectAll()
    End Sub



  Private Sub CargaSubTareas(ByVal mCabOrden_Id As Integer)
        Dim obCntv As New clConectividad, drSubT As MSSQL.SqlDataReader

        drSubT = obCntv.LeerValor("*", "CabSubT", "Tipo='ST' and Estado <>'I' AND Estado in ('P','N','T') AND OT_Cab_Id=" & mCabOrden_Id, My.Settings.cnnModProd)
        'drSubT.Read()

        grSubTareasDet.DataSource = Nothing
        grSubTareas.Rows.Clear()
        'grSubTareasDet.Rows.Clear()

         'lblReal.Text = CDec(RsSalida.Item("Real").ToString).ToString(FCTOTOT)
        'Dim fecha As DateTime = DateTime.ParseExact("21/04/2023", "dd/MM/yyyy", CultureInfo.InvariantCulture)

        Do
          If drSubT.HasRows = True Then
            Dim valorDesdeBD As Object = drSubT.Item("Porc") ' aquí obtienes el valor de la base de datos
            Dim valorString As String

            If valorDesdeBD IsNot DBNull.Value Then
                valorString = CDec(valorDesdeBD * 100).ToString(FCANT) ' Conversión segura a String
            Else
                valorString = ""
            End If

            Dim strCabSubT() As String = { _
                            drSubT.Item("Descripcion").ToString.TrimStart,
                            drSubT.Item("AsignadaA"),
                            Format(drSubT.Item("Fecha"), "dd/MM/yyyy"),
                            "",
                            drSubT.Item("Id"),
                            False,
                            "",
                            drSubT.Item("Operario_Id"),
                            valorString
                            }
            'drSubT.Item("Horas"),

              'grSubTareas.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
              'Al cargar la OT, el campo CabSubT_Id de la grilla grSubTareas se debe llenar. Al agregar una fila nueva, va en blanco, de esta forma se diferencia al actualizar.
              grSubTareas.Rows.Add(strCabSubT)
              grSubTareas.Item("colPorc", grSubTareas.Rows.Count - 1).Tag = valorString

              grSubTareas.Columns("colDescSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft



              'SI ESTA TERMINADA LA TAREA AL 100%
              If drSubT.Item("Estado") = "T" Then
                Dim Ff As Integer = grSubTareas.Rows.Count - 1

                For CC = 0 To grSubTareas.Columns.Count - 1
                  grSubTareas.Item(CC, Ff).Style.BackColor = Color.Cyan  'Color.FromArgb(103, 177, 49)
                Next CC

                grSubTareas.Rows(Ff).ReadOnly = True
              End If


              'ONYX 2022 11 15 USO LA ESTRUCTURA PARA ALMACENAR LOS DATOS DE SUB TAREA
              With mCabSubT
                .OT_Cab_ID = drSubT.Item("OT_Cab_ID")
                .Descripcion = drSubT.Item("Descripcion")
                .AsignadaA = drSubT.Item("AsignadaA")

              End With

          End If
        Loop While drSubT.Read()

        'EL DETALLE DE LAS SUBTAREAS
        Dim mCampos As String
        mCampos = "OT_Cab_ID, Cab_Id, Id, CodInventario, Inventario_ID, Cant, Unidad_Id, " _
          & "Estado, DetCotizacion_Id,	Tipo, CONVERT(money, 0) [Real], CONVERT(INT,0) [Llave]," _
          & "CONVERT(VARCHAR(2),'') [Editado], CANT_NT [Reportado]"

        dtDetSubT = obCntv.LlenarDataTable(My.Settings.cnnModProd, mCampos, _
          "VW_DetSubT", "Tipo='ST' and Estado='A' and OT_Cab_ID=" & mOrdenDeTrabajo.CabOrden_Id, "Order by Cab_id, Id")

        Dim fF2 As Integer
        For fF2 = 0 To dtDetSubT.Rows.Count - 1
          dtDetSubT.Rows(fF2).Item("Llave") = fF2
        Next

        'grSubTareasDet.DataSource = dtDetSubT
        If grSubTareas.Rows.Count > 0 Then
          Call FiltrarDetSubT(0)
        End If



    End Sub

  Private Sub FiltrarDetSubT(ByVal Fila As Integer)
      Dim dtFiltrado As Data.DataTable, strFiltro As String

      dtFiltrado = dtDetSubT.Clone
      strFiltro = "Cab_Id=" & grSubTareas.Item("Col_mCabSutT", Fila).Value
      Dim result() As DataRow = dtDetSubT.Select(strFiltro)

      For Each row As DataRow In result
        dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), CDec(row(5)).ToString(FCANT), _
          row(6), row(7), row(8), "", CDec(row(10)).ToString(FCANT), row(11), row(12), CDec(row("Reportado")).ToString(FCANT))
      Next

      grSubTareasDet.DataSource = dtFiltrado

      grSubTareasDet.Columns(0).Visible = False : grSubTareasDet.Columns(1).Visible = False
      grSubTareasDet.Columns(2).Visible = False : grSubTareasDet.Columns(7).Visible = False
      grSubTareasDet.Columns(8).Visible = False : grSubTareasDet.Columns(9).Visible = False
      grSubTareasDet.Columns(11).Visible = False : grSubTareasDet.Columns(12).Visible = False
      grSubTareasDet.Columns(6).Visible = False

      'grSubTareasDet.Columns(5).Visible = False


      grSubTareasDet.Columns(3).Width = 300 : grSubTareasDet.Columns(4).Width = 104
      grSubTareasDet.Columns(5).Width = 98 : grSubTareasDet.Columns(7).Width = 100


      grSubTareasDet.Columns(3).HeaderText = "Descripción" : grSubTareasDet.Columns(3).ReadOnly = True
      grSubTareasDet.Columns(4).HeaderText = "Código" : grSubTareasDet.Columns(4).ReadOnly = True
      grSubTareasDet.Columns(5).HeaderText = "Solicitada" : grSubTareasDet.Columns(5).ReadOnly = True
      grSubTareasDet.Columns(10).HeaderText = "Real"
      grSubTareasDet.Columns(13).HeaderText = "Reportado" : grSubTareasDet.Columns(13).ReadOnly = True

      grSubTareasDet.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grSubTareasDet.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grSubTareasDet.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

  End Sub

  Private Sub grSubTareas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grSubTareas.CellEnter
    Call FiltrarDetSubT(e.RowIndex)
  End Sub

  Private Sub grSubTareasDet_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) _
  Handles grSubTareasDet.CellValidating

    Dim cell As DataGridViewTextBoxCell = TryCast(grSubTareasDet(e.ColumnIndex, e.RowIndex), DataGridViewTextBoxCell)

    If e.ColumnIndex = 10 Then 'colST_CantST
      If Not IsDBNull(cell.Value) Then
        If cell IsNot Nothing Then
          If IsNumeric(e.FormattedValue.ToString) = False Then
            MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True

          Else
            'dtDetSubT.Rows(e.RowIndex).Item("Real") = e.FormattedValue

            Dim filaDT As Integer = grSubTareasDet.Item(11, e.RowIndex).Value
            dtDetSubT.Rows(filaDT).Item("Editado") = "SI"
            grSubTareasDet.Item(12, e.RowIndex).Value = "SI"
            dtDetSubT.Rows(filaDT).Item("Real") = e.FormattedValue
            'grSubTareas.Item("colEditado", filaDT).Value = "SI"


          End If

        End If
      End If
    End If
  End Sub

  Private Sub grSubTareas_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grSubTareas.CellValidating
      Dim cell As DataGridViewTextBoxCell = TryCast(grSubTareas(e.ColumnIndex, e.RowIndex), DataGridViewTextBoxCell)

      If e.ColumnIndex = 5 Then 'colST_CantST

        If cell IsNot Nothing Then
          If IsNumeric(IIf(e.FormattedValue.ToString = "", "0", e.FormattedValue.ToString)) = False Then
            MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            e.Cancel = True
          End If

        End If
      End If

  End Sub


  

  


Private Sub cmbOperarios_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbOperarios.KeyDown
     If e.KeyCode = Keys.F3 Then
            If e.Modifiers = Keys.Control Then
                Call BuscarOperario(cmbOperarios.Text, , True)
            Else
                Call BuscarOperario(cmbOperarios.Text)
            End If

        ElseIf e.KeyCode = Keys.F9 Then
            Call BuscarOperario("%")

            'ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
            '   Call BuscarItem(cmbProducto.Text, , True)
        End If
End Sub

Private Sub BuscarOperario(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional ByVal bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbOperarios.BackColor
        cmbOperarios.BackColor = Color.Yellow
        cmbOperarios.Text = strMensaje  '"Buscando ..."
        cmbOperarios.Refresh()


        Dim dtFiltrado As Data.DataTable


        If bolAvanzada = False Then
          dtFiltrado = dtOperarios.Clone
          strFiltro = "NombreMostrar like '%" & strFiltro & "%'"
          Dim result() As DataRow = dtOperarios.Select(strFiltro)

          For Each row As DataRow In result
            dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5))
            mCnt = mCnt + 1
          Next

          If mCnt = 0 Then
              MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              Call BuscarOperario("%", "Actualizando ...")
          End If

        Else 'ENTRADA AL FILTRO AVANZADO
            'Dim obCntv As New clConectividad

            'strFiltro = "'" & strFiltro & "'"

            'dtFiltrado = obCntv.LlenarDataTable(strCadena, True, "pa_ProductosTerminadosOEnProceso", strFiltro, "dt_ProductosTerminadosOEnProceso")

        End If

        cmbOperarios.DataSource = dtFiltrado
        cmbOperarios.DisplayMember = "Descripcion"

        cmbOperarios.BackColor = mColor
        cmbOperarios.Refresh()
    End Sub




Private Sub cmbOperarios_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperarios.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbOperarios.SelectedItem

    strOperatio_Id = selectedItem("id").ToString

    If My.Settings.ModoDebug = True Then
      lblOperarioID.Text = strOperatio_Id
      lblOperarioID.Visible = True
    Else
      lblOperarioID.Visible = False
    End If

End Sub

  Private Sub btnAdicionarMO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarMO.Click
    Dim objItem As System.Data.DataRowView, strNombreEmpleado As String
    objItem = cmbOperarios.SelectedItem


        strNombreEmpleado = cmbOperarios.Text

        If txtCantMO.Text <> "" Then
            'Dim vlTotal As Decimal
            'vlTotal = CDec(txtCantMO.Text.ToString) * CDec(txtValorHora.Text.ToString)


            Dim strFilaNueva() As String = {strNombreEmpleado.ToString,
                                            CDec(txtCantMO.Text.ToString).ToString(FCANT),
                                            strOperatio_Id
                                            }

            grRecursos.Rows.Add(strFilaNueva)
            txtCantMO.Text = ""
            
        Else
            MessageBox.Show("Debe especificar la cantidad!", "Falta Cantidad", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

        End If
  End Sub

  Private Sub txtCantMO_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCantMO.KeyPress
       If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

          If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

          'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
          '    Call Calcular()
          'End If
  End Sub

  Private Sub grSubTareas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grSubTareas.CellContentClick
    Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)
    Dim currentCell As DataGridViewCell = dataGridView(e.ColumnIndex, e.RowIndex)
    Dim mPorc As Decimal = IIf(dataGridView("colPorc", e.RowIndex).Value = "", 0, dataGridView("colPorc", e.RowIndex).Value)

    If grSubTareas.Columns(e.ColumnIndex).Name = "colAddMO" Then
      If CDec(IIf(grSubTareas.Item("colPorc", e.RowIndex).Value = "", 0, grSubTareas.Item("colPorc", e.RowIndex).Value)) < 100 Then
      'MessageBox.Show("Imprimir")
        Call CargarAddMO(e.RowIndex)
      End If

    Else
        txtPorcNoti.Text = (mPorc * 100).ToString(FCANT)
        mPorcIni = mPorc


        If TypeOf currentCell Is DataGridViewCheckBoxCell Then
            ' Desmarcar todas las otras filas
            For Each row As DataGridViewRow In dataGridView.Rows
                If row.Index <> e.RowIndex Then
                    Dim checkboxCell As DataGridViewCheckBoxCell = DirectCast(row.Cells(e.ColumnIndex), DataGridViewCheckBoxCell)
                    checkboxCell.Value = False
                End If
            Next
        End If
    End If
  End Sub


  Private Sub CargarAddMO(ByVal mFila As Integer)
    Dim Frm As New frmAddMONotificacion

    Frm.GrillaOrigen = grRecursos
    Frm.ShowDialog()
    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
        'Call CargarMaterialesAjustados(mOTCabCotizacion_Id, "OT")
        'MessageBox.Show("Adicionar MO")

        Dim Ff As Integer
        For Ff = 0 To grSubTareas.Rows.Count - 1
          grSubTareas.Item("colNotificar", Ff).Value = False
        Next

        grSubTareas.Item("colNotificar", mFila).Value = True

    End If
  End Sub





  Private Sub txtPorcNoti_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcNoti.Leave
      Dim textoIngresado As String = txtPorcNoti.Text.Trim() ' Obtener el texto ingresado y eliminar espacios en blanco

      If Not String.IsNullOrEmpty(textoIngresado) Then
          'Dim mPorcIni As Integer ' Tu variable mPorcIni aquí
          Dim valorIngresado As Decimal

          If Decimal.TryParse(textoIngresado, valorIngresado) Then
              valorIngresado = valorIngresado / 100

              If valorIngresado < mPorcIni Then
                  MessageBox.Show("El valor ingresado debe ser mayor al porcentaje actual!", "Error porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  txtPorcNoti.Focus()
              ElseIf valorIngresado > 1 Then
                  MessageBox.Show("El valor ingresado no puede ser mayor a 100 %", "Error porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
                  txtPorcNoti.Focus()
              End If
          Else
              MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
              txtPorcNoti.Focus()
          End If
      Else
              MessageBox.Show("Por favor, ingrese un valor numérico válido.", "Error porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
              txtPorcNoti.Focus()

      End If

  End Sub

  Private Sub grSubTareas_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grSubTareas.CellEndEdit
    Dim columnIndex As Integer = e.ColumnIndex
    Dim rowIndex As Integer = e.RowIndex


    If columnIndex = grSubTareas.Columns("colPorc").Index Then ' Suponiendo que quieres validar la segunda columna
        Dim cell As DataGridViewCell = grSubTareas.Rows(rowIndex).Cells(columnIndex)
        Dim newValue As String = cell.Value.ToString()
        Dim oldValue As String = cell.Tag ' Almacena el valor anterior en la propiedad Tag

        ' Validar si el nuevo valor es un número
        Dim isValidNumber As Boolean = Decimal.TryParse(newValue, Nothing)

        If isValidNumber AndAlso oldValue IsNot Nothing Then
            Dim newNumber As Decimal = Decimal.Parse(newValue)
            Dim oldNumber As Decimal

            If oldValue = "" Then
              oldNumber = 0
            Else
              oldNumber = Decimal.Parse(oldValue)
            End If


            ' Validar si el nuevo valor es mayor que el valor anterior
            If newNumber > oldNumber Then
                ' Actualizar el valor en la propiedad Tag para futuras validaciones
                cell.Tag = newValue
                cell.Value = CDec(newValue).ToString(FCANT)
            Else
                'MessageBox.Show("El nuevo valor debe ser mayor que el valor anterior.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
                MessageBox.Show("El valor ingresado debe ser mayor al porcentaje actual!", "Error porcentaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
                ' Restaurar el valor anterior en la celda
                cell.Value = oldValue
            End If
        Else
            MessageBox.Show("El valor ingresado no es un número válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Restaurar el valor anterior en la celda
            cell.Value = oldValue
        End If
    End If



  End Sub


Private Sub btnAnexos_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click

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
                btnGrabar.Visible = True
            End If

            'tbcContenido.SelectedTab = tbcContenido.TabPages("tbpAnexos")
            'btnGrabarAnexos.Enabled = True


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

          obCntv = Nothing
            'Catch ex As Exception
        Catch ex As System.ArgumentException
            If blCargar = True Then
                Process.Start(strImagen).ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.InnerException.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try


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


  Private Sub lstAnexos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnexos.SelectedIndexChanged

    Dim mLista = CType(sender, CheckedListBox)
    Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)
  End Sub


  Private Function GrabarAnexos(ByVal NumOrden As Integer, ByVal CabOrden_Id As Integer) As String
        Dim obCntv As New clConectividad
        Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=47", My.Settings.cnnModProd)
        Dim strMes As String = StrDup(2 - Len(Today.Month.ToString), "0") & Today.Month.ToString
        Dim strRutaOrden As String

        strRutaOrden = NumOrden.ToString 'SIEMPRE SE SABE EL NUMERO DE LA ORDE, POR LO TANTO NO NECESITO GUID

        Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaOrden.ToString
        strRuta = strRuta & strRutaB
        If lstAnexos.CheckedItems.Count > 0 Then
            IO.Directory.CreateDirectory(strRuta)

        End If
        'presento el cuadro para cargar los archivos
        'If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Dim strArchivo As String, Ff As Integer

        For Ff = 0 To lstAnexos.Items.Count - 1
            If lstAnexos.GetItemChecked(Ff) = True Then
                strArchivo = mVctAnexos(Ff + 1).ToString

                Dim strDestino As String
                Dim strInsert As String

                If Ff > mCantAnexosCot - 1 Then 'SOLAMENTE COPIO 
                  strDestino = strRuta & "\" & IO.Path.GetFileName(strArchivo)

                  If System.IO.File.Exists(strDestino) = True Then
                    'Debug.Print(strDestino)

                    strDestino = VBNet.Mid(strDestino, 1, InStrRev(strDestino, ".") - 1) & "_Copia." & VBNet.Mid(strDestino, InStrRev(strDestino, ".") + 1, Len(strDestino) - InStrRev(strDestino, "."))

                  End If
                  mCantAnexosCot = mCantAnexosCot + 1


                  IO.File.Copy(strArchivo, strDestino)
                  strInsert = "insert AnexosNotificacion(Cab_id, RutaArchivo,mguid,Estado ) values (" & CabOrden_Id.ToString & ",'" _
                      & strDestino.ToString & "','" & NumOrden.ToString & "','A')"
                  obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

                Else
                  strDestino = strArchivo
                  If mDocCargado = False Then
                      strInsert = "insert AnexosNotificacion(Cab_id, RutaArchivo,mguid,Estado ) values (" & CabOrden_Id.ToString & ",'" _
                        & strDestino.ToString & "','" & NumOrden.ToString & "','A')"
                      obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)
                  End If
                End If

                'If mDocCargado = False Then
                '  strInsert = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & CabOrden_Id.ToString & ",'" _
                '    & strDestino.ToString & "','" & NumOrden.ToString & "','A')"
                '  obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)
                'End If
            End If
        Next


        GrabarAnexos = strRuta
    End Function

Private toolTip1 As New ToolTip()

'Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
'    ' Agregar columnas al DataGridView
'    DataGridView1.Columns.Add("Column1", "Columna 1")
'    DataGridView1.Columns.Add("Column2", "Columna 2")
'    DataGridView1.Columns.Add("Column3", "Columna 3")
'    DataGridView1.Columns.Add("Column4", "Columna 4")

'    ' Asociar el evento CellMouseEnter al DataGridView
'    AddHandler DataGridView1.CellMouseEnter, AddressOf DataGridView1_CellMouseEnter
'End Sub



End Class