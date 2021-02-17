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
    public partial class MainMenu : Form
    {
        OleDbConnection cnnOLEDB = new OleDbConnection();
        OleDbCommand cmdSearch = new OleDbCommand();
        CustDetailsClass homeDC = new CustDetailsClass();
        public MainMenu(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            homeDC.AdminID = _AdminID;
            homeDC.CustID = _CustID;
            homeDC.Balance = _Balance;
        }

        private void NewHomePage_Load(object sender, EventArgs e)
        {
            try
            {
                DateTimetimer.Start();
                this.datetimelabel.Hide();
                cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                cnnOLEDB.Open();
                if (homeDC.CustID != "")
                {
                    //To display CustID Login button.
                    custidlabel.Visible = true;
                    ChangeCustButton.Visible = false;
                    //To display CustID.
                    custidlabel.Text = homeDC.CustID;
                    //To display current balance.
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + homeDC.CustID + "\';";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        currentbalancelabel.Text = dr[13].ToString();
                        homeDC.Balance = currentbalancelabel.Text;
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
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            StaffManagerLogin back = new StaffManagerLogin();
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

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(homeDC.AdminID,homeDC.CustID,homeDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(homeDC.AdminID, homeDC.CustID, homeDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (homeDC.CustID == "")
                {
                    CustomerQuickChange f = new CustomerQuickChange();
                    if (f.ShowDialog(this) == DialogResult.OK)
                    {
                        cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                        cmdSearch.Connection = cnnOLEDB;
                        OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                        if (dr.Read() == true)
                        {
                            homeDC.CustID = dr[0].ToString();
                            homeDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                            this.Hide();
                            MessageBox.Show("  Login successful!\n Welcome," + homeDC.FName + "!");
                            CustomerOrder nextform = new CustomerOrder(homeDC.AdminID, homeDC.CustID, homeDC.Balance);
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
                    CustomerOrder nextform = new CustomerOrder(homeDC.AdminID, homeDC.CustID, homeDC.Balance);
                    nextform.Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void ChangeCustButton_Click(object sender, EventArgs e)
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
                        homeDC.CustID = dr[0].ToString();
                        homeDC.FName = dr[1].ToString();
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + homeDC.FName + "!");
                        MainMenu refresh = new MainMenu(homeDC.AdminID, homeDC.CustID, homeDC.Balance);
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

        private void custloginbutton_Click(object sender, EventArgs e)
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
                        homeDC.CustID = dr[0].ToString();
                        homeDC.FName = dr[1].ToString(); 
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + homeDC.FName + "!");
                        MainMenu refresh = new MainMenu(homeDC.AdminID, homeDC.CustID, homeDC.Balance);
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
    }
}
