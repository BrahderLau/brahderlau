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
    public partial class CustomerSearch : Form
    {
        CustDetailsClass SearchDC = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        public CustomerSearch(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            SearchDC.AdminID = _AdminID;
            SearchDC.CustID = _CustID;
            SearchDC.Balance = _Balance;
        }

        private void CustomerSearch_Load(object sender, EventArgs e)
        {
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                            "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            string[] types = { "CustID", "First Name", "Last Name", "Mobile", "Address", "NRIC", "Date of Birth" };
            foreach (string i in types)
            {
                searchcomboBox.Items.Add(i.ToString());
            }
            searchcomboBox.SelectedIndex = 0;
            searchcomboBox.Focus();
            if (SearchDC.CustID != "")
            {
                //To display CustID Login button.
                custidlabel.Visible = true;
                quickchangememberbutton.Visible = false;
                //To display CustID.
                custidlabel.Text = SearchDC.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + SearchDC.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    SearchDC.Balance = currentbalancelabel.Text;
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

        private void searchbutton_Click(object sender, EventArgs e)
        {
            if (keywordtextBox.Text != "" && searchcomboBox.SelectedIndex != -1)
            {
                if (searchcomboBox.Text == "CustID")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where CustID Like \'%" + keywordtextBox.Text + "%\';"; //Like means equal, % means similar
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "First Name")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where FName Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "Last Name")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where LName Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "Mobile")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where Mobile Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "Address")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where Address Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "NRIC")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where NRIC Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
                else if (searchcomboBox.Text == "Date of Birth")
                {
                    string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                    string sql = "Select * From CustomerData Where DOB Like \'%" + keywordtextBox.Text + "%\';";
                    OleDbConnection con = new OleDbConnection(conprovider);
                    OleDbCommand cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                    DataTable CustomerData = new DataTable();
                    da.Fill(CustomerData);
                    customersearchdataGridView.DataSource = CustomerData;
                    customersearchdataGridView.Refresh();
                    //create the connection using the data adapter of the bridge.
                }
            }
        }

        private void searchcomboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                keywordtextBox.Focus();
            }
        }

        private void keywordtextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                searchbutton.Focus();
            }
        }

        private void searchbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                searchcomboBox.Focus();
            }
        }

        private void CustomerSearch_Shown(object sender, EventArgs e)
        {
            searchcomboBox.Focus();
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
                    SearchDC.CustID = dr[0].ToString();
                    SearchDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + SearchDC.FName + "!");
                    CustomerSearch refresh = new CustomerSearch(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
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
                    SearchDC.CustID = dr[0].ToString();
                    SearchDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + SearchDC.FName + "!");
                    CustomerSearch refresh = new CustomerSearch(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
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
            if (SearchDC.CustID == "")
            {
                CustomerQuickChange f = new CustomerQuickChange();
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        SearchDC.CustID = dr[0].ToString();
                        SearchDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                        this.Hide();
                        MessageBox.Show("  Login successful!\n Welcome," + SearchDC.FName + "!");
                        dr.Close();
                        f.Dispose();
                        CustomerOrder nextform = new CustomerOrder(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
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
                CustomerOrder nextform = new CustomerOrder(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
                nextform.Show();
                this.Hide();
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            CustomerHome back = new CustomerHome(SearchDC.AdminID,SearchDC.CustID,SearchDC.Balance);
            back.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(SearchDC.AdminID, SearchDC.CustID, SearchDC.Balance);
            nextform.Show();
            this.Hide();
        }
    }
}
