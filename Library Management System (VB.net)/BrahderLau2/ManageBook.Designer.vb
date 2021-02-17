<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ManageBook
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ManageBook))
        Me.backPictureBox = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LogoutPictureBox = New System.Windows.Forms.PictureBox()
        Me.exitpictureBox = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.deleteButton = New System.Windows.Forms.Button()
        Me.btnClearFields = New System.Windows.Forms.Button()
        Me.yeartextBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bookpricetextBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rentpricetextBox = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.addButton = New System.Windows.Forms.Button()
        Me.publishertextBox = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.authortextBox = New System.Windows.Forms.TextBox()
        Me.titletextBox = New System.Windows.Forms.TextBox()
        Me.isbntextBox = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.BookDataGridView = New System.Windows.Forms.DataGridView()
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BookDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'backPictureBox
        '
        Me.backPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.backPictureBox.Image = CType(resources.GetObject("backPictureBox.Image"), System.Drawing.Image)
        Me.backPictureBox.Location = New System.Drawing.Point(458, 222)
        Me.backPictureBox.Name = "backPictureBox"
        Me.backPictureBox.Size = New System.Drawing.Size(45, 46)
        Me.backPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.backPictureBox.TabIndex = 40
        Me.backPictureBox.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Mistral", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(158, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 57)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Manage Book"
        '
        'LogoutPictureBox
        '
        Me.LogoutPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoutPictureBox.Image = CType(resources.GetObject("LogoutPictureBox.Image"), System.Drawing.Image)
        Me.LogoutPictureBox.Location = New System.Drawing.Point(17, 11)
        Me.LogoutPictureBox.Name = "LogoutPictureBox"
        Me.LogoutPictureBox.Size = New System.Drawing.Size(46, 46)
        Me.LogoutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogoutPictureBox.TabIndex = 35
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
        Me.exitpictureBox.TabIndex = 34
        Me.exitpictureBox.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GroupBox2.Controls.Add(Me.deleteButton)
        Me.GroupBox2.Controls.Add(Me.btnClearFields)
        Me.GroupBox2.Controls.Add(Me.yeartextBox)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.backPictureBox)
        Me.GroupBox2.Controls.Add(Me.bookpricetextBox)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.rentpricetextBox)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.addButton)
        Me.GroupBox2.Controls.Add(Me.publishertextBox)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.authortextBox)
        Me.GroupBox2.Controls.Add(Me.titletextBox)
        Me.GroupBox2.Controls.Add(Me.isbntextBox)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 274)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Book Information"
        '
        'deleteButton
        '
        Me.deleteButton.BackColor = System.Drawing.Color.MediumTurquoise
        Me.deleteButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.deleteButton.Location = New System.Drawing.Point(200, 239)
        Me.deleteButton.Name = "deleteButton"
        Me.deleteButton.Size = New System.Drawing.Size(92, 27)
        Me.deleteButton.TabIndex = 43
        Me.deleteButton.Text = "&Delete Book"
        Me.deleteButton.UseVisualStyleBackColor = False
        '
        'btnClearFields
        '
        Me.btnClearFields.BackColor = System.Drawing.Color.DimGray
        Me.btnClearFields.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClearFields.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise
        Me.btnClearFields.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearFields.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClearFields.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnClearFields.Location = New System.Drawing.Point(106, 239)
        Me.btnClearFields.Name = "btnClearFields"
        Me.btnClearFields.Size = New System.Drawing.Size(88, 27)
        Me.btnClearFields.TabIndex = 8
        Me.btnClearFields.Text = "Clear Entry"
        Me.btnClearFields.UseVisualStyleBackColor = False
        '
        'yeartextBox
        '
        Me.yeartextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.yeartextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.yeartextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.yeartextBox.Location = New System.Drawing.Point(144, 145)
        Me.yeartextBox.Name = "yeartextBox"
        Me.yeartextBox.Size = New System.Drawing.Size(70, 25)
        Me.yeartextBox.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Publication Year :"
        '
        'bookpricetextBox
        '
        Me.bookpricetextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.bookpricetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.bookpricetextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bookpricetextBox.Location = New System.Drawing.Point(144, 178)
        Me.bookpricetextBox.Name = "bookpricetextBox"
        Me.bookpricetextBox.Size = New System.Drawing.Size(70, 25)
        Me.bookpricetextBox.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 17)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Book Price (RM) :"
        '
        'rentpricetextBox
        '
        Me.rentpricetextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.rentpricetextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rentpricetextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rentpricetextBox.Location = New System.Drawing.Point(144, 210)
        Me.rentpricetextBox.Name = "rentpricetextBox"
        Me.rentpricetextBox.Size = New System.Drawing.Size(70, 25)
        Me.rentpricetextBox.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 211)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 17)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Rent Price (RM) :"
        '
        'addButton
        '
        Me.addButton.BackColor = System.Drawing.Color.MediumTurquoise
        Me.addButton.FlatAppearance.BorderColor = System.Drawing.Color.Teal
        Me.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.addButton.Location = New System.Drawing.Point(12, 239)
        Me.addButton.Name = "addButton"
        Me.addButton.Size = New System.Drawing.Size(88, 27)
        Me.addButton.TabIndex = 7
        Me.addButton.Text = "&Add Book"
        Me.addButton.UseVisualStyleBackColor = False
        '
        'publishertextBox
        '
        Me.publishertextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.publishertextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.publishertextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.publishertextBox.Location = New System.Drawing.Point(144, 114)
        Me.publishertextBox.Name = "publishertextBox"
        Me.publishertextBox.Size = New System.Drawing.Size(346, 25)
        Me.publishertextBox.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 117)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 17)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Publisher :"
        '
        'authortextBox
        '
        Me.authortextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.authortextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.authortextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.authortextBox.Location = New System.Drawing.Point(144, 84)
        Me.authortextBox.Name = "authortextBox"
        Me.authortextBox.Size = New System.Drawing.Size(346, 25)
        Me.authortextBox.TabIndex = 2
        '
        'titletextBox
        '
        Me.titletextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.titletextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.titletextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.titletextBox.Location = New System.Drawing.Point(144, 54)
        Me.titletextBox.Name = "titletextBox"
        Me.titletextBox.Size = New System.Drawing.Size(346, 25)
        Me.titletextBox.TabIndex = 1
        '
        'isbntextBox
        '
        Me.isbntextBox.BackColor = System.Drawing.SystemColors.ControlLight
        Me.isbntextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.isbntextBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.isbntextBox.Location = New System.Drawing.Point(144, 24)
        Me.isbntextBox.Name = "isbntextBox"
        Me.isbntextBox.Size = New System.Drawing.Size(120, 25)
        Me.isbntextBox.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 87)
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
        Me.Label9.Location = New System.Drawing.Point(9, 57)
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
        Me.Label23.Location = New System.Drawing.Point(9, 27)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(42, 17)
        Me.Label23.TabIndex = 0
        Me.Label23.Text = "ISBN :"
        '
        'BookDataGridView
        '
        Me.BookDataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BookDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.BookDataGridView.Location = New System.Drawing.Point(4, 343)
        Me.BookDataGridView.Name = "BookDataGridView"
        Me.BookDataGridView.Size = New System.Drawing.Size(527, 174)
        Me.BookDataGridView.TabIndex = 42
        '
        'ManageBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(533, 519)
        Me.Controls.Add(Me.BookDataGridView)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LogoutPictureBox)
        Me.Controls.Add(Me.exitpictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ManageBook"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AddBook"
        CType(Me.backPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BookDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents backPictureBox As PictureBox
    Friend WithEvents Label1 As Label
    Private WithEvents LogoutPictureBox As PictureBox
    Private WithEvents exitpictureBox As PictureBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents rentpricetextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents addButton As Button
    Friend WithEvents publishertextBox As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents authortextBox As TextBox
    Friend WithEvents titletextBox As TextBox
    Friend WithEvents isbntextBox As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents yeartextBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents bookpricetextBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents BookDataGridView As DataGridView
    Friend WithEvents btnClearFields As Button
    Friend WithEvents deleteButton As Button
End Class
