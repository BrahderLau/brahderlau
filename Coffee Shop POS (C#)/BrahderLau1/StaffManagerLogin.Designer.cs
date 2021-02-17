namespace User_registration_by_Nesa
{
    partial class StaffManagerLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.usernametextBox = new System.Windows.Forms.TextBox();
            this.passwordtextBox = new System.Windows.Forms.TextBox();
            this.loginbutton = new System.Windows.Forms.Button();
            this.remembermecheckBox = new System.Windows.Forms.CheckBox();
            this.stafflabel = new System.Windows.Forms.Label();
            this.datetimelabel = new System.Windows.Forms.Label();
            this.DateTimetimer = new System.Windows.Forms.Timer(this.components);
            this.managerlinkLabel = new System.Windows.Forms.LinkLabel();
            this.exitbutton = new System.Windows.Forms.Button();
            this.managerlabel = new System.Windows.Forms.Label();
            this.stafflinkLabel = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // usernamelabel
            // 
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Location = new System.Drawing.Point(109, 91);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(61, 13);
            this.usernamelabel.TabIndex = 0;
            this.usernamelabel.Text = "Username :";
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(107, 135);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(59, 13);
            this.passwordlabel.TabIndex = 1;
            this.passwordlabel.Text = "Password :";
            // 
            // usernametextBox
            // 
            this.usernametextBox.Location = new System.Drawing.Point(168, 88);
            this.usernametextBox.Name = "usernametextBox";
            this.usernametextBox.Size = new System.Drawing.Size(100, 20);
            this.usernametextBox.TabIndex = 0;
            // 
            // passwordtextBox
            // 
            this.passwordtextBox.Location = new System.Drawing.Point(168, 132);
            this.passwordtextBox.Name = "passwordtextBox";
            this.passwordtextBox.PasswordChar = '*';
            this.passwordtextBox.Size = new System.Drawing.Size(100, 20);
            this.passwordtextBox.TabIndex = 1;
            // 
            // loginbutton
            // 
            this.loginbutton.Location = new System.Drawing.Point(157, 211);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(75, 23);
            this.loginbutton.TabIndex = 4;
            this.loginbutton.Text = "Login";
            this.loginbutton.UseVisualStyleBackColor = true;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // remembermecheckBox
            // 
            this.remembermecheckBox.AutoSize = true;
            this.remembermecheckBox.Location = new System.Drawing.Point(147, 168);
            this.remembermecheckBox.Name = "remembermecheckBox";
            this.remembermecheckBox.Size = new System.Drawing.Size(95, 17);
            this.remembermecheckBox.TabIndex = 2;
            this.remembermecheckBox.Text = "Remember Me";
            this.remembermecheckBox.UseVisualStyleBackColor = true;
            this.remembermecheckBox.CheckedChanged += new System.EventHandler(this.remembermecheckBox_CheckedChanged);
            // 
            // stafflabel
            // 
            this.stafflabel.AutoSize = true;
            this.stafflabel.Location = new System.Drawing.Point(165, 51);
            this.stafflabel.Name = "stafflabel";
            this.stafflabel.Size = new System.Drawing.Size(58, 13);
            this.stafflabel.TabIndex = 8;
            this.stafflabel.Text = "Staff Login";
            // 
            // datetimelabel
            // 
            this.datetimelabel.AutoSize = true;
            this.datetimelabel.Location = new System.Drawing.Point(13, 264);
            this.datetimelabel.Name = "datetimelabel";
            this.datetimelabel.Size = new System.Drawing.Size(66, 13);
            this.datetimelabel.TabIndex = 10;
            this.datetimelabel.Text = "Date && TIme";
            // 
            // DateTimetimer
            // 
            this.DateTimetimer.Interval = 1000;
            this.DateTimetimer.Tick += new System.EventHandler(this.DateTimetimer_Tick);
            // 
            // managerlinkLabel
            // 
            this.managerlinkLabel.AutoSize = true;
            this.managerlinkLabel.Location = new System.Drawing.Point(118, 188);
            this.managerlinkLabel.Name = "managerlinkLabel";
            this.managerlinkLabel.Size = new System.Drawing.Size(150, 13);
            this.managerlinkLabel.TabIndex = 3;
            this.managerlinkLabel.TabStop = true;
            this.managerlinkLabel.Text = "Click here to login as Manager";
            this.managerlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.managerlinkLabel_LinkClicked);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.Location = new System.Drawing.Point(314, 12);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(55, 37);
            this.exitbutton.TabIndex = 5;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // managerlabel
            // 
            this.managerlabel.AutoSize = true;
            this.managerlabel.Location = new System.Drawing.Point(154, 51);
            this.managerlabel.Name = "managerlabel";
            this.managerlabel.Size = new System.Drawing.Size(78, 13);
            this.managerlabel.TabIndex = 118;
            this.managerlabel.Text = "Manager Login";
            // 
            // stafflinkLabel
            // 
            this.stafflinkLabel.AutoSize = true;
            this.stafflinkLabel.Location = new System.Drawing.Point(128, 188);
            this.stafflinkLabel.Name = "stafflinkLabel";
            this.stafflinkLabel.Size = new System.Drawing.Size(130, 13);
            this.stafflinkLabel.TabIndex = 3;
            this.stafflinkLabel.TabStop = true;
            this.stafflinkLabel.Text = "Click here to login as Staff";
            this.stafflinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.stafflinkLabel_LinkClicked);
            // 
            // StaffManagerLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 289);
            this.Controls.Add(this.stafflinkLabel);
            this.Controls.Add(this.managerlabel);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.managerlinkLabel);
            this.Controls.Add(this.datetimelabel);
            this.Controls.Add(this.stafflabel);
            this.Controls.Add(this.remembermecheckBox);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.passwordtextBox);
            this.Controls.Add(this.usernametextBox);
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.usernamelabel);
            this.Name = "StaffManagerLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.TextBox usernametextBox;
        private System.Windows.Forms.TextBox passwordtextBox;
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.CheckBox remembermecheckBox;
        private System.Windows.Forms.Label stafflabel;
        private System.Windows.Forms.Label datetimelabel;
        private System.Windows.Forms.Timer DateTimetimer;
        private System.Windows.Forms.LinkLabel managerlinkLabel;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Label managerlabel;
        private System.Windows.Forms.LinkLabel stafflinkLabel;
    }
}

