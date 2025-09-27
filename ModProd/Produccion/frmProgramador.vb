Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms
Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Windows.Forms.DataVisualization.Charting




Public Class frmProgramador
    Private mNumOrden As Integer, mNumOrden_Cab_Id As Integer
    Private Sep As Char, mNumRemision As Integer
    Private FCANT As String = My.Settings.FormatoCantidad
    Private FCTO_U As String = My.Settings.FormatoC_U
    Private FCTOTOT As String = My.Settings.FormatoCostoTotal
    Private strIdCliente As String, strNombreCliente As String
    Private mUsuarioId As Integer
    Private vctItems() As Integer
    Private dtProg As New DataTable()
    Private strOperario_Id As String
    Private mSubT_Id As Integer, mSubT_Desc As String
    Private mObProd As New clProduccion
    Private mCntSubTProgramadas As Integer
    Private mProgCab_Id As String


    Public Property UsuarioId As Integer
    Get
      Return mUsuarioId
    End Get
    Set(ByVal value As Integer)
      mUsuarioId = value
    End Set
  End Property

    Private Sub btnBotonera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBotonera.Click
        If flyPanelBotones.Width = 190 Then
            flyPanelBotones.Width = 45
            'grpDetalle.Width = grpDetalle.Width + (190 - 45)
        Else
            flyPanelBotones.Width = 190
            'grpDetalle.Width = grpDetalle.Width - (190 - 45)
    End If
    End Sub



    Private Sub frmProgramador_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

      'If mPreguntaSalida = True Then
      '  If mModoLiquidacionVentaDirecta = False Then
      '      If MsgBox(LeerEtqTextoXml("msgTextoSalir"), MsgBoxStyle.YesNo + MsgBoxStyle.Critical, "Cerrando cotización") = MsgBoxResult.No Then
      '          e.Cancel = True
      '      End If


            Call CerrarControlBarra()
      '  Else 'SALIDA DE VENTA DIRECTA
      '      'PROGRAMAR

      '  End If
      'End If

    End Sub


  Private Sub frmProgramador_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Dim obCntv As New clConectividad, obInicio As New clSetUpInicio

      ''Detectar el separador decimal de la aplicación.
      Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

      Dim mUsuario As String, mDominio As String ', obInicio As New clSetUpInicio
      mUsuario = obInicio.Usuario 'Environment.UserName '& Environment.UserName.GetHashCode
      mDominio = obInicio.Dominio  'Environment.UserDomainName
      obInicio = Nothing

      'DATA TABLE PARA PROGRAMCACION Y ORDEN
      dtProg.Columns.Add("SubT_Desc")
      dtProg.Columns.Add("SubT_Id")
      dtProg.Columns.Add("Orden")


      'PARTE DE LA CARGA DE LOS OPERARIOS
      cmbOperarios.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
      cmbOperarios.DisplayMember = "NombreMostrar"

      cmbOperariosConsulta.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
      cmbOperariosConsulta.DisplayMember = "NombreMostrar"


      

      'Call FormatoGrilla()

      ''TEMPORAL PARA LLENAR EL VECTOR
      'ReDim vctItems(lstPrograma.Items.Count - 1)
      'Dim ii As Integer

      'For ii = 0 To lstPrograma.Items.Count - 1
      '  vctItems(ii) = ii + 1
      'Next
      dtpFF_SubT.Value = DateAdd(DateInterval.Day, 8, Date.Today)
      dtpFF_Prog.Value = DateAdd(DateInterval.Day, 8, Date.Today)


      btnImprimir.Visible = True
    End Sub

    Private Sub CerrarControlBarra()
      Dim mBoton As Button = Me.Tag
      Try
        frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
      Catch ex As System.NullReferenceException
        'no hago nada
      End Try
  End Sub

  'Private Sub btnArriba_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
  '  Dim Ii As Integer, Nn As Integer
  '  Dim q As New ArrayList
  '  Dim mVct() As Integer = vctItems.Clone
  '  Dim strtest As String = ""

  '  If lstPrograma.Items.Count > 1 Then
  '    Ii = lstPrograma.SelectedIndex

  '    If Ii > 0 Then
  '      For Each o As Object In lstPrograma.Items
  '          q.Add(o)
  '      Next

  '      lstPrograma.Items.Clear()

  '      For Nn = 0 To Ii - 2
  '        lstPrograma.Items.Add(q(Nn))
  '      Next

  '      lstPrograma.Items.Add(q(Ii))
  '      lstPrograma.Items.Add(q(Ii - 1))

  '      mVct(Ii - 1) = vctItems(Ii)
  '      mVct(Ii) = vctItems(Ii - 1)
  '      vctItems = mVct

  '      For Nn = Ii + 1 To q.Count() - 1
  '        lstPrograma.Items.Add(q(Nn))
  '      Next

  '      lstPrograma.SelectedIndex = Ii - 1

  '      '***********************************************
  '      'VERIFICACIÓN

  '      For Nn = 0 To mVct.Count - 1
  '        strtest = strtest & mVct(Nn) & vbCrLf
  '      Next Nn
  '      TextBox1.Text = ""
  '      TextBox1.Text = strtest
  '      '***********************************************



  '    End If
  '  End If


  'End Sub

'Private Sub btnAbajo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
'  Dim Ii As Integer, Nn As Integer
'  Dim mVct() As Integer = vctItems.Clone
'  Dim q As New ArrayList
'  Dim strTest As String = ""

'    If lstPrograma.SelectedIndex < lstPrograma.Items.Count - 1 Then
'      Ii = lstPrograma.SelectedIndex

'      'If Ii > 0 Then
'        For Each o As Object In lstPrograma.Items
'            q.Add(o)
'        Next

'        lstPrograma.Items.Clear()

'        For Nn = 0 To Ii - 1
'          lstPrograma.Items.Add(q(Nn))
'        Next

'        lstPrograma.Items.Add(q(Ii + 1))
'        lstPrograma.Items.Add(q(Ii))

'        mVct(Ii + 1) = vctItems(Ii)
'        mVct(Ii) = vctItems(Ii + 1)
'        vctItems = mVct


'        For Nn = Ii + 2 To q.Count() - 1
'          lstPrograma.Items.Add(q(Nn))
'        Next

'        lstPrograma.SelectedIndex = Ii + 1

'        '***********************************************
'        'VERIFICACIÓN

'        For Nn = 0 To mVct.Count - 1
'          strTest = strTest & mVct(Nn) & vbCrLf
'        Next Nn
'        TextBox1.Text = ""
'        TextBox1.Text = strTest
'        '***********************************************
'      'End If
'    End If

'End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    'Dim ObCntv As New clConectividad
    ''Dim StrConsulta As String


    ''PARTE DE LA CARGA DE LOS REPONSABLES
    'lstSubTareas.DataSource = ObCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_SubT", "Estado='A' and Id>0 and Operario_Id=" & strOperario_Id)
    'lstSubTareas.DisplayMember = "SubTarea"
    'DataGridView1.DataSource = dtProg

    Call CargarSubTareas()

End Sub

Private Sub CargarSubTareas()
    Dim ObCntv As New clConectividad

    'PARTE DE LA CARGA DE LOS REPONSABLES
    Dim dtlstSubTareas As DataTable = ObCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_SubT", _
        "Estado='A' and Id>0 and Operario_Id=" & strOperario_Id, _
        "order by numorden , item") 'Id

    lstSubTareas.DataSource = dtlstSubTareas
    ' ObCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_SubT", _
        '"Estado='A' and Id>0 and Operario_Id=" & strOperario_Id, _
        '"order by Id")

        '" and Fecha > '" & Format(dtpFI_SubT.Value.Date, "yyyyMMdd") & "'", "order by Id")

    lstSubTareas.DisplayMember = "SubTarea"
    'DataGridView1.DataSource = dtProg

    Dim Ff As Integer, mCntSubT As Integer, mCntHoras As Integer

    For Ff = 0 To dtlstSubTareas.Rows.Count - 1
      mCntHoras = mCntHoras + dtlstSubTareas.Rows(Ff).Item("Horas")
      mCntSubT = Ff + 1
    Next

    lblCntHoras3.Text = mCntHoras
    lblCntSubTareas3.Text = mCntSubT

    grPrograma.DataSource = Nothing
    grPrograma.Rows.Clear()
    mCntSubTProgramadas = grPrograma.Rows.Count

    Call CargarProg()


End Sub


Private Sub btnAdicionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdicionar.Click
  If lstSubTareas.Items.Count > 0 Then
    '********  Asignar DT
    Dim selectedItem As DataRowView
    selectedItem = lstSubTareas.SelectedItem
    mSubT_Id = selectedItem("id").ToString
    mSubT_Desc = selectedItem("SubTarea").ToString


    Dim row As DataRow = dtProg.NewRow()
    row("SubT_Desc") = mSubT_Desc
    row("SubT_Id") = mSubT_Id
    row("Orden") = grPrograma.RowCount + 1 'La asigno

    'lstSubTareas.Items(lstSubTareas.SelectedIndex).Visible = False 'La oculto par simular que ya está asignada

    Dim dtlstSubTareas As DataTable = lstSubTareas.DataSource
    Dim rr As DataRow = dtlstSubTareas.Rows(lstSubTareas.SelectedIndex)
    dtlstSubTareas.Rows.Remove(rr)

    dtProg.Rows.Add(row)
    grPrograma.DataSource = dtProg
    Call FormatoGrilla()
  End If
End Sub

Private Sub cmbOperarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperarios.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbOperarios.SelectedItem

    strOperario_Id = selectedItem("id").ToString
    'Label1.Text = strOperario_Id

    Call CargarSubTareas()
    Call BuscarDatosGrafica()
    If cmbOperarios.SelectedIndex > 0 Then
      cmbOperariosConsulta.SelectedIndex = cmbOperarios.SelectedIndex
    End If
    'dtProg.Rows.Clear()


End Sub

Private Sub cmbOperariosConsulta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOperariosConsulta.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbOperariosConsulta.SelectedItem

    strOperario_Id = selectedItem("id").ToString
    Call BuscarDatosGrafica()
    lblStrOperario_Id.Text = strOperario_Id

End Sub



Private Sub lstSubTareas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubTareas.SelectedIndexChanged
  Dim selectedItem As DataRowView
  selectedItem = lstSubTareas.SelectedItem

  mSubT_Id = selectedItem("id").ToString
  mSubT_Desc = selectedItem("SubTarea").ToString
End Sub

Private Sub btnRemover_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemover.Click
  If grPrograma.Rows.Count > 0 Then
    Dim ff As Integer = grPrograma.CurrentRow.Index

    ' Crear una nueva fila en el DataTable de destino
    Dim newRow As DataRow = lstSubTareas.DataSource.NewRow()

    ' Copiar los valores de la fila de origen a la fila de destino
    For Each column As DataColumn In dtProg.Columns
        newRow(column.ColumnName) = dtProg.Rows(ff)(column.ColumnName)
    Next

    ' Agregar la nueva fila al DataTable de destino
    lstSubTareas.DataSource.Rows.Add(newRow)

    ' Eliminar la fila del DataTable de origen
    dtProg.Rows.RemoveAt(ff)

  End If

End Sub



Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim Ii As Integer, Nn As Integer
    Dim ff As Integer = grPrograma.CurrentRow.Index


    Dim cloneDtProg As DataTable = dtProg.Copy
    Dim strtest As String = ""

    If grPrograma.RowCount > 1 Then
      Ii = grPrograma.CurrentRow.Index

      If Ii > 0 Then
        dtProg.Clear()

        For Nn = 0 To Ii - 2
          Dim row As DataRow = dtProg.NewRow()
          row("SubT_Desc") = cloneDtProg.Rows(Nn).Item("SubT_Desc")
          row("SubT_Id") = cloneDtProg.Rows(Nn).Item("SubT_Id")
          row("Orden") = grPrograma.RowCount + 1
          dtProg.Rows.Add(row)
        Next

        Dim rr As DataRow = dtProg.NewRow()
        rr("SubT_Desc") = cloneDtProg.Rows(Ii).Item("SubT_Desc")
        rr("SubT_Id") = cloneDtProg.Rows(Ii).Item("SubT_Id")
        rr("Orden") = grPrograma.RowCount + 1
        dtProg.Rows.Add(rr)

        rr = Nothing
        rr = dtProg.NewRow()
        rr("SubT_Desc") = cloneDtProg.Rows(Ii - 1).Item("SubT_Desc")
        rr("SubT_Id") = cloneDtProg.Rows(Ii - 1).Item("SubT_Id")
        rr("Orden") = grPrograma.RowCount + 1
        dtProg.Rows.Add(rr)

        For Nn = Ii + 1 To cloneDtProg.Rows.Count - 1
          Dim row As DataRow = dtProg.NewRow()
          row("SubT_Desc") = cloneDtProg.Rows(Nn).Item("SubT_Desc")
          row("SubT_Id") = cloneDtProg.Rows(Nn).Item("SubT_Id")
          row("Orden") = grPrograma.RowCount + 1
          dtProg.Rows.Add(row)
        Next
        grPrograma.DataSource = dtProg

        grPrograma.CurrentCell = grPrograma.Item(0, ff - 1)
        grPrograma.Rows(ff - 1).Selected = True
        Call FormatoGrilla()
      End If
    End If

End Sub


Private Sub FormatoGrilla()
  Dim miCol As DataGridViewColumn
  miCol = grPrograma.Columns(0) : miCol.Width = 400
  miCol = grPrograma.Columns(1) : miCol.Visible = False
  miCol = grPrograma.Columns(2) : miCol.Visible = False
  miCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

End Sub


Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
Dim Ii As Integer, Nn As Integer
    Dim ff As Integer = grPrograma.CurrentRow.Index


    Dim cloneDtProg As DataTable = dtProg.Copy
    Dim strtest As String = ""

    If grPrograma.CurrentRow.Index < grPrograma.Rows.Count - 1 Then 'grPrograma.RowCount > 1 Then
      Ii = grPrograma.CurrentRow.Index

      'If Ii > 0 Then
        dtProg.Clear()

        For Nn = 0 To Ii - 1
          Dim row As DataRow = dtProg.NewRow()
          row("SubT_Desc") = cloneDtProg.Rows(Nn).Item("SubT_Desc")
          row("SubT_Id") = cloneDtProg.Rows(Nn).Item("SubT_Id")
          row("Orden") = grPrograma.RowCount + 1
          dtProg.Rows.Add(row)
        Next

        Dim rr As DataRow = dtProg.NewRow()
        rr("SubT_Desc") = cloneDtProg.Rows(Ii + 1).Item("SubT_Desc")
        rr("SubT_Id") = cloneDtProg.Rows(Ii + 1).Item("SubT_Id")
        rr("Orden") = grPrograma.RowCount + 1
        dtProg.Rows.Add(rr)

        rr = Nothing
        rr = dtProg.NewRow()
        rr("SubT_Desc") = cloneDtProg.Rows(Ii).Item("SubT_Desc")
        rr("SubT_Id") = cloneDtProg.Rows(Ii).Item("SubT_Id")
        rr("Orden") = grPrograma.RowCount + 1
        dtProg.Rows.Add(rr)

        For Nn = Ii + 2 To cloneDtProg.Rows.Count - 1
          Dim row As DataRow = dtProg.NewRow()
          row("SubT_Desc") = cloneDtProg.Rows(Nn).Item("SubT_Desc")
          row("SubT_Id") = cloneDtProg.Rows(Nn).Item("SubT_Id")
          row("Orden") = grPrograma.RowCount + 1
          dtProg.Rows.Add(row)
        Next
        grPrograma.DataSource = dtProg

        grPrograma.CurrentCell = grPrograma.Item(0, ff + 1)
        grPrograma.Rows(ff + 1).Selected = True
        Call FormatoGrilla()
      'End If
    End If

End Sub

  Private Sub btnGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabar.Click
    Call GrabarPrograma()

    'Recargo los datos
    Call CargarSubTareas()
    Call BuscarDatosGrafica()

  End Sub


  Private Sub GrabarPrograma()
    Dim Ff As Integer
    Dim mObCntv As New clConectividad ', mCab_Id As Integer
    Dim mCab_Id As String

    'Dim mExiste As Integer = mObCntv.LeerValorSencillo("count(Id) Cant", "Cant", "CabProg", "Operario_Id = " & strOperario_Id & _
    '   " and FechaIni >='" & dtpFI_SubT_Prog.Value.Date & "' and FechaFin <= '" & dtpFF_SubT_Prog.Value.Date & "'", My.Settings.cnnModProd)

    Dim mExiste As Integer = mObCntv.LeerValorSencillo("count(Id) Cant", "Cant", "CabProg", "Operario_Id = " & strOperario_Id & _
       " and FechaIni >='" & dtpFI_SubT_Prog.Value.Date & "'", My.Settings.cnnModProd)


    If mExiste > 0 Then

      'mCab_Id = mObCntv.LeerValorSencillo("Id", "CabProg", "Operario_Id = " & strOperario_Id & " and FechaIni ='" & dtpFI_SubT_Prog.Value.Date & "'", My.Settings.cnnModProd)
      ''Inactivo todo para preveer los eliminados
      'Dim strCadena As String

      'mObCntv.ActualizaValor("ESTADO='A'", "CabSubT", "Id IN (SELECT SubTarea_Id  FROM DetProg WHERE Cab_Id = " & mCab_Id & " ) AND Tipo ='ST'", My.Settings.cnnModProd)

      'strCadena = "Delete from DetProg where estado <> 'I' and Cab_id=" & mCab_Id
      'mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

      'strCadena = "Delete from CabProg where id=" & mCab_Id
      'mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)


      'mCab_Id = mObCntv.LeerValorSencillo("Id", "CabProg", "Operario_Id = " & strOperario_Id & " and FechaIni ='" & dtpFI_SubT_Prog.Value.Date & "'", My.Settings.cnnModProd)
      'Inactivo todo para preveer los eliminados
      Dim strCadena As String

      'Actualizo las subtareas como no programadas
      mObCntv.ActualizaValor("ESTADO='A'", "CabSubT", "Id IN (SELECT SubTarea_Id  FROM DetProg WHERE Cab_Id in(" & mProgCab_Id & ")) AND Tipo ='ST'", My.Settings.cnnModProd)

      'Borro el detalle de las programaciones en memoria
      strCadena = "Delete from DetProg where estado <> 'I' and Cab_id in (" & mProgCab_Id & ")"
      mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)

      'Borro la cabecera de las programaciones en memoria
      strCadena = "Delete from CabProg where id in (" & mProgCab_Id & ")"
      mObCntv.EjecutaComando(strCadena, My.Settings.cnnModProd, False)


    End If

    Dim mOperario_Id As Integer = strOperario_Id


    'RECORRO CADA RENGLON DE LA GRILLA
    mCab_Id = mObCntv.LeerValorSencillo("ISNULL(MAX(id)+1,1) [MaxCabId]", "MaxCabId", "CabProg", "1=1", My.Settings.cnnModProd)

    For Ff = 0 To grPrograma.RowCount - 1
      Dim mFilaDetProg As DataRow = mObProd.TablaDetProg.NewRow

      mFilaDetProg.Item("Cab_Id") = 0
      mFilaDetProg.Item("Id") = Ff + 1


      mFilaDetProg.Item("SubTarea_Id") = grPrograma.Item("SubT_Id", Ff).Value
      mFilaDetProg.Item("Estado") = "A"
      mObProd.TablaDetProg.Rows.Add(mFilaDetProg)

    Next

    mObProd.GrabarProgramacion(My.Settings.cnnModProd, "INSERT", mCab_Id, mOperario_Id, dtpFI_SubT_Prog.Value.Date, "A", dtpFF_SubT_Prog.Value.Date)

    'Actualizo las subtareas a PROGRAMADAS con base en el nuevo ID
    mObCntv.ActualizaValor("ESTADO='P'", "CabSubT", "Id IN (SELECT SubTarea_Id  FROM DetProg WHERE Cab_Id = " & mCab_Id & ") AND Tipo ='ST'", My.Settings.cnnModProd)

    Dim mNuevoCab_Id As String = mObCntv.LeerValorSencillo("ISNULL(MAX(id),0) [MaxCabId]", "MaxCabId", "CabProg", "1=1", My.Settings.cnnModProd)
    Dim numeroConCeros As String = mNuevoCab_Id.ToString().PadLeft(6, "0")

    MessageBox.Show("Datos grabados con éxito!" & vbCrLf & vbCrLf & "Programa creado con el número " & numeroConCeros, "Grabar programación", MessageBoxButtons.OK, MessageBoxIcon.Information)

  End Sub



Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
    Try
      If mCntSubTProgramadas <> grPrograma.Rows.Count Then
        If MessageBox.Show("Desea guardar los cambios antes de imprimir?", "Salvar cambios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Call GrabarPrograma()
        End If
      End If


        Dim strRutaApp As String = System.AppDomain.CurrentDomain.BaseDirectory()
        Dim obXml As New clManejoXML

        obXml.AbrirXml(strRutaApp & "\Resources\ModProdUiRpt.xml")
        obXml.OrdenaPor = "Label_Id" : obXml.Campo = "Label_name"

        'INICIO LA ASIGNACIÓN DE CAMPOS
        Dim strMargenes As String = obXml.LeerValor("frmImprimeProg")
        Dim Pg2 As New System.Drawing.Printing.PageSettings()
        Dim Size2 = New Printing.PaperSize()
        Dim vctMedidas2() As String
        vctMedidas2 = Split(strMargenes, ",")
        Pg2.Margins.Top = CInt(vctMedidas2(0))
        Pg2.Margins.Bottom = CInt(vctMedidas2(1))
        Pg2.Margins.Left = CInt(vctMedidas2(2))
        Pg2.Margins.Right = CInt(vctMedidas2(3))
        Pg2.PaperSize.RawKind = System.Drawing.Printing.PaperKind.Letter


        'Dim strOrden As String = txtNumOrden.Text  'InputBox("Número de Orden de Trabajo")
        Dim frm As New frmImprimeProg
        frm.dteFecha = dtpFI_SubT.Value.Date
        frm.intOperario_Id = strOperario_Id
        frm.strNombreReporte = obXml.LeerValor("rptImprimeProg")


        frm.Show()

    Catch ex As System.InvalidCastException

    Catch ex As Exception
      MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    End Try
End Sub

Private Sub dtpFI_SubT_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFI_SubT.ValueChanged, dtpFF_SubT.ValueChanged
    dtpFI_SubT_Prog.Value = dtpFI_SubT.Value
    dtpFF_SubT_Prog.Value = dtpFF_SubT.Value


    Call CargarSubTareas()
    Call BuscarDatosGrafica()
    If cmbOperarios.SelectedIndex > 0 Then
      cmbOperariosConsulta.SelectedIndex = cmbOperarios.SelectedIndex
    End If
End Sub

Private Sub lstSubTareas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstSubTareas.Click

End Sub


Private Sub lstSubTareas_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstSubTareas.MouseDown
  If e.Button = Windows.Forms.MouseButtons.Right Then
    Dim Frm As New frmCambiaResponsable
    Frm.txtSubtarea.Text = mSubT_Desc

      'mSubT_Id = selectedItem("id").ToString
      ' mSubT_Desc = selectedItem("SubTarea").ToString
    Frm.CabSubT_Id = mSubT_Id
    Frm.ShowDialog()
    'mNumOrden = "%"

    'Dim dtConsulta As DataTable

    If Frm.DialogResult = Windows.Forms.DialogResult.OK Then
      'RE CARGO LA LISTA DE SUB TAREAS
      Call CargarSubTareas()


    End If
    End If
End Sub


Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
  Call BuscarDatosGrafica()
End Sub

Private Sub BuscarDatosGrafica()

  Dim obCntv As New clConectividad
    Dim strWhere As String = "Operario_Id=" & strOperario_Id & " and fechaIni>='" & dtpFI_SubT_Prog.Value.Date & "'" ' and fechaFin <= '" & dtpFF_Prog.Value.Date & "'"


    Chart1.DataSource = Nothing
    Dim mTable As DataTable = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "vw_GraficoProgramacion", strWhere)


    If mTable.Rows.Count > 0 Then
      lblSiDatos.Visible = False
      PlotHorizontalBarChart(mTable, "Programación diaria", "Fecha", "Horas")
    Else
      Chart1.Series.Clear()
      lblSiDatos.Visible = True

    End If

    Dim mCntHoras As Integer, mCntSubT As Integer
    Dim Ff As Integer

    For Ff = 0 To mTable.Rows.Count - 1
      mCntHoras = mCntHoras + mTable.Rows(Ff).Item("CntHoras")
      mCntSubT = mCntSubT + mTable.Rows(Ff).Item("CntSubT")
    Next Ff

    lblCntHoras.Text = mCntHoras
    lblCntSubTareas.Text = mCntSubT

    lblCntHoras2.Text = mCntHoras
    lblCntSubTareas2.Text = mCntSubT


    mTable = Nothing


End Sub



Private Sub PlotHorizontalBarChart(ByVal data As DataTable, ByVal chartTitle As String, ByVal xTitle As String, ByVal yTitle As String)
    ' Crear un control de Chart
    'Dim chart1 As New Chart()
    'chart1.Location = New Point(78, 94)
    'chart1.Size = New Size(900, 500)
    'Me.Controls.Add(chart1)
    Chart1.Series.Clear()
    ' Configurar la gráfica
    'chart1.ChartAreas.Add("ChartArea1")
    Chart1.Series.Add("Series1")
    chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Font = New Font("Arial", 8.0F)
    chart1.ChartAreas("ChartArea1").AxisY.LabelStyle.Font = New Font("Arial", 8.0F)
    chart1.ChartAreas("ChartArea1").AxisX.Title = xTitle
    chart1.ChartAreas("ChartArea1").AxisY.Title = yTitle
    'Chart1.Titles.Item(0).Text = chartTitle
    'chart1.Titles.Add(chartTitle)
    chart1.Series("Series1").Color = Color.Blue
    chart1.Series("Series1").IsValueShownAsLabel = True
    chart1.Series("Series1").CustomProperties = "DrawSideBySide=False"

    ' Agregar datos a la gráfica


    For Each row As DataRow In data.Rows
        'Chart1.Series("Series1").Points.AddXY(CDate(row("FechaIni")), row("CntHoras"))
        Chart1.Series("Series1").Points.AddXY(Format(row("FechaIni"), "dd/MM/yyyy"), row("CntHoras"))
    Next



    'tbpConsulta.Controls.Add(chart1)
    
    chart1.ChartAreas("ChartArea1").AxisX.MajorGrid.Enabled = False
    chart1.ChartAreas("ChartArea1").AxisY.MajorGrid.Enabled = False
    chart1.ChartAreas("ChartArea1").AxisX.MinorGrid.Enabled = False
    chart1.ChartAreas("ChartArea1").AxisY.MinorGrid.Enabled = False

End Sub

  Private Sub CargarProg()
    dtProg.Rows.Clear()
    mProgCab_Id = ""
    lblProgCab_Id.Text = ""


    Dim ObCntv As New clConectividad
    Dim mdrProg As MSSQL.SqlDataReader

    mdrProg = ObCntv.LeerValor("*", "VW_Programacion", "operario_Id= " & strOperario_Id & " and fechaIni>='" & dtpFI_SubT_Prog.Value.Date & "'", My.Settings.cnnModProd)

    If mdrProg.HasRows Then
      Do

        Dim row As DataRow = dtProg.NewRow()
        row("SubT_Desc") = mdrProg.Item("SubTarea")
        row("SubT_Id") = mdrProg.Item("CabSubT_Id")
        row("Orden") = mdrProg.Item("NumOrden")

        'Elimino los repetidos
        mProgCab_Id = mProgCab_Id.Replace(mdrProg.Item("Id") & ", ", "")
        'Agrego el nuevo valor
        mProgCab_Id = mProgCab_Id & mdrProg.Item("Id") & ", "
        dtProg.Rows.Add(row)

      Loop While mdrProg.Read()

      grPrograma.DataSource = dtProg
      mProgCab_Id = Mid(mProgCab_Id, 1, Len(mProgCab_Id) - 2)
      lblProgCab_Id.Text = "Código (s) programación: " & mProgCab_Id

      Call FormatoGrilla()
    End If




  End Sub

End Class