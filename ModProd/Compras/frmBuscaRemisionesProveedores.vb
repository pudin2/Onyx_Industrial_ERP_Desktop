Option Explicit On

Public Class frmBuscaRemisionesProveedores
  Private mStrWhere As String, mStrCampos As String
  Public dtSeleccionado As DataTable

  Public Property sqlWhere As String
  Get
    Return mStrWhere
  End Get
  Set(value As String)
    mStrWhere = value
  End Set
  End Property

  Public Property sqlCampos As String
  Get
    Return mStrCampos
  End Get
  Set(value As String)
    mStrCampos = value
  End Set
  End Property


  Private Sub frmBuscaRemisionesProveedores_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad, strCampos As String, strWhere As String

    strWhere = mStrWhere
    strCampos = mStrCampos

      grIngresos.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_RemisionesProveedoresZiur", strWhere)
      grIngresos.Columns("IdEncabMov").Visible = False
      grIngresos.Columns("Cantidad").DefaultCellStyle.Format = "N2"
      grIngresos.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

     obCntv = Nothing
  End Sub

  Private Sub SeleccionaRegistro()
    Dim dtResultado As DataTable
    dtResultado = grIngresos.DataSource
    dtSeleccionado = dtResultado.Clone

    Dim i As Integer, CantidadSeleccion As Integer

    CantidadSeleccion = grIngresos.Rows.GetRowCount(DataGridViewElementStates.Selected)
    If CantidadSeleccion > 0 Then
      For i = 0 To CantidadSeleccion - 1
        dtSeleccionado.ImportRow(dtResultado.Rows(grIngresos.SelectedRows(i).Index.ToString()))
      Next
    End If

    Me.DialogResult = Windows.Forms.DialogResult.OK


  End Sub


  Private Sub grIngresos_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grIngresos.CellDoubleClick
    Call SeleccionaRegistro()
  End Sub

  Private Sub grIngresos_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles grIngresos.KeyDown
    If e.KeyCode = Keys.Enter Then
      Call SeleccionaRegistro()
    End If
  End Sub




End Class