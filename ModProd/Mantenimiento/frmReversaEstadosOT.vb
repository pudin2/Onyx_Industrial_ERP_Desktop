Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel



Public Class frmReversaEstadosOT

  Private strCadena As String
  Private dtCotizaciones As Data.DataTable
  Private dtNuevoEstadosCot As Data.DataTable
  Public mUsuario_Id As Integer
  Private mNumOrden As Integer


  Private Sub frmCambiaEstadosCot_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
    Dim mBoton As Button = Me.Tag
    Try
      frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
    Catch ex As System.NullReferenceException
      'no hago nada
    End Try

  End Sub

  Private Sub frmCambiaEstadosCot_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Dim obCntv As New clConectividad

    strCadena = My.Settings.cnnModProd
    obCntv.CadenaDeConeccion = strCadena

    dtCotizaciones = obCntv.LlenarDataTable(strCadena, "NumOrden", "CabOT", "NumOrden >= (select valor from Parametros where id=34)")
    cmbOT.DataSource = dtCotizaciones
    cmbOT.DisplayMember = "NumOrden"

    Me.Text = "Estados OT"
    Me.Icon = My.Resources.IconoFrm
    'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
    If Me.Tag IsNot Nothing Then
      Me.Tag.TEXT = Me.Text
    End If
    cmbOT.Focus()



  End Sub

  Private Sub cmbCot_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbOT.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbOT.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")

    ElseIf e.KeyCode = Keys.Enter Then
      Call BuscarItem(cmbOT.Text)

    End If
  End Sub

  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbOT.BackColor
        cmbOT.BackColor = Color.Yellow
        cmbOT.Text = strMensaje  '"Buscando ..."
        cmbOT.Refresh()


        Dim dtFiltrado As Data.DataTable


        If bolAvanzada = False Then
          dtFiltrado = dtCotizaciones.Clone
          strFiltro = "NumCotizacion = " & strFiltro
          Dim result() As DataRow = dtCotizaciones.Select(strFiltro)

          For Each row As DataRow In result
            dtFiltrado.Rows.Add(row(0))
            mCnt = mCnt + 1
          Next

          If mCnt = 0 Then
              MessageBox.Show("Criterio no encontrado!", "Busqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
              Call BuscarItem("%", "Actualizando ...")
          End If
        End If

        cmbOT.DataSource = dtFiltrado
        cmbOT.DisplayMember = "Descripcion"

        cmbOT.BackColor = mColor
        cmbOT.Refresh()

    End Sub

Private Sub CargarCotizacion(ByVal mOTCabCotizacion_Id As String)
  Try

      'Dim Cotiza As Integer = mNumCotizacion
            Dim objCntv As New clConectividad 'fF As Integer
      Dim strConsulta As String = "Select "

      'CARGA LA CABECERA
      Dim drCabCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "CabCotizacion", "Id =" & mOTCabCotizacion_Id, strCadena)

      lblNombreCliente.Text = drCabCotiza.Item("NombreCliente").ToString

      txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
      txtAlcance.Text = drCabCotiza.Item("Alcance").ToString
      txtObservacion.Text = drCabCotiza.Item("Observacion").ToString
      lblNombreAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString


      'LOS ESTADOS DE LA ORDEN
      Dim drEstadosCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "vw_EstadosCotizacion", "Id =" & mOTCabCotizacion_Id & " order by id", strCadena)

      'SE LIMPIAN TODOS LOS ESTADOS
            Dim jj As Integer 'mMaxEstado As Integer,
      For jj = 0 To 5
          chkListEstados.SetItemCheckState(jj, CheckState.Unchecked)
      Next

      'CHEQUEO LOS ESTADOS QUE SE HAN CUMPLIDO
      'Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
      '    chkListEstados.SetItemChecked(drEstadosCotiza("id") - 1, True)
      '    'cmbNuevoEstado.Items.Add(drEstadosCotiza("Nombre"))
      '    mMaxEstado = IIf(drEstadosCotiza("id") > mMaxEstado, drEstadosCotiza("id"), mMaxEstado)
      '    fF = fF + 1
      'Loop While drEstadosCotiza.Read()


      Dim drEstadosOT As MSSQL.SqlDataReader, mEstadoActual As String
      drEstadosOT = objCntv.LeerValor("*", "Vw_EstadosOT", "NumOrden=" & mNumOrden, My.Settings.cnnModProd)

    Do
        mEstadoActual = drEstadosOT.Item("EstadoActual").ToString
        'mTipoOT = drEstadosOT.Item("Tipo").ToString 'para controlar si son venta directa o normal
        If drEstadosOT.Item("EstadoEtapa") = "T" Then
            chkListEstados.SetItemCheckState(drEstadosOT.Item("ID").ToString - 7, CheckState.Checked)
        End If
    Loop While drEstadosOT.Read()








      'ONYX - LOS NUEVOS POSIBLES ESTADOS DE LA COTIZACION
      dtNuevoEstadosCot = objCntv.LlenarDataTable(strCadena, True, "pa_CargaCmbEstadosCot", mOTCabCotizacion_Id, "NuevoEstadosCot")
      cmbNuevoEstado.DataSource = dtNuevoEstadosCot
      cmbNuevoEstado.DisplayMember = "Titulo"

      cmbOT.Focus()

  Catch ex As System.InvalidCastException

  Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  End Try
    End Sub




Private Sub cmbCot_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbOT.SelectedIndexChanged
  Dim strOTCabCotizacion_Id As String, selectedItem As DataRowView, obCntv As New clConectividad
  selectedItem = cmbOT.SelectedItem

  mNumOrden = selectedItem("NumOrden").ToString
  strOTCabCotizacion_Id = obCntv.LeerValorSencillo("OTCabCotizacion_Id", "CabOT", "NumOrden=" & mNumOrden.ToString, My.Settings.cnnModProd)


  Call CargarCotizacion(strOTCabCotizacion_Id)
  obCntv = Nothing

End Sub

  Private Sub btnCabiarEstado_Click(sender As System.Object, e As System.EventArgs) Handles btnCabiarEstado.Click

    Dim objCntv As New clConectividad

    Dim strNumCot As String, selectedItem As DataRowView, strIdNuevoEstado As String
    selectedItem = cmbOT.SelectedItem
    strNumCot = selectedItem("NumCotizacion").ToString

    selectedItem = cmbNuevoEstado.SelectedItem
    strIdNuevoEstado = selectedItem("Id").ToString

    Try
      Dim strComando As String
      strComando = "EXEC pa_CambiaEstadoCot '" & strNumCot & "'," & strIdNuevoEstado & "," & mUsuario_Id & ""
      objCntv.EjecutaComando(strComando, strCadena, False)

      MessageBox.Show("Cotización Actualizada", "Cotización", MessageBoxButtons.OK)

    Catch ex As Exception
      MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Try


  End Sub
End Class