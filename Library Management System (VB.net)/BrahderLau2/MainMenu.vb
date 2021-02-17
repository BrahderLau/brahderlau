Public Class MainMenu
    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    Private Sub rentButton_Click(sender As Object, e As EventArgs) Handles rentButton.Click
        Dim nextform As New Renting
        Me.Hide()
        nextform.Show()
    End Sub

    Private Sub Fine_Click(sender As Object, e As EventArgs)
        Dim nextform As New Member
        Me.Hide()
        nextform.Show()
    End Sub

    Private Sub addbookButton_Click(sender As Object, e As EventArgs) Handles addbookButton.Click
        Dim nextform As New ManageBook
        Me.Hide()
        nextform.Show()
    End Sub

    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click
        Dim nextform As New ReturnBook
        Me.Hide()
        nextform.Show()
    End Sub

    Private Sub memberButton_Click(sender As Object, e As EventArgs) Handles memberButton.Click
        Dim nextform As New Member
        Me.Hide()
        nextform.Show()
    End Sub
End Class