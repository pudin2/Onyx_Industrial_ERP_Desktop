Option Explicit On
Imports Microsoft.Office.Interop  'aqui debes hacer una referencia al com de outlook
Imports System.Text
Imports System.Windows.Forms

Public Class clCorreo
  Private mCuerpo As String


  Private moApp As Outlook.Application
  Private mbKillMe As Boolean = True
  Private cabecera, estilo, cuerpo, footer As String


Public Property CuerpoMensaje As String
Get
  CuerpoMensaje = mCuerpo
End Get
Set(value As String)
  mCuerpo = value
End Set
End Property

  Public Sub enviar_mail()
    'primero verifico que tenga el outlook instalado
    If verificar_outlook() Then
      crear_email()
      cerrar_email()
    End If
  End Sub


  Private Function verificar_outlook() As Boolean
    Try
      moApp = CType(GetObject(, "Outlook.Application"), Outlook.Application)
      mbKillMe = False
    Catch ex As Exception
      If moApp Is Nothing Then
        moApp = New Outlook.Application
        mbKillMe = True

        MessageBox.Show("Outlook no se ha iniciado en este equipo!" & vbCrLf & vbCrLf & "El correo creado lo encontrará en la bandeja Borradores", "ModProd", MessageBoxButtons.OK, MessageBoxIcon.Information)

      End If
    End Try
    If moApp Is Nothing Then

      MessageBox.Show("Outlook no se ha instalado en este equipo!" & vbCrLf & vbCrLf & "No se puede crear el correo.", "ModProd", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Return False
    End If

    Return True
  End Function


  Private Sub crear_email()
    Dim oEmail As Outlook.MailItem
    'Me.Cursor = Cursors.WaitCursor
    oEmail = DirectCast(moApp.CreateItem(Outlook.OlItemType.olMailItem), Outlook.MailItem)
    With oEmail
        .To = ""
        .CC = ""
        .Subject = "TECNIPALMA Cotización de productos"
        .BodyFormat = Outlook.OlBodyFormat.olFormatHTML
        .HTMLBody = mCuerpo
        '.BodyFormat = Outlook.OlBodyFormat.olFormatUnspecified
        '.Body = mCuerpo

        '.BodyFormat = Outlook.OlBodyFormat.olFormatPlain
        '.Body = mCuerpo


        .Importance = Outlook.OlImportance.olImportanceNormal
        .ReadReceiptRequested = False
        '.Attachments.Add(“C:\archivo.jpg”, Outlook.OlAttachmentType.olByValue)
        '.Recipients.ResolveAll()
        .Save()
        .Display() 'Muestra el mensaje para que se pueda editar
    '.Send() ‘Si lo activas se envia automaticamente sin editar
    End With
    'Me.Cursor = Cursors.Default
  End Sub


  Private Sub cerrar_email()
    If mbKillMe = True Then
      If Not moApp Is Nothing Then
      moApp.Quit()
      moApp = Nothing
      End If
    End If
  End Sub



  Public Function DataTableToHTMLTable(ByVal inTable As DataTable) As String
    Dim dString As New StringBuilder

    dString.Append("<table border=1 cellspacing=0 cellpadding=0 width=600>")
    dString.Append(GetHeader(inTable))
    dString.Append(GetBody(inTable))
    dString.Append("</table>")
    Return dString.ToString
  End Function

  Public Function TextToHTML(Cadena As String, Fuente As String, Size As Integer, NuevaLinea As Boolean)
    Dim Salida As String

    Salida = "<font face=" & Chr(34) & Fuente & Chr(34) & " size=" & Size & ">" & Cadena & "</font>"  'sans-serif">Señores: AGOFER</font>"

    If NuevaLinea = True Then
      Salida = "<P>" & Salida & "</P>"
    End If

    Return Salida
  End Function

  Private Function GetHeader(ByVal dTable As DataTable) As String
   Dim dString As New StringBuilder

   dString.Append("<thead><tr>")
   For Each dColumn As DataColumn In dTable.Columns
    'dString.AppendFormat("<th>{0}</th>", dColumn.ColumnName)
    dString.AppendFormat("<th>{0}</th>", TextToHTML(dColumn.ColumnName.ToString, "sans-serif", 2, False))

   Next
   dString.Append("</tr></thead>")

   Return dString.ToString
  End Function

  Private Function GetBody(ByVal dTable As DataTable) As String
   Dim dString As New StringBuilder

   dString.Append("<tbody>")

   For Each dRow As DataRow In dTable.Rows
    dString.Append("<tr>")
    For dCount As Integer = 0 To dTable.Columns.Count - 1
      If dCount = 1 Then
        dString.AppendFormat("<td align=" & Chr(34) & "right" & Chr(34) & ">{0}</td>", TextToHTML(dRow(dCount).ToString, "sans-serif", 2, False))
      Else
        dString.AppendFormat("<td>{0}</td>", TextToHTML(dRow(dCount).ToString, "sans-serif", 2, False))
      End If

    Next
    dString.Append("</tr>")
   Next
   dString.Append("</tbody>")

   Return dString.ToString()

   End Function

  Public Function DataTableToTexto(mTabla As DataTable) As String
    Dim Salida As String = "", vctAnchos(3) As Integer
    Dim Cc As Integer, Ff As Integer

    vctAnchos(0) = 100 : vctAnchos(1) = 30 : vctAnchos(2) = 20

    ''DETERMINO LOS ANCHOS
    'For Ff = 0 To mTabla.Rows.Count - 1
    '  For Cc = 0 To mTabla.Columns.Count - 1
    '    If Len(Trim(mTabla.Rows(Ff).Item(Cc).ToString)) > vctAnchos(Cc) Then
    '      vctAnchos(Cc) = Len(Trim(mTabla.Rows(Ff).Item(Cc).ToString)) + 10
    '    End If
    '  Next Cc
    'Next Ff


    For Ff = 0 To mTabla.Rows.Count - 1
      For Cc = 0 To mTabla.Columns.Count - 1
        Salida = Salida & Trim(mTabla.Rows(Ff).Item(Cc).ToString) & StrDup(vctAnchos(Cc) - Len(Trim(mTabla.Rows(Ff).Item(Cc).ToString)), " ") '& vbTab
      Next Cc
      Salida = Salida & vbCrLf
    Next Ff

    Return Salida

  End Function

End Class
