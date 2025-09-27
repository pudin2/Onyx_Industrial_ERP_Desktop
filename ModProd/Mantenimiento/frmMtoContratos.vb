Option Explicit On
Imports System.Configuration
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports IO = System.IO
Imports System.ComponentModel

Public Class frmMtoContratos
  Private mVctAnexos As New Collection
  Private mDocCargado As Boolean = False
  Private mTablaAnexos As DataTable
  Private strCadena As String, strIdCliente As String, strNombreCliente As String, obXml As New clManejoXML
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal
  Public mUsuario_Id As Integer
  Private mCabContratoId As Integer
  Private mGuid As String = "", mCntAnexos As Integer

  Private Sub frmMtoContratos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
       Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try

  End Sub

  Private Sub frmMtoContratos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
      Me.Icon = My.Resources.IconoFrm
      mDocCargado = False
      Dim obCntv As New clConectividad

      strCadena = My.Settings.cnnModProd
      obCntv.CadenaDeConeccion = strCadena

      cmbCliente.DataSource = obCntv.LlenarDataTable(strCadena, "*", "vw_Clientes", "esactivo=1", "Order by Nombre1")
      cmbCliente.DisplayMember = "NombreCompleto"

      Call NombrarBotones()
  End Sub

  Private Sub NombrarBotones()
      Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()


      obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiMtoCto.xml")
      obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

      lblCliente.Text = obXml.LeerValor("lblCliente")
      lblAlcance.Text = obXml.LeerValor("lblAlcance")
      lblF_Final.Text = obXml.LeerValor("lblF_Final")
      lblF_Inicial.Text = obXml.LeerValor("lblF_Inicial")
      lblNumero.Text = obXml.LeerValor("lblNumero")
      lblValor.Text = obXml.LeerValor("lblValor")
      btnGrabar.Text = obXml.LeerValor("btnGrabar")
      Me.Text = obXml.LeerValor("tituloForm")
      'obXml = Nothing

    'PARA EL TITULO DEL BOTON DE LA BARRA EN NUEVA INTERFACE
    If Me.Tag IsNot Nothing Then
      Me.Tag.TEXT = Me.Text
    End If

  End Sub

Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
  Dim obCntv As New clConectividad
  Dim obContrato As New clContratos ', strIdCliente As String
  Dim NuevoID As String, strRuta As String, strEstado As String

  If chkEstado.Checked = True Then
    strEstado = "I"
  Else
    strEstado = "A"
  End If

  If mDocCargado = False Then
    Dim strFechaSys As Date = Today.Date


    obContrato.GrabarContrato(strCadena, txtContrato.Text, strIdCliente, strNombreCliente, txtAlcance.Text, txtValor.Text, strFechaSys, dtpFechaIni.Value, dtpFechaFin.Value, strEstado)
    NuevoID = obCntv.LeerValorSencillo("MAX(id) [Maximo]", "Maximo", "Contratos", "id > 0", strCadena)
    strRuta = GrabarAnexos(NuevoID, mDocCargado)
    Call ActualizarGUID(strRuta, mGuid, NuevoID)
    mCabContratoId = NuevoID
  Else
    Dim strFecha_Ini As Date = dtpFechaIni.Value
    Dim strFecha_Fin As Date = dtpFechaFin.Value

    obContrato.ActualizarContrato(strCadena, mCabContratoId, txtContrato.Text, strIdCliente, strNombreCliente, txtAlcance.Text, txtValor.Text, strFecha_Ini, strFecha_Fin, strEstado)

    If mCntAnexos > 0 Then
      Call ActualizarAnexos(mCabContratoId)
    Else
      strRuta = GrabarAnexos(mCabContratoId, mDocCargado)
      Call ActualizarGUID(strRuta, mGuid, mCabContratoId)

    End If


  End If

  MessageBox.Show(obXml.LeerValor("msgContenidoGrabar") & vbCrLf & "Contrato número: " & mCabContratoId.ToString, obXml.LeerValor("msgTituloGrabar"), MessageBoxButtons.OK, MessageBoxIcon.Information)
  mCabContratoId = 0
  mDocCargado = False
  cmbCliente.Text = ""
  txtAlcance.Text = ""
  txtContrato.Text = ""
  dtpFechaFin.Value = Date.Today
  dtpFechaIni.Value = Date.Today
  txtValor.Text = ""
  lstAnexos.Items.Clear()
  pcbAnexos.Image = Nothing

End Sub


Private Sub cmbCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbCliente.KeyPress
        strIdCliente = "0"

    End Sub

Private Sub cmbCliente_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbCliente.SelectedItem

    strIdCliente = selectedItem("idCliente").ToString
    strNombreCliente = selectedItem("NombreCompleto").ToString
End Sub

  Private Sub txtValor_LostFocus(sender As Object, e As System.EventArgs) Handles txtValor.LostFocus
   ' lblTotalMO.Text = CDec(numTotalMO).ToString(FCTOTOT)
   If IsNumeric(txtValor.Text) Then

    txtValor.Text = CDec(txtValor.Text).ToString(FCTOTOT)
    Else
     txtValor.Text = ""
   End If
  End Sub


Private Sub btnAnexos_Click(sender As System.Object, e As System.EventArgs) Handles btnAnexos.Click
      'El boton adjuntar, solamente carga el listado a subir
        'SE DEJA FILTRO DESDE ARCHIVO DE CONFIGURACION
        ofdCargarAdjuntos.Filter = My.Settings.FiltroAdjuntos  '"JPEG|*.jpg;*.jpeg;*.jpe;*.jfif"

        If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim strArchivo As String, Ff As Integer = 0

            For Each strArchivo In ofdCargarAdjuntos.FileNames
                lstAnexos.Items.Add(IO.Path.GetFileName(strArchivo), True)
                mVctAnexos.Add(strArchivo.ToString)

                'para controlar cuando se cargada la cotizacion
                If mDocCargado = True Then
                    Dim mFila As DataRow = mTablaAnexos.NewRow
                    mFila.Item("id") = 0
                    mFila.Item("RutaArchivo") = strArchivo.ToString
                    mFila.Item("NombreArchivo") = IO.Path.GetFileName(IO.Path.GetFileName(strArchivo))
                    mFila.Item("Estado") = "N"
                    mTablaAnexos.Rows.Add(mFila)
                End If
            Next

            If mVctAnexos.Count > 0 Then
                Call CargaImagen(mVctAnexos(1).ToString, False)
            End If

        End If
End Sub

 


    Private Sub lstAnexos_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstAnexos.KeyDown

        If e.KeyCode = Keys.Delete Then
            Dim Ff As Integer, VctAnexos As New Collection

            For Ff = 0 To lstAnexos.Items.Count - 1
                If lstAnexos.GetItemChecked(Ff) = True Then
                    VctAnexos.Add(mVctAnexos(Ff + 1))
                End If
            Next

            lstAnexos.Items.Clear()
            mVctAnexos.Clear()

            For Each mItem In VctAnexos
                lstAnexos.Items.Add(IO.Path.GetFileName(mItem.ToString), True)
                mVctAnexos.Add(mItem)
            Next

            If mDocCargado = True Then ' CUANDO EL DOCUMENTO HA SIDO CARGADO TIENE OTRO MANEJO
                For Each mFila In mTablaAnexos.Rows
                    mFila("Estado") = "I"
                Next

                For Each mItem In lstAnexos.Items
                    Dim mFila() As DataRow = mTablaAnexos.Select("NombreArchivo = '" & mItem.ToString & "'")
                    mFila(0)("Estado") = "A"
                    'Dim mFila As DataRow = mTablaAnexos.NewRow

                Next

            End If
        End If

    End Sub

    Private Sub lstAnexos_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAnexos.MouseDoubleClick
        Dim mLista = CType(sender, CheckedListBox)
        'Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString)

        'Process.Start(mVctAnexos(mLista.SelectedIndex + 1).ToString)
    End Sub


    Private Sub lstAnexos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAnexos.SelectedIndexChanged

        Dim mLista = CType(sender, CheckedListBox)



          Dim strArchivo As String = mVctAnexos(mLista.SelectedIndex + 1).ToString

          If UCase(Microsoft.VisualBasic.Strings.Right(strArchivo.ToString, 3)) <> "PDF" Then
            Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)
          Else
          '  If mLista.GetItemChecked = True Then
          '    Call CargaPdf(strArchivo)
              pcbAnexos.Image = Nothing
          '  End If
          End If

    End Sub


    'Private Sub lstAnexos_Enter(sender As Object, e As System.EventArgs) Handles lstAnexos.Enter
    '  Dim mLista = CType(sender, CheckedListBox)

    '    Dim strArchivo As String = mVctAnexos(mLista.SelectedIndex + 1).ToString

    '    If UCase(Microsoft.VisualBasic.Strings.Right(strArchivo.ToString, 3)) <> "PDF" Then
    '      Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)
    '    Else
    '      Call CargaPdf(strArchivo)
    '      pcbAnexos.Image = Nothing
    '    End If
    'End Sub

    Private Sub CargaPdf(ByVal strImagen As String)
      Dim loPSI As New ProcessStartInfo
      Dim loProceso As New Process
      loPSI.FileName = strImagen
      loProceso = Process.Start(loPSI)

    End Sub

  Private Sub CargaImagen(ByVal strImagen As String, ByVal blCargar As Boolean)
    Dim mImagen As Bitmap

    Try
          If strImagen.Contains(".pdf") = True Then

            pdfVisor.src = strImagen
            pcbAnexos.Visible = False
            pdfVisor.Visible = True

          Else
            mImagen = New Bitmap(strImagen)
            pcbAnexos.Image = CType(mImagen, Image)
            pcbAnexos.Visible = True
            pdfVisor.Visible = False
          End If

            'Catch ex As Exception
        Catch ex As System.ArgumentException
            If blCargar = True Then
                Process.Start(strImagen).ToString()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.InnerException.ToString, MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try

    End Sub
'=============================================================================================================
'
'     FUNCIONES PARA EL MANEJO DE ANEXOS
'
'============================================================================================================='
#Region "MANEJO DE ANEXOS"

  Private Function GrabarAnexos(ByVal Cab_Id As String, mDocCargado As Boolean) As String
          Dim obCntv As New clConectividad
          Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=15", strCadena)
          Dim strMes As String = StrDup(2 - Len(Today.Month.ToString), "0") & Today.Month.ToString
          Dim strRutaCotiza As String

          If mCabContratoId = 0 Then
              strRutaCotiza = CrearGUID()
              mGuid = strRutaCotiza
          ElseIf mDocCargado = True Then
            strRutaCotiza = CrearGUID()
            mGuid = strRutaCotiza
          Else
              strRutaCotiza = mCabContratoId.ToString
          End If

          Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
          strRuta = strRuta & strRutaB
          If lstAnexos.CheckedItems.Count > 0 Then
              IO.Directory.CreateDirectory(strRuta)

          'ElseIf mDocCargado = True Then
           ' IO.Directory.CreateDirectory(strRuta)
          End If
          'presento el cuadro para cargar los archivos
          'If ofdCargarAdjuntos.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
          Dim strArchivo As String, Ff As Integer

          'For Each strArchivo In mVctAnexos
          For Ff = 0 To lstAnexos.Items.Count - 1
              If lstAnexos.GetItemChecked(Ff) = True Then
                  strArchivo = mVctAnexos(Ff + 1).ToString

                  Dim strDestino As String = strRuta & "\" & IO.Path.GetFileName(strArchivo)
                  Dim strInsert As String

                  IO.File.Copy(strArchivo, strDestino)
                  strInsert = "insert AnexosContratos(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
                    & strDestino.ToString & "','" & mGuid & "','A')"
                  obCntv.EjecutaComando(strInsert, strCadena, False)
              End If
          Next
          'End If

          'FileIO.FileSystem.RenameDirectory(strRuta, "00AA")

          GrabarAnexos = strRuta
      End Function
      Private Sub ActualizarGUID(ByVal strRuta As String, ByVal Guid As String, ByVal NumContrato As String)
          'renombro la carpeta
          If lstAnexos.CheckedItems.Count > 0 Then
              FileIO.FileSystem.RenameDirectory(strRuta, NumContrato)

              Dim strUpdate As String
              strUpdate = "UPDATE AnexosContratos SET RutaArchivo = REPLACE(rutaarchivo, '" _
                & Guid & "' ,'" & NumContrato & "')" _
                & ", mGUID = '" & NumContrato & "' WHERE mGUID ='" & Guid & "'"

              Dim obCntv As New clConectividad
              obCntv.EjecutaComando(strUpdate, strCadena, False)

              Guid = ""
          End If
      End Sub

      Private Function CreaTablaAnexos() As Data.DataTable
          Dim mTabla As Data.DataTable
          mTabla = New DataTable("tblAnexos")

          Dim m_Id As DataColumn = New DataColumn("Id")
          m_Id.DataType = System.Type.GetType("System.Int32")

          Dim mRutaArchivo As DataColumn = New DataColumn("RutaArchivo")
          mRutaArchivo.DataType = System.Type.GetType("System.String")

          Dim mNombreArchivo As DataColumn = New DataColumn("NombreArchivo")
          mNombreArchivo.DataType = System.Type.GetType("System.String")

          Dim mEstado As DataColumn = New DataColumn("Estado")
          mEstado.DataType = System.Type.GetType("System.String")



          mTabla.Columns.Add(m_Id)
          mTabla.Columns.Add(mRutaArchivo)
          mTabla.Columns.Add(mNombreArchivo)
          mTabla.Columns.Add(mEstado)

          CreaTablaAnexos = mTabla
      End Function

      Private Sub ActualizarAnexos(ByVal Cab_Id As String)
          Dim obCntv As New clConectividad, strSql As String

          strSql = "update AnexosContratos set estado='I' where cab_Id=" & Cab_Id.ToString
          obCntv.EjecutaComando(strSql, strCadena, False)

          For Each mFila In mTablaAnexos.Rows
              If mFila("Estado") = "A" Then
                  strSql = "update AnexosContratos set estado='A' where Id=" & mFila("Id")
                  obCntv.EjecutaComando(strSql, strCadena, False)

              ElseIf mFila("Estado") = "N" Then
                  Dim strRuta As String = obCntv.LeerValorSencillo("valor", "parametros", "id=15", strCadena)
                  Dim strFecha As Date = obCntv.LeerValorSencillo("fecha_sys", "Contratos", "id=" & Cab_Id.ToString, strCadena)
                  Dim strMes As String = StrDup(2 - Len(strFecha.Month.ToString), "0") & strFecha.Month.ToString
                  Dim strRutaCotiza As String = mCabContratoId.ToString

                  Dim strRutaB As String = "\" & Today.Year.ToString & "\" & strMes & "\" & strRutaCotiza.ToString
                  strRuta = strRuta & strRutaB

                  Dim strDestino As String = strRuta & "\" & IO.Path.GetFileName(mFila("NombreArchivo"))

                  Try
                      IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

                      Dim strInsert As String = "insert AnexosContratos(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
                        & strDestino.ToString & "','" & mCabContratoId.ToString & "','A')"
                      obCntv.EjecutaComando(strInsert, strCadena, False)

                  Catch ex As System.IO.DirectoryNotFoundException
                      IO.Directory.CreateDirectory(strRuta)
                      IO.File.Copy(mFila("RutaArchivo").ToString, strDestino, True)

                      Dim strInsert As String = "insert AnexosContratos(Cab_id, RutaArchivo,mguid,Estado ) values (" & Cab_Id.ToString & ",'" _
                        & strDestino.ToString & "','" & mCabContratoId.ToString & "','A')"
                      obCntv.EjecutaComando(strInsert, strCadena, False)


                  End Try

              End If
          Next


      End Sub

       Private Function CrearGUID() As String
          Dim g As Guid
          ' Create and display the value of two GUIDs.
          g = Guid.NewGuid()
          CrearGUID = g.ToString

      End Function


#End Region

#Region "CARGA DE COTIZACIONES"


  Private Sub cmdCargar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCargar.Click
    Try

      'Dim mCabContratoId As Integer = InputBox("Contrato")
      mCabContratoId = InputBox("Contrato")
      Me.Cursor = Cursors.WaitCursor


      Call CargarContrato(mCabContratoId)
      mDocCargado = True


      Me.Cursor = Cursors.Default

    Catch ex As System.InvalidCastException

    Catch ex As Exception
    MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Try
  End Sub

  Private Sub CargarContrato(mCabContratoId As Integer)
    Dim objCntv As New clConectividad

    Try

    Dim drCabContrato As MSSQL.SqlDataReader = _
              objCntv.LeerValor("*", "Contratos", "id = " & mCabContratoId, strCadena)

      strIdCliente = drCabContrato.Item("IdCliente").ToString
      cmbCliente.Text = drCabContrato.Item("NombreCliente").ToString
      txtAlcance.Text = drCabContrato.Item("Alcance").ToString
      txtContrato.Text = drCabContrato.Item("NumContrato").ToString
      txtValor.Text = CDec(drCabContrato.Item("Valor").ToString).ToString(FCTOTOT)
      dtpFechaIni.Value = drCabContrato.Item("Fecha_Ini").ToString
      dtpFechaFin.Value = drCabContrato.Item("Fecha_Fin").ToString

      If drCabContrato.Item("Estado").ToString = "A" Then
        chkEstado.Checked = False
      Else
        chkEstado.Checked = True
      End If


      Dim drAnexos As MSSQL.SqlDataReader
      mTablaAnexos = CreaTablaAnexos()
      drAnexos = objCntv.LeerValor("*", "AnexosContratos", "Cab_ID =" & mCabContratoId.ToString & " and estado='A'", strCadena)
      lstAnexos.Items.Clear() : mVctAnexos.Clear()

      Do
          If drAnexos.HasRows = True Then
              lstAnexos.Items.Add(IO.Path.GetFileName(drAnexos.Item("RutaArchivo").ToString), True)
              mVctAnexos.Add(drAnexos.Item("RutaArchivo").ToString)

              Dim mFila As DataRow = mTablaAnexos.NewRow
              mFila.Item("id") = drAnexos.Item("id")
              mFila.Item("RutaArchivo") = drAnexos.Item("RutaArchivo")
              mFila.Item("NombreArchivo") = IO.Path.GetFileName(drAnexos.Item("RutaArchivo"))
              mFila.Item("Estado") = drAnexos.Item("Estado")
              mTablaAnexos.Rows.Add(mFila)
          End If
      Loop While drAnexos.Read()

      If lstAnexos.Items.Count > 0 Then
          Call CargaImagen(mVctAnexos(1).ToString, False)
      End If

      mCntAnexos = lstAnexos.Items.Count



     Catch ex As System.InvalidCastException

        Catch ex As Exception
            MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

  End Sub



#End Region

  Private Sub mnuAbrirPdf_Click(sender As Object, e As System.EventArgs) Handles mnuAbrirPdf.Click
    Dim mLista = lstAnexos
    'Dim mLista = CType(sender, CheckedListBox)
    Dim strArchivo As String
    If lstAnexos.Items.Count = 1 Then
      strArchivo = mVctAnexos(1).ToString
       Call CargaImagen(mVctAnexos(1).ToString, True)
    Else
      strArchivo = mVctAnexos(mLista.SelectedIndex + 1).ToString()
       Call CargaImagen(mVctAnexos(mLista.SelectedIndex + 1).ToString, True)
    End If



  End Sub
End Class