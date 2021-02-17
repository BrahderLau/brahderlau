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
    public partial class CustomerHome : Form
    {
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        CustDetailsClass CHome = new CustDetailsClass();
        public CustomerHome(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            CHome.AdminID = _AdminID;
            CHome.CustID = _CustID;
            CHome.Balance = _Balance;
        }

        private void CustomerHome_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            if (CHome.CustID != "")
            {
                //To display CustID Login button.
                custidlabel.Visible = true;
                ChangeCustButton.Visible = false;
                //To display CustID.
                custidlabel.Text = CHome.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + CHome.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    CHome.Balance = currentbalancelabel.Text;
                }
                dr.Close();
                custiddisplaylabel.Visible = true;
                custidlabel.Visible = true;
                displaycurrentbalancelabel.Visible = true;
                currentbalancelabel.Visible = true;
                ChangeCustButton.Visible = true;
                custloginbutton.Visible = false;
            }
            else
            {
                custiddisplaylabel.Visible = false;
                custidlabel.Visible = false;
                displaycurrentbalancelabel.Visible = false;
                currentbalancelabel.Visible = false;
                custidlabel.Visible = false;
                ChangeCustButton.Visible = false;
                custloginbutton.Visible = true;
            }
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            CHome.CustID = "";
            CHome.Save = false;//- This bool is for the condition later to display the register form instead of edit form.
            CustomerDetails nextform = new CustomerDetails(CHome.AdminID,CHome.CustID,CHome.Balance,CHome.Save); //This is to pass the value of Custid to CustomerDetails for the condition.
            nextform.Show();
            this.Hide();
        }

        private void topupbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CHome.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            CHome.CustID = dr[0].ToString();
                            CHome.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                            CustomerTopUp nextform = new CustomerTopUp(CHome.AdminID, CHome.CustID, CHome.Balance);
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
                    CustomerTopUp nextform1 = new CustomerTopUp(CHome.AdminID, CHome.CustID, CHome.Balance);
                    nextform1.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void custtransferbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CHome.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            CHome.CustID = dr[0].ToString();
                            CHome.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                            CustomerCreditTransfer nextform = new CustomerCreditTransfer(CHome.AdminID, CHome.CustID, CHome.Balance);
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
                CustomerCreditTransfer nextform1 = new CustomerCreditTransfer(CHome.AdminID, CHome.CustID, CHome.Balance);
                nextform1.Show();
                this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void editbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (CHome.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            CHome.CustID = dr[0].ToString();
                            CHome.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                            CustomerDetails nextform = new CustomerDetails(CHome.AdminID, CHome.CustID, CHome.Balance, CHome.Save);
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
                    CustomerDetails nextform = new CustomerDetails(CHome.AdminID, CHome.CustID, CHome.Balance, CHome.Save);
                    nextform.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void custsearchbutton_Click(object sender, EventArgs e)
        {
            CustomerSearch nextform = new CustomerSearch(CHome.AdminID, CHome.CustID, CHome.Balance);
            nextform.Show();
            this.Hide();
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
                        CHome.CustID = dr[0].ToString();
                        CHome.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                        CustomerHome refresh = new CustomerHome(CHome.AdminID, CHome.CustID, CHome.Balance);
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
            try
            {
                CustomerQuickChange f = new CustomerQuickChange();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader();
                    if (dr.Read() == true)
                    {
                        CHome.CustID = dr[0].ToString();
                        CHome.FName = dr[1].ToString(); 
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                        CustomerHome refresh = new CustomerHome(CHome.AdminID, CHome.CustID, CHome.Balance);
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
                if (CHome.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            CHome.CustID = dr[0].ToString();
                            CHome.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + CHome.FName + "!");
                            CustomerOrder nextform = new CustomerOrder(CHome.AdminID, CHome.CustID, CHome.Balance);
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
                    CustomerOrder nextform = new CustomerOrder(CHome.AdminID, CHome.CustID, CHome.Balance);
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
            SystemManagement nextform = new SystemManagement(CHome.AdminID, CHome.CustID, CHome.Balance);
            nextform.Show();
            this.Hide();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            MainMenu back = new MainMenu(CHome.AdminID, CHome.CustID, CHome.Balance);
            back.Show();
            this.Hide();
        }
    }
}
