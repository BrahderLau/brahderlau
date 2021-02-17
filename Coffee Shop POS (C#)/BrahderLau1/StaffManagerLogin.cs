using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; //Borrow the library for the purpose of database linking.


namespace User_registration_by_Nesa
{
    public partial class StaffManagerLogin : Form
    {
        CustDetailsClass loginDC = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();

        public StaffManagerLogin()
        {
            InitializeComponent();
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                DateTimetimer.Start();
                this.datetimelabel.Hide();
                cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                                "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                cnnOLEDB.Open();
                if (Properties.Settings.Default.userName != string.Empty) //In you winforms project right click and go to properties, select settings and add name to store data (eg. userName and passUser) ref = https://stackoverflow.com/questions/12539382/how-to-remember-username-or-password-for-login-form
                {
                    usernametextBox.Text = Properties.Settings.Default.userName;
                    passwordtextBox.Text = Properties.Settings.Default.passWord;
                }
                managerlabel.Visible = false;
                stafflinkLabel.Visible = false;
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void remembermecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (remembermecheckBox.Checked)
            {
                Properties.Settings.Default.userName = usernametextBox.Text;
                Properties.Settings.Default.passWord = passwordtextBox.Text;
                Properties.Settings.Default.Save();
            }
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            try
            {
                loginDC.Username = usernametextBox.Text;
                loginDC.Password = passwordtextBox.Text;
                loginDC.CustID = "";
                if (stafflinkLabel.Visible)
                {
                    cmdSearch.CommandText = "Select * From ManagerData Where Username = \'" + loginDC.Username + "\' And Password = \'" + loginDC.Password + "\';";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        loginDC.AdminID = dr[0].ToString();
                        loginDC.FName = dr[1].ToString();
                        MessageBox.Show("Login Successful! Welcome " + loginDC.FName + "!");
                        MainMenu nextform = new MainMenu(loginDC.AdminID,loginDC.CustID,loginDC.Balance); // ref : https://www.youtube.com/watch?v=RAAxqTK1W-k
                        nextform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                        usernametextBox.Clear();
                        passwordtextBox.Clear();
                        usernametextBox.Focus();
                    }
                    dr.Close();
                }
                else
                {
                    cmdSearch.CommandText = "Select * From StaffData Where Username = \'" + loginDC.Username + "\' And Password = \'" + loginDC.Password + "\';";
                    cmdSearch.Connection = cnnOLEDB;
                    OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                    if (dr.Read() == true)
                    {
                        loginDC.AdminID = dr[0].ToString();
                        loginDC.FName = dr[1].ToString();
                        MessageBox.Show("Login Successful! Welcome " + loginDC.FName + "!");
                        MainMenu nextform = new MainMenu(loginDC.AdminID, loginDC.CustID, loginDC.Balance);
                        nextform.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect!");
                        usernametextBox.Clear();
                        passwordtextBox.Clear();
                        usernametextBox.Focus();
                    }
                    dr.Close();
                }
            }
            catch
            {
                MessageBox.Show("Technical error.");
            }
        }

        private void stafflinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            stafflinkLabel.Visible = false;
            managerlinkLabel.Visible = true;
            stafflabel.Visible = true;
            managerlabel.Visible = false;
            usernametextBox.Clear();
            passwordtextBox.Clear();
            usernametextBox.Focus();
        }

        private void managerlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            managerlinkLabel.Visible = false;
            stafflinkLabel.Visible = true;
            managerlabel.Visible = true;
            stafflabel.Visible = false;
            usernametextBox.Clear();
            passwordtextBox.Clear();
            usernametextBox.Focus();
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
    }
}
