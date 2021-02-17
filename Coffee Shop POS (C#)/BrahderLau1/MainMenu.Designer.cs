namespace User_registration_by_Nesa
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.orderButton = new System.Windows.Forms.Button();
            this.systemButton = new System.Windows.Forms.Button();
            this.customerButton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.ChangeCustButton = new System.Windows.Forms.Button();
            this.DateTimetimer = new System.Windows.Forms.Timer(this.components);
            this.datetimelabel = new System.Windows.Forms.Label();
            this.custidlabel = new System.Windows.Forms.Label();
            this.custiddisplaylabel = new System.Windows.Forms.Label();
            this.displaycurrentbalancelabel = new System.Windows.Forms.Label();
            this.currentbalancelabel = new System.Windows.Forms.Label();
            this.custloginbutton = new System.Windows.Forms.Button();
            this.logoutbutton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // orderButton
            // 
            this.orderButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderButton.Location = new System.Drawing.Point(24, 79);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(138, 88);
            this.orderButton.TabIndex = 0;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // systemButton
            // 
            this.systemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.systemButton.Location = new System.Drawing.Point(24, 192);
            this.systemButton.Name = "systemButton";
            this.systemButton.Size = new System.Drawing.Size(138, 88);
            this.systemButton.TabIndex = 1;
            this.systemButton.Text = "System";
            this.systemButton.UseVisualStyleBackColor = true;
            this.systemButton.Click += new System.EventHandler(this.systemButton_Click);
            // 
            // customerButton
            // 
            this.customerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customerButton.Location = new System.Drawing.Point(24, 311);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(138, 84);
            this.customerButton.TabIndex = 2;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.Location = new System.Drawing.Point(733, 12);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(55, 37);
            this.exitbutton.TabIndex = 5;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // ChangeCustButton
            // 
            this.ChangeCustButton.Location = new System.Drawing.Point(733, 55);
            this.ChangeCustButton.Name = "ChangeCustButton";
            this.ChangeCustButton.Size = new System.Drawing.Size(56, 42);
            this.ChangeCustButton.TabIndex = 114;
            this.ChangeCustButton.Text = "Change CustID";
            this.ChangeCustButton.UseVisualStyleBackColor = true;
            this.ChangeCustButton.Visible = false;
            this.ChangeCustButton.Click += new System.EventHandler(this.ChangeCustButton_Click);
            // 
            // DateTimetimer
            // 
            this.DateTimetimer.Interval = 1000;
            this.DateTimetimer.Tick += new System.EventHandler(this.DateTimetimer_Tick);
            // 
            // datetimelabel
            // 
            this.datetimelabel.AutoSize = true;
            this.datetimelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datetimelabel.Location = new System.Drawing.Point(37, 30);
            this.datetimelabel.Name = "datetimelabel";
            this.datetimelabel.Size = new System.Drawing.Size(125, 24);
            this.datetimelabel.TabIndex = 123;
            this.datetimelabel.Text = "Date && TIme";
            // 
            // custidlabel
            // 
            this.custidlabel.AutoSize = true;
            this.custidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custidlabel.Location = new System.Drawing.Point(473, 29);
            this.custidlabel.Name = "custidlabel";
            this.custidlabel.Size = new System.Drawing.Size(70, 25);
            this.custidlabel.TabIndex = 126;
            this.custidlabel.Text = "label2";
            this.custidlabel.Visible = false;
            // 
            // custiddisplaylabel
            // 
            this.custiddisplaylabel.AutoSize = true;
            this.custiddisplaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custiddisplaylabel.Location = new System.Drawing.Point(385, 29);
            this.custiddisplaylabel.Name = "custiddisplaylabel";
            this.custiddisplaylabel.Size = new System.Drawing.Size(82, 25);
            this.custiddisplaylabel.TabIndex = 125;
            this.custiddisplaylabel.Text = "CustID:";
            this.custiddisplaylabel.Visible = false;
            // 
            // displaycurrentbalancelabel
            // 
            this.displaycurrentbalancelabel.AutoSize = true;
            this.displaycurrentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaycurrentbalancelabel.Location = new System.Drawing.Point(305, 57);
            this.displaycurrentbalancelabel.Name = "displaycurrentbalancelabel";
            this.displaycurrentbalancelabel.Size = new System.Drawing.Size(231, 25);
            this.displaycurrentbalancelabel.TabIndex = 127;
            this.displaycurrentbalancelabel.Text = "Current Balance: RM";
            this.displaycurrentbalancelabel.Visible = false;
            // 
            // currentbalancelabel
            // 
            this.currentbalancelabel.AutoSize = true;
            this.currentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentbalancelabel.Location = new System.Drawing.Point(530, 57);
            this.currentbalancelabel.Name = "currentbalancelabel";
            this.currentbalancelabel.Size = new System.Drawing.Size(76, 25);
            this.currentbalancelabel.TabIndex = 128;
            this.currentbalancelabel.Text = "label3";
            this.currentbalancelabel.Visible = false;
            // 
            // custloginbutton
            // 
            this.custloginbutton.Location = new System.Drawing.Point(733, 56);
            this.custloginbutton.Name = "custloginbutton";
            this.custloginbutton.Size = new System.Drawing.Size(55, 40);
            this.custloginbutton.TabIndex = 6;
            this.custloginbutton.Text = "CustID Login";
            this.custloginbutton.UseVisualStyleBackColor = true;
            this.custloginbutton.Click += new System.EventHandler(this.custloginbutton_Click);
            // 
            // logoutbutton
            // 
            this.logoutbutton.Location = new System.Drawing.Point(57, 401);
            this.logoutbutton.Name = "logoutbutton";
            this.logoutbutton.Size = new System.Drawing.Size(75, 23);
            this.logoutbutton.TabIndex = 4;
            this.logoutbutton.Text = "Log Out";
            this.logoutbutton.UseVisualStyleBackColor = true;
            this.logoutbutton.Click += new System.EventHandler(this.logoutbutton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(224, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(496, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 131;
            this.pictureBox1.TabStop = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.logoutbutton);
            this.Controls.Add(this.custloginbutton);
            this.Controls.Add(this.currentbalancelabel);
            this.Controls.Add(this.displaycurrentbalancelabel);
            this.Controls.Add(this.custidlabel);
            this.Controls.Add(this.custiddisplaylabel);
            this.Controls.Add(this.datetimelabel);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.ChangeCustButton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.systemButton);
            this.Controls.Add(this.orderButton);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewHomePage";
            this.Load += new System.EventHandler(this.NewHomePage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button systemButton;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button ChangeCustButton;
        private System.Windows.Forms.Timer DateTimetimer;
        private System.Windows.Forms.Label datetimelabel;
        private System.Windows.Forms.Label custidlabel;
        private System.Windows.Forms.Label custiddisplaylabel;
        private System.Windows.Forms.Label displaycurrentbalancelabel;
        private System.Windows.Forms.Label currentbalancelabel;
        private System.Windows.Forms.Button custloginbutton;
        private System.Windows.Forms.Button logoutbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}