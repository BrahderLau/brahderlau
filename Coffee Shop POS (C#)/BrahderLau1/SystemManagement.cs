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
    public partial class SystemManagement : Form
    {
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        CustDetailsClass SystemDC = new CustDetailsClass();
        public SystemManagement(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            SystemDC.AdminID = _AdminID;
            SystemDC.CustID = _CustID;
            SystemDC.Balance = _Balance;
        }

        private void SystemManagement_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            if (SystemDC.CustID != "")
            {
                //To display CustID Login button.
                custidlabel.Visible = true;
                quickchangememberbutton.Visible = false;
                //To display CustID.
                custidlabel.Text = SystemDC.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + SystemDC.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    SystemDC.Balance = currentbalancelabel.Text;
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
            if (SystemDC.AdminID == "")
            {
                ManageStaffbutton.Visible = true;
                DailyTransactionsbutton.Visible = true;
            }
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (SystemDC.CustID == "")
            {
                CustomerQuickChange f = new CustomerQuickChange();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        SystemDC.CustID = dr[0].ToString();
                        SystemDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + SystemDC.FName + "!");
                        dr.Close();
                        f.Dispose();
                        CustomerOrder nextform = new CustomerOrder(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
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
            }
            else
            {
                CustomerOrder nextform = new CustomerOrder(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
                nextform.Show();
                this.Hide();
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {

        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
            nextform.Show();
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
                    SystemDC.CustID = dr[0].ToString();
                    SystemDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + SystemDC.FName + "!");
                    SystemManagement refresh = new SystemManagement(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
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
                    SystemDC.CustID = dr[0].ToString();
                    SystemDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + SystemDC.FName + "!");
                    SystemManagement refresh = new SystemManagement(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
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

        private void backbutton_Click(object sender, EventArgs e)
        {
            MainMenu back = new MainMenu(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
            back.Show();
            this.Hide();
        }

        private void DailyTransactionsbutton_Click(object sender, EventArgs e)
        {
            if (SystemDC.AdminID != "1")
            {
                MessageBox.Show("Restricted Access");
            }
            else
            {
                ReportView nextform = new ReportView(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
                nextform.Show();
                this.Hide();
            }
        }

        private void ManageStaffbutton_Click(object sender, EventArgs e)
        {
            if (SystemDC.AdminID != "1")
            {
                MessageBox.Show("Restricted Access");
            }
            else
            {
                MessageBox.Show("Future implementation");
            }
        }

        private void updatefoodbutton_Click(object sender, EventArgs e)
        {
            UpdateItem nextform = new UpdateItem(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void searchfoodbutton_Click(object sender, EventArgs e)
        {
            SearchItem nextform = new SearchItem(SystemDC.AdminID, SystemDC.CustID, SystemDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void addfoodbevbutton_Click(object sender, EventArgs e)
        {
            AddItem nextform = new AddItem(SystemDC.AdminID,SystemDC.CustID,SystemDC.Balance);
            nextform.Show();
            this.Hide();
        }
    }
}
