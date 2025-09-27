Option Explicit On
Imports System.Xml


Public Class clManejoXML
  Private mDataSet As New DataSet
  Private mOrdenaPor As String
  Private mCampo As String

  Public Property xmlDataSet As DataSet
    Get
      Return mDataSet
    End Get
    Set(ByVal Value As DataSet)
      mDataSet = Value
    End Set
  End Property

  Public Property OrdenaPor As String
    Get
      Return mOrdenaPor
    End Get
    Set(ByVal value As String)
      mOrdenaPor = value
    End Set
  End Property


  Public Property Campo As String
    Get
      Return mCampo

    End Get
    Set(ByVal value As String)
      mCampo = value
    End Set
  End Property




  Public Sub AbrirXml(ByVal strFile As String)
    Dim xmlFile = XmlReader.Create(strFile, New XmlReaderSettings())

    mDataSet.ReadXml(xmlFile)


  End Sub


  Public Function LeerValor(ByVal Clave As String, ByVal Campo As String, ByVal OrdenaPor As String) As String
    Dim dv As DataView
    dv = New DataView(mDataSet.Tables(0))
    dv.Sort = OrdenaPor  '"Label_Id"

    Dim Ii As Integer = dv.Find(Clave)

    If Ii = -1 Then
      LeerValor = ""
    Else
      LeerValor = dv(Ii)(Campo).ToString()

    End If

  End Function

  Public Function LeerValor(ByVal Clave As String, ByVal Campo As String, ByVal OrdenaPor As String, ByVal strFile As String) As String

    Call AbrirXml(strFile)

    LeerValor = LeerValor(Clave, Campo, OrdenaPor)
  End Function


  Public Function LeerValor(ByVal Clave As String)
    LeerValor = LeerValor(Clave, mCampo, mOrdenaPor)
  End Function


  Public Function LeerValor(ByVal Clave As String, ByVal strFile As String)
    LeerValor = LeerValor(Clave, mCampo, mOrdenaPor, strFile)

  End Function


End Class
