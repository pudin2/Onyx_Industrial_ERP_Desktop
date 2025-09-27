Option Explicit On

Public Class frmPedidos
  Private mWhere As String
  Private obXml As New clManejoXML
  Private strProveedor As String
  Private mEntradaFrmAdmin As Boolean
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private dtProveedores As Data.DataTable

  Private Sub frmPedidos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Call CargarPedidos()
  End Sub

  Private Sub CargarPedidos()
    Dim obCntv As New clConectividad
    Dim strWhere As String = ""


    If txtOC.Text <> "" Then
      strWhere = "AND OC like '" & txtOC.Text.Replace("*", "%") & "' "
    End If

    If txtMP.Text <> "" Then
      strWhere = strWhere & "AND MATERIAL like '" & txtMP.Text.Replace("*", "%") & "' "
    End If

    If txtOT.Text <> "" Then
      strWhere = strWhere & "AND OT like '" & txtOT.Text.Replace("*", "%") & "' "
    End If

    Call NombrarBotones()

    dtProveedores = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Proveedores", "esactivo=1", "Order by Nombre1")
    cmbProveedores.DataSource = dtProveedores
    cmbProveedores.DisplayMember = "NombreCompleto"



    Dim strEstadosSolped As String = obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion ='EstadoCargaPedCompras'", My.Settings.cnnModProd)
    strEstadosSolped = strEstadosSolped.Replace("|", "'")


    Dim strEstadosOC As String = ""
    If optOCEliminadas.Checked = True Then
        strEstadosOC = "AND [ESTADO OC] = 'I' "
    ElseIf optOCActivas.Checked = True Then
        strEstadosOC = "AND [ESTADO OC] not like 'I' "
    Else
        strEstadosOC = "AND [ESTADO OC] like '%'"
    End If


    'grPedidos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_BuscaSC", "[estado pedido] in (" & strEstadosSolped & ") and isnull(NumOrden,'') like '%'" & mWhere, "Order by [num solicitud],id")
    grPedidos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*",
                                                  "vw_BuscaSC", "[estado pedido] in (" & strEstadosSolped & ")" _
                                                  & strWhere _
                                                  & strEstadosOC _
                                                  & " AND PEDIR='SI' and isnull(NumOrden,'') like '%'" _
                                                  & mWhere, "Order by [num solicitud],id")
      '& " AND [ESTADO OC]<>'I' AND [ESTADO DET OC]<>'I' AND PEDIR='SI' and isnull(NumOrden,'') like '%'" _
    Call FormatoGrilla()
  End Sub

  Private Sub btnCotizar_Click(sender As System.Object, e As System.EventArgs) Handles btnCotizar.Click
        Dim obCorreo As New clCorreo, strCuerpo As String
    Dim mTabla As New DataTable("ItemsACotizar"), Ff As Integer

    mTabla.Columns.Add("PRODUCTO", GetType(String))
    mTabla.Columns.Add("CANTIDAD", GetType(String))
    mTabla.Columns.Add("UNIDAD", GetType(String))

    For Ff = 0 To grPedidos.Rows.Count - 1
       If grPedidos.Item("COTIZAR", Ff).Value = True Then
          Dim mFila As DataRow = mTabla.NewRow
          mFila("PRODUCTO") = grPedidos.Item("NOMBRE MATERIAL", Ff).Value.ToString
          mFila("CANTIDAD") = CDec(grPedidos.Item("CANTIDAD", Ff).Value).ToString(FCANT)
          mFila("UNIDAD") = grPedidos.Item("MEDIDA", Ff).Value.ToString
          mTabla.Rows.Add(mFila)
      End If
    Next Ff

    strCuerpo = obCorreo.TextToHTML(obXml.LeerValor("MensajeCorreo_Parte1") & cmbProveedores.Text, "sans-serif", 2, True) _
      & obCorreo.TextToHTML(obXml.LeerValor("MensajeCorreo_Parte2"), "sans-serif", 2, True) _
      & obCorreo.DataTableToHTMLTable(mTabla)

    'strCuerpo = obXml.LeerValor("MensajeCorreo_Parte1") & cmbProveedores.Text & vbCrLf & vbCrLf & obXml.LeerValor("MensajeCorreo_Parte2") _
    '  & vbCrLf & vbCrLf & obCorreo.DataTableToTexto(mTabla)

    obCorreo.CuerpoMensaje = strCuerpo
    obCorreo.enviar_mail()

    Call GrabarCotizacion()
    Call CargarPedidos()

  End Sub


  Private Sub NombrarBotones()
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()


    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUICompras.xml")
    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

    Me.Text = obXml.LeerValor("frmTitulo")
    btnCotizar.Text = obXml.LeerValor("btnCotizar")
    btnGrabar.Text = obXml.LeerValor("btnGrabar")
    btnCargar.Text = obXml.LeerValor("btnCargar")
    btnImprimir.Text = obXml.LeerValor("btnImprimir")

    Dim mBoton As Button = Me.Tag
    mBoton.Text = obXml.LeerValor("btnTitulo")



  End Sub


    Private Sub FormatoGrilla()
      grPedidos.Columns("id").Visible = False
      grPedidos.Columns("Clave").Visible = False
      grPedidos.Columns("NumOrden").Visible = False
      grPedidos.Columns("idUnidad").Visible = False
      grPedidos.Columns("CabSol_Id").Visible = False
      grPedidos.Columns("DetSol_Id").Visible = False
      grPedidos.Columns("ESTADO PEDIDO").Visible = False
      grPedidos.Columns("PEDIR").Visible = False
      grPedidos.Columns("ESTADO DET OC").Visible = False

      'grPedidos.Columns("CantCotizaciones").Visible = False



      grPedidos.Columns("FECHA").Width = 85
      grPedidos.Columns("OT").Width = 65
      grPedidos.Columns("COTIZAR").Width = 75
      grPedidos.Columns("MATERIAL").Width = 80
      grPedidos.Columns("NOMBRE MATERIAL").Width = 300
      grPedidos.Columns("DESC ITEM").Width = 250
      grPedidos.Columns("CANTIDAD").Width = 76
      grPedidos.Columns("MEDIDA").Width = 80
      grPedidos.Columns("PIDE").Width = 176
      grPedidos.Columns("CLIENTE").Width = 230
      grPedidos.Columns("PROYECTO").Width = 320
      grPedidos.Columns("Cant Cotizaciones").Width = 120 : grPedidos.Columns("Cant Cotizaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      grPedidos.Columns("CANTIDAD").DefaultCellStyle.Format = "N4" : grPedidos.Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grPedidos.Columns("PENDIENTE").DefaultCellStyle.Format = "N4" : grPedidos.Columns("PENDIENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grPedidos.Columns("COSTO").DefaultCellStyle.Format = "N0" : grPedidos.Columns("COSTO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grPedidos.Columns("PENDIENTE").DisplayIndex = 7

      Dim Cc As Integer
      For Cc = 0 To grPedidos.Columns.Count - 1
        grPedidos.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grPedidos.Columns(Cc).ReadOnly = True
        grPedidos.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
      Next Cc

      grPedidos.Columns("COTIZAR").ReadOnly = False
      grPedidos.Columns("CANTIDAD").ReadOnly = False

   

      Call FormatoItemsCotizados()

    End Sub

      Private Sub cmbProveedor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbProveedores.SelectedIndexChanged
          Dim selectedItem As DataRowView
          selectedItem = cmbProveedores.SelectedItem

          strProveedor = selectedItem("idCliente").ToString
          
      End Sub

    Private Sub GrabarCotizacion()
        Dim Ff As Integer, obCntv As New clConectividad, strCab_Id As String, strNumCotizacion As String
        Dim obCompras As New clCompras

        'EL NUMERO CONSECUTIVO
        strCab_Id = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CMP_CabCotizacion", "1=1", My.Settings.cnnModProd)
        strNumCotizacion = obCntv.LeerValorSencillo("CONVERT(int,valor)+1 [NumCotizacion]", "NumCotizacion", "Parametros", " ID=20", My.Settings.cnnModProd)
        obCntv.EjecutaComando("update Parametros set Valor='" & strNumCotizacion.ToString & "' where id=20", My.Settings.cnnModProd, False)

        'EL PROVEEDOR esta en el evento change del combo

        'TABLA TEMPORAL DEL DETALLE
        For Ff = 0 To grPedidos.Rows.Count - 1
          'GENERO LA SOLPED SI: SE SELECCIONA PARA COMPRA, SE HA REVISADO Y SI NO SE HA REPORTADO ANTES
          If grPedidos.Item("COTIZAR", Ff).Value = True Then
            Dim NuevaFila = obCompras.TablaCMP_DetCotizacion.NewCMP_DetCotizacionRow    '.TablaDetSolicitud.NewDetSolicitudRow
            NuevaFila("Cab_Id") = strCab_Id
            NuevaFila("Id") = Ff + 1
            NuevaFila("Inventario_ID") = grPedidos.Item("MATERIAL", Ff).Value
            NuevaFila("Unidad_Id") = grPedidos.Item("IdUnidad", Ff).Value
            NuevaFila("CodInventario") = "" 'grPedidos.Item("CodInventario", Ff).Value
            NuevaFila("Cant") = grPedidos.Item("CANTIDAD", Ff).Value
            'NuevaFila("Estado") = "R"
            NuevaFila("Costo") = 0

            NuevaFila("CabSol_Id") = grPedidos.Item("CabSol_Id", Ff).Value
            NuevaFila("DetSol_Id") = grPedidos.Item("DetSol_Id", Ff).Value


            obCompras.TablaCMP_DetCotizacion.AddCMP_DetCotizacionRow(NuevaFila)

          End If
        Next
        'Dim maxId As String = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CMP_CabCotizacion", "1=1", My.Settings.cnnModProd)
        obCompras.GrabarCotizacion(My.Settings.cnnModProd, strCab_Id, strNumCotizacion, strProveedor, DateTime.Today, "R", "", txtObservacion.Text, #1/1/2000#)

        'ACTUALIZO EL ESTADO DEL DETALLE DEL PEDIDO, EN ESTADO COTIZADO: 'CT' = COTIZADO
        obCntv.EjecutaComando("EXEC PA_ActualizaEstadoPedido 'CT'," & strCab_Id.ToString, My.Settings.cnnModProd, False)


        obCntv = Nothing
        MessageBox.Show("Se ha creado la cotización de proveedor número: " & strNumCotizacion, "Cotización Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Sub

  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
    'Call GrabarCotizacion()

    Call BorrarPedidos()

  End Sub
  

  Private Sub frmPedidos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try
  End Sub


  Private Sub btnBotonera_Click(sender As System.Object, e As System.EventArgs) Handles btnBotonera.Click
        If flyPanelBotones.Width = 190 Then
            flyPanelBotones.Width = 45
            grPedidos.Width = grPedidos.Width + (190 - 45)
          Else
            flyPanelBotones.Width = 190
            grPedidos.Width = grPedidos.Width - (190 - 45)
          End If
  End Sub


  Public Sub FormatoItemsCotizados()
     Dim Ff As Integer, CC As Integer
      For Ff = 0 To grPedidos.Rows.Count - 1
        If grPedidos.Rows(Ff).Cells("Cant Cotizaciones").Value > 0 Then
          'grPedidos.Item("colCodigoInventario", e.RowIndex).Style.BackColor = Color.FromArgb(103, 177, 49)

          For CC = 0 To grPedidos.Columns.Count - 1
            grPedidos.Item(CC, Ff).Style.BackColor = Color.Cyan  'Color.FromArgb(103, 177, 49)
          Next CC

        End If

        If grPedidos.Rows(Ff).Cells("ESTADO OC").Value = "I" Then
          For CC = 0 To grPedidos.Columns.Count - 1
            grPedidos.Item(CC, Ff).Style.BackColor = Color.Yellow   'Color.FromArgb(103, 177, 49)
          Next CC
        End If



      Next Ff
End Sub


  Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
    Call CargarPedidos()
  End Sub

  Public Sub PantallaAdminCompras()
    grPedidos.Columns("COTIZAR").HeaderText = "ELIMINAR"
    mEntradaFrmAdmin = True
    btnGrabar.Visible = True
  End Sub

  'Private Sub lblProveedor_Click(sender As System.Object, e As System.EventArgs) Handles lblProveedor.Click
  '    Call PantallaAdminCompras()
  'End Sub


  Private Sub BorrarPedidos()
    Dim Ff As Integer, strWhere As String, obCntv As New clConectividad

    For Ff = 0 To grPedidos.Rows.Count - 1
      If grPedidos.Item("COTIZAR", Ff).Value = True Then
        strWhere = "cab_id=" & grPedidos.Item("CabSol_Id", Ff).Value & " and Id=" & grPedidos.Item("DetSol_Id", Ff).Value
        obCntv.ActualizaValor("Estado='I'", "DetSolicitud", strWhere, My.Settings.cnnModProd)
      End If
    Next

    obCntv = Nothing

    MessageBox.Show("Pedidos eliminados con éxito!", "Pedidos eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Call CargarPedidos()
  End Sub

  Private Sub cmbProveedores_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbProveedores.KeyDown
      If e.KeyCode = Keys.F3 Then
              If e.Modifiers = Keys.Control Then
                  Call BuscarItem(cmbProveedores.Text, , True)
              Else
                  Call BuscarItem(cmbProveedores.Text)
              End If

          ElseIf e.KeyCode = Keys.F9 Then
              Call BuscarItem("%")

              'ElseIf (e.KeyCode = Keys.F3 AndAlso e.Modifiers = Keys.Control) Then
              '   Call BuscarItem(cmbProducto.Text, , True)
          End If
  End Sub

  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional ByVal bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbProveedores.BackColor
        cmbProveedores.BackColor = Color.Yellow
        cmbProveedores.Text = strMensaje  '"Buscando ..."
        cmbProveedores.Refresh()


        Dim dtFiltrado As Data.DataTable


        'If bolAvanzada = False Then
          dtFiltrado = dtProveedores.Clone
          strFiltro = "nombrecompleto like '%" & strFiltro & "%'"
          Dim result() As DataRow = dtProveedores.Select(strFiltro)

          For Each row As DataRow In result
            dtFiltrado.Rows.Add(row(0), row(1), row(2), row(3), row(4), row(5), row(6), row(7), row(8), row(9), row(10), row(11), row(12))
            mCnt = mCnt + 1
          Next

          If mCnt = 0 Then
              MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              Call BuscarItem("%", "Actualizando ...")
              cmbProveedores.BackColor = mColor
              cmbProveedores.Refresh()

          Else
              cmbProveedores.DataSource = dtFiltrado
              cmbProveedores.DisplayMember = "Descripcion"
              cmbProveedores.BackColor = mColor
              cmbProveedores.Refresh()
          End If

    End Sub

  Private Sub txtOC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOC.KeyDown, txtOT.KeyDown, txtMP.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call CargarPedidos()

    End If
  End Sub


End Class