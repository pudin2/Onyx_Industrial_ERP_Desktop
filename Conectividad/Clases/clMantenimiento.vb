Imports MSSQL = System.Data.SqlClient
Public Class clMantenimiento

  Private mTablaCostos As New dsMantenimiento.CostosMPDataTable

  Public Property TablaCostos As dsMantenimiento.CostosMPDataTable
    Get
      Return mTablaCostos
    End Get
    Set(ByVal value As dsMantenimiento.CostosMPDataTable)
      mTablaCostos = value
    End Set
  End Property


  Public Sub GrabarCosto(ByVal strConexion As String, ByVal Inventario_ID As String, ByVal Unidad_Id As String, ByVal Costo As Decimal, ByVal Estado As String)
    Dim dsMantenimientoAdp As New dsMantenimientoTableAdapters.CostosMPTableAdapter
    dsMantenimientoAdp.Connection.ConnectionString = strConexion

    Try
      dsMantenimientoAdp.Insert(Inventario_ID, Unidad_Id, Costo, Estado)
    Catch ex As MSSQL.SqlException
      If ex.Number = 2601 Then 'Error de unique index
        Dim strComando As String, obCntv As New clConectividad

        strComando = "update CostosMP set costo=" & Costo & ", Estado='" & Estado & "' where inventario_id='" & Inventario_ID & "'"
        obCntv.EjecutaComando(strComando, strConexion, False)

        obCntv = Nothing
      End If

    End Try
  End Sub


  Public Sub GrabarCosto(ByVal strConexion As String, ByVal CodInventario As String, ByVal Costo As Decimal)
    Dim obCntv As New clConectividad
    Dim strCadena As String

    strCadena = "EXEC pa_MtoCostosMP '" & CodInventario & "'," & Costo
    obCntv.EjecutaComando(strCadena, strConexion, False)
  End Sub


End Class
