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
    public partial class CustomerQuickChange : Form
    {
        public CustomerQuickChange()
        {
            InitializeComponent();
            this.okbutton.DialogResult = System.Windows.Forms.DialogResult.OK; https://stackoverflow.com/questions/487920/winforms-acceptbutton-not-working
            this.cancelbutton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void CustomerQuickChange_Load(object sender, EventArgs e)
        {

        }
    }
}
