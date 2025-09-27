Public Class frmPlaneacion

  Private Sub frmPlaneacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        grid1.Rows.Add("John")
        grid1.Rows.Add("Daphne")
        grid1.Rows.Add("Roger")
        grid1.Rows.Add("Max")
        grid1.Rows.Add("Abbey")
        grid1.Rows.Add("Tommy")

        Grid2.AllowDrop = True
        Grid2.Rows.Add("Desk 1")
        Grid2.Rows.Add("Desk 2")
        Grid2.Rows.Add("Desk 3")
        Grid2.Rows.Add("Desk 4")
        Grid2.Rows.Add("Desk 5")
        Grid2.Rows.Add("Desk 6")


  End Sub



  Private Sub grid1_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles grid1.MouseDown
    Dim SourceRow As Integer
    SourceRow = grid1.HitTest(e.X, e.Y).RowIndex
    grid1.DoDragDrop(SourceRow, DragDropEffects.Copy)

  End Sub

Private Sub Grid2_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Grid2.DragDrop

        Dim SourceRow As Integer = Convert.ToInt32(e.Data.GetData(Type.GetType("System.Int32")))
        Dim clientPoint As Point = Grid2.PointToClient(New Point(e.X, e.Y))
        Dim hit As DataGridView.HitTestInfo = Grid2.HitTest(clientPoint.X, clientPoint.Y)
        If hit.Type = DataGridViewHitTestType.Cell Then
            Dim DestRow As Integer = hit.RowIndex
            Dim DestCol As Integer = hit.ColumnIndex
            Grid2.Rows(DestRow).Cells(DestCol).Value = grid1.Rows(SourceRow).Cells(0).Value
        End If



End Sub

  Private Sub Grid2_DragOver(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles Grid2.DragOver
     e.Effect = DragDropEffects.Copy
  End Sub
End Class