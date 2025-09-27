

Partial Public Class dsCalculadora
  Partial Class CabCotizacionDataTable

    Private Sub CabCotizacionDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
      If (e.Column.ColumnName = Me.FormaPagoColumn.ColumnName) Then
        'Agregar código de usuario aquí
      End If

    End Sub

  End Class

End Class
