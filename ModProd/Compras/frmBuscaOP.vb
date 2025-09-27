Option Explicit On

'Imports MSSQL = System.Data.SqlClient
Imports System.Configuration

Public Class frmBuscaOP
  Private strCadena As String

  'Public Structure estSalida
  '  Dim Cab_Id As Integer
  '  Dim Det_Id As Integer
  'End Structure

#Region "PROPIEDADES"
  Private mSalida As String, mCab_Id As String, mDet_Id As String = "", mWhere As String, mResponsable_Id As String = ""
  Private mTblDetOCompraSolicitud As DataTable


  Public ReadOnly Property DatosSalida As String
    Get
      Return mSalida
    End Get
  End Property


  Public ReadOnly Property Cab_ID_Retorno As String
    Get
      Return mCab_Id
    End Get
  End Property

  Public ReadOnly Property Det_ID_Retorno As String
    Get
      Return mDet_Id
    End Get
  End Property

  Public Property WhereDeConsulta As String
    Get
      Return mWhere

    End Get
    Set(ByVal value As String)
      mWhere = value
    End Set
  End Property

  Public Property Responsable_ID As String
    Get
      Return mResponsable_Id
    End Get
    Set(ByVal value As String)
      mResponsable_Id = value
    End Set
  End Property

  Public ReadOnly Property TblDetOCompraSolicitud As DataTable
    Get
      Return mTblDetOCompraSolicitud
    End Get

  End Property


#End Region

  Private Sub frmBuscaOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad

    strCadena = My.Settings.cnnModProd
    Call CreateUnboundButtonColumn(grDet, "Tomar", "Tomar", "cmdTomar", grDet.Columns.Count)

    grDet.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_BuscaSC", "Cab_ID like '%'" & mWhere)
    grDet.Columns("Clave").Visible = False

  End Sub

  Private Sub CreateUnboundButtonColumn(ByRef Gr As DataGridView, ByVal Titulo As String, ByVal Texto As String, ByVal Nombre As String, ByVal Posicion As Integer)

    ' Initialize the button column. 
    Dim buttonColumn As New DataGridViewCheckBoxColumn 'DataGridViewButtonColumn
    'Dim bb As New DataGridViewCheckBoxColumn

    With buttonColumn
      .HeaderText = Titulo
      .Name = Nombre
    End With

    ' Add the button column to the control.
    Gr.Columns.Insert(Posicion, buttonColumn)

  End Sub


  'Private Sub grDet_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDet.CellClick
  '  If e.ColumnIndex >= 0 Then

  '    If grDet.Columns(e.ColumnIndex).Name = "cmdTomar" Then
  '      mDet_Id = grDet.Item("ID", e.RowIndex).Value.ToString
  '      'Me.Close()
  '    End If
  '  End If
  'End Sub


  Private Sub grDet_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grDet.CellContentClick

  End Sub

  Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

    Dim Ff As Integer
    Dim obCompras As New clCompras

    For Ff = 0 To grDet.Rows.Count - 1
      If grDet.Item("cmdTomar", Ff).Value = True Then
        Dim NuevaFila = obCompras.TablaTblDetOCompraSolicitud.NewmTblDetOCompraSolicitudRow
        NuevaFila("Sol_Cab_Id") = grDet.Item("Cab_Id", Ff).Value
        NuevaFila("Sol_Det_Id") = grDet.Item("Id", Ff).Value
        NuevaFila("Sol_CodInventario") = grDet("CodInventario", Ff).Value
        NuevaFila("Sol_Inventario_Id") = grDet("Inventario_ID", Ff).Value

        obCompras.TablaTblDetOCompraSolicitud.AddmTblDetOCompraSolicitudRow(NuevaFila)

        mSalida = mSalida & "'" & grDet.Item("Clave", Ff).Value & "',"
      End If
    Next

    mTblDetOCompraSolicitud = obCompras.TablaTblDetOCompraSolicitud
    Me.Close()

  End Sub
End Class