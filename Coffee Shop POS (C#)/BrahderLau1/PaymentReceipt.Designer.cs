namespace User_registration_by_Nesa
{
    partial class PaymentReceipt
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
            this.printbutton = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.paymentdataGridView = new System.Windows.Forms.DataGridView();
            this.subtotaltextBox = new System.Windows.Forms.TextBox();
            this.subtotallabel = new System.Windows.Forms.Label();
            this.servicetaxlabel = new System.Windows.Forms.Label();
            this.GSTlabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GSTtextBox = new System.Windows.Forms.TextBox();
            this.discounttextBox = new System.Windows.Forms.TextBox();
            this.servicetextBox = new System.Windows.Forms.TextBox();
            this.roundinglabel = new System.Windows.Forms.Label();
            this.grandtotallabel = new System.Windows.Forms.Label();
            this.grandtotaltextBox = new System.Windows.Forms.TextBox();
            this.roundingtextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newbalancetextBox = new System.Windows.Forms.TextBox();
            this.paymenttextBox = new System.Windows.Forms.TextBox();
            this.initialbalancetextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.billnotextBox = new System.Windows.Forms.TextBox();
            this.orderdatetextBox = new System.Windows.Forms.TextBox();
            this.billnolabel = new System.Windows.Forms.Label();
            this.ordertimetextBox = new System.Windows.Forms.TextBox();
            this.ordertimelabel = new System.Windows.Forms.Label();
            this.orderdatelabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.custidtextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paymentdataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // printbutton
            // 
            this.printbutton.Location = new System.Drawing.Point(365, 786);
            this.printbutton.Name = "printbutton";
            this.printbutton.Size = new System.Drawing.Size(89, 41);
            this.printbutton.TabIndex = 113;
            this.printbutton.Text = "Print Receipt";
            this.printbutton.UseVisualStyleBackColor = true;
            this.printbutton.Click += new System.EventHandler(this.printbutton_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(28, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(731, 768);
            this.listView1.TabIndex = 114;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // paymentdataGridView
            // 
            this.paymentdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.paymentdataGridView.Location = new System.Drawing.Point(76, 162);
            this.paymentdataGridView.Name = "paymentdataGridView";
            this.paymentdataGridView.ReadOnly = true;
            this.paymentdataGridView.Size = new System.Drawing.Size(647, 258);
            this.paymentdataGridView.TabIndex = 115;
            // 
            // subtotaltextBox
            // 
            this.subtotaltextBox.Location = new System.Drawing.Point(189, 28);
            this.subtotaltextBox.Name = "subtotaltextBox";
            this.subtotaltextBox.ReadOnly = true;
            this.subtotaltextBox.Size = new System.Drawing.Size(121, 22);
            this.subtotaltextBox.TabIndex = 183;
            // 
            // subtotallabel
            // 
            this.subtotallabel.AutoSize = true;
            this.subtotallabel.Location = new System.Drawing.Point(129, 31);
            this.subtotallabel.Name = "subtotallabel";
            this.subtotallabel.Size = new System.Drawing.Size(57, 16);
            this.subtotallabel.TabIndex = 182;
            this.subtotallabel.Text = "Subtotal";
            // 
            // servicetaxlabel
            // 
            this.servicetaxlabel.AutoSize = true;
            this.servicetaxlabel.Location = new System.Drawing.Point(78, 83);
            this.servicetaxlabel.Name = "servicetaxlabel";
            this.servicetaxlabel.Size = new System.Drawing.Size(108, 16);
            this.servicetaxlabel.TabIndex = 184;
            this.servicetaxlabel.Text = "Service tax(10%)";
            // 
            // GSTlabel
            // 
            this.GSTlabel.AutoSize = true;
            this.GSTlabel.Location = new System.Drawing.Point(121, 110);
            this.GSTlabel.Name = "GSTlabel";
            this.GSTlabel.Size = new System.Drawing.Size(63, 16);
            this.GSTlabel.TabIndex = 185;
            this.GSTlabel.Text = "GST(6%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(91, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 199;
            this.label3.Text = "Discount(10%)";
            // 
            // GSTtextBox
            // 
            this.GSTtextBox.Location = new System.Drawing.Point(190, 107);
            this.GSTtextBox.Name = "GSTtextBox";
            this.GSTtextBox.ReadOnly = true;
            this.GSTtextBox.Size = new System.Drawing.Size(121, 22);
            this.GSTtextBox.TabIndex = 186;
            // 
            // discounttextBox
            // 
            this.discounttextBox.Location = new System.Drawing.Point(189, 54);
            this.discounttextBox.Name = "discounttextBox";
            this.discounttextBox.ReadOnly = true;
            this.discounttextBox.Size = new System.Drawing.Size(121, 22);
            this.discounttextBox.TabIndex = 198;
            // 
            // servicetextBox
            // 
            this.servicetextBox.Location = new System.Drawing.Point(189, 80);
            this.servicetextBox.Name = "servicetextBox";
            this.servicetextBox.ReadOnly = true;
            this.servicetextBox.Size = new System.Drawing.Size(121, 22);
            this.servicetextBox.TabIndex = 187;
            // 
            // roundinglabel
            // 
            this.roundinglabel.AutoSize = true;
            this.roundinglabel.Location = new System.Drawing.Point(118, 137);
            this.roundinglabel.Name = "roundinglabel";
            this.roundinglabel.Size = new System.Drawing.Size(66, 16);
            this.roundinglabel.TabIndex = 188;
            this.roundinglabel.Text = "Rounding";
            // 
            // grandtotallabel
            // 
            this.grandtotallabel.AutoSize = true;
            this.grandtotallabel.Location = new System.Drawing.Point(107, 164);
            this.grandtotallabel.Name = "grandtotallabel";
            this.grandtotallabel.Size = new System.Drawing.Size(79, 16);
            this.grandtotallabel.TabIndex = 189;
            this.grandtotallabel.Text = "Grand Total";
            // 
            // grandtotaltextBox
            // 
            this.grandtotaltextBox.Location = new System.Drawing.Point(192, 161);
            this.grandtotaltextBox.Name = "grandtotaltextBox";
            this.grandtotaltextBox.ReadOnly = true;
            this.grandtotaltextBox.Size = new System.Drawing.Size(118, 22);
            this.grandtotaltextBox.TabIndex = 190;
            // 
            // roundingtextBox
            // 
            this.roundingtextBox.Location = new System.Drawing.Point(192, 134);
            this.roundingtextBox.Name = "roundingtextBox";
            this.roundingtextBox.ReadOnly = true;
            this.roundingtextBox.Size = new System.Drawing.Size(118, 22);
            this.roundingtextBox.TabIndex = 191;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newbalancetextBox);
            this.groupBox1.Controls.Add(this.paymenttextBox);
            this.groupBox1.Controls.Add(this.initialbalancetextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.subtotaltextBox);
            this.groupBox1.Controls.Add(this.subtotallabel);
            this.groupBox1.Controls.Add(this.servicetaxlabel);
            this.groupBox1.Controls.Add(this.GSTlabel);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.GSTtextBox);
            this.groupBox1.Controls.Add(this.discounttextBox);
            this.groupBox1.Controls.Add(this.servicetextBox);
            this.groupBox1.Controls.Add(this.roundinglabel);
            this.groupBox1.Controls.Add(this.grandtotallabel);
            this.groupBox1.Controls.Add(this.grandtotaltextBox);
            this.groupBox1.Controls.Add(this.roundingtextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(216, 426);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 309);
            this.groupBox1.TabIndex = 204;
            this.groupBox1.TabStop = false;
            // 
            // newbalancetextBox
            // 
            this.newbalancetextBox.Location = new System.Drawing.Point(192, 276);
            this.newbalancetextBox.Name = "newbalancetextBox";
            this.newbalancetextBox.ReadOnly = true;
            this.newbalancetextBox.Size = new System.Drawing.Size(119, 22);
            this.newbalancetextBox.TabIndex = 206;
            // 
            // paymenttextBox
            // 
            this.paymenttextBox.Location = new System.Drawing.Point(192, 247);
            this.paymenttextBox.Name = "paymenttextBox";
            this.paymenttextBox.ReadOnly = true;
            this.paymenttextBox.Size = new System.Drawing.Size(118, 22);
            this.paymenttextBox.TabIndex = 205;
            // 
            // initialbalancetextBox
            // 
            this.initialbalancetextBox.Location = new System.Drawing.Point(192, 215);
            this.initialbalancetextBox.Name = "initialbalancetextBox";
            this.initialbalancetextBox.ReadOnly = true;
            this.initialbalancetextBox.Size = new System.Drawing.Size(118, 22);
            this.initialbalancetextBox.TabIndex = 204;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 16);
            this.label5.TabIndex = 203;
            this.label5.Text = "________________________________________________";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 280);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 16);
            this.label4.TabIndex = 202;
            this.label4.Text = "New account balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 201;
            this.label2.Text = "Cashless Payment";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 200;
            this.label1.Text = "Accounting Balance";
            // 
            // billnotextBox
            // 
            this.billnotextBox.Location = new System.Drawing.Point(133, 85);
            this.billnotextBox.Name = "billnotextBox";
            this.billnotextBox.ReadOnly = true;
            this.billnotextBox.Size = new System.Drawing.Size(100, 20);
            this.billnotextBox.TabIndex = 210;
            // 
            // orderdatetextBox
            // 
            this.orderdatetextBox.Location = new System.Drawing.Point(385, 120);
            this.orderdatetextBox.Name = "orderdatetextBox";
            this.orderdatetextBox.ReadOnly = true;
            this.orderdatetextBox.Size = new System.Drawing.Size(100, 20);
            this.orderdatetextBox.TabIndex = 209;
            // 
            // billnolabel
            // 
            this.billnolabel.AutoSize = true;
            this.billnolabel.Location = new System.Drawing.Point(84, 88);
            this.billnolabel.Name = "billnolabel";
            this.billnolabel.Size = new System.Drawing.Size(43, 13);
            this.billnolabel.TabIndex = 208;
            this.billnolabel.Text = "Bill. No:";
            // 
            // ordertimetextBox
            // 
            this.ordertimetextBox.Location = new System.Drawing.Point(611, 120);
            this.ordertimetextBox.Name = "ordertimetextBox";
            this.ordertimetextBox.ReadOnly = true;
            this.ordertimetextBox.Size = new System.Drawing.Size(100, 20);
            this.ordertimetextBox.TabIndex = 207;
            // 
            // ordertimelabel
            // 
            this.ordertimelabel.AutoSize = true;
            this.ordertimelabel.Location = new System.Drawing.Point(546, 123);
            this.ordertimelabel.Name = "ordertimelabel";
            this.ordertimelabel.Size = new System.Drawing.Size(59, 13);
            this.ordertimelabel.TabIndex = 206;
            this.ordertimelabel.Text = "Order Time";
            // 
            // orderdatelabel
            // 
            this.orderdatelabel.AutoSize = true;
            this.orderdatelabel.Location = new System.Drawing.Point(320, 123);
            this.orderdatelabel.Name = "orderdatelabel";
            this.orderdatelabel.Size = new System.Drawing.Size(59, 13);
            this.orderdatelabel.TabIndex = 205;
            this.orderdatelabel.Text = "Order Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(319, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 24);
            this.label6.TabIndex = 211;
            this.label6.Text = "Payment Receipt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(254, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(265, 43);
            this.label7.TabIndex = 212;
            this.label7.Text = "Big Coffee Company";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(156, 747);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(504, 21);
            this.label8.TabIndex = 213;
            this.label8.Text = "Please come again! Have a nice day! :)";
            // 
            // custidtextBox
            // 
            this.custidtextBox.Location = new System.Drawing.Point(133, 120);
            this.custidtextBox.Name = "custidtextBox";
            this.custidtextBox.ReadOnly = true;
            this.custidtextBox.Size = new System.Drawing.Size(100, 20);
            this.custidtextBox.TabIndex = 214;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 215;
            this.label9.Text = "CustID:";
            // 
            // PaymentReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 851);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.custidtextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.billnotextBox);
            this.Controls.Add(this.orderdatetextBox);
            this.Controls.Add(this.billnolabel);
            this.Controls.Add(this.ordertimetextBox);
            this.Controls.Add(this.ordertimelabel);
            this.Controls.Add(this.orderdatelabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.paymentdataGridView);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.printbutton);
            this.Name = "PaymentReceipt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaymentReceipt";
            this.Load += new System.EventHandler(this.PaymentReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.paymentdataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button printbutton;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.DataGridView paymentdataGridView;
        private System.Windows.Forms.TextBox subtotaltextBox;
        private System.Windows.Forms.Label subtotallabel;
        private System.Windows.Forms.Label servicetaxlabel;
        private System.Windows.Forms.Label GSTlabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GSTtextBox;
        private System.Windows.Forms.TextBox discounttextBox;
        private System.Windows.Forms.TextBox servicetextBox;
        private System.Windows.Forms.Label roundinglabel;
        private System.Windows.Forms.Label grandtotallabel;
        private System.Windows.Forms.TextBox grandtotaltextBox;
        private System.Windows.Forms.TextBox roundingtextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox newbalancetextBox;
        private System.Windows.Forms.TextBox paymenttextBox;
        private System.Windows.Forms.TextBox initialbalancetextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox billnotextBox;
        private System.Windows.Forms.TextBox orderdatetextBox;
        private System.Windows.Forms.Label billnolabel;
        private System.Windows.Forms.TextBox ordertimetextBox;
        private System.Windows.Forms.Label ordertimelabel;
        private System.Windows.Forms.Label orderdatelabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox custidtextBox;
        private System.Windows.Forms.Label label9;
    }
}