Option Explicit On
Imports MSSQL = System.Data.SqlClient


Public Class clCompras
#Region "PROPIEDADES"
  Private mDetSolicitud As New dsCompras.DetSolicitudDataTable
  Private mDetOCompra As New dsCompras.DetOCompraDataTable
  Private mTblDetOCompraSolicitud As New dsCompras.mTblDetOCompraSolicitudDataTable
  Private mDetOCompraSolicitud As New dsCompras.DetOCompraSolicitudDataTable
  Private mCMP_DetCotizacion As New dsCompras.CMP_DetCotizacionDataTable

  Public Property TablaCMP_DetCotizacion As dsCompras.CMP_DetCotizacionDataTable
  Get
    Return mCMP_DetCotizacion
  End Get
  Set(value As dsCompras.CMP_DetCotizacionDataTable)
    mCMP_DetCotizacion = value
  End Set
  End Property


  Public Property TablaDetSolicitud As dsCompras.DetSolicitudDataTable
    Get
      Return mDetSolicitud

    End Get
    Set(ByVal value As dsCompras.DetSolicitudDataTable)
      mDetSolicitud = value
    End Set
  End Property


  Public Property TablaDetOCompra As dsCompras.DetOCompraDataTable
    Get
      Return mDetOCompra

    End Get
    Set(ByVal value As dsCompras.DetOCompraDataTable)
      mDetOCompra = value
    End Set
  End Property


  Public Property TablaTblDetOCompraSolicitud As dsCompras.mTblDetOCompraSolicitudDataTable
    Get
      Return mTblDetOCompraSolicitud
    End Get
    Set(ByVal value As dsCompras.mTblDetOCompraSolicitudDataTable)
      mTblDetOCompraSolicitud = value
    End Set
  End Property


  Public Property TablaDetOCompraSolicitud As dsCompras.DetOCompraSolicitudDataTable
    Get
      Return mDetOCompraSolicitud
    End Get
    Set(ByVal value As dsCompras.DetOCompraSolicitudDataTable)
      mDetOCompraSolicitud = value
    End Set
  End Property

#End Region


  Public Sub GrabarSolicitud(ByVal strConexion As String, ByVal Id As Integer, ByVal Fecha As DateTime, _
      ByVal Cab_Id As Integer, ByVal FechaRequerida As DateTime, ByVal Estado As String, TipoDoc As String, Usuario_Id As Integer)

    'Guardo la cabecera
    Dim dsCabSolicitud As New dsComprasTableAdapters.CabSolicitudTableAdapter
    Dim obCntv As New clConectividad
    dsCabSolicitud.Connection.ConnectionString = strConexion
    dsCabSolicitud.Insert(Id, Fecha, Cab_Id, FechaRequerida, Estado, TipoDoc, Usuario_Id)

    'guardo el detalle
    Dim Ff As Integer
    For Ff = 0 To mDetSolicitud.Rows.Count - 1
      mDetSolicitud.Rows(Ff).Item("Cab_Id") = Id
    Next

    Dim dsDetSolicitud As New dsComprasTableAdapters.DetSolicitudTableAdapter
    dsDetSolicitud.Connection.ConnectionString = strConexion
    dsDetSolicitud.Update(mDetSolicitud)

  End Sub


  Public Sub GrabarCotizacion(strConexion As String, Id As Integer, NumCotizacion As Integer, Proveedor_Id As Integer,
      Fecha As DateTime, Estado As String, NumDocProv As String, Observacion As String, FechaEntrega As Date)

      'GUARDO LA CABECERA
      Dim dsCMP_CabCotizacion As New dsComprasTableAdapters.CMP_CabCotizacionTableAdapter
      dsCMP_CabCotizacion.Connection.ConnectionString = strConexion
      dsCMP_CabCotizacion.Insert(Id, NumCotizacion, Proveedor_Id, Fecha, Estado, NumCotizacion, Observacion, FechaEntrega)

      'GUARDO EL DETALLE
      Dim Ff As Integer
      For Ff = 0 To mCMP_DetCotizacion.Rows.Count - 1
        mCMP_DetCotizacion.Rows(Ff).Item("Cab_Id") = Id
      Next

      Dim dsCMP_DetCotizacion As New dsComprasTableAdapters.CMP_DetCotizacionTableAdapter
      dsCMP_DetCotizacion.Connection.ConnectionString = strConexion
      dsCMP_DetCotizacion.Update(mCMP_DetCotizacion)


  End Sub


  Public Sub GrabarOrdenCompra(ByVal strConexion As String, ByVal Id As Integer, ByVal Fecha As DateTime, ByVal Usuario_Id As Integer, _
                               ByVal Estado As String, Proveedor_Id As Integer, Optional FechaEntrega As DateTime = #1/1/2000#,
                               Optional FechaValidacion As DateTime = #1/1/2000#, Optional Observacion As String = "", _
                               Optional LugarEntrega As String = "", Optional Descuento As Decimal = 0, Optional CabCot_Id As String = "")

    'Dim FechaValidacion As DateTime
    'FechaValidacion = Today
    'GUARDO LA CABECERA
    Dim dsCabOCompra As New dsComprasTableAdapters.CabOCompraTableAdapter
    Dim obCntv As New clConectividad
    dsCabOCompra.Connection.ConnectionString = strConexion

    dsCabOCompra.Insert(Id, Fecha, Usuario_Id, FechaEntrega, FechaValidacion, Estado, Proveedor_Id, Observacion, LugarEntrega, Descuento, CabCot_Id)

    'GUARDO EL DETALLE
    Dim Ff As Integer
    For Ff = 0 To mDetOCompra.Rows.Count - 1
      mDetOCompra.Rows(Ff).Item("Cab_Id") = Id
    Next

    Dim dsDetOCompra As New dsComprasTableAdapters.DetOCompraTableAdapter
    dsDetOCompra.Connection.ConnectionString = strConexion
    dsDetOCompra.Update(mDetOCompra)


    'GUARDO N:N  TABLA SQL:DetOCompraSolicitud
    For Ff = 0 To mDetOCompraSolicitud.Rows.Count - 1
      mDetOCompraSolicitud.Rows(Ff).Item("OCompra_Cab_Id") = Id
    Next

    Dim dsDetOCompraSolicitud As New dsComprasTableAdapters.DetOCompraSolicitudTableAdapter
    dsDetOCompraSolicitud.Connection.ConnectionString = strConexion
    dsDetOCompraSolicitud.Update(mDetOCompraSolicitud)

  End Sub

    Public Sub ActualizarOrdenCompra(ByVal strConexion As String, ByVal Id As Integer, ByVal Estado As String, Optional FechaEntrega As DateTime = #1/1/2000#, _
                                 Optional FechaValidacion As DateTime = #1/1/2000#,
                                 Optional Observacion As String = vbNullString,
                                 Optional LugarEntrega As String = vbNullString, _
                                 Optional Descuento As Decimal = vbNull, _
                                 Optional ObsAnulacion As String = vbNullString, _
                                 Optional FechaAnulacion As DateTime = #1/1/2000#,
                                Optional Usuario_Id_Aprueba As Integer = 0)


        Dim obCntv As New clConectividad
        Dim Cadena As String
    Cadena = "FechaEntrega = '" & FechaEntrega.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
      "FechaValidacion='" & FechaValidacion.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
      "Estado='" & Estado & "'," & _
      "Observacion='" & Observacion & "'," & _
      "Descuento=" & Descuento & "," & _
      "LugarEntrega='" & LugarEntrega & "'," & _
      "Usuario_ID_Aprueba=" & Usuario_Id_Aprueba


        If Estado = "I" Then
            Cadena = Cadena & ", ObsAnulacion='" & ObsAnulacion & "', " & "FechaAnulacion='" & FechaAnulacion.ToString("dd/MM/yyyy H:mm:ss") & "'"
        End If

        obCntv.ActualizaValor(Cadena, "CabOCompra", "id=" & Id, strConexion)





    End Sub

    Public Sub ActualizarSolicitud(Id As Integer, Fecha As Date, Cab_Id As Integer, FechaRequerida As Date, Estado As String)
        Dim obCntv As New clConectividad, obTran As MSSQL.SqlTransaction, strComando As String
        Dim dsDetSolicitud As New dsComprasTableAdapters.DetSolicitudTableAdapter

        Dim Cadena As String
        Cadena = "Fecha = '" & Fecha.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
          "Cab_Id=" & Cab_Id & "," & _
          "FechaRequerida='" & FechaRequerida.ToString("dd/MM/yyyy H:mm:ss") & "'," & _
          "Estado='" & Estado & "'"

        obCntv.ActualizaValor(Cadena, "CabSolicitud", "id=" & Id, My.Settings.cnnModProd)

        dsDetSolicitud.Connection.ConnectionString = My.Settings.cnnModProd
        dsDetSolicitud.Connection.Open()
        Dim obComando As MSSQL.SqlCommand = dsDetSolicitud.Connection.CreateCommand()


        obTran = dsDetSolicitud.Connection.BeginTransaction("UpdateDetSolicitud")
        obComando.Connection = dsDetSolicitud.Connection
        obComando.Transaction = obTran
        dsDetSolicitud.Transaction = obTran

        Try
            strComando = "delete from DetSolicitud where Cab_ID =" & Cab_Id.ToString
            obComando.CommandText = strComando
            obComando.ExecuteNonQuery()
            dsDetSolicitud.Update(mDetSolicitud)
            obTran.Commit()

        Catch ex As Exception
            obTran.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.Critical)


        End Try


    End Sub

    Public Sub ActualizaDetalleCotiza(Cab_Id As Integer, strConexion As String)
        Dim dsDetCotiza As New dsComprasTableAdapters.CMP_DetCotizacionTableAdapter
        Dim strComando As String, obTran As MSSQL.SqlTransaction

        dsDetCotiza.Connection.ConnectionString = strConexion
        dsDetCotiza.Connection.Open()

        Dim obComando As MSSQL.SqlCommand = dsDetCotiza.Connection.CreateCommand()


        obTran = dsDetCotiza.Connection.BeginTransaction("UpdateDetCotizacion")


        obComando.Connection = dsDetCotiza.Connection()
        obComando.Transaction = obTran
        dsDetCotiza.Transaction = obTran

        Try
            strComando = "delete from CMP_DetCotizacion where Cab_ID =" & Cab_Id.ToString
            obComando.CommandText = strComando
            obComando.ExecuteNonQuery()
            'obCntv.EjecutaComando(strComando, strCadena, False)
            dsDetCotiza.Update(mCMP_DetCotizacion)

            strComando = "update CMP_CabCotizacion set estado='C' where id=" & Cab_Id.ToString
            obComando.CommandText = strComando
            obComando.ExecuteNonQuery()

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

    Public Sub GrabarIngresosOC(strConexion As String, Cab_Id As Integer, Det_Id As Integer, IdEncabMov As Integer, Fecha As Date, Cant As Decimal, Estado As String)
        'Dim dsCabSolicitud As New dsComprasTableAdapters.CabSolicitudTableAdapter
        'Dim obCntv As New clConectividad
        'dsCabSolicitud.Connection.ConnectionString = strConexion
        'dsCabSolicitud.Insert(Id, Fecha, Cab_Id, FechaRequerida, Estado, TipoDoc, Usuario_Id)

        Dim dsCMP_Ingresos_OC As New dsComprasTableAdapters.CMP_Ingresos_OCTableAdapter
        dsCMP_Ingresos_OC.Connection.ConnectionString = strConexion
        dsCMP_Ingresos_OC.Insert(Cab_Id, Det_Id, IdEncabMov, Fecha, Cant, Estado)


        dsCMP_Ingresos_OC = Nothing

    End Sub


End Class
