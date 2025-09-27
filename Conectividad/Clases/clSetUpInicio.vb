Public Class clSetUpInicio
  Private mRutaInicio As String
  Public Property RutaInicio()
    Get
      RutaInicio = mRutaInicio
    End Get
    Set(ByVal Value)
      mRutaInicio = value
    End Set
  End Property

#Region " INICIO SETUP "
  '//------------------------------------------------------------------------
  '//            NOMBRE: LeerSetupInicio
  '//            DESCRIPCION: Lee el archivo inicio.XML que contiene las configuraciones básicas y devuele el valor
  '//            PARÁMETROS: string Parametro: Es el dato dentro del XML que voy a buscar
  '//            NOTA:
  '//------------------------------------------------------------------------
  Public Function LeerSetupInicio(ByVal Parametro As String) As String
    Dim dsInicio As New DataSet, dtInicio As New DataTable

    'dsInicio.ReadXml(My.Application.Info.DirectoryPath & "\Inicio.xml", XmlReadMode.ReadSchema)
    dsInicio.ReadXml(mRutaInicio, XmlReadMode.ReadSchema)
    dtInicio = dsInicio.Tables("dtInicio")

    Dim pkInicio(1) As DataColumn
    pkInicio(0) = dtInicio.Columns("Id")
    dtInicio.PrimaryKey = pkInicio

    Dim Fila As DataRow

    'es la busqueda
    Fila = dtInicio.Rows.Find(Parametro)
    LeerSetupInicio = Fila.Item("Valor").ToString

  End Function






  Public Function CargaDtSetupInicio() As DataTable
    Dim dsInicio As New DataSet, dtInicio As New DataTable

    'dsInicio.ReadXml(My.Application.Info.DirectoryPath & "\Inicio.xml", XmlReadMode.ReadSchema)
    dsInicio.ReadXml(mRutaInicio, XmlReadMode.ReadSchema)
    dtInicio = dsInicio.Tables("dtInicio")

    Dim pkInicio(1) As DataColumn
    pkInicio(0) = dtInicio.Columns("Id")
    dtInicio.PrimaryKey = pkInicio
    CargaDtSetupInicio = dtInicio

    dtInicio = Nothing

  End Function


  Public Function LeerSetupInicio(ByVal dtInicio As DataTable, ByVal Parametro As String) As String
    Dim dsInicio As New DataSet ', dtInicio As New DataTable
    Dim Fila As DataRow

    Fila = dtInicio.Rows.Find(Parametro)
    LeerSetupInicio = Fila.Item("Valor").ToString

  End Function


#End Region

#Region "DEFINE INPERSONALIZACION - UTIL EN PRUEBAS"

  Private mUsuario As String, mDominio As String

  Public ReadOnly Property Usuario As String
    Get
      Return mUsuario
    End Get
  End Property

  Public ReadOnly Property Dominio As String
    Get
      Return mDominio
    End Get
  End Property


  Public Sub New()
    Dim obCntv As New clConectividad, mUserReplace As String

    'mUserReplace = obCntv.LeerValorSencillo("Valor", "parametros", "descripcion='UserReplace'", My.Settings.cnnModProd)

    mUserReplace = My.Settings.UsrReplace
    If mUserReplace = "" Then
      mUsuario = Environment.UserName '& Environment.UserName.GetHashCode
      mDominio = Environment.UserDomainName
    Else
      Dim vctUserReplace = Split(mUserReplace, "\")
      mUsuario = vctUserReplace(1)
      mDominio = vctUserReplace(0)

    End If


  End Sub


#End Region
End Class
