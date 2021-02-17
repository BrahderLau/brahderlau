Imports System.Data.OleDb

Public Class Login
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub staffidtextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles staffidtextBox.MouseClick
        staffidtextBox.Clear()
    End Sub

    Private Sub passwordtextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles passwordtextBox.MouseClick
        passwordtextBox.Clear()
    End Sub

    Private Sub LoginButton_Click(sender As Object, e As EventArgs) Handles LoginButton.Click
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
        Dim cmdSearch As OleDbCommand = New OleDbCommand(
                   "SELECT * FROM Staff WHERE [StaffID] = '" &
                   staffidtextBox.Text & "' AND [StaffPassword] = '" & passwordtextBox.Text & "' ", con)
        Dim staffid As String = ""
        Dim pass As String = ""
        Dim staffName As String = ""
        con.Open()
        Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
        If (dr.Read() = True) Then
            staffid = dr("StaffID")
            pass = dr("StaffPassword")
            staffName = dr("StaffName")
            MessageBox.Show("Login Successfully! Welcome " + staffName + "!")
            Me.Hide()
            MainMenu.Show()
        Else
            MessageBox.Show("Invalid username or password!")
        End If
        dr.Close()
    End Sub
End Class