using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace User_registration_by_Nesa
{
    public partial class CustomerCreditTransfer : Form
    {
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        OleDbCommand cmdUpdate = new OleDbCommand();
        CustDetailsClass transferDC = new CustDetailsClass();
        public CustomerCreditTransfer(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            transferDC.CustID = _CustID;
            transferDC.AdminID = _AdminID;
            transferDC.Balance = _Balance;
        }

        private void CustomerTransfer_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            receiverIDmaskedTextBox.Focus();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                            "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            int[] amount = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 150, 200 };
            foreach (int i in amount)
            {
                amountcomboBox.Items.Add(i.ToString());
            }
            if (transferDC.CustID != "")
            {
                //To display CustID Login button.
                custidlabel.Visible = true;
                quickchangememberbutton.Visible = false;
                //To display CustID.
                custidlabel.Text = transferDC.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + transferDC.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    transferDC.Balance = currentbalancelabel.Text;
                }
                dr.Close();
                custiddisplaylabel.Visible = true;
                custidlabel.Visible = true;
                displaycurrentbalancelabel.Visible = true;
                currentbalancelabel.Visible = true;
                quickchangememberbutton.Visible = true;
                custloginbutton.Visible = false;
            }
            else
            {
                custiddisplaylabel.Visible = false;
                custidlabel.Visible = false;
                displaycurrentbalancelabel.Visible = false;
                currentbalancelabel.Visible = false;
                custidlabel.Visible = false;
                quickchangememberbutton.Visible = false;
                custloginbutton.Visible = true;
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            if (transferDC.CustID != "")
            {
                if (receiverIDmaskedTextBox.MaskCompleted || amountcomboBox.Text != "")
                {
                    //Step 1: Get the initial balance of Sender ID
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + custidlabel.Text + "\';";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader drSender = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (drSender.Read() == true)
                    {
                        int senderBalance = Convert.ToInt32(drSender[13]);
                        drSender.Close();
                        if (int.Parse(amountcomboBox.Text) > senderBalance)
                        {
                            MessageBox.Show("Insufficient balance. Please try again.");
                            amountcomboBox.SelectedIndex = -1;
                            amountcomboBox.Focus();
                        }
                        else if (int.Parse(amountcomboBox.Text) < senderBalance)
                        {
                            //Step 2: Get the initial balance of Receiver ID
                            cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + receiverIDmaskedTextBox.Text + "\';";
                            cmdSearch.Connection = cnnOLEDB;
                            OleDbDataReader drReceiver = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                            if (drReceiver.Read() == true)
                            {
                                string receiverName = drReceiver[1].ToString();
                                drReceiver.Close();
                                DialogResult Result = MessageBox.Show("Do you wish to transfer the credit amount of RM" + amountcomboBox.Text + " to " + receiverName + " CustID = " + receiverIDmaskedTextBox.Text, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                switch (Result)
                                {
                                    case DialogResult.Yes:
                                        {
                                            //Step 3: Update the current balance of the Sender ID
                                            cmdUpdate.CommandText = "Update CustomerData Set Balance = Balance - \'" + amountcomboBox.Text + "\' Where CustID = \'" + custidlabel.Text + "\';";
                                            cmdUpdate.CommandType = CommandType.Text;
                                            cmdUpdate.Connection = cnnOLEDB;
                                            cmdUpdate.ExecuteNonQuery();

                                            //Step 4: Update the current balance of the Receiver ID
                                            cmdUpdate.CommandText = "Update CustomerData Set Balance = Balance + \'" + amountcomboBox.Text + "\' Where CustID = \'" + receiverIDmaskedTextBox.Text + "\';";
                                            cmdUpdate.CommandType = CommandType.Text;
                                            cmdUpdate.Connection = cnnOLEDB;
                                            cmdUpdate.ExecuteNonQuery();

                                            //Step 5: Show the current balance of SenderID
                                            cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + transferDC.CustID + "\';";
                                            cmdSearch.Connection = cnnOLEDB;
                                            OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                                            if (dr.Read() == true)
                                            {
                                                transferDC.Balance = dr[13].ToString();
                                                MessageBox.Show("  Credit Transfer Successful\nYour new balance is RM" + transferDC.Balance);
                                                CustomerHome done = new CustomerHome(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
                                                done.Show();
                                                this.Close();
                                            }
                                            break;
                                        }
                                    case DialogResult.No:
                                        {
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                MessageBox.Show("CustID is not registered.");
                                receiverIDmaskedTextBox.Clear();
                                receiverIDmaskedTextBox.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please key in a valid CustomerID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("ReceiverID not found.");
                        receiverIDmaskedTextBox.Clear();
                        receiverIDmaskedTextBox.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Please key in ReceiverID and credit amount.");
                }
            }
            else
            {
                MessageBox.Show("Please login the CustID.");
            }
        }      

        private void backbutton_Click(object sender, EventArgs e)
        {
            CustomerHome back = new CustomerHome(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
            back.Show();
            this.Hide();
        }

        private void exitbutton_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you wish to quit Big Coffee System?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (Result)
            {
                case DialogResult.Yes:
                    {

                        this.Close();
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
            }
        }

        private void receiverIDmaskedTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                amountcomboBox.Focus();
            }
        }

        private void amountcomboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                confirmbutton.Focus();
            }
        }

        private void confirmbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                backbutton.Focus();
            }
        }

        private void backbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                exitbutton.Focus();
            }
        }

        private void exitbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                receiverIDmaskedTextBox.Focus();
            }
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void CustomerTransfer_Shown(object sender, EventArgs e)
        {
            receiverIDmaskedTextBox.Focus();
        }

        private void exitbutton_Click_1(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("Do you wish to quit Big Coffee System?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            switch (Result)
            {
                case DialogResult.Yes:
                    {

                        this.Close();
                        break;
                    }
                case DialogResult.No:
                    {
                        break;
                    }
            }
        }

        private void quickchangememberbutton_Click(object sender, EventArgs e)
        {
            CustomerQuickChange f = new CustomerQuickChange();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    transferDC.CustID = dr[0].ToString();
                    transferDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + transferDC.FName + "!");
                    CustomerCreditTransfer refresh = new CustomerCreditTransfer(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
                    refresh.Show();
                    f.Dispose();
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("CustID does not exist.");
                    f.quickcustidmaskedTextBox.Clear();
                    f.quickcustidmaskedTextBox.Focus();
                    dr.Close();
                }
            }
            else
            {
                f.Dispose();
            }
        }

        private void custloginbutton_Click(object sender, EventArgs e)
        {
            CustomerQuickChange f = new CustomerQuickChange();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    transferDC.CustID = dr[0].ToString();
                    transferDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + transferDC.FName + "!");
                    CustomerSearch refresh = new CustomerSearch(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
                    refresh.Show();
                    f.Dispose();
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("CustID does not exist.");
                    f.quickcustidmaskedTextBox.Clear();
                    f.quickcustidmaskedTextBox.Focus();
                    dr.Close();
                }
            }
            else
            {
                f.Dispose();
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (transferDC.CustID == "")
            {
                CustomerQuickChange f = new CustomerQuickChange();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        transferDC.CustID = dr[0].ToString();
                        transferDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + transferDC.FName + "!");
                        dr.Close();
                        f.Dispose();
                        CustomerOrder nextform = new CustomerOrder(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
                        nextform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("CustID does not exist.");
                        f.quickcustidmaskedTextBox.Clear();
                        f.quickcustidmaskedTextBox.Focus();
                        dr.Close();
                    }
                }
                else
                {
                    f.Dispose();
                }
            }
            else
            {
                CustomerOrder nextform = new CustomerOrder(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
                nextform.Show();
                this.Hide();
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(transferDC.AdminID, transferDC.CustID, transferDC.Balance);
            nextform.Show();
            this.Hide();
        }
    }
}
