Option Explicit On
Imports Microsoft.Reporting.WinForms
Imports MSSQL = System.Data.SqlClient
Imports System.Configuration
Imports VBNet = Microsoft.VisualBasic


Public Class frmOrdenDeTrabajo
  Private mOrigenDocCargado As String = "OT", mCantAnexosCot As Integer, mEstadoXDefecto As String = "R"
  Private mDocCargado As Boolean = False, mCabCotizacion_Id As Integer, mNumCotiza As Integer = 0, mCabOrden_Id As Integer, mOTCabCotizacion_Id As Integer = 0
  Private mIdNumeroCotizacionRapida As Integer, mNumOrden As String = "%"
  Private obXml As New clManejoXML, mUsuarioId As Integer, mUsuarioId_AsignadoA As Integer
  Private mdtConsulta As DataTable, mRol_Id As Integer
  Private mKeyEnPadre As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private Sep As Char
  Private strCadena As String
  Private mCabMov_Id As String, strNombreProducto As String, strCodInventario As String
  Private strNombreEmpleado As String, strIdentificacion As String
  Private mTotal As Decimal, strIdCliente As String, strNombreCliente As String
  Private mReqID As Integer, intContrato_Id As Integer
  Private mEsNuevo As Boolean, mId As Integer
  Private dtProducto As Data.DataTable
  Private mGuid As String = ""
  Private mVctAnexos As New Collection : Private mVctAnexosNotificacion As New Collection
  Private mTablaAnexos As DataTable : Private mTablaAnexosNotificacion As DataTable
  Private mTblCheckList As DataTable, mTipoOT As String, mModoOTDirecta As Boolean = False
  Private mOTyaImpresa As Boolean
  Private mEstadoDespacho As String
  Private strIdEstadoActual As String, strNombreEstadoActual As String, strEstadoActual As String
  Private mNombreEstadoActual As String, mCntPendiente As Integer
  Private mCabSutT As Integer = -1
  Private mCabSubTEdit As Integer
  Private mCupo As Decimal
  'Private dtDetSubT 'El tipo de dato lo defino al cargar OT
  Private mObProd As New clProduccion
  Private dtDetSubT As Data.DataTable
  'Dim NuevaFila = obProd.TablaDetRemision.NewDetRemisionRow
  Private strOperatio_Id As String
  Private m_Tab As String
  Private mCntAFabricar As Integer, mMultiplicarCantOT As String
  Private TL(2) As ToolTip
  Private mUsuarioAutorizaAddMP As Boolean
  Private mFilaSubTVinculada As Integer


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

  'Private mOTCabCotizacion_Id As Integer

  Public Property KeyEnPadre As String
      Get
        KeyEnPadre = mKeyEnPadre
      End Get
      Set(value As String)
        mKeyEnPadre = value
      End Set
  End Property

  Public Property ModoOTDirecta As Boolean
      Get
        Return mModoOTDirecta
      End Get
      Set(value As Boolean)
        mModoOTDirecta = value
      End Set
  End Property

  Public Property Usuario_Id As Integer
      Get
        Return mUsuarioId
      End Get
      Set(value As Integer)
        mUsuarioId = value
      End Set
  End Property

  Private Sub cmdCargarOT_Click(sender As System.Object, e As System.EventArgs) Handles cmdCargarOT.Click

    Dim Frm As New frmBuscar

    Frm.Text = "Buscar OT"
    Frm.lblDoc.Text = "Numero OT" : Frm.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    Frm.txtDocumento.MaxLength = 10

    Frm.chkTexto.Text = "Alcance"
    Frm.chkFechas.Text = "Fecha   "
    Frm.chkTercero.Text = "Cliente  "

    Frm.txtTexto.Tag = "Alcance"
    Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
    Frm.cmbTercero.Tag = "NombreCliente"

    Frm.strConsultaSQL = "vw_buscarOT" : Frm.strCamposSQL = "*"

    Frm.ShowDialog()


    Dim dtConsulta As DataTable

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
      dtConsulta = Frm.dtSeleccionado.Copy
      tssNumeroOT.Text = "OT Número: " & dtConsulta.Rows(0).Item(1)
      txtNumOrden.Text = dtConsulta.Rows(0).Item(1)
      mNumOrden = dtConsulta.Rows(0).Item(1)

      'Call CargarCotizacion(dtConsulta.Rows(0).Item("CabCotizacion_id").ToString, dtConsulta.Rows(0).Item("NumCotizacion").ToString)
      txtAlcanceOT.Text = dtConsulta.Rows(0).Item("Alcance").ToString
      Call CargarCotizacion(CInt(dtConsulta.Rows(0).Item("NumCotizacion").ToString))

      mDocCargado = True
      btnGrabar.Text = "Actualizar"



    End If

    Frm.Dispose()

  End Sub



  Private Sub BuscarCotizacion()

    Dim Frm As New frmBuscar, xNumOrden As Integer, obCntv As New clConectividad

    xNumOrden = obCntv.LeerValorSencillo("valor", "parametros", "id=3", My.Settings.cnnModProd)
    obCntv = Nothing
    Frm.txtDocumento.Text = Strings.Left(xNumOrden, 2) & "*"
    Frm.txtDocumento.MaxLength = 10

    Frm.Text = "Buscar Cotizacion"
    Frm.lblDoc.Text = "Numero Cot" : Frm.txtDocumento.Tag = "NumCotizacion" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    Frm.txtDocumento.MaxLength = 10

    Frm.chkTexto.Text = "Proyecto"
    Frm.chkFechas.Text = "Fecha   "
    Frm.chkTercero.Text = "Cliente  "

    Frm.txtTexto.Tag = "NombreProyecto"
    Frm.dtpFechaIni.Tag = "Fecha" : Frm.dtpFechaFin.Tag = "Fecha"
    Frm.cmbTercero.Tag = "NombreCliente"

    Frm.strConsultaSQL = "vw_RPT_ConsultaCotizaciones" : Frm.strCamposSQL = "NumCotizacion, NombreCliente, NombreProyecto,AsignadoA, Alcance, Estado2, Id"
    Frm.mWhereExterno = "AND Estado ='A'"

    Frm.ShowDialog()
    '

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
          Call FrmInicial()
          mdtConsulta = Frm.dtSeleccionado.Copy
          txtNumCotizacion.Text = mdtConsulta.Rows(0).Item("NumCotizacion")
          tssNumeroCot.Text = "Cotización: " & mdtConsulta.Rows(0).Item("NumCotizacion")
          tssEstadoOT.Text = "Fase Actual: REGISTRO"
          mNumOrden = "%"
          'Call CargarCotizacion(mdtConsulta.Rows(0).Item("Id").ToString)

          Call CargarCotizacion(CInt(mdtConsulta.Rows(0).Item("NumCotizacion")))

          mNumCotiza = mdtConsulta.Rows(0).Item("NumCotizacion").ToString
          txtCntAFabricar.Text = "1"
          btnGrabar.Text = "Grabar" : btnGrabar.Visible = True
    End If

    Frm.Dispose()



  End Sub

  Private Sub rbOpt1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbOpt1.CheckedChanged, rbOpt2.CheckedChanged, rbOpt3.CheckedChanged

    If rbOpt1.Checked = True Then
      btnAccion.Text = "Cargar Cotización" : btnAccion.Top = 14 : btnAccion.Tag = "rbOpt1"
      lblCot.Text = "Cotización Normal"

    ElseIf rbOpt2.Checked = True Then
      btnAccion.Text = "Completar Datos" : btnAccion.Top = 35 : btnAccion.Tag = "rbOpt2"
      lblCot.Text = "Cotización Rapida"

    ElseIf rbOpt3.Checked = True Then
      btnAccion.Text = "Completar Datos" : btnAccion.Top = 58 : btnAccion.Tag = "rbOpt3"
      lblCot.Text = "Cotización Rapida"
    End If



  End Sub

  Private Sub btnAccion_Click(sender As System.Object, e As System.EventArgs) Handles btnAccion.Click

    mOrigenDocCargado = "COT"
    Call FrmInicial()
      Select Case btnAccion.Tag
        Case "rbOpt1"
          Call BuscarCotizacion()

        Case "rbOpt2"
          Call CotizacionRapida()
        Case "rbOpt3"

      End Select
        'btnGrabar.Visible = True
  End Sub



  Private Sub CotizacionRapida()


    Dim frm As New frmSimuladorRapida
    frm.ShowDialog(Me)


    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
      'El número del consecutivo
      Dim obCntv As New clConectividad, NumCotizacion As String, strCadena As String

      strCadena = My.Settings.cnnModProd
      mIdNumeroCotizacionRapida = 6

      NumCotizacion = obCntv.LeerValorSencillo("CONVERT(int,valor) [NumCotizacion]", "NumCotizacion", "Parametros", " ID=" & mIdNumeroCotizacionRapida, strCadena)
      txtNumCotizacion.Text = frm.mNumCotiza
      mNumCotiza = frm.mNumCotiza
            Call CargarCotizacion("", txtNumCotizacion.Text.ToString)
            btnGrabar.Visible = True

    End If

  End Sub





  Private Sub txtNumCotizacion_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumCotizacion.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call CargarCotizacion("", txtNumCotizacion.Text)


    End If


  End Sub

  Private Sub LimpiarCampos()
    lblCliente.Text = ""
    txtAlcance.Text = ""
    txtProyecto.Text = ""
    txtObservacion.Text = ""
    txtObsInterna.Text = ""
  End Sub

  Private Sub brnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    If chkCierreTecnico.Checked = True Then
      Call GrabarCierreTecnico()
    Else

      Call GrabarOT()
      Label55.Visible = False

    End If

    'If m_Tab = "SubTareasNuevas" Then
      '  Call GrabarSubT()
      'End If
  End Sub

  Private Sub GrabarCierreTecnico()
    Dim obCntv As New clConectividad, strInsert As String

   '***** MODIFICO EL ESTATUS DE LA MOTO *****
    Dim strSQLupdate As String = "Estado ='CT'"
    obCntv.ActualizaValor(strSQLupdate, "CabOT", "NumOrden=" & mNumOrden, My.Settings.cnnModProd)


    '**** FINALIZO TODAS LAS ETAPAS ANTERIORES
    strSQLupdate = "EstadoEtapa ='T'"
    obCntv.ActualizaValor(strSQLupdate, "EstadosOT", "Cab_Id=" & mCabOrden_Id, My.Settings.cnnModProd)

    'GRABO LOS ESTADOS
    '1. Cargo el estado con que pudo haber establecido el usuario
    Dim drOt As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabOT", "NumOrden ='" & mNumOrden & "'", My.Settings.cnnModProd)
    Dim mIdEstado As String = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & drOt.Item("Estado").ToString & "'", My.Settings.cnnModProd)
    strInsert = "exec pa_Insert_EstadosOT " & drOt.Item("id").ToString & "," & mIdEstado & "," & mUsuarioId & ",'P'"
    obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

    chkCierreTecnico.Checked = False

  End Sub


  Private Sub GrabarSubT()
    Dim Ff As Integer
    Dim mObCntv As New clConectividad, mCab_Id As Integer

    'Inactivo todo para preveer los eliminados
    Dim strCadena As String

    strCadena = "UPDATE CabSubT SET Estado ='I'	WHERE OT_Cab_ID =" & mOrdenDeTrabajo.CabOrden_Id & " and Tipo='ST' and Estado ='A'"
    mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

    strCadena = "UPDATE DetSubT SET Estado ='I' FROM CabSubT C JOIN DetSubT D ON C.Id = D.Cab_Id WHERE OT_Cab_ID =" & mOrdenDeTrabajo.CabOrden_Id & " and c.Tipo='ST' and c.Estado ='A'"
    mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

    Dim mOperario_Id As Integer = 0
    Dim mMaxItem As Integer = mObCntv.LeerValorSencillo("ISNULL(Max(item) +1,1) as [Item]", "Item", "CabSubT", "Tipo='ST' and OT_Cab_ID = " & mCabOrden_Id, My.Settings.cnnModProd)



    'RECORRO CADA SUBTAREA DE LA GRILLA
    For Ff = 0 To grSubTareas.RowCount - 1
      If grSubTareas.Item("Col_mCabSutT", Ff).Value < 0 Then 'por aca entran las nuevas sub tareas
          mCab_Id = mObCntv.LeerValorSencillo("ISNULL(MAX(id)+1,1) [MaxCabId]", "MaxCabId", "CabSubT", "1=1", My.Settings.cnnModProd)
          mOperario_Id = grSubTareas.Item("colOperario_Id", Ff).Value


          'PREPARO EL ID DEL DETALLE A USAR DENTRO DE LA CLASE, CON BASE EN EL NUMERO DE LA CABECERA
          mObProd.MaxDetId = mObCntv.LeerValorSencillo("ISNULL(max(Id) +1,1) as [MaxId]", "MaxId", "DetSubT", "Cab_ID = " & mCab_Id, My.Settings.cnnModProd)

          If grSubTareas.Item("colSubTVinvulada", Ff).Value = "" Then

            mObProd.GrabarSubTarea(My.Settings.cnnModProd, "INSERT", grSubTareas.Item("Col_mCabSutT", Ff).Value, mCab_Id, mCabOrden_Id, _
              grSubTareas.Item("colDescSubT", Ff).Value, Date.Now, grSubTareas.Item("colSubTAsignadaA", Ff).Value, "A", "ST", _
              grSubTareas.Item("col_Horas", Ff).Value, mOperario_Id, mMaxItem)
            grSubTareas.Item("CabSubT_Id", Ff).Value = mCab_Id
          Else
            Dim mSubTVinvulada As Integer

            'If grSubTareas.Item("colSubTVinvulada", Ff).Value <> "0" Then
                mSubTVinvulada = CInt(grSubTareas.Item("CabSubT_Id", CInt(grSubTareas.Item("colSubTVinvulada", Ff).Value)).Value)
            'End If


            mObProd.GrabarSubTarea(My.Settings.cnnModProd, "INSERT", grSubTareas.Item("Col_mCabSutT", Ff).Value, mCab_Id, mCabOrden_Id, _
                grSubTareas.Item("colDescSubT", Ff).Value, Date.Now, grSubTareas.Item("colSubTAsignadaA", Ff).Value, "A", "ST", _
                grSubTareas.Item("col_Horas", Ff).Value, mOperario_Id, mMaxItem, mSubTVinvulada)



          End If
          mMaxItem = mMaxItem + 1

      Else
        'DESCARTO LAS SUB TAREAS NOTIFICADAS Y PROGRAMADAS
        If (grSubTareas.Item("colCabSubT_Estado", Ff).Value = "A" Or grSubTareas.Item("colCabSubT_Estado", Ff).Value = "ACTIVA") Then

          strCadena = "UPDATE CabSubT SET Estado ='A'	WHERE OT_Cab_ID = " & mOrdenDeTrabajo.CabOrden_Id & " AND ID = " & grSubTareas.Item("Col_mCabSutT", Ff).Value
          mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

          strCadena = "UPDATE DetSubT SET Estado ='A' FROM CabSubT C JOIN DetSubT D ON C.Id = D.Cab_Id WHERE OT_Cab_ID =" & mOrdenDeTrabajo.CabOrden_Id & " AND Cab_ID = " & grSubTareas.Item("Col_mCabSutT", Ff).Value
          mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

          mCab_Id = grSubTareas.Item("CabSubT_Id", Ff).Value

          'PREPARO EL ID DEL DETALLE A USAR DENTRO DE LA CLASE, CON BASE EN EL NUMERO DE LA CABECERA
          mObProd.MaxDetId = mObCntv.LeerValorSencillo("ISNULL(max(Id) +1,1) as [MaxId]", "MaxId", "DetSubT", "Cab_ID = " & mCab_Id, My.Settings.cnnModProd)

          mObProd.GrabarSubTarea(My.Settings.cnnModProd, "UPDATE", grSubTareas.Item("Col_mCabSutT", Ff).Value, mCab_Id, mCabOrden_Id, _
            grSubTareas.Item("colDescSubT", Ff).Value, Date.Now, grSubTareas.Item("colSubTAsignadaA", Ff).Value, "A", "ST", _
            grSubTareas.Item("col_Horas", Ff).Value, mOperario_Id, mMaxItem)
          mMaxItem = mMaxItem + 1

        End If
      End If
    Next

  End Sub


  Private Sub CerrarOT()
    Dim strCadena As String = "" ', Ff As Integer
    Dim obCntv As New clConectividad

   
    strCadena = "Estado='CT'"

    strCadena = "update cabOT set " & strCadena & " where id = " & mCabOrden_Id

    obCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)


  End Sub


  Private Sub GrabarOT(Optional mOptInvocador As String = "") 'poner parametro de quien llama

      Dim strCadena As String = My.Settings.cnnModProd
      Dim obProduccion As New clProduccion
      Dim obCntv As New clConectividad, strInsert As String, NuevoID As String

      If txtCntAFabricar.Text = "" Then txtCntAFabricar.Text = "1"
      If txtCupo.Text = "" Then txtCupo.Text = "0"

      mCntAFabricar = CInt(txtCntAFabricar.Text)
      mCupo = CDec(txtCupo.Text)



      '************************************************
      '*** REGISTRO NUEVO
      '************************************************
      If mDocCargado = False Then
            Dim strFechaSys As Date = Today.Date, bkEstadoXDefecto As String = mEstadoXDefecto
             mEstadoXDefecto = "R" 'POR DEFINICION TODO SE GRABA EN ESTADO R

            'SE GRABA EL REGISTRO DE ORDEN DE TRABAJO EN LA TABLA CABOT
            Dim NumOrden As String
            NumOrden = obCntv.LeerValorSencillo("CONVERT(int,valor)+1 [NumOrden]", "NumOrden", "Parametros", " ID=16", strCadena)

            obProduccion.GrabarCabOT(strCadena, NumOrden, mCabCotizacion_Id, String.Format("{0:G}", DateTime.Now), dtpFechaInicio.Value, dtpFechaFin.Value, _
                                     txtAlcanceOT.Text, mEstadoXDefecto, chkPlanos.Checked, mOTCabCotizacion_Id, txtOCCliente.Text, mCntAFabricar, _
                                     txtTaller.Text, txtMunicipio.Text, mEstadoDespacho, txtObs.Text, mCupo)

            obCntv.EjecutaComando("update Parametros set Valor='" & NumOrden.ToString & "' where id=16", strCadena, False)
            NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabOT", "id > 0", strCadena)

            Call GrabarProductosOT("")
            mDocCargado = True
            mNumOrden = NumOrden
            tssNumeroOT.Text = "Número OT: " & NumOrden.ToString


            'ONYX: GRABO LOS ANEXOS DE LA ORDEN DE TRABAJO
            If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then
              Call GrabarAnexos(mNumOrden, NuevoID)
            End If

            Dim strSQLupdate As String

            strSQLupdate = "AsignadoA='" & cmbAsignadaA.Text.ToString & "', NombreProyecto='" & txtProyectoOT.Text _
                & "', Alcance='" & txtAlcanceOT.Text & "'"

            obCntv.ActualizaValor(strSQLupdate, "CabCotizacion", "Tipo='OT' and numCotizacion=" & mNumCotiza.ToString & " and id=" & mOTCabCotizacion_Id.ToString, My.Settings.cnnModProd)
            obCntv.ActualizaValor("OTCabCotizacion_Id=" & mOTCabCotizacion_Id.ToString, "CabOT", "NumOrden =" & mNumOrden.ToString, My.Settings.cnnModProd)
            mDocCargado = True


            'SE PREGUNTA SI SE DESEA PASAR A LA SIGUIENTE FASE: VALIDADO O PLANOS Y MATERIALES
            Dim mIdEstado As String
            mIdEstado = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & mEstadoXDefecto & "'", My.Settings.cnnModProd)

            If MessageBox.Show(obXml.LeerValor("preguntaMsjPregTerminaRegistroParte1") & NumOrden.ToString & vbCrLf & vbCrLf & obXml.LeerValor("preguntaMsjPregTerminaRegistroParte2") _
              & UCase(obCntv.LeerValorSencillo("Titulo", "Estados", "id=8", My.Settings.cnnModProd)), _
              obXml.LeerValor("tituloMsjPregTerminaRegistro"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then

              'ENTRA SI DESEA SEGUIR EDITANDO
              'GRABO LOS ESTADOS
              strInsert = "exec pa_Insert_EstadosOT " & NuevoID & "," & mIdEstado & "," & mUsuarioId & ",'P'"
              obCntv.EjecutaComando(strInsert, strCadena, False)
              grpTipoCot.Enabled = False : txtNumCotizacion.Enabled = False : mDocCargado = True

              Dim xNumOrden As Integer = mNumOrden

              Call FrmInicial()
              Call CargarOT(xNumOrden)

            Else
              'ACA ENTRA SI HA RESPOSPONDIDO QUE PASA A LA SIGUIENTE FASE
              'MARCO EL CAMPO ESTADO CON EL CUAL QUEDA LA OT EN ESTE MOMENTO
              'INSERTO EL REGISTRO EN ESTADOSOT PARA INIDICAR QUIEN Y CUANDO SE MODIFICO y SI EL ESTADO DE LA ETAPA SE HA TERMINADO O SI ES PARCIAL (CASO PROYECTOS GRANDES)
              obProduccion.ActualizarOT(strCadena, mNumOrden, mCabCotizacion_Id, String.Format("{0:G}", DateTime.Now), _
              dtpFechaInicio.Value, dtpFechaFin.Value, txtAlcanceOT.Text, "V", chkPlanos.Checked, mOTCabCotizacion_Id, _
              mCntAFabricar, txtCupo.Text)

              strSQLupdate = "AsignadoA='" & cmbAsignadaA.Text.ToString & "', NombreProyecto='" & txtProyectoOT.Text _
                & "', Alcance='" & txtAlcanceOT.Text & "'"

              obCntv.ActualizaValor(strSQLupdate, "CabCotizacion", "Tipo='OT' and numCotizacion=" & mNumCotiza.ToString & " and id=" & mOTCabCotizacion_Id.ToString, My.Settings.cnnModProd)

              NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabOT", "id > 0", strCadena)

              'GRABO LOS ESTADOS
              strInsert = "exec pa_Insert_EstadosOT " & NuevoID & "," & mIdEstado & "," & mUsuarioId & ",'T'"
              obCntv.EjecutaComando(strInsert, strCadena, False)

              'NOTIFICAR
              'PONER ACA LA CLASE DE NOTIFICACIONES
              Dim obNotifica As New clNotificaciones, mUsuarioEnvia As String, mUsuarioDestino As String
              mUsuarioEnvia = Environment.UserDomainName & "\" & Environment.UserName

              If mUsuarioId_AsignadoA = "0" Then
                mUsuarioDestino = mUsuarioId_AsignadoA
              Else
                mUsuarioDestino = obCntv.LeerValorSencillo("dominio +'\'+usuario [Usuario]", "Usuario", "Usuarios", "id=" & mUsuarioId_AsignadoA, strCadena)
              End If

              Dim mMensaje As String = "Se ha registrado la OT número " & mNumOrden.ToString & " con la cotización " & mNumCotiza.ToString _
                & " asignada a " & lblAsignadaA.Text

              obNotifica.GrabarNotificacion(strCadena, "frmOT", mUsuarioEnvia, mUsuarioDestino, String.Format("{0:G}", DateTime.Now), "A", "E", "OT Registrada", mMensaje)

              'IMPRIMIR
              'PONER CODIGO PARA IMPRIMIR

              'LIMPIAR FORMULARIO, VOLVERLO A SU ESTADO INICIAL
              Call FrmInicial() 'LimpiarFrm()

              mEstadoXDefecto = bkEstadoXDefecto
            End If

      '************************************************
      '*** REGISTRO CARGADO
      '*** ACA ENTRA SI EL REGISTRO DE OT EN PANTALLA FUE CARGADO. 
      '*** ESTA PARTE NO SE HACE NADA DE LOS ESTADOS, PARA ESO ESTA BOTON SIGUIENTE FASE
      '************************************************
      Else
        Dim mPlanos As String

        If chkPlanos.Checked = True Then
          mPlanos = "1"
        Else
          mPlanos = "0"
        End If

        Try
            If mModoOTDirecta = False Then
                'Dim mStrActualiza As String = "Planos=" & mPlanos & ", Estado='" & mEstadoXDefecto & "'"
                Dim mStrActualiza As String = "Planos=" & mPlanos & ", Estado='" & strEstadoActual & "'"

                mStrActualiza = mStrActualiza & ",Obs='" & txtObs.Text & "', Taller='" & txtTaller.Text & "', Municipio='" & txtMunicipio.Text & "'" & ", ValAdicional= " & mCupo
                obCntv.ActualizaValor(mStrActualiza, "CabOT", "numOrden=" & mNumOrden, My.Settings.cnnModProd)

                '***** INSERTO LAS FACTURAS DEL CIERRE *****
                Dim mStrFacturas As String = "delete from FacturasOT where CabOT_Id = " & mCabOrden_Id.ToString
                obCntv.EjecutaComando(mStrFacturas, My.Settings.cnnModProd, False)

                For fF As Integer = 0 To grFacturasOT.Rows.Count - 1
                  mStrFacturas = mCabOrden_Id.ToString & ", '" & grFacturasOT.Item("colFacNumFactura", fF).Value.ToString & "','" _
                         & grFacturasOT.Item("colFacFechaFactura", fF).Value.ToString & "', " _
                         & TxtADec(grFacturasOT.Item("colFacValor", fF).Value.ToString)
                  obCntv.InsertarValor(mStrFacturas, "FacturasOT", My.Settings.cnnModProd)
                Next fF


                '***** MODIFICO EL INGENIERO ASIGNADO *****
                Dim strSQLupdate As String = "AsignadoA='" & cmbAsignadaA.Text.ToString & "', NombreProyecto='" & txtProyectoOT.Text _
                  & "', Alcance='" & txtAlcanceOT.Text & "'"

                obCntv.ActualizaValor(strSQLupdate, "CabCotizacion", "Tipo in ('OT','CR') and numCotizacion=" & mNumCotiza.ToString & " and id=" & mOTCabCotizacion_Id.ToString, My.Settings.cnnModProd)


                '****** REPENSAR CON BASE EN EL ESTADO ACTUAL QUE PONGA EL USUARIO ASISTENTE DE PRODUCCIÓN

                'GRABO LOS ESTADOS
                '1. Cargo el estado con que pudo haber establecido el usuario
                Dim drOt As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabOT", "NumOrden ='" & mNumOrden & "'", My.Settings.cnnModProd)
                Dim mIdEstado As String = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & drOt.Item("Estado").ToString & "'", My.Settings.cnnModProd)
                strInsert = "exec pa_Insert_EstadosOT " & drOt.Item("id").ToString & "," & mIdEstado & "," & mUsuarioId & ",'P'"
                obCntv.EjecutaComando(strInsert, strCadena, False)



                'Agrego estados
                If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then
                  Call GrabarAnexos(mNumOrden, mCabOrden_Id)
                End If

                'SECCIÓN DE SUBTAREAS
                If m_Tab = "SubTareasNuevas" Then
                  Call GrabarSubT()
                End If

                'SECCIÓN BITACORA
                Call GrabarBitacora()



                Dim mMensaje As String = "Datos actualizados con éxito" & vbCrLf & vbCrLf & "Desea seguir editando la OT " & mNumOrden.ToString
                If chkCerrarOT.Checked = True Then
                  Call CerrarOT()
                  mMensaje = "OT número " & mNumOrden.ToString & " cerrada con éxito!"
                End If

                If mOptInvocador = "" Then 'COLOCAR ACA SI DESEA SEGUIR EDITANDO
                  If chkCerrarOT.Checked = False Then
                    If MessageBox.Show("Datos actualizados con éxito" & vbCrLf & vbCrLf & "Desea seguir editando la OT " & mNumOrden.ToString, "Datos Actualizados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                          Dim xNumOrden As Integer = mNumOrden
                          Call FrmInicial()
                          Call CargarOT(xNumOrden)
                    Else
                          Call FrmInicial()

                    End If
                  Else
                    MessageBox.Show(mMensaje, "OT Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Call FrmInicial()
                  End If

                Else
                    btnGrabar.Visible = False
                End If
                'btnGrabar.Visible = False

            Else
                'CUANDO ES PARA GRABAR UNA OTDIRECTA DESDE MATERIALES (CAMBIOS DE ALCANCE)
                Call ActualizarOTVtaDirecta()


            End If
        Catch ex As Exception
          Call ManejoError(Me.Name, "btnGrabar.Click", ex)
          MessageBox.Show("Se ha presentado un error." & vbCrLf & ex.Data.ToString & vbCrLf & ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

     End If

     'mDocCargado = False
     'mOTCabCotizacion_Id = 0


  End Sub

  
  Private Sub frmOT_Disposed(sender As Object, e As System.EventArgs) Handles Me.Disposed
    obXml = Nothing

  End Sub




  Private Sub frmOT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    TL(0) = New ToolTip
    TL(0).SetToolTip(Me.Label58, "Materiales propuestos en la cotización")

    TL(1) = New ToolTip
    TL(1).SetToolTip(Me.Label59, "AIU de materiales cotizados")
    flyPanelBotones.Width = 190
    tbcContenido.Width = Me.Width - 190 - 21

    'Cambia el modo de las columnas de ajuste de materiales
    'Call ModoVistaAjusteMP()


    'UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then


    'grReportar.AutoGenerateColumns = False
    m_Tab = ""
    Dim obCntv As New clConectividad, strCadena As String

    strCadena = My.Settings.cnnModProd
    If mModoOTDirecta = False Then mDocCargado = False

    'Parámetro para saber si se multiplica por la cantidad de la OT los materiales de la cotización
    mMultiplicarCantOT = UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='MultiplicarCantOT'", My.Settings.cnnModProd))

    'El objeto general para leer el XML
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiOT.xml")
    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

    Dim mUsuario As String, mDominio As String, obInicio As New clSetUpInicio
    mUsuario = obInicio.Usuario 'Environment.UserName '& Environment.UserName.GetHashCode
    mDominio = obInicio.Dominio  'Environment.UserDomainName
    obInicio = Nothing

    Dim strWhere As String = "dominio='" & mDominio & "' and usuario='" & mUsuario & "'"
    mUsuarioId = obCntv.LeerValorSencillo("id", "Usuarios", strWhere, strCadena)


    'PARTE DE LA CARGA DE LOS REPONSABLES
    cmbAsignadaA.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Responsables", "Estado='A' and Id>0")
    cmbAsignadaA.DisplayMember = "Nombre"

    'PARTE DE LA CARGA DE LOS OPERARIOS
    cmbOperarios.DataSource = obCntv.LlenarDataTable(strCadena, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
    cmbOperarios.DisplayMember = "NombreMostrar"

    'CARGA EL LISTADO DE ESTADOS DE OT
    cmbEstadoActual.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Estados", "TipoDoc ='OT' and id>=16")
    lblEstadoActual.Text = "" 'strEstadoActual
    cmbEstadoActual.DisplayMember = "Nombre"


    'VERIFICACIÓN DE LOS PERMISOS DEL USUARIO
    'ROLES 7 Y 8 SON LOS PERMITIDOS PARA VALIDAR (GERENCIA PRODUCCION Y PLANEADOR)
    Dim drRoles As Data.DataTable
    drRoles = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Roles_X_Usuario", _
       "Usuario_Id =" & mUsuarioId.ToString & " and rol_id in (7,8)", "")

    If drRoles.Rows.Count > 0 Then
      chkPlanos.Visible = True
      mEstadoXDefecto = "V"
    Else
      chkPlanos.Visible = False
      cmdCargarOT.Top = 47
      mEstadoXDefecto = "R"
    End If

    'BOTONES PARA SUBTAREAS Y MAS MATERIAL
    drRoles = Nothing
    drRoles = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_PermisosUsuarioXBoton", _
       "frm='frmOrdenDeTrabajo' and objeto IN ('btnMasMaterial2','btnMasMaterial') and Usuario_Id =" & mUsuarioId.ToString & " and rol_id =8 and template='Load'", "")

    If drRoles.Rows.Count > 0 Then
      btnMasMaterial.Visible = True
      btnMasMaterial2.Visible = True
    Else
      btnMasMaterial.Visible = False
      btnMasMaterial2.Visible = False
    End If

    'Debug.Print(Now)
    Call NombrarBotones()
    'Call CargaPerfilServicios()

    If HabilitarSeccionCierre(tbcCerrarOT, Usuario_Id) = False Then
      'tbcContenido.TabPages("tbcCerrarOT").Enabled = False 'HabilitarSeccionCierre(tbcCerrarOT, Usuario_Id)
      tbcContenido.TabPages.Remove(tbcCerrarOT)
    End If

    'HAGO EL CONTROL DE IMPRESION CON LA CARGA DE LA OT, NO A LA CARGA DEL FORUMULARIO
    'Call Habilitar_btnImprimir()
    'Debug.Print(Now)


  End Sub

  Private Sub CargaPerfilServicios()
    Dim objCntv As New clConectividad

    Dim drObjetosXRol As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "ObjetosXRol", "Frm ='frmOrdenDetrabajo' and Template ='Serv' and visible=0", My.Settings.cnnModProd)

      Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
        If drObjetosXRol.HasRows = True Then
          'tbcContenido.TabPages(drObjetosXRol.Item("Objeto").ToString)
          tbcContenido.TabPages.Remove(tbcContenido.TabPages(drObjetosXRol.Item("Objeto").ToString))
        End If
      Loop While drObjetosXRol.Read()


  End Sub





  Private Function HabilitarSeccionCierre(mBoton As Control, xUsuario_Id As Integer) As Boolean

   'Private Function MostrarBoton(mBoton As Button, xUsuario_Id As Integer) As Boolean
        Dim mCantidad As Integer, obCntv As New clConectividad
        Dim mWhere As String, drCantidad As MSSQL.SqlDataReader
        HabilitarSeccionCierre = False
        mWhere = "FRM='" & Me.Name & "' AND Template='Load' and objeto='" & mBoton.Name & "' and usuario_id=" & xUsuario_Id.ToString _
          & " AND LikeUsuario_Id ='" & xUsuario_Id.ToString & "'"

        'mCantidad = obCntv.LeerValorSencillo("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)

        drCantidad = obCntv.LeerValor("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)


        If drCantidad.HasRows Then
            mCantidad = drCantidad.Item("Cantidad")
            If mCantidad > 0 Then
                HabilitarSeccionCierre = True : mBoton.Tag = "SI"
            Else
                HabilitarSeccionCierre = False : mBoton.Tag = "NO"
            End If
        End If

        obCntv = Nothing



  End Function

   Private Sub NombrarBotones()
      Dim mColores = Split(obXml.LeerValor("ColorFondoFrm"), ",")
      Me.Text = obXml.LeerValor("frmTitulo")

      tbpRegistroOT.BackColor = Color.FromArgb(CInt(mColores(0)), CInt(mColores(1)), CInt(mColores(2)))

      'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
      If Me.Tag IsNot Nothing Then
        Me.Tag.TEXT = Me.Text
      End If

  End Sub



  Private Sub txtNumOrden_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtNumOrden.KeyPress

          If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
          If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True
  End Sub


  Private Sub txtNumOrden_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumOrden.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call CargarOT(txtNumOrden.Text)
    End If


  End Sub


  Public Sub CargarOT(NumOT As String)
    Dim obCntv As New clConectividad
    Dim dtConsulta As DataTable

    dtConsulta = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_buscarOT", "NumOrden=" & NumOT)

    If dtConsulta.Rows.Count > 0 Then

      tssNumeroOT.Text = "OT Número: " & dtConsulta.Rows(0).Item(1)
      txtNumOrden.Text = dtConsulta.Rows(0).Item(1)
      mNumOrden = NumOT
      txtAlcanceOT.Text = dtConsulta.Rows(0).Item("Alcance").ToString
      mCabOrden_Id = dtConsulta.Rows(0).Item("id").ToString

      'Call CargarCotizacion(dtConsulta.Rows(0).Item("CabCotizacion_id").ToString, dtConsulta.Rows(0).Item("NumCotizacion").ToString)
      Call CargarCotizacion(CInt(dtConsulta.Rows(0).Item("NumCotizacion").ToString), CInt(mNumOrden))
      txtCntAFabricar.Text = dtConsulta.Rows(0).Item("CntAFabricar").ToString

      Dim mBoton As Button = Me.Tag
      If mModoOTDirecta = False Then
          mBoton.Text = Me.Text & " " & mNumOrden
      End If

      'ONYX 2022 06 11 USO LA ESTRUCTURA PARA ALMACENAR LOS DATOS DE OT
      With mOrdenDeTrabajo
        .CabCotizacion_id = dtConsulta.Rows(0).Item("CabCotizacion_Id")   'mCabCotizacion_Id
        .CabOrden_Id = dtConsulta.Rows(0).Item("Id")  'mCabOrden_Id
        .NumOrden = dtConsulta.Rows(0).Item("NumOrden")
        .OTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id") 'mOTCabCotizacion_Id

      End With

       

        If dtConsulta.Rows(0).Item("TipoCot").ToString = "CR" Then
            stTipoOrigen.Text = "VENTA DIRECTA"
        Else
            stTipoOrigen.Text = "COTIZACION NORMAL"
        End If


        'LLAMO EL CONTROL DE ESTADOS
        Call CargaEstados(mNumOrden)

        Call HabilitarCierreOT(mNumOrden)

         'CARGO EL PRESUPUESTO DE AJUSTE DE MATERIALES
        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarPresupuetoMateriales..." & vbCrLf
        Call CargarPresupuestoMateriales()

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarMaterialesAjustados..." & vbCrLf
        Call CargarMaterialesAjustados(mOTCabCotizacion_Id, "OT")

        Call HabilitaEdicionPresupuesto(Usuario_Id)
        Call CargaSubTareas(mCabOrden_Id)
        Call CargarNotificaciones()

        btnGrabar.Text = "Actualizar"
        mDocCargado = True
        btnGrabar.Text = "Actualizar"
        btnSigFase.Visible = True
        btnImprimir.Visible = True
        btnGrabar.Visible = True

    Else
      MessageBox.Show("Número de OT no encontrada!", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End If


    obCntv = Nothing

  End Sub

  Private Function VerificaUsuario() As Integer
    Dim drRoles As Data.DataTable, obCntv As New clConectividad

  'VERIFICACIÓN DE LOS PERMISOS DEL USUARIO
    drRoles = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Roles_X_Usuario", "Usuario_Id =" & mUsuarioId.ToString & " and rol_id in (7,8)", "")

    If drRoles.Rows.Count > 0 Then
      chkPlanos.Visible = True
    Else
      chkPlanos.Visible = False
      cmdCargarOT.Top = 47

    End If

    Dim Ii As Integer
    For Ii = 0 To drRoles.Rows.Count - 1
      Select Case drRoles.Rows(Ii).Item("Rol_Id")
        Case 6 'Aux de produccion
          chkPlanos.Visible = False
          cmdCargarOT.Top = 47

        Case 7, 8 'Planeador y Gerente
          chkPlanos.Visible = True
          btnSiguienteFase.Visible = True

        Case 1 'Ingeniero
          btnAccion.Enabled = False
          txtNumOrden.Enabled = False
          chkPlanos.Enabled = False
          cmdCargarOT.Enabled = False
          btnGrabar.Enabled = False
          btnSiguienteFase.Enabled = True

        Case Else
          MessageBox.Show("No esta autorizado!", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error)
          'pensar en la anulación de la salida

      End Select

      VerificaUsuario = drRoles.Rows(Ii).Item("Rol_Id") ' PARA LA SALIDA
    Next


    'If drRoles.Rows.Count > 0 Then
    '  chkPlanos.Visible = True
    'Else
    '  chkPlanos.Visible = False
    '  cmdCargarOT.Top = 47

    'End If

    drRoles = Nothing
    obCntv = Nothing

  End Function


  Private Sub btnSiguienteFase_Click(sender As System.Object, e As System.EventArgs) Handles btnSiguienteFase.Click
    'HACER INSERT DE LOS ESTADOS

    'LLAMAR CLASE DE NOTIFICACIONES

     ''GRABO LOS ESTADOS
     '   Dim strInsert As String
     '   mNumOrden

     '   strInsert = "exec pa_Insert_EstadosOT " & mca & ",7," & mUsuarioId
     '   obCntv.EjecutaComando(strInsert, strCadena, False)

     '   'NOTIFICAR
     '   'PONER ACA LA CLASE DE NOTIFICACIONES
     '   Dim obNotifica As New clNotificaciones, mUsuarioEnvia As String, mUsuarioDestino As String
     '   mUsuarioEnvia = Environment.UserDomainName & "\" & Environment.UserName

     '   If mUsuarioId_AsignadoA = "0" Then
     '     mUsuarioDestino = mUsuarioId_AsignadoA
     '   Else
     '     mUsuarioDestino = obCntv.LeerValorSencillo("dominio +'\'+usuario [Usuario]", "Usuario", "Usuarios", "id=" & mUsuarioId_AsignadoA, strCadena)
     '   End If

     '   Dim mMensaje As String = "Se ha registrado la OT número " & mNumOrden.ToString & " con la cotización " & mNumCotiza.ToString _
     '     & " asignada a " & lblAsignadaA.Text




     '   obNotifica.GrabarNotificacion(strCadena, "frmOT", mUsuarioEnvia, mUsuarioDestino, String.Format("{0:G}", DateTime.Now), "A", "E", "OT Registrada", mMensaje)



  End Sub






  Private Sub frmOT_FormClosed(sender As System.Object, e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        Debug.Print(ex.Message)
      End Try


  End Sub


#Region "FORMAS DE CARGA DE LA COTIZACIÓN - LA CONSUME LA COTIZACION RAPIDA"

  'FORMA 1)
  Private Sub CargarCotizacion(strCab_Id As String, Optional strNumCotizacion As String = "")
    Dim strComando As String, obCntv As New clConectividad, strCadena As String

    strCadena = My.Settings.cnnModProd


    If strNumCotizacion <> "" Then
      Dim strTipo As String

      If strCab_Id = "" Then
        strTipo = "Tipo='CR' AND "
      Else
        strTipo = "Tipo='CN' AND "
      End If

      strCab_Id = obCntv.LeerValorSencillo("id", "CabCotizacion", strTipo & "NumCotizacion='" & strNumCotizacion & "'", strCadena)
      If strCab_Id = "" Then
        MessageBox.Show("Número de cotización no existe!", "No existe documento", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Call LimpiarCampos()
        txtNumCotizacion.Focus()
        Exit Sub

      End If
    End If


    strComando = "pa_RPT_ConsulaCotizacion " & strCab_Id.ToString

    Dim drConsulta As SqlClient.SqlDataReader = _
      obCntv.EjecutaComando(strComando, strCadena, True)

    drConsulta.Read()
    If drConsulta.HasRows = True Then
      lblCliente.Text = drConsulta.Item("NombreCliente").ToString
      lblClienteOT.Text = drConsulta.Item("NombreCliente").ToString

      strIdCliente = drConsulta.Item("IdCliente").ToString
      strNombreCliente = drConsulta.Item("NombreCliente").ToString



      txtAlcance.Text = drConsulta.Item("Alcance").ToString
      txtAlcanceOT.Text = drConsulta.Item("Alcance").ToString
      txtProyecto.Text = drConsulta.Item("NombreProyecto").ToString
      txtProyectoOT.Text = drConsulta.Item("NombreProyecto").ToString

      txtObservacion.Text = drConsulta.Item("Observacion").ToString
      txtObsInterna.Text = drConsulta.Item("ObsInterna").ToString
      txtAlcanceOT.Text = txtAlcance.Text

      lblAsignadaA.Text = drConsulta.Item("AsignadoA").ToString
      mUsuarioId_AsignadoA = drConsulta.Item("Usuario_Id").ToString


      mNumCotiza = drConsulta.Item("NumCotizacion").ToString
      txtNumCotizacion.Text = mNumCotiza.ToString
      mCabCotizacion_Id = strCab_Id
      cmbAsignadaA.Text = drConsulta.Item("AsignadoA").ToString
      txtTmpFabricacion.Text = drConsulta.Item("TiempoFabricacion").ToString

      Dim mNumCotizacion As Integer = drConsulta.Item("NumCotizacion").ToString

      txtTmpEntrega.Text = drConsulta.Item("TiempoEntrega").ToString
      txtReq.Text = drConsulta.Item("Requisicion").ToString
      chkMontaje.Checked = CBool(drConsulta.Item("RequiereMontaje"))
      chkVentaDirecta.Checked = CBool(drConsulta.Item("VentaDirecta"))
      txtDirigidaA.Text = drConsulta.Item("DirigidaA").ToString
      txtFormaPago.Text = drConsulta.Item("FormaPago").ToString
      txtPrecioFinal.Text = CDec(drConsulta.Item("PrecioFinal").ToString).ToString(FCTOTOT)
      txtImprevistos.Text = CDec(IIf(drConsulta.Item("Imprevistos").ToString <> "", drConsulta.Item("Imprevistos").ToString, 0)).ToString(FCTOTOT)
      txtAIU.Text = CInt(drConsulta.Item("AIU").ToString)
      lblEstado.Text = drConsulta.Item("Estado").ToString

      stNumCotizacion.Text = "Cotización: " & mNumCotizacion.ToString & "      "
      txtNumCotizacion.Text = mNumCotizacion.ToString
      stFecha.Text = "Fecha de Registro: " & drConsulta.Item("Fecha").ToString
      mReqID = IIf(drConsulta.Item("Req_Id").ToString = "", 0, drConsulta.Item("Req_Id").ToString)
      txtOC_Cliente.Text = drConsulta.Item("OC_Cliente").ToString

      dtpFechaFin.Value = DateAdd(DateInterval.Day, IIf(drConsulta.Item("TiempoFabricacion") = "", 0, drConsulta.Item("TiempoFabricacion")), dtpFechaInicio.Value)
      mCabCotizacion_Id = drConsulta.Item("id").ToString

      'marzo 22 2016 
      Label28.Text = stNumCotizacion.Text

      mNumCotiza = mNumCotizacion
      mId = drConsulta.Item("id").ToString
      mEsNuevo = False


      If mNumOrden <> Nothing And mNumOrden <> "%" Then
        tssEstadoOT.Text = "Fase actual: " & UCase(obCntv.LeerValorSencillo("FaseActual", "Vw_EstadosOT", "EstadoEtapa='P' AND numOrden=" & mNumOrden.ToString, My.Settings.cnnModProd))
      End If


    End If

  End Sub




  'FORMA 2)
    Private Sub CargarCotizacion(ByVal mNumCotizacion As Integer, Optional xNumOrden As Integer = 0)
      Try
          Dim strCadena As String = My.Settings.cnnModProd
          Dim Cotiza As Integer = mNumCotizacion
            Dim objCntv As New clConectividad ' fF As Integer
          Dim strConsulta As String = "Select "

          'CARGA LA CABECERA

          Dim drCabCotiza As MSSQL.SqlDataReader
          'drCabCotiza = objCntv.LeerValor("*", "VW_CabOT", "NumCotizacion ='" & mNumCotizacion & "' AND NumOrden LIKE '" & mNumOrden.ToString & "'", My.Settings.cnnModProd)
          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - drCabCotiza ..." & vbCrLf
          drCabCotiza = objCntv.LeerValor("*", "DBO.fn_CabOT('" & mNumCotizacion & "','" & mNumOrden.ToString & "')", "1=1", My.Settings.cnnModProd)


          'ONYX - LIMPIEZA DE CAMPOS DE REQUERIMIENTO
          mReqID = 0
          cmbRequerimientos.Text = "" : lblDescReq.Text = ""
          txtOC_Cliente.Text = ""


          strIdCliente = drCabCotiza.Item("IdCliente").ToString
          strNombreCliente = drCabCotiza.Item("NombreCliente").ToString
          'cmbCliente.Text = strNombreCliente
          lblCliente.Text = strNombreCliente
          lblClienteOT.Text = strNombreCliente

          If drCabCotiza.Item("Tipo").ToString = "CR" Then
            txtProyecto.Text = drCabCotiza.Item("OT_NombreProyecto").ToString
            txtAlcance.Text = drCabCotiza.Item("OT_Alcance").ToString
          Else
            txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
            txtAlcance.Text = drCabCotiza.Item("Alcance").ToString

          End If
          txtProyectoOT.Text = drCabCotiza.Item("OT_NombreProyecto").ToString
          txtAlcanceOT.Text = drCabCotiza.Item("OT_Alcance").ToString
          'txtAlcanceOT.Text = drCabCotiza.Item("NombreProyecto").ToString & vbCrLf & vbCrLf & drCabCotiza.Item("Alcance").ToString

          txtObservacion.Text = drCabCotiza.Item("Observacion").ToString
          cmbAsignadaA.Text = drCabCotiza.Item("OT_AsignadoA").ToString
          lblAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString
          txtTmpFabricacion.Text = drCabCotiza.Item("TiempoFabricacion").ToString
          txtTmpEntrega.Text = drCabCotiza.Item("TiempoEntrega").ToString
          txtReq.Text = drCabCotiza.Item("Requisicion").ToString
          chkMontaje.Checked = CBool(drCabCotiza.Item("RequiereMontaje"))
          chkVentaDirecta.Checked = CBool(drCabCotiza.Item("VentaDirecta"))
          txtDirigidaA.Text = drCabCotiza.Item("DirigidaA").ToString
          txtFormaPago.Text = drCabCotiza.Item("FormaPago").ToString
          txtPrecioFinal.Text = CDec(drCabCotiza.Item("PrecioFinal").ToString).ToString(FCTOTOT)
          txtImprevistos.Text = CDec(IIf(drCabCotiza.Item("Imprevistos").ToString <> "", drCabCotiza.Item("Imprevistos").ToString, 0)).ToString(FCTOTOT)
          txtAIU.Text = CInt(drCabCotiza.Item("AIU").ToString)
          lblEstado.Text = drCabCotiza.Item("Estado").ToString
          txtObsInterna.Text = drCabCotiza.Item("ObsInterna").ToString
          stNumCotizacion.Text = "Cotización: " & mNumCotizacion.ToString & "      "
          txtNumCotizacion.Text = mNumCotizacion.ToString
          stFecha.Text = "Fecha de Registro: " & drCabCotiza.Item("Fecha").ToString
          mReqID = IIf(drCabCotiza.Item("Req_Id").ToString = "", 0, drCabCotiza.Item("Req_Id").ToString)
          txtOC_Cliente.Text = drCabCotiza.Item("OC_Cliente").ToString
          mOTCabCotizacion_Id = drCabCotiza.Item("OTCabCotizacion_Id").ToString
          mCabCotizacion_Id = drCabCotiza.Item("id").ToString
          dtpFechaInicio.Value = CDate(drCabCotiza.Item("Fecha").ToString)
          dtpFechaFin.Value = DateAdd(DateInterval.Day, drCabCotiza.Item("TiempoFabricacion"), dtpFechaInicio.Value)




            If drCabCotiza.Item("AIU_MO").ToString = "" Then
                txtAIU_MO.Text = 0
            Else
                txtAIU_MO.Text = CInt(drCabCotiza.Item("AIU_MO").ToString)
            End If

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
          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - grTipoGastos ..." & vbCrLf
          grTipoGastos.DataSource = objCntv.LlenarDataTable(strCadena, "*", _
                                    "fn_TipoGastosGrabados(" & mId.ToString & ")", "0=0")

          Dim miCol As DataGridViewColumn
          miCol = grTipoGastos.Columns(0) : miCol.Width = 20
          miCol = grTipoGastos.Columns(1) : miCol.Width = 80
          miCol = grTipoGastos.Columns(2) : miCol.Width = 80
          miCol.DefaultCellStyle.Format = FCTOTOT : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            miCol = grTipoGastos.Columns(3) : miCol.Width = 20



          'CARGA EL DETALLE
          grProductos.Rows.Clear()
          grEmpleados.Rows.Clear()
          'grProductosDiv.Rows.Clear()
          Dim drDetCotiza As MSSQL.SqlDataReader

          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - drDetCotiza ..." & vbCrLf
          If xNumOrden = 0 Then
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
                      strFilaNueva = {grProductos.Rows.Count + 1,
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
                      grProductos.Rows.Add(strFilaNueva)


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
                      strFilaNueva = {grTipoGastos.Rows.Count + 1,
                                      drDetCotiza.Item("CodInventario").ToString,
                                      CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                      True}
                  Else
                      strFilaNueva = {grEmpleados.Rows.Count + 1,
                                      drDetCotiza.Item("Inventario_ID").ToString,
                                      drDetCotiza.Item("CodInventario").ToString,
                                      CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                      CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                      CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                      True}

                      grEmpleados.Rows.Add(strFilaNueva)

                      'agrego la carga en la grilla de subtareas
                      strFilaNueva = {
                          False,
                          grMoST.Rows.Count + 1,
                          drDetCotiza.Item("Inventario_ID").ToString,
                          drDetCotiza.Item("CodInventario").ToString,
                          CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                          CDec(0).ToString(FCANT)
                      }
                      grMoST.Rows.Add(strFilaNueva)

                  End If
              End If

          Loop While drDetCotiza.Read()

          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - Calcular ..." & vbCrLf
          Call Calcular()

          'CARGO LOS ANEXOS ****************************************************************************
          'ACA VOY A CARGAR LOS ANEXOS DE LA COT CUANDO SEA LA PRIMERA CARGA, ES DECIR CUANDO SE ESTE REGISTRANDO
          'LA OT. POSTERIORMENTE SE CARGARÁN LOS ANEXOS DE LA TABLA ANEXOSOT
          Dim drAnexos As MSSQL.SqlDataReader
          mTablaAnexos = CreaTablaAnexos()
          lstAnexos.Items.Clear() : mVctAnexos.Clear()


          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - drAnexos ..." & vbCrLf
          If mOrigenDocCargado = "OT" Then
            drAnexos = objCntv.LeerValor("*", "AnexosOrden", "Cab_ID =" & mCabOrden_Id.ToString & " and estado in ('A','E')", strCadena)
          Else
            drAnexos = objCntv.LeerValor("*", "AnexosCotizacion ", "Cab_ID =" & mCabCotizacion_Id.ToString & " and estado='A'", strCadena)
          End If
          mCantAnexosCot = 0

          Do
              If drAnexos.HasRows = True Then
                  lstAnexos.Items.Add(IO.Path.GetFileName(drAnexos.Item("RutaArchivo").ToString), True)
                  mVctAnexos.Add(drAnexos.Item("RutaArchivo").ToString)
                  mCantAnexosCot = mCantAnexosCot + 1
                  Dim mFila As DataRow = mTablaAnexos.NewRow
                  mFila.Item("id") = drAnexos.Item("id")
                  mFila.Item("RutaArchivo") = drAnexos.Item("RutaArchivo")
                  mFila.Item("NombreArchivo") = IO.Path.GetFileName(drAnexos.Item("RutaArchivo"))
                  mFila.Item("Estado") = drAnexos.Item("Estado")
                  mTablaAnexos.Rows.Add(mFila)
              End If
          Loop While drAnexos.Read()

          '**********  CARGO LOS ANEXOS DE NOTIFICACIÓN *********************************************
          Call CargarAnexosNotificacion()

          '****************************************************************************************************


          'If mOrigenDocCargado = "OT" Then mCantAnexosCot = 0

          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - CargaImagen ..." & vbCrLf
          'If lstAnexos.Items.Count > 0 Then
          '    Call CargaImagen(mVctAnexos(1).ToString, False)
          'End If

          'EG: ONYX, adicion de pestaña de reporte de estados
          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - dtEstadosCotizacion ..." & vbCrLf
          Dim dtEstadosCotizacion As Data.DataTable = objCntv.LlenarDataTable(strCadena, True, "PA_EstadosOT", mId.ToString & "," & mCabOrden_Id.ToString, "PA_EstadosOT")  '(strCadena, "FECHA, USUARIO, TITULO", "vw_EstadosCotizacion", "Cab_ID =" & mId.ToString)
          grEventos.DataSource = dtEstadosCotizacion
          grEventos.Columns(0).Width = 150 : grEventos.Columns(1).Width = 150
          dtEstadosCotizacion = Nothing


          'PONGO EN ORDEN LOS CONTROLES
          'cmdActualizar.Enabled = True
          btnAprobar.Enabled = True

         'Modificado el 20150411. Se agrega el manejo de estados
          If drCabCotiza.Item("Estado").ToString = "I" Then
              ChkAnulada.CheckState = CheckState.Checked
              ChkAnulada.Enabled = False
              'btnSigFase.Enabled = False
              'cmdActualizar.Enabled = False
          Else
              ChkAnulada.CheckState = CheckState.Unchecked
              ChkAnulada.Enabled = True
          End If

          Call EstableceModoColumnas(grProductos)
          Call EstableceModoColumnas(grEmpleados)
          Call EstableceModoColumnas(grMatST, -1, "22|30|55|435|50|50|50|100|")

      Catch ex As System.InvalidCastException

      Catch ex As Exception
          Call ManejoError(Me.Name, "CargarCotizacion", ex)
          MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


  End Sub


#End Region

  Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
        Dim mImagen As Bitmap

        Try
          Dim obCntv As New clConectividad
          If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then
            If UCase(strImagen).Contains(".PDF") = True Then

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

        If Validacion = False Then
            MessageBox.Show("Existe mano de obra sin cantidad o costo!", "Validación mano de obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Validacion = True
        End If


        ''LOS GASTOS DE MONTAJE
        'If chkMontaje.Checked = True Then
        '    For Ff = 0 To grTipoGastos.RowCount - 1
        '        If grTipoGastos.Rows(Ff).Cells(3).Value = True Then
        '            Dim mCosto As Decimal

        '            mCosto = CDec(IIf(grTipoGastos.Rows(Ff).Cells(2).Value.ToString <> "", grTipoGastos.Rows(Ff).Cells(2).Value.ToString, 0))
        '            numTotal = numTotal + mCosto
        '            numTotalMO = numTotalMO + mCosto


        '            If mCosto = 0 Then
        '                Validacion = False
        '            End If
        '        End If
        '    Next
        'End If

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
        'txtUtilidad.Text = CDec((CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + (CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO)).ToString(FCTOTOT)
        txtUtilidad.Text = CDec((CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + (CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO) + mUtilMontaje).ToString(FCTOTOT)


        'mTotal = (numTotalMP + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + _
        '         (numTotalMO + CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO) + _
        '         CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text))

        mTotal = (numTotalMP + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotalMP) + _
                 (numTotalMO + CDec(IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text)) / 100 * numTotalMO) + _
                 CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) + mUtilMontaje + numTotalMontaje


        lblTotal.Text = CDec(mTotal).ToString(FCTOTOT)




    End Sub





  'Private Sub Calcular()
  '      Dim numTotal As Decimal, Ff As Integer, Validacion As Boolean = True


  '      numTotal = 0
  '      For Ff = 0 To grProductos.RowCount - 1
  '          If grProductos.Rows(Ff).Cells("colAgregar").Value = True Then
  '              Dim mCantidad As Decimal, mCosto As Decimal

  '              mCantidad = CDec(IIf(grProductos.Rows(Ff).Cells(3).Value.ToString <> "", grProductos.Rows(Ff).Cells(3).Value.ToString, 0))
  '              mCosto = CDec(IIf(grProductos.Rows(Ff).Cells(4).Value.ToString <> "", grProductos.Rows(Ff).Cells(4).Value.ToString, 0))

  '              numTotal = numTotal + mCantidad * mCosto
  '              If mCantidad * mCosto = 0 Then
  '                  Validacion = False
  '              End If
  '          End If
  '      Next

  '      lblTotalMateriales.Text = CDec(numTotal).ToString(FCTOTOT)


  '      If Validacion = False Then
  '          MessageBox.Show("Existen productos sin cantidad o costo!", "Validación productos", MessageBoxButtons.OK, MessageBoxIcon.Error)
  '          Validacion = True
  '      End If


  '      Dim numTotalMO As Decimal

  '      For Ff = 0 To grEmpleados.RowCount - 1
  '          If grEmpleados.Rows(Ff).Cells(6).Value = True Then
  '              Dim mCantidad As Decimal, mCosto As Decimal
  '              mCantidad = CDec(IIf(grEmpleados.Rows(Ff).Cells(3).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(3).Value.ToString, 0))
  '              mCosto = CDec(IIf(grEmpleados.Rows(Ff).Cells(4).Value.ToString <> "", grEmpleados.Rows(Ff).Cells(4).Value.ToString, 0))


  '              numTotal = numTotal + mCantidad * mCosto
  '              numTotalMO = numTotalMO + mCantidad * mCosto

  '              If mCantidad * mCosto = 0 Then
  '                  Validacion = False
  '              End If
  '          End If
  '      Next

  '      lblTotalMO.Text = CDec(numTotalMO).ToString(FCTOTOT)

  '      If Validacion = False Then
  '          MessageBox.Show("Existe mano de obra sin cantidad o costo!", "Validación mano de obra", MessageBoxButtons.OK, MessageBoxIcon.Error)
  '          Validacion = True
  '      End If


  '      If chkMontaje.Checked = True Then
  '          For Ff = 0 To grTipoGastos.RowCount - 1
  '              If grTipoGastos.Rows(Ff).Cells(3).Value = True Then
  '                  Dim mCosto As Decimal

  '                  mCosto = CDec(IIf(grTipoGastos.Rows(Ff).Cells(2).Value.ToString <> "", grTipoGastos.Rows(Ff).Cells(2).Value.ToString, 0))
  '                  numTotal = numTotal + mCosto


  '                  If mCosto = 0 Then
  '                      Validacion = False
  '                  End If
  '              End If
  '          Next
  '      End If
  '      If Validacion = False Then
  '          MessageBox.Show("Existe items de montaje sin costo!", "Validación montaje", MessageBoxButtons.OK, MessageBoxIcon.Error)
  '          Validacion = True
  '      End If


  '      numTotal = numTotal + CDec(IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)) _
  '           + CDec(IIf(txtValorMontaje.Text = "", 0, txtValorMontaje.Text))

  '      txtUtilidad.Text = CDec(CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal).ToString(FCTOTOT)
  '      mTotal = numTotal + CDec(IIf(txtAIU.Text = "", 0, txtAIU.Text)) / 100 * numTotal

  '      lblTotal.Text = CDec(mTotal).ToString(FCTOTOT)
  '  End Sub


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

  'USADA PARA CREAR LA COPIA DE LA COTIZACIÓN BASE
  Private Sub GrabarProductosOT(ByVal strMensaje As String)
    Dim _FactorCant As Integer

    btnGrabar.Text = "Grabando..."
    btnGrabar.Enabled = False

    Dim objCalc As New clCalculadora, Ff As Integer, Ff_ID As Integer

    If mMultiplicarCantOT = "SI" Then
      _FactorCant = mCntAFabricar
    Else
      _FactorCant = 1
    End If

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
        NuevaFila("Cant") = TxtADec(grProductos.Item(3, Ff).Value) * _FactorCant  'CDec(IIf(grProductos.Item(3, Ff).Value = 0, 0, grProductos.Item(3, Ff).Value))
        NuevaFila("Costo") = TxtADec(grProductos.Item(4, Ff).Value)   'CDec(IIf(grProductos.Item(4, Ff).Value = 0, 0, grProductos.Item(4, Ff).Value))
        NuevaFila("Inventario_ID") = IIf(grProductos.Item(1, Ff).Value = "", 0, grProductos.Item(1, Ff).Value)
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = TxtADec(grProductos.Item("colCostoTotal", Ff).Value) * _FactorCant  'CDec(IIf(grProductos.Item("colCostoTotal", Ff).Value = 0, 0, grProductos.Item("colCostoTotal", Ff).Value))
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
        NuevaFila("Cant") = TxtADec(grEmpleados.Item(3, Ff).Value) * _FactorCant 'CDec(IIf(grEmpleados.Item(3, Ff).Value = 0, 0, grEmpleados.Item(3, Ff).Value))
        NuevaFila("Costo") = TxtADec(grEmpleados.Item(4, Ff).Value) 'CDec(IIf(grEmpleados.Item(4, Ff).Value = 0, 0, grEmpleados.Item(4, Ff).Value))
        NuevaFila("Estado") = "A"
        NuevaFila("CostoTotal") = TxtADec(grEmpleados.Item("colValorTotal", Ff).Value) * _FactorCant 'CDec(IIf(grEmpleados.Item("colValorTotal", Ff).Value = 0, 0, grEmpleados.Item("colValorTotal", Ff).Value))
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
      NuevaFila2("Cant") = 1 * _FactorCant
      NuevaFila2("Costo") = TxtADec(txtImprevistos.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = TxtADec(txtImprevistos.Text) * _FactorCant
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
      NuevaFila2("Cant") = 1 * _FactorCant
      NuevaFila2("Costo") = TxtADec(txtUtilidad.Text)
      NuevaFila2("Estado") = "A"
      NuevaFila2("CostoTotal") = TxtADec(txtUtilidad.Text) * _FactorCant
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
          NuevaFila2("Cant") = 1 * _FactorCant
          NuevaFila2("Costo") = TxtADec(filaGrilla.Cells(2).Value)  'txtValorMontaje.Text
          NuevaFila2("Estado") = "A"
          NuevaFila2("Inventario_ID") = filaGrilla.Cells(0).Value.ToString
          NuevaFila2("CostoTotal") = TxtADec(filaGrilla.Cells(2).Value) * _FactorCant

          objCalc.DetCotizacion.AddDetCotizacionRow(NuevaFila2)
          NuevaFila2 = Nothing
        End If

      Next
    End If
    '********************************  FIN DE LA PARTE DE DETALLE DE LA COTIZACION ************




    txtAIU.Text = IIf(txtAIU.Text = "", 0, txtAIU.Text)
    txtImprevistos.Text = IIf(txtImprevistos.Text = "", 0, txtImprevistos.Text)

    Dim strPrecioFinal As Single, strImprevistos As Single

    If txtPrecioFinal.Text = "" Then
      strPrecioFinal = 0
    Else
      strPrecioFinal = CType(txtPrecioFinal.Text, Single) * _FactorCant
    End If

    If txtImprevistos.Text = "" Then
      strImprevistos = 0
    Else
      strImprevistos = CType(txtImprevistos.Text, Single) * _FactorCant
    End If


    'El número del consecutivo
    Dim obCntv As New clConectividad
    Dim NumCotizacion As String
    NumCotizacion = mNumCotiza.ToString


    Dim drCabProdOT As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabCotizacion", "NumCotizacion='" & NumCotizacion & "' and tipo='OT'", My.Settings.cnnModProd)
    Dim NuevoID

    If mDocCargado = False Then 'REGISTRO DE OT TOTALMENTE NUEVO

        objCalc.GrabarCotizacion(My.Settings.cnnModProd, dtpFecha.Value, txtObservacion.Text, strIdCliente, strNombreCliente, _
          txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
          txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, NumCotizacion.ToString, cmbAsignadaA.Text, IIf(lblTotal.Text = "", 0, lblTotal.Text), strPrecioFinal, _
          chkVentaDirecta.Checked, txtAIU.Text, strImprevistos, "R", txtObsInterna.Text, "OT", 0, "", 0, IIf(txtAIU_MO.Text = "", 0, txtAIU_MO.Text), mCntAFabricar)


        NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", My.Settings.cnnModProd)
        mOTCabCotizacion_Id = NuevoID
        'GRABO LOS ESTADOS
        Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        'strInsert = "Insert EstadosCotizacion values (" & NuevoID & ",1,'" & strHoy & "'," & mUsuarioId & ")"
        strInsert = "exec pa_Insert_EstadosCotizacion " & NuevoID & ",1," & mUsuarioId
        obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)



    Else
      If drCabProdOT.HasRows = False Then
        'HABILITAR
        objCalc.GrabarCotizacion(My.Settings.cnnModProd, dtpFecha.Value, txtObservacion.Text, strIdCliente, strNombreCliente, _
              txtProyecto.Text, txtAlcance.Text, txtTmpFabricacion.Text, txtTmpEntrega.Text, chkMontaje.CheckState, txtReq.Text, _
              txtDirigidaA.Text, txtAviso.Text, txtFormaPago.Text, NumCotizacion.ToString, cmbAsignadaA.Text, lblTotal.Text, strPrecioFinal, _
              chkVentaDirecta.Checked, txtAIU.Text, strImprevistos, "R", txtObsInterna.Text, "OT", 0, "", 0, txtAIU_MO.Text, mCntAFabricar)


        NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", My.Settings.cnnModProd)
        mOTCabCotizacion_Id = NuevoID

        'GRABO LOS ESTADOS
        Dim strInsert As String ', strHoy As String = Format(Now, "yyyy-MM-dd HH:mm:ss")
        'strInsert = "Insert EstadosCotizacion values (" & NuevoID & ",1,'" & strHoy & "'," & mUsuarioId & ")"
        strInsert = "exec pa_Insert_EstadosCotizacion " & NuevoID & ",1," & mUsuarioId
        obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

      Else
        NuevoID = drCabProdOT.Item("id").ToString
        mOTCabCotizacion_Id = NuevoID
      End If
    End If

    ''GRABO LOS ANEXOS
    'If mDocCargado = False Then ' seguro para cuando se copia una cotizacion no de error en los anexos
    '  Dim strRuta As String = GrabarAnexos(NuevoID)
    '  Call ActualizarGUID(strRuta, mGuid, NumCotizacion)
    'End If

    ''GRABO LA LISTA DE CHEQUEO
    'Call GrabarCheckList(NuevoID)
    mId = NuevoID


    btnGrabar.Enabled = True
    btnGrabar.Text = "Grabar"
    obCntv = Nothing

  End Sub

  Private Function TxtADec(ByVal strTxt As String) As Decimal
    TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
  End Function



  Private Sub cmdCargar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCargar.Click
    Dim Frm As New frmBuscar, xNumOrden As String, obCntv As New clConectividad

    

    m_Tab = ""
    btnGrabar.Visible = False
    Frm.Text = "Buscar OT"
    Frm.lblDoc.Text = "Numero OT" : Frm.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD


    xNumOrden = obCntv.LeerValorSencillo("valor", "parametros", "id=16", My.Settings.cnnModProd)
    obCntv = Nothing
    Frm.txtDocumento.Text = Strings.Left(xNumOrden, 2) & "*"
    Frm.txtDocumento.MaxLength = 10

    'Frm.chkTexto.Text = "Alcance"
    Frm.chkTexto.Text = "Estado"
    Frm.chkFechas.Text = "Fecha   "
    Frm.chkTercero.Text = "Cliente  "

    'Frm.txtTexto.Tag = "Alcance"
    Frm.txtTexto.Tag = "Estado"
    Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
    Frm.cmbTercero.Tag = "NombreCliente"

    Frm.strConsultaSQL = "vw_buscarOT"
    Frm.strCamposSQL = "id, NumOrden, NumCotizacion, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,  " _
      & " FechaInicio, FechaRegistro ,	Estado, [OC Cliente], CntAFabricar, CntDespachada, CntXDespachar, EstadoOTCierre [Estado Cierre],CabCotizacion_Id,OTCabCotizacion_Id"

    Frm.strOrderBy = "Order by NumOrden"

    Frm.ShowDialog()
   'mNumOrden = "%"

    Dim dtConsulta As DataTable

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
      'txtCarga.Text = txtCarga.Text & vbCrLf & Now()
        'dtDetSubT = Nothing
        lblCargando.Visible = My.Settings.ModoDebug
        lblCargando.Text = Now() & " Cargando módulo: Inicial..." & vbCrLf
        mObProd.TablaDetSubT.Rows.Clear()
        Call FrmInicial()

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: Consulta..." & vbCrLf
        dtConsulta = Frm.dtSeleccionado.Copy


        tssNumeroOT.Text = "OT Número: " & dtConsulta.Rows(0).Item(1)
        strEstado.Text = "Estado Actual OT: " & dtConsulta.Rows(0).Item("Titulo Estado")
        txtNumOrden.Text = dtConsulta.Rows(0).Item(1)
        mNumOrden = dtConsulta.Rows(0).Item(1)
        txtOCCliente.Text = dtConsulta.Rows(0).Item("OC Cliente")

        '***** LAS CANTIDADES
        txtCntFabricar.Text = dtConsulta.Rows(0).Item("CntAFabricar").ToString
        txtCntDespachada.Text = dtConsulta.Rows(0).Item("CntDespachada").ToString
        txtCntPendiente.Text = dtConsulta.Rows(0).Item("CntXDespachar").ToString
        mCntPendiente = dtConsulta.Rows(0).Item("CntXDespachar").ToString

        'ONYX 2022 06 11 USO LA ESTRUCTURA PARA ALMACENAR LOS DATOS DE OT
        With mOrdenDeTrabajo
          .CabCotizacion_id = dtConsulta.Rows(0).Item("CabCotizacion_Id")   'mCabCotizacion_Id
          .CabOrden_Id = dtConsulta.Rows(0).Item("Id")  'mCabOrden_Id
          '.NumOrden = mNumOrden
          .NumOrden = dtConsulta.Rows(0).Item("NumOrden")
          .OTCabCotizacion_Id = dtConsulta.Rows(0).Item("OTCabCotizacion_Id") 'mOTCabCotizacion_Id

        End With

        'Call CargarCotizacion(dtConsulta.Rows(0).Item("CabCotizacion_id").ToString, dtConsulta.Rows(0).Item("NumCotizacion").ToString)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        mCabOrden_Id = dtConsulta.Rows(0).Item("id").ToString

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion..." & vbCrLf
        Call CargarCotizacion(CInt(dtConsulta.Rows(0).Item("NumCotizacion").ToString), CInt(mNumOrden))

        'lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarResumen..." & vbCrLf
        'Call CargarResumen(mNumOrden)

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarRemision..." & vbCrLf
        Call CargarRemision(mNumOrden)

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarMaterialesAjustados..." & vbCrLf
        Call CargarMaterialesAjustados(mOTCabCotizacion_Id, "OT")

        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarMaterialesAjustados..." & vbCrLf
        Call CargarCostosOT(mNumOrden)


        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCompras..." & vbCrLf
        Call CargarCompras(mNumOrden)


        Me.Cursor = System.Windows.Forms.Cursors.Default
        txtCntAFabricar.Text = dtConsulta.Rows(0).Item("CntAFabricar").ToString

        Dim mBoton As Button = Me.Tag
        If mModoOTDirecta = False Then
            mBoton.Text = Me.Text & " " & mNumOrden
        End If

        btnGrabar.Text = "Actualizar"
        mDocCargado = True
        btnGrabar.Text = "Actualizar"
        btnSigFase.Visible = True


        'LLAMO EL CONTROL DE IMPRESIONES
        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: Habilitar_btnImprimir..." & vbCrLf
        Call Habilitar_btnImprimir()

        btnGrabar.Visible = True

        If dtConsulta.Rows(0).Item("TipoCot").ToString = "CR" Then
            stTipoOrigen.Text = "VENTA DIRECTA"
        Else
            stTipoOrigen.Text = "COTIZACION NORMAL"
        End If


        'LLAMO EL CONTROL DE ESTADOS
        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargaEstados..." & vbCrLf
        Call CargaEstados(mNumOrden)


        'ACA VOY A MANEJAR EL CIERRE DE OT 
        stEstadoOTCierre.Text = dtConsulta.Rows(0).Item("Estado Cierre").ToString

        btnGrabar.Visible = HabilitarSeccionCierre(btnGrabar, Usuario_Id)
        Call HabilitaEdicionResponsable(Usuario_Id)

        If dtConsulta.Rows(0).Item("Estado Cierre").ToString = "OT CERRADA" Then
          imgCerrada.Visible = True
          'Dim mTab As TabPage = tbcContenido.TabPages("tbcCerrarOT")
          grpCierreOTFacturas.Enabled = False
          grpCierreOTOtrosCampos.Enabled = False
        End If

        If mCntPendiente = 0 Then
          cmbEstadoActual.Visible = True
          chkCerrarOT.Visible = True
          lblNuevoEstado.Visible = True
        Else
          cmbEstadoActual.Visible = False
          chkCerrarOT.Visible = False
          lblNuevoEstado.Visible = False
        End If

        'CARGO EL PRESUPUESTO DE AJUSTE DE MATERIALES
        lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarPresupuetoMateriales..." & vbCrLf
        Call CargarPresupuestoMateriales()
        Call HabilitaEdicionPresupuesto(Usuario_Id)

        'CARGO LAS SUBTAREAS
        'Call CargaSubTareas(mCabOrden_Id, grSubTareas, grSubTareasDet)
        Call CargaSubTareas(mCabOrden_Id, grSubTareas, grSubTareasDet, "ST")
        Call CargaSubTareas(mCabOrden_Id, grSubTareasNotif, grSubTareasDetNotif, "NT")

        'grSubTareasNotif

        'CARGAR LA NOTIFICACIONES
        'Call CargarNotificaciones()

        'CARGO LA BITACORA
        Call CargarBitacora()

        'CARGO LOS SERVICIOS
        Call CargaServicios(mNumOrden)


    End If

    Frm.Dispose()
  End Sub

  Private Sub CargaServicios(ByVal mNumOrden As String)
    Dim obCntv As New clConectividad

    grServicios.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_ServiciosDeOT", "OT=" & mNumOrden)

    Dim miCol As DataGridViewColumn

    miCol = grServicios.Columns("COSTO") : miCol.Width = 100 : miCol.ReadOnly = False
    miCol.DefaultCellStyle.Format = "N0" : miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    Dim Ff As Integer, mTotal As Decimal = 0
    For Ff = 0 To grServicios.Rows.Count - 1
      mTotal = mTotal + grServicios.Item("Costo", Ff).Value
    Next

    lblTotalServicios.Text = mTotal.ToString("N0")

    obCntv = Nothing
  End Sub




  Private Sub CargarNotificaciones()
    Dim obCntv As New clConectividad

    'MODELO ANTIGUO
    grNotificaciones.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "PA_CargarNotificaciones", mNumOrden & ",1", "CargarNotificaciones")
    grNotificaciones2.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "PA_CargarNotificaciones", mNumOrden & ",2", "CargarNotificaciones")

    Dim mDtNotif As New DataTable


    grNotificaciones.Columns(7).Visible = False
    grNotificaciones2.Columns(7).Visible = False

    Dim ff As Integer

    For ff = 1 To grNotificaciones.Rows.Count - 1
      If grNotificaciones.Item("CANT REAL", ff).Value = 0 Then

        For CC = 0 To grNotificaciones.Columns.Count - 1
          grNotificaciones.Item(CC, ff).Style.BackColor = Color.Yellow   'Color.FromArgb(103, 177, 49)
        Next CC
      End If
    Next

    For ff = 1 To grNotificaciones2.Rows.Count - 1
      If grNotificaciones2.Item("CANT REAL", ff).Value = 0 Then

        For CC = 0 To grNotificaciones2.Columns.Count - 1
          grNotificaciones2.Item(CC, ff).Style.BackColor = Color.Yellow   'Color.FromArgb(103, 177, 49)
        Next CC
      End If
    Next ff


  End Sub

Private Sub MostrarNotifAgrupados(ByVal mTabla As DataTable)
        ' Crear un nuevo DataTable para almacenar los datos agrupados
        Dim dtAgrupado As New DataTable()

        ' Definir las columnas del nuevo DataTable
        dtAgrupado.Columns.Add("OT", GetType(Integer))
        dtAgrupado.Columns.Add("ITEM", GetType(String))
        dtAgrupado.Columns.Add("DESCRIPCION", GetType(String))
        dtAgrupado.Columns.Add("FECHA", GetType(Date))
        dtAgrupado.Columns.Add("MATERIAL_RECURSO", GetType(String))
        dtAgrupado.Columns.Add("CANT_PLAN", GetType(Decimal))
        dtAgrupado.Columns.Add("CANT_REAL", GetType(Decimal))
        dtAgrupado.Columns.Add("TipoDet", GetType(Integer))

        ' Iterar a través de las filas del DataTable original y agrupar por OT e ITEM
        'Dim grupos = From row In dataTable.AsEnumerable()
        '             Group By ot = row.Field(Of String)("OT"),
        '                      item = row.Field(Of String)("ITEM")
        '             Into Grupo = Group

        Dim grupos = From row In mTabla.AsEnumerable()
              Group By ot = row.Field(Of Integer)("OT"),
                       item = row.Field(Of String)("ITEM")
              Into Grupo = Group


        ' Llenar el DataTable agrupado con los datos resultantes
        For Each grupo In grupos
            Dim nuevaFila = dtAgrupado.NewRow()
            nuevaFila("OT") = grupo.ot
            nuevaFila("ITEM") = grupo.item

            ' Concatenar las descripciones separadas por coma
            nuevaFila("DESCRIPCION") = String.Join(", ", grupo.Grupo.Select(Function(f) f.Field(Of String)("DESCRIPCION")))

            ' Mostrar la fecha y el material/recurso del primer elemento del grupo
            nuevaFila("FECHA") = grupo.Grupo.First().Field(Of Date)("FECHA")
            nuevaFila("MATERIAL_RECURSO") = grupo.Grupo.First().Field(Of String)("MATERIAL/RECURSO")

            ' Sumar las cantidades planificadas y reales del grupo
            nuevaFila("CANT_PLAN") = grupo.Grupo.Sum(Function(f) f.Field(Of Decimal)("CANT PLAN"))
            nuevaFila("CANT_REAL") = grupo.Grupo.Sum(Function(f) f.Field(Of Decimal)("CANT REAL"))

            ' Mostrar el TipoDet del primer elemento del grupo
            nuevaFila("TipoDet") = grupo.Grupo.First().Field(Of Integer)("TipoDet")

            dtAgrupado.Rows.Add(nuevaFila)
        Next

        ' Enlazar el DataTable agrupado al DataGridView
        'grNotificaciones3.DataSource = dtAgrupado
    End Sub


  Private Sub CargarPresupuestoMateriales()
      Dim obCntv As New clConectividad

      Dim strConsulta As String, RsSalida As MSSQL.SqlDataReader

      strConsulta = "exec PA_RevisaSobreCostoMP " & mNumOrden

      RsSalida = obCntv.EjecutaComando(strConsulta, My.Settings.cnnModProd, True)
      RsSalida.Read()

      TxtPresupuesto.Text = CDec(RsSalida.Item("bolsa").ToString).ToString(FCTOTOT)
      lblReal.Text = CDec(RsSalida.Item("Real").ToString).ToString(FCTOTOT)
      'txtMO_Aju.Text = IIf(RsSalida.Item("MO_Aju").ToString = "", CDec(0).ToString(FCTOTOT), CDec(RsSalida.Item("MO_Aju").ToString).ToString(FCTOTOT))
      txtMPCotizados.Text = CDec(IIf(RsSalida.Item("MPCotizados").ToString = "", 0, RsSalida.Item("MPCotizados").ToString)).ToString(FCTOTOT)
      txtAIU_Aju.Text = CDec(IIf(RsSalida.Item("ValorAIU").ToString = "", 0, RsSalida.Item("ValorAIU").ToString)).ToString(FCTOTOT)
      txtCupo.Text = CDec(IIf(RsSalida.Item("ValAdicional").ToString = "", 0, RsSalida.Item("ValAdicional").ToString)).ToString(FCTOTOT)

      mCupo = CDec(RsSalida.Item("Ppto").ToString)

      'LAS VARIABLES PARA CALCULAR LOS PORCENTAJES
      With mOrdenDeTrabajo
        .Presupuesto = CDec(RsSalida.Item("Ppto").ToString).ToString(FCTOTOT)
        .ValMPCotizados = CDec(RsSalida.Item("MPCotizados").ToString).ToString(FCTOTOT)
        .ValAIU = CDec(RsSalida.Item("ValorAIU").ToString).ToString(FCTOTOT)
        .ValAdicional = CDec(RsSalida.Item("ValAdicional").ToString).ToString(FCTOTOT)
        .ValEjecutado = CDec(RsSalida.Item("Real").ToString).ToString(FCTOTOT)
      End With



      Dim mDiff As Decimal = CDec(RsSalida.Item("Ppto")) - CDec(RsSalida.Item("Real"))
      lblDifDinero.Text = CDec(mDiff).ToString(FCTOTOT)

      Dim mDiffPorc As Decimal

      If CDec(RsSalida.Item("Ppto").ToString) = 0 Then
        mDiffPorc = 0
      Else
          mDiffPorc = CDec(RsSalida.Item("Real")) / CDec(RsSalida.Item("Ppto").ToString)
      End If

      lblDifPorc.Text = mDiffPorc.ToString("P")


      'El calculo del porc Adicional
      Dim mAdicionalPorc As Decimal

      If CDec(RsSalida.Item("Ppto").ToString) = 0 Then
        mAdicionalPorc = 0
      Else
        mAdicionalPorc = CDec(RsSalida.Item("ValAdicional")) / CDec(RsSalida.Item("Ppto").ToString)
      End If

      lblAdicionalPorc.Text = mAdicionalPorc.ToString("P")

      If mDiffPorc > 1 Then
        ProgressBar1.Value = 100
      Else
        ProgressBar1.Value = mDiffPorc * 100
      End If



      tslMensajePresupuesto.Text = RsSalida.Item("TextoSemaforo").ToString

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

  'Private Sub CargaSubTareas(ByVal mCabOrden_Id As Integer)
  '    Dim obCntv As New clConectividad, drSubT As MSSQL.SqlDataReader

  '    '*********************AJUSTAR CON PERMISOS ESTA VARIABLE ********
  '    mUsuarioAutorizaAddMP = True 'PENDIENTE AJJUSTAR: 20240122

  '    drSubT = obCntv.LeerValor("*", "vw_CabSubT", "Tipo='ST' and Estado in ('A','N','P') and OT_Cab_Id=" & mCabOrden_Id, My.Settings.cnnModProd)

  '    grSubTareasDet.DataSource = Nothing
  '    grSubTareas.Rows.Clear()

  '    ''LA NOTIFICACIÓN
  '    'grSubTareasDetNotif.DataSource = Nothing
  '    'grSubTareasNotif.Rows.Clear()


  '    Do
  '      If drSubT.HasRows = True Then
  '        Dim strCabSubT() As String = { _
  '                        StrDup(3 - Len(drSubT.Item("Item")), "0") & drSubT.Item("Item"),
  '                        drSubT.Item("Descripcion"),
  '                        drSubT.Item("AsignadaA"),
  '                        drSubT.Item("Fecha"),
  '                        drSubT.Item("Id"),
  '                        drSubT.Item("Id"),
  '                        drSubT.Item("Horas"),
  '                        drSubT.Item("N. Estado"),
  '                        "Imprimir",
  '                        drSubT.Item("operario_id"),
  '                        IIf(IsDBNull(drSubT.Item("SubT_Cab_Id")) = True, "", drSubT.Item("SubT_Cab_Id"))
  '                        }

  '          grSubTareas.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
  '          'grSubTareasNotif.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

  '          'Al cargar la OT, el campo CabSubT_Id de la grilla grSubTareas se debe llenar. Al agregar una fila nueva, va en blanco, de esta forma se diferencia al actualizar.
  '          grSubTareas.Rows.Add(strCabSubT)
  '          'grSubTareasNotif.Rows.Add(strCabSubT)

  '          'FORMATO DE LAS SUBTAREAS
  '          Select Case drSubT.Item("Estado")
  '            Case "A"
  '                Call ColorFila(grSubTareas.Rows.Count - 1, Color.Red)
  '                'Call ColorFila(grSubTareasNotif.Rows.Count - 1, Color.Red)
  '            Case "I"
  '              Call ColorFila(grSubTareas.Rows.Count - 1, Color.Gray)
  '              'Call ColorFila(grSubTareasNotif.Rows.Count - 1, Color.Gray)
  '            Case "N"
  '              Call ColorFila(grSubTareas.Rows.Count - 1, Color.Green)
  '              'Call ColorFila(grSubTareasNotif.Rows.Count - 1, Color.Green)
  '            Case "P"
  '              Call ColorFila(grSubTareas.Rows.Count - 1, Color.Yellow)
  '              'Call ColorFila(grSubTareasNotif.Rows.Count - 1, Color.Yellow)
  '            Case "T"
  '              Call ColorFila(grSubTareas.Rows.Count - 1, Color.Green)
  '              'Call ColorFila(grSubTareasNotif.Rows.Count - 1, Color.Green)
  '          End Select
  '      End If
  '    Loop While drSubT.Read()

  '    'EL DETALLE DE LAS SUBTAREAS
  '    dtDetSubT = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_DetSubT", "Estado='A' and OT_Cab_ID=" & mOrdenDeTrabajo.CabOrden_Id)

  '    If grSubTareas.Rows.Count > 0 Then
  '      Call FiltrarDetSubT(0, grSubTareas)
  '      'Call FiltrarDetSubT(0, grSubTareasNotif)
  '    End If

  'End Sub





  Private Sub btnSigFase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSigFase.Click
    Dim obCntv As New clConectividad

    Dim strSql As String

    Try
      Dim drDatosEstado As MSSQL.SqlDataReader = obCntv.LeerValor("*", "Estados", "TipoDoc ='OT' and Estado ='" & mEstadoXDefecto & "'", My.Settings.cnnModProd)

      'GRABO LOS POSIBLES CAMBIOS

      Call GrabarOT("btnSigFase_Click")

      strSql = "exec PA_TerminaEtapaOT " & mNumOrden.ToString & "," & drDatosEstado.Item("id").ToString
      obCntv.EjecutaComando(strSql, My.Settings.cnnModProd, False)
      MessageBox.Show("Etapa de " & UCase(drDatosEstado.Item("Titulo").ToString) & " terminada para la Orden de Trabajo " & mNumOrden.ToString, "Etapa terminada", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Call FrmInicial()
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error ModProd", MessageBoxButtons.OK, MessageBoxIcon.Error)

    End Try



  End Sub


  Private Sub btnAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnexos.Click, btnAnexos2.Click
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

            tbcContenido.SelectedTab = tbcContenido.TabPages("tbpAnexos")
            btnGrabarAnexos.Enabled = True

        End If


  End Sub


  Private Function GrabarAnexos(ByVal NumOrden As Integer, ByVal CabOrden_Id As Integer) As String
        Dim obCntv As New clConectividad
        Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=10", My.Settings.cnnModProd)
        Dim strMes As String = StrDup(2 - Len(Today.Month.ToString), "0") & Today.Month.ToString
        Dim strRutaOrden As String

        strRutaOrden = NumOrden.ToString 'SIEMPRE SE SABE EL NUMERO DE LA ORDE, POR LO TANTO NO NECESITO GUID

        Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaOrden.ToString
        strRuta = strRuta & strRutaB

        'ONYX: GRABO LOS ANEXOS DE LA ORDEN DE TRABAJO
        If UCase(obCntv.LeerValorSencillo("valor", "parametros", "descripcion='CargarImagenes'", My.Settings.cnnModProd)) = "SI" Then
          If lstAnexos.CheckedItems.Count > 0 Then
              IO.Directory.CreateDirectory(strRuta)

          End If
        End If

        'presento el cuadro para cargar los archivos
        'If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
        Dim strArchivo As String, Ff As Integer

        For Ff = 0 To lstAnexos.Items.Count - 1
            If mTablaAnexos(Ff).Item("Estado") = "N" Then 'lstAnexos.GetItemChecked(Ff) = True Then
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


                  'IO.File.Copy(strArchivo, strDestino)
                  CopiarArchivoSiEsMasActual(strArchivo, strDestino)
                  strInsert = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & CabOrden_Id.ToString & ",'" _
                      & strDestino.ToString & "','" & NumOrden.ToString & "','A')"
                  obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

                Else
                  strDestino = strArchivo
                  If mDocCargado = False Then
                      strInsert = "insert AnexosOrden(Cab_id, RutaArchivo,mguid,Estado ) values (" & CabOrden_Id.ToString & ",'" _
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




    Public Sub CopiarArchivoSiEsMasActual(ByVal strArchivo As String, ByVal strDestino As String)
        ' Verificar si el archivo de destino existe
        If IO.File.Exists(strDestino) Then
            ' Obtener las fechas de modificación de ambos archivos
            Dim fechaArchivoOrigen As DateTime = IO.File.GetLastWriteTime(strArchivo)
            Dim fechaArchivoDestino As DateTime = IO.File.GetLastWriteTime(strDestino)

            ' Comparar las fechas de modificación
            If fechaArchivoOrigen > fechaArchivoDestino Then
                ' Sobrescribir el archivo de destino si el archivo origen es más reciente
                IO.File.Copy(strArchivo, strDestino, True)
                Console.WriteLine("El archivo de destino fue sobrescrito.")
            Else
                Console.WriteLine("El archivo de destino es más reciente o tiene la misma fecha. No se realizó la copia.")
            End If
        Else
            ' Si el archivo de destino no existe, copiar el archivo origen
            IO.File.Copy(strArchivo, strDestino)
            Console.WriteLine("El archivo fue copiado al destino.")
        End If
    End Sub



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

     Private Function CrearGUID() As String
        Dim g As Guid
        ' Create and display the value of two GUIDs.
        g = Guid.NewGuid()
        CrearGUID = g.ToString

    End Function


  Private Sub lstAnexos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles lstAnexos.SelectedIndexChanged, lstAnexosNotificacion.SelectedIndexChanged

    Dim mLista = CType(sender, CheckedListBox)

    If mLista.Name = "lstAnexosNotificacion" Then
      Call CargaImagen(mVctAnexosNotificacion(mLista.SelectedIndex + 1).ToString, True)
    Else
      Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)
    End If

  End Sub



Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
  If mOTyaImpresa = True Then
    MessageBox.Show("Esta OT ya fué impresa!" & vbCrLf & "No esta autorizado para una nueva impresión", "Impresión no Autorizada", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    Exit Sub
  End If

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
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


      Dim strOrden As String = txtNumOrden.Text  'InputBox("Número de Orden de Trabajo")
      Dim frm As New frmImprimeOT
      frm.strOrdenID = mNumOrden  'strOrden

      Dim obCntv As New clConectividad, mTipoRpt As String

      mTipoRpt = obCntv.LeerValorSencillo("distinct MarcaAgua", "MarcaAgua", "VW_RPT_OrdenDeTrabajo", " numorden=" & mNumOrden, My.Settings.cnnModProd)

      If mTipoRpt = "DEFINITIVA" Then
        frm.strNombreReporte = My.Settings.NombreRptOrdenProduccion
      Else
        frm.strNombreReporte = My.Settings.NombreRptOrdenProduccionBorrador
      End If

      frm.rptReporte.SetPageSettings(Pg2)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
      frm.rptReporte.RefreshReport()
      frm.Show()

      'La parte de la creación del control de impresiones
      Dim obProd As New clProduccion

      obProd.GrabarImpresionOT(My.Settings.cnnModProd, mNumOrden, mTipoOT, mUsuarioId, Date.Now, "A")
      'LLAMO EL CONTROL DE IMPRESIONES
      Call Habilitar_btnImprimir()

      obProd = Nothing

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Try


End Sub



  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
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


  Private Sub ManejoError(ByVal mFrm As String, ByVal mSub As String, ByVal mErr As Exception)
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



  Private Sub txtCntAFabricar_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
    Handles txtCntAFabricar.KeyPress
     If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

        'se decide llevar en la función de guardar la OT
        'If mMultiplicarCantOT = "SI" Then
        '  If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
        '    Call Calcular()
        '  End If
        'End If
  End Sub

  Private Sub CargaEstados(ByVal mNumOrden As Integer)
    Dim obCntv As New clConectividad, drEstadosOT As MSSQL.SqlDataReader, mEstadoActual As String

    Dim mEstadoIDActual As Integer

    drEstadosOT = obCntv.LeerValor("*", "Vw_EstadosOT", "NumOrden=" & mNumOrden, My.Settings.cnnModProd)

    Do
        mEstadoActual = drEstadosOT.Item("EstadoActual").ToString
        mEstadoIDActual = drEstadosOT.Item("IDEstadoFaseActual").ToString
        mNombreEstadoActual = drEstadosOT.Item("FaseActual").ToString

        mTipoOT = drEstadosOT.Item("Tipo").ToString 'para controlar si son venta directa o normal
        If drEstadosOT.Item("EstadoEtapa") = "T" Then
            chkListEstadosOT.SetItemCheckState(drEstadosOT.Item("ID").ToString - 8, CheckState.Checked)
        End If
    Loop While drEstadosOT.Read()

    chkListEstadosOT.Visible = True

    Dim mRol_Id As Integer = obCntv.LeerValorSencillo("Rol_Id", "usuarios", "id=" & mUsuarioId, My.Settings.cnnModProd)




    If mModoOTDirecta = True And mTipoOT = "CR" Then 'LAS OTS DE VENTA DIRECTA y llamado en forma modal desde AJUSTE DE MATERIALES
        Dim xRolesModificanOTDirecta As String = obCntv.LeerValorSencillo("Valor", "Parametros", "descripcion='RolesModificanOTDirecta'", My.Settings.cnnModProd)
        Dim xTieneAutoriza As String = obCntv.LeerValorSencillo("count(1) Cant", "Cant", "rolesxusuario", "rol_id IN (" & xRolesModificanOTDirecta & ") AND Usuario_Id=" & mUsuarioId.ToString, My.Settings.cnnModProd)

        Call BotonesModoTODirecta()

        If CInt(xTieneAutoriza) > 0 Then 'Si el usuario tiene asignado el rol o roles que estan en el parametro
              btnGrabar.Visible = True
              btnSigFase.Visible = False

        Else
            btnGrabar.Visible = False
            btnSigFase.Visible = False

        End If
    Else 'ENTRA PARA LAS OT CON COTIZACIONES NORMALES
          Select Case mRol_Id
            Case 6 'Sec produccion
              If mEstadoActual = "R" Then
                  btnGrabar.Visible = True
                  btnSigFase.Visible = True
              Else
                  btnGrabar.Visible = False
                  btnSigFase.Visible = False
              End If
            Case 7, 8, 4
              If mEstadoActual = "R" Then
                  btnGrabar.Visible = False
                  btnSigFase.Visible = False
              ElseIf mEstadoActual = "V" Then
                  btnGrabar.Visible = True
                  btnSigFase.Visible = True
                  chkPlanos.Visible = True
                  cmbAsignadaA.Enabled = True

              Else
                  btnGrabar.Visible = False
                  btnSigFase.Visible = False
              End If
            Case Else
          End Select
    End If

    If mTipoOT = "CN" Then
      If mEstadoIDActual >= 9 Then 'SI EL ID DE ESTADO ES SUPERIOR O IGUAL A VALIDACION
        btnGrabarAnexos.Visible = True
      End If
    End If

    If mTipoOT = "CR" And mRol_Id = 6 Then 'sec produccion
        btnGrabar.Visible = True
    End If

    'If mEstadoIDActual >= 16 Then
    '  cmbEstadoActual.SelectedIndex = cmbEstadoActual.FindStringExact(mNombreEstadoActual)
    '  lblEstadoActual.Text = strNombreEstadoActual
    'Else
    '  lblEstadoActual.Text = mNombreEstadoActual
    '  strEstadoActual = mEstadoActual
    'End If
    If mCntPendiente = 0 Then
      If mEstadoIDActual > 16 Then
        cmbEstadoActual.SelectedIndex = cmbEstadoActual.FindStringExact(mNombreEstadoActual)
      Else
        cmbEstadoActual.SelectedIndex = cmbEstadoActual.FindStringExact("Liquidación")
      End If
      lblEstadoActual.Text = strNombreEstadoActual
    Else
      lblEstadoActual.Text = mNombreEstadoActual
      strEstadoActual = mEstadoActual
    End If


  End Sub


'*******************************************************************
'** ESTABLECE LA FORMA DE AUTO AJUSTAR EL ANCHO DE LAS COLUMNAS
'*******************************************************************

  Private Sub EstableceModoColumnas( _
      ByRef grGrilla As DataGridView, _
      Optional ByVal Tipo As Integer = 0, _
      Optional ByVal AnchoColumnas As String = "")

    Dim ModoColumna As DataGridViewAutoSizeColumnsMode, ParametroUsar As Integer

    If Tipo > 0 Then
      ParametroUsar = Tipo
    ElseIf Tipo = -1 Then
      ParametroUsar = 0
    Else
      ParametroUsar = My.Settings.grProductosColumnsMode
    End If

    Dim VctColumnas() As String = Split(AnchoColumnas, "|")


    Select Case ParametroUsar 'My.Settings.grProductosColumnsMode
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

      If Tipo = -1 Then
        grGrilla.Columns(Cc).Width = VctColumnas(Cc)
      End If

    Next Cc

    ' MessageBox.Show(My.Settings.grProductosColumnsMode)

  End Sub

#Region "MODIFICACIÓN ESPECIAL PARA LA OT´S POR VENTA DIRECTA"
    Private Sub ActualizarOTVtaDirecta()
        Dim obCntv As New clConectividad

        Dim strSQLupdate As String

        strSQLupdate = "Alcance='" & txtAlcanceOT.Text & "', OCompraCliente='" & txtOCCliente.Text & "'"
        obCntv.ActualizaValor(strSQLupdate, "CabOT", "NumOrden=" & mNumOrden.ToString, My.Settings.cnnModProd)

        strSQLupdate = "AsignadoA='" & cmbAsignadaA.Text.ToString & "', NombreProyecto='" & txtProyectoOT.Text _
            & "', Alcance='" & txtAlcanceOT.Text & "'"
        obCntv.ActualizaValor(strSQLupdate, "CabCotizacion", "Tipo='OT' and numCotizacion=" & mNumCotiza.ToString, My.Settings.cnnModProd)

        Dim strSQL As String = "exec PA_SincronizarOTVentaDirecta " & mNumOrden
        obCntv.EjecutaComando(strSQL, My.Settings.cnnModProd, False)


        MessageBox.Show("Datos actualizados con éxito", "Datos Actualizados", MessageBoxButtons.OK)
        Me.DialogResult = Windows.Forms.DialogResult.OK
        obCntv = Nothing
    End Sub

    Public Sub BotonesModoTODirecta()
        cmdCargar.Visible = False
        btnAprobar.Visible = False
        btnSigFase.Visible = False
        btnImprimir.Visible = False
        btnCalcular.Visible = False
        btnAccion.Enabled = False
        btnMenuLista.Visible = False
        txtNumOrden.ReadOnly = True
        rbOpt1.Enabled = False
        rbOpt2.Enabled = False
        rbOpt3.Enabled = False
        tbcContenido.TabPages.Remove(TabPage1)
        tbcContenido.TabPages.Remove(TabPage2)
        tbcContenido.TabPages.Remove(tbpAnexos)
        tbcContenido.TabPages.Remove(TabPage4)

        'btnGrabar.Visible = True



    End Sub


#End Region


#Region "IMPRESION DE OT"



  '****************************************************************
  '****************************************************************
  '***********  LOGICA PARA LA IMPRESIÓN DE OT
  '****************************************************************
  '****************************************************************
  Private Sub Habilitar_btnImprimir()

    Dim obCntv As New clConectividad, xCantNivelUsuario As Integer
    Dim xRolNivel2ImpOT As Integer, xRolNivel1ImpOT As Integer

    mOTyaImpresa = False ': btnImprimir.Visible = True
    btnImprimir.Visible = False


    'PARA CARGA EL MENSAJE DE SI SE HA IMPRESO O NO
    stEstadoImpresion.Visible = False
    Dim mCant As Integer = obCntv.LeerValorSencillo("COUNT(1) CANT", "CANT", "ImpresionesOT", "NumOrden = " & mNumOrden, My.Settings.cnnModProd)

    If mCant > 0 Then
      stEstadoImpresion.Text = "OT YA SE IMPRIMIO"
      stEstadoImpresion.Visible = True
    End If

    'xRolNivel2ImpOT es el nivel mas alto, puede imprimir todas las veces
    xRolNivel2ImpOT = obCntv.LeerValorSencillo("valor", "Parametros", "Descripcion='RolNivel2ImpOT'", My.Settings.cnnModProd)
    xCantNivelUsuario = obCntv.LeerValorSencillo("count(1) Cant", "Cant", "RolesXUsuario", "Usuario_Id = " & mUsuarioId.ToString & " and Rol_Id = " & xRolNivel2ImpOT, My.Settings.cnnModProd)

    'Tiene permiso total de impresion
    If xCantNivelUsuario > 0 Then
      btnImprimir.Visible = True
      mOTyaImpresa = False 'dejo qeu imprima siempre. Usado en el evento click del boton imprimir
      obCntv = Nothing
      Exit Sub
    End If

    'SI NO TIENE PERMISO TOTAL, REVISO SI TIENE PERMISO TIPO 1 (SOLO UNA IMPRESION)
    xRolNivel1ImpOT = obCntv.LeerValorSencillo("valor", "Parametros", "Descripcion='RolNivel1ImpOT'", My.Settings.cnnModProd)
    xCantNivelUsuario = obCntv.LeerValorSencillo("count(1) Cant", "Cant", "RolesXUsuario", "Usuario_Id = '" & mUsuarioId.ToString & "' and Rol_Id = " & xRolNivel1ImpOT, My.Settings.cnnModProd)

    If xCantNivelUsuario > 0 Then
      'LOGICA PARA REVISAR SI YA SE HA IMPRESO MAS DE N-VECES UNA OT
      Dim xCantImp As Integer = obCntv.LeerValorSencillo("Count(1) Cant", "Cant", "ImpresionesOT", "numorden='" & mNumOrden & "' and estado='A'", My.Settings.cnnModProd)
      Dim xCantReImp As Integer = obCntv.LeerValorSencillo("valor", "Parametros", "Descripcion='CantReImpresionOT'", My.Settings.cnnModProd)

      btnImprimir.Visible = True
      If xCantImp < xCantReImp Then
          'btnImprimir.Visible = True
          mOTyaImpresa = False
      Else

          mOTyaImpresa = True 'para usar en el mensaje del evento click
      End If

    Else 'NO TIENE PERMISO ALGUNO
      obCntv = Nothing
      Exit Sub 'EL BOTON DEBE QUEDAR DESHABILITADO
    End If




    obCntv = Nothing
  End Sub


#End Region



    Private Sub btnMenuLista_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenuLista.Click
        flyCierreOT.Visible = Not flyCierreOT.Visible



    End Sub

    Private Sub btnLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLiquidacion.Click, btnLegalizacion.Click, btnFacturacion.Click
        Dim strInsert As String, obCntv As New clConectividad, strSQL As String
        Dim mIdEstado As Integer = 15
        mEstadoXDefecto = "LQ"

        '1)AL ENTRAR:
        '   A) TERMINAR CUALQUIER ETAPA ANTERIOR
            obCntv.ActualizaValor("EstadoEtapa='T'", "EstadosOT", "cab_id=" & mCabOrden_Id.ToString, My.Settings.cnnModProd)

        '   B) CAMBIAR CAMPO ESTADO A 'LQ'
            obCntv.ActualizaValor("Estado='LQ'", "CabOT", "id=" & mCabOrden_Id.ToString, My.Settings.cnnModProd)

            '***SINCRONIZAR LA OT
            strSQL = "exec PA_SincronizarOTVentaDirecta " & mNumOrden
            obCntv.EjecutaComando(strSQL, My.Settings.cnnModProd, False)

            Dim Frm As New frmSimulador
            Frm.ModoLiquidacionVentaDirecta = True
            Frm.NumCotizacion = mNumCotiza : Frm.NumOrdenTrabajo = mNumOrden
            Frm.ShowDialog()

        '2) AL SALIR:
        '   SI DESEA TERMINAR LA ETAPA:
        '       A) INSERTAR REGISTRO 'LQ' TERMINADO
            If MessageBox.Show("Desea dar por teminada la etapa de LIQUIDACIÓN?", "Liquidación de OT", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                'strInsert = "exec PA_TerminaEtapaOT " & mNumOrden.ToString & "," & mIdEstado.ToString
                strInsert = "exec pa_Insert_EstadosOT " & mCabOrden_Id & "," & mIdEstado & "," & mUsuarioId & ",'T'"
                obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

                'B) CAMBIAR CAMPO DE ESTADO A 'LG'
                obCntv.ActualizaValor("Estado='LG'", "CabOT", "id=" & mCabOrden_Id.ToString, My.Settings.cnnModProd)
            Else
            '   SI NO DESEA TERMINAR LA ETAPA:
            '       A) INGRESAR REGISTRO 'LQ' EN PARCIAL
                strInsert = "exec pa_Insert_EstadosOT " & mCabOrden_Id & "," & mIdEstado & "," & mUsuarioId & ",'P'"
                obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

            End If

        '3) PARA AMBOS CASOS, SINCRONIZAR DATOS DE OT (COT) CON DATOS DE COT(EJ. SERVICIOS Y ADICIONALES)
            strSQL = "exec PA_SincronizarOTVentaDirecta " & mNumOrden
            obCntv.EjecutaComando(strSQL, My.Settings.cnnModProd, False)


        '4) VOLVER A CARGAR LA PANTALLA
            Call CargarCotizacion(CInt(mNumCotiza), CInt(mNumOrden))

       obCntv = Nothing

    End Sub


    Private Sub HabilitarCierreOT(ByVal xNumOrden As Integer)
      'If mModoOTDirecta = False Then
      '    Dim obCntv As New clConectividad
      '    Dim xEstadoActual As String = obCntv.LeerValorSencillo("Estado", "CabOT", "numorden=" & xNumOrden, My.Settings.cnnModProd)
      '    btnLegalizacion.Visible = False
      '    btnLiquidacion.Visible = False
      '    btnFacturacion.Visible = False
      '    btnMenuLista.Visible = False
      '    btnImprimirCOT.Visible = False

      '    Select Case xEstadoActual
      '        Case "PM", "C", "DT", "PP", "FB", "MJ", "LQ"
      '            btnLiquidacion.Visible = True
      '            btnMenuLista.Visible = True

      '        Case "LG"
      '            btnImprimirCOT.Visible = True
      '            btnLegalizacion.Visible = True
      '            btnMenuLista.Visible = True
      '        Case "FC"
      '            btnFacturacion.Visible = True
      '            btnMenuLista.Visible = True
      '        Case Else
      '    End Select

      '    obCntv = Nothing
      '  End If
    End Sub


    Private Sub btnImprimirCOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirCOT.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        stEstadoImpresion.Text = "Preparando Informe ..."
        stEstadoImpresion.Visible = True : stEstadoImpresion.BackColor = Color.Yellow
        Call Imprimir(mCabCotizacion_Id)
        stEstadoImpresion.Text = "OT YA SE IMPRIMIO"
        stEstadoImpresion.Visible = False
        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub Imprimir(ByVal Cab_ID As Integer)

        'If VentaDirecta = False Then
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
       ' End If

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


    Private Sub FrmInicial()
        btnMenuLista.Visible = False
        rbOpt1.Checked = True
        lblCliente.Text = ""
        txtAlcance.Text = ""
        txtProyecto.Text = ""
        txtObservacion.Text = ""
        txtObsInterna.Text = ""
        txtAlcanceOT.Text = ""
        txtNumCotizacion.Enabled = True
        txtNumCotizacion.Text = ""
        tssNumeroCot.Text = ""
        tssNumeroOT.Text = ""
        'mNumOrden = 0
        mNumOrden = "%"
        mDocCargado = False
        lblAsignadaA.Text = ""

        txtNumOrden.Text = ""
        dtpFechaInicio.Value = Today
        dtpFecha.Value = Today
        chkPlanos.Checked = False
        txtAlcanceOT.Text = ""
        cmbAsignadaA.Text = ""

        lblCliente.Text = ""
        txtProyecto.Text = ""
        txtAlcance.Text = ""
        txtObservacion.Text = ""
        txtObsInterna.Text = ""
        lblAsignadaA.Text = ""
        txtDirigidaA.Text = ""
        txtFormaPago.Text = ""
        txtTmpFabricacion.Text = ""
        txtTmpEntrega.Text = ""
        txtReq.Text = ""
        txtImprevistos.Text = ""
        txtAIU.Text = ""
        txtAIU_MO.Text = ""
        txtUtilidad.Text = ""
        dtpFecha.Value = Today
        chkMontaje.Checked = False
        lblTotal.Text = ""
        txtPrecioFinal.Text = ""
        lstAnexos.Items.Clear()
        'grEventos.Rows.Clear()
        grProductos.Rows.Clear()
        grEmpleados.Rows.Clear()
        grSubTareas.Rows.Clear()
        grMatST.Rows.Clear()

        grSubTareasDet.DataSource = Nothing
        grSubTareasDet.Rows.Clear()


        txtProyectoOT.Text = ""
        txtAlcanceOT.Text = ""
        lblClienteOT.Text = ""
        txtCntAFabricar.Text = ""
        txtOCCliente.Text = ""

        stFecha.Text = ""
        stNumCotizacion.Text = ""
        strEstado.Text = ""


        grEventos.DataSource = Nothing

        btnGrabar.Visible = False

        Dim Ff As Integer


        For Ff = 0 To chkListEstadosOT.Items.Count - 1
          chkListEstadosOT.SetItemCheckState(Ff, False)

        Next


        'LIMPIEZA DE VARIABLES
        mOrigenDocCargado = "OT" : mCantAnexosCot = 0
        mDocCargado = False : mCabCotizacion_Id = 0 : mNumCotiza = 0 : mCabOrden_Id = 0 : mOTCabCotizacion_Id = 0
        mIdNumeroCotizacionRapida = 0 : mNumOrden = "%"
        mCabMov_Id = "" : strNombreProducto = ""
        mTotal = 0
        mEsNuevo = False : mId = 0
        'mModoOTDirecta = False
        'mEstadoXDefecto = "R"

        rbOpt1.Select()
        txtNumCotizacion.Text = ""
        dtpFechaInicio.Value = Date.Today
        dtpFechaFin.Value = Date.Today
        txtNumOrden.Text = ""
        txtOCCliente.Text = ""
        chkPlanos.Checked = False
        txtCntAFabricar.Text = ""
        lblCliente.Text = ""
        txtProyectoOT.Text = ""
        txtAlcanceOT.Text = ""
        cmbAsignadaA.Text = ""

        btnAccion.Text = "Cargar Cotización" : btnAccion.Top = 14 : btnAccion.Tag = "rbOpt1"
        lblCot.Text = "Cotización Normal"

        grpCierreOTFacturas.Enabled = True
        grpCierreOTOtrosCampos.Enabled = True
        grRemisionesOT.Enabled = True

        grSubTareas.Rows.Clear()
        grSubTareasDet.DataSource = Nothing

        grSubTareasDet.Rows.Clear()

        'Las grillas de notificación
        grSubTareasNotif.Rows.Clear()
        grSubTareasDetNotif.DataSource = Nothing

      End Sub

    Private Sub CargarCompras(ByVal mNumOrden As Integer)
        Dim obCntv As New clConectividad
        grCompras.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "PA_RPT_Estado_Pedido_Compra", "'" & mNumOrden & "','19000101','21001231','%','%','%'", "PA_RPT_Estado_Pedido_Compra")
        obCntv = Nothing

        With grCompras
            .Columns("NUMERO SOLICITUD").Visible = False
            .Columns("SOLDET_ID").Visible = False
            .Columns("NOMBRE CLIENTE").Visible = False
            .Columns("TipoDoc").Visible = False
            .Columns("NumOrden").Visible = False
            .Columns("COSTO").Visible = False
            .Columns("TOTAL").Visible = False
            .Columns("Inventario_ID").DisplayIndex = 0
            .Columns("NombreZiur").DisplayIndex = 1
            .Columns("Cant").DisplayIndex = 2
            .Columns("NomUnidad").DisplayIndex = 3
            .Columns("ESTADO PEDIDO").DisplayIndex = 4
            .Columns("NumOC").DisplayIndex = 5
            .Columns("FECHA PEDIDO").DisplayIndex = 6
            .Columns("FECHA COTIZACION").DisplayIndex = 7
            .Columns("FECHA OC").DisplayIndex = 8
            .Columns("FECHA VALIDACION OC").DisplayIndex = 9
            .Columns("FECHA ENTREGADO").DisplayIndex = 10
            .Columns("PIDE").DisplayIndex = 11
            .Columns("USUARIO APRUEBA").DisplayIndex = 12
            .Columns("NUM REMISIONES").DisplayIndex = 13


            .Columns("NombreZiur").Width = 200 : .Columns("NombreZiur").HeaderText = "PRODUCTO"
            .Columns("PIDE").Width = 150
            .Columns("USUARIO APRUEBA").Width = 150
            .Columns("NumOC").HeaderText = "NUMERO ORDEN COMPRA"
            .Columns("Inventario_ID").HeaderText = "INVENTARIO"
            .Columns("Cant").HeaderText = "CANTIDAD"
            .Columns("NomUnidad").HeaderText = "UNIDAD"
            .Columns("NUM REMISIONES").HeaderText = "REMISION"
        End With

    End Sub
   'Private Sub CargarResumen(ByVal mNumOrden As Integer)
   '     Dim obCntv As New clConectividad
   '     Dim drCabResumen As MSSQL.SqlDataReader = obCntv.LeerValor("*", "VW_ResumenProduccion", "NumOrden=" & mNumOrden.ToString & " ORDER BY ResCab_ID, ResDet_ID ", My.Settings.cnnModProd)
   '     Dim strFilaNueva() As String

   '     grConsolidado.Rows.Clear()


   '     If drCabResumen.HasRows = True Then
   '       Do
   '         If drCabResumen.Item("ResDet_Id").ToString <> "" Then
   '                 strFilaNueva = {
   '                     drCabResumen.Item("ResCab_ID").ToString,
   '                     drCabResumen.Item("ResDet_ID").ToString,
   '                     drCabResumen.Item("Maquina").ToString,
   '                     drCabResumen.Item("Operario").ToString,
   '                     drCabResumen.Item("Tarea").ToString,
   '                     CDec(drCabResumen.Item("Horas").ToString).ToString(FCANT)
   '                 }

   '               grConsolidado.Rows.Add(strFilaNueva)
   '           End If
   '       Loop While drCabResumen.Read()
   '     End If


   '     With grConsolidado
   '         For Cc = 0 To .Columns.Count - 1
   '             .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
   '             .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Regular, GraphicsUnit.Point)
   '             .Columns(Cc).ReadOnly = True
   '             .Columns(Cc).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
   '             .Columns(Cc).HeaderText = UCase(.Columns(Cc).HeaderText)
   '         Next


   '         .Columns("colResCab_ID3").Width = 70 : .Columns("colResCab_ID3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
   '         .Columns("colResDet_ID3").Width = 70 : .Columns("colResDet_ID3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
   '         .Columns("colCodInventario3").Width = 128 : .Columns("colCodInventario3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
   '         .Columns("colDescripcion3").Width = 400 : .Columns("colDescripcion3").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
   '         .Columns("colTareaMotivo").Width = 400 : .Columns("colTareaMotivo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
   '         .Columns("colHorasCantidad").Width = 120 : .Columns("colHorasCantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight






   '     End With
   '     Dim Ff As Integer

   '     With grProductos
   '      For Ff = 0 To .Rows.Count - 1
   '           If CDec(.Item("colCntFaltante", Ff).Value) = 0 Then
   '               .Item("colCntFaltante", Ff).Style.BackColor = Color.Green  '(0, 255, 0)
   '           Else
   '             .Item("colCntFaltante", Ff).Style.BackColor = Color.Red '(0, 255, 0)
   '           End If

   '         Next
   '     End With
   ' End Sub


  ' Private Sub CargarMaterialesAjustados()
  '  Dim dtMaterialesAjustados As DataTable


  '   Call EstableceModoColumnas(grProductosDiv)

  'End Sub

  'Private Sub btnAdicionarDiv_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  '  'WC es abreviación de Work Center, o punto de uso
  '    Dim Ff As Integer, strLinea() As String, WC_Ff As Integer, WC_Desc As String

  '    WC_Ff = 1 : WC_Desc = cmbWorkCenter.Text


  '      For Ff = 0 To grProductosDiv.Rows.Count - 1
  '        If grProductosDiv.Item("dicCol_chkAdicionar", Ff).Value = True Then
  '            strLinea = {
  '                WC_Ff,
  '                WC_Desc,
  '                grProductosDiv.Item("divCol_Codigo", Ff).Value.ToString,
  '                grProductosDiv.Item("divCol_Descripcion", Ff).Value.ToString,
  '                grProductosDiv.Item("divCol_CantidadAdd", Ff).Value.ToString
  '                }

  '            grReportar.Rows.Add(strLinea)
  '            grProductosDiv.Item("dicCol_chkAdicionar", Ff).Value = False
  '        End If
  '      Next

  'End Sub

  '/* SECCION ESPECIAL PARA MAQUILLAR LA GRILLA*/

  'Private Function IsTheSameCellValue(ByVal Column As Integer, ByVal Row As Integer) As Boolean
  '    Dim cell1 As DataGridViewCell = grReportar.Rows(Row).Cells(Column)
  '    Dim cell2 As DataGridViewCell = grReportar.Rows(Row - 1).Cells(Column)

  '    If (cell1.Value Is Nothing Or cell2 Is Nothing) Then
  '      Return False
  '    End If

  '    Return cell1.Value.ToString = cell2.Value.ToString
  'End Function




  'Private Sub grReportar_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs)
  '  If (e.ColumnIndex = 0 OrElse e.ColumnIndex = 1) Then
  '      e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

  '      If (e.RowIndex < 1 OrElse e.ColumnIndex < 0) Then
  '          Return
  '      End If


  '      If (IsTheSameCellValue(e.ColumnIndex, e.RowIndex)) Then
  '          e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None
  '      Else
  '          e.AdvancedBorderStyle.Top = grReportar.AdvancedCellBorderStyle.Top
  '      End If
  '  End If
  'End Sub


  'Private Sub grReportar_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs)
  '  If (e.ColumnIndex = 0 OrElse e.ColumnIndex = 1) Then
  '      If (e.RowIndex = 0) Then
  '          Return
  '      End If


  '      If (IsTheSameCellValue(e.ColumnIndex, e.RowIndex)) Then
  '          e.Value = ""
  '          e.FormattingApplied = True
  '      End If
  '  End If
  'End Sub


  Private Sub CargarMaterialesAjustados(ByVal xOTCabCotizacion_Id As Integer, ByVal mTipo As String)
    Try

      'Dim Cotiza As Integer = mNumCotizacion

      Dim objCntv As New clConectividad ' fF As Integer
      Dim strConsulta As String = "Select "

      'CARGA LA CABECERA
      Dim drCabCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "CabCotizacion", "Tipo='" & mTipo & "' AND Id=" & xOTCabCotizacion_Id.ToString, My.Settings.cnnModProd)


      'CARGA EL DETALLE
      grProductosNORevisados.Rows.Clear()
      grProductosRevisados.Rows.Clear()
      grMatST.Rows.Clear()
      'grEmpleados.Rows.Clear()
      Dim drDetCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "VW_DetalleOTconStock", "Cab_ID =" & drCabCotiza.Item("id").ToString & " and tipo in (1,2) order by id", My.Settings.cnnModProd)

      Dim pmEstadoRevisado As Boolean = False


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
                                  CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                  CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                  drDetCotiza.Item("DescItem").ToString,
                                  CDec(drDetCotiza.Item("Disponible").ToString).ToString(FCANT),
                                  CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT),
                                  CDec(drDetCotiza.Item("Cnt_PDEliminados").ToString).ToString(FCANT),
                                  CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
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

                    '20211107 - Se incluye ST - Subtareas
                    If drDetCotiza.Item("DisponibleSubt").ToString > 0 Then


                      strFilaNueva = {
                        False,
                        grMatST.Rows.Count + 1,
                        drDetCotiza.Item("Inventario_Id").ToString,
                        drDetCotiza.Item("Inventario_Id").ToString & " - " & drDetCotiza.Item("CodInventario").ToString,
                        CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                        CDec(drDetCotiza.Item("DisponibleSubt").ToString).ToString(FCANT),
                        0,
                        drDetCotiza.Item("ID").ToString
                      }
                      grMatST.Rows.Add(strFilaNueva)
                    End If

            Else
                  strFilaNueva = {grProductosNORevisados.Rows.Count + 1,
                                drDetCotiza.Item("Inventario_ID").ToString,
                                drDetCotiza.Item("CodInventario").ToString,
                                CDec(drDetCotiza.Item("Costo").ToString).ToString(FCTO_U),
                                CDec(drDetCotiza.Item("CostoTotal").ToString).ToString(FCTOTOT),
                                drDetCotiza.Item("DescItem").ToString,
                                CDec(drDetCotiza.Item("Disponible").ToString).ToString(FCANT),
                                CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT),
                                CDec(drDetCotiza.Item("Cnt_PDEliminados").ToString).ToString(FCANT),
                                CDec(drDetCotiza.Item("Cant").ToString).ToString(FCANT),
                                True, IIf(CDec(drDetCotiza.Item("Cnt_Comprar").ToString).ToString(FCANT) > 0, True, False),
                                "", pmEstadoRevisado, CInt(pmEstadoRevisado), drDetCotiza.Item("ID").ToString} 'ONYX, ACA VOY

                  grProductosNORevisados.Rows.Add(strFilaNueva)
            End If


          End If
        End If

      Loop While drDetCotiza.Read()


      Call EstableceModoColumnas(grProductosNORevisados)
      Call EstableceModoColumnas(grProductosRevisados)

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try
  End Sub


  Private Sub CargarRemision(ByVal NumOrden As String)
    Dim obCntv As New clConectividad, strCampos As String

    strCampos = "Id [REMISION], NumOrden [OT], Cantidad [CANT], NombreCliente [CLIENTE], TransportadoPor [TRANSPORTADOR], Placas [PLACAS], DespachadoPor [DESPACHADOR], Fecha [FECHA], Estado [ESTADO]"
    grRemisiones.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_Remisiones", "NumOrden=" & NumOrden.ToString)



    strCampos = "Id [REMISION], Fecha [FECHA REMISION], TipoDespacho [DESPACHO]"
    grRemisionesOT.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_Remisiones", "NumOrden=" & NumOrden.ToString)


    obCntv = Nothing


  End Sub


Private Sub btnGrabarAnexos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarAnexos.Click
    Call GrabarAnexos(mNumOrden, mCabOrden_Id)
    btnGrabarAnexos.Enabled = False
End Sub


Private Sub chkFacturas_ItemCheck(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)
    If e.CurrentValue = CheckState.Indeterminate Then
      e.NewValue = e.CurrentValue


    End If
End Sub


Private Sub btnFacAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFacAdicionar.Click
  If txtFactura.Text <> "" And txtValorFactura.Text <> "" Then
      Dim bolComprar As Boolean = True
      'If CDec(txtAComprar.Text) = 0 Then bolComprar = False

      Dim strFilaNueva() As String = {txtFactura.Text,
                                      CType(dtpFechaFactura.Value, DateTime).ToShortDateString,
                                      CDec(txtValorFactura.Text).ToString(FCTOTOT),
                                      "Eliminar"
                                      } '*** REVISAR PUNTO ACA ***

      grFacturasOT.Rows.Add(strFilaNueva)
      txtFactura.Text = "" : dtpFechaFactura.Value = Date.Today() : txtValorFactura.Text = ""


    Else
      MessageBox.Show("Debe especificar datos de factura!", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

    End If
End Sub

Private Sub txtValorFactura_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValorFactura.KeyPress
    If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True

        'If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
        '    Call Calcular()
        'End If
End Sub


  Private Sub chkCerrarOT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCerrarOT.CheckedChanged
    Dim mChk As CheckBox = sender


    If grFacturasOT.Rows.Count > 0 Then
      btnGrabar.Visible = chkCerrarOT.Checked
    Else
      chkCerrarOT.Checked = False
    End If
  End Sub




  Private Sub cmbEstadoActual_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstadoActual.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbEstadoActual.SelectedItem
    strIdEstadoActual = selectedItem("id").ToString
    strNombreEstadoActual = selectedItem("Nombre").ToString
    strEstadoActual = selectedItem("Estado").ToString


    'If CInt(strIdEstadoActual) < 16 Then
    '  MessageBox.Show("No tiene permisos para retornar al estado " & UCase(strNombreEstadoActual), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

    '  cmbEstadoActual.SelectedIndex = cmbEstadoActual.FindStringExact(mNombreEstadoActual)

    'End If

  End Sub




  Private Sub grFacturasOT_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grFacturasOT.CellContentClick
    Dim senderGrid = DirectCast(sender, DataGridView)

    If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso e.RowIndex >= 0 Then
    'TODO - Button Clicked - Execute Code Here
      grFacturasOT.Rows.RemoveAt(e.RowIndex)



    End If

  End Sub

    Private Sub HabilitaEdicionResponsable(ByVal mUsuario_Id As Integer)

        Dim obCntv As New clConectividad

        Dim drEstado As MSSQL.SqlDataReader, mPermisoResp As Integer, mEstado As Integer

        mPermisoResp = obCntv.LeerValorSencillo("count(Cantidad) Cantidad", "Cantidad", "VW_PermisosUsuarioXBoton", "Usuario_Id = " & mUsuario_Id & " and Frm = 'frmOrdenDetrabajo' and Objeto ='cmbAsignadaA'", My.Settings.cnnModProd)
        'mEstado = obCntv.LeerValorSencillo (

        'Dim drCantidad As MSSQL.SqlDataReader
        'drCantidad = obCntv.LeerValor("Cantidad", "VW_PermisosUsuarioXBoton", mWhere, My.Settings.cnnModProd)

        drEstado = obCntv.LeerValor("*", "VW_Estados_X_Usuario", "Usuario_Id = " & mUsuario_Id & " and Estado ='" & strEstadoActual & "'", My.Settings.cnnModProd)

        If drEstado.HasRows Then
            mEstado = 1
            btnGrabar.Visible = True
        Else
          mEstado = 0
          btnGrabar.Visible = False
        End If


        If mPermisoResp > 0 And mEstado = 1 Then
            cmbAsignadaA.Visible = True : txtAsignadaA.Visible = False
            btnGrabar.Visible = True
        Else
            cmbAsignadaA.Visible = False
            txtAsignadaA.Text = cmbAsignadaA.Text
            txtAsignadaA.Visible = True : txtAsignadaA.Top = cmbAsignadaA.Top : txtAsignadaA.Left = txtAsignadaA.Left


        End If
    End Sub


 Private Sub HabilitaEdicionPresupuesto(ByVal mUsuario_Id As Integer)

        Dim obCntv As New clConectividad

        Dim mPermisoCupo As Integer, mEstado As Integer

        mPermisoCupo = obCntv.LeerValorSencillo("count(Cantidad) Cantidad", "Cantidad", "VW_PermisosUsuarioXBoton", "Usuario_Id = " & mUsuario_Id & " and Frm = 'frmOrdenDetrabajo' and Objeto ='TxtPresupuesto'", My.Settings.cnnModProd)

        If mPermisoCupo > 0 Then ' And mEstado = 1 Then
            'cmbAsignadaA.Visible = True : txtAsignadaA.Visible = False
            'TxtPresupuesto.ReadOnly = False
            txtCupo.ReadOnly = False
            btnGrabar.Visible = True
        Else
            'TxtPresupuesto.ReadOnly = True
            txtCupo.ReadOnly = True
        End If
    End Sub


Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

End Sub

Private Sub Label30_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label30.DoubleClick
    If mUsuarioId = 17 Then
      cmbAsignadaA.Visible = True
      cmbAsignadaA.Enabled = True
      txtAsignadaA.Visible = False
      Label55.Visible = True
      Label55.Text = "Re-asignando!"
    End If

    If Label55.Visible = True Then
      Label55.Visible = False


    End If

End Sub




Private Sub btnAdicionarSubT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarSubT.Click
  m_Tab = "SubTareasNuevas" 'Esta variable la usaré al momento de grabar

  Dim mEsVinculada As Boolean = False
  Dim ff As Integer
  Dim mDetener As Boolean = False, mCntSeleccion As Integer = 0

  '****************************************************************************************
  'VALIDACION DE SUB TAREAS VINCULADAS
  'Primero valido que no existan materiales seleccionado
   For ff = 0 To grMatST.RowCount - 1
      If grMatST.Item("colSubT_Adicionar", ff).Value = True Then
        mCntSeleccion = mCntSeleccion + 1

      End If
    Next

    If mCntSeleccion = 0 Then
      If grSubTareas.Item("colCabSubT_Estado", mFilaSubTVinculada).Value = "A" Then
        Dim _mMensaje As String = grSubTareas.Item("colItemSubT", mFilaSubTVinculada).Value & " - " & grSubTareas.Item("colDescSubT", mFilaSubTVinculada).Value

          'Valido que la fila vinculada, no esté vinculada a otra
          If grSubTareas.Item("colSubTVinvulada", mFilaSubTVinculada).Value <> "" Then
            'Or grSubTareas.Item("colSubTVinvulada", mFilaSubTVinculada).Value = Nothing Then
              MessageBox.Show("No se puede vincular con una tarea vinculada a otra tarea!", "Error vinculando", MessageBoxButtons.OK, MessageBoxIcon.Error)
              Exit Sub
          End If



          If MessageBox.Show("Desea vincular con la Sub Tarea:" & vbCrLf & _mMensaje, "Vincular Sub Tarea", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then

              MessageBox.Show("No se puede crear la subtarea." & vbCrLf & "Por favor revisar que ha seleccionado al menos un material, que las cantidades sean correctas y que se especifiquen las horas de trabajo.", "Error en subtarea", MessageBoxButtons.OK, MessageBoxIcon.Error)
              Exit Sub
          Else
            mEsVinculada = True
          End If

      End If
    End If

  If mEsVinculada = False Then
    '****************************************************************************************
      'VALIDACION DE SELECCION Y VALORES VALIDOS

      For ff = 0 To grMatST.RowCount - 1
        If grMatST.Item("colSubT_Adicionar", ff).Value = True Then
          mCntSeleccion = mCntSeleccion + 1

          If grMatST.Item("colST_CantST", ff).Value = 0 Then
            mDetener = True
          End If

          If CDec(grMatST.Item("colST_cantst", ff).Value) > CDec(grMatST.Item("CantPresupuesto", ff).Value) Then
            mDetener = True
          End If

        End If
      Next

      If mCntSeleccion = 0 Then mDetener = True
      If IIf(txtHoras.Text = "", "0", txtHoras.Text) = "0" Then mDetener = True

      If mDetener = True Then
        MessageBox.Show("No se puede crear la subtarea." & vbCrLf & "Por favor revisar que ha seleccionado al menos un material, que las cantidades sean correctas y que se especifiquen las horas de trabajo.", "Error en subtarea", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Exit Sub
      End If
  End If

    '******************************
    'ADICIONO LA CABECERA SUBT

    Dim strCabSubT() As String = { _
                    "",
                    txtSubT.Text,
                    cmbOperarios.Text,
                    dtpFI_SubT.Value.ToString,
                    "",
                    mCabSutT,
                    txtHoras.Text,
                    "A",
                    "Imprimir",
                    strOperatio_Id, IIf(mEsVinculada = True, mFilaSubTVinculada, "")
                  }

    grSubTareas.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    'Al cargar la OT, el campo CabSubT_Id de la grilla grSubTareas se debe llenar. Al agregar una fila nueva, va en blanco, de esta forma se diferencia al actualizar.
    grSubTareas.Rows.Add(strCabSubT)



  '****************************************************************************************
  'Recorro los materiales para al subtarea. VAN EN EL OBJETO PROPIEDAD DE LA CLASE SUBT
  Dim _Ff As Integer = 0
  For ff = 0 To grMatST.RowCount - 1
    If grMatST.Item("colSubT_Adicionar", ff).Value = True Then
      Dim NuevaFila = mObProd.TablaDetSubT.NewDetSubTRow

       NuevaFila("Cab_Id") = mCabSutT
       NuevaFila("Id") = _Ff + 1
       NuevaFila("CodInventario") = grMatST.Item("colST_Descripcion", ff).Value  'grSubTareas.Item(0, 0).Value
       NuevaFila("Inventario_ID") = grMatST.Item("colST_CodInventario", ff).Value
       NuevaFila("Cant") = grMatST.Item("colST_CantST", ff).Value
       NuevaFila("Unidad_Id") = 1
       NuevaFila("Estado") = "A"
       NuevaFila("DetCotizacion_Id") = grMatST.Item("colST_Det_Id", ff).Value
       NuevaFila("Tipo") = 1

       _Ff = _Ff + 1
       mObProd.TablaDetSubT.AddDetSubTRow(NuevaFila)

       'La copia para el DT del detalle en pantalla
        Dim _Nfila = dtDetSubT.NewRow
        With _Nfila
          .Item("OT_Cab_Id") = mOrdenDeTrabajo.CabOrden_Id
          .Item("Cab_Id") = mCabSutT
          .Item("Id") = _Ff + 1
          .Item("CodInventario") = grMatST.Item("colST_Descripcion", ff).Value  'grSubTareas.Item(0, 0).Value
          .Item("Inventario_ID") = grMatST.Item("colST_CodInventario", ff).Value
          .Item("Cant") = grMatST.Item("colST_CantST", ff).Value
          .Item("Unidad_Id") = 1
          .Item("Estado") = "A"
          .Item("DetCotizacion_Id") = grMatST.Item("colST_Det_Id", ff).Value
        End With
        dtDetSubT.Rows.Add(_Nfila)

       'LIMPIO TODO
       grMatST.Item("colSubT_Adicionar", ff).Value = False
       grMatST.Item("colSubT_CntDisp", ff).Value = grMatST.Item("colSubT_CntDisp", ff).Value - grMatST.Item("colST_CantST", ff).Value
       grMatST.Item("colST_CantST", ff).Value = 0

       txtHoras.Text = ""
       'cmbOperarios.SelectedValue = 1
       txtSubT.Text = ""

       If grMatST.Item("colSubT_CntDisp", ff).Value <= 0 Then grMatST.Rows(ff).Visible = False


    End If

  Next

  mCabSutT = mCabSutT - 1
  cmbOperarios.SelectedIndex = 0
  txtSubT.Text = ""
  txtHoras.Text = ""



End Sub

Private Sub grMatST_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grMatST.CellValidating, grMoST.CellValidating
    Dim cell As DataGridViewTextBoxCell = TryCast(grMatST(e.ColumnIndex, e.RowIndex), DataGridViewTextBoxCell)


    If e.ColumnIndex = 6 Then 'colST_CantST

      If cell IsNot Nothing Then
        If IsNumeric(e.FormattedValue.ToString) = False Then
          MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

          e.Cancel = True
        End If

      End If
    End If

End Sub


Private Sub TxtPresupuesto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
  Try
    If TxtPresupuesto.Text <> "" Then
      mCupo = TxtPresupuesto.Text
      TxtPresupuesto.Text = CDec(TxtPresupuesto.Text).ToString(FCTOTOT)

    End If
  Catch ex As System.InvalidCastException
    MessageBox.Show("No se permiten letras en el campo presupuesto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    TxtPresupuesto.Focus()
    TxtPresupuesto.SelectAll()

  End Try

End Sub


  Private Sub txtCupo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
    If txtCupo.Text <> "" Then
      txtCupo.Text = CDec(txtCupo.Text).ToString(FCTOTOT)
      TxtPresupuesto.Text = (CDec(txtMPCotizados.Text) + CDec(txtAIU_Aju.Text) + CDec(txtCupo.Text)).ToString(FCTOTOT)
    End If
  End Sub


    Private Sub lblCargando_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblCargando.TextChanged
        Me.Refresh()
    End Sub

    Private Sub frmOrdenDeTrabajo_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
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


    Private Sub ImprimirSubTarea(ByVal mNumOrden As Integer, ByVal mCabSubt_Id As Integer)
      lblAnimacionImpresion.Visible = True
      Me.Cursor = Cursors.WaitCursor

      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      'INICIO LA ASIGNACIÓN DE CAMPOS
      lblAnimacionImpresion.Text = "Leyendo configuración ..." : Me.Refresh()
      Dim strMargenes As String = obXml.LeerValor("frmRptSubTareas")
      Dim Pg2 As New System.Drawing.Printing.PageSettings()
      Dim Size2 = New Printing.PaperSize()
      Dim vctMedidas2() As String
      vctMedidas2 = Split(strMargenes, ",")
      Pg2.Margins.Top = CInt(vctMedidas2(0))
      Pg2.Margins.Bottom = CInt(vctMedidas2(1))
      Pg2.Margins.Left = CInt(vctMedidas2(2))
      Pg2.Margins.Right = CInt(vctMedidas2(3))
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


      Dim strOrden As String = txtNumOrden.Text  'InputBox("Número de Orden de Trabajo")

      lblAnimacionImpresion.Text = "Construyendo ventana informe ..." : Me.Refresh()
      Dim frm As New frmImprimeOT
      frm.strOrdenID = mNumOrden  'strOrden

      If MessageBox.Show("Desea imprimir todas las boletas de materiales?", "Imprimir boletas de material", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        frm.strCabSubt_Id = "%"
      Else
        frm.strCabSubt_Id = mCabSubt_Id
      End If



      frm.strNombreReporte = obXml.LeerValor("rptImprimeSubT")

      frm.rptReporte.SetPageSettings(Pg2)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)

      lblAnimacionImpresion.Text = "Leyendo datos ..." : Me.Refresh()
      frm.rptReporte.RefreshReport()

      lblAnimacionImpresion.Text = "Preparando informe ..." : Me.Refresh()
      frm.Show()

      lblAnimacionImpresion.Visible = False
      Me.Cursor = Cursors.Default


    End Sub



  Private Sub grSubTareas_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
     Handles grSubTareas.CellContentClick

    'Dim mGrilla As DataGridView = sender

    Dim senderGrid = DirectCast(sender, DataGridView)

        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
            e.RowIndex >= 0 Then

            If senderGrid.Columns(e.ColumnIndex).Name = "Col_ImprimirSubT" Then
              Call ImprimirSubTarea(mOrdenDeTrabajo.NumOrden, senderGrid.Item("CabSubT_Id", e.RowIndex).Value)
            End If
        End If

    End Sub


  Private Sub grMatST_CellValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grMatST.CellValueChanged
    If e.ColumnIndex = 6 And e.RowIndex > -1 Then
      If CDec(grMatST.Item("ColST_CantST", e.RowIndex).Value) > CDec(grMatST.Item("colSubT_CntDisp", e.RowIndex).Value) Then
        MessageBox.Show("No se puede adicionar, el valor del material supera el disponible!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        grMatST.Item("ColST_CantST", e.RowIndex).Value = 0
        'grMatST.CancelEdit()
      End If

    End If
  End Sub

  Private Sub FiltrarDetSubT(ByVal Fila As Integer)
      Dim dtFiltrado As Data.DataTable, strFiltro As String

      dtFiltrado = dtDetSubT.Clone
      strFiltro = "Cab_Id=" & grSubTareas.Item("Col_mCabSutT", Fila).Value
      Dim result() As DataRow = dtDetSubT.Select(strFiltro)

      For Each row As DataRow In result
        dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8))
        'dtFiltrado.Rows.Add(row(4), row(3), row(5), row(7))
      Next

      grSubTareasDet.DataSource = dtFiltrado

      grSubTareasDet.Columns(0).Visible = False : grSubTareasDet.Columns(1).Visible = False
      grSubTareasDet.Columns(2).Visible = False : grSubTareasDet.Columns(6).Visible = False
      grSubTareasDet.Columns(8).Visible = False

      grSubTareasDet.Columns(3).Width = 300 : grSubTareasDet.Columns(4).Width = 104
      grSubTareasDet.Columns(5).Width = 98 : grSubTareasDet.Columns(7).Width = 100

      grSubTareasDet.Columns(3).HeaderText = "Descripción"
      grSubTareasDet.Columns(4).HeaderText = "Código"
      grSubTareasDet.Columns(5).HeaderText = "Cantidad"

      'grSubTareasDet.Columns(0).Width = 
      'txtSubT.Text = grSubTareas.Item("colDescSubT", Fila).Value

  End Sub


  Private Sub grSubTareas_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) _
    Handles grSubTareas.CellEnter
    Dim mGrilla As DataGridView = DirectCast(sender, DataGridView)

    Call CargarDetalleSubT(e.RowIndex, mGrilla, grSubTareasDet)
  End Sub

   Private Sub grSubTareasNotif_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grSubTareasNotif.CellEnter
    Dim mGrilla As DataGridView = sender

    Call CargarDetalleSubT(e.RowIndex, mGrilla, grSubTareasDetNotif)

  End Sub


Private Sub grSubTareas_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)
    m_Tab = "SubTareasNuevas"
End Sub

  Private Sub ModoVistaAjusteMP()
    With grProductosRevisados
      .Columns("ColCosto2").Visible = False
      .Columns("ColStock2").Visible = False
      .Columns("ColCntComprar2").Visible = False
      .Columns("ColCostoTotal2").Visible = False
      .Columns("colCntPDEliminados").Visible = False

      .Columns("colId2").Width = 42
      .Columns("colCodigoInventario2").Width = 66
      .Columns("colDescripcion2").Width = 272
      .Columns("colCosto2").Width = 71
      .Columns("colCostoTotal2").Width = 106
      .Columns("colDescItem2").Width = 405
      .Columns("colStock2").Width = 100
      .Columns("colCntComprar2").Width = 100
      .Columns("colCntPDEliminados").Width = 100
      .Columns("colCantidad2").Width = 93
      .Columns("colAgregar2").Width = 60
      .Columns("colComprar2").Width = 52
      .Columns("colFechaRequerida2").Width = 100
      .Columns("colRevisado2").Width = 58
      .Columns("colSTRevisado2").Width = 100
      .Columns("colDet_Id2").Width = 100


    End With

     With grProductosNORevisados
      .Columns("DataGridViewTextBoxColumn10").Visible = False
      .Columns("colStock").Visible = False
      .Columns("colCntComprar").Visible = False
      .Columns("DataGridViewTextBoxColumn11").Visible = False
      '.Columns("colCntPDEliminados").Visible = False
      .Columns("DataGridViewTextBoxColumn6").Width = 42
      .Columns("DataGridViewTextBoxColumn7").Width = 66
      .Columns("DataGridViewTextBoxColumn8").Width = 272
      .Columns("DataGridViewTextBoxColumn10").Width = 71
      .Columns("DataGridViewTextBoxColumn11").Width = 106
      .Columns("DataGridViewTextBoxColumn12").Width = 405
      .Columns("colStock").Width = 100
      .Columns("colCntComprar").Width = 100
      .Columns("colCntPDEliminados2").Width = 100
      .Columns("DataGridViewTextBoxColumn9").Width = 93
      .Columns("DataGridViewCheckBoxColumn1").Width = 60
      .Columns("colComprar").Width = 52
      .Columns("colFechaRequerida").Width = 100
      .Columns("DataGridViewCheckBoxColumn2").Width = 58
      .Columns("colSTRevisado").Width = 100
      .Columns("colDet_Id").Width = 100

      .Columns("colComprar").Visible = False
      .Columns("DataGridViewCheckBoxColumn2").Visible = False
    End With
  End Sub

  Private Sub CargarCostosOT(ByVal _numOrden As Integer)

    Dim objCntv As New clConectividad ' fF As Integer
    Dim mCampos As String, Ff As Integer, strFila()

    'Dim dtVW_CostoComprasOT As DataTable
    mCampos = _
      "NumOrden," & _
      "OTCabCotizacion_Id," & _
      "OrdenDeCompra," & _
      "Inventario_ID," & _
      "CodInventario," & _
      "DescItem," & _
      "CantAjustado [Cant Ajustado]," & _
      "CantCompra [Cant Compra]," & _
      "CostoAjustado [Costo Ajustado]," & _
      "CostoCompra [Costo Compra]," & _
      "CostoTotalAjustado [Costo Total Ajustado]," & _
      "CostoTotalCompra [Costo Total Compra]," & _
      "Estado," & _
      "FechaOC"

    'Dim dtVW_CostoComprasOT As DataTable = objCntv.LlenarDataTable(My.Settings.cnnModProd, mCampos, "VW_CostoComprasOT", "NumOrden=" & _numOrden)
    Dim drCostos As MSSQL.SqlDataReader
    Dim mTotalCostoAjuste As Decimal, mTotalCostoCompra As Decimal

    drCostos = objCntv.LeerValor(mCampos, "VW_CostoComprasOT", "NumOrden=" & _numOrden, My.Settings.cnnModProd)

    grCostosOT.Rows.Clear()

    Do
      If drCostos.HasRows Then
          strFila = {
              drCostos.Item("NumOrden").ToString,
              drCostos.Item("OTCabCotizacion_Id").ToString,
              drCostos.Item("OrdenDeCompra").ToString,
              drCostos.Item("Inventario_ID").ToString,
              drCostos.Item("CodInventario").ToString,
              drCostos.Item("DescItem").ToString,
              CDec(drCostos.Item("Cant Ajustado").ToString).ToString(FCANT),
              CDec(drCostos.Item("Cant Compra").ToString).ToString(FCANT),
              CDec(drCostos.Item("Costo Ajustado").ToString).ToString(FCTO_U),
              CDec(drCostos.Item("Costo Compra").ToString).ToString(FCTO_U),
              CDec(drCostos.Item("Costo Total Ajustado").ToString).ToString(FCTO_U),
              CDec(drCostos.Item("Costo Total Compra").ToString).ToString(FCTO_U),
              drCostos.Item("Estado").ToString,
              drCostos.Item("FechaOC").ToString
            }

          mTotalCostoAjuste = mTotalCostoAjuste + drCostos.Item("Costo Total Ajustado")
          mTotalCostoCompra = mTotalCostoCompra + drCostos.Item("Costo Total Compra")

          grCostosOT.Rows.Add(strFila)
      End If
    Loop While drCostos.Read()


    If grCostosOT.Rows.Count > 0 Then
        strFila = {
              "",
              "",
              "",
              "",
              "",
              "",
              "",
              "",
              "",
              "Σ",
              CDec(mTotalCostoAjuste).ToString(FCTO_U),
              CDec(mTotalCostoCompra).ToString(FCTO_U),
              "",
              ""
            }
        grCostosOT.Rows.Add(strFila)
    End If

    'Dim miCol As DataGridViewColumn
    With grCostosOT
      .Columns("ColCtoNumOrden").Visible = False
      .Columns("ColCtoOTCabCotizacion_Id").Visible = False
      .Columns("ColCtoEstado").Visible = False

      .Columns("ColCtoCantAjustado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColCtoCantCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColCtoCostoAjustado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColCtoCostoCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColCtoCostoTotalAjustado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColCtoCostoTotalCompra").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

      .Columns("ColCtoNumOrden").Width = 100
      .Columns("ColCtoOTCabCotizacion_Id").Width = 160
      .Columns("ColCtoOrdenDeCompra").Width = 50
      .Columns("ColCtoInventario_ID").Width = 70
      .Columns("ColCtoCodInventario").Width = 260
      .Columns("ColCtoDescItem").Width = 340
      .Columns("ColCtoCantAjustado").Width = 70
      .Columns("ColCtoCantCompra").Width = 70
      .Columns("ColCtoCostoAjustado").Width = 90
      .Columns("ColCtoCostoCompra").Width = 90
      .Columns("ColCtoCostoTotalAjustado").Width = 100
      .Columns("ColCtoCostoTotalCompra").Width = 100
      .Columns("ColCtoEstado").Width = 70
      .Columns("ColCtoFechaOC").Width = 90

       If grCostosOT.Rows.Count > 0 Then
        .Item("ColCtoCostoCompra", grCostosOT.Rows.Count - 1).Style.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        .Item("ColCtoCostoTotalAjustado", grCostosOT.Rows.Count - 1).Style.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        .Item("ColCtoCostoTotalCompra", grCostosOT.Rows.Count - 1).Style.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
      End If
      '.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End With

  End Sub

Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim cc As Integer
    Dim strCadena As String

    For cc = 0 To grCostosOT.Columns.Count - 1
      strCadena = strCadena & ".Columns(|" & grCostosOT.Columns(cc).Name & "|).Width =" & grCostosOT.Columns(cc).Width & vbCrLf

    Next

    'For cc = 0 To grProductosRevisados.Columns.Count - 1
    '  strCadena = strCadena & ".Columns(|" & grProductosRevisados.Columns(cc).Name & "|).Width =" & grProductosRevisados.Columns(cc).Width & vbCrLf

    'Next
End Sub


Private Sub txtHoras_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtHoras.Validating
  If txtHoras.Text = "" Then Exit Sub

    If IsNumeric(sender.text.ToString) = False Then
            MessageBox.Show("Solamente se aceptan números!", "Datos no válidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)


            e.Cancel = True

    End If
End Sub




Private Sub cmbOperarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperarios.SelectedIndexChanged
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

Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    Dim cc As Integer
    Dim strSalida As String = ""

    For cc = 0 To grMatST.Columns.Count - 1
      strSalida = strSalida & cc.ToString & " - " & grMatST.Columns(cc).HeaderText & " - " & grMatST.Columns(cc).Width & vbCrLf
    Next

    MsgBox(strSalida)

End Sub


Private Sub chkCierreTecnico_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCierreTecnico.CheckedChanged
    grpCierreOTFacturas.Enabled = Not chkCierreTecnico.Checked
    grpCierreOTOtrosCampos.Enabled = Not chkCierreTecnico.Checked
End Sub



Private Sub btnMasMaterial_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasMaterial.Click
  Dim _mItem As String, _mCabSutT As Integer
  Dim _Fila As Integer

    '****************************************************************************************
    'VALIDACION DE SELECCION Y VALORES VALIDOS
    Dim mDetener As Boolean = False, mCntSeleccion As Integer = 0
    For ff = 0 To grMatST.RowCount - 1
      If grMatST.Item("colSubT_Adicionar", ff).Value = True Then
        mCntSeleccion = mCntSeleccion + 1

        If grMatST.Item("colST_CantST", ff).Value = 0 Then
          mDetener = True
        End If

        If CDec(grMatST.Item("colST_cantst", ff).Value) > CDec(grMatST.Item("CantPresupuesto", ff).Value) Then
          mDetener = True
        End If

      End If
    Next

    If mCntSeleccion = 0 Then mDetener = True

    If mDetener = True Then
      MessageBox.Show("No se ha seleccionado material para adicionar." & vbCrLf & "Por favor revisar que ha seleccionado al menos un material, que las cantidades sean correctas.", "Error en subtarea", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    '******************************

  _Fila = grSubTareas.CurrentRow.Index
  _mCabSutT = grSubTareas.Item("CabSubT_Id", _Fila).Value
  _mItem = grSubTareas.Item("colItemSubT", _Fila).Value

  If grSubTareas.Item("colCabSubT_Estado", _Fila).Value <> "A" Then
      MessageBox.Show("No se puede modificar Subtareas Planificadas o Notificadas.", "Error en subtarea", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
  End If


  If MessageBox.Show("Desea adicionar material a la sub tarea " & _mItem & "?", "Adicionar material", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
    Exit Sub
  End If


  'Recorro los materiales para al subtarea. VAN EN EL OBJETO PROPIEDAD DE LA CLASE SUBT
  Dim _Ff As Integer = 0
  For ff = 0 To grMatST.RowCount - 1
    If grMatST.Item("colSubT_Adicionar", ff).Value = True Then
      Dim NuevaFila = mObProd.TablaDetSubT.NewDetSubTRow

       NuevaFila("Cab_Id") = _mCabSutT
       NuevaFila("Id") = _Ff + 1
       NuevaFila("CodInventario") = grMatST.Item("colST_Descripcion", ff).Value  'grSubTareas.Item(0, 0).Value
       NuevaFila("Inventario_ID") = grMatST.Item("colST_CodInventario", ff).Value
       NuevaFila("Cant") = grMatST.Item("colST_CantST", ff).Value
       NuevaFila("Unidad_Id") = 1
       NuevaFila("Estado") = "A"
       NuevaFila("DetCotizacion_Id") = grMatST.Item("colST_Det_Id", ff).Value
       NuevaFila("Tipo") = 1
       _Ff = _Ff + 1
       mObProd.TablaDetSubT.AddDetSubTRow(NuevaFila)



       'La copia para el DT del detalle en pantalla
        Dim _Nfila = dtDetSubT.NewRow
        With _Nfila
          .Item("OT_Cab_Id") = mOrdenDeTrabajo.CabOrden_Id
          .Item("Cab_Id") = _mCabSutT
          .Item("Id") = _Ff + 1
          .Item("CodInventario") = grMatST.Item("colST_Descripcion", ff).Value  'grSubTareas.Item(0, 0).Value
          .Item("Inventario_ID") = grMatST.Item("colST_CodInventario", ff).Value
          .Item("Cant") = grMatST.Item("colST_CantST", ff).Value
          .Item("Unidad_Id") = 1
          .Item("Estado") = "A"
          .Item("DetCotizacion_Id") = grMatST.Item("colST_Det_Id", ff).Value
        End With
        dtDetSubT.Rows.Add(_Nfila)

       'LIMPIO TODO
       grMatST.Item("colSubT_Adicionar", ff).Value = False
       grMatST.Item("colSubT_CntDisp", ff).Value = grMatST.Item("colSubT_CntDisp", ff).Value - grMatST.Item("colST_CantST", ff).Value
       grMatST.Item("colST_CantST", ff).Value = 0

       txtHoras.Text = ""
       'cmbOperarios.SelectedValue = 1
       txtSubT.Text = ""

       If grMatST.Item("colSubT_CntDisp", ff).Value <= 0 Then grMatST.Rows(ff).Visible = False

       Call CargarDetalleSubT(_Fila, grSubTareas, grSubTareasDet)
        m_Tab = "SubTareasNuevas"


    End If

  Next

End Sub


  Private Sub btnMasMaterial2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasMaterial2.Click
    btnMasMaterial2.Text = "... Cargando!"
    Me.Refresh()
    Call PedirMasMaterial()

    btnMasMaterial2.Text = "Ajustar MP"
    Me.Refresh()

  End Sub

  Private Sub PedirMasMaterial()
    Dim Frm As New frmProductosOT
    Dim Cotiza As Integer
    Cotiza = mNumCotiza
    Frm.NumCotizacionOriginal = Cotiza
    Frm.NumeroOT = mNumOrden
    Frm.CabOrden_Id = mCabOrden_Id
    Frm.OTCabCotizacion_Id = mOTCabCotizacion_Id

    Dim mBoton As New Button
    mBoton.Name = "btnVentana" & mNumOrden
    Frm.Tag = mBoton
    Frm.mTipoEntrada = "ModalMasMaterial"

    Frm.ShowDialog()
    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
        Call CargarMaterialesAjustados(mOTCabCotizacion_Id, "OT")

    End If
  End Sub




  Private Sub grSubTareas_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles grSubTareas.SelectionChanged

    Dim mGrilla As DataGridView = sender

  ' Verificar si se ha seleccionado al menos una fila
    If mGrilla.SelectedRows.Count > 0 Then
        ' Obtener la primera fila seleccionada (en caso de selección múltiple)
        Dim filaSeleccionada As DataGridViewRow = mGrilla.SelectedRows(0)

        ' Luego, puedes acceder a los datos de la fila seleccionada, por ejemplo:
        Dim valorCelda As String = filaSeleccionada.Cells("colCabSubT_Estado").Value.ToString()

        mFilaSubTVinculada = filaSeleccionada.Index
        ' O hacer cualquier otra operación con la fila seleccionada
        ' ...
    End If


  End Sub

Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionarEvento.Click
    If txtEvento.Text <> "" Then

      Dim strFilaNueva() As String = {dtpFechaEvento.Value,
                                      txtEvento.Text,
                                      "SI"
                                      } '*** REVISAR PUNTO ACA ***

      grBitacora.Rows.Add(strFilaNueva)

      txtEvento.Text = ""


    End If
End Sub

  Private Sub GrabarBitacora()
    Dim Ff As Integer, MaxId As Integer
    Dim obCntv As New clConectividad, obProd As New clProduccion

    'mObProd.MaxDetId = mObCntv.LeerValorSencillo("ISNULL(max(Id) +1,1) as [MaxId]", "MaxId", "DetSubT", "Cab_ID = " & mCab_Id, My.Settings.cnnModProd)

    MaxId = obCntv.LeerValorSencillo("ISNULL(max(Id) +1,1) as [MaxId]", "MaxId", "BitacoraOT", "1 = 1", My.Settings.cnnModProd)

    For Ff = 0 To grBitacora.Rows.Count - 1
      If grBitacora.Item("colEventoEsNuevo", Ff).Value = "SI" Then
        obProd.GrabarBitacoraOT(My.Settings.cnnModProd, "Insert", MaxId, mOrdenDeTrabajo.CabOrden_Id, _
          grBitacora.Item("colBitFecha", Ff).Value, mUsuarioId, grBitacora.Item("colBitEvento", Ff).Value, "A")

        MaxId = MaxId + 1

      ElseIf grBitacora.Item("colEventoEsNuevo", Ff).Value = "EDITADO" Then
        obProd.GrabarBitacoraOT(My.Settings.cnnModProd, "UPDATE", grBitacora.Item("colBitacora_ID", Ff).Value, mOrdenDeTrabajo.CabOrden_Id, _
          grBitacora.Item("colBitFecha", Ff).Value, mUsuarioId, grBitacora.Item("colBitEvento", Ff).Value, "A")

      End If

      grBitacora.Item("colEventoEsNuevo", Ff).Value = ""

    Next


  End Sub

  Public Sub CargarBitacora()
  Dim obCntv As New clConectividad, drBitacoraOT As MSSQL.SqlDataReader

      drBitacoraOT = obCntv.LeerValor("*", "BitacoraOT", "Estado='A' and CabOT_ID=" & mCabOrden_Id, My.Settings.cnnModProd)
      grBitacora.Rows.Clear()

      Do
        If drBitacoraOT.HasRows = True Then
          Dim strBitacoraOT() As String = { _
                          drBitacoraOT.Item("FechaEvento"),
                          drBitacoraOT.Item("Evento"),
                          "",
                          drBitacoraOT.Item("ID")
                          }

            grBitacora.Rows.Add(strBitacoraOT)
          End If
      Loop While drBitacoraOT.Read()
  End Sub


  Private Sub grBitacora_CellValidating(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles grBitacora.CellValidating

    Dim cell As DataGridViewTextBoxCell = TryCast(grBitacora(e.ColumnIndex, e.RowIndex), DataGridViewTextBoxCell)

    If e.ColumnIndex = 1 Then 'colST_CantST
        If Not IsDBNull(cell.Value) Then
          If cell IsNot Nothing Then
            If grBitacora.Item("colEventoEsNuevo", e.RowIndex).Value = "" Then
              grBitacora.Item("colEventoEsNuevo", e.RowIndex).Value = "EDITADO"
            End If
          End If
        End If

    End If


  End Sub

#Region "SOBRECARGA DE CARGAR SUB TAREAS"

  Private Sub CargaSubTareas(ByVal mCabOrden_Id As Integer)
      Dim obCntv As New clConectividad, drSubT As MSSQL.SqlDataReader

      '*********************AJUSTAR CON PERMISOS ESTA VARIABLE ********
      mUsuarioAutorizaAddMP = True

      drSubT = obCntv.LeerValor("*", "vw_CabSubT", "Tipo='ST' and Estado in ('A','N','P') and OT_Cab_Id=" & mCabOrden_Id, My.Settings.cnnModProd)
      'drSubT.Read()

      grSubTareasDet.DataSource = Nothing
      grSubTareas.Rows.Clear()

      Do
        If drSubT.HasRows = True Then
          Dim strCabSubT() As String = { _
                          StrDup(3 - Len(drSubT.Item("Item")), "0") & drSubT.Item("Item"),
                          LTrim(drSubT.Item("Descripcion")),
                          drSubT.Item("AsignadaA"),
                          drSubT.Item("Fecha"),
                          drSubT.Item("Id"),
                          drSubT.Item("Id"),
                          drSubT.Item("Horas"),
                          drSubT.Item("N. Estado"),
                          "Imprimir",
                          drSubT.Item("operario_id"),
                          IIf(IsDBNull(drSubT.Item("SubT_Cab_Id")) = True, "", drSubT.Item("SubT_Cab_Id"))
                          }

            grSubTareas.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Al cargar la OT, el campo CabSubT_Id de la grilla grSubTareas se debe llenar. Al agregar una fila nueva, va en blanco, de esta forma se diferencia al actualizar.
            grSubTareas.Rows.Add(strCabSubT)


            'FORMATO DE LAS SUBTAREAS
            Select Case drSubT.Item("Estado")
              Case "A"
                  Call ColorFila(grSubTareas.Rows.Count - 1, Color.Red)
              Case "I"
                Call ColorFila(grSubTareas.Rows.Count - 1, Color.Gray)
              Case "N"
                Call ColorFila(grSubTareas.Rows.Count - 1, Color.Green)
              Case "P"
                Call ColorFila(grSubTareas.Rows.Count - 1, Color.Yellow)
              Case "T"
                Call ColorFila(grSubTareas.Rows.Count - 1, Color.Green)
            End Select



        End If

      Loop While drSubT.Read()

      'EL DETALLE DE LAS SUBTAREAS
      dtDetSubT = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_DetSubT", "Estado='A' and OT_Cab_ID=" & mOrdenDeTrabajo.CabOrden_Id)
      'grSubTareasDet.DataSource = dtDetSubT
      If grSubTareas.Rows.Count > 0 Then
        Call FiltrarDetSubT(0)
      End If


      grSubTareas.Columns("colDescSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft



  End Sub



  Private Sub CargaSubTareas(ByVal mCabOrden_Id As Integer, ByRef mGrilla As DataGridView, ByRef mGrillaDet As DataGridView, ByVal mTipo As String)
      Dim obCntv As New clConectividad, drSubT As MSSQL.SqlDataReader

      '*********************AJUSTAR CON PERMISOS ESTA VARIABLE ********
      mUsuarioAutorizaAddMP = True

      drSubT = obCntv.LeerValor("*", "vw_CabSubT", "Tipo='" & mTipo & "' and Estado in ('A','N','P','T') and OT_Cab_Id=" & mCabOrden_Id, My.Settings.cnnModProd)
      'drSubT.Read()

      grSubTareasDet.DataSource = Nothing ' este se asigna en el filtro
      mGrilla.Rows.Clear()

      'grSubTareas

      Do
        If drSubT.HasRows = True Then
          Dim strCabSubT() As String = { _
                          StrDup(3 - Len(drSubT.Item("Item")), "0") & drSubT.Item("Item"),
                          drSubT.Item("Descripcion").ToString.TrimStart,
                          drSubT.Item("AsignadaA"),
                          drSubT.Item("Fecha"),
                          drSubT.Item("Id"),
                          drSubT.Item("Id"),
                          drSubT.Item("Horas"),
                          drSubT.Item("N. Estado"),
                          "Imprimir",
                          drSubT.Item("operario_id"),
                          IIf(IsDBNull(drSubT.Item("SubT_Cab_Id")) = True, "", drSubT.Item("SubT_Cab_Id")),
                          IIf(IsDBNull(drSubT.Item("porc")) = True, "", drSubT.Item("porc")),
                          IIf(IsDBNull(drSubT.Item("Observacion")) = True, "", drSubT.Item("Observacion"))
                          }


            If mGrilla.Name = "grSubTareas" Then
              mGrilla.Columns("Col_ImprimirSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
              mGrilla.Columns("colDescSubT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft
            End If
            'Al cargar la OT, el campo CabSubT_Id de la grilla grSubTareas se debe llenar. Al agregar una fila nueva, va en blanco, de esta forma se diferencia al actualizar.
            mGrilla.Rows.Add(strCabSubT)


            'FORMATO DE LAS SUBTAREAS
            Select Case drSubT.Item("Estado2")
              Case "A"
                  Call ColorFila(mGrilla, mGrilla.Rows.Count - 1, Color.FromArgb(255, 51, 51), Color.Black)
              Case "I"
                Call ColorFila(mGrilla, mGrilla.Rows.Count - 1, Color.Gray, Color.Black)
              Case "N"
                Call ColorFila(mGrilla, mGrilla.Rows.Count - 1, Color.FromArgb(198, 224, 180), Color.Black)
              Case "P"
                Call ColorFila(mGrilla, mGrilla.Rows.Count - 1, Color.FromArgb(255, 255, 153), Color.Black)
              Case "T"
                Call ColorFila(mGrilla, mGrilla.Rows.Count - 1, Color.FromArgb(198, 224, 180), Color.Black)
            End Select
        End If

      Loop While drSubT.Read()

      If mGrilla.Name = "grSubTareasNotif" Then
        'EL DETALLE DE LAS SUBTAREAS
        dtDetSubT = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_DetSubT", "Estado='A' and OT_Cab_ID=" & mOrdenDeTrabajo.CabOrden_Id, "Order by Fecha")
        'grSubTareasDet.DataSource = dtDetSubT
        'If grSubTareas.Rows.Count > 0 Then
        If mGrilla.Rows.Count > 0 Then
          Call FiltrarDetSubT(0, mGrilla, mGrillaDet)
        End If

        'If mGrilla.Name = "grSubTareasNotif" Then
           mGrilla.Columns("Col_ImprimirSubTNotif").Visible = False
      End If

      'mGrilla.ClearSelection()
      'mGrilla.Refresh()

  End Sub


  Private Sub FiltrarDetSubT(ByVal Fila As Integer, ByRef mGrilla As DataGridView, ByRef mGrillaDet As DataGridView)
      Dim dtFiltrado As Data.DataTable, strFiltro As String

      dtFiltrado = dtDetSubT.Clone

      'If mGrilla.Name = "" Then
        strFiltro = "Cab_Id=" & mGrilla.Item(5, Fila).Value 'Col_mCabSutT
      'Else
      '  strFiltro = "Cab_Id=" & mGrilla.Item("Col_mCabSutTNotif", Fila).Value
      'End If


      Dim result() As DataRow = dtDetSubT.Select(strFiltro)

      For Each row As DataRow In result
        'dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), CDec(row(6)).ToString(FCANT), row(7), row(8), row(9), row(10), row(11), row(12), CDec(row(13)).ToString(FCANT))

        dtFiltrado.Rows.Add(
              row("Descripcion"),
              row("OT_Cab_ID"),
              row("Fecha"),
              row("Cab_Id"),
              row("Id"),
              row("CodInventario"),
              row("Inventario_ID"),
              CDec(row("Cant")).ToString(FCANT),
              row("Unidad_Id"),
              row("Estado"),
              row("DetCotizacion_Id"),
              row("TipoSubT"),
              row("Tipo"),
              row("Item"),
              CDec(row("CANT_NT")).ToString(FCANT)
          )

        'dtFiltrado.Rows.Add(row(4), row(3), row(5), row(7))
      Next

      mGrillaDet.DataSource = dtFiltrado

      'Pongo todo oculto
      Dim Cc As Integer
      For Cc = 0 To mGrillaDet.Columns.Count - 1
        mGrillaDet.Columns(Cc).Visible = False
      Next Cc

      If mGrillaDet.Name = "grSubTareasDetNotif" Then
        mGrillaDet.Columns("ID").Visible = True
        mGrillaDet.Columns("Fecha").Visible = True
        mGrillaDet.Columns("CodInventario").Visible = True
        mGrillaDet.Columns("Cant").Visible = True
        mGrillaDet.Columns("Cant_NT").Visible = True
      Else
        mGrillaDet.Columns("ID").Visible = True
        mGrillaDet.Columns("Fecha").Visible = True
        mGrillaDet.Columns("CodInventario").Visible = True
        mGrillaDet.Columns("Cant").Visible = True
      End If

      mGrillaDet.Columns("Fecha").Width = 120
      mGrillaDet.Columns("ID").Width = 80 : mGrillaDet.Columns("CodInventario").Width = 350
      mGrillaDet.Columns("Cant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      mGrillaDet.Columns("Cant_NT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


      'mGrillaDet.Columns(0).Visible = False : mGrillaDet.Columns(1).Visible = False
      'mGrillaDet.Columns(2).Visible = False : mGrillaDet.Columns(6).Visible = False
      'mGrillaDet.Columns(8).Visible = False

      'mGrillaDet.Columns(3).Width = 300 : mGrillaDet.Columns(4).Width = 104
      'mGrillaDet.Columns(5).Width = 98 : mGrillaDet.Columns(7).Width = 100

      'mGrillaDet.Columns(3).HeaderText = "Descripción"
      'mGrillaDet.Columns(4).HeaderText = "Código"
      'mGrillaDet.Columns(5).HeaderText = "Cantidad"



  End Sub

   Private Sub ColorFila(ByVal mFf As Integer, ByVal mColor As Color)
      For CC = 0 To grSubTareas.Columns.Count - 1
        grSubTareas.Item(CC, mFf).Style.BackColor = mColor
      Next CC
  End Sub

   Private Sub ColorFila(ByRef mGrilla As DataGridView, ByVal mFf As Integer, ByVal mColor As Color, ByVal mColorFuente As Color)
      For CC = 0 To mGrilla.Columns.Count - 1
        mGrilla.Item(CC, mFf).Style.BackColor = mColor
        mGrilla.Item(CC, mFf).Style.ForeColor = mColorFuente
      Next CC
  End Sub

  Private Sub CargarDetalleSubT(ByVal Fila As Integer, ByVal mGrilla As DataGridView, ByRef mGrillaDet As DataGridView)
    Call FiltrarDetSubT(Fila, mGrilla, mGrillaDet)

    If mUsuarioAutorizaAddMP = True And mGrilla.Item(7, Fila).Value <> "N" Then ' "colCabSubT_Estado"
        btnMasMaterial.Visible = True
    Else
      btnMasMaterial.Visible = False
    End If


  End Sub



  Private Sub DataGridView1_RowStateChanged(ByVal sender As Object, ByVal e As DataGridViewRowStateChangedEventArgs) Handles grSubTareasNotif.RowStateChanged
      Dim mGrilla As DataGridView = sender
      Dim mColor As Color
      Dim Ff As Integer = e.Row.Index

      mColor = mGrilla.Item(0, Ff).Style.BackColor

      ' Verificar si la fila está seleccionada
      If e.StateChanged = DataGridViewElementStates.Selected Then
          ' Cambiar el color de fondo de la fila seleccionada
          e.Row.DefaultCellStyle.SelectionBackColor = mColor
          e.Row.DefaultCellStyle.SelectionForeColor = Color.Black
      ElseIf e.StateChanged = DataGridViewElementStates.None Then
          ' Restaurar el color de fondo original cuando la fila no está seleccionada
          e.Row.DefaultCellStyle.SelectionBackColor = mGrilla.DefaultCellStyle.SelectionBackColor
          e.Row.DefaultCellStyle.SelectionForeColor = mGrilla.DefaultCellStyle.SelectionForeColor
      End If

    End Sub

#End Region



Private Sub frmOrdenDeTrabajo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    ' Verificar si la tecla presionada es F3
    If e.KeyCode = Keys.F3 Then
        ' Activar el evento Click del botón Boton1
        cmdCargar.PerformClick()
    End If

End Sub

Private Sub CargarAnexosNotificacion()
  Dim objCntv As New clConectividad
  Dim strCadena As String = My.Settings.cnnModProd


'CARGO LOS ANEXOS ****************************************************************************
          'ACA VOY A CARGAR LOS ANEXOS DE LA COT CUANDO SEA LA PRIMERA CARGA, ES DECIR CUANDO SE ESTE REGISTRANDO
          'LA OT. POSTERIORMENTE SE CARGARÁN LOS ANEXOS DE LA TABLA ANEXOSOT
          Dim drAnexosNotificacion As MSSQL.SqlDataReader
          mTablaAnexosNotificacion = CreaTablaAnexos()
          lstAnexosNotificacion.Items.Clear() : mVctAnexosNotificacion.Clear()


          lblCargando.Text = lblCargando.Text & Now() & " Cargando módulo: CargarCotizacion - drAnexosNotificacion ..." & vbCrLf
          drAnexosNotificacion = objCntv.LeerValor("*", "VW_AnexosNotificacion ", "OT_Cab_ID =" & mCabOrden_Id.ToString & " and estado='A'", strCadena)
          mCantAnexosCot = 0

          Do
              If drAnexosNotificacion.HasRows = True Then
                  lstAnexosNotificacion.Items.Add(IO.Path.GetFileName(drAnexosNotificacion.Item("RutaArchivo").ToString), True)
                  mVctAnexosNotificacion.Add(drAnexosNotificacion.Item("RutaArchivo").ToString)
                  mCantAnexosCot = mCantAnexosCot + 1
                  Dim mFila As DataRow = mTablaAnexosNotificacion.NewRow
                  mFila.Item("id") = drAnexosNotificacion.Item("id")
                  mFila.Item("RutaArchivo") = drAnexosNotificacion.Item("RutaArchivo")
                  mFila.Item("NombreArchivo") = IO.Path.GetFileName(drAnexosNotificacion.Item("RutaArchivo"))
                  mFila.Item("Estado") = drAnexosNotificacion.Item("Estado")
                  mTablaAnexosNotificacion.Rows.Add(mFila)
              End If
          Loop While drAnexosNotificacion.Read()
End Sub


End Class




