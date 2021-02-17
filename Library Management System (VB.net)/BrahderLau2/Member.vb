Imports System.Data.OleDb

Public Class Member
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Dim pendingFine As Single
    Dim isExist As Boolean = True
    Dim PaymentType As String
    Dim memberisExist As Boolean = True

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub backPictureBox_Click(sender As Object, e As EventArgs) Handles backPictureBox.Click
        Dim back As New MainMenu
        Me.Hide()
        back.Show()
    End Sub

    Private Sub Member_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        searchbyComboBox.SelectedIndex = 0
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
                membernameTextBox.Text = dr("MemberName")
                If memberisExist = False Then
                    memberisExist = Not memberisExist
                End If
            Else
                memberisExist = Not memberisExist
            End If
            dr.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DisplayCurrentBooks()
        'checking whether the connection is opened or not
        If Not con.State = ConnectionState.Open Then
            con.Open() 'opening the connection
        End If
        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM IssueRecord WHERE [MemberID] = '" & memberidtextBox.Text & "' AND [BookStatus] = 'Not due yet' ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            booktransactionDataGridView.DataSource = dt
            'closing the connection
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DisplayOverdueBooks()
        'checking whether the connection is opened or not
        If Not con.State = ConnectionState.Open Then
            con.Open() 'opening the connection
        End If
        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM IssueRecord WHERE [MemberID] = '" & memberidtextBox.Text & "' AND [BookStatus] = 'Overdue' ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            booktransactionDataGridView.DataSource = dt
            'closing the connection
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DisplayReturnedBooks()
        'checking whether the connection is opened or not
        If Not con.State = ConnectionState.Open Then
            con.Open() 'opening the connection
        End If
        Try
            Dim da As New OleDbDataAdapter("SELECT * FROM IssueRecord WHERE [MemberID] = '" & memberidtextBox.Text & "' AND [BookStatus] = 'Returned' ", con)
            Dim dt As New DataTable
            da.Fill(dt)
            booktransactionDataGridView.DataSource = dt
            'closing the connection
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub clearfinesButton_Click(sender As Object, e As EventArgs) Handles clearfinesButton.Click
        If memberidtextBox.Text = "" Then
            MsgBox("Please enter the MemberID.")
        ElseIf Not memberisExist Then
            MsgBox("MemberID does not exist.")
        ElseIf pendingfinesTextBox.Text = "0.00" Then
            MsgBox("No pending fees.")
        Else
            PaymentType = "Clear Fines"
            Dim nextform As New Payment(memberidtextBox.Text, pendingfinesTextBox.Text, membernameTextBox.Text)
            Me.Hide()
            nextform.Show()
        End If
    End Sub

    Sub ReadBookTransaction()
        If memberisExist Then
            If searchbyComboBox.SelectedIndex = 0 Then
                DisplayCurrentBooks()
            ElseIf searchbyComboBox.SelectedIndex = 1 Then
                DisplayOverdueBooks()
            ElseIf searchbyComboBox.SelectedIndex = 2 Then
                DisplayReturnedBooks()
            End If
        End If
    End Sub

    Private Sub memberidtextBox_TextChanged(sender As Object, e As EventArgs) Handles memberidtextBox.TextChanged
        ReadMemberDetails()
        ReadPendingFines()
        ReadBookTransaction()
    End Sub

    Private Sub searchbyComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles searchbyComboBox.SelectedIndexChanged
        ReadBookTransaction()
    End Sub
End Class