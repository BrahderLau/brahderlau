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
    public partial class CustomerTopUp : Form
    {
        CustDetailsClass topup = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdUpdate = new OleDbCommand(); //Insert command
        OleDbCommand cmdSearch = new OleDbCommand();
        public CustomerTopUp(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            topup.AdminID = _AdminID;
            topup.CustID = _CustID;
            topup.Balance = _Balance;
        }

        private void CustomerTopUp_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            amountcomboBox.Focus();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                            "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            int[] amount = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 150, 200 };
            foreach (int i in amount)
            {
                amountcomboBox.Items.Add(i.ToString());
            }
            try
            {
                //To display CustID.
                custidlabel.Text = topup.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + topup.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader();
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    topup.Balance = currentbalancelabel.Text;
                }
                dr.Close();
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void confirmbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (amountcomboBox.SelectedIndex != -1)
                {
                    cmdUpdate.CommandText = "Update CustomerData Set Balance = Balance + " + amountcomboBox.Text + " Where CustID = \'" + custidlabel.Text + "\';";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery(); // go to database change one row and do not return any value
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + topup.CustID + "\';";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        topup.Balance = dr[13].ToString();
                        MessageBox.Show("      Top up successful! \nYour new balance is: RM" + topup.Balance);
                        CustomerHome done = new CustomerHome (topup.AdminID, topup.CustID, topup.Balance);
                        done.Show();
                        this.Hide();
                    }
                    dr.Close();
                }
                else
                {
                    MessageBox.Show("Please select the amount of credit to top up.");
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            CustomerHome back = new CustomerHome(topup.AdminID, topup.CustID, topup.Balance);
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

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
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
            try
            {
                CustomerQuickChange f = new CustomerQuickChange();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        topup.CustID = dr[0].ToString();
                        topup.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + topup.FName + "!");
                        CustomerTopUp refresh = new CustomerTopUp(topup.AdminID, topup.CustID, topup.Balance);
                        refresh.Show();
                    }
                    else
                    {
                        MessageBox.Show("CustID does not exist.");
                        f.quickcustidmaskedTextBox.Clear();
                        f.quickcustidmaskedTextBox.Focus();
                    }
                    dr.Close();
                }
                f.Dispose();
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (topup.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            topup.CustID = dr[0].ToString();
                            topup.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + topup.FName + "!");
                            CustomerOrder nextform = new CustomerOrder(topup.AdminID, topup.CustID, topup.Balance);
                            nextform.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("CustID does not exist.");
                            f.quickcustidmaskedTextBox.Clear();
                            f.quickcustidmaskedTextBox.Focus();
                        }
                        dr.Close();
                    }
                    f.Dispose();
                }
                else
                {
                    CustomerOrder nextform = new CustomerOrder(topup.AdminID, topup.CustID, topup.Balance);
                    nextform.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(topup.AdminID, topup.CustID, topup.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(topup.AdminID, topup.CustID, topup.Balance);
            nextform.Show();
            this.Hide();
        }
    }
}
