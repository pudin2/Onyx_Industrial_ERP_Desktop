Option Explicit On
Imports MSSQL = System.Data.SqlClient
Imports Microsoft.Reporting.WinForms


Public Class frmValidacionRemision
    Private Sep As Char
    Public Usuario_Id As Integer
    Private FCANT As String = My.Settings.FormatoCantidad
    Private FCTO_U As String = My.Settings.FormatoC_U
    Private FCTOTOT As String = My.Settings.FormatoCostoTotal
    Private mIVA As Decimal, mCab_Id As Integer
    Private mModoPrograma As String = "REGISTRAR"

    Public Property ModoPrograma As String
        Get
            Return mModoPrograma
        End Get
        Set(value As String)
            mModoPrograma = value
        End Set
    End Property

    Private Sub frmvalidacionremision_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        SplitContainer1.SplitterDistance = 390
        dtpInicial.Value = CDate("01/01/" & Year(Date.Today))

        Sep = Application.CurrentCulture.NumberFormat.NumberDecimalSeparator

        Call CargarCabeceras()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Call CargarCabeceras()
        Me.Cursor = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CargarCabeceras()
        Dim obCntv As New clConectividad, strCampos As String
        Dim strWhere As String

        If optOCRegistradas.Checked = True Then
            strWhere = "Estado = 'R'"
        ElseIf optOCAprobadas.Checked = True Then
            strWhere = "Estado = 'V'"
        Else
            strWhere = "Estado like '%'"
        End If

        strWhere = strWhere & " AND Fecha between '" & Format(dtpInicial.Value, "yyyyMMdd") & "' and '" & Format(dtpFinal.Value, "yyyyMMdd") & "'"

        strCampos = "id, NombreCliente [Nombre Cliente], Fecha, TransportadoPor [Transportado Por], Placas , Estado"
        grCabResumen.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "CabRemision", strWhere)

        If grCabResumen.Rows.Count = 0 Then
            Call CargarDetalle(0)
        End If

        With grCabResumen
            .Columns("id").Width = 25
            .Columns("Nombre Cliente").Width = 300
            .Columns("Transportado Por").Width = 150

        End With

        obCntv = Nothing

    End Sub

    Private Sub CargarDetalle(Cab_Id As String)
        Dim obCntv As New clConectividad, strCampos As String

        strCampos = "NumOrden [Numero Orden], Estado, CntAFabricar [Cantidad a Fabricar], FechaInicio [Fecha Inicio], FechaPactada [Fecha Pactada], FechaRegistro [Fecha registro], OCompraCliente [Orden Compra Cliente], Cantidad [Cantidad a Entregar], NombreProyecto [Nombre Proyecto] "

        grDetalle.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, strCampos, "VW_RemisionxOT", "Cab_Id =" & Cab_Id & " Order by cab_id")


        mCab_Id = Cab_Id



        obCntv = Nothing

        With grDetalle
            .Columns("Numero Orden").DisplayIndex = 0
            .Columns("Nombre Proyecto").DisplayIndex = 1
            .Columns("Cantidad a Fabricar").DisplayIndex = 2
            .Columns("Cantidad a Entregar").DisplayIndex = 3
            .Columns("Orden Compra Cliente").DisplayIndex = 4
            .Columns("Nombre Proyecto").Width = 300
            .Columns("Fecha registro").Width = 100
            .Columns("Cantidad a Entregar").Width = 60
            .Columns("Cantidad a Fabricar").Width = 60


        End With
    End Sub

    Private Sub grCabResumen_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grCabResumen.CellEnter
        Dim gr As DataGridView = sender
        Call CargarDetalle(gr.Item("Id", e.RowIndex).Value.ToString)

    End Sub

    Private Sub btnAprobar_Click(sender As System.Object, e As System.EventArgs) Handles btnAprobar.Click



        If MessageBox.Show("Desea aprobar la remisión " & mCab_Id.ToString & " ?", "Aprobar remision", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Dim obCntv As New clConectividad
            obCntv.ActualizaValor("Estado= 'V' ", "cabRemision", "id=" & mCab_Id, My.Settings.cnnModProd)
            obCntv.ActualizaValor("Estado= 'V' ", "detRemision", "cab_id=" & mCab_Id, My.Settings.cnnModProd)
            Call CargarCabeceras()



        End If
    End Sub



    Private Sub CerrarControlBarra()
        Dim mBoton As Button = Me.Tag
        Try
            frmMenuWin10.flpVentanas.Controls.RemoveByKey(mBoton.Name)
        Catch ex As System.NullReferenceException
            'no hago nada
        End Try
    End Sub

    Private Sub frmvalidacionremision_FormClosing(sender As System.Object, e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Call CerrarControlBarra()
    End Sub

End Class