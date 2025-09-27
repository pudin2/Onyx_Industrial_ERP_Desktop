Option Explicit On

Imports System.Configuration

Public Class frmNotifica
  Private mTiempo As Integer, mTiempoGlobo As Integer

  Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
    Call CargarNotificaciones()

  End Sub


  Private Sub CargarNotificaciones()
    Dim Usuario As String = Environment.UserDomainName & "\" & Environment.UserName
    Dim obCntv As New clConectividad, strCadena As String

    strCadena = My.Settings.cnnModProd

    Dim strTipo As String

    If optLeidos.Checked = True Then
      strTipo = "L"
    Else
      strTipo = "E"
    End If

    grNotifica.DataSource = obCntv.LlenarDataTable(strCadena, True, "pa_LeerNotificaciones", strTipo, "dtNotificaciones")


    'grDet.DataSource = obCntv.LlenarDataTable(strCadena, strCamposSQL, strConsultaSQL, mWhere)
    Dim Ii As Integer

    For Ii = 0 To grNotifica.Rows.Count - 1
      grNotifica.Rows(Ii).Height = 50
    Next Ii

    grNotifica.Columns(0).Width = 75 : grNotifica.Columns(1).Width = 350
    grNotifica.Columns(2).Width = 70 : grNotifica.Columns(3).Width = 120
    grNotifica.Columns(4).Width = 150 : grNotifica.Columns(5).Width = 50
    grNotifica.Columns(6).Visible = False
    grNotifica.Columns(7).Visible = False
    grNotifica.Columns(8).Visible = False



    grNotifica.Columns(1).DefaultCellStyle.WrapMode = DataGridViewTriState.True


    grNotifica.Columns(0).HeaderText = "TITULO"
    grNotifica.Columns(1).HeaderText = "MENSAJE"
    grNotifica.Columns(2).HeaderText = "ESTADO"
    grNotifica.Columns(3).HeaderText = "USUARIO ENVIA"
    grNotifica.Columns(4).HeaderText = "USUARIO DESTINO"
    grNotifica.Columns(5).HeaderText = "LEIDO"

    grNotifica.Columns(0).ReadOnly = True : grNotifica.Columns(1).ReadOnly = True
    grNotifica.Columns(2).ReadOnly = True : grNotifica.Columns(3).ReadOnly = True
    grNotifica.Columns(4).ReadOnly = True : grNotifica.Columns(5).ReadOnly = True




  End Sub

Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
   If (Me.WindowState = FormWindowState.Minimized) Then

      Call CargarNotificaciones()
      If optSinLeer.Checked = True Then
        If grNotifica.Rows.Count > 0 Then
          NotifyIcon1.ShowBalloonTip(mTiempoGlobo, "Modprod", "Notificaciones de Modprod sin leer!", ToolTipIcon.Info)
        End If
      End If
    End If
End Sub


Private Sub frmNotifica_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
  Dim obCntv As New clConectividad

  mTiempo = CInt(obCntv.LeerValorSencillo("Valor", "Parametros", "Id=17", My.Settings.cnnModProd))
  mTiempoGlobo = CInt(obCntv.LeerValorSencillo("Valor", "Parametros", "Id=18", My.Settings.cnnModProd))


  Timer1.Interval = mTiempo
  Timer1.Start()
End Sub

Private Sub NotifyIcon1_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
    Me.Show()
    Me.WindowState = FormWindowState.Normal
    Me.Focus()
End Sub


  Private Sub frmNotifica_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    If e.CloseReason = CloseReason.UserClosing Then
      e.Cancel = True


    End If
  End Sub

 

  Private Sub frmNotifica_SizeChanged(sender As Object, e As System.EventArgs) Handles Me.SizeChanged
    If (Me.WindowState = FormWindowState.Minimized) Then
      Me.Hide()
      Timer1.Interval = mTiempo
      Timer1.Start()
    Else
      Timer1.Stop()

    End If




  End Sub

  Private Sub grNotifica_CellContentClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grNotifica.CellContentClick
    Dim chkCelda As DataGridViewCheckBoxCell
    If e.ColumnIndex = 5 Then
      chkCelda = grNotifica.Rows(e.RowIndex).Cells(5)
      chkCelda.Value = Not chkCelda.Value

      Dim obCntv As New clConectividad, strCadena As String, strComando As String, strValor As String

      strValor = IIf(chkCelda.Value = True, "L", "E")

      strCadena = My.Settings.cnnModProd
      strComando = "UPDATE Notificaciones SET Estado='" & strValor & "' WHERE ID=" & grNotifica.Rows(e.RowIndex).Cells("ID").Value
      obCntv.EjecutaComando(strComando, strCadena, False)

      obCntv = Nothing
    End If

  End Sub




  
  Private Sub grNotifica_CellContentDoubleClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grNotifica.CellContentDoubleClick


    Select Case grNotifica.Item("Origen", e.RowIndex).Value.ToString
      Case "frmOT"
        Dim Frm As New frmOrdenDeTrabajo
        Frm.CargarOT(grNotifica.Item("NumDocumento", e.RowIndex).Value)
        frmMenuWin10.AbreFrmOrdenDeTrabajoDesdeNotificacion(Frm)




      Case "frmSimulador"

    End Select



  End Sub
End Class