<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.passwordtextBox = New System.Windows.Forms.TextBox()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.staffidtextBox = New System.Windows.Forms.TextBox()
        Me.exitpictureBox = New System.Windows.Forms.PictureBox()
        Me.pictureBox5 = New System.Windows.Forms.PictureBox()
        Me.pictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.LoginButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.Black
        Me.panel2.Location = New System.Drawing.Point(216, 425)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(151, 1)
        Me.panel2.TabIndex = 21
        '
        'passwordtextBox
        '
        Me.passwordtextBox.BackColor = System.Drawing.Color.PapayaWhip
        Me.passwordtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.passwordtextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordtextBox.Location = New System.Drawing.Point(216, 388)
        Me.passwordtextBox.Name = "passwordtextBox"
        Me.passwordtextBox.Size = New System.Drawing.Size(151, 31)
        Me.passwordtextBox.TabIndex = 2
        Me.passwordtextBox.Text = "Password"
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.Black
        Me.panel1.Location = New System.Drawing.Point(216, 337)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(151, 1)
        Me.panel1.TabIndex = 19
        '
        'staffidtextBox
        '
        Me.staffidtextBox.BackColor = System.Drawing.Color.PapayaWhip
        Me.staffidtextBox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.staffidtextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staffidtextBox.Location = New System.Drawing.Point(216, 300)
        Me.staffidtextBox.Name = "staffidtextBox"
        Me.staffidtextBox.Size = New System.Drawing.Size(151, 31)
        Me.staffidtextBox.TabIndex = 1
        Me.staffidtextBox.Text = "StaffID"
        '
        'exitpictureBox
        '
        Me.exitpictureBox.BackColor = System.Drawing.Color.Transparent
        Me.exitpictureBox.Image = CType(resources.GetObject("exitpictureBox.Image"), System.Drawing.Image)
        Me.exitpictureBox.Location = New System.Drawing.Point(475, 12)
        Me.exitpictureBox.Name = "exitpictureBox"
        Me.exitpictureBox.Size = New System.Drawing.Size(42, 46)
        Me.exitpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.exitpictureBox.TabIndex = 17
        Me.exitpictureBox.TabStop = False
        '
        'pictureBox5
        '
        Me.pictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox5.Image = CType(resources.GetObject("pictureBox5.Image"), System.Drawing.Image)
        Me.pictureBox5.Location = New System.Drawing.Point(154, 380)
        Me.pictureBox5.Name = "pictureBox5"
        Me.pictureBox5.Size = New System.Drawing.Size(46, 46)
        Me.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox5.TabIndex = 16
        Me.pictureBox5.TabStop = False
        '
        'pictureBox1
        '
        Me.pictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.pictureBox1.Image = CType(resources.GetObject("pictureBox1.Image"), System.Drawing.Image)
        Me.pictureBox1.Location = New System.Drawing.Point(154, 292)
        Me.pictureBox1.Name = "pictureBox1"
        Me.pictureBox1.Size = New System.Drawing.Size(46, 46)
        Me.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureBox1.TabIndex = 12
        Me.pictureBox1.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(167, 12)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(200, 179)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox7.TabIndex = 24
        Me.PictureBox7.TabStop = False
        '
        'LoginButton
        '
        Me.LoginButton.BackColor = System.Drawing.Color.FloralWhite
        Me.LoginButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LoginButton.Location = New System.Drawing.Point(187, 456)
        Me.LoginButton.Name = "LoginButton"
        Me.LoginButton.Size = New System.Drawing.Size(159, 52)
        Me.LoginButton.TabIndex = 3
        Me.LoginButton.Text = "Login"
        Me.LoginButton.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Mistral", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 218)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(389, 57)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "APU Book Rental Shop"
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(533, 519)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LoginButton)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.passwordtextBox)
        Me.Controls.Add(Me.panel1)
        Me.Controls.Add(Me.staffidtextBox)
        Me.Controls.Add(Me.exitpictureBox)
        Me.Controls.Add(Me.pictureBox5)
        Me.Controls.Add(Me.pictureBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panel2 As Panel
    Private WithEvents passwordtextBox As TextBox
    Private WithEvents panel1 As Panel
    Private WithEvents staffidtextBox As TextBox
    Private WithEvents exitpictureBox As PictureBox
    Private WithEvents pictureBox5 As PictureBox
    Private WithEvents pictureBox1 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents LoginButton As Button
    Friend WithEvents Label1 As Label
End Class
