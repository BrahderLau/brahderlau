Imports System.Data.OleDb

Public Class ReturnBook
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Dim loanPeriod As Integer
    Public fineRule As Integer = 1
    Dim totalFine As Integer
    Dim pendingFine As Single
    Dim bookStatus As String
    Dim isExist As Boolean = True

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

    Private Sub isbntextBox_TextChanged(sender As Object, e As EventArgs) Handles isbntextBox.TextChanged
        CalcLoanPeriod()
        ReadBookDetails()
        ReadMemberID()
        ReadMemberDetails()
        ReadPendingFines()
    End Sub

    Private Sub btnClearFields_Click(sender As Object, e As EventArgs) Handles btnClearFields.Click
        isbntextBox.Clear()
        titletextBox.Clear()
        authortextBox.Clear()
        publishertextBox.Clear()
        yeartextBox.Clear()
        rentpricetextBox.Clear()
        bookstatustextBox.Clear()
        memberidtextBox.Clear()
        membertypetextBox.Clear()
        membernametextBox.Clear()
        pendingfinesTextBox.Clear()
    End Sub

    Sub CalcLoanPeriod() 'Check overdue books and borrowed books
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM IssueRecord WHERE [ISBN] = '" & isbntextBox.Text & "' AND [BookStatus] = 'Not due yet' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            If dr.Read() = True Then
                isExist = True
                bookStatus = dr("bookStatus")
                dtpDueDate.Value = dr("DueDate")
                Dim span = Now - dtpDueDate.Value
                loanPeriod = span.TotalDays
                If loanPeriod > 0 Then
                    totalFine = fineRule * loanPeriod
                    bookStatus = "Overdue"
                    UpdateFine()
                End If
            Else
                isExist = False
                ShowReturnedooks()
            End If
            bookstatustextBox.Text = bookStatus
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ShowReturnedooks()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM IssueRecord WHERE [ISBN] = '" & isbntextBox.Text & "' AND [BookStatus] = 'Returned' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            If dr.Read() = True Then
                bookStatus = dr("BookStatus")
                dtpDueDate.Value = dr("DueDate")
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub UpdateFine()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdUpdate As OleDbCommand = New OleDbCommand(
                    "UPDATE IssueRecord SET [Fines(RM)] = '" & totalFine & "' WHERE [ISBN] = '" & isbntextBox.Text & "' AND ReturnDate IS NULL", con)
            cmdUpdate.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ReadBookDetails()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM Book WHERE [ISBN] = '" & isbntextBox.Text & "' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            If (dr.Read() = True) Then
                titletextBox.Text = dr("Title")
                authortextBox.Text = dr("Author")
                publishertextBox.Text = dr("Publisher")
                yeartextBox.Text = dr("PublishYear")
                Dim oriRentPrice As Single = dr("RentPrice(RM)")
                rentpricetextBox.Text = oriRentPrice.ToString("N2")
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ReadMemberID()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM IssueRecord WHERE [ISBN] = '" & isbntextBox.Text & "' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            If (dr.Read() = True) Then
                memberidtextBox.Text = dr("MemberID")
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ReadMemberDetails()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM Member WHERE [MemberID] = '" & memberidtextBox.Text & "' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            If (dr.Read() = True) Then
                membertypetextBox.Text = dr("MemberType")
                membernametextBox.Text = dr("MemberName")
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub ReadPendingFines()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdSearch As OleDbCommand = New OleDbCommand(
                    "SELECT * FROM IssueRecord WHERE [MemberID] = '" & memberidtextBox.Text & "' ", con)
            Dim dr As OleDbDataReader = cmdSearch.ExecuteReader()
            While (dr.Read() = True)
                pendingFine += dr("Fines(RM)")
            End While
            pendingfinesTextBox.Text = pendingFine.ToString("N2")
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub RecordReturnDate()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdInsert As OleDbCommand = New OleDbCommand(
                    "UPDATE IssueRecord SET [ReturnDate] = '" & Date.Now & "' WHERE ISBN = '" & isbntextBox.Text & "' ", con)
            cmdInsert.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub UpdateBookStatus()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdUpdate As OleDbCommand = New OleDbCommand(
                    "UPDATE IssueRecord SET [BookStatus] = 'Returned' WHERE [ISBN] = '" & isbntextBox.Text & "' ", con)
            cmdUpdate.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub UpdateBookAvailability()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdUpdate As OleDbCommand = New OleDbCommand(
                    "UPDATE Book SET [Availability] = 'Available' WHERE [ISBN] = '" & isbntextBox.Text & "' ", con)
            cmdUpdate.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub returnButton_Click(sender As Object, e As EventArgs) Handles returnButton.Click
        If bookStatus = "Returned" Then
            MsgBox("This book has already returned!")
        ElseIf isExist = False Then
            MsgBox("The ISBN does not exist.")
            isbntextBox.Clear()
            titletextBox.Clear()
            authortextBox.Clear()
            publishertextBox.Clear()
            yeartextBox.Clear()
            rentpricetextBox.Clear()
            bookstatustextBox.Clear()
            memberidtextBox.Clear()
            membertypetextBox.Clear()
            membernametextBox.Clear()
            pendingfinesTextBox.Clear()
        ElseIf isExist = True Then
            RecordReturnDate()
            UpdateBookStatus()
            UpdateBookAvailability()
            MsgBox("Book successfully returned!")
            Dim done As New MainMenu
            Me.Hide()
            done.Show()
        Else
            MsgBox("Please key in the ISBN for the book.")
        End If
    End Sub
End Class