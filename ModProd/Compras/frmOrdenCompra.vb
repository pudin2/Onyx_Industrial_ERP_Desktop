Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class frmOrdenCompra
  Private Sep As Char
  Public Usuario_Id As Integer
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mIVA As Decimal, mCab_Id As Integer
  Private mModoPrograma As String = "REGISTRAR"

  Public Property ModoPrograma As String
  Get
    Return mModoPrograma
  End Get
  Set(ByVal value As String)
    mModoPrograma = value
  End Set
  End Property


  Private Sub frmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    'SplitContainer1.SplitterDistance = 390
    dtpInicial.Value = CDate("01/01/" & Year(Date.Today))

    Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

    Call CargarCabeceras()

    Call ReSizePaneles()
  End Sub

  Private Sub CargarCabeceras()
    Dim obCntv As New clConectividad, strCampos As String
    Dim strWhere As String

    If optOCRegistradas.Checked = True Then
      strWhere = "Estado = 'R'"
    ElseIf optOCAprobadas.Checked = True Then
      strWhere = "Estado = 'V'"
    Else
      strWhere = "Estado like '%'"
    End If

    If txtOC.Text <> "" Then
      strWhere = strWhere & " AND Id like '" & txtOC.Text.Replace("*", "%") & "'"
    End If


    strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

        strCampos = "Id [ORDEN], NOMBRECOMPLETO [PROVEEDOR], ESTADO, FECHA, FechaEntrega [FECHA ENTREGA], FechaValidacion [FECHA VALIDACIÓN]" _
      & ", Observacion, LugarEntrega, descuento, ObsAnulacion [OBS ANULACION]"

    grOrdenesCompra.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_CabOrdenCompra", strWhere)

    grOrdenesCompra.Columns("Observacion").Visible = False
    grOrdenesCompra.Columns("LugarEntrega").Visible = False
    grOrdenesCompra.Columns("Descuento").Visible = False

    mIVA = obCntv.LeerValorSencillo("Valor", "Parametros", "id=21", My.Settings.cnnModProd)

    obCntv = Nothing



    FormatoGrilla()

  End Sub




  Private Sub CargarDetalle(ByVal Cab_Id As String)
    Dim obCntv As New clConectividad, strCampos As String

    strCampos = "cab_id [ORDEN], id [ID], Inventario_ID [COD INVENTARIO], NombreZiur [PRODUCTO], Cant [CANT], costo [VALOR UNITARIO], total [VALOR TOTAL],  NomUnidad UNIDAD" _
      & ", NumOrden [OT], NombreCliente [CLIENTE], NombreProyecto [PROYECTO]"


    grDetalle.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_DetOrdenCompra", "Cab_Id =" & Cab_Id & " Order by cab_id, id")

    With grDetalle
      .Columns("CANT").DefaultCellStyle.Format = "N2" : .Columns("CANT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("VALOR UNITARIO").DefaultCellStyle.Format = "N2" : .Columns("VALOR UNITARIO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("VALOR TOTAL").DefaultCellStyle.Format = "N2" : .Columns("VALOR TOTAL").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End With

    mCab_Id = Cab_Id
    Call Calcular()

    obCntv = Nothing
  End Sub


  Private Sub grOrdenesCompra_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grOrdenesCompra.CellEnter
      Dim gr As DataGridView = sender

      txtProveedor.Text = gr.Item("PROVEEDOR", e.RowIndex).Value.ToString
      txtOCompra.Text = gr.Item("ORDEN", e.RowIndex).Value.ToString
      txtObservacion.Text = gr.Item("Observacion", e.RowIndex).Value.ToString
      txtLugarEntrega.Text = gr.Item("LugarEntrega", e.RowIndex).Value.ToString
      txtDescuento.Text = TxtADec(gr.Item("Descuento", e.RowIndex).Value.ToString).ToString(FCTOTOT)
      dtpFechaEntrega.Value = gr.Item("FECHA ENTREGA", e.RowIndex).Value


      Call CargarDetalle(gr.Item("ORDEN", e.RowIndex).Value.ToString)
      chkAnular.Checked = False
      txtObsAnulacion.Text = ""
      txtObsAnulacion.Visible = False

      If gr.Item("ESTADO", e.RowIndex).Value = "R" Then
          btnActualizar.Visible = True
          btnActualizar.Enabled = True
      ElseIf gr.Item("ESTADO", e.RowIndex).Value = "I" Then
          btnActualizar.Enabled = False
          btnActualizar.Visible = False
          chkAnular.Checked = True
          txtObsAnulacion.Visible = True
          txtObsAnulacion.Text = gr.Item("OBS ANULACION", e.RowIndex).Value
      Else
          btnActualizar.Visible = MostrarBoton(btnActualizar, Usuario_Id)
          btnActualizar.Enabled = btnActualizar.Visible
      End If



    End Sub

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

  Private Function TxtADec(ByVal strTxt As String) As Decimal
        TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
  End Function


  Private Sub Calcular()
    Dim Ff As Integer, Subtotal As Decimal = 0

    For Ff = 0 To grDetalle.Rows.Count - 1
      Subtotal = Subtotal + grDetalle.Rows(Ff).Cells("VALOR TOTAL").Value
    Next

    txtValorOC.Text = Subtotal.ToString(FCTOTOT)

    If txtDescuento.Text <> "" Then Subtotal = (Subtotal.ToString - CDec(txtDescuento.Text)).ToString(FCTOTOT)
    txtSubTotal.Text = Subtotal.ToString(FCTOTOT)
    txtIVA.Text = (Subtotal * mIVA).ToString(FCTOTOT)

    txtTotalOC.Text = (Subtotal + CDec(txtIVA.Text)).ToString(FCTOTOT)

  End Sub


  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click, btnActualizar.Click

    If MessageBox.Show("Desea actualizar la Orden de Compra número " & mCab_Id.ToString & " ?", "Actualizar OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then

      Dim obCompras As New clCompras, obCntv As New clConectividad
      Dim Estado As String, FechaValidacion As Date, xEstadoDetSol As String

      'If chkValidar.Checked = True Then
      If mModoPrograma = "VALIDAR" Then
        Estado = "V" : FechaValidacion = Date.Today : xEstadoDetSol = "OCV"
      Else
        Estado = "R" : FechaValidacion = #1/1/2000# : xEstadoDetSol = "OCR"
      End If

      'PARA MANEJAR LAS ANULACIONES
      Dim strObsAnulacion As String = vbNullString, FechaAnulacion As Date

      If chkAnular.Checked = True Then
        FechaAnulacion = Date.Now
        Estado = "I"
        strObsAnulacion = txtObsAnulacion.Text

        If strObsAnulacion = "" Then
            MessageBox.Show("Debe especificar una observación", "Dato obligarorio", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub

        End If

      End If

      Try
        obCompras.ActualizarOrdenCompra(My.Settings.cnnModProd, mCab_Id, Estado, dtpFechaEntrega.Value, FechaValidacion, _
         txtObservacion.Text, txtLugarEntrega.Text, txtDescuento.Text, txtObsAnulacion.Text, FechaAnulacion)

                'obCntv.EjecutaComando("EXEC PA_ActualizaSolpedConOCompra " & mCab_Id.ToString, My.Settings.cnnModProd, False)
                If chkAnular.Checked = True Then
                    obCntv.EjecutaComando("EXEC PA_CambiaEstadoSolPed 'R'," & mCab_Id.ToString, My.Settings.cnnModProd, False)

                    'RECARGO LA GRILLA
                    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                    Call CargarCabeceras()
                    Me.Cursor = System.Windows.Forms.Cursors.Default


                Else
                    'ACTUALIZO EL ESTADO DEL DETALLE DEL PEDIDO, EN ESTADO COTIZADO: 'OCV' = ORDEN DE COMPRA VALIDADA
                    obCntv.EjecutaComando("EXEC PA_ActualizaEstadoPedido '" & xEstadoDetSol & "'," & mCab_Id.ToString, My.Settings.cnnModProd, False)

                    'MessageBox.Show("Orden actualizada con éxito", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If

                MessageBox.Show("Orden actualizada con éxito", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Se ha presentado el siguiente error" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

      obCompras = Nothing : obCntv = Nothing

    End If
  End Sub

 Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtDescuento.KeyPress


        If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

        If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True


    End Sub


  Private Sub txtDescuento_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescuento.Leave
    txtDescuento.Text = TxtADec(txtDescuento.Text).ToString(FCTOTOT)
  End Sub



Private Sub frmOrdenCompra_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
     Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
End Sub



Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    Try
      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
      Dim obXml As New clManejoXML

      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      'INICIO LA ASIGNACIÓN DE CAMPOS
      Dim strMargenes As String = obXml.LeerValor("frmOrdenCompra_Margenes")
      Dim Pg2 As New System.Drawing.Printing.PageSettings()
      Dim Size2 = New Printing.PaperSize()
      Dim vctMedidas2() As String
      vctMedidas2 = Split(strMargenes, ",")
      Pg2.Margins.Top = CInt(vctMedidas2(0))
      Pg2.Margins.Bottom = CInt(vctMedidas2(1))
      Pg2.Margins.Left = CInt(vctMedidas2(2))
      Pg2.Margins.Right = CInt(vctMedidas2(3))
      Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


      Dim strOrden As String = "7" 'txtNumOrden.Text  'InputBox("Número de Orden de Trabajo")
      Dim frm As New frmImprimeOC

      frm.strCab_ID = mCab_Id.ToString
      frm.strNombreReporte = obXml.LeerValor("rptImprimeOC") 'My.Settings.NombreRptOrdenProduccion
      frm.strMargenes = obXml.LeerValor("frmOrdenCompra_Margenes")

      frm.rptReporte.SetPageSettings(Pg2)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
      frm.rptReporte.RefreshReport()

      frm.Show()

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Try


End Sub



  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
        If flyPanelBotones.Width = 190 Then
          flyPanelBotones.Width = 45
          SplitContainer1.Width = SplitContainer1.Width + (190 - 45)
        Else
          flyPanelBotones.Width = 190
          SplitContainer1.Width = Me.Width - 190 - 20 'tbcContenido.Width - 190 '- 45)
        End If
  End Sub


  Private Sub btnAprobar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAprobar.Click
        If MessageBox.Show("Desea aprobar la Orden de Compra " & mCab_Id.ToString & " ?", "Aprobar OC", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'mCab_Id se asigna cuando se selecciona la OC en la grilla de cabeceras

            Dim obCompras As New clCompras, obCntv As New clConectividad ', Ff As Integer
            Dim Estado As String, FechaValidacion As Date, xEstadoDetSol As String, FechaAnulacion As Date
            'If chkValidar.Checked = True Then
            If mModoPrograma = "VALIDAR" Then
                Estado = "V" : FechaValidacion = Date.Today : xEstadoDetSol = "OCV"
            Else
                Estado = "R" : FechaValidacion = #1/1/2000# : xEstadoDetSol = "OCR"
            End If
            Dim obInicio As New clSetUpInicio, mUsuario As String, mDominio As String, mUsuario_id As Integer
            mUsuario = obInicio.Usuario
            mDominio = obInicio.Dominio
            obInicio = Nothing

            mUsuario_id = obCntv.LeerValorSencillo("id", "usuarios", "Dominio='" & mDominio & "' and usuario='" & mUsuario & "'", My.Settings.cnnModProd)

            'mCab_Id = grOrdenesCompra.Item("orden", Ff).Value
            'obCntv.ActualizaValor("Estado='V', Usuario_ID_Aprueba=" & mUsuario_id.ToString, "CabOCompra", "id=" & mCab_Id.ToString, My.Settings.cnnModProd)

      obCompras.ActualizarOrdenCompra(My.Settings.cnnModProd, mCab_Id, Estado, dtpFechaEntrega.Value, FechaValidacion, _
              txtObservacion.Text, txtLugarEntrega.Text, txtDescuento.Text, txtObsAnulacion.Text, FechaAnulacion, mUsuario_id)
            'ESTA LINEA SE REEMPLAZA POR EL STORE SIGUIENTE
            'obCntv.EjecutaComando("EXEC PA_ActualizaSolpedConOCompra " & mCab_Id.ToString, My.Settings.cnnModProd, False)

            'ACTUALIZO EL ESTADO DEL DETALLE DEL PEDIDO, EN ESTADO COTIZADO: 'OCV' = ORDEN DE COMPRA VALIDADA
            obCntv.EjecutaComando("EXEC PA_ActualizaEstadoPedido 'OCV'," & mCab_Id.ToString, My.Settings.cnnModProd, False)


            MessageBox.Show("Orden aprobada con éxito!", "Aprobar OC", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Call CargarCabeceras()

            obCompras = Nothing : obCntv = Nothing
        End If
  End Sub

   Private Sub FormatoGrilla()
    Dim Cc As Integer

    With grOrdenesCompra
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).ReadOnly = True
        .Columns(Cc).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

      Next

            .Columns("ORDEN").Width = 60
      .Columns("PROVEEDOR").Width = 400
            .Columns("ESTADO").Width = 60
      .Columns("FECHA").Width = 80
      .Columns("FECHA ENTREGA").Width = 130
      .Columns("FECHA VALIDACIÓN").Width = 110
      .Columns("OBSERVACION").Width = 100
      .Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End With

    If grDetalle.Columns.Count > 0 Then
      With grDetalle
        For Cc = 0 To .Columns.Count - 1
          .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
          .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
          .Columns(Cc).ReadOnly = True
          '.Columns(Cc).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Next

                .Columns("ORDEN").Width = 60
        .Columns("ID").Width = 40
                .Columns("COD INVENTARIO").Width = 100
        .Columns("PRODUCTO").Width = 165
        .Columns("CANT").Width = 50
        .Columns("VALOR UNITARIO").Width = 100
        .Columns("VALOR TOTAL").Width = 100
        .Columns("UNIDAD").Width = 60
        .Columns("OT").Width = 60
        .Columns("CLIENTE").Width = 120
        .Columns("PROYECTO").Width = 321



        End With
     End If
  End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call CargarCabeceras()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

  Private Sub chkAnular_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAnular.Click
    lblObsAnulacion.Visible = chkAnular.Checked
    txtObsAnulacion.Visible = chkAnular.Checked
  End Sub


  Private Sub txtOC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOC.KeyDown
    If e.KeyCode = Keys.Enter Then
      Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
      Call CargarCabeceras()
      Me.Cursor = System.Windows.Forms.Cursors.Default

    End If
  End Sub


  Private Sub ReSizePaneles()
    grOrdenesCompra.Height = SplitContainer1.Panel1.Height - Panel1.Height - 15
    grOrdenesCompra.Width = SplitContainer1.Panel1.Width - 10
    grDetalle.Width = SplitContainer1.Panel2.Width - 10
    grDetalle.Height = SplitContainer1.Panel2.Height - grDetalle.Top - 10


  End Sub

Private Sub frmOrdenCompra_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
    Call ReSizePaneles()
End Sub

Private Sub SplitContainer1_SplitterMoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.SplitterEventArgs) Handles SplitContainer1.SplitterMoved
    Call ReSizePaneles()
End Sub
End Class