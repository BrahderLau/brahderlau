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
    public partial class AddItem : Form
    {
        CustDetailsClass aItem = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdInsert = new OleDbCommand();
        public AddItem(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            aItem.AdminID = _AdminID;
            aItem.CustID = _CustID;
            aItem.Balance = _Balance;
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void AddItem_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            CustomerOrder nextform = new CustomerOrder(aItem.AdminID, aItem.CustID, aItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(aItem.AdminID, aItem.CustID, aItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(aItem.AdminID, aItem.CustID, aItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void addfoodbutton_Click(object sender, EventArgs e)
        {
            if (foodidtextBox.Text != "" && foodtextBox.Text != "" && foodpricemaskedTextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into FoodData(FoodID,FoodName,Price) Values('" + foodidtextBox.Text + "','" + foodtextBox.Text + "', '" + foodpricemaskedTextBox.Text + "' );";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
        }

        private void addexpressobeveragebutton_Click(object sender, EventArgs e)
        {
            if (expidtextBox.Text != "" && ExpressotextBox.Text != "" && ExpressosmalltextBox.Text != "" && ExpressoLargetextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into ExpData(ExpID,ExpName,SmallPrice,LargePrice) Values('" + expidtextBox.Text + "','" + ExpressotextBox.Text + "', '" + ExpressosmalltextBox.Text + "','" + ExpressoLargetextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
            else if (expidtextBox.Text != "" && ExpressotextBox.Text != "" && ExpressosmalltextBox.Text != "" || ExpressoLargetextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into ExpData(ExpID,ExpName,SmallPrice) Values('" + expidtextBox.Text + "','" + ExpressotextBox.Text + "', '" + ExpressosmalltextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
            else if (expidtextBox.Text != "" && ExpressotextBox.Text != "" && ExpressosmalltextBox.Text != "" || ExpressoLargetextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into ExpData(ExpID,ExpName,LargePrice) Values('" + expidtextBox.Text + "','" + ExpressotextBox.Text + "','" + ExpressoLargetextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
        }

        private void addicebeveragebutton_Click(object sender, EventArgs e)
        {
            if (iceidtextBox.Text != "" && IcetextBox.Text != "" && IcesmalltextBox.Text != "" && IceLargetextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into IceData(IceID,IceName,SmallPrice,LargePrice) Values('" + iceidtextBox.Text + "','" + IcetextBox.Text + "', '" + IcesmalltextBox.Text + "','" + IceLargetextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
            else if (iceidtextBox.Text != "" && IcetextBox.Text != "" && IcesmalltextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into IceData(IceID,IceName,SmallPrice) Values('" + iceidtextBox.Text + "','" + IcetextBox.Text + "', '" + IcesmalltextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
            }
            else if (iceidtextBox.Text != "" && IcetextBox.Text != "" && IceLargetextBox.Text != "") //Check whether the textBox is blank
            {                                                                //For inserting into Access Database
                cmdInsert.CommandText = "Insert Into IceData(IceID,IceName,LargePrice) Values('" + iceidtextBox.Text + "','" + IcetextBox.Text + "', '" + IceLargetextBox.Text + "');";
                cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
                cmdInsert.Connection = cnnOLEDB;                             //Connect the database
                cmdInsert.ExecuteNonQuery();                                 //For executing the query
                MessageBox.Show("Insertion Successful");                     //Give a confirmation message
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

        private void backbutton_Click(object sender, EventArgs e)
        {
            SystemManagement back = new SystemManagement(aItem.AdminID,aItem.CustID,aItem.Balance);
            back.Show();
            this.Hide();
        }
    }
}
