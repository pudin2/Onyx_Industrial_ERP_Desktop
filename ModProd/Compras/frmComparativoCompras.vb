Option Explicit On
Imports MSSQL = System.Data.SqlClient


Public Class frmComparativoCompras
  Private mTablaCotizaciones As DataTable, mVctCotizaciones(3, 0) As Integer
  Private mTabla As DataTable
  Public mUsuario_Id As Integer
  Private FCANT As String = My.Settings.FormatoCantidad
  Private FCTO_U As String = My.Settings.FormatoC_U
  Private FCTOTOT As String = My.Settings.FormatoCostoTotal


  Private Sub btnMenuLista_Click(sender As System.Object, e As System.EventArgs) Handles btnMenuLista.Click
    Call OcultarMenu()
  End Sub
  Private Sub OcultarMenu()
    If pnlDerecha.Height = 22 Then
      pnlDerecha.Height = Me.Height - 39
      pnlDerecha.BringToFront()
    Else
      pnlDerecha.Height = 22
    End If
  End Sub

    Private Sub frmPedidos_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim mBoton As Button = Me.Tag
        Try
          frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
          'no hago nada
        End Try
  End Sub


  Private Sub frmComparativoCompras_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad, Ff As Integer, mWhere As String

    mWhere = "Estado='C' and Fecha BETWEEN (DATEADD (DD, (SELECT CONVERT(INT, VALOR)*-1 FROM Parametros WHERE ID=23), GETDATE())) 	AND GETDATE()"

    mTablaCotizaciones = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_ConsultaCabCotizacionProveedor", mWhere, "Order by cotizacion")
    chkCotizaciones.Items.Clear()

    For Ff = 0 To mTablaCotizaciones.Rows.Count - 1
      chkCotizaciones.Items.Add(mTablaCotizaciones.Rows(Ff).Item("COTIZACION") & " - " & mTablaCotizaciones.Rows(Ff).Item("PROVEEDOR"))
    Next

    pnlDerecha.Height = 22
    pnlDerecha.SendToBack()

    'pnlDerecha.Height = 22 'Me.Height - 39
    obCntv = Nothing
    btnOrdenCompra.Visible = False

  End Sub

  Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
    Dim obCntv As New clConectividad, Ff As Integer, Cc As Integer, strParametros As String = ""
    Dim strTitulo As String = "", Ii As Integer = 0



    Call OcultarMenu()

    For Ff = 0 To chkCotizaciones.Items.Count - 1
      If chkCotizaciones.GetItemChecked(Ff) = True Then
          strParametros = strParametros & mTablaCotizaciones.Rows(Ff).Item("COTIZACION").ToString & ","
          Ii = Ii + 1
      End If
    Next

    ReDim mVctCotizaciones(Ii, 3) 'borro todo


    'SALE DEL PROCESO SI NO SE HAN SELECCIONADO COTIZACIONES
    If strParametros = "" Then
      MessageBox.Show("No ha seleccionado cotizaciones de proveedor para comparar!", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
      Exit Sub
    End If

    strParametros = "'" & Mid(strParametros, 1, Len(strParametros) - 1) & "'"   '"'180016, 180017'"
    mTabla = obCntv.LlenarDataTable(My.Settings.cnnModProd, True, "PA_ConsultacCombinacionCotizaciones", strParametros, "PA_ConsultacCombinacionCotizaciones")


     With grComparativo
        For Cc = 0 To .Columns.Count - 1
          .Columns.RemoveAt(0)
        Next

        .Columns.Add("FilaTabla", "FilaTabla")
        .Columns.Add("CabSol_Id", "CabSol_Id")
        .Columns.Add("DetSol_Id", "DetSol_Id")
        .Columns.Add("Cod Producto", "COD PRODUCTO")
        .Columns.Add("Producto", "PRODUCTO")
        .Columns.Add("Cantidad", "CANTIDAD")
        .Columns.Add("Medida", "MEDIDA")

        'EL PRIMER BLOQUE, EL COTENIDO QUE SE REPITE SIEMPRE
        For Ff = 0 To mTabla.Rows.Count - 1
          .Rows.Add()
          .Rows(Ff).Cells(0).Value = Ff
          For Cc = 1 To 6
            .Rows(Ff).Cells(Cc).Value = mTabla.Rows(Ff).Item(Cc - 1)
          Next Cc
        Next Ff

        Ii = 0 'Reinicio el contador
        Dim CntCols As Integer = 2

        'EL SEGUNDO BLOQUE, LAS COTIZACIONES SELECCIONADAS
        For Cc = 7 To mTabla.Columns.Count - 1
            Dim drCotiza As MSSQL.SqlDataReader
            drCotiza = obCntv.LeerValor("id, COTIZACION, PROVEEDOR", "VW_ConsultaCabCotizacionProveedor", "COTIZACION=" & mTabla.Columns(Cc).ColumnName.ToString, My.Settings.cnnModProd)

            strTitulo = mTabla.Columns(Cc).ColumnName.ToString & vbCrLf & drCotiza.Item("PROVEEDOR")
            'obCntv.LeerValorSencillo("PROVEEDOR", "VW_ConsultaCabCotizacionProveedor", "COTIZACION=" & mTabla.Columns(Cc).ColumnName.ToString, My.Settings.cnnModProd)
            .Columns.Add(mTabla.Columns(Cc).ColumnName.ToString, strTitulo & vbCrLf & "COSTO") ': Ii = Ii + 1

            mVctCotizaciones(Ii, 0) = Cc '.Columns.Count
            mVctCotizaciones(Ii, 1) = drCotiza.Item("COTIZACION")
            mVctCotizaciones(Ii, 2) = drCotiza.Item("Id")
            Ii = Ii + 1

            drCotiza = Nothing

            .Columns.Add(New DataGridViewTextBoxColumn)
            .Columns(.Columns.Count - 1).Name = "TXT_CNT_" & mTabla.Columns(Cc).ColumnName.ToString
            .Columns(.Columns.Count - 1).HeaderText = strTitulo & vbCrLf & "CANTIDAD"
            .Columns(.Columns.Count - 1).ReadOnly = True


            .Columns.Add(New DataGridViewCheckBoxColumn)
            .Columns(.Columns.Count - 1).Name = "CHK_" & mTabla.Columns(Cc).ColumnName.ToString : .Columns(.Columns.Count - 1).HeaderText = ""

            
            For Ff = 0 To mTabla.Rows.Count - 1
                .Rows(Ff).Cells(.Columns.Count - (CntCols + 1)).Value = mTabla.Rows(Ff).Item(Cc)

                If IsDBNull(mTabla.Rows(Ff).Item(Cc)) Then
                  .Rows(Ff).Cells(.Columns.Count - CntCols).ReadOnly = True
                  .Rows(Ff).Cells(.Columns.Count - CntCols).Style.BackColor = Color.FromArgb(240, 240, 240) 'Color.Gray

                  .Rows(Ff).Cells(.Columns.Count - (CntCols + 1)).ReadOnly = True
                  .Rows(Ff).Cells(.Columns.Count - (CntCols + 1)).Style.BackColor = Color.FromArgb(240, 240, 240) ' Color.Gray

                End If
            Next
        Next
        Call FormatoGrilla()
    End With


    btnOrdenCompra.Visible = True
    obCntv = Nothing
  End Sub

 
  Private Sub FormatoGrilla()
      Dim Cc As Integer, strtemp As String = ""

      With grComparativo
        For Cc = 0 To .Columns.Count - 1
          .Columns(Cc).HeaderText = .Columns(Cc).HeaderText.ToUpper
          .Columns(Cc).ReadOnly = True
          .Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
          .Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        Next

        .Columns("FilaTabla").Visible = False
        .Columns("CabSol_Id").Visible = False
        .Columns("DetSol_Id").Visible = False

        .Columns("CANTIDAD").DefaultCellStyle.Format = "N2" : .Columns("CANTIDAD").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        .Columns("COD PRODUCTO").Width = 130
        .Columns("PRODUCTO").Width = 380
        .Columns("CANTIDAD").Width = 80
        .Columns("MEDIDA").Width = 80

        .EnableHeadersVisualStyles = False


        Dim Ii As Integer = 7, CntCols As Integer = 3, ColorOn As Boolean = False
        For Cc = 7 To mTabla.Columns.Count - 1
          'la columna del check
          .Columns(Ii + (CntCols - 1)).Width = 25 : .Columns(Ii + (CntCols - 1)).ReadOnly = False

          'la columna de la cantidad a compra con el proveedor
          .Columns(Ii + (CntCols - 2)).ReadOnly = True
          .Columns(Ii + (CntCols - 2)).DefaultCellStyle.Format = "N2"
          .Columns(Ii + (CntCols - 2)).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

          .Columns(Ii).DefaultCellStyle.Format = "N2" : .Columns(Ii).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
          .Columns(Ii).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

          ColorOn = Not ColorOn
          If ColorOn = True Then
              Dim Xx As Integer
              For Xx = Ii To Ii + CntCols - 1
                .Columns(Xx).HeaderCell.Style.BackColor = Color.LightSteelBlue
              Next Xx
          End If
          Ii = Ii + CntCols '2
        Next
      End With
  End Sub


  Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
      Call FormatoGrilla()
  End Sub

  Private Sub btnOrdenCompra_Click(sender As System.Object, e As System.EventArgs) Handles btnOrdenCompra.Click
    Dim Cc As Integer, Ff As Integer, strId As String = "", FfTabla As Integer, Ii As Integer = 1
    Dim obCntv As New clConectividad, dteFechaEntrega As Date, strProveedor_Id = "0", Xx As Integer = 0
    Dim strNumerosOC As String = "", CntCols As Integer, Ic As Integer

    Ic = 5 : CntCols = 3
    For Cc = 7 To mTabla.Columns.Count - 1
        Dim obCompras As New clCompras
        Ii = 1

        For Ff = 0 To grComparativo.Rows.Count - 1
            If grComparativo.Rows(Ff).Cells("CHK_" & mTabla.Columns(Cc).ColumnName.ToString).Value = True Then
                Dim mFilaDetOC = obCompras.TablaDetOCompra.NewDetOCompraRow
                FfTabla = grComparativo.Rows(Ff).Cells("FilaTabla").Value
                Dim strWhere As String

                strWhere = "COTIZACION = " & mTabla.Columns(Cc).ColumnName.ToString & " and cabsol_Id=" & _
                            mTabla.Rows(FfTabla).Item("CabSol_Id").ToString & " and detsol_Id=" & mTabla.Rows(FfTabla).Item("DetSol_Id").ToString

                Dim mFilaCot As MSSQL.SqlDataReader = obCntv.LeerValor("*", "VW_ConsultaCotizacionProveedor", strWhere, My.Settings.cnnModProd)
                dteFechaEntrega = mFilaCot.Item("FECHAENTREGA")
                strProveedor_Id = mFilaCot.Item("Proveedor_Id")

                mFilaDetOC("Cab_Id") = 0
                mFilaDetOC("Id") = Ii
                mFilaDetOC("CodInventario") = mTabla.Rows(FfTabla).Item("PRODUCTO").ToString
                mFilaDetOC("Inventario_Id") = mTabla.Rows(FfTabla).Item("COD PRODUCTO").ToString
                mFilaDetOC("Cant") = grComparativo.Rows(Ff).Cells(Ic + CntCols).Value 'mTabla.Rows(FfTabla).Item("CANTIDAD").ToString
                mFilaDetOC("Unidad_Id") = mTabla.Rows(FfTabla).Item("IdUnidad").ToString
                mFilaDetOC("Estado") = "A"
                mFilaDetOC("Costo") = mTabla.Rows(FfTabla).Item(Cc).ToString
                mFilaDetOC("CabCot_Id") = mFilaCot.Item("ID")
                mFilaDetOC("DetCot_Id") = mFilaCot.Item("DET_ID")

                obCompras.TablaDetOCompra.Rows.Add(mFilaDetOC)
                Ii = Ii + 1 : Xx = Xx + 1
            End If
        Next

        If obCompras.TablaDetOCompra.Rows.Count > 0 Then
            Ii = BuscarFilaVector(Cc)
            Dim mCabCot_Id As Integer = mVctCotizaciones(Ii, 2)

            Dim maxId As String = obCntv.LeerValorSencillo("ISNULL(MAX(id),0)+1 [Id]", "ID", "CabOCompra", "1=1", My.Settings.cnnModProd)
            obCompras.GrabarOrdenCompra(My.Settings.cnnModProd, maxId, Today.ToString, mUsuario_Id, "R", strProveedor_Id, CabCot_Id:=mCabCot_Id)

            'ACTUALIZO EL ESTADO DEL DETALLE DEL PEDIDO, EN ESTADO COTIZADO: 'OCR' = ORDEN DE COMPRA REGISTRADA
            obCntv.EjecutaComando("EXEC PA_ActualizaEstadoPedido 'OCR'," & maxId.ToString, My.Settings.cnnModProd, False)


            strNumerosOC = strNumerosOC & maxId.ToString & ", "
        End If
      Ic = Ic + CntCols
    Next

    If Xx > 0 Then
      strNumerosOC = Mid(strNumerosOC, 1, Len(strNumerosOC) - 2)
      MessageBox.Show("Ordenes de compra creadas: " & vbCrLf & strNumerosOC, "Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Else
      MessageBox.Show("Debe seleccionar por lo menos un ítem", "Orden de compra", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End If
  End Sub



 'PARA BUSCAR EL ITEM DENTRO DEL VECTOR
  Private Function BuscarFilaVector(Columna As Integer) As Integer
    Dim Ii As Integer, Salida As Integer
    For Ii = 0 To mVctCotizaciones.GetUpperBound(0) - 1
      If mVctCotizaciones(Ii, 0) = Columna Then
        Salida = Ii
        Exit For
      End If

    Next
    Return Salida
  End Function


  Private Sub grComparativo_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grComparativo.CellEndEdit
    Dim mGr As DataGridView = CType(sender, DataGridView)
    Dim ColIni As Integer = 8

    Dim X As Integer

    X = (e.ColumnIndex - ColIni) Mod 3 'la tercera segunda columna (Cantidad) de la serie de cotizaciones
    If X = 0 Then
      Dim mCant As Decimal

      Try
        mCant = CDec(IIf(mGr.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "", 0, mGr.Rows(e.RowIndex).Cells(e.ColumnIndex).Value))
      Catch ex As System.InvalidCastException
        MessageBox.Show("Esta celda solo acepta valores numéricos!", "Error de datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        grComparativo.CancelEdit()
      End Try

      'valido y pregunto si la cantidad acumulada del producto es correcta
      Dim Cc As Integer, Acum As Decimal, mCantPedido As Decimal, Ii As Integer, CntCols As Integer = 3

      mCantPedido = grComparativo.Rows(e.RowIndex).Cells("CANTIDAD").Value
      Cc = 5
      For Ii = 7 To mTabla.Columns.Count - 1
        Acum = Acum + grComparativo.Rows(e.RowIndex).Cells(Cc + CntCols).Value
        Cc = Cc + CntCols
      Next Ii

      If Acum > mCantPedido Then
        If MessageBox.Show("Esta acumulando mas unidades de las solicitadas. Desea continuar?", "Total unidades", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = Windows.Forms.DialogResult.No Then
          mCant = 0
        End If
      End If

       'escribo el valor formateado
      mGr.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = CDec(mCant).ToString(FCANT)
    End If

    'If Mid(grComparativo.Columns(e.ColumnIndex).Name, 1, 4) = "CHK_" And e.RowIndex >= 0 Then
    '  Call HabilitarCelda(e.ColumnIndex, e.RowIndex, grComparativo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

    'End If


  End Sub

  'Private Sub grComparativo_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grComparativo.CellMouseClick
  '  If Mid(grComparativo.Columns(e.ColumnIndex).Name, 1, 4) = "CHK_" And e.RowIndex >= 0 Then
  '    Call HabilitarCelda(e.ColumnIndex, e.RowIndex, grComparativo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)
  '  End If
  'End Sub

  Private Sub HabilitarCelda(Columna As Integer, Fila As Integer, mEstado As Boolean)
    grComparativo.Item(Columna - 1, Fila).ReadOnly = Not mEstado

    If mEstado = False Then
      grComparativo.Rows(Fila).Cells(Columna - 1).Value = CDec(0).ToString(FCANT)
    End If
  End Sub

Private Sub grComparativo_CellMouseUp(sender As System.Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles grComparativo.CellMouseUp
  grComparativo.CommitEdit(DataGridViewDataErrorContexts.Commit)
End Sub


  Private Sub grComparativo_CellValueChanged(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grComparativo.CellValueChanged

    If Mid(grComparativo.Columns(e.ColumnIndex).Name, 1, 4) = "CHK_" And e.RowIndex >= 0 Then
      Call HabilitarCelda(e.ColumnIndex, e.RowIndex, grComparativo.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

    End If

  End Sub
End Class