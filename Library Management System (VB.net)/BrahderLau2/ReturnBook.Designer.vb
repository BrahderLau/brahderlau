﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ReturnBook
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReturnBook))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.returnButton = New System.Windows.Forms.Button()
        Me.btnClearFields = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.pendingfinesTextBox = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.membernametextBox = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.memberidtextBox = New System.Windows.Forms.MaskedTextBox()
        Me.membertypetextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rentpricetextBox = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.publishertextBox = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.isbntextBox = New System.Windows.Forms.MaskedTextBox()
        Me.yeartextBox = New System.Windows.Forms.MaskedTextBox()
        Me.bookstatustextBox = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.authortextBox = New System.Windows.Forms.TextBox()
        Me.titletextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LogoutPictureBox = New System.Windows.Forms.PictureBox()
        Me.exitpictureBox = New System.Windows.Forms.PictureBox()
        Me.backPictureBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox4.Controls.Add(Me.dtpDueDate)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.returnButton)
        Me.GroupBox4.Controls.Add(Me.btnClearFields)
        Me.GroupBox4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(78, 410)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(399, 97)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Return Information"
        '
        'dtpDueDate
        '
        Me.dtpDueDate.CalendarMonthBackground = System.Drawing.SystemColors.ControlDark
        Me.dtpDueDate.CalendarTitleBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpDueDate.Enabled = False
        Me.dtpDueDate.Location = New System.Drawing.Point(121, 26)
        Me.dtpDueDate.MaxDate = New Date(2019, 12, 31, 0, 0, 0, 0)
        Me.dtpDueDate.MinDate = New Date(2010, 1, 1, 0, 0, 0, 0)
        Me.dtpDueDate.Name = "dtpDueDate"
        Me.dtpDueDate.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dtpDueDate.Size = New System.Drawing.Size(220, 25)
        Me.dtpDueDate.TabIndex = 6
        Me.dtpDueDate.Value = New Date(2018, 11, 27, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(46, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 17)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Due Date :"
        '
        'returnButton
        '
        Me.returnButton.BackColor = System.Drawing.Color.SteelBlue
        Me.returnButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.returnButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise
        Me.returnButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.returnButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.returnButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.returnButton.Location = New System.Drawing.Point(99, 57)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(94, 30)
        Me.returnButton.TabIndex = 2
        Me.returnButton.Text = "Return Book"
        Me.returnButton.UseVisualStyleBackColor = False
        '
        'btnClearFields
        '
        Me.btnClearFields.BackColor = System.Drawing.Color.DimGray
        Me.btnClearFields.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClearFields.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise
        Me.btnClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFields.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClearFields.Location = New System.Drawing.Point(199, 57)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(94, 30)
        Me.btnClearFields.TabIndex = 3
        Me.btnClearFields.Text = "Clear Entry"
        Me.btnClearFields.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.pendingfinesTextBox)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.membernametextBox)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.memberidtextBox)
        Me.GroupBox1.Controls.Add(Me.membertypetextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(78, 281)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 118)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Member Information"
        '
        'pendingfinesTextBox
        '
        Me.pendingfinesTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pendingfinesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pendingfinesTextBox.Enabled = False
        Me.pendingfinesTextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pendingfinesTextBox.Location = New System.Drawing.Point(312, 23)
        Me.pendingfinesTextBox.Name = "pendingfinesTextBox"
        Me.pendingfinesTextBox.ReadOnly = True
        Me.pendingfinesTextBox.Size = New System.Drawing.Size(81, 25)
        Me.pendingfinesTextBox.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(214, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 17)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Pending Fines:"
        '
        'membernametextBox
        '
        Me.membernametextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.membernametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.membernametextBox.Enabled = False
        Me.membernametextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membernametextBox.Location = New System.Drawing.Point(119, 86)
        Me.membernametextBox.Name = "membernametextBox"
        Me.membernametextBox.ReadOnly = True
        Me.membernametextBox.Size = New System.Drawing.Size(253, 25)
        Me.membernametextBox.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 17)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "MemberName :"
        '
        'memberidtextBox
        '
        Me.memberidtextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.memberidtextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.memberidtextBox.Enabled = False
        Me.memberidtextBox.Location = New System.Drawing.Point(119, 22)
        Me.memberidtextBox.Name = "memberidtextBox"
        Me.memberidtextBox.ReadOnly = True
        Me.memberidtextBox.Size = New System.Drawing.Size(81, 25)
        Me.memberidtextBox.TabIndex = 4
        Me.memberidtextBox.ValidatingType = GetType(Integer)
        '
        'membertypetextBox
        '
        Me.membertypetextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.membertypetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.membertypetextBox.Enabled = False
        Me.membertypetextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membertypetextBox.Location = New System.Drawing.Point(119, 55)
        Me.membertypetextBox.Name = "membertypetextBox"
        Me.membertypetextBox.ReadOnly = True
        Me.membertypetextBox.Size = New System.Drawing.Size(81, 25)
        Me.membertypetextBox.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 17)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "MemberType :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "MemberID :"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.rentpricetextBox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.publishertextBox)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.isbntextBox)
        Me.GroupBox2.Controls.Add(Me.yeartextBox)
        Me.GroupBox2.Controls.Add(Me.bookstatustextBox)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.authortextBox)
        Me.GroupBox2.Controls.Add(Me.titletextBox)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(78, 60)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(399, 206)
        Me.GroupBox2.TabIndex = 29
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Book Information"
        '
        'rentpricetextBox
        '
        Me.rentpricetextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rentpricetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rentpricetextBox.Enabled = False
        Me.rentpricetextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rentpricetextBox.Location = New System.Drawing.Point(121, 177)
        Me.rentpricetextBox.Name = "rentpricetextBox"
        Me.rentpricetextBox.Size = New System.Drawing.Size(70, 25)
        Me.rentpricetextBox.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 181)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 17)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "Rent Price (RM) :"
        '
        'publishertextBox
        '
        Me.publishertextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.publishertextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.publishertextBox.Enabled = False
        Me.publishertextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publishertextBox.Location = New System.Drawing.Point(121, 115)
        Me.publishertextBox.Name = "publishertextBox"
        Me.publishertextBox.ReadOnly = True
        Me.publishertextBox.Size = New System.Drawing.Size(253, 25)
        Me.publishertextBox.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 17)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Publisher :"
        '
        'isbntextBox
        '
        Me.isbntextBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.isbntextBox.Location = New System.Drawing.Point(121, 21)
        Me.isbntextBox.Name = "isbntextBox"
        Me.isbntextBox.Size = New System.Drawing.Size(120, 25)
        Me.isbntextBox.TabIndex = 0
        Me.isbntextBox.ValidatingType = GetType(Integer)
        '
        'yeartextBox
        '
        Me.yeartextBox.AsciiOnly = True
        Me.yeartextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.yeartextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.yeartextBox.Enabled = False
        Me.yeartextBox.Location = New System.Drawing.Point(121, 146)
        Me.yeartextBox.Name = "yeartextBox"
        Me.yeartextBox.ReadOnly = True
        Me.yeartextBox.Size = New System.Drawing.Size(64, 25)
        Me.yeartextBox.TabIndex = 14
        Me.yeartextBox.ValidatingType = GetType(Integer)
        '
        'bookstatustextBox
        '
        Me.bookstatustextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.bookstatustextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bookstatustextBox.Enabled = False
        Me.bookstatustextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bookstatustextBox.Location = New System.Drawing.Point(312, 177)
        Me.bookstatustextBox.Name = "bookstatustextBox"
        Me.bookstatustextBox.ReadOnly = True
        Me.bookstatustextBox.Size = New System.Drawing.Size(81, 25)
        Me.bookstatustextBox.TabIndex = 15
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(217, 182)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(83, 17)
        Me.Label25.TabIndex = 13
        Me.Label25.Text = "Book Status :"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(17, 149)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(40, 17)
        Me.Label24.TabIndex = 5
        Me.Label24.Text = "Year :"
        '
        'authortextBox
        '
        Me.authortextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.authortextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.authortextBox.Enabled = False
        Me.authortextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.authortextBox.Location = New System.Drawing.Point(121, 84)
        Me.authortextBox.Name = "authortextBox"
        Me.authortextBox.ReadOnly = True
        Me.authortextBox.Size = New System.Drawing.Size(253, 25)
        Me.authortextBox.TabIndex = 12
        '
        'titletextBox
        '
        Me.titletextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.titletextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.titletextBox.Enabled = False
        Me.titletextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titletextBox.Location = New System.Drawing.Point(121, 54)
        Me.titletextBox.Name = "titletextBox"
        Me.titletextBox.ReadOnly = True
        Me.titletextBox.Size = New System.Drawing.Size(253, 25)
        Me.titletextBox.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 84)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 17)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Author(s) :"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 56)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 17)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Book Title :"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(15, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 17)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "ISBN :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Mistral", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 57)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Return"
        '
        'LogoutPictureBox
        '
        Me.LogoutPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoutPictureBox.Image = CType(resources.GetObject("LogoutPictureBox.Image"), System.Drawing.Image)
        Me.LogoutPictureBox.Location = New System.Drawing.Point(17, 11)
        Me.LogoutPictureBox.Name = "LogoutPictureBox"
        Me.LogoutPictureBox.Size = New System.Drawing.Size(46, 46)
        Me.LogoutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogoutPictureBox.TabIndex = 27
        Me.LogoutPictureBox.TabStop = False
        '
        'exitpictureBox
        '
        Me.exitpictureBox.BackColor = System.Drawing.Color.Transparent
        Me.exitpictureBox.Image = CType(resources.GetObject("exitpictureBox.Image"), System.Drawing.Image)
        Me.exitpictureBox.Location = New System.Drawing.Point(474, 11)
        Me.exitpictureBox.Name = "exitpictureBox"
        Me.exitpictureBox.Size = New System.Drawing.Size(42, 46)
        Me.exitpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.exitpictureBox.TabIndex = 26
        Me.exitpictureBox.TabStop = False
        '
        'backPictureBox
        '
        Me.backPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.backPictureBox.Image = CType(resources.GetObject("backPictureBox.Image"), System.Drawing.Image)
        Me.backPictureBox.Location = New System.Drawing.Point(17, 463)
        Me.backPictureBox.Name = "backPictureBox"
        Me.backPictureBox.Size = New System.Drawing.Size(45, 46)
        Me.backPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.backPictureBox.TabIndex = 32
        Me.backPictureBox.TabStop = False
        '
        'ReturnBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(533, 519)
        Me.Controls.Add(Me.backPictureBox)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LogoutPictureBox)
        Me.Controls.Add(Me.exitpictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ReturnBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ReturnBook"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents returnButton As Button
    Friend WithEvents btnClearFields As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents membernametextBox As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents memberidtextBox As MaskedTextBox
    Friend WithEvents membertypetextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents publishertextBox As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents isbntextBox As MaskedTextBox
    Friend WithEvents yeartextBox As MaskedTextBox
    Friend WithEvents bookstatustextBox As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents authortextBox As TextBox
    Friend WithEvents titletextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label1 As Label
    Private WithEvents LogoutPictureBox As PictureBox
    Private WithEvents exitpictureBox As PictureBox
    Private WithEvents backPictureBox As PictureBox
    Friend WithEvents dtpDueDate As DateTimePicker
    Friend WithEvents pendingfinesTextBox As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents rentpricetextBox As TextBox
    Friend WithEvents Label10 As Label
End Class
