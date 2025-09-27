Option Explicit On



Public Class frmActualizaPrecios
  Private mNumCotizacion As Integer, mDocCargado As Boolean = False
  Private Sep As Char, mCab_Id As Integer

 Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
    Dim Frm As New frmBuscar

    Frm.Text = "Buscar Cotización Proveedor"
    Frm.lblDoc.Text = "Numero Cot" : Frm.txtDocumento.Tag = "COTIZACION" 'TAG SE USA PARA LIGAR AL CAMPO DE LA BD
    Frm.txtDocumento.MaxLength = 10

    Frm.chkTexto.Text = "Observación"
    Frm.chkFechas.Text = "Fecha   "
    Frm.chkTercero.Text = "Proveedor  "

    Frm.txtTexto.Tag = "Observacion"
    Frm.dtpFechaIni.Tag = "Fecha" : Frm.dtpFechaFin.Tag = "Fecha"
    Frm.cmbTercero.Tag = "PROVEEDOR"

    Frm.strVctColsOcultas = "id;proveedor_Id"
    Frm.strConsultaTercero = "vw_Proveedores" : Frm.strCampoMiembroTercero = "Nombre1"

    Frm.strConsultaSQL = "VW_ConsultaCabCotizacionProveedor" : Frm.strCamposSQL = "*"

    Frm.ShowDialog()


    Dim dtConsulta As DataTable

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
      dtConsulta = Frm.dtSeleccionado.Copy
      tssNumeroCot.Text = "Cot Número: " & dtConsulta.Rows(0).Item(1)
      txtNumOrden.Text = dtConsulta.Rows(0).Item(1)
      mNumCotizacion = dtConsulta.Rows(0).Item("COTIZACION")
      tssNumeroCot.Text = "Cotización " & mNumCotizacion

      lblProveedor.Text = dtConsulta.Rows(0).Item("PROVEEDOR").ToString
      lblFecha.Text = dtConsulta.Rows(0).Item("FECHA")
      dtpFechaEntrega.Value = dtConsulta.Rows(0).Item("FECHAENTREGA")
      txtNumCotProveedor.Text = ""

      Call CargaDetCotizacionProveedor(CInt(dtConsulta.Rows(0).Item("Cotizacion").ToString))

      



    End If

    Frm.Dispose()
  End Sub

  Private Sub CargaDetCotizacionProveedor(NumCotizacion As Integer)
    Dim obCntv As New clConectividad, strCamposSQL As String, mTabla As DataTable

    Try

      'DATOS DE DETALLE
      strCamposSQL = "cotizacion,proveedor, det_id, [cod producto], producto, medida, cantidad, costo, costoprom [costo Ziur], idUnidad, CabSol_Id, DetSol_Id"
      grDetalle.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCamposSQL, "VW_ConsultaCotizacionProveedor", "Cotizacion=" & NumCotizacion.ToString)
      tssNumeroCot.Text = "Cotización " & NumCotizacion
      mNumCotizacion = NumCotizacion

      'DATOS DE CABECERA
      mTabla = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_ConsultaCabCotizacionProveedor", "Cotizacion=" & NumCotizacion.ToString)
      lblProveedor.Text = mTabla.Rows(0).Item("proveedor").ToString
      lblFecha.Text = Format(mTabla.Rows(0).Item("fecha"), "dd/MM/yyyy")
      mCab_Id = mTabla.Rows(0).Item("id").ToString

      Call FormatoGrilla()

      Dim mBoton As Button = Me.Tag
      mBoton.Text = Me.Text & " " & NumCotizacion
      btnGrabar.Text = "Actualizar"

      mDocCargado = True
      btnGrabar.Text = "Actualizar"

      btnImprimir.Visible = True


      mTabla = Nothing
      obCntv = Nothing

    Catch ex As IndexOutOfRangeException
      MessageBox.Show("Número de cotización no existe!", "No hay datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)


    End Try

  End Sub

  Private Sub FormatoGrilla()
    Dim Cc As Integer ', strtemp As String = ""

    With grDetalle
      For Cc = 0 To .Columns.Count - 1
        .Columns(Cc).HeaderText = .Columns(Cc).HeaderText.ToUpper
        .Columns(Cc).ReadOnly = True
        .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

       ' strtemp = strtemp & .Columns(Cc).HeaderText.ToUpper & vbTab & .Columns(Cc).Width & vbCrLf

      Next

      'TextBox1.Text = strtemp
      .Columns("COSTO").ReadOnly = False
      .Columns("Proveedor").Visible = False
      .Columns("cotizacion").Visible = False
      .Columns("idUnidad").Visible = False
      .Columns("CabSol_Id").Visible = False
      .Columns("DetSol_Id").Visible = False



      .Columns("CANTIDAD").DefaultCellStyle.Format = "N2" : .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("COSTO").DefaultCellStyle.Format = "N2" : .Columns("COSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      .Columns("COSTO ZIUR").DefaultCellStyle.Format = "N2" : .Columns("COSTO ZIUR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

      .Columns("COTIZACION").Width = 100
      .Columns("PROVEEDOR").Width = 100
      .Columns("DET_ID").Width = 65
      .Columns("COD PRODUCTO").Width = 150
      .Columns("PRODUCTO").Width = 290
      .Columns("MEDIDA").Width = 90
      .Columns("CANTIDAD").Width = 90
      .Columns("COSTO").Width = 100
      .Columns("COSTO ZIUR").Width = 100


    End With


  End Sub

  Private Sub frmActualizaPrecios_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try
  End Sub


  Private Sub txtNumOrden_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtNumOrden.KeyDown
      If e.KeyCode = Keys.Enter Then
        txtNumCotProveedor.Text = ""
        Call CargaDetCotizacionProveedor(txtNumOrden.Text)

      End If
  End Sub


  Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
    If flyPanelBotones.Width = 190 Then
          flyPanelBotones.Width = 45
          grDetalle.Width = grDetalle.Width + (190 - 45)
          'tbcContenido.Left = tbcContenido.Left - (255 - 70)
        Else
          flyPanelBotones.Width = 190
          'grDetalle.Width = Me.Width - 190
          'grDetalle.Width = grDetalle.Width - 30
          grDetalle.Width = Me.Width - 190 - 30 'tbcContenido.Width - 190 '- 45)
          'panelContenedor.Left = panelContenedor.Left + (255 - 70)
        End If


        
        


  End Sub

  Private Sub frmActualizaPrecios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      txtNumOrden.Select()
      'Detectar el separador decimal de la aplicación.
      Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator
  End Sub

   Private Sub txtNumOrden_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) _
      Handles txtNumOrden.KeyPress

      If Not (Char.IsNumber(e.KeyChar) Or e.KeyChar.Equals(Sep) Or Char.IsControl(e.KeyChar)) Then e.Handled = True
      If InStr(sender.text, Sep) > 0 And e.KeyChar.Equals(Sep) Then e.Handled = True
    End Sub


    Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
      Dim Ff As Integer, Ff_ID As Integer
      Dim obCntv As New clConectividad, obCompras As New clCompras

      Ff_ID = 1
      For Ff = 0 To grDetalle.RowCount - 1

          Dim NuevaFila = obCompras.TablaCMP_DetCotizacion.NewRow()

          Ff_ID = Ff_ID + 1
          NuevaFila("Cab_ID") = mCab_Id
          NuevaFila("id") = grDetalle.Item("DET_ID", Ff).Value
          NuevaFila("Inventario_Id") = grDetalle.Item("COD PRODUCTO", Ff).Value
          NuevaFila("Unidad_Id") = grDetalle.Item("IdUnidad", Ff).Value
          NuevaFila("Cant") = grDetalle.Item("CANTIDAD", Ff).Value
          NuevaFila("Costo") = grDetalle.Item("COSTO", Ff).Value
          NuevaFila("CabSol_Id") = grDetalle.Item("CabSol_Id", Ff).Value
          NuevaFila("DetSol_Id") = grDetalle.Item("DetSol_Id", Ff).Value

          obCompras.TablaCMP_DetCotizacion.AddCMP_DetCotizacionRow(NuevaFila)
      Next

      Call obCompras.ActualizaDetalleCotiza(mCab_Id, My.Settings.cnnModProd)
      Dim strCampos As String

      strCampos = "FechaEntrega='" & dtpFechaEntrega.Value.Date & "', NumDocProv='" & txtNumCotProveedor.Text & "'"

      obCntv.ActualizaValor(strCampos, "CMP_CabCotizacion", "id=" & mCab_Id.ToString, My.Settings.cnnModProd)

      'store para grabar el historico de precios de un proveedor
      obCntv.EjecutaComando("exec PA_GrabaHistoricoPreciosProv " & mCab_Id.ToString, My.Settings.cnnModProd, False)

      MessageBox.Show("Precios actualizados con éxito!", "Datos actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information)


    End Sub




End Class