Imports System.Data.SqlClient
Imports System.Data

Public Class clInventarios


  Private mStrConexion As String

  Public Property CadenaConexion As String
  Get
    CadenaConexion = mStrConexion
  End Get
  Set(ByVal value As String)
    mStrConexion = value
  End Set
  End Property

    ' Método para registrar un movimiento completo con cabecera y detalles
    Public Function RegistrarMovimiento(ByVal strConexion As String,
        ByVal almacenId As Integer, ByVal tipoMovimiento As Integer, ByVal fechaMovimiento As DateTime,
        ByVal observaciones As String, ByVal docReferencia As String, ByVal detalles As DataTable) As Boolean

        Using conn As New SqlConnection(strConexion)

            Try
                conn.Open()

                ' Crear un SqlParameter para el tipo de tabla definido en SQL
                Dim detallesParam As New SqlParameter()
                detallesParam.ParameterName = "@Detalles"
                detallesParam.SqlDbType = SqlDbType.Structured
                detallesParam.Value = detalles
                detallesParam.TypeName = "TypeDetMovimiento"

                ' Crear y configurar el SqlCommand para ejecutar el procedimiento almacenado
                Using cmd As New SqlCommand("INV.spRegistrarMovimiento", conn)
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.Parameters.Add("@AlmacenID", SqlDbType.Int).Value = almacenId
                    cmd.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = tipoMovimiento
                    cmd.Parameters.Add("@FechaMovimiento", SqlDbType.DateTime).Value = fechaMovimiento
                    cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = observaciones
                    cmd.Parameters.Add("@DocReferencia", SqlDbType.VarChar).Value = docReferencia
                    cmd.Parameters.Add(detallesParam)

                    cmd.ExecuteNonQuery()
                End Using
                Return True
            Catch ex As Exception
                Console.WriteLine("Error: " & ex.Message)
                Return False
            Finally
                conn.Close()
            End Try
        End Using
    End Function

End Class
