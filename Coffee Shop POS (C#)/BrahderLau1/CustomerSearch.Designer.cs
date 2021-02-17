namespace User_registration_by_Nesa
{
    partial class CustomerSearch
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
            this.customersearchdataGridView = new System.Windows.Forms.DataGridView();
            this.searchbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchcomboBox = new System.Windows.Forms.ComboBox();
            this.keywordlabel = new System.Windows.Forms.Label();
            this.keywordtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.customerButton = new System.Windows.Forms.Button();
            this.systemButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.backbutton = new System.Windows.Forms.Button();
            this.exitbutton = new System.Windows.Forms.Button();
            this.quickchangememberbutton = new System.Windows.Forms.Button();
            this.custloginbutton = new System.Windows.Forms.Button();
            this.currentbalancelabel = new System.Windows.Forms.Label();
            this.displaycurrentbalancelabel = new System.Windows.Forms.Label();
            this.custidlabel = new System.Windows.Forms.Label();
            this.custiddisplaylabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.customersearchdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // customersearchdataGridView
            // 
            this.customersearchdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.customersearchdataGridView.Location = new System.Drawing.Point(178, 212);
            this.customersearchdataGridView.Name = "customersearchdataGridView";
            this.customersearchdataGridView.Size = new System.Drawing.Size(610, 209);
            this.customersearchdataGridView.TabIndex = 0;
            // 
            // searchbutton
            // 
            this.searchbutton.Location = new System.Drawing.Point(448, 170);
            this.searchbutton.Name = "searchbutton";
            this.searchbutton.Size = new System.Drawing.Size(75, 23);
            this.searchbutton.TabIndex = 1;
            this.searchbutton.Text = "Search";
            this.searchbutton.UseVisualStyleBackColor = true;
            this.searchbutton.Click += new System.EventHandler(this.searchbutton_Click);
            this.searchbutton.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.searchbutton_PreviewKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(362, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search by:";
            // 
            // searchcomboBox
            // 
            this.searchcomboBox.FormattingEnabled = true;
            this.searchcomboBox.Location = new System.Drawing.Point(426, 105);
            this.searchcomboBox.Name = "searchcomboBox";
            this.searchcomboBox.Size = new System.Drawing.Size(121, 21);
            this.searchcomboBox.TabIndex = 3;
            this.searchcomboBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.searchcomboBox_PreviewKeyDown);
            // 
            // keywordlabel
            // 
            this.keywordlabel.AutoSize = true;
            this.keywordlabel.Location = new System.Drawing.Point(263, 147);
            this.keywordlabel.Name = "keywordlabel";
            this.keywordlabel.Size = new System.Drawing.Size(51, 13);
            this.keywordlabel.TabIndex = 4;
            this.keywordlabel.Text = "Keyword:";
            // 
            // keywordtextBox
            // 
            this.keywordtextBox.Location = new System.Drawing.Point(320, 144);
            this.keywordtextBox.Name = "keywordtextBox";
            this.keywordtextBox.Size = new System.Drawing.Size(355, 20);
            this.keywordtextBox.TabIndex = 5;
            this.keywordtextBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.keywordtextBox_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 137;
            this.label3.Text = "Date && TIme";
            // 
            // customerButton
            // 
            this.customerButton.Location = new System.Drawing.Point(23, 308);
            this.customerButton.Name = "customerButton";
            this.customerButton.Size = new System.Drawing.Size(138, 84);
            this.customerButton.TabIndex = 136;
            this.customerButton.Text = "Customer";
            this.customerButton.UseVisualStyleBackColor = true;
            this.customerButton.Click += new System.EventHandler(this.customerButton_Click);
            // 
            // systemButton
            // 
            this.systemButton.Location = new System.Drawing.Point(23, 189);
            this.systemButton.Name = "systemButton";
            this.systemButton.Size = new System.Drawing.Size(138, 88);
            this.systemButton.TabIndex = 135;
            this.systemButton.Text = "System";
            this.systemButton.UseVisualStyleBackColor = true;
            this.systemButton.Click += new System.EventHandler(this.systemButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Location = new System.Drawing.Point(23, 76);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(138, 88);
            this.orderButton.TabIndex = 134;
            this.orderButton.Text = "Order";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(52, 415);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(75, 23);
            this.backbutton.TabIndex = 140;
            this.backbutton.Text = "Back";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // exitbutton
            // 
            this.exitbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitbutton.Location = new System.Drawing.Point(733, 13);
            this.exitbutton.Name = "exitbutton";
            this.exitbutton.Size = new System.Drawing.Size(55, 37);
            this.exitbutton.TabIndex = 142;
            this.exitbutton.Text = "X";
            this.exitbutton.UseVisualStyleBackColor = true;
            this.exitbutton.Click += new System.EventHandler(this.exitbutton_Click);
            // 
            // quickchangememberbutton
            // 
            this.quickchangememberbutton.Location = new System.Drawing.Point(733, 56);
            this.quickchangememberbutton.Name = "quickchangememberbutton";
            this.quickchangememberbutton.Size = new System.Drawing.Size(56, 42);
            this.quickchangememberbutton.TabIndex = 141;
            this.quickchangememberbutton.Text = "Change Member";
            this.quickchangememberbutton.UseVisualStyleBackColor = true;
            this.quickchangememberbutton.Click += new System.EventHandler(this.quickchangememberbutton_Click);
            // 
            // custloginbutton
            // 
            this.custloginbutton.Location = new System.Drawing.Point(733, 57);
            this.custloginbutton.Name = "custloginbutton";
            this.custloginbutton.Size = new System.Drawing.Size(55, 40);
            this.custloginbutton.TabIndex = 143;
            this.custloginbutton.Text = "CustID Login";
            this.custloginbutton.UseVisualStyleBackColor = true;
            this.custloginbutton.Click += new System.EventHandler(this.custloginbutton_Click);
            // 
            // currentbalancelabel
            // 
            this.currentbalancelabel.AutoSize = true;
            this.currentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentbalancelabel.Location = new System.Drawing.Point(541, 61);
            this.currentbalancelabel.Name = "currentbalancelabel";
            this.currentbalancelabel.Size = new System.Drawing.Size(76, 25);
            this.currentbalancelabel.TabIndex = 147;
            this.currentbalancelabel.Text = "label3";
            this.currentbalancelabel.Visible = false;
            // 
            // displaycurrentbalancelabel
            // 
            this.displaycurrentbalancelabel.AutoSize = true;
            this.displaycurrentbalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.displaycurrentbalancelabel.Location = new System.Drawing.Point(316, 61);
            this.displaycurrentbalancelabel.Name = "displaycurrentbalancelabel";
            this.displaycurrentbalancelabel.Size = new System.Drawing.Size(231, 25);
            this.displaycurrentbalancelabel.TabIndex = 146;
            this.displaycurrentbalancelabel.Text = "Current Balance: RM";
            this.displaycurrentbalancelabel.Visible = false;
            // 
            // custidlabel
            // 
            this.custidlabel.AutoSize = true;
            this.custidlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custidlabel.Location = new System.Drawing.Point(484, 33);
            this.custidlabel.Name = "custidlabel";
            this.custidlabel.Size = new System.Drawing.Size(70, 25);
            this.custidlabel.TabIndex = 145;
            this.custidlabel.Text = "label2";
            this.custidlabel.Visible = false;
            // 
            // custiddisplaylabel
            // 
            this.custiddisplaylabel.AutoSize = true;
            this.custiddisplaylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.custiddisplaylabel.Location = new System.Drawing.Point(396, 33);
            this.custiddisplaylabel.Name = "custiddisplaylabel";
            this.custiddisplaylabel.Size = new System.Drawing.Size(82, 25);
            this.custiddisplaylabel.TabIndex = 144;
            this.custiddisplaylabel.Text = "CustID:";
            this.custiddisplaylabel.Visible = false;
            // 
            // CustomerSearch
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
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.customerButton);
            this.Controls.Add(this.systemButton);
            this.Controls.Add(this.orderButton);
            this.Controls.Add(this.keywordtextBox);
            this.Controls.Add(this.keywordlabel);
            this.Controls.Add(this.searchcomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchbutton);
            this.Controls.Add(this.customersearchdataGridView);
            this.Name = "CustomerSearch";
            this.Text = "CustomerSearch";
            this.Load += new System.EventHandler(this.CustomerSearch_Load);
            this.Shown += new System.EventHandler(this.CustomerSearch_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.customersearchdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView customersearchdataGridView;
        private System.Windows.Forms.Button searchbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox searchcomboBox;
        private System.Windows.Forms.Label keywordlabel;
        private System.Windows.Forms.TextBox keywordtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button customerButton;
        private System.Windows.Forms.Button systemButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button exitbutton;
        private System.Windows.Forms.Button quickchangememberbutton;
        private System.Windows.Forms.Button custloginbutton;
        private System.Windows.Forms.Label currentbalancelabel;
        private System.Windows.Forms.Label displaycurrentbalancelabel;
        private System.Windows.Forms.Label custidlabel;
        private System.Windows.Forms.Label custiddisplaylabel;
    }
}