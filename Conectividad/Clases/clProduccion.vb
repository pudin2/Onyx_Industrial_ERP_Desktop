Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient

Public Class clProduccion
#Region "PROPIEDADES"
    Private mDetResumen As New dsProduccion.DetResumenDataTable
    Private mStrConexion As String
    Private mDetRemision As New dsProduccion.DetRemisionDataTable
    Private mUsuarioId As Integer
    Private mDetSubT As New dsProduccion.DetSubTDataTable
    Private mDetProg As New dsProduccion.DetProgDataTable
    Private mMaxDetId As Integer

    Public Property MaxDetId As Integer
    Get
      Return mMaxDetId
    End Get
    Set(ByVal value As Integer)
      mMaxDetId = value
    End Set
    End Property

    Public Property TablaDetProg As dsProduccion.DetProgDataTable
    Get
      Return mDetProg
    End Get
    Set(ByVal value As dsProduccion.DetProgDataTable)
      mDetProg = value
    End Set
    End Property

    Public Property TablaDetSubT As dsProduccion.DetSubTDataTable
    Get
      Return mDetSubT
    End Get
    Set(ByVal value As dsProduccion.DetSubTDataTable)
      mDetSubT = value
    End Set
    End Property

  Public Property UsuarioId As Integer
  Get
    Return mUsuarioId
  End Get
  Set(value As Integer)
    mUsuarioId = value
  End Set
  End Property


    Public Property TablaDetResumen As dsProduccion.DetResumenDataTable
    Get
        Return mDetResumen
    End Get
    Set(value As dsProduccion.DetResumenDataTable)
        mDetResumen = value
    End Set
    End Property

    Public Property TablaDetRemision As dsProduccion.DetRemisionDataTable
        Get
            Return mDetRemision
        End Get
        Set(value As dsProduccion.DetRemisionDataTable)
            mDetRemision = value
        End Set
    End Property


#End Region




  Public Property CadenaConexion As String
  Get
    CadenaConexion = mStrConexion
  End Get
  Set(value As String)
    mStrConexion = value
  End Set
  End Property

  Public Sub GrabarImpresionOT(strConexion As String, NumOrden As Integer, Tipo As String, Usuario_id As Integer, Fecha As Date, Estado As String)
    Dim dsImpresionOT As New dsProduccionTableAdapters.ImpresionesOTTableAdapter
    Dim obCntv As New clConectividad

    dsImpresionOT.Connection.ConnectionString = strConexion
    Dim NuevoID = obCntv.LeerValorSencillo("isnull(MAX(id)+1,1) [Maximo]", "Maximo", "ImpresionesOT", "id > 0", strConexion)

    dsImpresionOT.Insert(NuevoID, NumOrden, Tipo, Usuario_id, Fecha, Estado)



  End Sub

  Public Sub GrabarCabOT(ByVal strConexion As String,
    ByVal NumOrden As Integer, ByVal CabCotizacion_Id As Integer, ByVal FechaRegistro As Date,
    ByVal FechaInicio As Date, ByVal FechaPactada As Date, ByVal Alcance As String, ByVal Estado As String, ByVal Planos As Boolean,
    ByVal OTCabCotizacion_Id As Integer, ByVal OCompraCliente As String, ByVal CntAFabricar As Integer, ByVal Taller As String,
    ByVal Municipio As String, ByVal EstadoDespacho As String, ByVal Obs As String, ByVal ValAdicional As Decimal)

    Dim dsCabOTAdp As New dsProduccionTableAdapters.CabOTTableAdapter
    Dim obCntv As New clConectividad

    dsCabOTAdp.Connection.ConnectionString = strConexion

    Dim NuevoID = obCntv.LeerValorSencillo("isnull(MAX(id)+1,1) [Maximo]", "Maximo", "CabOT", "id > 0", strConexion)

    dsCabOTAdp.Insert(NuevoID, NumOrden, CabCotizacion_Id, FechaRegistro, FechaInicio, FechaPactada, Alcance, Estado, Planos, _
        OTCabCotizacion_Id, OCompraCliente, CntAFabricar, Taller, Municipio, EstadoDespacho, Obs, ValAdicional)


  End Sub




  Public Sub ActualizarOT(ByVal strConexion As String,
    ByVal NumOrden As Integer, ByVal CabCotizacion_Id As Integer, ByVal FechaRegistro As Date,
    ByVal FechaInicio As Date, ByVal FechaPactada As Date, ByVal Alcance As String, ByVal Estado As String,
    ByVal Planos As Boolean, ByVal OTCabCotizacion_Id As Integer, ByVal CntAFabricar As Integer, ByVal Cupo As Decimal)

    Dim obCntv As New clConectividad, mPlanos As String
    Dim strCadena As String


    If Planos = False Then
      mPlanos = "0"
    Else
      mPlanos = "1"
    End If

    strCadena = "CabCotizacion_Id=" & CabCotizacion_Id.ToString & "," & _
      "FechaRegistro='" & FechaRegistro.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
      "FechaInicio='" & FechaInicio.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
      "FechaPactada='" & FechaPactada.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
      "Alcance='" & Alcance.ToString & "'," & _
      "Estado='" & Estado.ToString & "'," & _
      "Planos=" & mPlanos & "," & _
      "OTCabCotizacion_Id=" & OTCabCotizacion_Id & "," & _
      "CntAFabricar=" & CntAFabricar & "," & _
      "ValAdicional=" & Cupo

    obCntv.ActualizaValor(strCadena, "CabOT", "NumOrden=" & NumOrden.ToString, strConexion)

  End Sub

  Public Sub GrabarResumen(ByVal strConexion As String, ByVal Accion As String, ByVal Id As Integer, _
      ByVal SubT_ID As Integer, ByVal Descripcion As String, ByVal FechaRegistro As Date, ByVal Usuario_ID As Integer, ByVal Estado As String, _
      ByVal Observacion As String, ByVal Horas As Integer)

    'Dim obCntv As New clConectividad

    'GUARDO LA CABECERA
    Dim dsCabResumen As New dsProduccionTableAdapters.CabResumenTableAdapter  '.CabResumenTableAdapter
    dsCabResumen.Connection.ConnectionString = strConexion
    If Accion = "INSERT" Then dsCabResumen.Insert(Id, SubT_ID, Descripcion, FechaRegistro, Usuario_ID, Estado, Observacion, Horas)

    'GUARDO EL DETALLE
    Dim Ff As Integer
    For Ff = 0 To mDetResumen.Rows.Count - 1
      mDetResumen.Rows(Ff).Item("Cab_Id") = Id
    Next Ff

    Dim dsDetResumen As New dsProduccionTableAdapters.DetResumenTableAdapter
    dsDetResumen.Connection.ConnectionString = strConexion
    dsDetResumen.Update(mDetResumen)



  End Sub

  'Public Function GrabarSubTarea(strConexion As String, OTCabId As Integer, Descripcion As String, FechaRegistro As Date, Usuario_Id As Integer, Estado As String) As Integer
  '  Dim mTareaID As Integer, obCntv As New clConectividad
  '  Dim dsSubTareas_OT As New dsProduccionTableAdapters.SubTareas_OTTableAdapter

  '  mTareaID = obCntv.LeerValorSencillo("isnull(max(id),0)+1 [Id]", "ID", "SubTareas_OT", "1=1", strConexion)

  '  dsSubTareas_OT.Connection.ConnectionString = strConexion
  '  dsSubTareas_OT.Insert(mTareaID, OTCabId, Descripcion, FechaRegistro, Usuario_Id, Estado)

  '  obCntv = Nothing : dsSubTareas_OT = Nothing
  '  Return mTareaID
  'End Function



  Public Sub GrabarRemision(strConexion As String, Accion As String, Id As Integer, Fecha As Date, IdCliente As Integer, NombreCliente As String, TransportadoPor As String, _
      Placas As String, DespachadoPor As String, Observacion As String, Estado As String)

    Dim strUpdate As String, obCntv As New clConectividad

    'GUARDO LA CABECERA
    Dim dsCabRemision As New dsProduccionTableAdapters.CabRemisionTableAdapter
    dsCabRemision.Connection.ConnectionString = strConexion

    Dim mHoy As Date = Date.Now

    If Accion = "INSERT" Then
      dsCabRemision.Insert(Id, Fecha, mHoy, IdCliente, NombreCliente, TransportadoPor, Placas, DespachadoPor, Observacion, Estado)
    Else
        strUpdate = "UPDATE CabRemision SET TransportadoPor='" & TransportadoPor & _
            "', Placas='" & Placas & "', DespachadoPor='" & DespachadoPor & "', Observacion='" & Observacion & "', Estado='" & Estado & "' WHERE ID=" & Id
        obCntv.EjecutaComando(strUpdate, strConexion, False)
    End If


    ' *****LA PARTE DEL DETALLE DE LA REMISION*
    Dim Ff As Integer
    For Ff = 0 To mDetRemision.Rows.Count - 1
      mDetRemision.Rows(Ff).Item("Cab_Id") = Id
    Next

    Dim dsDetRemision As New dsProduccionTableAdapters.DetRemisionTableAdapter
    dsDetRemision.Connection.ConnectionString = strConexion
    dsDetRemision.Update(mDetRemision)


    If Accion = "UPDATE" Then
        strUpdate = "EXEC PA_ActualizarOTconRemision " & Id.ToString & "," & mUsuarioId.ToString
        obCntv.EjecutaComando(strUpdate, strConexion, False)
    End If


    obCntv = Nothing
    dsCabRemision = Nothing
    dsDetRemision = Nothing

  End Sub



Public Sub GrabarSubTarea(ByVal strConexion As String, ByVal Accion As String, ByVal Fila As Integer, ByVal Id As Integer, _
    ByVal OT_Cab_ID As Integer, ByVal Descripcion As String, ByVal Fecha As Date, ByVal AsignadaA As String, _
    ByVal Estado As String, ByVal Tipo As String, ByVal Horas As Integer, ByVal Operario_Id As Integer, ByVal Item As Integer, _
    Optional ByVal SubT_Cab_Id As Integer? = Nothing, Optional ByVal Porc As Decimal = 0, Optional ByVal Observacion As String = "")
    'Dim obCntv As New clConectividad

    'GUARDO LA CABECERA
    Dim dsCabSubT As New dsProduccionTableAdapters.CabSubTTableAdapter
    dsCabSubT.Connection.ConnectionString = strConexion

    If Accion = "INSERT" Then
      'If SubT_Cab_Id.HasValue Then
      '  dsCabSubT.Insert(Id, OT_Cab_ID, Descripcion, Fecha, AsignadaA, Estado, Tipo, Horas, _
      '   Operario_Id, Item, SubT_Cab_Id.Value)
      'Else
      '  dsCabSubT.Insert(Id, OT_Cab_ID, Descripcion, Fecha, AsignadaA, Estado, Tipo, Horas, _
      '   Operario_Id, Item, vbNull)
      'End If
      'dsCabSubT.Insert(Id, OT_Cab_ID, Descripcion, Fecha, AsignadaA, Estado, Tipo, Horas, _
      '   Operario_Id, Item, (If(SubT_Cab_Id.HasValue, SubT_Cab_Id.Value, DBNull.Value)))

      dsCabSubT.Insert(Id, OT_Cab_ID, Descripcion, Fecha, AsignadaA, Estado, Tipo, Horas, _
         Operario_Id, Item, SubT_Cab_Id, Porc, Observacion)

    End If


    '****** GUARDO EL DETALLE
        Dim dsDetSubT As New dsProduccionTableAdapters.DetSubTTableAdapter
        dsDetSubT.Connection.ConnectionString = strConexion
        'dsDetSubT.Update(mDetSubT)

        Dim Ff As Integer
        For Ff = 0 To mDetSubT.Rows.Count - 1
          If mDetSubT(Ff).Item("Cab_Id") = Fila Then
            mDetSubT.Rows(Ff).Item("Cab_Id") = Id
            mDetSubT.Rows(Ff).Item("Id") = mMaxDetId
            mMaxDetId = mMaxDetId + 1

            dsDetSubT.Update(mDetSubT.Rows(Ff))
          End If
        Next Ff
        mMaxDetId = 0

        'Filtro el detalle de lo que realmente se puede guardar
        Dim _mDetsubT As DataTable = mDetSubT.Clone()
        Dim filasFiltradas() As DataRow = mDetSubT.Select("Cab_Id = " & Id.ToString)

        For Each filaDet As DataRow In filasFiltradas
            _mDetsubT.ImportRow(filaDet)
        Next



      '***********************************************************************

    dsDetSubT.Connection.ConnectionString = strConexion
    dsDetSubT.Update(_mDetsubT)


  End Sub

Public Sub GrabarProgramacion(ByVal strConexion As String, ByVal Accion As String, _
    ByVal Id As Integer, _
    ByVal Operario_ID As Integer, ByVal FechaIni As Date, _
    ByVal Estado As String, ByVal FechaFin As Date)
    'Dim obCntv As New clConectividad

    'GUARDO LA CABECERA
    Dim dsCabProg As New dsProduccionTableAdapters.CabProgTableAdapter
    dsCabProg.Connection.ConnectionString = strConexion

    If Accion = "INSERT" Then
      dsCabProg.Insert(Id, Operario_ID, FechaIni, Estado, FechaFin)
    End If

    'GUARDO EL DETALLE

    Dim dsDetProg As New dsProduccionTableAdapters.DetProgTableAdapter
    dsDetProg.Connection.ConnectionString = strConexion
    'dsDetSubT.Update(mDetSubT)

    Dim Ff As Integer
    For Ff = 0 To mDetProg.Rows.Count - 1
      'If mDetProg(Ff).Item("Cab_Id") = Fila Then
        mDetProg.Rows(Ff).Item("Cab_Id") = Id
        dsDetProg.Update(mDetProg.Rows(Ff))
      'End If
    Next Ff

    mDetProg.Rows.Clear()

  End Sub



  Public Sub GrabarBitacoraOT(ByVal strConexion As String, ByVal Accion As String, _
    ByVal Id As Integer, _
    ByVal CabOT_Id As Integer, _
    ByVal FechaEvento As Date, _
    ByVal Usuario_Id As Integer, _
    ByVal Evento As String,
    ByVal Estado As String)

     'GUARDO LA CABECERA
    Dim dsBitacoraOT As New dsProduccionTableAdapters.BitacoraOTTableAdapter    'dsProduccionTableAdapters.CabProgTableAdapter
    Dim strUpdate As String, obCntv As New clConectividad

    dsBitacoraOT.Connection.ConnectionString = strConexion


    If UCase(Accion) = "INSERT" Then
      dsBitacoraOT.Insert(Id, CabOT_Id, FechaEvento, Usuario_Id, Evento, Estado)
    ElseIf UCase(Accion) = "UPDATE" Then
          strUpdate = "UPDATE BitacoraOT SET Evento='" & Evento & _
            "', Usuario_ID=" & Usuario_Id & " WHERE ID=" & Id
        obCntv.EjecutaComando(strUpdate, strConexion, False)

        obCntv = Nothing
    End If

    ' If Accion = "INSERT" Then
    '  dsCabRemision.Insert(Id, Fecha, mHoy, IdCliente, NombreCliente, TransportadoPor, Placas, DespachadoPor, Observacion, Estado)
    'Else
    '    strUpdate = "UPDATE CabRemision SET TransportadoPor='" & TransportadoPor & _
    '        "', Placas='" & Placas & "', DespachadoPor='" & DespachadoPor & "', Observacion='" & Observacion & "', Estado='" & Estado & "' WHERE ID=" & Id
    '    obCntv.EjecutaComando(strUpdate, strConexion, False)
    'End If





  End Sub


End Class
