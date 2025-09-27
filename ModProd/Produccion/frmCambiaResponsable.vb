Public Class frmCambiaResponsable
    Private mEstadoOT As String, mCabOT_Id As Integer, mUsuarioId As Integer
    Private mCabSubT_Id As Integer, strOperario_Id As String, strAsignadaA As String


    Public Property CabSubT_Id As Integer
    Get
      Return mCabSubT_Id
    End Get
    Set(ByVal value As Integer)
      mCabSubT_Id = value
    End Set
    End Property

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
        Dim obCntv As New clConectividad, strUpdate As String

        If obCntv.LeerValorSencillo("count(1) Cant", "Cant", "DetProg", "SubTarea_Id = " & mCabSubT_Id & " and estado='A'", My.Settings.cnnModProd) > 0 Then
          If MessageBox.Show("Esta subtarea ya está programada. Se eliminará del progama y debe programarla en el recurso asignado. Desea continuar?" _
            , "Tarea programada", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = vbNo Then
              Exit Sub
          End If
        End If

        strUpdate = "Estado='I'"
        obCntv.ActualizaValor(strUpdate, "DetProg", "SubTarea_Id=" & mCabSubT_Id, My.Settings.cnnModProd)


        strUpdate = "Operario_Id =" & strOperario_Id & ", AsignadaA='" & strAsignadaA & "'"
        obCntv.ActualizaValor(strUpdate, "CabSubT", "Id=" & mCabSubT_Id, My.Settings.cnnModProd)

        MessageBox.Show("Responsable de Subtarea actualizado con éxito!", "Responsable SubT", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Me.DialogResult = Windows.Forms.DialogResult.OK


    End Sub


Private Sub frmCambiaResponsable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Dim obCntv As New clConectividad

      'PARTE DE LA CARGA DE LOS OPERARIOS
      lstOperarios.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "VW_Operarios", "Estado='A' and Id>0 order by NombreMostrar")
      lstOperarios.DisplayMember = "NombreMostrar"
End Sub

Private Sub lstOperarios_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstOperarios.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = lstOperarios.SelectedItem


    strOperario_Id = selectedItem("id").ToString
    strAsignadaA = selectedItem("NombreMostrar").ToString

    Label1.Text = strOperario_Id

End Sub
End Class