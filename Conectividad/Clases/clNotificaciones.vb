Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient


Public Class clNotificaciones
  Private mStrConexion As String

  Public Property CadenaConexion As String
  Get
    CadenaConexion = mStrConexion
  End Get
  Set(value As String)
    mStrConexion = value
  End Set
  End Property

  Public Sub GrabarNotificacion(strConexion As String,
    Origen As String, Usu_Envia As String, Usu_Destino As String,
    Fecha As Date, Tipo As String, Estado As String, Titulo As String, Mensaje As String)

    Dim dsNotificaAdp As New dsProduccionTableAdapters.NotificacionesTableAdapter

    Dim obCntv As New clConectividad

    dsNotificaAdp.Connection.ConnectionString = strConexion

    Dim NuevoID = obCntv.LeerValorSencillo("isnull(MAX(id)+1,1) [Maximo]", "Maximo", "Notificaciones", "id > 0", strConexion)

    dsNotificaAdp.Insert(NuevoID, Origen, Usu_Envia, Usu_Destino, Tipo, Estado, Titulo, Mensaje)


  End Sub








End Class
