Option Explicit On

Imports Microsoft.Reporting.WinForms
Imports MSSQL = System.Data.SqlClient


Public Class frmIngresosOC


  Private Sep As Char
  Public Usuario_Id As Integer
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mIVA As Decimal, mCab_Id As Integer, mProveedor_ID As Integer, mFilaActual As Integer
  Private mEstadoOC As String


  Private Sub frmOrdenCompra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    SplitContainer1.SplitterDistance = 290

    Dim obCntv As New clConectividad
    Dim mDiasRestar = obCntv.LeerValorSencillo("Valor", "Parametros", "id=25", My.Settings.cnnModProd)
    Dim mFechaI As DateTime = Date.Today.AddDays(CDbl(mDiasRestar))

    dtpInicial.Value = CDate(mFechaI)  'CDate("01/01/" & Year(Date.Today))

    Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

    Call CargarCabeceras()


    flyPanelBotones.Width = 45
    Call FormatoPaneles()

  End Sub


  Private Sub CargarCabeceras()

    lblMensaje.Visible = True : Me.Refresh() : Me.Cursor = Cursors.WaitCursor

    Dim obCntv As New clConectividad, strCampos As String
    Dim strWhere As String

    If optOCRegistradas.Checked = True Then
      strWhere = "Estado = 'R'"
    ElseIf optOCAprobadas.Checked = True Then
      strWhere = "Estado = 'V'"
    Else
      strWhere = "Estado like '%'"
    End If

    strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'" _
        & " AND ID LIKE '%" & txtOC.Text.Replace("*", "%") & "%'"


    '20221004 VALIDO SI TIENE INGRESOS EN ZIUR NO REGISTRADOS
    If chkIngresosZiur.Checked = True Then
      strWhere = strWhere & " AND CONVERT(VARCHAR, Id) IN " & _
          "(SELECT DISTINCT Z.NOTA FROM VW_RemisionesProveedoresZiur Z WHERE IdEncabMov NOT IN (SELECT I.IdEncabMov FROM CMP_Ingresos_OC I))"

    End If


    strCampos = "Id [ORDEN], NOMBRECOMPLETO [PROVEEDOR], ESTADO, FECHA, FechaEntrega [FECHA ENTREGA], FechaValidacion [FECHA VALIDACIÓN]" _
      & ", Observacion, LugarEntrega, descuento, proveedor_Id"

    grOrdenesCompra.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_CabOrdenCompra", strWhere)

    grOrdenesCompra.Columns("Observacion").Visible = False
    grOrdenesCompra.Columns("LugarEntrega").Visible = False
    grOrdenesCompra.Columns("Descuento").Visible = False
    grOrdenesCompra.Columns("proveedor_Id").Visible = False

    mIVA = obCntv.LeerValorSencillo("Valor", "Parametros", "id=21", My.Settings.cnnModProd)

    obCntv = Nothing

    FormatoGrilla()

    lblMensaje.Visible = False : Me.Cursor = Cursors.Default
  End Sub


  Private Sub CargarDetalle(ByVal Cab_Id As String)
    Dim obCntv As New clConectividad, strCampos As String

    strCampos = "cab_id [ORDEN], id [ID], Inventario_ID [COD INVENTARIO], NombreZiur [PRODUCTO], Cant [CANTIDAD], costo [VALOR UNITARIO], total [VALOR TOTAL],  NomUnidad UNIDAD"

    Dim dtConsulta As DataTable = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_DetOrdenCompra", "Cab_Id =" & Cab_Id)
    Dim Ff As Integer

    For Ff = 0 To grDetalle.Rows.Count - 1
      grDetalle.Rows.RemoveAt(0)
    Next

    For Ff = 0 To dtConsulta.Rows.Count - 1
      Dim strNuevaFila() As String = {dtConsulta.Rows(Ff).Item(0), dtConsulta.Rows(Ff).Item(1), _
        dtConsulta.Rows(Ff).Item(2), dtConsulta.Rows(Ff).Item(3), _
        CDec(dtConsulta.Rows(Ff).Item("CANTIDAD")).ToString(FCANT), _
        CDec(dtConsulta.Rows(Ff).Item("VALOR UNITARIO")).ToString(FCTO_U), _
        CDec(dtConsulta.Rows(Ff).Item("VALOR TOTAL")).ToString(FCTOTOT), _
        dtConsulta.Rows(Ff).Item(7), CDec(0).ToString(FCANT), "Ingresar"}

      grDetalle.Rows.Add(strNuevaFila)

      Call LeerIngresosOC(Cab_Id, dtConsulta.Rows(Ff).Item("ID"), Ff)
    Next


    With grDetalle
      .Columns("ColCantidad2").DefaultCellStyle.Format = "N2" : .Columns("ColCantidad2").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("ColValorUnitario").DefaultCellStyle.Format = "N2" : .Columns("ColValorUnitario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("colValorTotal").DefaultCellStyle.Format = "N2" : .Columns("colValorTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End With

    mCab_Id = Cab_Id
    Call FormatoGrilla()
    mFilaActual = -1


    Dim CntXIngresar As Integer = 0
    lblItemsOnyx.Text = "0"
    For Ff = 0 To grDetalle.Rows.Count - 1
      If grDetalle.Item("colBoton", Ff).Value = "ENTREGADO" Then
        lblItemsOnyx.Text = (Val(lblItemsOnyx.Text) + 1).ToString
      Else
        CntXIngresar = CntXIngresar + 1
      End If
    Next

    'SE HABILITA SI TIENE MATERIALES PENDIENTES POR INGRESO
    If CntXIngresar > 0 Then
      chkIngresaTodo.Visible = True
    Else
      chkIngresaTodo.Visible = False

    End If

    lblItemsZiur.BackColor = SystemColors.Control
    If Val(lblItemsOnyx.Text) < Val(lblItemsZiur.Text) Then
      lblItemsZiur.BackColor = Color.Red

    End If


    obCntv = Nothing
  End Sub


  Private Sub grOrdenesCompra_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grOrdenesCompra.CellEnter
    Dim gr As DataGridView = sender

    txtProveedor.Text = gr.Item("PROVEEDOR", e.RowIndex).Value.ToString
    txtOCompra.Text = gr.Item("ORDEN", e.RowIndex).Value.ToString
    mProveedor_ID = gr.Item("Proveedor_Id", e.RowIndex).Value.ToString
    mEstadoOC = gr.Item("ESTADO", e.RowIndex).Value.ToString

    Call CargarDetalle(gr.Item("ORDEN", e.RowIndex).Value.ToString)
    Call CargarRemisionZiur()
  End Sub



  Private Function TxtADec(ByVal strTxt As String) As Decimal
    TxtADec = CDec(IIf(strTxt.ToString = "", 0, strTxt.ToString))
  End Function


  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click, btnActualizar.Click
    If chkIngresaTodo.Checked = True Then
      Call GrabarIngresosMasivo(mCab_Id)
      Call CargarCabeceras()

    Else
      Call GrabarIngresos()
    End If


  End Sub


  Private Sub GrabarIngresosMasivo(ByVal NumOc As Integer)
    Dim obCntv As New clConectividad

    Try
      obCntv.EjecutaComando("EXEC PA_ActualizaIngresosMasivo " & NumOc, My.Settings.cnnModProd, False)
      MessageBox.Show("Orden actualizada con éxito", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
      chkIngresaTodo.Checked = False

    Catch ex As Exception
      MessageBox.Show("Se ha presentado el siguiente error" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

    obCntv = Nothing
  End Sub

  Private Sub GrabarIngresos()
    Dim obCompras As New clCompras, obCntv As New clConectividad
    Dim Estado As String = "A"

    Try
      'TODO. Grabar Datos para tabla de ingresos
      Dim Ff As Integer

      For Ff = 0 To grIngresosOC.Rows.Count - 1
        If grIngresosOC.Item("colEstadoFila", Ff).Value = "NUEVO" Then
          obCompras.GrabarIngresosOC(My.Settings.cnnModProd, mCab_Id, grDetalle.Item("colID", mFilaActual).Value, grIngresosOC.Item("colIdEncabMov", Ff).Value, Date.Now, grIngresosOC.Item("colCantidad", Ff).Value, Estado)
          obCntv.EjecutaComando("EXEC PA_ActualizaPedidosConIngresos " & mCab_Id & "," & grDetalle.Item("colID", mFilaActual).Value, My.Settings.cnnModProd, False)
        End If
      Next

      MessageBox.Show("Orden actualizada con éxito", "Orden de Compra", MessageBoxButtons.OK, MessageBoxIcon.Information)

    Catch ex As Exception
      MessageBox.Show("Se ha presentado el siguiente error" & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try

    obCompras = Nothing : obCntv = Nothing
  End Sub


  Private Sub txtDescuento_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
    If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True

    If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True
  End Sub


  Private Sub frmOrdenCompra_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    Dim mBoton As Button = Me.Tag
    Try
      frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
    Catch ex As System.NullReferenceException
      'no hago nada
    End Try
  End Sub


  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
    'If flyPanelBotones.Width = 190 Then
    '  flyPanelBotones.Width = 45
    '  SplitContainer1.Width = SplitContainer1.Width + (190 - 45)
    'Else
    '  flyPanelBotones.Width = 190
    '  SplitContainer1.Width = Me.Width - 190 - 20 'tbcContenido.Width - 190 '- 45)
    'End If
    Call FormatoPaneles()
  End Sub

  Private Sub FormatoPaneles()
    If flyPanelBotones.Width = 190 Then
      flyPanelBotones.Width = 45
      SplitContainer1.Width = SplitContainer1.Width + (190 - 45)
    Else
      flyPanelBotones.Width = 190
      SplitContainer1.Width = Me.Width - 190 - 20 'tbcContenido.Width - 190 '- 45)
    End If

    grDetalle.Width = TabPage1.Width - 10
    grIngresosOC.Width = grDetalle.Width 'TabPage1.Width - 10
    grIngresosOC.Height = TabPage1.Height - 10 - grIngresosOC.Top
    grDetalle.Height = grIngresosOC.Top - grDetalle.Top - 10

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

      .Columns("ORDEN").Width = 63
      .Columns("PROVEEDOR").Width = 400
      .Columns("ESTADO").Width = 68
      .Columns("FECHA").Width = 120
      .Columns("FECHA ENTREGA").Width = 130
      .Columns("FECHA VALIDACIÓN").Width = 110
      .Columns("OBSERVACION").Width = 100
      .Columns("PROVEEDOR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
    End With

    With grDetalle
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).ReadOnly = True
      Next
    End With

    With grIngresosOC
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).ReadOnly = True
      Next
    End With

    If mEstadoOC = "V" Then
      grDetalle.Columns("colBoton").Visible = True
    Else
      grDetalle.Columns("colBoton").Visible = False

    End If




  End Sub


  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    Call CargarCabeceras()

  End Sub


  Private Sub grDetalle_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalle.CellContentClick
    Dim senderGrid = DirectCast(sender, DataGridView)

    If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
        e.RowIndex >= 0 AndAlso senderGrid.Item("colBoton", e.RowIndex).Value = "Ingresar" Then

      'TODO - Button Clicked - Execute Code Here
      Dim frm As New frmBuscaRemisionesProveedores

      frm.sqlWhere = "esAnulado=0 AND CodInventario='" & grDetalle.Item("colCodInventario2", e.RowIndex).Value & _
        "' AND NomUnidad='" & grDetalle.Item("ColUnidad2", e.RowIndex).Value & "' AND IdCliente1=" & mProveedor_ID.ToString & _
        " AND IdEncabMov NOT IN (SELECT IdEncabMov FROM CMP_Ingresos_OC) and Nota='" & mCab_Id & "'"

      frm.sqlCampos = "NomDocumento [TIPO], NumDocumento [NUM ZIUR], ISNULL(NumDocumentoExt,'') [REMISION CLIENTE], Fecha [FECHA], CodInventario [COD INVENTARIO]" & _
        ", NomInventario [PRODUCTO], Cantidad [CANTIDAD] , NomUnidad [UNIDAD], IdEncabMov, Nota [OC]"
      frm.StartPosition = FormStartPosition.CenterScreen
      frm.ShowDialog()

      Dim dtConsulta As DataTable


      '********************************************************
      '**** ACA HAGO EL LLAMADO AL FRM EN FORMA MODAL
      '********************************************************
      If frm.DialogResult = Windows.Forms.DialogResult.OK Then
        dtConsulta = frm.dtSeleccionado.Copy

        Dim strNuevaFila() As String = {dtConsulta.Rows(0).Item(0), dtConsulta.Rows(0).Item(1), _
          dtConsulta.Rows(0).Item(2), dtConsulta.Rows(0).Item(3), _
          dtConsulta.Rows(0).Item(4), dtConsulta.Rows(0).Item(5), CDec(dtConsulta.Rows(0).Item(6)).ToString(FCANT), _
          dtConsulta.Rows(0).Item(7), dtConsulta.Rows(0).Item(8), "NUEVO"}

        grIngresosOC.Rows.Add(strNuevaFila)
        mFilaActual = e.RowIndex

        Call ContarIngresosEnPantalla(mFilaActual)
      End If
    End If
  End Sub


  Private Function ValidarSiIngresosNuevos() As Boolean
    Dim Ff As Integer, mSalida As Boolean = False

    For Ff = 0 To grIngresosOC.Rows.Count - 1
      If grIngresosOC.Item("colEstadoFila", Ff).Value = "NUEVO" Then
        mSalida = True
      End If
    Next

    Return mSalida
  End Function


  Private Sub LeerIngresosOC(ByVal mCab_Id As Integer, ByVal mDet_Id As Integer, ByVal mFila As Integer)
    Dim dtConsulta As DataTable, obCntv As New clConectividad, Ff As Integer, mCant As Decimal = 0

    dtConsulta = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_LeerIngresosOC", "Cab_Id=" & mCab_Id & " AND Id=" & mDet_Id)

    lblItemsZiur.Text = obCntv.LeerValorSencillo("COUNT(IdEncabMov) [Cant]", "Cant", "VW_RemisionesProveedoresZiur", "CONVERT(VARCHAR,NOTA)= '" & mCab_Id & "'", My.Settings.cnnModProd)

    For Ff = 0 To grIngresosOC.Rows.Count - 1
      grIngresosOC.Rows.RemoveAt(0)

    Next

    'lblItemsOnyx.Text = Ff

    For Ff = 0 To dtConsulta.Rows.Count - 1
      Dim strNuevaFila() As String = {dtConsulta.Rows(Ff).Item(0), dtConsulta.Rows(Ff).Item(1), _
        dtConsulta.Rows(Ff).Item(2), dtConsulta.Rows(Ff).Item(3), dtConsulta.Rows(Ff).Item(4), dtConsulta.Rows(Ff).Item(5), _
        CDec(dtConsulta.Rows(Ff).Item("Cantidad")).ToString(FCANT), _
        dtConsulta.Rows(Ff).Item(7), dtConsulta.Rows(Ff).Item(8), "ANTIGUO"}

      mCant = mCant + CDec(dtConsulta.Rows(Ff).Item("Cantidad")).ToString(FCANT)
      grIngresosOC.Rows.Add(strNuevaFila)
    Next Ff



    grIngresosOC.Columns("colIdEncabMov").Visible = False
    grIngresosOC.Columns("colCantidad").DefaultCellStyle.Format = "N2"
    grIngresosOC.Columns("colCantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    grDetalle.Item("colIngresos", mFila).Value = CDec(mCant).ToString(FCANT)

    If mCant >= CDec(grDetalle.Item("ColCantidad2", mFila).Value) Then
      grDetalle.Item("colBoton", mFila).Value = "ENTREGADO"
      grDetalle.Rows(mFila).DefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)


    End If

    'lblItemsOnyx.Text = grDetalle.RowCount

  End Sub

  Private Sub grDetalle_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalle.CellEnter
    Dim gr As DataGridView = sender
    mFilaActual = e.RowIndex


    Call LeerIngresosOC(txtOCompra.Text, gr.Item("colId", e.RowIndex).Value.ToString, e.RowIndex)
  End Sub


  Private Sub grDetalle_CellLeave(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDetalle.CellLeave
    Debug.Print(e.RowIndex)

    If ValidarSiIngresosNuevos() = True Then
      If MessageBox.Show("Existen ingresos de OC sin grabar. Desea salvar los cambios?", "Ingresos Nuevos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
        'TODO: Grabar los cambios
        Call GrabarIngresos()


      End If
    End If

  End Sub

  Private Sub ContarIngresosEnPantalla(ByVal mFila As Integer)
    Dim Ff As Integer, mCant As Decimal

    For Ff = 0 To grIngresosOC.Rows.Count - 1
      mCant = mCant + grIngresosOC.Item("colCantidad", Ff).Value
    Next

    grDetalle.Item("colIngresos", mFila).Value = CDec(mCant).ToString(FCANT)

  End Sub


  Private Sub txtOC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOC.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call CargarCabeceras()

    End If
  End Sub

  Private Sub CargarRemisionZiur()
    Dim Cntv As New clConectividad
    Dim strCampos As String

    strCampos = "Nota, CodInventario, NomInventario, CONVERT(DECIMAL(8,2), Cantidad) [Cantidad], NomUnidad, NomDocumento, NumDocumento [Num ZIUR], Fecha, EsAnulado"

    grRemisionZiur.DataSource = Cntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_RemisionesProveedoresZiur", "CONVERT(VARCHAR,NOTA)= '" & mCab_Id & "'", "order by IdEncabMov")


    With grRemisionZiur
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).ReadOnly = True
      Next

      .Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    End With


    If chkIngresaTodo.Visible = True Then
      If grRemisionZiur.RowCount > 0 Then

        chkIngresaTodo.Visible = True
      Else
        chkIngresaTodo.Visible = False
      End If
    End If


  End Sub


  Private Sub chkIngresaTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIngresaTodo.CheckedChanged
    If chkIngresaTodo.Checked Then
      Dim Cntv As New clConectividad, strConsulta As String

      strConsulta = "exec PA_ValidaSiProcedeMasivo " & mCab_Id

      Dim drSalida As MSSQL.SqlDataReader = Cntv.EjecutaComando(strConsulta, My.Settings.cnnModProd, True)

      drSalida.Read()

      If drSalida.Item(0) > 0 Then
        MessageBox.Show("No se puede usar esta opción en la OC " & mCab_Id & vbCrLf & "Debe hacerse el ingreso uno a uno!" & vbCrLf _
          & vbCrLf & drSalida.Item(1), "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        chkIngresaTodo.Checked = False
      End If

      Cntv = Nothing
    End If
  End Sub

End Class