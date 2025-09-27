Option Explicit On
Imports MSSQL = System.Data.SqlClient

Public Class clContratos
  Private mStrConexion As String

  Public Property CadenaConexion As String
  Get
    CadenaConexion = mStrConexion
  End Get
  Set(value As String)
    mStrConexion = value
  End Set
  End Property

  Public Sub GrabarContrato(strConexion As String,
    NumContrato As String, IdCliente As Integer, NombreCliente As String, Alcance As String, Valor As Single, _
    Fecha_Sys As Date, Fecha_Ini As Date, Fecha_Fin As Date, Estado As String)

    Dim dsContratoAdp As New dsMantenimientoTableAdapters.ContratosTableAdapter
    Dim obCntv As New clConectividad
    dsContratoAdp.Connection.ConnectionString = strConexion

    Dim NuevoID = obCntv.LeerValorSencillo("isnull(MAX(id)+1,1) [Maximo]", "Maximo", "Contratos", "id > 0", strConexion)


    dsContratoAdp.Insert(NuevoID, NumContrato, IdCliente, NombreCliente, Alcance, Valor, Fecha_Sys, Fecha_Ini, Fecha_Fin, Estado)

  End Sub


Public Sub ActualizarContrato(strConexion As String, Id As Integer, _
    NumContrato As String, IdCliente As Integer, NombreCliente As String, Alcance As String, Valor As Single, _
    Fecha_Ini As Date, Fecha_Fin As Date, Estado As String)

    Dim obCntv As New clConectividad

    'Dim dtCabCotizacion As DataTable = obCntv.LlenarDataTable(strConexion, "*", "CabCotizacion", "id=" & ID.ToString)


    Dim Cadena As String
    Cadena = "NumContrato = '" & NumContrato & "'," & _
      "IdCliente=" & IdCliente & "," & _
      "NombreCliente='" & NombreCliente & "'," & _
      "Alcance='" & Alcance & "'," & _
      "Valor=" & Valor & "," & _
      "Fecha_Ini='" & Fecha_Ini.ToString & "'," & _
      "Fecha_Fin='" & Fecha_Fin.ToString & "'," & _
      "Estado='" & Estado & "'"

    obCntv.ActualizaValor(Cadena, "Contratos", "id=" & Id, strConexion)




End Sub




End Class
