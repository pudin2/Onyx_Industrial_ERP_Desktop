Option Explicit On

Public Class frmLiberaPedidoAlmacen
  Private mWhere As String
  Private obXml As New clManejoXML
  Private strProveedor As String
  Private mEntradaFrmAdmin As Boolean
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal

  Private Sub frmLiberaPedidoAlmacen_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
      Call CargarPedidos()
  End Sub

  Private Sub CargarPedidos()
    Dim obCntv As New clConectividad
      Call NombrarBotones()

      'cmbProveedores.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_Proveedores", "esactivo=1", "Order by Nombre1")
      'cmbProveedores.DisplayMember = "NombreCompleto"

      Dim strEstadosSolped As String = "|R|" 'obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion ='EstadoCargaPedCompras'", My.Settings.cnnModProd)
      strEstadosSolped = strEstadosSolped.Replace("|","'")

      'grPedidos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_BuscaSC", "[estado pedido] in ('R','CT') and isnull(NumOrden,'') like '%'" & mWhere, "Order by [num solicitud],id")
      grPedidos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_BuscaSC_Almacen", "[estado pedido] in (" & strEstadosSolped & ") and isnull(NumOrden,'') like '%'" & mWhere, "Order by [num solicitud],id")
      Call FormatoGrilla()

      Dim mBoton As New DataGridViewButtonColumn
      mBoton.Name = "btnLiberar"

      mBoton.Text = "Liberar"
      mBoton.UseColumnTextForButtonValue = True
      mBoton.HeaderText = ""
      grPedidos.Columns.Add(mBoton)
      grPedidos.Columns("btnLiberar").DisplayIndex = 10


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

    'Dim mBoton As Button = Me.Tag
    'mBoton.Text = obXml.LeerValor("btnTitulo")



  End Sub


    Private Sub FormatoGrilla()
      grPedidos.Columns("id").Visible = False
      grPedidos.Columns("Clave").Visible = False
      grPedidos.Columns("NumOrden").Visible = False
      grPedidos.Columns("idUnidad").Visible = False
      grPedidos.Columns("CabSol_Id").Visible = False
      grPedidos.Columns("DetSol_Id").Visible = False
      grPedidos.Columns("ESTADO PEDIDO").Visible = False
      'grPedidos.Columns("CantCotizaciones").Visible = False



      grPedidos.Columns("FECHA").Width = 85
      grPedidos.Columns("OT").Width = 65
      'grPedidos.Columns("COTIZAR").Width = 75
      grPedidos.Columns("COMPRAR").Width = 75
      grPedidos.Columns("MATERIAL").Width = 80
      grPedidos.Columns("NOMBRE MATERIAL").Width = 300
      grPedidos.Columns("DESC ITEM").Width = 250
      grPedidos.Columns("CANTIDAD").Width = 76
      grPedidos.Columns("MEDIDA").Width = 80
      grPedidos.Columns("PIDE").Width = 176
      grPedidos.Columns("CLIENTE").Width = 230
      grPedidos.Columns("PROYECTO").Width = 320
      'grPedidos.Columns("Cant Cotizaciones").Width = 120 : grPedidos.Columns("Cant Cotizaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      grPedidos.Columns("CANTIDAD").DefaultCellStyle.Format = "N4" : grPedidos.Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grPedidos.Columns("CANTIDAD A COMPRAR").DefaultCellStyle.Format = "N4" : grPedidos.Columns("CANTIDAD A COMPRAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
      grPedidos.Columns("CANTIDAD A RESERVAR").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

      Dim Cc As Integer
      For Cc = 0 To grPedidos.Columns.Count - 1
        grPedidos.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grPedidos.Columns(Cc).ReadOnly = True
        grPedidos.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
      Next Cc

      grPedidos.Columns("COMPRAR").ReadOnly = False
      grPedidos.Columns("CANTIDAD").ReadOnly = False
      grPedidos.Columns("CANTIDAD A COMPRAR").ReadOnly = False

      Dim Ff As Integer

      For Ff = 0 To grPedidos.Rows.Count - 1
        grPedidos.Item("CANTIDAD A COMPRAR", Ff).Style.BackColor = Color.FromArgb(157, 230, 159) ' .GreenYellow ' .Coral
      Next Ff




      'Call FormatoItemsCotizados()

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
        'obCompras.GrabarCotizacion(My.Settings.cnnModProd, strCab_Id, strNumCotizacion, strProveedor, DateTime.Today, "R", "", txtObservacion.Text, #1/1/2000#)

        'ACTUALIZO EL ESTADO DEL DETALLE DEL PEDIDO, EN ESTADO COTIZADO: 'CT' = COTIZADO
        'obCntv.EjecutaComando("EXEC PA_ActualizaEstadoPedido 'CT'," & strCab_Id.ToString, My.Settings.cnnModProd, False)


        obCntv = Nothing
        MessageBox.Show("Se ha creado la cotización de proveedor número: " & strNumCotizacion, "Cotización Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Sub

  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
    'Call GrabarCotizacion()

    Call BorrarPedidos()

  End Sub
  

  Private Sub frmLiberaPedidoAlmacen_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
      'For Ff = 0 To grPedidos.Rows.Count - 1
      '  If grPedidos.Rows(Ff).Cells("Cant Cotizaciones").Value > 0 Then
      '    'grPedidos.Item("colCodigoInventario", e.RowIndex).Style.BackColor = Color.FromArgb(103, 177, 49)

      '    For CC = 0 To grPedidos.Columns.Count - 1
      '      grPedidos.Item(CC, Ff).Style.BackColor = Color.Cyan  'Color.FromArgb(103, 177, 49)
      '    Next CC

      '  End If
      'Next Ff
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

  Private Sub CalcCntReserva(Ff As Integer)
    Dim mCant As Decimal
      'mctn = CDec(mCant).ToString(FCANT)

    If grPedidos.Item("COMPRAR", Ff).Value = True Then
      mCant = grPedidos.Item("CANTIDAD", Ff).Value - grPedidos.Item("CANTIDAD A COMPRAR", Ff).Value
      grPedidos.Item("CANTIDAD A RESERVAR", Ff).Value = CDec(mCant).ToString("N4")
      grPedidos.Item("CANTIDAD A COMPRAR", Ff).Value = grPedidos.Item("CANTIDAD", Ff).Value '.ToString("N4")

    Else
      mCant = grPedidos.Item("CANTIDAD", Ff).Value
      grPedidos.Item("CANTIDAD A RESERVAR", Ff).Value = CDec(mCant).ToString("N4")
      grPedidos.Item("CANTIDAD A COMPRAR", Ff).Value = CDec(0).ToString("N4")

    End If


  End Sub


  Private Sub grPedidos_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grPedidos.CellValueChanged
      If grPedidos.Columns(e.ColumnIndex).Name = "COMPRAR" Then
        Call CalcCntReserva(e.RowIndex)


      End If
  End Sub

  Private Sub grPedidos_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grPedidos.CellMouseUp
      grPedidos.CommitEdit(DataGridViewDataErrorContexts.Commit)
  End Sub

  Private Sub grPedidos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grPedidos.CellContentClick
      ' If grOT.Columns(e.ColumnIndex).Name = "btnImprimir" Then
      '  'MessageBox.Show("Imprimir")
      '  Call ImprimirOT(e.RowIndex)

      '' Se ha hecho clic
      'ElseIf grOT.Columns(e.ColumnIndex).Name = "btnValidar" Then
      '  Call ValidarOT(grOT.Item("ORDEN", e.RowIndex).Value, grOT.Item("OTCabCotizacion_Id", e.RowIndex).Value)


      'End If
  End Sub
End Class