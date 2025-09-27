Imports System.Configuration
Imports MSSQL = System.Data.SqlClient

Public Class frmEntregarResumen

Private strCadena As String
  Private mCabMov_Id As String, strMotivo_Id As String

Private Sub frmEntregarResumen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  Dim obCntv As New clConectividad


  strCadena = ConfigurationManager.ConnectionStrings("ModProd.My.MySettings.cnnModProd").ConnectionString

  obCntv.CadenaDeConeccion = strCadena

    cmbEntregas.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_EntregasDeArea", "estado = 'A' order by cs_numero")
  cmbEntregas.DisplayMember = "CS_Numero" '"Salida_CabMov_Id"


    cmbMotivos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "Motivos", "estado='A' and Motivo_Id_Relacionado=2")
    cmbMotivos.DisplayMember = "Descripcion"
    'cmbProductos.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    'cmbProductos.DisplayMember = "Descripcion"

  obCntv = Nothing
End Sub


Private Sub cmbEntregas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEntregas.SelectedIndexChanged
  Dim obCntv As New clConectividad

  Dim strConsulta As String

  Dim selectedItem As DataRowView
    selectedItem = cmbEntregas.SelectedItem

    Dim CabMov_ID = selectedItem("Salida_CabMov_ID").ToString()

  strConsulta = "select * from CabMov C" _
    & " join VW_Sedes_Plantas_Areas A on a.Area_ID = c.Area_ID " _
    & " where c.Id =" & CabMov_ID.ToString

  Dim drConsulta As MSSQL.SqlDataReader = obCntv.EjecutaComando(strConsulta, strCadena, True)

  drConsulta.Read()
  lblSede.Text = drConsulta.Item("Sede").ToString
  lblPlanta.Text = drConsulta.Item("Planta").ToString
  lblArea.Text = drConsulta.Item("Area").ToString
  mCabMov_Id = CabMov_ID.ToString


    

    grDetalle.DataSource = obCntv.LlenarDataTable(strCadena, "CodInventario, Descripcion, Cantidad, NomUnidad, [Usado por Area], [Usado?], [Producto_ID], [Unidad_ID]", _
      "vw_SalidasAlArea", "CabMov_id=" & mCabMov_Id)

    Dim MyEstilo As New DataGridViewCellStyle

    'MyEstilo.BackColor = Color.Silver
    MyEstilo.BackColor = Color.Cyan


    grDetalle.Columns(0).ReadOnly = True : grDetalle.Columns(0).DefaultCellStyle = MyEstilo
    grDetalle.Columns(1).ReadOnly = True : grDetalle.Columns(1).DefaultCellStyle = MyEstilo
    grDetalle.Columns(2).ReadOnly = True : grDetalle.Columns(2).DefaultCellStyle = MyEstilo
    grDetalle.Columns(3).ReadOnly = True : grDetalle.Columns(3).DefaultCellStyle = MyEstilo
    grDetalle.Columns(6).Visible = False : grDetalle.Columns(7).Visible = False
    grDetalle.Columns(1).Width = 250


  obCntv = Nothing


End Sub


Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    'If txtCantidad.Text <> "" Then

    Dim obMov As New clMovimiento
    Dim obCntv As New clConectividad
    Dim blnSeleccionado As Boolean = False
    Dim Ff As Integer

    Dim selectedItem As DataRowView
    selectedItem = cmbProductos.SelectedItem

    'Dim CabMov_ID = selectedItem("Salida_CabMov_ID").ToString()

    For Ff = 0 To grDetalle.Rows.Count - 1
      If grDetalle.Item(5, Ff).Value = True Then
        Dim NuevaFila = obMov.DetMovimiento.NewDetMovRow()

        NuevaFila("CabMov_ID") = 0
        NuevaFila("id") = Ff + 1
        NuevaFila("Producto_ID") = CInt(grDetalle.Item(6, Ff).Value) '  .Rows(Ff).Cells(4).ToString
        NuevaFila("Cantidad") = grDetalle.Item(4, Ff).Value
        NuevaFila("Unidad_ID") = grDetalle.Item(7, Ff).Value


        obMov.DetMovimiento.AddDetMovRow(NuevaFila)
        blnSeleccionado = True
      End If
    Next

    Dim NuevoMov = obCntv.LeerValorSencillo("isnull(MAX(numero),0)+1 [Maximo]", "Maximo", "CabMov", "Motivo_ID = 3", strCadena)
    Dim CabOrden_Id = obCntv.LeerValorSencillo("CabOrden_Id", "CabMov", "id=" & mCabMov_Id, strCadena)
    obMov.GrabarMovimiento(strCadena, strMotivo_Id, NuevoMov, 1, dtpFecha.Value, "A", txtObservacion.Text, CabOrden_Id)

    Dim strMsg As String = "Datos guardados correctamente!" & vbCrLf & "Se generó la nota de entrada: " & NuevoMov
    MessageBox.Show(strMsg, "Guardado...", MessageBoxButtons.OK, MessageBoxIcon.Information)

    'End If
End Sub

Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
    Dim Frm As New frmMov

    Frm.strMotivo_ID = "3,5,6"
    Frm.Show()


  End Sub
  Private Sub grDetalle_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles grDetalle.DataError
    MessageBox.Show(e.Exception.Message, "Se ha presentado un error", MessageBoxButtons.OK, MessageBoxIcon.Error)
  End Sub

  Private Sub cmbMotivos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMotivos.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbMotivos.SelectedItem

    strMotivo_Id = selectedItem("ID").ToString()

  End Sub
End Class