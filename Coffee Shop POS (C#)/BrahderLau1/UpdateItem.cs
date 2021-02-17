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
    public partial class UpdateItem : Form
    {
        CustDetailsClass uItem = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdUpdate = new OleDbCommand();
        public UpdateItem(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            uItem.AdminID = _AdminID;
            uItem.CustID = _CustID;
            uItem.Balance = _Balance;
        }

        private void UpdateItem_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                   "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            CustomerOrder nextform = new CustomerOrder(uItem.AdminID, uItem.CustID, uItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(uItem.AdminID, uItem.CustID, uItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(uItem.AdminID, uItem.CustID, uItem.Balance);
            nextform.Show();
            this.Hide();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            SystemManagement back = new SystemManagement(uItem.AdminID, uItem.CustID, uItem.Balance);
            back.Show();
            this.Hide();
        }

        private void updatefoodbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (foodidtextBox.Text != "" && foodpricemaskedTextBox.Text != "")
                {
                    cmdUpdate.CommandText = "Update FoodData Set FoodName = '" + foodtextBox.Text + "', Price = '" + foodpricemaskedTextBox.Text + "' Where FoodID = '" + foodidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
            }
            catch
            {
                MessageBox.Show("FoodID record does not exist. Please try again.");
            }
        }

        private void updateexpressobeveragebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ExpressosmalltextBox.Text != "" && ExpressoLargetextBox.Text == "")
                {
                    cmdUpdate.CommandText = "Update ExpData Set ExpName = '" + ExpressotextBox.Text + "', SmallPrice = '" + ExpressosmalltextBox.Text + "' Where ExpID = '" + expidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
                else if (ExpressosmalltextBox.Text != "" && ExpressoLargetextBox.Text == "")
                {
                    cmdUpdate.CommandText = "Update ExpData Set ExpName = '" + ExpressotextBox.Text + "', LargePrice = '" + ExpressoLargetextBox.Text + "' Where ExpID = '" + expidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
                else if (ExpressosmalltextBox.Text != "" && ExpressoLargetextBox.Text != "")
                {
                    cmdUpdate.CommandText = "Update ExpData Set ExpName = '" + ExpressotextBox.Text + "', SmallPrice = '" + ExpressosmalltextBox.Text + "', LargePrice = '" + ExpressoLargetextBox.Text + "' Where ExpID = '" + expidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
            }
            catch
            {
                MessageBox.Show("ExpID record does not exist. Please try again.");
            }
        }

        private void updateicebeveragebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (IcesmalltextBox.Text != "" && IceLargetextBox.Text == "")
                {
                    cmdUpdate.CommandText = "Update IceData Set IceName = '" + IcetextBox.Text + "', SmallPrice = '" + IcesmalltextBox.Text + "' Where IceID = '" + iceidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
                else if (IcesmalltextBox.Text == "" && IceLargetextBox.Text != "")
                {
                    cmdUpdate.CommandText = "Update IceData Set IceName = '" + IcetextBox.Text + "', LargePrice = '" + IceLargetextBox.Text + "' Where IceID = '" + iceidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
                else if (IcesmalltextBox.Text != "" && IceLargetextBox.Text != "")
                {
                    cmdUpdate.CommandText = "Update IceData Set IceName = '" + IcetextBox.Text + "', SmallPrice = '" + IcesmalltextBox.Text + "', LargePrice = '" + IceLargetextBox.Text + "' Where IceID = '" + iceidtextBox.Text + "' ";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    MessageBox.Show("Record Updated");
                }
            }
            catch
            {
                MessageBox.Show("IceID record does not exist. Please try again.");
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
    }
}
