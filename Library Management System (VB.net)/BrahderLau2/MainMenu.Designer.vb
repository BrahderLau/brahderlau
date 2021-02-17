<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
        Me.rentButton = New System.Windows.Forms.Button()
        Me.memberButton = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.exitpictureBox = New System.Windows.Forms.PictureBox()
        Me.LogoutPictureBox = New System.Windows.Forms.PictureBox()
        Me.addbookButton = New System.Windows.Forms.Button()
        Me.returnButton = New System.Windows.Forms.Button()
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rentButton
        '
        Me.rentButton.BackgroundImage = CType(resources.GetObject("rentButton.BackgroundImage"), System.Drawing.Image)
        Me.rentButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.rentButton.Location = New System.Drawing.Point(98, 185)
        Me.rentButton.Name = "rentButton"
        Me.rentButton.Size = New System.Drawing.Size(127, 108)
        Me.rentButton.TabIndex = 0
        Me.rentButton.UseVisualStyleBackColor = True
        '
        'memberButton
        '
        Me.memberButton.BackgroundImage = CType(resources.GetObject("memberButton.BackgroundImage"), System.Drawing.Image)
        Me.memberButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.memberButton.Location = New System.Drawing.Point(98, 362)
        Me.memberButton.Name = "memberButton"
        Me.memberButton.Size = New System.Drawing.Size(127, 108)
        Me.memberButton.TabIndex = 2
        Me.memberButton.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(74, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(399, 34)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Please select an option:"
        '
        'exitpictureBox
        '
        Me.exitpictureBox.BackColor = System.Drawing.Color.Transparent
        Me.exitpictureBox.Image = CType(resources.GetObject("exitpictureBox.Image"), System.Drawing.Image)
        Me.exitpictureBox.Location = New System.Drawing.Point(463, 12)
        Me.exitpictureBox.Name = "exitpictureBox"
        Me.exitpictureBox.Size = New System.Drawing.Size(42, 46)
        Me.exitpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.exitpictureBox.TabIndex = 18
        Me.exitpictureBox.TabStop = False
        '
        'LogoutPictureBox
        '
        Me.LogoutPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoutPictureBox.Image = CType(resources.GetObject("LogoutPictureBox.Image"), System.Drawing.Image)
        Me.LogoutPictureBox.Location = New System.Drawing.Point(12, 12)
        Me.LogoutPictureBox.Name = "LogoutPictureBox"
        Me.LogoutPictureBox.Size = New System.Drawing.Size(46, 46)
        Me.LogoutPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.LogoutPictureBox.TabIndex = 19
        Me.LogoutPictureBox.TabStop = False
        '
        'addbookButton
        '
        Me.addbookButton.BackgroundImage = CType(resources.GetObject("addbookButton.BackgroundImage"), System.Drawing.Image)
        Me.addbookButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.addbookButton.Location = New System.Drawing.Point(302, 362)
        Me.addbookButton.Name = "addbookButton"
        Me.addbookButton.Size = New System.Drawing.Size(127, 108)
        Me.addbookButton.TabIndex = 3
        Me.addbookButton.UseVisualStyleBackColor = True
        '
        'returnButton
        '
        Me.returnButton.BackgroundImage = CType(resources.GetObject("returnButton.BackgroundImage"), System.Drawing.Image)
        Me.returnButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.returnButton.Location = New System.Drawing.Point(302, 185)
        Me.returnButton.Name = "returnButton"
        Me.returnButton.Size = New System.Drawing.Size(127, 108)
        Me.returnButton.TabIndex = 1
        Me.returnButton.UseVisualStyleBackColor = True
        '
        'MainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PapayaWhip
        Me.ClientSize = New System.Drawing.Size(533, 519)
        Me.Controls.Add(Me.returnButton)
        Me.Controls.Add(Me.addbookButton)
        Me.Controls.Add(Me.LogoutPictureBox)
        Me.Controls.Add(Me.exitpictureBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.memberButton)
        Me.Controls.Add(Me.rentButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form2"
        CType(Me.exitpictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoutPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents rentButton As Button
    Friend WithEvents memberButton As Button
    Friend WithEvents Label1 As Label
    Private WithEvents exitpictureBox As PictureBox
    Private WithEvents LogoutPictureBox As PictureBox
    Friend WithEvents addbookButton As Button
    Friend WithEvents returnButton As Button
End Class
