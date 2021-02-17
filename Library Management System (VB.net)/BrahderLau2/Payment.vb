Imports System.Data.OleDb

Public Class Payment
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Dim tencent As Single = 0
    Dim twentycent As Single = 0
    Dim fiftycent As Single = 0
    Dim oneringgit As Integer = 0
    Dim fiveringgit As Integer = 0
    Dim tenringgit As Integer = 0
    Dim fiftyringgit As Integer = 0
    Dim totalAmount As Single = 0
    Dim balanceAmount As Single
    Dim _ISBN As String
    Dim _Title As String
    Dim _MemberID As String
    Dim _MemberName As String
    Dim _MemberType As String
    Dim _DueDate As Date
    Dim PaymentType As String

    'Book Rental
    Public Sub New(ByVal ISBN As String, ByVal Title As String, ByVal RentPrice As String, ByVal MemberID As String, ByVal MemberName As String, ByVal MemberType As String, ByVal DueDate As Date)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        PaymentType = "Book Rental"
        totalpaymentTextBox.Text = RentPrice
        _ISBN = ISBN
        _Title = Title
        _MemberID = MemberID
        _MemberName = MemberName
        _MemberType = MemberType
        _DueDate = DueDate
    End Sub

    'Clear Fines
    Public Sub New(ByVal MemberID As String, ByVal PendingFines As String, ByVal MemberName As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        PaymentType = "Clear Fines"
        _MemberID = MemberID
        _MemberName = MemberName
        totalpaymentTextBox.Text = PendingFines
    End Sub

    Private Sub Payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        ComboBox4.SelectedIndex = 0
        ComboBox5.SelectedIndex = 0
        ComboBox6.SelectedIndex = 0
        ComboBox7.SelectedIndex = 0
    End Sub

    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        tencent = 0.1 * ComboBox1.SelectedIndex
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        twentycent = 0.2 * ComboBox2.SelectedIndex
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        fiftycent = 0.5 * ComboBox3.SelectedIndex
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox4.SelectedIndexChanged
        oneringgit = 1 * ComboBox4.SelectedIndex
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox5.SelectedIndexChanged
        fiveringgit = 5 * ComboBox5.SelectedIndex
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox6.SelectedIndexChanged
        tenringgit = 10 * ComboBox6.SelectedIndex
    End Sub

    Private Sub ComboBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox7.SelectedIndexChanged
        fiftyringgit = 50 * ComboBox7.SelectedIndex
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        totalAmount = 0
        balanceAmount = 0
        totalAmount = tencent + twentycent + fiftycent + oneringgit + fiveringgit + tenringgit + fiftyringgit
        amountreceivedTextBox.Text = totalAmount.ToString("N2")
        balanceTextBox.Text = "N/A"
        If totalAmount > Val(totalpaymentTextBox.Text) Then
            balanceAmount = totalAmount - Val(totalpaymentTextBox.Text)
        End If
        balanceTextBox.Text = balanceAmount.ToString("N2")
    End Sub

    Private Sub payButton_Click(sender As Object, e As EventArgs)
        Timer1.Stop()
    End Sub

    Private Sub totalamontTextBox_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub payButton_Click_1(sender As Object, e As EventArgs) Handles payButton.Click
        If Val(amountreceivedTextBox.Text) >= Val(totalpaymentTextBox.Text) Then
            If PaymentType = "Book Rental" Then
                UpdateBookStatus()
                UpdateRentDetails()
            Else
                UpdateFine()
            End If
            MsgBox("Payment Successful!")
            Dim nextform As New Receipt(_MemberID, _MemberName, PaymentType, totalpaymentTextBox.Text, amountreceivedTextBox.Text, balanceTextBox.Text)
            Me.Hide()
            nextform.Show()
        Else
            MsgBox("Insufficient Amount Received!")
        End If
    End Sub

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    'Book Rental
    Sub UpdateBookStatus()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdUpdate As OleDbCommand = New OleDbCommand(
                    "UPDATE Book SET [Availability] = 'Unavailable' WHERE [ISBN] = '" & _ISBN & "' ", con)
            cmdUpdate.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub UpdateRentDetails()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdInsert As OleDbCommand = New OleDbCommand(
                        "INSERT INTO IssueRecord([MemberID],[ISBN],[RentDate],[DueDate],[BookStatus]) VALUES('" & _MemberID & "','" & _ISBN & "','" & Date.Now & "','" & _DueDate & "','Not due yet')", con)
            cmdInsert.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Clear Fines
    Sub UpdateFine()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdUpdate As OleDbCommand = New OleDbCommand(
                    "UPDATE IssueRecord SET [Fines(RM)] = '" & 0 & "' WHERE [MemberID] = '" & _MemberID & "' ", con)
            cmdUpdate.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class