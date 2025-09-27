Option Explicit On
Imports Microsoft.Reporting.WinForms
Imports MSSQL = System.Data.SqlClient
Imports System.Configuration


Public Class frmConsolaControl
  Private mUsuarioId As Integer, mTipoConsola As String

  Public Property UsuarioId As Integer
  Get
    Return mUsuarioId
  End Get
  Set(value As Integer)
    mUsuarioId = value
  End Set
  End Property

  Public Property TipoConsola As String
  Get
    Return mTipoConsola
  End Get
  Set(value As String)
    mTipoConsola = value
  End Set
  End Property

Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
  Dim strCadena As String

  Me.Cursor = Cursors.WaitCursor
  strCadena = Now.TimeOfDay.ToString
    Dim obCntv As New clConectividad, strCampos As String
    Dim strWhere As String

    grOT.Columns.Clear()
    If optOTSinImprimir.Checked = True Then
      strWhere = "Estado = 'V' and CntImpresas=0 and EtapaTerminada=0"
    ElseIf optOTImpresas.Checked = True Then
      strWhere = "CntImpresas>0"
    Else
      strWhere = "Estado<>'I'" '"Estado like '%'"
    End If

    strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

    strCampos = "id [ID], TIPO, NumOrden [ORDEN],convert(date,Fecha) [FECHA REGISTRO],UltimaImpresion [ULTIMA IMPRESION], NombreCliente [CLIENTE], NombreProyecto [PROYECTO] , Alcance [ALCANCE]"
        grOT.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_ImpresionesOT", strWhere)


    With grOT
      Dim mBoton As New DataGridViewButtonColumn
      mBoton.Name = "btnImprimir"
      mBoton.Text = "Imprimir"
      mBoton.UseColumnTextForButtonValue = True
      mBoton.HeaderText = ""

      .Columns.Add(mBoton)
    End With

    strCadena = strCadena & vbCrLf & Now.TimeOfDay.ToString

    Call FormatoGrilla()
    strCadena = strCadena & vbCrLf & Now.TimeOfDay.ToString

    Me.Cursor = Cursors.Default
    'MessageBox.Show(strCadena)

End Sub

  Private Sub frmConsolaControl_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
     Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
  End Sub

  Private Sub grOT_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grOT.CellContentClick
    If grOT.Columns(e.ColumnIndex).Name = "btnImprimir" Then
      'MessageBox.Show("Imprimir")
      Call ImprimirOT(e.RowIndex)

    ' Se ha hecho clic
    ElseIf grOT.Columns(e.ColumnIndex).Name = "btnValidar" Then
      Call ValidarOT(grOT.Item("ORDEN", e.RowIndex).Value, grOT.Item("OTCabCotizacion_Id", e.RowIndex).Value)


    End If
  End Sub

  Private Sub ValidarOT(xNumOrden As Integer, xOTCabCotizacion_Id As Integer)
    Dim frm As New frmValidarOT
    frm.NumOrden = xNumOrden
    frm.OTCabCotizacion_Id = xOTCabCotizacion_Id


    frm.UsuarioId = mUsuarioId

    frm.ShowDialog()

    If frm.DialogResult = Windows.Forms.DialogResult.OK Then
      Call CargarOTaValidar()
    End If

  End Sub

  Private Sub ImprimirOT(mFila As Integer)
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


      'Dim strOrden As String = txtNumOrden.Text  'InputBox("Número de Orden de Trabajo")


      Dim frm As New frmImprimeOT, mNumOrden As String = "%", mTipoOT As String
      mNumOrden = grOT.Item("Orden", mFila).Value
      mTipoOT = grOT.Item("Tipo", mFila).Value


      frm.strOrdenID = mNumOrden  'strOrden

      Dim obCntv As New clConectividad, mTipoRpt As String

      Debug.Print("*****INICIO **********'")
      Debug.Print(Now.TimeOfDay.ToString)
      mTipoRpt = obCntv.LeerValorSencillo("distinct MarcaAgua", "MarcaAgua", "VW_RPT_OrdenDeTrabajo", " numorden=" & mNumOrden, My.Settings.cnnModProd)

      If mTipoRpt = "DEFINITIVA" Then
        frm.strNombreReporte = My.Settings.NombreRptOrdenProduccion
      Else
        frm.strNombreReporte = My.Settings.NombreRptOrdenProduccionBorrador
      End If

      Debug.Print(Now.TimeOfDay.ToString)
      frm.rptReporte.SetPageSettings(Pg2)

      Debug.Print(Now.TimeOfDay.ToString)
      frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)

      Debug.Print(Now.TimeOfDay.ToString)
      frm.rptReporte.RefreshReport()

      Debug.Print(Now.TimeOfDay.ToString)
      frm.Show()

      Debug.Print(Now.TimeOfDay.ToString)
      Debug.Print("***** FIN **********'")
      'La parte de la creación del control de impresiones
      Dim obProd As New clProduccion

      'obProd.GrabarImpresionOT(My.Settings.cnnModProd, mNumOrden, mTipoOT, mUsuarioId, Date.Now, "A")


      obProd = Nothing

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Try

  End Sub




  Private Sub FormatoGrilla()

    grOT.Columns(0).Width = 0 : grOT.Columns(0).Visible = False
    grOT.Columns(1).Width = 40
    grOT.Columns(2).Width = 59
    grOT.Columns(3).Width = 134
    grOT.Columns(4).Width = 128
    grOT.Columns(5).Width = 254
    grOT.Columns(6).Width = 417
    grOT.Columns(7).Width = 150
    grOT.Columns(8).Width = 100

    Dim Cc As Integer
      For Cc = 0 To grOT.Columns.Count - 1
        grOT.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        grOT.Columns(Cc).ReadOnly = True
        grOT.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
      Next Cc

  End Sub


  Private Sub btnCargarValidadas_Click(sender As System.Object, e As System.EventArgs) Handles btnCargarValidadas.Click
      Call CargarOTaValidar()

  End Sub

  Private Sub CargarOTaValidar()

      Dim strCadena As String

      Me.Cursor = Cursors.WaitCursor
      strCadena = Now.TimeOfDay.ToString
      Dim obCntv As New clConectividad, strCampos As String
      Dim strWhere As String

      grOT.Columns.Clear()
      If optOTSinValidar.Checked = True Then
            strWhere = "Estado = 'V' and EtapaTerminada = 0"
      ElseIf optOTValidadas.Checked = True Then
        strWhere = "EtapaTerminada > 0"
      Else
        strWhere = "Estado<>'I'" '"Estado like '%'"
      End If

      strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

      strCampos = "id [ID], TIPO, NumOrden [ORDEN],convert(date,Fecha) [FECHA REGISTRO],UltimaImpresion [ULTIMA IMPRESION], NombreCliente [CLIENTE], NombreProyecto [PROYECTO] , Alcance [ALCANCE], OTCabCotizacion_Id"
      grOT.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_ImpresionesOT", strWhere)


        With grOT
            If optOTSinValidar.Checked = True Then
                Dim mBoton As New DataGridViewButtonColumn
                mBoton.Name = "btnValidar"
                mBoton.Text = "Validar"
                mBoton.UseColumnTextForButtonValue = True
                mBoton.HeaderText = ""
                .Columns.Add(mBoton)
            End If
            .Columns("OTCabCotizacion_Id").Visible = False

        End With

      strCadena = strCadena & vbCrLf & Now.TimeOfDay.ToString

      Call FormatoGrilla()
      strCadena = strCadena & vbCrLf & Now.TimeOfDay.ToString

      Me.Cursor = Cursors.Default
    'MessageBox.Show(strCadena)

  End Sub

  Private Sub IniciaModoPantalla()
    If mTipoConsola = "VALIDAR" Then
      grpValidar.Left = 19
      btnCargarValidadas.Left = 270
      Me.Text = "Validación OT"
      grpImprimir.Visible = False
      btnCargar.Visible = False

    Else
      grpValidar.Visible = False
      btnCargarValidadas.Visible = False

    End If


  End Sub



Private Sub frmConsolaControl_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Call IniciaModoPantalla()
End Sub
End Class