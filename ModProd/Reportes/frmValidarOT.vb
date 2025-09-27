Imports MSSQL = System.Data.SqlClient

Public Class frmValidarOT
  Private mNumOrden As Integer, mOTCabCotizacion_Id As Integer, mUsuarioId As Integer

  Public Property NumOrden As Integer
  Get
    Return mNumOrden
  End Get
  Set(value As Integer)
    mNumOrden = value
  End Set
  End Property

  Public Property OTCabCotizacion_Id As Integer
  Get
    Return mOTCabCotizacion_Id
  End Get
  Set(value As Integer)
    mOTCabCotizacion_Id = value

  End Set
  End Property

  Public Property UsuarioId As Integer
  Get
    Return mUsuarioId

  End Get
  Set(value As Integer)
    mUsuarioId = value
  End Set
  End Property


Private Sub cmdValidar_Click(sender As System.Object, e As System.EventArgs) Handles cmdValidar.Click
    Dim mPlanos As String, obCntv As New clConectividad, mEstadoXDefecto As String = "PM", strInsert As String

    If chkPlanos.Checked = True Then
      mPlanos = "1"
    Else
      mPlanos = "0"
    End If

    Dim drOt As MSSQL.SqlDataReader = obCntv.LeerValor("*", "CabOT", "NumOrden ='" & mNumOrden & "'", My.Settings.cnnModProd)
    Dim mIdEstado As String = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & drOt.Item("Estado").ToString & "'", My.Settings.cnnModProd)

    'TERMINO LA ETAPA ACTUAL 'R' E INSERTO LA SIGUIENTE 'V'
    strInsert = "exec pa_Insert_EstadosOT " & drOt.Item("id").ToString & "," & mIdEstado & "," & mUsuarioId & ",'T'"
    obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

    obCntv.ActualizaValor("Planos=" & mPlanos & ", Estado='" & mEstadoXDefecto & "'", "CabOT", "numOrden=" & mNumOrden, My.Settings.cnnModProd)
    Dim strSQLupdate As String = "AsignadoA='" & cmbAsignadaA.Text.ToString & "'"
    obCntv.ActualizaValor(strSQLupdate, "CabCotizacion", "Tipo in ('OT') and id=" & mOTCabCotizacion_Id.ToString, My.Settings.cnnModProd)

    'GRABO LOS ESTADOS
    drOt = obCntv.LeerValor("*", "CabOT", "NumOrden ='" & mNumOrden & "'", My.Settings.cnnModProd)
    mIdEstado = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & drOt.Item("Estado").ToString & "'", My.Settings.cnnModProd)

    'GRABO LA NUEVA ETAPA
    strInsert = "exec pa_Insert_EstadosOT " & drOt.Item("id").ToString & "," & mIdEstado & "," & mUsuarioId & ",'P'"
    obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

    MessageBox.Show("Datos actualizados con éxito!", "Datos Actualizados", MessageBoxButtons.OK, MessageBoxIcon.Information)
    Me.DialogResult = Windows.Forms.DialogResult.OK
    'Me.Close()



End Sub

Private Sub frmValidarOT_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad

    'PARTE DE LA CARGA DE LOS REPONSABLES
    cmbAsignadaA.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Responsables", "Estado='A' and Id>0")
    cmbAsignadaA.DisplayMember = "Nombre"

    lblOT.Text = mNumOrden.ToString
End Sub
End Class