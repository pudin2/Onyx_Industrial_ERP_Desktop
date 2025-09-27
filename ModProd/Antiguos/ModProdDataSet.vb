

Partial Public Class ModProdDataSet
  Partial Class pa_RPT_CosultaOrdenesDataTable

    Private Sub pa_RPT_CosultaOrdenesDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
      If (e.Column.ColumnName = Me.CodInventario_MPColumn.ColumnName) Then
        'Agregar código de usuario aquí
      End If

    End Sub

  End Class

End Class
