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
    public partial class SearchItem : Form
    {
        CustDetailsClass sItem = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        public SearchItem(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            sItem.AdminID = _AdminID;
            sItem.CustID = _CustID;
            sItem.Balance = _Balance;
        }

        private void SearchItem_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();


            cmdSearch.CommandText = "Select * from FoodData ";
            cmdSearch.Connection = cnnOLEDB;
            OleDbDataReader reader = cmdSearch.ExecuteReader();
            while (reader.Read())
            {
                foodsearchcomboBox.Items.Add(" |FoodID:|  " + reader["FoodID"].ToString() 
                + " |Name:|  " + reader["FoodName"].ToString() + "  |Price:|  " + reader["Price"].ToString());
            }
            reader.Close();

            cmdSearch.CommandText = "Select * from ExpData ";
            cmdSearch.Connection = cnnOLEDB;
            OleDbDataReader reader1 = cmdSearch.ExecuteReader();
            while (reader1.Read())
            {
                expbeveragesearchcomboBox.Items.Add(" |ExpID:|  " + reader1["ExpID"].ToString()
                + " |Name:|  " + reader1["ExpName"].ToString() + " |Small:|  " + reader1["SmallPrice"].ToString() + " |Large:|  " + reader1["LargePrice"].ToString());
            }
            reader1.Close();

            cmdSearch.CommandText = "Select * from IceData ";
            cmdSearch.Connection = cnnOLEDB;
            OleDbDataReader reader2 = cmdSearch.ExecuteReader();
            while (reader2.Read())
            {
                icebeveragecomboBox.Items.Add(" |IceID:|  " + reader2["IceID"].ToString()
                + " |Name:|  " + reader2["IceName"].ToString() + " |Small:|  " + reader2["SmallPrice"].ToString() + " |Large:|  " + reader2["LargePrice"].ToString());
            }
            reader2.Close();
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            SystemManagement back = new SystemManagement(sItem.AdminID,sItem.CustID,sItem.Balance);
            back.Show();
            this.Hide();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            CustomerOrder nextform = new CustomerOrder(sItem.AdminID, sItem.CustID, sItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(sItem.AdminID, sItem.CustID, sItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(sItem.AdminID, sItem.CustID, sItem.Balance);
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
    }
}
