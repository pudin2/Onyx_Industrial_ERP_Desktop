Public Class frmValidaResumenes


    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        Call CargarResumenes()
        'Me.Cursor = Cursors.WaitCursor
        'Dim obCntv As New clConectividad
        'Dim strCampos
        'Dim strCadena As String
        'Dim strWhere As String

        'grResumen.Columns.Clear()
        'strCadena = Now.TimeOfDay.ToString

        'If optOTSinValidar.Checked = True Then
        '    strWhere = "Estado = 'R'" 'and EtapaTerminada = 0"
        'ElseIf optOTValidadas.Checked = True Then
        '    strWhere = "Estado = 'V'"
        'Else
        '    strWhere = "Estado<>'I'"
        'End If

        'strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

        'strCampos = " distinct NumOrden [ORDEN], ResCab_ID [Numero Resumen],NombreCliente [CLIENTE], NombreProyecto [PROYECTO], DescripcionSubT [DESCRIPCION] , Alcance [ALCANCE] "
        'grResumen.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_ResumenProduccion", strWhere)

        'If optOTSinValidar.Checked = True Then
        '    With grResumen
        '        Dim mBoton As New DataGridViewButtonColumn()
        '        mBoton.Name = "btnValidar"
        '        mBoton.Text = "Validar"
        '        mBoton.UseColumnTextForButtonValue = True
        '        mBoton.HeaderText = ""
        '        .Columns.Add(mBoton)
        '    End With
        'End If

        'grResumen.Columns(0).Width = 80
        'grResumen.Columns(1).Width = 80
        'grResumen.Columns(2).Width = 150
        'grResumen.Columns(3).Width = 150
        'grResumen.Columns(4).Width = 150
        'grResumen.Columns(5).Width = 300


        'Dim Cc As Integer
        'For Cc = 0 To grResumen.Columns.Count - 1
        '    grResumen.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        '    grResumen.Columns(Cc).ReadOnly = True
        '    grResumen.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        'Next

        'Me.Cursor = Cursors.Default
    End Sub

    Private Sub CargarResumenes()
        Me.Cursor = Cursors.WaitCursor
        Dim obCntv As New clConectividad
        Dim strCampos
        Dim strCadena As String
        Dim strWhere As String

        grResumen.Columns.Clear()
        strCadena = Now.TimeOfDay.ToString

        If optOTSinValidar.Checked = True Then
            strWhere = "Estado = 'R'" 'and EtapaTerminada = 0"
        ElseIf optOTValidadas.Checked = True Then
            strWhere = "Estado = 'V'"
        Else
            strWhere = "Estado<>'I'"
        End If

        strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

        strCampos = " distinct NumOrden [ORDEN], ResCab_ID [Numero Resumen],NombreCliente [CLIENTE], NombreProyecto [PROYECTO], DescripcionSubT [DESCRIPCION] , Alcance [ALCANCE] "
        grResumen.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_ResumenProduccion", strWhere)

        If optOTSinValidar.Checked = True Then
            With grResumen
                Dim mBoton As New DataGridViewButtonColumn()
                mBoton.Name = "btnValidar"
                mBoton.Text = "Validar"
                mBoton.UseColumnTextForButtonValue = True
                mBoton.HeaderText = ""
                .Columns.Add(mBoton)
            End With
        End If

        grResumen.Columns(0).Width = 80
        grResumen.Columns(1).Width = 80
        grResumen.Columns(2).Width = 150
        grResumen.Columns(3).Width = 150
        grResumen.Columns(4).Width = 150
        grResumen.Columns(5).Width = 300


        Dim Cc As Integer
        For Cc = 0 To grResumen.Columns.Count - 1
            grResumen.Columns(Cc).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            grResumen.Columns(Cc).ReadOnly = True
            grResumen.Columns(Cc).HeaderCell.Style.Font = New Font("Microsoft Sans Serif", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        Next

        Me.Cursor = Cursors.Default
    End Sub


    Private Sub grResumen_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grResumen.CellContentClick
        Dim obCntv As New clConectividad


        If grResumen.Columns(e.ColumnIndex).Name = "btnValidar" Then
            obCntv.ActualizaValor("Estado = 'V'", "CabResumen", "Id = " & grResumen.Item("Numero Resumen", e.RowIndex).Value, My.Settings.cnnModProd)
            MessageBox.Show("Resumen Validado", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Call CargarResumenes()
        End If
    End Sub
End Class