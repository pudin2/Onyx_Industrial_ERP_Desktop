Option Explicit On

Public Class frmMtoPedidos
  Private mWhere As String
  Private obXml As New clManejoXML
  Private strProveedor As String
  Private mEntradaFrmAdmin As Boolean
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private dtProveedores As Data.DataTable


  Private mUsuarioId As Integer, mTipoConsola As String

  Public Property UsuarioId As Integer
    Get
      Return mUsuarioId
    End Get
    Set(ByVal value As Integer)
      mUsuarioId = value
    End Set
  End Property

  Public Property TipoConsola As String
    Get
      Return mTipoConsola
    End Get
    Set(ByVal value As String)
      mTipoConsola = value
    End Set
  End Property


  Private Sub frmEliminaPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If mTipoConsola = "OC" Then
      Me.Text = "Mantenimiento de Ordenes de compra"
    Else
      Me.Text = "Mantenimiento de Pedidos"
    End If


    Call CargarPedidos()
  End Sub

  Private Sub CargarPedidos()
    Dim obCntv As New clConectividad
    Call NombrarBotones()
    Dim strEstadosSolped As String = obCntv.LeerValorSencillo("Valor", "Parametros", "Descripcion ='EstadoCargaMtoPedCompras'", My.Settings.cnnModProd)
    strEstadosSolped = strEstadosSolped.Replace("|", "'")

    Dim strCampos As String = "OT,OC,[NUM SOLICITUD],[TIPO SOLICITUD],FECHA,MATERIAL,[NOMBRE MATERIAL]," _
      & "CANTIDAD, [CANTIDAD COMPRADA] [COMPRA], [CANT BORRADOS] [BORRADOS], CANTIDAD - [CANTIDAD COMPRADA] - [CANT BORRADOS] [PENDIENTE] ," _
      & "MEDIDA,[DESC ITEM]," _
      & "PIDE,CLIENTE,PROYECTO,id,Clave,NumOrden,IdUnidad,CabSol_Id,DetSol_Id,[CANT COTIZACIONES]," _
      & "[ESTADO OC],[ESTADO PEDIDO]"

    Dim strWhere As String = ""

    If txtOC.Text <> "" Then
      strWhere = "OC like '" & txtOC.Text.Replace("*", "%") & "' AND "
    End If

    If txtMP.Text <> "" Then
      strWhere = strWhere & "MATERIAL like '" & txtMP.Text.Replace("*", "%") & "' AND "
    End If

    If txtOT.Text <> "" Then
      strWhere = strWhere & "OT like '" & txtOT.Text.Replace("*", "%") & "' AND "
    End If


    If optSolManual.Checked = True Then
      strWhere = strWhere & "[TIPO SOLICITUD] LIKE 'PM' AND "
    ElseIf optSolNormal.Checked = True Then
      strWhere = strWhere & "[TIPO SOLICITUD] LIKE 'OT' AND "
    Else
      strWhere = strWhere & "[TIPO SOLICITUD] LIKE '%' AND "
    End If


    strWhere = strWhere & "[estado pedido] in (" & strEstadosSolped & ") AND [ESTADO OC]<>'I' and isnull(NumOrden,'') like '%'"

    grPedidos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "vw_BuscaSC", strWhere & mWhere, "Order by OT,Material")

    Call FormatoGrilla()

  End Sub


  Private Sub NombrarBotones()
    Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()


    obXml.AbrirXml(strRutaApp & "\Resources\ModProdUICompras.xml")
    obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

    'Me.Text = obXml.LeerValor("frmTituloMtoPedidos")
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
    'grPedidos.Columns("CantCotizaciones").Visible = False



    grPedidos.Columns("FECHA").Width = 85
    grPedidos.Columns("OT").Width = 65
    'grPedidos.Columns("COTIZAR").Width = 75
    grPedidos.Columns("MATERIAL").Width = 80
    grPedidos.Columns("NOMBRE MATERIAL").Width = 300
    grPedidos.Columns("DESC ITEM").Width = 250
    grPedidos.Columns("CANTIDAD").Width = 76
    grPedidos.Columns("COMPRA").Width = 76
    grPedidos.Columns("PENDIENTE").Width = 82
    grPedidos.Columns("BORRADOS").Width = 82
    grPedidos.Columns("MEDIDA").Width = 80
    grPedidos.Columns("PIDE").Width = 176
    grPedidos.Columns("CLIENTE").Width = 230
    grPedidos.Columns("PROYECTO").Width = 320

    grPedidos.Columns("Cant Cotizaciones").Width = 120 : grPedidos.Columns("Cant Cotizaciones").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    grPedidos.Columns("CANTIDAD").DefaultCellStyle.Format = "N4" : grPedidos.Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    grPedidos.Columns("COMPRA").DefaultCellStyle.Format = "N4" : grPedidos.Columns("COMPRA").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    grPedidos.Columns("PENDIENTE").DefaultCellStyle.Format = "N4" : grPedidos.Columns("PENDIENTE").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    grPedidos.Columns("BORRADOS").DefaultCellStyle.Format = "N4" : grPedidos.Columns("BORRADOS").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


    Dim Cc As Integer
    For Cc = 0 To grPedidos.Columns.Count - 1
      grPedidos.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
      grPedidos.Columns(Cc).ReadOnly = True
      grPedidos.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
    Next Cc

    ' grPedidos.Columns("COTIZAR").ReadOnly = False
    grPedidos.Columns("CANTIDAD").ReadOnly = False


    '********** ADICIONO EL BOTON DE ELIMINAR
    If grPedidos.ColumnCount = 25 Then
      Dim btn As New DataGridViewButtonColumn()
      grPedidos.Columns.Add(btn)
      btn.HeaderText = ""
      btn.Text = "Eliminar"
      btn.Name = "btnEliminarPedido"
      btn.UseColumnTextForButtonValue = True
      grPedidos.Columns("btnEliminarPedido").DisplayIndex = 0

    End If

    Call FormatoItemsCotizados()

  End Sub


  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    'Call GrabarCotizacion()

    'Call BorrarPedidos()

  End Sub


  Private Sub frmEliminaPedidos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    Dim mBoton As Button = Me.Tag
    Try
      frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
    Catch ex As System.NullReferenceException
      'no hago nada
    End Try
  End Sub


  Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
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


  Private Sub btnCargar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCargar.Click
    Call CargarPedidos()
  End Sub

  Public Sub PantallaAdminCompras()
    grPedidos.Columns("COTIZAR").HeaderText = "ELIMINAR"
    mEntradaFrmAdmin = True
    btnGrabar.Visible = True
  End Sub



  Private Sub txtOC_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtOC.KeyDown, txtMP.KeyDown, txtOT.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call CargarPedidos()

    End If
  End Sub

  Private Sub grPedidos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grPedidos.CellContentClick
    Dim senderGrid = DirectCast(sender, DataGridView)

    If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
        e.RowIndex >= 0 AndAlso senderGrid.Item("btnEliminarPedido", e.RowIndex).Value = "Eliminar" Then

      'TODO - Button Clicked - Execute Code Here
      Dim frm As New frmModMtoPedidos
      frm.TipoConsola = mTipoConsola
      frm.CntCompra = senderGrid.Item("COMPRA", e.RowIndex).Value
      frm.CntPedido = senderGrid.Item("CANTIDAD", e.RowIndex).Value
      frm.CntBorrado = senderGrid.Item("BORRADOS", e.RowIndex).Value
      frm.UsuarioId = mUsuarioId
      frm.DetSol_Id = senderGrid.Item("DetSol_Id", e.RowIndex).Value


      frm.ShowDialog()
      Call CargarPedidos()


    End If
  End Sub

Private Sub optSolManual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSolManual.CheckedChanged

End Sub
End Class