Imports MSSQL = System.Data.SqlClient

Public Class clMovimiento
'Grabar cabecera
'GRaba detalle
'Consumir existencias

'Private mCadenaConeccion As String = ""

Private mDetMovimiento As New dsMovimiento.DetMovDataTable
Private mEntregaDeAreaID As Integer

Public Property EntregaDeAreaID As Integer
Get
  Return mEntregaDeAreaID
End Get
Set(ByVal value As Integer)
  mEntregaDeAreaID = value
End Set
End Property


Public Property DetMovimiento As dsMovimiento.DetMovDataTable
Get
  Return mDetMovimiento
End Get
Set(ByVal value As dsMovimiento.DetMovDataTable)
  mDetMovimiento = value
End Set
End Property

'Public Sub InicializarDetMovimiento()
'  mDetMovimiento = New dsMovimiento.DetMovDataTable

'End Sub

  Public Sub GrabarMovimiento(ByVal strConexion As String, ByVal Motivo_ID As Short, ByVal Numero As Integer, _
                              ByVal Area_ID As Integer, ByVal Fecha As Date, ByVal Estado As String, _
                              ByVal Observacion As String, ByVal CabOrden_Id As Global.System.Nullable(Of Long), _
                              Optional ByVal Empleado_Id As String = vbNullString,
                              Optional ByVal TipoDoc As String = vbNullString,
                              Optional ByVal NumDocumento As Integer = vbNull,
                              Optional ByVal Bodega_Id As Integer = 1
                              )

    Dim dsCabMovAdp As New dsMovimientoTableAdapters.CabMovTableAdapter
    dsCabMovAdp.Connection.ConnectionString = strConexion


    dsCabMovAdp.Insert(Motivo_ID, Numero, Area_ID, Fecha, Estado, Observacion, _
      CabOrden_Id, Empleado_Id, TipoDoc, NumDocumento, Bodega_Id)

    Dim obCntv As New clConectividad
    Dim NuevoMov = obCntv.LeerValorSencillo("MAX(ID) [Maximo]", "Maximo", "CabMov", "id > 0", strConexion)
    obCntv.EjecutaComando("update EntregasDeArea set Entrada_CabMov_ID=" & NuevoMov.ToString & " where id=" & mEntregaDeAreaID, _
    strConexion, False)

    Dim Ff As Integer

    For Ff = 0 To mDetMovimiento.Rows.Count - 1
      mDetMovimiento.Rows(Ff).Item("CabMov_ID") = NuevoMov
    Next

    Dim dsDetMovAdp As New dsMovimientoTableAdapters.DetMovTableAdapter
    dsDetMovAdp.Connection.ConnectionString = strConexion
    dsDetMovAdp.Update(mDetMovimiento)

    'Actualizo los saldos
    obCntv.EjecutaComando("SP_ActualizaSaldoMov " & NuevoMov, My.Settings.cnnModProd, False)


  End Sub

  Public Function CargarMovimiento(ByVal strConexion As String, ByVal CabMov_ID As Integer) As DataSet

    Dim dsMov As New DataSet, obCntv As New clConectividad
    dsMov.Tables.Add(obCntv.LlenarDataTable(strConexion, "*", "CabMov", "id=" & CabMov_ID.ToString).Copy)
    dsMov.Tables.Add(obCntv.LlenarDataTable(strConexion, "*", "DetMov", "CabMov_id=" & CabMov_ID.ToString).Copy)


    Return dsMov
  End Function


  Public Overridable Sub ValidarMovimiento(ByVal strConexion As String, ByVal CabMov_ID As Integer)
    Dim obCnvt As New clConectividad

    obCnvt.EjecutaComando("pa_ValidaAsignacionArea " & CabMov_ID.ToString, strConexion, False)
  End Sub

End Class




Public Class clMovimientoEntrada
Inherits clMovimiento

Public Overrides Sub ValidarMovimiento(ByVal strConexion As String, ByVal CabMov_ID As Integer)
  Dim obCnvt As New clConectividad

    obCnvt.EjecutaComando("pa_ValidaEntregaDeArea " & CabMov_ID.ToString, strConexion, False)
End Sub


End Class