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
using System.Drawing.Imaging;

namespace User_registration_by_Nesa
{
    public partial class PaymentReceipt : Form
    {
        CustDetailsClass PaymentDC = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        OleDbCommand cmdInsert = new OleDbCommand();
        string OrderDate;
        string OrderTime;
        string BillNo;
        string Subtotal;
        string Discount;
        string ServiceTax;
        string GST;
        string Rounding;
        string GrandTotal;
        string CurrentBalance;
        string NewBalance;
        public PaymentReceipt(string custid, string orderdate, string ordertime, string billNo, string initialSubtotal, string discount, string serviceTax, string gst, string rounding, string grandTotal, string currentBalance, string newBalance)
        {
            InitializeComponent();
            PaymentDC.CustID = custid;
            OrderDate = orderdate;
            OrderTime = ordertime;
            BillNo = billNo;
            Subtotal = initialSubtotal;
            Discount = discount;
            ServiceTax = serviceTax;
            GST = gst;
            Rounding = rounding;
            GrandTotal = grandTotal;
            CurrentBalance = currentBalance;
            NewBalance = newBalance;
        }

        private void PaymentReceipt_Load(object sender, EventArgs e)
        {
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                            "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();

            string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            string sql = "Select * From OrderData";
            OleDbConnection con = new OleDbConnection(conprovider);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable OrderData = new DataTable();
            da.Fill(OrderData);
            paymentdataGridView.DataSource = null;
            paymentdataGridView.DataSource = OrderData;

            //set autosize mode
            paymentdataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            paymentdataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            paymentdataGridView.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //datagrid has calculated it's widths so we can store them
            for (int i = 0; i <= paymentdataGridView.Columns.Count - 1; i++)
            {
                //store autosized widths
                int colw = paymentdataGridView.Columns[i].Width;
                //remove autosizing
                paymentdataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                //set width to calculated by autosize
                paymentdataGridView.Columns[i].Width = colw;
            }
            orderdatetextBox.Text = OrderDate;
            ordertimetextBox.Text = OrderTime;
            billnotextBox.Text = BillNo;
            subtotaltextBox.Text = Subtotal;
            discounttextBox.Text = Discount;
            servicetextBox.Text = ServiceTax;
            GSTtextBox.Text = GST;
            roundingtextBox.Text = Rounding;
            grandtotaltextBox.Text = GrandTotal;
            initialbalancetextBox.Text = CurrentBalance;
            paymenttextBox.Text = GrandTotal;
            newbalancetextBox.Text = NewBalance;
            custidtextBox.Text = PaymentDC.CustID;

            //For storing into reportdata.
            cmdInsert.CommandText = "Insert Into ReportData(BillNo,BillDate,CustID,Amount) Values('" + billnotextBox.Text + "','" + orderdatetextBox.Text + "','" + custidtextBox.Text + "'," + Convert.ToDecimal(grandtotaltextBox.Text) + " );";
            cmdInsert.CommandType = CommandType.Text;                    //Indicates that you are using a text comment
            cmdInsert.Connection = cnnOLEDB;                             //Connect the database
            cmdInsert.ExecuteNonQuery();                                 //For executing the query
        }


        private void printbutton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Receipt has been printed.");
            MainMenu home = new MainMenu(PaymentDC.AdminID,PaymentDC.CustID,PaymentDC.Balance);
            home.Show();
            this.Hide();
        }
    }
}
