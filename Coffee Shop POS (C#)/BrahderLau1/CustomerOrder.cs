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
    public partial class CustomerOrder : Form
    {
        CustDetailsClass OrderDC = new CustDetailsClass();
        PaymentClass OrderPC = new PaymentClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdUpdate = new OleDbCommand();
        OleDbCommand cmdSearch = new OleDbCommand();
        OleDbCommand cmdInsert = new OleDbCommand();
        OleDbCommand cmdDelete = new OleDbCommand();
        string billNo;// Here i delcare the variable so that i can use it when i create an object for the class.

        public CustomerOrder(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            OrderDC.AdminID = _AdminID;
            OrderDC.CustID = _CustID;
            OrderDC.Balance = _Balance;
        }

        private void CustomerOrder_Load(object sender, EventArgs e)
        {
            try
            {
                DateTimetimer.Start();
                this.datetimelabel.Hide();
                cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                                "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
                cnnOLEDB.Open();
                BillNoClass OrderPC = new BillNoClass(billNo);
                billNo = OrderPC.RandomBillNo();
                billnotextBox.Text = billNo;

                //To display CustID.
                custidlabel.Text = OrderDC.CustID;
                //To display current balance.
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + OrderDC.CustID + "\';";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader();
                if (dr.Read() == true)
                {
                    OrderDC.Balance = dr[13].ToString();
                    currentbalancelabel.Text = OrderDC.Balance;
                }
                dr.Close();
                //Fill comboBox with Food from FoodData
                cmdSearch.CommandText = "Select FoodName From FoodData ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader drFood = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (drFood.Read())
                {
                    FoodcomboBox.Text = "Add Food";
                    FoodcomboBox.Items.Add(drFood["FoodName"].ToString());
                }
                drFood.Close();

                //Fill comboBox with Ice from IceBeverageData
                cmdSearch.CommandText = "Select IceName From IceData ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader drIce = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (drIce.Read())
                {
                    icebeveragecomboBox.Text = "Add Drink";
                    icebeveragecomboBox.Items.Add(drIce["IceName"].ToString());
                }
                drIce.Close();

                //Fill comboBox with Expresso from ExpressoBeverageData
                cmdSearch.CommandText = "Select ExpName From ExpData ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader drExpresso = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (drExpresso.Read())
                {
                    ExpressocomboBox.Text = "Add Drink";
                    ExpressocomboBox.Items.Add(drExpresso["ExpName"].ToString());
                }
                drExpresso.Close();
                refreshtimer.Start();
            }
            catch
            {
                MessageBox.Show("Technical error");
            }
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void cancelorderbutton_Click(object sender, EventArgs e)
        {
            try
            {
                cmdDelete.CommandText = "Delete From OrderData";
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.Connection = cnnOLEDB;
                cmdDelete.ExecuteNonQuery();
                MessageBox.Show("Order canceled.");
                CustomerOrder reset = new CustomerOrder(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
                reset.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Technical error");
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

        private void quickchangememberbutton_Click(object sender, EventArgs e)
        {
            CustomerQuickChange f = new CustomerQuickChange();
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                cmdSearch.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                cmdSearch.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdSearch.ExecuteReader();
                if (dr.Read() == true)
                {
                    OrderDC.CustID = dr[0].ToString();
                    OrderDC.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    this.Hide();
                    MessageBox.Show("  Login successful!\n Welcome," + OrderDC.FName + "!");
                    CustomerOrder refresh = new CustomerOrder(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
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
            MainMenu back = new MainMenu(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
            back.Show();
            this.Hide();
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.orderdatetextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.ordertimetextBox.Text = DateTime.Now.ToString("HH:mm:ss");
            this.datetimelabel.Show();
        }

        private void FoodcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodquantitycomboBox.SelectedIndex = 0;
            OrderPC.SelectedFood = FoodcomboBox.SelectedItem.ToString();
            cmdSearch.CommandText = "Select Price From FoodData where FoodName = '" + OrderPC.SelectedFood + "' ";
            cmdSearch.Connection = cnnOLEDB;
            cmdSearch.ExecuteNonQuery();
            OleDbDataReader drFoodPrice = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
            while (drFoodPrice.Read())
            {
                OrderPC.FoodPrice = Convert.ToDecimal(drFoodPrice["Price"]);
            }
            drFoodPrice.Close();
            if (foodquantitycomboBox.Text != "")
            {
                OrderPC.FoodQuantity = int.Parse(foodquantitycomboBox.Text);
                OrderPC.FoodPrice *= OrderPC.FoodQuantity;
                FoodpricetextBox.Text = OrderPC.FoodPrice.ToString();
            }
        }

        private void foodquantitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (foodquantitycomboBox.Text != "")
            {
                OrderPC.FoodQuantity = int.Parse(foodquantitycomboBox.Text);
                OrderPC.TotalFoodPrice = OrderPC.FoodPrice * OrderPC.FoodQuantity;
                FoodpricetextBox.Text = OrderPC.TotalFoodPrice.ToString();
            }
        }

        private void icebeveragecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderPC.SelectedIce = icebeveragecomboBox.SelectedItem.ToString();
            IcesizecomboBox.SelectedIndex = 0;
            icequantitycomboBox.SelectedIndex = 0;
            if (IcesizecomboBox.Text == "S")
            {
                cmdSearch.CommandText = "Select SmallPrice From IceData where IceName = '" + OrderPC.SelectedIce + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.IceSize = "S";
                    OrderPC.IcePrice = Convert.ToDecimal(dr["SmallPrice"]);
                }
                dr.Close();
            }

            else if (IcesizecomboBox.Text == "L")
            {
                cmdSearch.CommandText = "Select LargePrice From IceData where IceName = '" + OrderPC.SelectedIce + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.IceSize = "L";
                    OrderPC.IcePrice = Convert.ToDecimal(dr["LargePrice"]);
                }
                dr.Close();
            }
            OrderPC.IceQuantity = int.Parse(icequantitycomboBox.Text);
            OrderPC.TotalIcePrice = OrderPC.IcePrice * OrderPC.IceQuantity;
            IcepricetextBox.Text = OrderPC.TotalIcePrice.ToString();
        }

        private void IcesizecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderPC.IceSize = IcesizecomboBox.Text;
            if (OrderPC.IceSize == "S")
            {
                cmdSearch.CommandText = "Select SmallPrice From IceData where IceName = '" + OrderPC.SelectedIce + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.IcePrice = Convert.ToDecimal(dr["SmallPrice"]);
                }
                dr.Close();
            }

            else
            {
                cmdSearch.CommandText = "Select LargePrice From IceData where IceName = '" + OrderPC.SelectedIce + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.IcePrice = Convert.ToDecimal(dr["LargePrice"]);
                }
                dr.Close();
            }
            decimal totalIcePrice = OrderPC.IcePrice * OrderPC.IceQuantity;
            IcepricetextBox.Text = totalIcePrice.ToString();
        }

        private void icequantitycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderPC.IceQuantity = int.Parse(icequantitycomboBox.Text);
            decimal totalIcePrice = OrderPC.IcePrice * OrderPC.IceQuantity;
            IcepricetextBox.Text = totalIcePrice.ToString();
        }

        private void ExpressocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderPC.SelectedExp = ExpressocomboBox.SelectedItem.ToString();
            ExpressosizecomboBox.SelectedIndex = 0;
            expquantitycomboBox.SelectedIndex = 0;
            if (ExpressosizecomboBox.Text == "S")
            {
                cmdSearch.CommandText = "Select SmallPrice From ExpData where ExpName = '" + OrderPC.SelectedExp + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.ExpSize = "S";
                    OrderPC.ExpPrice = Convert.ToDecimal(dr["SmallPrice"]);
                }
                dr.Close();
            }

            else if (ExpressosizecomboBox.Text == "L")
            {
                string selectedexplarge = ExpressocomboBox.SelectedItem.ToString();
                cmdSearch.CommandText = "Select LargePrice From ExpData where ExpName = '" + OrderPC.SelectedExp + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader();
                while (dr.Read())
                {
                    OrderPC.ExpSize = "L";
                    OrderPC.ExpPrice = Convert.ToDecimal(dr["LargePrice"]);
                }
                dr.Close();
            }
            OrderPC.ExpQuantity = int.Parse(expquantitycomboBox.Text);
            OrderPC.TotalExpPrice = OrderPC.ExpPrice * OrderPC.ExpQuantity;
            ExpressopricetextBox.Text = OrderPC.TotalExpPrice.ToString();
        }


        private void ExpressosizecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            OrderPC.ExpSize = ExpressosizecomboBox.Text;
            if (OrderPC.ExpSize == "S")
            {
                cmdSearch.CommandText = "Select SmallPrice From ExpData where ExpName = '" + OrderPC.SelectedExp + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.ExpPrice = Convert.ToDecimal(dr["SmallPrice"]);
                }
                dr.Close();
            }

            else
            {
                cmdSearch.CommandText = "Select LargePrice From ExpData where ExpName = '" + OrderPC.SelectedExp + "' ";
                cmdSearch.Connection = cnnOLEDB;
                cmdSearch.ExecuteNonQuery();
                OleDbDataReader dr = cmdSearch.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                while (dr.Read())
                {
                    OrderPC.ExpPrice = Convert.ToDecimal(dr["LargePrice"]);
                }
                dr.Close();
            }
            decimal totalExpPrice = OrderPC.ExpPrice * OrderPC.ExpQuantity;
            ExpressopricetextBox.Text = totalExpPrice.ToString();
        }

        private void expquantitycomboBox_TextChanged(object sender, EventArgs e)
        {
            OrderPC.ExpQuantity = int.Parse(expquantitycomboBox.Text);
            decimal totalExpPrice = OrderPC.ExpPrice * OrderPC.ExpQuantity;
            ExpressopricetextBox.Text = totalExpPrice.ToString();
        }

        private void AddFoodbutton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderPC.TotalFoodPrice = decimal.Parse(FoodpricetextBox.Text);
                string type = "Food";
                cmdInsert.CommandText = "Insert into OrderData([ItemType],[ItemName],[Quantity],[TotalPrice]) Values(\'" + type
                                + "\',\'" + OrderPC.SelectedFood
                                + "\'," + OrderPC.FoodQuantity
                                + "," + OrderPC.TotalFoodPrice + ");";
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Connection = cnnOLEDB;
                cmdInsert.ExecuteNonQuery();
                refreshtimer.Start();
                AddToCart();
            }
            catch
            {
                MessageBox.Show("Food column details are not filled completely.");
            }
        }

        private void AddIcebutton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderPC.TotalIcePrice = decimal.Parse(IcepricetextBox.Text);
                string type = "Ice";
                cmdInsert.CommandText = "Insert into OrderData([ItemType],[ItemName],[Size],[Quantity],[TotalPrice]) Values(\'" + type
                                + "\',\'" + OrderPC.SelectedIce
                                + "\',\'" + OrderPC.IceSize
                                + "\'," + OrderPC.IceQuantity
                                + "," + OrderPC.TotalIcePrice + ");";
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Connection = cnnOLEDB;
                cmdInsert.ExecuteNonQuery();
                refreshtimer.Start();
                AddToCart();
            }
            catch
            {
                MessageBox.Show("Ice column details are not filled completely.");
            }
        }

        private void AddExpressobutton_Click(object sender, EventArgs e)
        {
            try
            {
                OrderPC.TotalExpPrice = decimal.Parse(ExpressopricetextBox.Text);
                string type = "Exp";
                cmdInsert.CommandText = "Insert into OrderData([ItemType],[ItemName],[Size],[Quantity],[TotalPrice]) Values(\'" + type
                                + "\',\'" + OrderPC.SelectedExp
                                + "\',\'" + OrderPC.ExpSize
                                + "\'," + OrderPC.ExpQuantity
                                + "," + OrderPC.TotalExpPrice + ");";
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.Connection = cnnOLEDB;
                cmdInsert.ExecuteNonQuery();
                refreshtimer.Start();
                AddToCart();
            }
            catch
            {
                MessageBox.Show("Expresso column details are not filled completely.");
            }
        }

        private void refreshtimer_Tick(object sender, EventArgs e)
        {
            string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            string sql = "Select * From OrderData";
            OleDbConnection con = new OleDbConnection(conprovider);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable OrderData = new DataTable();
            da.Fill(OrderData);
            OrderCartdataGridView.DataSource = null;
            OrderCartdataGridView.DataSource = OrderData;
            con.Close();
        }

        private void OrderCartdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshtimer.Stop();
        }

        private void OrderCartdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            refreshtimer.Stop();
        }

        private void proceedbutton_Click(object sender, EventArgs e)
        {
            AddToCart();
            OrderPC.GrandTotal = Convert.ToDecimal(grandtotaltextBox.Text);
            if (OrderPC.GrandTotal >= Convert.ToDecimal(OrderDC.Balance))
            {
                DialogResult Result = MessageBox.Show("Insufficient balance. Do you wish to topup? Note: Your cart will be stored temporarily.", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                switch (Result)
                {
                    case DialogResult.Yes:
                        {
                            CustomerTopUp nextform = new CustomerTopUp(OrderDC.AdminID, OrderDC.CustID, OrderDC.Balance);
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
                decimal currentBalance = Convert.ToDecimal(OrderDC.Balance);
                decimal newBalance = currentBalance - OrderPC.GrandTotal;
                OrderDC.Balance = newBalance.ToString();
                MessageBox.Show("Payment Successful. Your new balance is now : RM" + OrderDC.Balance);
                cmdUpdate.CommandText = "Update CustomerData Set Balance = " + Convert.ToDecimal(OrderDC.Balance) + " Where CustID = \'" + OrderDC.CustID + "\';";
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.Connection = cnnOLEDB;
                cmdUpdate.ExecuteNonQuery(); // go to database change one row and do not return any value
                OleDbDataReader dr = cmdSearch.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    string orderdate = orderdatetextBox.Text;
                    string ordertime = ordertimetextBox.Text;
                    string initialSubtotal = subtotaltextBox.Text;
                    PaymentReceipt nextform = new PaymentReceipt(custidlabel.Text,orderdate,ordertime,billNo,initialSubtotal,discounttextBox.Text,servicetextBox.Text,GSTtextBox.Text,OrderPC.Rounding.ToString(),grandtotaltextBox.Text,currentBalance.ToString(),OrderDC.Balance);
                    nextform.Show();
                    this.Hide();
                }
            }
        }
            
        
        public void AddToCart()
        {
            PaymentClass OrderPC = new PaymentClass();
            cmdSearch.CommandText = "Select sum([TotalPrice]) From OrderData";
            cmdSearch.Connection = cnnOLEDB;
            cmdSearch.ExecuteNonQuery();
            OleDbDataReader dr = cmdSearch.ExecuteReader();
            if (dr.Read() == true)
            {
                dr.Close();
                OrderPC.Subtotal = Convert.ToDecimal(cmdSearch.ExecuteScalar());
                subtotaltextBox.Text = OrderPC.Subtotal.ToString();
                if (OrderPC.Subtotal >= 50)
                {
                    OrderPC.CalcDiscount();
                    discounttextBox.Text = OrderPC.Subtotal.ToString();
                }
                else
                {
                    discounttextBox.Text = "N/A";
                }
                OrderPC.CalcServiceTax();
                servicetextBox.Text = OrderPC.ServiceTax.ToString();
                OrderPC.CalcGST();
                GSTtextBox.Text = OrderPC.GST.ToString();
                OrderPC.Rounding = OrderPC.Subtotal;
                OrderPC.RoundOff();
                OrderPC.Rounding = OrderPC.Subtotal - OrderPC.Rounding;
                roundingtextBox.Text = OrderPC.Rounding.ToString();
                OrderPC.GrandTotal = OrderPC.Subtotal;
                grandtotaltextBox.Text = OrderPC.GrandTotal.ToString(".00");
                OrderPC.GrandTotal = Convert.ToDecimal(grandtotaltextBox.Text);
            }
        }
    }
}
