namespace User_registration_by_Nesa
{
    partial class CustomerCreditTransfer
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
            this.receiverIDmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.receiverIDlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backbutton = new System.Windows.Forms.Button();
            this.confirmbutton = new System.Windows.Forms.Button();
            this.amountcomboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DateTimetimer = new System.Windows.Forms.Timer(this.components);
            this.datetimelabel = new System.Windows.Forms.Label();
            this.customerButton = new System.Windows.Forms.Button();
            this.systemButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.quickchangememberbutton = new System.Windows.Forms.Button();
            this.custloginbutton = new System.Windows.Forms.Button();
            this.currentbalancelabel = new System.Windows.Forms.Label();
            this.displaycurrentbalancelabel = new System.Windows.Forms.Label();
            this.custidlabel = new System.Windows.Forms.Label();
            this.custiddisplaylabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // receiverIDmaskedTextBox
            // 
            this.receiverIDmaskedTextBox.Location = new System.Drawing.Point(487, 210);
            this.receiverIDmaskedTextBox.Mask = "000000";
            this.receiverIDmaskedTextBox.Name = "receiverIDmaskedTextBox";
            this.receiverIDmaskedTextBox.Size = new System.Drawing.Size(45, 20);
            this.receiverIDmaskedTextBox.TabIndex = 12;
            this.receiverIDmaskedTextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.receiverIDmaskedTextBox_PreviewKeyDown);
            // 
            // receiverIDlabel
            // 
            this.receiverIDlabel.AutoSize = true;
            this.receiverIDlabel.Location = new System.Drawing.Point(406, 213);
            this.receiverIDlabel.Name = "receiverIDlabel";
            this.receiverIDlabel.Size = new System.Drawing.Size(64, 13);
            this.receiverIDlabel.TabIndex = 10;
            this.receiverIDlabel.Text = "Receiver ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(394, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cash Transfer";
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(374, 282);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(75, 23);
            this.backbutton.TabIndex = 119;
            this.backbutton.Text = "Back";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            this.backbutton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.backbutton_PreviewKeyDown);
            // 
            // confirmbutton
            // 
            this.confirmbutton.Location = new System.Drawing.Point(489, 282);
            this.confirmbutton.Name = "confirmbutton";
            this.confirmbutton.Size = new System.Drawing.Size(75, 23);
            this.confirmbutton.TabIndex = 118;
            this.confirmbutton.Text = "Confirm";
            this.confirmbutton.UseVisualStyleBackColor = true;
            this.confirmbutton.Click += new System.EventHandler(this.confirmbutton_Click);
            this.confirmbutton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.confirmbutton_PreviewKeyDown);
            // 
            // amountcomboBox
            // 
            this.amountcomboBox.FormattingEnabled = true;
            this.amountcomboBox.Location = new System.Drawing.Point(443, 236);
            this.amountcomboBox.Name = "amountcomboBox";
            this.amountcomboBox.Size = new System.Drawing.Size(121, 21);
            this.amountcomboBox.TabIndex = 122;
            this.amountcomboBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.amountcomboBox_PreviewKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(371, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 121;
            this.label2.Text = "Amount: RM";
            // 
            // DateTimetimer
            // 
            this.DateTimetimer.Interval = 1000;
            this.DateTimetimer.Tick += new System.EventHandler(this.DateTimetimer_Tick);
            // 
            // datetimelabel
            // 
            this.datetimelabel.AutoSize = true;
            this.datetimelabel.Location = new System.Drawing.Point(61, 49);
            this.datetimelabel.Name = "datetimelabel";
            this.datetimelabel.Size = new System.Drawing.Size(66, 13);
            this.datetimelabel.TabIndex = 125;
            this.datetimelabel.Text = "Date && TIme";
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(23, 308);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(138, 84);
            this.customerButton.TabIndex = 134;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // systemButton
            // 
            this.systemButton.Location = new System.Drawing.Point(23, 189);
            this.systemButton.Name = "systemButton";
            this.systemButton.Size = new System.Drawing.Size(138, 88);
            this.systemButton.TabIndex = 133;
            this.systemButton.Text = "System";
            this.systemButton.UseVisualStyleBackColor = true;
            this.systemButton.Click += new System.EventHandler(this.systemButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(23, 76);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(138, 88);
            this.orderButton.TabIndex = 132;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.Location = new System.Drawing.Point(733, 12);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(55, 37);
            this.exitbutton.TabIndex = 139;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click_1);
            // 
            // quickchangememberbutton
            // 
            this.quickchangememberbutton.Location = new System.Drawing.Point(733, 55);
            this.quickchangememberbutton.Name = "quickchangememberbutton";
            this.quickchangememberbutton.Size = new System.Drawing.Size(56, 42);
            this.quickchangememberbutton.TabIndex = 138;
            this.quickchangememberbutton.Text = "Change Member";
            this.quickchangememberbutton.UseVisualStyleBackColor = true;
            this.quickchangememberbutton.Click += new System.EventHandler(this.quickchangememberbutton_Click);
            // 
            // custloginbutton
            // 
            this.custloginbutton.Location = new System.Drawing.Point(733, 56);
            this.custloginbutton.Name = "custloginbutton";
            this.custloginbutton.Size = new System.Drawing.Size(55, 40);
            this.custloginbutton.TabIndex = 142;
            this.custloginbutton.Text = "CustID Login";
            this.custloginbutton.UseVisualStyleBackColor = true;
            this.custloginbutton.Click += new System.EventHandler(this.custloginbutton_Click);
            // 
            // currentbalancelabel
            // 
            this.currentbalancelabel.AutoSize = true;
            this.currentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentbalancelabel.Location = new System.Drawing.Point(539, 89);
            this.currentbalancelabel.Name = "currentbalancelabel";
            this.currentbalancelabel.Size = new System.Drawing.Size(76, 25);
            this.currentbalancelabel.TabIndex = 149;
            this.currentbalancelabel.Text = "label3";
            this.currentbalancelabel.Visible = false;
            // 
            // displaycurrentbalancelabel
            // 
            this.displaycurrentbalancelabel.AutoSize = true;
            this.displaycurrentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaycurrentbalancelabel.Location = new System.Drawing.Point(314, 89);
            this.displaycurrentbalancelabel.Name = "displaycurrentbalancelabel";
            this.displaycurrentbalancelabel.Size = new System.Drawing.Size(231, 25);
            this.displaycurrentbalancelabel.TabIndex = 148;
            this.displaycurrentbalancelabel.Text = "Current Balance: RM";
            this.displaycurrentbalancelabel.Visible = false;
            // 
            // custidlabel
            // 
            this.custidlabel.AutoSize = true;
            this.custidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custidlabel.Location = new System.Drawing.Point(482, 61);
            this.custidlabel.Name = "custidlabel";
            this.custidlabel.Size = new System.Drawing.Size(70, 25);
            this.custidlabel.TabIndex = 147;
            this.custidlabel.Text = "label2";
            this.custidlabel.Visible = false;
            // 
            // custiddisplaylabel
            // 
            this.custiddisplaylabel.AutoSize = true;
            this.custiddisplaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custiddisplaylabel.Location = new System.Drawing.Point(394, 61);
            this.custiddisplaylabel.Name = "custiddisplaylabel";
            this.custiddisplaylabel.Size = new System.Drawing.Size(82, 25);
            this.custiddisplaylabel.TabIndex = 146;
            this.custiddisplaylabel.Text = "CustID:";
            this.custiddisplaylabel.Visible = false;
            // 
            // CustomerCreditTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentbalancelabel);
            this.Controls.Add(this.displaycurrentbalancelabel);
            this.Controls.Add(this.custidlabel);
            this.Controls.Add(this.custiddisplaylabel);
            this.Controls.Add(this.custloginbutton);
            this.Controls.Add(this.exitbutton);
            this.Controls.Add(this.quickchangememberbutton);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.systemButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.datetimelabel);
            this.Controls.Add(this.amountcomboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.confirmbutton);
            this.Controls.Add(this.receiverIDmaskedTextBox);
            this.Controls.Add(this.receiverIDlabel);
            this.Controls.Add(this.label1);
            this.Name = "CustomerCreditTransfer";
            this.Text = "CustomerTransfer";
            this.Load += new System.EventHandler(this.CustomerTransfer_Load);
            this.Shown += new System.EventHandler(this.CustomerTransfer_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MaskedTextBox receiverIDmaskedTextBox;
        private System.Windows.Forms.Label receiverIDlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button confirmbutton;
        private System.Windows.Forms.ComboBox amountcomboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer DateTimetimer;
        private System.Windows.Forms.Label datetimelabel;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button systemButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button quickchangememberbutton;
        private System.Windows.Forms.Button custloginbutton;
        private System.Windows.Forms.Label currentbalancelabel;
        private System.Windows.Forms.Label displaycurrentbalancelabel;
        private System.Windows.Forms.Label custidlabel;
        private System.Windows.Forms.Label custiddisplaylabel;
    }
}