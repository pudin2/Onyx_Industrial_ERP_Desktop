Imports MSSQL = System.Data.SqlClient
Imports System.Configuration

Public Class frmCrearPT
  Public mNumCotizacion As Integer = 0
  Private strCadena As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal


  Private Sub CargaCotizacion(ByVal strCotizacion As String)
    Dim obCntv As New clConectividad, strComando As String, strCab_Id As String

    grProductos.Rows.Clear()

    'strComando = "select id from CabCotizacion where NumCotizacion = '" & strCotizacion.ToString & "'"
    strCab_Id = obCntv.LeerValorSencillo("id", "CabCotizacion", "NumCotizacion= '" & strCotizacion.ToString & "' AND TIPO IN ('CN','CR')", strCadena)

    If strCab_Id = "" Then
      MessageBox.Show("Número de Cotización no encontrado!", "Buscar Cotización", MessageBoxButtons.OK, MessageBoxIcon.Error)
      'txtNumCotizacion.SelectAll() : txtNumCotizacion.Focus()
      Exit Sub
    End If

    strComando = "pa_RPT_ConsulaCotizacion " & strCab_Id.ToString

    Dim drConsulta As SqlClient.SqlDataReader = _
      obCntv.EjecutaComando(strComando, strCadena, True)

    drConsulta.Read()
    If drConsulta.HasRows = True Then



      lblCliente.Text = drConsulta.Item("NombreCliente").ToString
      txtAlcance.Text = drConsulta.Item("Alcance").ToString
      txtProyecto.Text = drConsulta.Item("NombreProyecto").ToString
      txtNombrePT.Text = drConsulta.Item("NombreProyecto").ToString
      txtObservaciones.Text = drConsulta.Item("Observacion").ToString
      txtObsInterna.Text = drConsulta.Item("ObsInterna").ToString
      'mNumCotiza = drConsulta.Item("NumCotizacion").ToString
      lblNumCotizacion.Text = drConsulta.Item("NumCotizacion").ToString
      txtCodInventario.Text = "PT" & strCotizacion.ToString

      Dim strFila() As String
      Do
        If drConsulta.Item("CodTipo") <> 4 Then

          strFila = {drConsulta.Item("CodInventario").ToString, _
                        CDec(drConsulta.Item("Cant").ToString()).ToString(FCANT), _
                        CDec(drConsulta.Item("Costo").ToString()).ToString(FCTO_U), _
                        CDec(drConsulta.Item("Total").ToString()).ToString(FCTOTOT)}

          grProductos.Rows.Add(strFila)
        End If
      Loop While drConsulta.Read()
    End If
  End Sub

  Private Sub frmCrearPT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    strCadena = My.Settings.cnnModProd
    Call CargaCotizacion(mNumCotizacion)
  End Sub

  Private Sub btnCrearPT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCrearPT.Click
    Dim obCntv As New clConectividad
    Dim strInstruccion As String

    Dim intResultado As Integer = obCntv.LeerValorSencillo("COUNT(1) [Cantidad]", "Cantidad", "PTporCotizacion", "CodInventario = '" & txtCodInventario.Text.ToString & "'", strCadena)

    If intResultado > 0 Then
      MessageBox.Show("El código de PT ya existe en Ziur!" & vbCrLf & vbCrLf & "Debe indicar un código de producto diferente.", "Código ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    If MessageBox.Show("Desea crear el producto ahora?", "Crear PT Ziur", MessageBoxButtons.YesNo, MessageBoxIcon.None) = Windows.Forms.DialogResult.Yes Then
      strInstruccion = "EXEC PA_CrearPT_Ziur '" & mNumCotizacion.ToString & "', '" & txtCodInventario.Text.ToString _
          & "','" & txtNombrePT.Text.ToString & "'"

      obCntv.EjecutaComando(strInstruccion, strCadena, False)

      MessageBox.Show("Producto creado con éxito", "Producto PT", MessageBoxButtons.OK, MessageBoxIcon.Information)

      Me.Close()
    End If
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click


    Dim frm As New frmRptMaterialesNoCreados
    frm.strCotizacion = lblNumCotizacion.Text
    'frm.rptReporte.ServerReport.ReportPath = "/produccion/07_ConsultaMaterialesNoCreados"
    'frm.rptReporte.ServerReport.ReportPath = "/produccion/05_ImprimeCotizacion"
    'frm.rptReporte.RefreshReport()

    'frm.Text = Me.Text
    frm.Show()




  End Sub
End Class