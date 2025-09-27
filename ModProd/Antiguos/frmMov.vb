Option Explicit On
Imports System.Configuration
Imports Microsoft.Reporting.WinForms
Public Class frmMov
Private strCadena As String
Public strMotivo_ID As String

Private Sub frmMov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim obMov As New clMovimiento
    strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString
    'Dim dsMov As DataSet = obMov.CargarMovimiento(strCadena, 77)
   ' dsMov.DataSetName = "Cabecera Movimientos"
   ' grCabMov.DataSource = dsMov.Tables("CabMov")
    Me.Cursor = Cursors.WaitCursor
   Call CargarCabMov()
    Me.Cursor = Cursors.Default
    'Dim obCntv As New clConectividad
    'grCabMov.DataSource = obCntv.LlenarDataTable(strCadena, "*", "CabMov", "estado='A'")

    'Call CreateUnboundButtonColumn(grCabMov, "Validar", "Validar", "cmdValidar", grCabMov.Columns.Count)

End Sub

  Private Sub grCabMov_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grCabMov.CellClick
    If e.ColumnIndex = 6 + 2 Then
      Dim Numero As Integer, Mensaje As String, CabOrden_ID As Integer, CabMov_ID As Integer

      If strMotivo_ID = "2" Then
        CabMov_ID = grCabMov.Item(3, e.RowIndex).Value
        CabOrden_ID = grCabMov.Item(0, e.RowIndex).Value
        Numero = grCabMov.Item(4, e.RowIndex).Value

        Mensaje = "Entrega al área validada con éxito!"
      Else
        CabMov_ID = grCabMov.Item(0, e.RowIndex).Value
        CabOrden_ID = grCabMov.Item(0, e.RowIndex).Value
        Numero = grCabMov.Item(4, e.RowIndex).Value
        Mensaje = "Entrega a la bodega validada con éxito!"

      End If


      Call ValidarMovimiento(CabMov_ID, CabOrden_ID, Numero)
      MessageBox.Show(Mensaje)
      Call CargarCabMov()
      grDetMov.DataSource = Nothing

    End If


  End Sub


  Private Sub grCabMov_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grCabMov.RowEnter
    Dim obCntv As New clConectividad
    Dim CabMov As String = grCabMov.Item(3, e.RowIndex).Value.ToString

    grDetMov.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_ConsultaDetMov", "CabMov_ID=" & CabMov)
  End Sub

Private Sub CreateUnboundButtonColumn(ByRef Gr As DataGridView, ByVal Titulo As String, ByVal Texto As String, ByVal Nombre As String, ByVal Posicion As Integer)

    ' Initialize the button column. 
    Dim buttonColumn As New DataGridViewButtonColumn

    With buttonColumn
        .HeaderText = Titulo
        .Name = Nombre
        .Text = Texto

        ' Use the Text property for the button text for all cells rather 
        ' than using each cell's value as the text for its own button.
        .UseColumnTextForButtonValue = True
    End With

    ' Add the button column to the control.
    Gr.Columns.Insert(Posicion, buttonColumn)

End Sub

  Private Sub ValidarMovimiento(ByVal CabMov_ID As Integer, ByVal CabOrden_ID As Integer, ByVal Numero As Integer)

    Select Case strMotivo_ID
      Case "2"
        Dim obMov As New clMovimiento
        obMov.ValidarMovimiento(strCadena, CabMov_ID)

        If (MessageBox.Show("Desa imprimir la boleta de salida ahora?", "Imprimir", MessageBoxButtons.YesNo)) = Windows.Forms.DialogResult.Yes Then
          Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
          Dim obXml As New clManejoXML
          obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
          obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

          'INICIO LA ASIGNACIÓN DE CAMPOS
          Dim strMargenes As String = obXml.LeerValor("frmImpBoletas_Margenes")
          Dim Pg2 As New System.Drawing.Printing.PageSettings()
          Dim Size2 = New Printing.PaperSize()
          Dim vctMedidas2() As String
          vctMedidas2 = Split(strMargenes, ",")
          Pg2.Margins.Top = CInt(vctMedidas2(0))
          Pg2.Margins.Bottom = CInt(vctMedidas2(1))
          Pg2.Margins.Left = CInt(vctMedidas2(2))
          Pg2.Margins.Right = CInt(vctMedidas2(3))
          Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter

          Dim frm As New frmImprimeMov
          frm.rptReporte.SetPageSettings(Pg2)
          frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
          frm.rptReporte.RefreshReport()
          frm.strCabOrden_ID = CabOrden_ID.ToString
          frm.strMotivo_ID = 2 : frm.strNumero = Numero
          frm.Show()
        End If

        obMov = Nothing
      Case "4"
        Dim obConectividad As New clConectividad

        obConectividad.EjecutaComando("EXEC pa_CierraOrden " & CabMov_ID.ToString, strCadena, False)

      Case Else
        Dim obMov As New clMovimientoEntrada
        obMov.ValidarMovimiento(strCadena, CabMov_ID)

        If (MessageBox.Show("Desa imprimir ahora?", "Imprimir", MessageBoxButtons.YesNo)) = MessageBoxButtons.OK Then
          Dim frm As New frmImprimeMov
          frm.strCabOrden_ID = CabOrden_ID.ToString
          frm.strMotivo_ID = 3 : frm.strNumero = Numero
          frm.Show()
        End If
        obMov = Nothing
    End Select

    'If strMotivo_ID = "2" Then
    '  Dim obMov As New clMovimiento
    '  obMov.ValidarMovimiento(strCadena, CabMov_ID)
    '  obMov = Nothing
    'Else
    '  Dim obMov As New clMovimientoEntrada
    '  obMov.ValidarMovimiento(strCadena, CabMov_ID)
    '  obMov = Nothing
    'End If


  End Sub

Private Sub CargarCabMov()
    Dim obCntv As New clConectividad
    Dim strTituloMotivo As String

    If strMotivo_ID = 2 Then
      strTituloMotivo = "[Salida al área]"
    Else
      strTituloMotivo = "[Entrega del área]"
    End If
    grCabMov.DataSource = ""
    grCabMov.Columns.Clear()
    'grCabMov.DataSource = obCntv.LlenarDataTable(strCadena, "*", "CabMov", "estado='A' and Motivo_ID =" & strMotivo_ID)
    grCabMov.DataSource = obCntv.LlenarDataTable(strCadena, "[Numero Orden], [Salida al area] " & strTituloMotivo & _
                                                 ", fecha, id,CabMov_ID, observacion, area, empleado", "vw_ConsultaMov", _
                                                 "estado='A' and Motivo_ID IN(" & strMotivo_ID & ")")

    grCabMov.Columns("id").Visible = False
    grCabMov.Columns("Observacion").Width = 300
    grCabMov.Columns("Fecha").Width = 200
    grCabMov.Columns("Numero Orden").Width = 50
    grCabMov.Columns("Empleado").Width = 300

    Call CreateUnboundButtonColumn(grCabMov, "Validar", "Validar", "cmdValidar", grCabMov.Columns.Count)
    'grDetalle.Columns(7).Visible = False
    grCabMov.Columns(4).Visible = False
    obCntv = Nothing
  End Sub



  
  
  
  Private Sub grCabMov_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grCabMov.CellContentClick

  End Sub
End Class