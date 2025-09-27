Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO

Public Class frmMntMPNoCreada
  Private strCadena As String
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Private mNumCotiza As Integer = 0
  Private dtCotizacion As Data.DataTable
  Private mIdNumeroCotizacionRapida As String


  Private mGuid As String = ""
  Private mVctAnexos As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private mTblCheckList As DataTable

    Private Sub frmMntMPNoCreada_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
    End Sub






  Private Sub frmMntMPNoCreada_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad
    strCadena = My.Settings.cnnModProd
    dtCotizacion = obCntv.LlenarDataTable(strCadena, "distinct NumCotizacion , cab_id", "VW_MaterialesNoCreados", "0=0  order by NumCotizacion desc")
    cmbCotizacion.DataSource = dtCotizacion  'obCntv.LlenarDataTable(strCadena, "*", "vw_ProductosTerminadosOEnProceso", "id>0")
    cmbCotizacion.DisplayMember = "NumCotizacion"
    mIdNumeroCotizacionRapida = My.Settings.IDNumeroCotizacionRapida

  End Sub


  Private Sub CargarMateriales(ByVal strNumCotizacion As String)
    Dim obCntv As New clConectividad

    Dim dtMateriales As DataTable
    dtMateriales = obCntv.LlenarDataTable(strCadena, "id, CodInventario, '' [Nuevo Código], '' [Nueva Descripción]", "VW_MaterialesNoCreados", "Numcotizacion = '" & strNumCotizacion & "'")

    grProductos.DataSource = dtMateriales

  End Sub

  Private Sub ValidaMaterial(ByVal strCodInventario As String, ByVal Ff As Integer)
    Dim obCntv As New clConectividad

    Dim mProducto As String = ""
    Dim strWhere As String = "codinventario ='" & strCodInventario & "'"

    mProducto = obCntv.LeerValorSencillo("NombreZiur", "vw_ProductosZiurMP", strWhere, strCadena)

    If mProducto <> "" Then
      grProductos.Rows(Ff).Cells(3).Value = mProducto
      grProductos.Rows(Ff).Cells(2).Value = UCase(grProductos.Rows(Ff).Cells(2).Value)
    Else
      MessageBox.Show("Código no existe!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
      grProductos.Rows(Ff).Cells(2).Value = "" : grProductos.Rows(Ff).Cells(3).Value = ""
    End If


  End Sub


  Private Sub cmbCotizacion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCotizacion.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbCotizacion.SelectedItem

    'drValor = objCntv.EjecutaComando("exec pa_BuscaCostoMP '" & selectedItem("CodInventario").ToString & "',1", strCadena, True)
    Call CargarMateriales(selectedItem("NumCotizacion").ToString)

  End Sub

  
  Private Sub brnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnGrabar.Click
    Dim Ff As Integer, strUpdate As String, obCntv As New clConectividad

    For Ff = 0 To grProductos.RowCount - 1

      If grProductos.Rows(Ff).Cells(2).Value.ToString <> "" Then
        strUpdate = "update detcotizacion set inventario_id='" & grProductos.Rows(Ff).Cells(2).Value.ToString & "'" _
          & " where id=" & grProductos.Rows(Ff).Cells(0).Value.ToString

        obCntv.EjecutaComando(strUpdate, strCadena, False)

      End If


    Next Ff

    MessageBox.Show("Datos actualizados con éxito", "Actualización", MessageBoxButtons.OK)

  End Sub


  Private Sub grProductos_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellEndEdit

    Dim mGr As DataGridView = CType(sender, DataGridView)

    Call ValidaMaterial(mGr.Rows(e.RowIndex).Cells(2).Value, e.RowIndex)

  End Sub

  Private Sub grProductos_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grProductos.CellContentClick

  End Sub
End Class