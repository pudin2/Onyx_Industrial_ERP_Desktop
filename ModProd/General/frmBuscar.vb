Option Explicit On

Imports System.Configuration


Public Class frmBuscar
  Public strConsultaSQL As String, NumFila As Integer, strCamposSQL As String
  Public dtSeleccionado As DataTable, mWhereExterno As String
  Public strVctColsOcultas As String, strConsultaTercero As String, strCampoMiembroTercero As String
  Public strOrderBy As String


  Private Sub chkFechas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFechas.CheckedChanged

    dtpFechaIni.Enabled = chkFechas.Checked : dtpFechaFin.Enabled = chkFechas.Checked
    dtpFechaIni.Focus()
  End Sub

  Private Sub chkTexto_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTexto.CheckedChanged
      txtTexto.Enabled = chkTexto.Checked
      txtTexto.Focus()

  End Sub

  Private Sub chkTercero_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTercero.CheckedChanged
      cmbTercero.Enabled = chkTercero.Checked
      cmbTercero.Focus()
  End Sub

  Private Sub frmBuscar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad, strCadena As String
    'Me.StartPosition = FormStartPosition.CenterScreen

    strCadena = My.Settings.cnnModProd
    obCntv.CadenaDeConeccion = strCadena



    If strConsultaTercero = "" Then
      cmbTercero.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_Clientes", "esactivo=1", "Order by Nombre1")
      cmbTercero.DisplayMember = "NombreCompleto"

    Else
      cmbTercero.DataSource = obCntv.LlenarDataTable(strCadena, "*", strConsultaTercero, "esactivo=1", "Order by Nombre1")
      cmbTercero.DisplayMember = strCampoMiembroTercero

    End If

    obCntv = Nothing

    'anulo la ordenación
    Dim Cc As Integer

    For Cc = 0 To grDet.Columns.Count - 1
      grDet.Columns(Cc).SortMode = DataGridViewColumnSortMode.NotSortable
      grDet.Columns(Cc).HeaderText = grDet.Columns(Cc).HeaderText.ToUpper
    Next







  End Sub


  Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
    Call BuscarEnBD()
  End Sub

Private Sub BuscarEnBD()

    Dim obCntv As New clConectividad, strCadena As String, mWhere As String = ""
    Dim mFormatoFecha As String = My.Settings.FormatoFecha

    If txtDocumento.Text = "" Then
      If chkFechas.Checked = False And chkTercero.Checked = False And chkTexto.Checked = False Then
        MsgBox("Debe seleccionar al menos un criterio de busqueda!", MsgBoxStyle.Exclamation, "No se puede buscar")

        Exit Sub
      Else
        If chkFechas.Checked = True Then
          Dim mF_i As String, mF_f As String

          mF_i = dtpFechaIni.Value.Date.ToString(mFormatoFecha)
          mF_f = dtpFechaFin.Value.Date.ToString(mFormatoFecha)


          mWhere = mWhere & " AND " & dtpFechaIni.Tag & " between '" & mF_i & "' and '" & mF_f & "'"
        End If

        If chkTercero.Checked = True Then
          mWhere = mWhere & " AND " & cmbTercero.Tag & " like '" & cmbTercero.Text & "'"
        End If

        If chkTexto.Checked = True Then
          mWhere = mWhere & " AND " & txtTexto.Tag & " like '" & txtTexto.Text & "'"
        End If

        mWhere = Mid(mWhere, 5)

      End If
    Else

      mWhere = txtDocumento.Tag & " like '" & txtDocumento.Text & "'"

      If chkFechas.Checked = True Then
        Dim mF_i As String, mF_f As String

        mF_i = dtpFechaIni.Value.Date.ToString(mFormatoFecha)
        mF_f = dtpFechaFin.Value.Date.ToString(mFormatoFecha)

        mWhere = mWhere & " AND " & dtpFechaIni.Tag & " between '" & mF_i & "' and '" & mF_f & "'"
      End If

      If chkTercero.Checked = True Then
        mWhere = mWhere & " AND " & cmbTercero.Tag & " like '" & cmbTercero.Text & "'"
      End If

      If chkTexto.Checked = True Then
        mWhere = mWhere & " AND " & txtTexto.Tag & " like '" & txtTexto.Text & "'"
      End If

    End If

    mWhere = mWhere.Replace("*", "%") & " " & mWhereExterno

    strCadena = My.Settings.cnnModProd
    obCntv.CadenaDeConeccion = strCadena

    grDet.DataSource = obCntv.LlenarDataTable(strCadena, strCamposSQL, strConsultaSQL, mWhere, strOrderBy)

    If grDet.Rows.Count > 0 Then
      btnAceptar.Enabled = True

      'anulo la ordenación
      Dim Cc As Integer

      For Cc = 0 To grDet.Columns.Count - 1
        grDet.Columns(Cc).SortMode = DataGridViewColumnSortMode.NotSortable
      Next
    End If


    'PARTE NUEVA PARA OCULTAR COLUMNAS
    If strVctColsOcultas <> "" Then
      Dim VctColsOcultas() As String = Split(strVctColsOcultas, ";")

      For Cc = 0 To VctColsOcultas.Length - 1
        grDet.Columns(VctColsOcultas(Cc).ToString).Visible = False
      Next
    End If

    If grDet.Rows.Count > 0 Then
      grDet.Rows(0).Selected = True
      grDet.Select()
    End If

End Sub

  Private Sub SeleccionaRegistro()
    Dim dtResultado As DataTable
    dtResultado = grDet.DataSource
    dtSeleccionado = dtResultado.Clone

    Dim i As Integer, CantidadSeleccion As Integer

    CantidadSeleccion = grDet.Rows.GetRowCount(DataGridViewElementStates.Selected)
    If CantidadSeleccion > 0 Then
      For i = 0 To CantidadSeleccion - 1
        dtSeleccionado.ImportRow(dtResultado.Rows(grDet.SelectedRows(i).Index.ToString()))
      Next
    End If

    Me.DialogResult = Windows.Forms.DialogResult.OK


  End Sub


  Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
      Call SeleccionaRegistro()
  End Sub


  Private Sub grDet_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDet.CellDoubleClick
    Call SeleccionaRegistro()
  End Sub

  Private Sub txtDocumento_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtDocumento.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call BuscarEnBD()
    End If
  End Sub


  Private Sub grDet_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grDet.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call SeleccionaRegistro()
    End If
  End Sub



End Class