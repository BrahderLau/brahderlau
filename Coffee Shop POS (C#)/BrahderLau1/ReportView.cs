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
    public partial class ReportView : Form
    {
        CustDetailsClass reportDC = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdSearch = new OleDbCommand();
        public ReportView(string _AdminID, string _CustID, string _Balance)
        {
            InitializeComponent();
            reportDC.AdminID = _AdminID;
            reportDC.CustID = _CustID;
            reportDC.Balance = _Balance;
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            string conprovider = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            string sql = "Select * From ReportData";
            OleDbConnection con = new OleDbConnection(conprovider);
            OleDbCommand cmd = new OleDbCommand(sql, con);
            con.Open();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable ReportData = new DataTable();
            da.Fill(ReportData);
            reportdataGridView.DataSource = ReportData;
            reportdataGridView.Refresh();
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            CustomerOrder nextform = new CustomerOrder(reportDC.AdminID, reportDC.CustID, reportDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void systemButton_Click(object sender, EventArgs e)
        {
            SystemManagement nextform = new SystemManagement(reportDC.AdminID, reportDC.CustID, reportDC.Balance);
            nextform.Show();
            this.Hide();
        }

        private void customerButton_Click(object sender, EventArgs e)
        {
            CustomerHome nextform = new CustomerHome(reportDC.AdminID, reportDC.CustID, reportDC.Balance);
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

        private void backbutton_Click(object sender, EventArgs e)
        {
            SystemManagement back = new SystemManagement(reportDC.AdminID, reportDC.CustID, reportDC.Balance);
            back.Show();
            this.Hide();
        }
    }
}
