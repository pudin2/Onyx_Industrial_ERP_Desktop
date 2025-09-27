Public Class frmCambiaEstadosOT
    Private mEstadoOT As String, mCabOT_Id As Integer, mUsuarioId As Integer

    Public Property EstadoOT
    Get
        Return mEstadoOT
    End Get
    Set(value)
        mEstadoOT = value
    End Set
    End Property


    Public Property CabOT_Id As Integer
    Get
        Return mCabOT_Id
    End Get
    Set(value As Integer)
        mCabOT_Id = value
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


    Private Sub btnCambiarEstado_Click(sender As System.Object, e As System.EventArgs) Handles btnCambiarEstado.Click
        Dim obCntv As New clConectividad, strInsert As String

        'SE PREGUNTA SI SE DESEA PASAR A LA SIGUIENTE FASE: VALIDADO O PLANOS Y MATERIALES
        Dim mIdEstado As String
        mIdEstado = obCntv.LeerValorSencillo("id", "Estados", "TipoDoc ='OT' and Estado ='" & mEstadoOT & "'", My.Settings.cnnModProd)


        'GRABO LOS ESTADOS
        strInsert = "exec pa_Insert_EstadosOT " & mCabOT_Id & "," & mIdEstado & "," & mUsuarioId & ",'T'"
        If txtObservacion.Text <> "" Then strInsert = strInsert & ",'" & txtObservacion.Text & "'"
        obCntv.EjecutaComando(strInsert, My.Settings.cnnModProd, False)

        'TERMINO LA ETAPA Y MARCO COMO ACTUAL
        Dim mNumOrden As Integer = obCntv.LeerValorSencillo("NumOrden", "CabOT", "id=" & mCabOT_Id.ToString, My.Settings.cnnModProd)

        Dim strSql As String = "exec PA_TerminaEtapaOT " & mNumOrden.ToString & "," & mIdEstado.ToString
        obCntv.EjecutaComando(strSql, My.Settings.cnnModProd, False)

        MessageBox.Show("Estado de OT actualizado con éxito!", "Estado OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.DialogResult = Windows.Forms.DialogResult.OK


    End Sub
End Class