Imports System.Drawing
Imports System.IO
Imports System.Drawing.Imaging
Imports System

Public Class clAnexos
    Private _IdUnico As Guid
    Public ReadOnly Property IdUnico As Guid
        Get
            Return _IdUnico
        End Get
    End Property

    Public Sub New()
        ' Genera un nuevo GUID cuando se crea un nuevo objeto de la clase
        _IdUnico = Guid.NewGuid()
    End Sub

    Public Function RedimensionarImagen(ByVal rutaImagen As String) As Image
        Dim maximoTamanoArchivo As Long = 3 * 1024 * 1024 ' Tamaño máximo permitido: 3MB
        Dim imagenOriginal As Image = Image.FromFile(rutaImagen)

        ' Verificar el tamaño del archivo
        Dim fileInfo As New FileInfo(rutaImagen)
        If fileInfo.Length > maximoTamanoArchivo Then
            ' Calcular nuevo tamaño proporcional manteniendo la relación de aspecto
            Dim proporcion As Double = CDbl(maximoTamanoArchivo) / CDbl(fileInfo.Length)
            Dim nuevoAncho As Integer = CInt(imagenOriginal.Width * Math.Sqrt(proporcion))
            Dim nuevoAlto As Integer = CInt(imagenOriginal.Height * Math.Sqrt(proporcion))

            ' Redimensionar la imagen
            Dim imagenRedimensionada As Image = New Bitmap(nuevoAncho, nuevoAlto)
            Using g As Graphics = Graphics.FromImage(imagenRedimensionada)
                g.DrawImage(imagenOriginal, New Rectangle(0, 0, nuevoAncho, nuevoAlto))
            End Using

            ' Liberar recursos de la imagen original
            imagenOriginal.Dispose()

            ' Devolver la imagen redimensionada
            Return imagenRedimensionada
            imagenRedimensionada.Dispose()
        Else
            ' Si la imagen no supera el tamaño máximo, devolver la original
            Return imagenOriginal
        End If
    End Function


    Public Sub GrabarImagen(ByVal imagen As Image, ByVal rutaGuardar As String)
        ' Guardar la imagen como JPG en la ruta especificada
        'imagen.Save(rutaGuardar, ImageFormat.Jpeg)


        Dim carpetaDestino As String = Path.GetDirectoryName(rutaGuardar)

        ' Verificar si la carpeta de destino existe, de lo contrario, crearla
        If Not Directory.Exists(carpetaDestino) Then
            Directory.CreateDirectory(carpetaDestino)
            Console.WriteLine("Se creó la carpeta de destino.")
        End If

        ' Guardar la imagen como JPG en la ruta especificada
        imagen.Save(rutaGuardar, ImageFormat.Jpeg)

    End Sub

    Public Sub BorrarContenidoCarpeta(ByVal rutaCarpeta As String)
        Try
            ' Verificar si la carpeta existe
            If Directory.Exists(rutaCarpeta) Then
                ' Eliminar todos los archivos dentro de la carpeta
                For Each archivo As String In Directory.GetFiles(rutaCarpeta)
                    File.Delete(archivo)
                Next

                ' Eliminar todos los subdirectorios dentro de la carpeta
                For Each subDirectorio As String In Directory.GetDirectories(rutaCarpeta)
                    Directory.Delete(subDirectorio, True)
                Next
            Else
                ' La carpeta no existe
                Console.WriteLine("La carpeta especificada no existe.")
            End If
        Catch ex As Exception
            ' Manejo de errores si ocurre alguna excepción al eliminar archivos o carpetas
            Console.WriteLine("Error al intentar borrar el contenido de la carpeta: " & ex.Message)
        End Try
    End Sub


  Public Function RedimensionarImagen(ByVal imagen As Bitmap, ByVal maxWidth As Integer, ByVal maxHeight As Integer) As Bitmap
      Dim ratioX As Double = CDbl(maxWidth) / imagen.Width
      Dim ratioY As Double = CDbl(maxHeight) / imagen.Height
      Dim ratio As Double = Math.Min(ratioX, ratioY)
      Dim newWidth As Integer = CInt(imagen.Width * ratio)
      Dim newHeight As Integer = CInt(imagen.Height * ratio)
      Dim newImage As New Bitmap(newWidth, newHeight)

      Using g As Graphics = Graphics.FromImage(newImage)
          g.DrawImage(imagen, 0, 0, newWidth, newHeight)
      End Using

      Return newImage
  End Function


  'Public Sub CopiarArchivo(ByVal rutaOrigen As String, ByVal rutaDestino As String)
  '      Try
  '          ' Verificar si el archivo de origen existe
  '          If File.Exists(rutaOrigen) Then
  '              ' Copiar el archivo desde la ruta de origen a la ruta de destino
  '              File.Copy(rutaOrigen, rutaDestino, True)
  '              Console.WriteLine("Archivo copiado con éxito.")
  '          Else
  '              Console.WriteLine("El archivo de origen no existe.")
  '          End If
  '      Catch ex As Exception
  '          Console.WriteLine("Error al copiar el archivo: " & ex.Message)
  '      End Try
  '  End Sub
  Public Sub CopiarArchivo(ByVal rutaOrigen As String, ByVal rutaDestino As String)
    Try
        ' Verificar si el archivo de origen existe
        If File.Exists(rutaOrigen) Then
            ' Obtener la ruta del directorio destino
            Dim directorioDestino As String = Path.GetDirectoryName(rutaDestino)

            ' Verificar si el directorio destino existe, si no existe, crearlo
            If Not Directory.Exists(directorioDestino) Then
                Directory.CreateDirectory(directorioDestino)
            End If

            ' Copiar el archivo desde la ruta de origen a la ruta de destino
            File.Copy(rutaOrigen, rutaDestino, True)
            Console.WriteLine("Archivo copiado con éxito.")
        Else
            Console.WriteLine("El archivo de origen no existe.")
        End If
    Catch ex As Exception
        Console.WriteLine("Error al copiar el archivo: " & ex.Message)
    End Try
End Sub


End Class
