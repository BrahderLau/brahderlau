<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Member
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Member))
        Me.LogoutPictureBox = New System.Windows.Forms.PictureBox()
        Me.exitpictureBox = New System.Windows.Forms.PictureBox()
        Me.backPictureBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.memberidtextBox = New System.Windows.Forms.MaskedTextBox()
        Me.membernameTextBox = New System.Windows.Forms.TextBox()
        Me.membertypetextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.searchbyComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.booktransactionDataGridView = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.clearfinesButton = New System.Windows.Forms.Button()
        Me.pendingfinesTextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.booktransactionDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'LogoutPictureBox
        '
        Me.LogoutPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoutPictureBox.Image = CType(resources.GetObject("LogoutPictureBox.Image"), System.Drawing.Image)
        Me.LogoutPictureBox.Location = New System.Drawing.Point(19, 12)
        Me.LogoutPictureBox.Name = "LogoutPictureBox"
        Me.LogoutPictureBox.Size = New System.Drawing.Size(46, 46)
        Me.LogoutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogoutPictureBox.TabIndex = 21
        Me.LogoutPictureBox.TabStop = False
        '
        'exitpictureBox
        '
        Me.exitpictureBox.BackColor = System.Drawing.Color.Transparent
        Me.exitpictureBox.Image = CType(resources.GetObject("exitpictureBox.Image"), System.Drawing.Image)
        Me.exitpictureBox.Location = New System.Drawing.Point(470, 12)
        Me.exitpictureBox.Name = "exitpictureBox"
        Me.exitpictureBox.Size = New System.Drawing.Size(42, 46)
        Me.exitpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.exitpictureBox.TabIndex = 20
        Me.exitpictureBox.TabStop = False
        '
        'backPictureBox
        '
        Me.backPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.backPictureBox.Image = CType(resources.GetObject("backPictureBox.Image"), System.Drawing.Image)
        Me.backPictureBox.Location = New System.Drawing.Point(20, 461)
        Me.backPictureBox.Name = "backPictureBox"
        Me.backPictureBox.Size = New System.Drawing.Size(45, 46)
        Me.backPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.backPictureBox.TabIndex = 34
        Me.backPictureBox.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.memberidtextBox)
        Me.GroupBox1.Controls.Add(Me.membernameTextBox)
        Me.GroupBox1.Controls.Add(Me.membertypetextBox)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(70, 69)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(399, 118)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Member Information"
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
        Me.memberidtextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.memberidtextBox.Location = New System.Drawing.Point(119, 22)
        Me.memberidtextBox.Name = "memberidtextBox"
        Me.memberidtextBox.Size = New System.Drawing.Size(81, 25)
        Me.memberidtextBox.TabIndex = 4
        Me.memberidtextBox.ValidatingType = GetType(Integer)
        '
        'membernameTextBox
        '
        Me.membernameTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.membernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.membernameTextBox.Enabled = False
        Me.membernameTextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membernameTextBox.Location = New System.Drawing.Point(119, 86)
        Me.membernameTextBox.Name = "membernameTextBox"
        Me.membernameTextBox.ReadOnly = True
        Me.membernameTextBox.Size = New System.Drawing.Size(253, 25)
        Me.membernameTextBox.TabIndex = 17
        '
        'membertypetextBox
        '
        Me.membertypetextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.membertypetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.membertypetextBox.Enabled = False
        Me.membertypetextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.membertypetextBox.Location = New System.Drawing.Point(119, 54)
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
        Me.GroupBox2.Controls.Add(Me.searchbyComboBox)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.booktransactionDataGridView)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 193)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 231)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Book Transaction"
        '
        'searchbyComboBox
        '
        Me.searchbyComboBox.FormattingEnabled = True
        Me.searchbyComboBox.Items.AddRange(New Object() {"Currently Borrowed", "Overdue", "Returned"})
        Me.searchbyComboBox.Location = New System.Drawing.Point(83, 21)
        Me.searchbyComboBox.Name = "searchbyComboBox"
        Me.searchbyComboBox.Size = New System.Drawing.Size(121, 25)
        Me.searchbyComboBox.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 17)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Search By :"
        '
        'booktransactionDataGridView
        '
        Me.booktransactionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.booktransactionDataGridView.Location = New System.Drawing.Point(8, 52)
        Me.booktransactionDataGridView.Name = "booktransactionDataGridView"
        Me.booktransactionDataGridView.Size = New System.Drawing.Size(492, 173)
        Me.booktransactionDataGridView.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox3.Controls.Add(Me.clearfinesButton)
        Me.GroupBox3.Controls.Add(Me.pendingfinesTextBox)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(71, 430)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(399, 77)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Fines Payment"
        '
        'clearfinesButton
        '
        Me.clearfinesButton.BackColor = System.Drawing.Color.SteelBlue
        Me.clearfinesButton.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.clearfinesButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise
        Me.clearfinesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.clearfinesButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.clearfinesButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.clearfinesButton.Location = New System.Drawing.Point(150, 42)
        Me.clearfinesButton.Name = "clearfinesButton"
        Me.clearfinesButton.Size = New System.Drawing.Size(94, 30)
        Me.clearfinesButton.TabIndex = 21
        Me.clearfinesButton.Text = "Clear Fines"
        Me.clearfinesButton.UseVisualStyleBackColor = False
        '
        'pendingfinesTextBox
        '
        Me.pendingfinesTextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.pendingfinesTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pendingfinesTextBox.Enabled = False
        Me.pendingfinesTextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pendingfinesTextBox.Location = New System.Drawing.Point(200, 15)
        Me.pendingfinesTextBox.Name = "pendingfinesTextBox"
        Me.pendingfinesTextBox.ReadOnly = True
        Me.pendingfinesTextBox.Size = New System.Drawing.Size(81, 25)
        Me.pendingfinesTextBox.TabIndex = 20
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(102, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Pending Fines:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Mistral", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(208, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 57)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Member"
        '
        'Member
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(533, 519)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.backPictureBox)
        Me.Controls.Add(Me.LogoutPictureBox)
        Me.Controls.Add(Me.exitpictureBox)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Member"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fines"
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.booktransactionDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents LogoutPictureBox As PictureBox
    Private WithEvents exitpictureBox As PictureBox
    Private WithEvents backPictureBox As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label6 As Label
    Friend WithEvents memberidtextBox As MaskedTextBox
    Friend WithEvents membernameTextBox As TextBox
    Friend WithEvents membertypetextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents pendingfinesTextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents clearfinesButton As Button
    Friend WithEvents searchbyComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents booktransactionDataGridView As DataGridView
    Friend WithEvents Label9 As Label
End Class
