namespace User_registration_by_Nesa
{
    partial class CustomerHome
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
            this.DateTimetimer = new System.Windows.Forms.Timer(this.components);
            this.registerButton = new System.Windows.Forms.Button();
            this.custsearchbutton = new System.Windows.Forms.Button();
            this.custtransferbutton = new System.Windows.Forms.Button();
            this.topupbutton = new System.Windows.Forms.Button();
            this.editbutton = new System.Windows.Forms.Button();
            this.datetimelabel = new System.Windows.Forms.Label();
            this.customerButton = new System.Windows.Forms.Button();
            this.systemButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.ChangeCustButton = new System.Windows.Forms.Button();
            this.currentbalancelabel = new System.Windows.Forms.Label();
            this.displaycurrentbalancelabel = new System.Windows.Forms.Label();
            this.custidlabel = new System.Windows.Forms.Label();
            this.custiddisplaylabel = new System.Windows.Forms.Label();
            this.custloginbutton = new System.Windows.Forms.Button();
            this.backbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DateTimetimer
            // 
            this.DateTimetimer.Interval = 1000;
            this.DateTimetimer.Tick += new System.EventHandler(this.DateTimetimer_Tick);
            // 
            // registerButton
            // 
            this.registerButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.registerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.registerButton.Location = new System.Drawing.Point(487, 265);
            this.registerButton.Name = "registerButton";
            this.registerButton.Size = new System.Drawing.Size(122, 103);
            this.registerButton.TabIndex = 4;
            this.registerButton.Text = "Customer Registration";
            this.registerButton.UseVisualStyleBackColor = false;
            this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
            // 
            // custsearchbutton
            // 
            this.custsearchbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custsearchbutton.Location = new System.Drawing.Point(356, 265);
            this.custsearchbutton.Name = "custsearchbutton";
            this.custsearchbutton.Size = new System.Drawing.Size(125, 103);
            this.custsearchbutton.TabIndex = 3;
            this.custsearchbutton.Text = "Customer Search";
            this.custsearchbutton.UseVisualStyleBackColor = true;
            this.custsearchbutton.Click += new System.EventHandler(this.custsearchbutton_Click);
            // 
            // custtransferbutton
            // 
            this.custtransferbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custtransferbutton.Location = new System.Drawing.Point(418, 141);
            this.custtransferbutton.Name = "custtransferbutton";
            this.custtransferbutton.Size = new System.Drawing.Size(126, 104);
            this.custtransferbutton.TabIndex = 1;
            this.custtransferbutton.Text = "Credit Transfer";
            this.custtransferbutton.UseVisualStyleBackColor = true;
            this.custtransferbutton.Click += new System.EventHandler(this.custtransferbutton_Click);
            // 
            // topupbutton
            // 
            this.topupbutton.Location = new System.Drawing.Point(287, 141);
            this.topupbutton.Name = "topupbutton";
            this.topupbutton.Size = new System.Drawing.Size(125, 103);
            this.topupbutton.TabIndex = 0;
            this.topupbutton.Text = "Top Up";
            this.topupbutton.UseVisualStyleBackColor = true;
            this.topupbutton.Click += new System.EventHandler(this.topupbutton_Click);
            // 
            // editbutton
            // 
            this.editbutton.Location = new System.Drawing.Point(549, 141);
            this.editbutton.Name = "editbutton";
            this.editbutton.Size = new System.Drawing.Size(125, 103);
            this.editbutton.TabIndex = 2;
            this.editbutton.Text = "Edit Profile";
            this.editbutton.UseVisualStyleBackColor = true;
            this.editbutton.Click += new System.EventHandler(this.editbutton_Click);
            // 
            // datetimelabel
            // 
            this.datetimelabel.AutoSize = true;
            this.datetimelabel.Location = new System.Drawing.Point(50, 35);
            this.datetimelabel.Name = "datetimelabel";
            this.datetimelabel.Size = new System.Drawing.Size(66, 13);
            this.datetimelabel.TabIndex = 131;
            this.datetimelabel.Text = "Date && TIme";
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(12, 316);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(138, 84);
            this.customerButton.TabIndex = 9;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            // 
            // systemButton
            // 
            this.systemButton.Location = new System.Drawing.Point(12, 197);
            this.systemButton.Name = "systemButton";
            this.systemButton.Size = new System.Drawing.Size(138, 88);
            this.systemButton.TabIndex = 8;
            this.systemButton.Text = "System";
            this.systemButton.UseVisualStyleBackColor = true;
            this.systemButton.Click += new System.EventHandler(this.systemButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(12, 84);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(138, 88);
            this.orderButton.TabIndex = 7;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.Location = new System.Drawing.Point(743, 11);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(55, 37);
            this.exitbutton.TabIndex = 6;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // ChangeCustButton
            // 
            this.ChangeCustButton.Location = new System.Drawing.Point(743, 54);
            this.ChangeCustButton.Name = "ChangeCustButton";
            this.ChangeCustButton.Size = new System.Drawing.Size(56, 42);
            this.ChangeCustButton.TabIndex = 5;
            this.ChangeCustButton.Text = "Change CustID";
            this.ChangeCustButton.UseVisualStyleBackColor = true;
            this.ChangeCustButton.Visible = false;
            this.ChangeCustButton.Click += new System.EventHandler(this.quickchangememberbutton_Click);
            // 
            // currentbalancelabel
            // 
            this.currentbalancelabel.AutoSize = true;
            this.currentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentbalancelabel.Location = new System.Drawing.Point(544, 82);
            this.currentbalancelabel.Name = "currentbalancelabel";
            this.currentbalancelabel.Size = new System.Drawing.Size(76, 25);
            this.currentbalancelabel.TabIndex = 139;
            this.currentbalancelabel.Text = "label3";
            this.currentbalancelabel.Visible = false;
            // 
            // displaycurrentbalancelabel
            // 
            this.displaycurrentbalancelabel.AutoSize = true;
            this.displaycurrentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaycurrentbalancelabel.Location = new System.Drawing.Point(319, 82);
            this.displaycurrentbalancelabel.Name = "displaycurrentbalancelabel";
            this.displaycurrentbalancelabel.Size = new System.Drawing.Size(231, 25);
            this.displaycurrentbalancelabel.TabIndex = 138;
            this.displaycurrentbalancelabel.Text = "Current Balance: RM";
            this.displaycurrentbalancelabel.Visible = false;
            // 
            // custidlabel
            // 
            this.custidlabel.AutoSize = true;
            this.custidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custidlabel.Location = new System.Drawing.Point(487, 54);
            this.custidlabel.Name = "custidlabel";
            this.custidlabel.Size = new System.Drawing.Size(70, 25);
            this.custidlabel.TabIndex = 137;
            this.custidlabel.Text = "label2";
            this.custidlabel.Visible = false;
            // 
            // custiddisplaylabel
            // 
            this.custiddisplaylabel.AutoSize = true;
            this.custiddisplaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custiddisplaylabel.Location = new System.Drawing.Point(399, 54);
            this.custiddisplaylabel.Name = "custiddisplaylabel";
            this.custiddisplaylabel.Size = new System.Drawing.Size(82, 25);
            this.custiddisplaylabel.TabIndex = 136;
            this.custiddisplaylabel.Text = "CustID:";
            this.custiddisplaylabel.Visible = false;
            // 
            // custloginbutton
            // 
            this.custloginbutton.Location = new System.Drawing.Point(743, 55);
            this.custloginbutton.Name = "custloginbutton";
            this.custloginbutton.Size = new System.Drawing.Size(55, 40);
            this.custloginbutton.TabIndex = 5;
            this.custloginbutton.Text = "CustID Login";
            this.custloginbutton.UseVisualStyleBackColor = true;
            this.custloginbutton.Click += new System.EventHandler(this.custloginbutton_Click);
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(41, 406);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(75, 23);
            this.backbutton.TabIndex = 10;
            this.backbutton.Text = "Back";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // CustomerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.custloginbutton);
            this.Controls.Add(this.currentbalancelabel);
            this.Controls.Add(this.displaycurrentbalancelabel);
            this.Controls.Add(this.custidlabel);
            this.Controls.Add(this.custiddisplaylabel);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.ChangeCustButton);
            this.Controls.Add(this.datetimelabel);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.systemButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.registerButton);
            this.Controls.Add(this.custsearchbutton);
            this.Controls.Add(this.custtransferbutton);
            this.Controls.Add(this.topupbutton);
            this.Controls.Add(this.editbutton);
            this.Name = "CustomerHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CustomerHome";
            this.Load += new System.EventHandler(this.CustomerHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer DateTimetimer;
        private System.Windows.Forms.Button registerButton;
        private System.Windows.Forms.Button custsearchbutton;
        private System.Windows.Forms.Button custtransferbutton;
        private System.Windows.Forms.Button topupbutton;
        private System.Windows.Forms.Button editbutton;
        private System.Windows.Forms.Label datetimelabel;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button systemButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button ChangeCustButton;
        private System.Windows.Forms.Label currentbalancelabel;
        private System.Windows.Forms.Label displaycurrentbalancelabel;
        private System.Windows.Forms.Label custidlabel;
        private System.Windows.Forms.Label custiddisplaylabel;
        private System.Windows.Forms.Button custloginbutton;
        private System.Windows.Forms.Button backbutton;
    }
}