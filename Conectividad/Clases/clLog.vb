Option Explicit On
Imports System.IO

Public Class clLog
  Private mArchivo As String

  Public Property NombreArchivo As String
    Get
      NombreArchivo = mArchivo
    End Get
    Set(value As String)
      mArchivo = value
    End Set
  End Property


  Public Sub IniciarArchivo(strNombreArchivo As String)

    Dim Escritor As System.IO.StreamWriter
    File.Delete(strNombreArchivo)
    Escritor = File.AppendText(strNombreArchivo)
    Escritor.WriteLine("/************ INICIO LOG MODPROD " & Date.Today & " " & Date.Now & " ************/")
    Escritor.WriteLine("")
    Escritor.Flush()
    Escritor.Close()


  End Sub

  Public Sub EscribirLog(strTexto As String)
    Dim Escritor As System.IO.StreamWriter
    Escritor = File.AppendText(mArchivo)
    Escritor.WriteLine(strTexto)
    Escritor.Flush()
    Escritor.Close()
  End Sub

  Public Sub EscribirLog(strTexto As String, strNombreArchivo As String)
    Dim Escritor As System.IO.StreamWriter
    Escritor = File.AppendText(strNombreArchivo)
    Escritor.WriteLine(strTexto)
    Escritor.Flush()
    Escritor.Close()
  End Sub


End Class
