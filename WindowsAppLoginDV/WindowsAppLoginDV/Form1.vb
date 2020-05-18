Public Class Form1
    Private Sub UtilizadoresBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles UtilizadoresBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.UtilizadoresBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.UsersDataSet)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'UsersDataSet.Utilizadores' table. You can move, or remove it, as needed.
        Me.UtilizadoresTableAdapter.Fill(Me.UsersDataSet.Utilizadores)

    End Sub
End Class
