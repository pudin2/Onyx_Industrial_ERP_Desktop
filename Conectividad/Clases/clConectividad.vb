Imports MSSQL = System.Data.SqlClient

Public Class clConectividad
  Private mCadenaConeccion As String = ""
  Private Cn As MSSQL.SqlConnection

#Region "PROPIEDADES"
  Public Property CadenaDeConeccion() As String
    Get
      CadenaDeConeccion = mCadenaConeccion
    End Get
    Set(ByVal value As String)
      mCadenaConeccion = value
    End Set
  End Property
#End Region




#Region "FORMAS DE CONEXION"

  Friend Function Conectar() As MSSQL.SqlConnection
    Dim cnLocal As MSSQL.SqlConnection

    If mCadenaConeccion = "" Then
      MsgBox("No se ha especificado una cadena de conexión!", MsgBoxStyle.Critical)
      Conectar = Nothing
    Else
      cnLocal = New MSSQL.SqlConnection(mCadenaConeccion)
      cnLocal.Open()
      Conectar = cnLocal : cnLocal.Close() : cnLocal = Nothing
    End If
  End Function


  Friend Function Conectar(ByVal Cadena As String) As MSSQL.SqlConnection
    Dim cnLocal As MSSQL.SqlConnection

    If Cadena = "" Then
      MsgBox("No se ha especificado una cadena de conexión!", MsgBoxStyle.Critical)
      Conectar = Nothing
    Else
      cnLocal = New MSSQL.SqlConnection(Cadena)
      cnLocal.Open()
      Conectar = cnLocal : cnLocal.Close() : cnLocal = Nothing
    End If
  End Function

#End Region




  Public Function LeerValor(ByVal Campos As String, ByVal Tabla As String, ByVal Where As String, ByVal strConexion As String) As MSSQL.SqlDataReader
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    LeerValor = Nothing

    cmLocal.CommandText = "select " & Campos & " from " & Tabla & " where " & Where
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    LeerValor = cmLocal.ExecuteReader


    Try
      LeerValor.Read()
    Catch ex As Exception
      MsgBox("Se ha presentado el siguiente error en LeenValor. Tabla: " & Tabla & ", Where: " _
        & Where & ", strConexion: " & strConexion.ToString & vbCrLf & ex.Message)
    End Try



  End Function

  Friend Function LeerValor(ByVal Campos As String, ByVal Tabla As String, ByVal Where As String, _
                            ByVal trTran As MSSQL.SqlTransaction, Optional ByVal strConexion As String = "", _
                            Optional ByVal Avanzar As Boolean = True) As MSSQL.SqlDataReader
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    cmLocal.CommandText = "select " & Campos & " from " & Tabla & " where " & Where
    cmLocal.CommandType = CommandType.Text
    Try
      cmLocal.Connection = trTran.Connection  'cnConexion
    Catch ex As NullReferenceException
      cmLocal.Connection = Conectar(strConexion)
      cmLocal.Connection.Open()
    End Try

    Try
      cmLocal.Transaction = trTran
    Catch ex As NullReferenceException
      'Ignoro este error
      'MsgBox(ex.Message)
    End Try
    'cmLocal.Connection.Open()

    LeerValor = cmLocal.ExecuteReader
    If Avanzar = True Then
      LeerValor.Read()
    End If
  End Function


  Public Sub InsertarValor(ByVal Valores As String, ByVal Tabla As String, ByVal strConexion As String)
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    cmLocal.CommandText = "Insert " & Tabla & " Values (" & Valores & ")"
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    cmLocal.ExecuteNonQuery() : cmLocal.Connection.Close()
    cmLocal = Nothing


  End Sub

  Public Sub InsertarValor(ByVal Campos As String, ByVal Valores As String, ByVal Tabla As String, ByVal strConexion As String)
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    cmLocal.CommandText = "Insert " & Tabla & "(" & Campos & ") Values (" & Valores & ")"
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    cmLocal.ExecuteNonQuery() : cmLocal.Connection.Close()
    cmLocal = Nothing


  End Sub




  Public Sub ActualizaValor(ByVal Campos As String, ByVal Tabla As String, ByVal Where As String, ByVal strConexion As String)
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    cmLocal.CommandText = "update " & Tabla & " Set " & Campos & " from " & Tabla & " where " & Where
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    cmLocal.ExecuteNonQuery() : cmLocal.Connection.Close()
    cmLocal = Nothing


  End Sub

  Friend Sub ActualizaValor(ByVal Campos As String, ByVal Tabla As String, ByVal Where As String, _
    ByRef cnConexion As MSSQL.SqlConnection, ByRef trTran As MSSQL.SqlTransaction)

    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    If cnConexion.State = ConnectionState.Closed Then cnConexion.Open()

    cmLocal.CommandText = "update " & Tabla & " Set " & Campos & " from " & Tabla & " where " & Where
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = cnConexion
    cmLocal.Transaction = trTran
    'cmLocal.Connection.Open()

    cmLocal.ExecuteNonQuery() ': cmLocal.Connection.Close()
    cmLocal = Nothing




  End Sub

  Public Function BuscaFilaEnDataTable(ByVal Tabla As DataTable, ByVal Campo As String, ByVal Valor As String) As Integer
    Dim Rr As Integer = 0

    For Rr = 0 To Tabla.Rows.Count - 1
      If Trim(Tabla.Rows(Rr).Item(Campo).ToString) = Valor Then
        BuscaFilaEnDataTable = Rr
        Exit For

      End If

    Next
  End Function


  Friend Sub EliminaValor(ByVal Tabla As String, ByVal Where As String, ByVal strConexion As String)
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader

    cmLocal.CommandText = "delete from " & Tabla & " where " & Where
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    cmLocal.ExecuteNonQuery() : cmLocal.Connection.Close()
    cmLocal = Nothing


  End Sub

  Public Function EjecutaComando(ByVal Texto As String, ByVal strConexion As String, ByVal Retorno As Boolean) As MSSQL.SqlDataReader
    Dim cmLocal As New MSSQL.SqlCommand ' drLocal As MSSQL.SqlDataReader
    EjecutaComando = Nothing
    cmLocal.CommandText = Texto
    cmLocal.CommandType = CommandType.Text : cmLocal.Connection = Conectar(strConexion)
    cmLocal.Connection.Open()

    If Retorno = True Then
      EjecutaComando = cmLocal.ExecuteReader

    Else
      cmLocal.ExecuteNonQuery()
      cmLocal.Connection.Close()
      cmLocal = Nothing
    End If

    

  End Function


#Region "CREAR COMANDOS"

  Public Function CrearComandoInsGeneral(ByVal strTabla As String, ByVal strConexion As String) As MSSQL.SqlCommand
    Dim adLocal As MSSQL.SqlDataAdapter
    adLocal = New MSSQL.SqlDataAdapter("select * from " & strTabla, strConexion)
    Dim cbLocal As New MSSQL.SqlCommandBuilder(adLocal)
    Dim cmLocal As MSSQL.SqlCommand
    cmLocal = cbLocal.GetInsertCommand(True)

    CrearComandoInsGeneral = cmLocal

  End Function


  Public Function CrearComandoUpdGeneral(ByVal strTabla As String, ByVal strConexion As String) As MSSQL.SqlCommand
    Dim adLocal As MSSQL.SqlDataAdapter
    adLocal = New MSSQL.SqlDataAdapter("select * from " & strTabla, strConexion)
    Dim cbLocal As New MSSQL.SqlCommandBuilder(adLocal)
    Dim cmLocal As MSSQL.SqlCommand = Nothing

    Try
      cmLocal = cbLocal.GetUpdateCommand(True)
    Catch ex As Exception
    End Try
    CrearComandoUpdGeneral = cmLocal

  End Function

  Public Function CrearComandoDelGeneral(ByVal strTabla As String, ByVal strConexion As String) As MSSQL.SqlCommand
    Dim adLocal As MSSQL.SqlDataAdapter
    adLocal = New MSSQL.SqlDataAdapter("select * from " & strTabla, strConexion)
    Dim cbLocal As New MSSQL.SqlCommandBuilder(adLocal)
    Dim cmLocal As MSSQL.SqlCommand
    cmLocal = cbLocal.GetDeleteCommand(True)

    CrearComandoDelGeneral = cmLocal

  End Function


  Public Function LlenarDataTable(ByVal CadenaConeccion As String, _
    ByVal Campos As String, ByVal Tabla As String, ByVal Where As String) As Data.DataTable
    'Dim Cn As New MSSql.SqlConnection
    Dim InstruccionSql As String

    'Cn.ConnectionString = CadenaConeccion
    'Cn.Open()

    InstruccionSql = "select " & Campos & " from " & Tabla & " where " & Where
    Dim Da As New MSSQL.SqlDataAdapter(InstruccionSql, CadenaConeccion)
    Dim Ds As New Data.DataSet
        Da.Fill(Ds, Tabla)
    LlenarDataTable = Ds.Tables(Tabla)
  End Function


  Public Function LlenarDataTable(ByVal CadenaConeccion As String, _
    ByVal ParametrosStore As String, ByVal NombreTabla As String) As Data.DataTable
    'Dim Cn As New MSSql.SqlConnection
    Dim InstruccionSql As String

    'Cn.ConnectionString = CadenaConeccion
    'Cn.Open()

    InstruccionSql = "exec prBuscaArticulos " & ParametrosStore
    Dim Da As New MSSQL.SqlDataAdapter(InstruccionSql, CadenaConeccion)
    Dim Ds As New Data.DataSet
    Da.Fill(Ds, NombreTabla)
    LlenarDataTable = Ds.Tables(NombreTabla)
  End Function

  Public Function LlenarDataTable(ByVal CadenaConeccion As String, _
   ByVal Campos As String, ByVal Tabla As String, ByVal Where As String, ByVal Order As String) As Data.DataTable
    'Dim Cn As New MSSql.SqlConnection
    Dim InstruccionSql As String

    'Cn.ConnectionString = CadenaConeccion
    'Cn.Open()

    InstruccionSql = "select " & Campos & " from " & Tabla & " where " & Where & " " & Order
    Dim Da As New MSSQL.SqlDataAdapter(InstruccionSql, CadenaConeccion)
    Dim Ds As New Data.DataSet
    Da.Fill(Ds, Tabla)
    LlenarDataTable = Ds.Tables(Tabla)
  End Function


  Public Function LlenarDataTable(ByVal CadenaConeccion As String, ByVal Avanzado As Boolean, _
  ByVal Store As String, ByVal ParametrosStore As String, ByVal NombreTabla As String) As Data.DataTable
    'Dim Cn As New MSSql.SqlConnection
    Dim InstruccionSql As String

    'Cn.ConnectionString = CadenaConeccion
    'Cn.Open()

    InstruccionSql = "exec " & Store & " " & ParametrosStore
    Dim Da As New MSSQL.SqlDataAdapter(InstruccionSql, CadenaConeccion)
    Dim Ds As New Data.DataSet
    Da.Fill(Ds, NombreTabla)
    LlenarDataTable = Ds.Tables(NombreTabla)

  End Function




  Public Function LeerValorSencillo(ByVal Campo As String, ByVal Tabla As String, ByVal Where As String, ByVal strConexion As String) As String
    Dim dr As MSSQL.SqlDataReader = LeerValor(Campo, Tabla, Where, strConexion)

    Try
      LeerValorSencillo = CStr(dr.Item(Campo).ToString())
    Catch ex As Exception
      LeerValorSencillo = ""
    End Try


  End Function

  Public Function LeerValorSencillo(ByVal Expresion As String, ByVal AliasExpresion As String, _
    ByVal Tabla As String, ByVal Where As String, ByVal strConexion As String) As String

    'Dim dr As MSSQL.SqlDataReader = LeerValor(Expresion, Tabla, Where, strConexion)
    'LeerValorSencillo = CStr(dr.Item(AliasExpresion).ToString())
    Dim dr As MSSQL.SqlDataReader = LeerValor(Expresion, Tabla, Where, strConexion)

    Try
        LeerValorSencillo = CStr(dr.Item(AliasExpresion).ToString())
    Catch ex As Exception
      LeerValorSencillo = ""
    End Try
    
    dr.Close()
  End Function

  


#End Region

End Class
