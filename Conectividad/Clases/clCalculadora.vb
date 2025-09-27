Imports MSSQL = System.Data.SqlClient


Public Class clCalculadora
  Private mCabCotizacion As New dsCalculadora.CabCotizacionDataTable
  Private mDetCotizacion As New dsCalculadora.DetCotizacionDataTable

  Public Property CabCotizacion As dsCalculadora.CabCotizacionDataTable
    Get
      Return mCabCotizacion
    End Get
    Set(ByVal value As dsCalculadora.CabCotizacionDataTable)
      mCabCotizacion = value
    End Set
  End Property

  Public Property DetCotizacion As dsCalculadora.DetCotizacionDataTable
    Get
      Return mDetCotizacion
    End Get
    Set(ByVal value As dsCalculadora.DetCotizacionDataTable)
      mDetCotizacion = value
    End Set
  End Property

  Public Sub ActualizarCotizacion(ByVal strConexion As String, ByVal ID As Integer, _
    ByVal Fecha As Date, ByVal Observacion As String, _
    ByVal IdCliente As Integer, ByVal NombreCliente As String, ByVal NombreProyecto As String, ByVal Alcance As String, _
    ByVal TiempoFabricacion As String, ByVal TiempoEntrega As String, ByVal RequiereMontaje As Boolean, ByVal Requisicion As String, _
    ByVal DirigidaA As String, ByVal Aviso As String, ByVal FormaPago As String, ByVal NumCotizacion As Integer,
    ByVal AsignadoA As String, ByVal PrecioBase As Single, ByVal PrecioFinal As Single, ByVal VentaDirecta As Boolean, _
    ByVal AIU As Single, ByVal Imprevistos As Single, ByVal ObsInterna As String, ByVal Tipo As String, ByVal Estado As String, _
    ByVal Req_Id As Integer, ByVal OC_Cliente As String, Contrato_Id As Integer, ByVal AIU_MO As Single)

    Dim obCntv As New clConectividad

    Dim dtCabCotizacion As DataTable = obCntv.LlenarDataTable(strConexion, "*", "CabCotizacion", "id=" & ID.ToString)


    Dim Cadena As String
    Cadena = "Id = '" & ID & "'," _
        & "Observacion = '" & Observacion & "'," _
        & "IdCliente = " & IdCliente & "," _
        & "NombreCliente = '" & NombreCliente & "'," _
        & "NombreProyecto = '" & NombreProyecto & "'," _
        & "Alcance = '" & Alcance & "'," _
        & "TiempoFabricacion = '" & TiempoFabricacion & "'," _
        & "TiempoEntrega = '" & TiempoEntrega & "'," _
        & "RequiereMontaje = " & IIf(RequiereMontaje = True, 1, 0) & "," _
        & "Requisicion = '" & Requisicion & "'," _
        & "DirigidaA = '" & DirigidaA & "'," _
        & "Aviso = '" & Aviso & "'," _
        & "FormaPago = '" & FormaPago & "'," _
        & "NumCotizacion = '" & NumCotizacion & "'," _
        & "AsignadoA = '" & AsignadoA & "'," _
        & "PrecioBase = " & PrecioBase & "," _
        & "PrecioFinal = " & PrecioFinal & "," _
        & "VentaDirecta = " & IIf(VentaDirecta = True, 1, 0) & "," _
        & "AIU = " & AIU & "," _
        & "Imprevistos = " & Imprevistos & "," _
        & "ObsInterna = '" & ObsInterna & "'," _
        & "Tipo='" & Tipo & "'," _
        & "Req_Id=" & Req_Id & "," _
        & "OC_Cliente='" & OC_Cliente.ToString & "'," _
        & "Contrato_Id=" & Contrato_Id.ToString & "," _
        & "AIU_MO = " & AIU_MO.ToString


    If Estado <> "" Then
      Cadena = Cadena & ", Estado='" & Estado & "'"
    End If


    '& "Fecha = '" & Fecha.ToString("yyyy-MM-dd HH:mm:ss") & "'," _

    obCntv.ActualizaValor(Cadena, "CabCotizacion", "id=" & ID, strConexion)

  End Sub




  Public Sub GrabarCotizacion(ByVal strConexion As String, ByVal Fecha As Date, ByVal Observacion As String, _
    ByVal IdCliente As Integer, ByVal NombreCliente As String, ByVal NombreProyecto As String, ByVal Alcance As String, _
    ByVal TiempoFabricacion As String, ByVal TiempoEntrega As String, ByVal RequiereMontaje As Boolean, ByVal Requisicion As String, _
    ByVal DirigidaA As String, ByVal Aviso As String, ByVal FormaPago As String, ByVal NumCotizacion As Integer,
    ByVal AsignadoA As String, ByVal PrecioBase As Single, ByVal PrecioFinal As Single, ByVal VentaDirecta As Boolean, _
    ByVal AIU As Single, ByVal Imprevistos As Single, ByVal Estado As String, ByVal ObsInterna As String, ByVal Tipo As String, _
    ByVal Req_Id As Integer, ByVal OC_Cliente As String, ByVal Contrato_Id As Integer, ByVal AIU_MO As Single, ByVal CntAFabricar As Integer)
    ', ByVal Estado As String, ByVal Observacion As String, ByVal CabOrden_Id As Global.System.Nullable(Of Long))


    Dim dsCabCotizacionAdp As New dsCalculadoraTableAdapters.CabCotizacionTableAdapter
    Dim obCntv As New clConectividad

    dsCabCotizacionAdp.Connection.ConnectionString = strConexion

    Dim NuevoID = obCntv.LeerValorSencillo("isnull(MAX(id)+1,1) [Maximo]", "Maximo", "CabCotizacion", "id > 0", strConexion)

    dsCabCotizacionAdp.Insert(NuevoID, Fecha, Observacion, IdCliente, NombreCliente, NombreProyecto, Alcance, _
      TiempoFabricacion, TiempoEntrega, RequiereMontaje, Requisicion, DirigidaA, Aviso, FormaPago, NumCotizacion, AsignadoA, _
      PrecioBase, PrecioFinal, VentaDirecta, AIU, Imprevistos, Estado, ObsInterna, Tipo, Req_Id, OC_Cliente, Contrato_Id, AIU_MO,
      CntAFabricar
      )
    'dsCabCotizacionAdp.Update(Fecha:=Fecha, AIU:=AIU)


    'Dim dwCabecera As New dsCalculadora.CabCotizacionRow( Rb as new  system.data.datarowbuilder)

    NuevoID = Nothing
    NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", strConexion)

    Dim Ff As Integer

    For Ff = 0 To mDetCotizacion.Rows.Count - 1
      mDetCotizacion.Rows(Ff).Item("Cab_ID") = NuevoID
    Next

    Dim dsDetCotizacionAdp As New dsCalculadoraTableAdapters.DetCotizacionTableAdapter
    dsDetCotizacionAdp.Connection.ConnectionString = strConexion
    dsDetCotizacionAdp.Update(mDetCotizacion)


  End Sub

  Public Sub ActualizaDetalleCotiza(ByVal Cab_ID As Integer, ByVal strConexion As String)

    Dim NuevoId As Integer = Cab_ID
    'NuevoId = Nothing
    'NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "CabCotizacion", "id > 0", strConexion)

    Dim Ff As Integer

    For Ff = 0 To mDetCotizacion.Rows.Count - 1
      mDetCotizacion.Rows(Ff).Item("Cab_ID") = NuevoId
    Next

    Dim dsDetCotizacionAdp As New dsCalculadoraTableAdapters.DetCotizacionTableAdapter
    dsDetCotizacionAdp.Connection.ConnectionString = strConexion
    dsDetCotizacionAdp.Connection.Open()
    Dim strComando As String
    Dim obComando As MSSQL.SqlCommand = dsDetCotizacionAdp.Connection.CreateCommand()
    Dim obTran As MSSQL.SqlTransaction
    obTran = dsDetCotizacionAdp.Connection.BeginTransaction("UpdateDetCotizacion")

    obComando.Connection = dsDetCotizacionAdp.Connection()
    obComando.Transaction = obTran
    dsDetCotizacionAdp.Transaction = obTran

    Try
      strComando = "delete from DetCotizacion where estado='A' and Cab_ID =" & Cab_ID.ToString
      obComando.CommandText = strComando
      obComando.ExecuteNonQuery()
      'obCntv.EjecutaComando(strComando, strCadena, False)
      dsDetCotizacionAdp.Update(mDetCotizacion)

      obTran.Commit()
    Catch ex As Exception
      Try
        obTran.Rollback()
        MsgBox(ex.Message, MsgBoxStyle.Critical)
      Catch ex2 As Exception
        MsgBox(ex2.Message, MsgBoxStyle.Critical)
      End Try
      

    End Try
    

  End Sub

  Public Sub GrabarCheckListCotizacion(ByVal strConexion As String, ByVal Cab_Id As Integer, _
                                      ByVal CheckList_Id As Integer, ByVal Valor As Boolean, ByVal Fecha As Date)


    Dim dsCheckListCotizacion As New dsCalculadoraTableAdapters.CheckListCotizacionTableAdapter

    dsCheckListCotizacion.Connection.ConnectionString = strConexion
    dsCheckListCotizacion.Insert(Cab_Id, CheckList_Id, Valor, Fecha)


  End Sub

  Public Sub ActualizarCheckListCotizacion(ByVal strConexion As String, ByVal Id As Integer, _
                                      ByVal Valor As Integer, ByVal Fecha As Date)


    Dim Cadena As String, obCntv As New clConectividad
    Cadena = "Valor=" & Valor '& ", Fecha='" & Fecha & "'"
    obCntv.ActualizaValor(Cadena, "CheckListCotizacion", "id=" & Id, strConexion)

  End Sub


End Class
