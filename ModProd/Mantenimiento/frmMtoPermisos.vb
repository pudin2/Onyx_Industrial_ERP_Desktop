Option Explicit On

Public Class frmMtoPermisos
  Private mRol_Id As Integer


  Private Sub frmMtoPermisos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
    Dim obCntv As New clConectividad

    cmbRoles.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Roles", "estado='A'")
    cmbRoles.DisplayMember = "Nombre"

    obCntv = Nothing

  End Sub

Private Sub cmbRoles_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbRoles.SelectedIndexChanged
    Dim selectedItem As DataRowView
    selectedItem = cmbRoles.SelectedItem

    mRol_Id = selectedItem("id").ToString
    Call CargarDatos(mRol_Id)
    'dtMenus = obCntv.LlenarDataTable(My.Settings.cnnModProd, False, "PA_MtoMenuXRol", mRol_Id.ToString, "Menus")
    'grMenus.DataSource = dtMenus

    'grMenus.Columns("id").Visible = False
    'grMenus.Columns("padre_id").Visible = False

    'grMenus.Columns("Menu").Width = 120
    'grMenus.Columns("transaccion").Width = 200

    'obCntv = Nothing
End Sub

Private Sub CargarDatos(Rol_Id As Integer)
  Dim dtMenus As DataTable, obCntv As New clConectividad

  dtMenus = obCntv.LlenarDataTable(My.Settings.cnnModProd, False, "PA_MtoMenuXRol", Rol_Id.ToString, "Menus")
  grMenus.DataSource = dtMenus

  grMenus.Columns("id").Visible = False
  grMenus.Columns("padre_id").Visible = False

  grMenus.Columns("Menu").Width = 120
  grMenus.Columns("transaccion").Width = 200

  'cmbRoles.DataSource = obCntv.LlenarDataTable(My.Settings.cnnModProd, "*", "Roles", "estado='A'")
  '  cmbRoles.DisplayMember = "Nombre"




  obCntv = Nothing

End Sub



Private Sub btnGrabar_Click(sender As System.Object, e As System.EventArgs) Handles btnGrabar.Click
  Dim obCntv As New clConectividad, strComando As String, Ff As Integer, mValor As Integer

  strComando = "delete from MenuXRol where rol_id=" & mRol_Id.ToString & vbCrLf

  For Ff = 0 To grMenus.Rows.Count - 1
    If grMenus.Item("valor", Ff).Value = True Then
      mValor = 1
    Else
      mValor = 0
    End If
    strComando = strComando & "INSERT MenuXRol VALUES (" & mRol_Id.ToString & "," & grMenus.Item("ID", Ff).Value & "," & mValor.ToString & ")" & vbCrLf
  Next

  strComando = strComando &
    "INSERT MenuXRol SELECT DISTINCT " & mRol_Id.ToString & ", M.Padre_Id,1 FROM MenuXRol MR JOIN MENU M ON M.Id = MR.Menu_Id where MR.rol_id=" & mRol_Id.ToString & " AND MR.Valor =1 AND M.Tipo ='C'"
  Try
      obCntv.EjecutaComando(strComando, My.Settings.cnnModProd, False)
      MessageBox.Show("Datos grabados con éxito!", "Mantenimiento Permisos", MessageBoxButtons.OK, MessageBoxIcon.Information)
  Catch ex As Exception
    Call ManejoError(Me.Name, "btnGrabar.Click", ex)
    MessageBox.Show(ex.GetType.ToString & vbCrLf & ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
  End Try



  Call CargarDatos(mRol_Id)

End Sub


Private Sub ManejoError(mFrm As String, mSub As String, mErr As Exception)
      Dim obLog As New clLog
      obLog.NombreArchivo = Application.StartupPath & "\ModProdLog.txt"
      obLog.EscribirLog("/------- INICIO EVENTO -----------------------------------------------------------------------------------/")
      obLog.EscribirLog("Error en " & mFrm & ": Sub " & mSub & ":")
      obLog.EscribirLog(mErr.Message)
      obLog.EscribirLog(mErr.StackTrace)
      obLog.EscribirLog("/------- FIN EVENTO -----------------------------------------------------------------------------------/")
      obLog.EscribirLog("")

      obLog = Nothing
    End Sub


End Class