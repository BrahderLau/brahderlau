Imports System.Data.OleDb

Public Class ManageBook
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    Private Sub backPictureBox_Click(sender As Object, e As EventArgs) Handles backPictureBox.Click
        Me.Hide()
        MainMenu.Show()
    End Sub

    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        If isbntextBox.Text IsNot "" And titletextBox.Text IsNot "" And authortextBox.Text IsNot "" And publishertextBox.Text IsNot "" And yeartextBox.Text IsNot "" And bookpricetextBox.Text IsNot "" And rentpricetextBox.Text IsNot "" Then
            Try
                If Not con.State = ConnectionState.Open Then
                    con.Open() 'opening the connection
                End If
                Dim cmdInsert As OleDbCommand = New OleDbCommand(
                        "INSERT INTO Book([ISBN],[Title],[Author],[Publisher],[PublishYear],[BookPrice(RM)],[RentPrice(RM)]) VALUES('" & isbntextBox.Text & "','" & titletextBox.Text & "','" & authortextBox.Text & "','" & publishertextBox.Text & "','" & yeartextBox.Text & "','" & Val(bookpricetextBox.Text) & "','" & Val(rentpricetextBox.Text) & "')", con)
                cmdInsert.ExecuteNonQuery()
                MsgBox("New book is added!")
            Catch ex As Exception
                MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            con.Close()
            DisplayData()
        Else
            MsgBox("Please fill in all the information!")
        End If
    End Sub

    Private Sub AddBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayData()
    End Sub

    Sub DisplayData()
        'checking whether the connection is opened or not
        If Not con.State = ConnectionState.Open Then
            con.Open() 'opening the connection
        End If
        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM Book", con)
            Dim dt As New DataTable
            da.Fill(dt)
            BookDataGridView.DataSource = dt
            'closing the connection
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        isbntextBox.Clear()
        titletextBox.Clear()
        authortextBox.Clear()
        publishertextBox.Clear()
        yeartextBox.Clear()
        bookpricetextBox.Clear()
        rentpricetextBox.Clear()
        isbntextBox.Focus()
    End Sub

    Private Sub deleteButton_Click(sender As Object, e As EventArgs) Handles deleteButton.Click 'Reference = https://www.programmingcraze.com/delete-database-records/
        'checking for the selected item in the list
        If BookDataGridView.Rows.Count > 0 Then
            If BookDataGridView.SelectedRows.Count > 0 Then
                Dim ISBN As String = BookDataGridView.SelectedRows(0).Cells("ISBN").Value

                'opening connection
                If Not con.State = ConnectionState.Open Then
                    con.Open()
                End If

                'deleting data from table

                If MessageBox.Show("Do you want to delete?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = Windows.Forms.DialogResult.Yes Then

                    Dim cmdDelete As OleDbCommand = New OleDbCommand("DELETE FROM Book WHERE [ISBN]= '" & ISBN & "' ", con)
                    cmdDelete.ExecuteNonQuery()

                    MessageBox.Show("Successfully deleted", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Deletion aborted", "Aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                End If

                'refresh data
                DisplayData()

                'closing connection
                con.Close()
            Else
                MessageBox.Show("No record selected for delete. hehe", "Deletion Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("No record to be delete.", "Deletion Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub
End Class