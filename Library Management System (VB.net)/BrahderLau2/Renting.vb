Imports System.Data.OleDb

Public Class Renting
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Dim pendingFine As Single
    Dim PaymentType As String
    Dim bookisExist As Boolean = True
    Dim memberisExist As Boolean = True

    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    Private Sub backPictureBox_Click(sender As Object, e As EventArgs) Handles backPictureBox.Click
        Dim back As New MainMenu
        Me.Hide()
        back.Show()
    End Sub

    Private Sub clearButton_Click(sender As Object, e As EventArgs) Handles clearButton.Click
        isbntextBox.Clear()
        titletextBox.Clear()
        authortextBox.Clear()
        publishertextBox.Clear()
        yeartextBox.Clear()
        rentpricetextBox.Clear()
        availabilitytextBox.Clear()
        memberidtextBox.Clear()
        membertypetextBox.Clear()
        membernametextBox.Clear()
        pendingfinesTextBox.Clear()
    End Sub

    Private Sub issuebookButton_Click(sender As Object, e As EventArgs) Handles issuebookButton.Click
        If availabilitytextBox.Text = "Available" And Val(pendingfinesTextBox.Text) = 0.00 Then
            PaymentType = "Book Rental"
            MsgBox("Book rental successful.")
            Dim nextform As New Payment(isbntextBox.Text, titletextBox.Text, rentpricetextBox.Text, memberidtextBox.Text, membernametextBox.Text, membertypetextBox.Text, dtpDueDate.Value)
            nextform.Show()
        ElseIf bookisExist = False Then
            MsgBox("Book does not exist.")
        ElseIf memberisExist = False Then
            MsgBox("Member does not exist.")
        ElseIf isbntextBox.Text = "" Then
            MsgBox("Please enter an ISBN for the book.")
        ElseIf memberidtextBox.Text = "" Then
            MsgBox("Please enter a MemberID.")
        ElseIf availabilitytextBox.Text = "Unavailable" Then
            MsgBox("Book is not available.")
        ElseIf Val(pendingfinesTextBox.Text) >= 0 Then
            MsgBox("Please clear your pending fine.")
        Else
            MsgBox("Please fill in the required fields.")
        End If
    End Sub

    Private Sub isbntextBox_TextChanged(sender As Object, e As EventArgs) Handles isbntextBox.TextChanged
        ReadBookDetails()
    End Sub

    Private Sub memberidtextBox_TextChanged(sender As Object, e As EventArgs) Handles memberidtextBox.TextChanged
        ReadMemberDetails()
        ReadPendingFines()
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
                bookisExist = True
                titletextBox.Text = dr("Title")
                authortextBox.Text = dr("Author")
                publishertextBox.Text = dr("Publisher")
                yeartextBox.Text = dr("PublishYear")
                Dim oriRentPrice As Single = dr("RentPrice(RM)")
                rentpricetextBox.Text = oriRentPrice.ToString("N2")
                availabilitytextBox.Text = dr("Availability")
            Else
                bookisExist = False
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
                memberisExist = True
                membertypetextBox.Text = dr("MemberType")
                membernametextBox.Text = dr("MemberName")
            Else
                memberisExist = False
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
End Class