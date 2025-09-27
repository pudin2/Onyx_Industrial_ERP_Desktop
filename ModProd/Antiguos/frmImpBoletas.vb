Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel



Public Class frmImpBoletas
  Private strConexion As String = ""
  Private vctOrdenes(1) As String
  Private vctDocumentos(1) As String

  Private Sub CargarOrdenes()

    Dim obCntv As New clConectividad
    Dim strWhere As String

    If strConexion = "" Then
      strConexion = My.Settings.cnnModProd
    End If

    If optValidadas.Checked = True Then
      strWhere = "Estado='V'"
    Else
      strWhere = "Estado='C'"
    End If

    Dim drVw_ListaOrdenes As MSSQL.SqlDataReader = obCntv.LeerValor("*", "vw_ListaOrdenes", strWhere, strConexion)
    Dim Ff As Integer = 1

    lstOrdenes.Items.Clear()
    Do
      ReDim Preserve vctOrdenes(Ff)
      vctOrdenes(Ff - 1) = drVw_ListaOrdenes.Item("NumeroOrden").ToString
      lstOrdenes.Items.Add(drVw_ListaOrdenes.Item("Nombre").ToString)
      Ff = Ff + 1
    Loop While drVw_ListaOrdenes.Read()

  End Sub


  Private Sub frmImpBoletas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    strConexion = My.Settings.cnnModProd

    Call CargarOrdenes()
  End Sub

  Private Sub optValidadas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optValidadas.CheckedChanged, optCerradas.CheckedChanged
    Call CargarOrdenes()
  End Sub

  Private Sub CargaDocumentos(ByVal NumeroOrden As String)
    Dim obCntv As New clConectividad
    Dim strWhere As String

    If optSalidas.Checked = True Then
      strWhere = "Motivo_ID=2"
    Else
      strWhere = "Motivo_ID=1"
    End If


    If strConexion = "" Then
      strConexion = My.Settings.cnnModProd
    End If


    strWhere = strWhere & " and [Numero Orden]=" & NumeroOrden

    Dim drVw_ConsultaMov As MSSQL.SqlDataReader = obCntv.LeerValor("*", "vw_ConsultaMov", strWhere, strConexion)
    Dim fF As Integer = 1

    lstDocumentos.Items.Clear()

    If drVw_ConsultaMov.HasRows Then

      Do
        ReDim Preserve vctDocumentos(fF)

        vctDocumentos(fF - 1) = drVw_ConsultaMov.Item("CabMov_Id").ToString
        lstDocumentos.Items.Add(drVw_ConsultaMov.Item("Salida al Area").ToString)
        fF = fF + 1
      Loop While drVw_ConsultaMov.Read()
    End If
  End Sub

  Private Sub lstOrdenes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstOrdenes.SelectedIndexChanged
    If lstOrdenes.SelectedIndex > -1 Then
      Call CargaDocumentos(vctOrdenes(lstOrdenes.SelectedIndex.ToString))
      'Else
      '  Call CargaDocumentos(vctOrdenes(0))
    End If

  End Sub

  Private Sub optSalidas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optSalidas.CheckedChanged
    If lstOrdenes.SelectedIndex > -1 Then
      Call CargaDocumentos(vctOrdenes(lstOrdenes.SelectedIndex.ToString))
      'Else
      '  Call CargaDocumentos(vctOrdenes(0))
    End If

  End Sub

  Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    Dim frm As New frmImprimeMov
    Dim strMotivo As String
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
    
    If optSalidas.Checked = True Then
      strMotivo = "2"
    Else
      strMotivo = "1"
    End If

    frm.strCabOrden_ID = vctOrdenes(lstOrdenes.SelectedIndex.ToString)
    frm.strMotivo_ID = strMotivo : frm.strNumero = vctDocumentos(lstDocumentos.SelectedIndex.ToString)

    frm.rptReporte.SetPageSettings(Pg2)
    frm.rptReporte.SetDisplayMode(DisplayMode.PrintLayout)
    frm.rptReporte.RefreshReport()
    frm.Show()


    
  End Sub
End Class