Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel



Public Class frmCambiaEstadosCot
  Private strCadena As String
  Private dtCotizaciones As Data.DataTable
  Private dtNuevoEstadosCot As Data.DataTable
  Public mUsuario_Id As Integer

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

    dtCotizaciones = obCntv.LlenarDataTable(strCadena, "NumCotizacion", "CabCotizacion", "NumCotizacion >= (select valor from Parametros where id=14)")
    cmbCot.DataSource = dtCotizaciones
    cmbCot.DisplayMember = "NumCotizacion"

    Me.Text = "Estados Cotización"
    Me.Icon = My.Resources.IconoFrm
    'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
    If Me.Tag IsNot Nothing Then
      Me.Tag.TEXT = Me.Text
    End If
    cmbCot.Focus()


    
  End Sub

  Private Sub cmbCot_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles cmbCot.KeyDown
    If e.KeyCode = Keys.F3 Then
      Call BuscarItem(cmbCot.Text)
    ElseIf e.KeyCode = Keys.F9 Then
      Call BuscarItem("%")

    ElseIf e.KeyCode = Keys.Enter Then
      Call BuscarItem(cmbCot.Text)

    End If
  End Sub

  Private Sub BuscarItem(ByVal strFiltro As String, Optional ByVal strMensaje As String = "Buscando ...", Optional bolAvanzada As Boolean = 0)
        Dim mCnt As Integer = 0
        Dim mColor As Color = cmbCot.BackColor
        cmbCot.BackColor = Color.Yellow
        cmbCot.Text = strMensaje  '"Buscando ..."
        cmbCot.Refresh()


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

        cmbCot.DataSource = dtFiltrado
        cmbCot.DisplayMember = "Descripcion"

        cmbCot.BackColor = mColor
        cmbCot.Refresh()

    End Sub

Private Sub CargarCotizacion(ByVal mNumCotizacion As String)
  Try

      'Dim Cotiza As Integer = mNumCotizacion
      Dim objCntv As New clConectividad, fF As Integer
      Dim strConsulta As String = "Select "

      'CARGA LA CABECERA
      Dim drCabCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "CabCotizacion", "NumCotizacion =" & mNumCotizacion, strCadena)

      lblNombreCliente.Text = drCabCotiza.Item("NombreCliente").ToString

      txtProyecto.Text = drCabCotiza.Item("NombreProyecto").ToString
      txtAlcance.Text = drCabCotiza.Item("Alcance").ToString
      txtObservacion.Text = drCabCotiza.Item("Observacion").ToString
      lblNombreAsignadaA.Text = drCabCotiza.Item("AsignadoA").ToString


      'LOS ESTADOS DE LA ORDEN
      Dim drEstadosCotiza As MSSQL.SqlDataReader = _
        objCntv.LeerValor("*", "vw_EstadosCotizacion", "NumCotizacion =" & mNumCotizacion & " order by id", strCadena)

      Dim mMaxEstado As Integer, jj As Integer
      For jj = 0 To 5
          chkListEstados.SetItemCheckState(jj, CheckState.Unchecked)
      Next



      Do 'el while va al final porque la funcion leervalor ya hace la lectura del primer registro
          chkListEstados.SetItemChecked(drEstadosCotiza("id") - 1, True)
          'cmbNuevoEstado.Items.Add(drEstadosCotiza("Nombre"))
          mMaxEstado = IIf(drEstadosCotiza("id") > mMaxEstado, drEstadosCotiza("id"), mMaxEstado)
          fF = fF + 1
      Loop While drEstadosCotiza.Read()

      'ONYX - LOS NUEVOS POSIBLES ESTADOS DE LA COTIZACION
      dtNuevoEstadosCot = objCntv.LlenarDataTable(strCadena, True, "pa_CargaCmbEstadosCot", mNumCotizacion, "NuevoEstadosCot")
      cmbNuevoEstado.DataSource = dtNuevoEstadosCot
      cmbNuevoEstado.DisplayMember = "Titulo"

      cmbCot.Focus()

  Catch ex As System.InvalidCastException

  Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  End Try
    End Sub




Private Sub cmbCot_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCot.SelectedIndexChanged
  Dim strNumCot As String, selectedItem As DataRowView
  selectedItem = cmbCot.SelectedItem
  strNumCot = selectedItem("NumCotizacion").ToString

  Call CargarCotizacion(strNumCot)
  'End If
End Sub

  Private Sub btnCabiarEstado_Click(sender As System.Object, e As System.EventArgs) Handles btnCabiarEstado.Click

    Dim objCntv As New clConectividad

    Dim strNumCot As String, selectedItem As DataRowView, strIdNuevoEstado As String
    selectedItem = cmbCot.SelectedItem
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