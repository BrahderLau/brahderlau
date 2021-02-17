Imports System.Data.OleDb

Public Class Receipt
    Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Kodi.accdb")
    Dim _MemberID As String
    Dim _MemberName As String
    Dim _PaymentType As String
    Dim _PaymentAmount As String
    Dim _AmountReceived As String
    Dim _Balance As String
    Private Sub exitpictureBox_Click(sender As Object, e As EventArgs) Handles exitpictureBox.Click
        Application.Exit()
    End Sub

    Private Sub LogoutPictureBox_Click(sender As Object, e As EventArgs) Handles LogoutPictureBox.Click
        Dim logout As New Login
        Me.Hide()
        logout.Show()
    End Sub

    Public Sub New(ByVal MemberID As String, ByVal MemberName As String, ByVal PaymentType As String, PaymentAmount As String, ByVal AmountReceived As String, ByVal Balance As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Try
            _MemberID = MemberID 'The error occurs here.
            _MemberName = MemberName
            _PaymentType = PaymentType
            _PaymentAmount = PaymentAmount
            _AmountReceived = AmountReceived
            _Balance = Balance
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Receipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            memberidTextBox.Text = _MemberID
            membernameTextBox.Text = _MemberName
            paymenttypetextBox.Text = _PaymentType
            paymentamountTextBox.Text = _PaymentAmount
            amountpaidTextBox.Text = _AmountReceived
            balanceTextBox.Text = _Balance
            billdateTextBox.Text = Date.Now
            GenerateRandomBillID()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GenerateRandomBillID() 'Reference = https://www.dotnetperls.com/random-vbnet
        Dim randomBill As Random = New Random
        ' Get random numbers between 10000 and 100000. 
        billidTextBox.Text = randomBill.Next(10000, 99999)
    End Sub

    Private Sub mainmenuButton_Click(sender As Object, e As EventArgs) Handles mainmenuButton.Click
        Dim mainMenu As New MainMenu
        Me.Hide()
        mainMenu.Show()
    End Sub

    Private Sub printButton_Click(sender As Object, e As EventArgs) Handles printButton.Click
        CreateBillRecord()
        MsgBox("Receipt is printed!")
        Dim mainMenu As New MainMenu
        Me.Hide()
        mainMenu.Show()
    End Sub

    Sub CreateBillRecord()
        Try
            If Not con.State = ConnectionState.Open Then
                con.Open() 'opening the connection
            End If
            Dim cmdInsert As OleDbCommand = New OleDbCommand(
                        "INSERT INTO BillRecord([BillID],[BillDate],[Amount(RM)],[MemberID],[MemberName],[PaymentType]) VALUES('" & billidTextBox.Text & "','" & billdateTextBox.Text & "','" & paymentamountTextBox.Text & "','" & memberidTextBox.Text & "','" & membernameTextBox.Text & "','" & paymenttypetextBox.Text & "')", con)
            cmdInsert.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class