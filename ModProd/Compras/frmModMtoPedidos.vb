Public Class frmModMtoPedidos

  Private mTipoConsola As String, mCntPedido As Decimal, mCntCompra As Decimal, mCntBorrado As Decimal, mDetSol_Id As Integer

  Public Property DetSol_Id As Integer
  Get
    Return mDetSol_Id
  End Get
  Set(ByVal value As Integer)
    mDetSol_Id = value
  End Set
  End Property


  Public Property TipoConsola As String
    Get
      Return mTipoConsola
    End Get
    Set(ByVal value As String)
      mTipoConsola = value
    End Set
  End Property


  Public Property CntPedido As Decimal
    Get
      Return mCntPedido
    End Get
    Set(ByVal value As Decimal)
      mCntPedido = value
    End Set
  End Property

  Public Property CntCompra As Decimal
    Get
      Return mCntPedido
    End Get
    Set(ByVal value As Decimal)
      mCntCompra = value
    End Set
  End Property

  Public Property CntBorrado As Decimal
  Get
    Return mCntBorrado
  End Get
  Set(ByVal value As Decimal)
    mCntBorrado = value
  End Set
  End Property


  Private mEstadoOT As String, mCabOT_Id As Integer, mUsuarioId As Integer

  Public Property EstadoOT
    Get
      Return mEstadoOT
    End Get
    Set(ByVal value)
      mEstadoOT = value
    End Set
  End Property


  Public Property CabOT_Id As Integer
    Get
      Return mCabOT_Id
    End Get
    Set(ByVal value As Integer)
      mCabOT_Id = value
    End Set
  End Property


  Public Property UsuarioId As Integer
    Get
      Return mUsuarioId
    End Get
    Set(ByVal value As Integer)
      mUsuarioId = value
    End Set
  End Property


  Private Sub btnActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActualizar.Click

    Dim obCntv As New clConectividad
    Dim mstrValores As String

    mstrValores = mDetSol_Id & "," & txtCntDepurar.Text & "," & mUsuarioId & ",'" & txtObservacion.Text & "','A'"
    '"6838899,1,2,'TEST','A'"

    obCntv.InsertarValor(mstrValores, "DetSolicitudDep", My.Settings.cnnModProd)

    MessageBox.Show("Item depurado con éxito!", "Estado OT", MessageBoxButtons.OK, MessageBoxIcon.Information)

    Me.DialogResult = Windows.Forms.DialogResult.OK


  End Sub

  Private Sub frmModMtoPedidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If mTipoConsola = "OC" Then
      grpCambiaEstado.Text = "Eliminar item de OC no procesado"
      txtCntCompra.Text = mCntCompra
      txtCntPedido.Text = mCntPedido
      txtCntDepurar.Text = mCntPedido - mCntCompra - mCntBorrado
      txtBorrados.Text = mCntBorrado
    Else
      grpCambiaEstado.Text = "Eliminar item de Pedido no procesado"
    End If
  End Sub

  
End Class