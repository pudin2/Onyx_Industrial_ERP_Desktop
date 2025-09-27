Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Drawing.Printing




Public Class frmRemision
    Private mNumOrden As Integer, mNumOrden_Cab_Id As Integer
    Private Sep As Char, mNumRemision As Integer
    Private FCANT As String = My.Settings.FormatoCantidad
    Private FCTO_U As String = My.Settings.FormatoC_U
    Private FCTOTOT As String = My.Settings.FormatoCostoTotal
    Private strIdCliente As String, strNombreCliente As String
    Private mUsuario_Id As Integer

    Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
        If flyPanelBotones.Width = 190 Then
            flyPanelBotones.Width = 45
            grpDetalle.Width = grpDetalle.Width + (190 - 45)
        Else
            flyPanelBotones.Width = 190
            grpDetalle.Width = grpDetalle.Width - (190 - 45)
        End If
    End Sub



    Private Sub frmRemision_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      'If mPreguntaSalida = True Then
      '  If mModoLiquidacionVentaDirecta = False Then
      '      If MsgBox(LeerEtqTextoXml("msgTextoSalir"), MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Cerrando cotización") = MsgBoxResult.No Then
      '          e.Cancel = True
      '      End If


            Call CerrarControlBarra()
      '  Else 'SALIDA DE VENTA DIRECTA
      '      'PROGRAMAR

      '  End If
      'End If

    End Sub


    Private Sub frmRemision_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim obCntv As New clConectividad, obInicio As New clSetUpInicio

        cmbCliente.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Clientes", "esactivo=1", "Order by Nombre1")
        cmbCliente.DisplayMember = "NombreCompleto"
        'Detectar el separador decimal de la aplicación.
        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator


        Dim mUsuario As String, mDominio As String ', obInicio As New clSetUpInicio
        mUsuario = obInicio.Usuario 'Environment.UserName '& Environment.UserName.GetHashCode
        mDominio = obInicio.Dominio  'Environment.UserDomainName
        obInicio = Nothing

        Dim strWhere As String = "dominio='" & mDominio & "' and usuario='" & mUsuario & "'"
        mUsuario_Id = obCntv.LeerValorSencillo("id", "Usuarios", strWhere, My.Settings.cnnModProd)

        Call FormatoGrilla()

    End Sub

    Private Sub btnAdicionar_Click(sender As System.Object, e As System.EventArgs) Handles btnAdicionar.Click

      If txtCantidad.Text <> "" And txtProyecto.Text <> "" Then
          Dim obCntv As New clConectividad
            Dim CntXDespachar As Integer = obCntv.LeerValorSencillo("CntXDespachar", "VW_CntDespachadaXOT ", "NumOrden=" & mNumOrden, My.Settings.cnnModProd)

            If optOtTotal.Checked = True Then

                If obCntv.LeerValorSencillo("cantidad", "VW_CntResumenesXOT", "NumOrden = " & mNumOrden, My.Settings.cnnModProd) > 0 Then
                    MessageBox.Show("Hay resumenes de producción sin validar para esta orden de trabajo.", "No se puede remisionar", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            End If

            If CntXDespachar >= CInt(txtCantidad.Text) Then
                Dim mTipoDespacho As String
                If optOtParcial.Checked = True Then mTipoDespacho = "P" Else mTipoDespacho = "T"

                Dim strFilaNueva() As String = { _
                      mNumOrden.ToString, txtCantidad.Text, txtProyecto.Text, txtOCCliente.Text, mTipoDespacho, "", "", mNumOrden_Cab_Id.ToString}

                grDetalleRemision.Rows.Add(strFilaNueva)

                txtCantidad.Text = "" : txtOCCliente.Text = ""
                txtProyecto.Text = "" : txtNumOrden.Text = ""

                txtNumOrden.Select()

                If btnGrabar.Tag = "SI" Then
                    btnGrabar.Visible = True
                End If

            Else
                MessageBox.Show("La cantidad especificada supera la cantidad pendiente por despachar!" & vbCrLf _
                  & "Cantidad pendiente: " & CntXDespachar.ToString, "No se puede remisionar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            End If

        End If
    End Sub

 Private Sub txtCantidad_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) _
  Handles txtCantidad.KeyPress, txtNumOrden.KeyPress

        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True
  End Sub

    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
      Call GrabarRemision("R")
    End Sub

    Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
        Dim selectedItem As DataRowView
        selectedItem = cmbCliente.SelectedItem

        strIdCliente = selectedItem("idCliente").ToString
        strNombreCliente = selectedItem("NombreCompleto").ToString

        'Call CargaContratos(strIdCliente)

    End Sub

  Private Sub GrabarRemision(mEstado As String)
   If grDetalleRemision.Rows.Count > 0 Then
            Dim obCntv As New clConectividad, Ff As Integer, obProd As New clProduccion
            Dim xRemision_Id As Integer, xAccion As String, strMensaje As String

            If mNumRemision = 0 Then ' si es nuevo
                xRemision_Id = obCntv.LeerValorSencillo("isnull(max(id),0)+1 [Id]", "ID", "CabRemision", "1=1", My.Settings.cnnModProd)
                xAccion = "INSERT"
                strMensaje = " creada con éxito!"
            Else
                xRemision_Id = mNumRemision
                xAccion = "UPDATE"
                strMensaje = " actualizada con éxito!"
            End If

            obCntv.ActualizaValor("estado='I'", "DetRemision", "Cab_Id=" & mNumRemision.ToString, My.Settings.cnnModProd)
            Dim xDet_IdXActualizar As String = ""

            Dim xMaxDet_Id As Integer = obCntv.LeerValorSencillo("isnull(max(id),0)+1 [Id]", "ID", "DetRemision", "Cab_id=" & mNumRemision.ToString, My.Settings.cnnModProd)

            For Ff = 0 To grDetalleRemision.Rows.Count - 1
              If grDetalleRemision.Item("colRemDet_ID", Ff).Value = "" Then ' Es registro nuevo
                    Dim NuevaFila = obProd.TablaDetRemision.NewDetRemisionRow
                    NuevaFila("Cab_Id") = xRemision_Id
                    NuevaFila("Id") = xMaxDet_Id
                    NuevaFila("OTCab_Id") = grDetalleRemision.Item("colOTCab_ID", Ff).Value
                    NuevaFila("Cantidad") = grDetalleRemision.Item("colCant", Ff).Value
                    NuevaFila("NombreProyecto") = grDetalleRemision.Item("colProyecto", Ff).Value
                    NuevaFila("OCCliente") = grDetalleRemision.Item("colOCCliente", Ff).Value
                    NuevaFila("Estado") = "R"
                    NuevaFila("TipoDespacho") = grDetalleRemision.Item("colTipoDespacho", Ff).Value

                    xMaxDet_Id = xMaxDet_Id + 1

                    obProd.TablaDetRemision.AddDetRemisionRow(NuevaFila)
              Else
                  xDet_IdXActualizar = xDet_IdXActualizar & grDetalleRemision.Item("colRemDet_ID", Ff).Value & ","

              End If
            Next

            If xDet_IdXActualizar <> "" Then
                xDet_IdXActualizar = Strings.Left(xDet_IdXActualizar, Len(xDet_IdXActualizar) - 1)
                obCntv.ActualizaValor("Estado='R'", "DetRemision", "cab_Id=" & mNumRemision.ToString & " and id in (" & xDet_IdXActualizar & ")", My.Settings.cnnModProd)
            End If

            obProd.UsuarioId = mUsuario_Id
            obProd.GrabarRemision(My.Settings.cnnModProd, xAccion, xRemision_Id, dtpFecha.Value, strIdCliente, strNombreCliente, txtTransporta.Text, txtPlacas.Text, txtDespachado.Text, txtObservacion.Text, mEstado)

            If mEstado = "V" Then
              Dim mStrActualiza As String = "exec PA_ActualizaEstadosAnterioresOT " & mNumRemision.ToString
              obCntv.EjecutaComando(mStrActualiza, My.Settings.cnnModProd, False)

            End If


            MessageBox.Show("Remisión de entrega número " & xRemision_Id.ToString & strMensaje, "Remisión de entrega", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call LimpiarFrm()
            'Call CargarResumen(mNumOrden)
        End If

  End Sub


    Private Sub LimpiarFrm()
        txtNumOrden.Text = ""
        cmbCliente.SelectedIndex = 0
        txtTransporta.Text = ""
        txtPlacas.Text = ""
        txtDespachado.Text = ""
        txtObservacion.Text = ""
        grDetalleRemision.Rows.Clear()
        btnGrabar.Visible = False


    End Sub

    Private Sub LeerOT(xNumOrden As Integer)
        Dim obCntv As New clConectividad

        Dim drOT As MSSQL.SqlDataReader
        drOT = obCntv.LeerValor("id, numorden, ocompracliente, cntafabricar, OT_NombreProyecto, OT_Alcance", "vw_buscarot", "NumOrden=" & xNumOrden.ToString, My.Settings.cnnModProd)

        If drOT.HasRows Then
            txtNumOrden.Text = drOT.Item("NumOrden").ToString
            txtOCCliente.Text = drOT.Item("OCompraCliente").ToString
            txtCantidad.Text = drOT.Item("CntaFabricar").ToString
            txtProyecto.Text = drOT.Item("OT_NombreProyecto").ToString & vbCrLf & drOT.Item("OT_Alcance").ToString



            mNumOrden = drOT.Item("NumOrden")
            mNumOrden_Cab_Id = drOT.Item("id")
            btnAdicionar.Select()
        Else
            MessageBox.Show("No se encontró este número de OT!", "No hay registros", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumOrden.Select()
        End If


        obCntv = Nothing



    End Sub

Private Sub btnBuscarOT_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarOT.Click
         Dim Frm As New frmBuscar, xNumOrden As String, obCntv As New clConectividad

        'btnGrabar.Visible = False
        Frm.Text = "Buscar OT"
        Frm.lblDoc.Text = "Numero OT" : Frm.txtDocumento.Tag = "NumOrden" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD


        xNumOrden = obCntv.LeerValorSencillo("valor", "parametros", "id=16", My.Settings.cnnModProd)
        obCntv = Nothing
        Frm.txtDocumento.Text = Strings.Left(xNumOrden, 2) & "*"
        Frm.txtDocumento.MaxLength = 10

        Frm.chkTexto.Text = "Alcance"
        Frm.chkFechas.Text = "Fecha   "
        Frm.chkTercero.Text = "Cliente  "

        Frm.txtTexto.Tag = "Alcance"
        Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
        Frm.cmbTercero.Tag = "NombreCliente"

        Frm.strConsultaSQL = "vw_buscarOT" : Frm.strCamposSQL = "id, NumOrden, NumCotizacion, CntAFabricar , CntXDespachar, TipoCot, [Titulo Estado], NombreCliente, NombreProyecto, Alcance, FechaRegistro,  FechaInicio, FechaRegistro ,	Estado, [OC Cliente]"
        Frm.mWhereExterno = " AND CntXDespachar <> 0 AND idcliente=" & strIdCliente


        Frm.ShowDialog()


        Dim dtConsulta As DataTable

        If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
            dtConsulta = Frm.dtSeleccionado.Copy
            'tssNumeroOT.Text = "OT Número: " & dtConsulta.Rows(0).Item(1)
            'mNumOrden = dtConsulta.Rows(0).Item("NumOrden")
            'mNumOrden_Cab_Id = dtConsulta.Rows(0).Item("id")
            Call LeerOT(dtConsulta.Rows(0).Item("NumOrden"))


        End If

    End Sub


     Private Sub txtNumOrden_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) _
        Handles txtNumOrden.KeyPress

              If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
              If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True
      End Sub

    Private Sub txtNumOrden_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumOrden.KeyDown
        If e.KeyCode = Keys.Enter Then
            Call LeerOT(txtNumOrden.Text)
            'btnAdicionar.Select()
        End If


    End Sub


    Private Sub cmdCargar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCargar.Click
         Dim Frm As New frmBuscar, xNumOrden As String, obCntv As New clConectividad

        'btnGrabar.Visible = False
        Frm.Text = "Buscar OT"
        Frm.lblDoc.Text = "Remisión" : Frm.txtDocumento.Tag = "id" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD


        xNumOrden = obCntv.LeerValorSencillo("Max(id) [ID]", "ID", "CabRemision", "id>0", My.Settings.cnnModProd)
        obCntv = Nothing
        If Len(xNumOrden.ToString) > 2 Then
          Frm.txtDocumento.Text = Strings.Left(xNumOrden, Len(xNumOrden.ToString) - 2) & "*"
        Else
          Frm.txtDocumento.Text = "*"
        End If


        'Frm.txtDocumento.MaxLength = 10

        Frm.chkTexto.Text = "OT" : Frm.chkTexto.Visible = True
        'Frm.chkFechas.Text = "Fecha   " : Frm.chkFechas.Top = 38
        Frm.chkTercero.Text = "Cliente  " : Frm.chkTercero.Top = 64

        Frm.txtTexto.Tag = "NumOrden" : Frm.txtTexto.Visible = True
        Frm.dtpFechaIni.Tag = "FechaRegistro" : Frm.dtpFechaFin.Tag = "FechaRegistro"
        'Frm.dtpFechaIni.Top = 38 : Frm.dtpFechaFin.Top = 38
        Frm.cmbTercero.Tag = "NombreCliente" : Frm.cmbTercero.Top = 64

        'Frm.btnBuscar.Top = 90 : Frm.btnCancelar.Top = 90 : Frm.btnAceptar.Top = 90
        'Frm.grDet.Top = 120
        'Frm.grDet.Height = 313
        Frm.strConsultaSQL = "VW_Remisiones"
        Frm.strCamposSQL = "id [REMISION], NumOrden [OT] ,Fecha [FECHA], NombreCliente [CLIENTE], TransportadoPor [TRANSPORTADO POR], Placas [PLACAS], DespachadoPor [DESPACHADO POR], Estado [ESTADO] "


        Frm.ShowDialog()


        Dim dtConsulta As DataTable

        If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
            dtConsulta = Frm.dtSeleccionado.Copy
            'tssNumeroOT.Text = "OT Número: " & dtConsulta.Rows(0).Item(1)
            'mNumOrden = dtConsulta.Rows(0).Item("NumOrden")
            'mNumOrden_Cab_Id = dtConsulta.Rows(0).Item("id")
            Call CargarRemision(dtConsulta.Rows(0).Item("Remision"))

            'Reviso los permisos para poder aprobar una Remision
            If dtConsulta.Rows(0).Item("Estado").ToString = "R" Then
              btnGrabar.Visible = MostrarBoton(btnGrabar, mUsuario_Id)
              btnAprobar.Visible = MostrarBoton(btnAprobar, mUsuario_Id)

            Else
              btnGrabar.Visible = False
              btnAprobar.Visible = False
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

  Private Sub FormatoGrilla()
      With grDetalleRemision
          .Columns("colNumOrden").Width = 90
          .Columns("colCant").Width = 90
          .Columns("colProyecto").Width = 305
          .Columns("colOCCliente").Width = 90
          '.Columns("colCab_Id").Width = 58 : .Columns("colCab_Id").Visible = False
          '.Columns("colRemDet_ID").Width = 99 : .Columns("colRemDet_ID").Visible = False
          '.Columns("ColOTCab_ID").Visible = False

      End With

      With grDetalleRemision
          For Cc = 0 To .Columns.Count - 1
            .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Regular, GraphicsUnit.Point)
            .Columns(Cc).ReadOnly = True
            .Columns(Cc).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

          Next

        .Columns("colNumOrden").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        .Columns("colCant").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        .Columns("colProyecto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        .Columns("colOCCliente").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        .Columns("colCab_Id").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        .Columns("colRemDet_ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

      End With
  End Sub

  Private Sub CargarRemision(NumRemision As Integer)
    Dim obCntv As New clConectividad
    Dim drCabRemision As MSSQL.SqlDataReader

    drCabRemision = obCntv.LeerValor("*", "CabRemision", "Id=" & NumRemision, My.Settings.cnnModProd)
    txtNumResumen.Text = NumRemision

    dtpFecha.Value = drCabRemision.Item("fecha")

    cmbCliente.Text = drCabRemision.Item("NombreCliente")
    strIdCliente = drCabRemision.Item("idCliente")
    txtTransporta.Text = drCabRemision.Item("TransportadoPor")
    txtPlacas.Text = drCabRemision.Item("Placas")
    txtDespachado.Text = drCabRemision.Item("DespachadoPor")
    txtObservacion.Text = drCabRemision.Item("observacion")
    stNumRemision.Visible = True : stNumRemision.Text = drCabRemision.Item("id")
    stEstadoRemision.Visible = True : stEstadoRemision.Text = "Estado: " & drCabRemision.Item("Estado")



    Dim drDetRemision As MSSQL.SqlDataReader
    drDetRemision = obCntv.LeerValor("*", "VW_DetRemision", "Estado <> 'I' and Cab_id=" & NumRemision, My.Settings.cnnModProd)
    grDetalleRemision.Rows.Clear()

    Do
      Dim strLinea() As String

      strLinea = {
        drDetRemision.Item("NumOrden"),
        drDetRemision.Item("Cantidad"),
        drDetRemision.Item("NombreProyecto"),
        drDetRemision.Item("OCCliente"),
        drDetRemision.Item("TipoDespacho"),
        drDetRemision.Item("Cab_Id"),
        drDetRemision.Item("Id"),
        drDetRemision.Item("OTCab_Id")
      }
      grDetalleRemision.Rows.Add(strLinea)
    Loop While drDetRemision.Read()

    'variable global con el numero de Remision
    mNumRemision = NumRemision

    'SI EL DOCUMENTO ESTA VALIDADO, NO PERMITO QUE SE GUARDE
    If drCabRemision.Item("Estado") = "V" Then
      btnGrabar.Visible = False
      btnImprimir.Visible = True

    End If

    drCabRemision = Nothing
  End Sub

Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
    Dim frm As New frmPlaneacion

    frm.Show()
End Sub

  Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click
      Dim obCntv As New clConectividad

      GrabarRemision("V")
      'obCntv.ActualizaValor("Estado='V'", "CabRemision", "id=" & mNumRemision, My.Settings.cnnModProd)

      Call ImprimirRemision()

      btnAprobar.Visible = False

  End Sub

    Private Function MostrarBoton(mBoton As Button, xUsuario_Id As Integer) As Boolean
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

  Private Sub btnImprimir_Click(sender As System.Object, e As System.EventArgs) Handles btnImprimir.Click
     Call ImprimirRemision()
  End Sub


  Private Sub ImprimirRemision()
    Try
          Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
          Dim obXml As New clManejoXML

          obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
          obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

          'INICIO LA ASIGNACIÓN DE CAMPOS
          Dim strMargenes As String = obXml.LeerValor("frmImprimeRemision_Margenes")
          Dim Pg2 As New System.Drawing.Printing.PageSettings()
          Dim Size2 = New Printing.PaperSize("MediaCarta", 827, 584)



          Dim vctMedidas2() As String
          vctMedidas2 = Split(strMargenes, ",")
          Pg2.Margins.Top = CInt(vctMedidas2(0))
          Pg2.Margins.Bottom = CInt(vctMedidas2(1))
          Pg2.Margins.Left = CInt(vctMedidas2(2))
          Pg2.Margins.Right = CInt(vctMedidas2(3))
          'Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Statement
          'Pg2.PaperSize.RawKind = GetPaperSize("Media Carta")
          'Pg2.PaperSize = Size2

          'BUSCO EL TAMAÑO MEDIA CARTA
          'For I As Integer = 0 to System.Drawing.Printing.PaperSize(
         Call CheckGetPaperSize()


          Dim strOrden As String = txtNumResumen.Text  'InputBox("Número de Orden de Trabajo")
          Dim frm As New frmImprimeRemision
          frm.strOrdenID = txtNumResumen.Text  'strOrden

          Dim obCntv As New clConectividad 'mTipoRpt As String

          'mTipoRpt = obCntv.LeerValorSencillo("distinct MarcaAgua", "MarcaAgua", "VW_RPT_OrdenDeTrabajo", " numorden=" & mNumOrden, My.Settings.cnnModProd)

          'If mTipoRpt = "DEFINITIVA" Then
          '  frm.strNombreReporte = My.Settings.NombreRptOrdenProduccion
          'Else
          '  frm.strNombreReporte = My.Settings.NombreRptOrdenProduccionBorrador
          'End If

          frm.strNombreReporte = obXml.LeerValor("rptImprimeRemision") 'My.Settings.NombreRptOrdenProduccion
          'frm.strMargenes = obXml.LeerValor("frmImprimeRemision_Margenes")


          frm.rptReporte.SetPageSettings(Pg2)
          frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
          frm.rptReporte.RefreshReport()

          frm.Show()

      Catch ex As System.InvalidCastException

      Catch ex As Exception
        MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

      End Try



  End Sub

  'System.Drawing.Printing.PaperKind.Statement
  Public Shared Function GetPaperSize(ByVal Name As String) As PaperKind 'PaperSize
      Dim size1 As PaperSize = Nothing
      Name = Name.ToUpper()
      Dim settings As PrinterSettings = New PrinterSettings()

      For Each size As PaperSize In settings.PaperSizes

          If size.Kind.ToString().ToUpper() = Name Then
              size1 = size
              Exit For
          End If
      Next

      Return size1.PaperName
  End Function


  Public Sub CheckGetPaperSize()
      Dim size1 As PaperSize = Nothing
      Name = Name.ToUpper()
      Dim settings As PrinterSettings = New PrinterSettings()

      For Each size As PaperSize In settings.PaperSizes

         ' If size.Kind.ToString().ToUpper() = Name Then
              size1 = size
              Debug.Print(size1.PaperName)
           '   Exit For
          'End If
      Next


  End Sub

End Class