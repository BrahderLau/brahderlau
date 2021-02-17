using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.OleDb; //Borrow the library for the purpose of database linking.

namespace User_registration_by_Nesa
{
    public partial class CustomerDetails : Form
    {
        CustDetailsClass customer = new CustDetailsClass();
        OleDbConnection cnnOLEDB = new OleDbConnection(); //Variables here are decleared globally; OleDbConnection class is create by C#.net
        OleDbCommand cmdInsert = new OleDbCommand(); //Insert command
        OleDbCommand cmdDerive = new OleDbCommand(); //Derive means take data from database.
        OleDbCommand cmdUpdate = new OleDbCommand(); //Update command - update information edited by customer.

        public CustomerDetails(string _AdminID, string _CustID, string _Balance, bool _Save)
        {
            InitializeComponent();
            customer.AdminID = _AdminID;
            customer.CustID = _CustID;
            customer.Balance = _Balance;
            customer.Save = _Save;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DateTimetimer.Start();
            this.datetimelabel.Hide();
            cnnOLEDB.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                                "Data Source=BigCoffeeDatabase.accdb;Persist Security Info = False;";
            cnnOLEDB.Open();
            if (customer.Save == false && customer.CustID == "")//This means to register
            {
                dobdateTimePicker.Format = DateTimePickerFormat.Custom; //ref - https://www.codeproject.com/Questions/329879/Datetime-picker-control-to-be-blank-when-the-form
                dobdateTimePicker.CustomFormat = " "; //a string with one whitespace - This will display a string with an empty space inside by default to prompt user for selecting DOB.
                custiddisplaylabel.Visible = false;
                custidlabel.Visible = false;
                currentbalancelabel.Visible = false;
                displaycurrentbalancelabel.Visible = false;
                savebutton.Visible = false;
                quickchangememberbutton.Visible = false;
                registerbutton.Visible = true;
                nricmaskedTextBox.Enabled = true;
            }
            else //This means to save details.
            {
                //To display CustID.
                custiddisplaylabel.Visible = true;
                custidlabel.Visible = true;
                //To display CustID.
                custidlabel.Text = customer.CustID;
                //To display current balance.
                cmdDerive.CommandText = "Select * From CustomerData Where CustID = \'" + customer.CustID + "\';";
                cmdDerive.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdDerive.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    currentbalancelabel.Text = dr[13].ToString();
                    customer.Balance = currentbalancelabel.Text;
                }
                dr.Close();
                currentbalancelabel.Visible = true;
                displaycurrentbalancelabel.Visible = true;
                savebutton.Visible = true;
                quickchangememberbutton.Visible = true;
                registerbutton.Visible = false;
                nricmaskedTextBox.Enabled = false; //"false" property will make the text box disable. and "true" will make it in regular form.
                ValidateRegisterForm();
            }
        }

        private void registerbutton_Click(object sender, EventArgs e)
        {
            customer.Save = true;
            ValidateRegisterForm();
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            customer.Save = true;
            if (customer.CustID == "")
            {
                MessageBox.Show("Please login the CustID.");
            }
            else
            {
                ValidateRegisterForm();
                MainMenu done = new MainMenu(customer.AdminID, customer.CustID, customer.Balance);
                done.Show();
                this.Hide();
            }
        }

        public void ValidateRegisterForm()
        {
            customer.FName = firstnametextBox.Text;
            customer.LName = lastnametextBox.Text;
            customer.Home = HomemaskedTextBox.Text;
            customer.Mobile = MobilemaskedTextBox.Text;
            customer.Address = addresstextBox.Text;
            customer.City = citytextBox.Text;
            customer.State = statetextBox.Text;
            customer.Zipcode = zipcodemaskedtextbox.Text;
            customer.Email = emailtextBox.Text;
            customer.NRIC = nricmaskedTextBox.Text;
            customer.DOB = dobdateTimePicker.Text;

            if (customer.CustID != "" && customer.Save == false) //This is for getting details
            {
                cmdDerive.CommandText = "Select * From CustomerData Where CustID = \'" + customer.CustID + "\';";
                cmdDerive.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdDerive.ExecuteReader(); // It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    firstnametextBox.Text = dr[1].ToString();
                    lastnametextBox.Text = dr[2].ToString();
                    customer.Gender = dr[3].ToString();
                    HomemaskedTextBox.Text = dr[4].ToString();
                    MobilemaskedTextBox.Text = dr[5].ToString();
                    addresstextBox.Text = dr[6].ToString();
                    citytextBox.Text = dr[7].ToString();
                    statetextBox.Text = dr[8].ToString();
                    zipcodemaskedtextbox.Text = dr[9].ToString();
                    emailtextBox.Text = dr[10].ToString();
                    nricmaskedTextBox.Text = dr[11].ToString();
                    dobdateTimePicker.Text = dr[12].ToString();
                }
                dr.Close();
                if (customer.Gender == "Male")
                {
                    maleradioButton.Checked = true;
                }
                else if (customer.Gender == "Female")
                {
                    femaleradioButton.Checked = true;
                }
                else if (customer.Gender != "")
                {
                    othersradioButton.Checked = true;
                    othertextBox.Text = customer.Gender;
                }
            }
            else //This is register for new customer.
            {
                bool bValidFirstName = ValidateFirstName();
                bool bValidLastName = ValidateLastName();
                bool bValidGender = ValidateGender();
                bool bValidHome = ValidateHome();
                bool bValidMobile = ValidateMobile();
                bool bValidAddress = ValidateAddress();
                bool bValidCity = ValidateCity();
                bool bValidState = ValidateState();
                bool bValidZipCode = ValidateZipCode();
                bool bValidEmail = ValidateEmail();
                bool bValidNRIC = ValidateNRIC();
                bool bValidDOB = ValidateDOB();

                if (bValidFirstName && bValidLastName && bValidGender && bValidHome && bValidMobile && bValidAddress && bValidCity && bValidState && bValidZipCode && bValidEmail && bValidNRIC && bValidDOB && registerbutton.Visible == true)
                {
                    try
                    {// Registering process goes here.
                        string tempcustid = customer.NRIC.Substring(6); //This is to extract the inputs starting from 7th position of the array //Reference - https://www.dotnetperls.com/substring
                        customer.CustID = new String(tempcustid.Where(Char.IsDigit).ToArray()); //This is to extract digits only from string //Reference - https://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
                        cmdInsert.CommandText = "Insert Into CustomerData([CustID],[FName],[LName],[Gender],[Home],[Mobile],[Address],[City],[State],[ZipCode],[Email],[NRIC],[DOB]) Values(\'" + customer.CustID
                                                + "\',\'" + customer.FName
                                                + "\',\'" + customer.LName
                                                + "\',\'" + customer.Gender
                                                + "\',\'" + customer.Home    // ----  " + pinmaskedtextbox.Text + " --- For numbers only
                                                + "\',\'" + customer.Mobile    //  ---   \'" + firstnametextBox.Text + "\' --- For text or mix inputs                 
                                                + "\',\'" + customer.Address
                                                + "\',\'" + customer.City
                                                + "\',\'" + customer.State
                                                + "\',\'" + customer.Zipcode
                                                + "\',\'" + customer.Email
                                                + "\',\'" + customer.NRIC
                                                + "\',\'" + customer.DOB //In here i decided to use all as string as i want the leading zero to appear for numbers as well in database.
                                                + "\');"; //Single notation are used for string, but in C#.net it has to be used with \' The two semicolon at the end one is for Database, one is for Visual Studio.
                        cmdInsert.CommandType = CommandType.Text; //After we need to say what type of command it is, which is a text command
                        cmdInsert.Connection = cnnOLEDB; //Next,i gonna pass these commands to the connection.
                        cmdInsert.ExecuteNonQuery(); //Change one row in database and will not return any value.
                        MessageBox.Show("      Register Successful. \n         This is your CustomerID: " + customer.CustID + "\nIt is use as LoginID and many other stuffs :p"); //The profiles of the new user is added into the database.
                        MainMenu done = new MainMenu(customer.AdminID, customer.CustID, customer.Balance);
                        done.Show();
                        this.Hide();
                    }
                    catch
                    {
                        MessageBox.Show("CustomerID already exist.");
                    }
                }
                else if (customer.CustID != "")
                {//Updating information process goes here.
                    string tempcustid = customer.NRIC.Substring(6); //This is to extract the inputs starting from 7th position of the array //Reference - https://www.dotnetperls.com/substring
                    customer.CustID = new String(tempcustid.Where(Char.IsDigit).ToArray()); //This is to extract digits only from string //Reference - https://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
                    cmdUpdate.CommandText = " Update CustomerData Set [FName] = \'" + customer.FName
                        + "\', [LName] = \'" + customer.LName
                        + "\', [Gender] = \'" + customer.Gender
                        + "\', [Home] = \'" + customer.Home
                        + "\', [Address] = \'" + customer.Address
                        + "\', [City] = \'" + customer.City
                        + "\', [State] = \'" + customer.State
                        + "\', [ZipCode] = \'" + customer.Zipcode
                        + "\', [Email] = \'" + customer.Email
                        + "\', [NRIC] = \'" + customer.NRIC
                        + "\', [DOB] = \'" + customer.DOB
                        + "\' Where [CustID] = \'" + customer.CustID + "\';";
                    cmdUpdate.CommandType = CommandType.Text;
                    cmdUpdate.Connection = cnnOLEDB;
                    cmdUpdate.ExecuteNonQuery();
                    cnnOLEDB.Close();
                    MessageBox.Show("Update Successful");
                }
                else
                {
                    MessageBox.Show("Please fill in all the fields.");
                }
            }
        }

        private void firstnametextBox_PreviewKeyDown_1(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)//This means that if the user press the "tab" key.
            {
                e.IsInputKey = true;
                lastnametextBox.Focus();//focus means it will go to the particular box.
            }
        }

        private void firstnametextBox_Validating_1(object sender, CancelEventArgs e)
        {
            //ref = https://www.c-sharpcorner.com/article/using-error-provider-control-in-windows-forms-and-C-Sharp/
            ValidateFirstName();
        }

        private bool ValidateFirstName()
        {
            bool bStatus = true;
            if (firstnametextBox.Text == "")
            {
                firstnameerrorProvider.SetError(firstnametextBox, "Please key in your first name");
                bStatus = false;
            }
            else
            {
                firstnameerrorProvider.Clear();
            }
            return bStatus;
        }

        private void lastnametextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                HomemaskedTextBox.Focus();
            }
        }

        private void lastnametextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateLastName();
        }

        private bool ValidateLastName()
        {
            bool bStatus = true;
            if (lastnametextBox.Text == "")
            {
                lastnameerrorProvider.SetError(lastnametextBox, "Please key in your last name");
                bStatus = false;
            }
            else
            {
                lastnameerrorProvider.Clear();// SetError(lastnametextBox, "");
            }
            return bStatus;
        }

        private void maleradioButton_CheckedChanged(object sender, EventArgs e)
        {
            customer.Gender = "Male";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            customer.Gender = "Female";
        }

        private void othersradioButton_CheckedChanged(object sender, EventArgs e)
        {
            othertextBox.Enabled = true;
            customer.Gender = othertextBox.Text;
        }

        private void gendergroupBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateGender();
        }

        private bool ValidateGender()
        {
            bool bStatus = true;
            if (maleradioButton.Checked == false && femaleradioButton.Checked == false && othersradioButton.Checked == false && othertextBox.Text == "")
            {
                gendererrorProvider.SetError(gendergroupBox, "Please select you gender.");
                bStatus = false;
            }
            else
            {
                gendererrorProvider.Clear();
            }
            return bStatus;
        }

        private void HomemaskedTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                MobilemaskedTextBox.Focus();
            }
        }

        private void HomemaskedTextBox_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateHome();
        }

        private bool ValidateHome()
        {
            bool bStatus = true;
            if (HomemaskedTextBox.MaskCompleted)
            {
                HomeerrorProvider.Clear();// SetError(HomemaskedTextBox, "");
            }
            else
            {
                HomeerrorProvider.SetError(HomemaskedTextBox, "Please key in a valid Home contact no.");
                bStatus = false;
            }
            return bStatus;
        }

        private void MobilemaskedTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                addresstextBox.Focus();
            }
        }

        private void MobilemaskedTextBox_Validating_1(object sender, CancelEventArgs e)
        {
            ValidateMobile();
        }

        private bool ValidateMobile()
        {
            bool bStatus = true;
            if (MobilemaskedTextBox.MaskCompleted) //if the masked textbox is filled completely, then do something... ref: https://stackoverflow.com/questions/17757612/how-to-check-if-a-maskedtextbox-is-empty-from-a-user-input
            {
                mobileerrorProvider.Clear();// SetError(MobilemaskedTextBox, "");
            }
            else
            {
                mobileerrorProvider.SetError(MobilemaskedTextBox, "Please key in a valid Mobile contact no.");
                bStatus = false;
            }
            return bStatus;
        }

        private void addresstextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                citytextBox.Focus();
            }
        }

        private void addresstextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateAddress();
        }

        private bool ValidateAddress()
        {
            bool bStatus = true;
            if (addresstextBox.Text == "")
            {
                addresserrorProvider.SetError(addresstextBox, "Please key in your Address.");
                bStatus = false;
            }
            else
            {
                addresserrorProvider.Clear();// SetError(addresstextBox, "");
            }
            return bStatus;
        }

        private void citytextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                statetextBox.Focus();
            }
        }

        private void citytextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateCity();
        }

        private bool ValidateCity()
        {
            bool bStatus = true;
            if (citytextBox.Text == "")
            {
                cityerrorProvider.SetError(citytextBox, "Please key in your City.");
                bStatus = false;
            }
            else
            {
                cityerrorProvider.Clear();//SetError(citytextBox, "");
            }
            return bStatus;
        }

        private void statetextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                zipcodemaskedtextbox.Focus();
            }
        }

        private void statetextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateState();
        }

        private bool ValidateState()
        {
            bool bStatus = true;
            if (statetextBox.Text == "")
            {
                stateerrorProvider.SetError(statetextBox, "Please key in your State.");
                bStatus = false;
            }
            else
            {
                stateerrorProvider.Clear();
            }
            return bStatus;
        }

        private void zipcodemaskedtextbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                emailtextBox.Focus();
            }
        }

        private void zipcodemaskedtextbox_Validating(object sender, CancelEventArgs e)
        {
            ValidateZipCode();
        }

        private bool ValidateZipCode()
        {
            bool bStatus = true;
            if (zipcodemaskedtextbox.MaskCompleted)
            {
                zipcodeerrorProvider.Clear();
            }
            else
            {
                zipcodeerrorProvider.SetError(zipcodemaskedtextbox, "Please key in your ZipCode.");
                bStatus = false;
            }
            return bStatus;
        }

        private void emailtextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                nricmaskedTextBox.Focus();
            }
        }

        private void emailtextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateEmail();
        }

        private bool ValidateEmail()
        {
            bool bStatus = true;
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; //Standard email format that includes @ and .
            if (Regex.IsMatch(emailtextBox.Text, pattern))//If it matches the format which includes @ and .
            {
                emailerrorProvider.Clear();//This is to clear the message in error icon.
            }
            else
            {
                emailerrorProvider.SetError(emailtextBox, "Please fill in a valid email address."); //This shows the error message when user mouse over the error icon.
                bStatus = false;
            }
            return bStatus;
        }

        private void nricmaskedTextBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                dobdateTimePicker.Focus();
            }
        }

        private void nricmaskedTextBox_Validating(object sender, CancelEventArgs e)
        {
            ValidateNRIC();
        }

        private bool ValidateNRIC()
        {
            bool bStatus = true;
            if ( nricmaskedTextBox.MaskCompleted ) //if the masked textbox is filled completely, then do something... ref: https://stackoverflow.com/questions/17757612/how-to-check-if-a-maskedtextbox-is-empty-from-a-user-input
            {
                nricerrorProvider.Clear();//SetError(nricmaskedTextBox, "");
            }
            else
            {
                nricerrorProvider.SetError(nricmaskedTextBox, "Please key in your NRIC.");
                bStatus = false;
            }
            return bStatus;
        }

        private void usernametextbox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                dobdateTimePicker.Focus();
            }
        }

        private void dobdateTimePicker_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                firstnametextBox.Focus();
            }
        }

        private void dobdateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            ValidateDOB();
        }

        private void dobdateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            dobdateTimePicker.Format = DateTimePickerFormat.Short; //https://stackoverflow.com/questions/846395/how-can-i-make-a-datetimepicker-display-an-empty-string
        }

        private bool ValidateDOB()
        {
            bool bStatus = true;
            if (dobdateTimePicker.Format == DateTimePickerFormat.Short)
            {
                doberrorProvider.Clear();
            }
            else
            {
                doberrorProvider.SetError(dobdateTimePicker, "Please select your DOB.");
                bStatus = false;
            }
            return bStatus;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            CustomerHome back = new CustomerHome(customer.AdminID, customer.CustID, customer.Balance);
            back.Show();
            this.Hide();
        }

        private void registerbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                resetbutton.Focus();
            }
        }

        private void savebutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                resetbutton.Focus();
            }
        }

        private void backbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                exitbutton.Focus();
            }
        }

        private void resetbutton_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                e.IsInputKey = true;
                backbutton.Focus();
            }
        }

        private void resetbutton_Click(object sender, EventArgs e)
        {
            firstnametextBox.Clear();
            lastnametextBox.Clear();
            maleradioButton.Checked = false;
            femaleradioButton.Checked = false;
            othersradioButton.Checked = false;
            othertextBox.Clear();
            othertextBox.Enabled = false;
            HomemaskedTextBox.Clear();
            MobilemaskedTextBox.Clear();
            addresstextBox.Clear();
            citytextBox.Clear();
            statetextBox.Clear();
            zipcodemaskedtextbox.Clear();
            emailtextBox.Clear();
            if (customer.CustID == "")
            {
                nricmaskedTextBox.Clear();
            }
            dobdateTimePicker.CustomFormat = " ";
            dobdateTimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void DateTimetimer_Tick(object sender, EventArgs e)
        {
            this.datetimelabel.Text = DateTime.Now.ToString();
            this.datetimelabel.Show();
        }

        private void CustomerDetails_Shown(object sender, EventArgs e)
        {
            firstnametextBox.Focus();
        }

        private void exitbutton_Click_1(object sender, EventArgs e)
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
                cmdDerive.CommandText = "Select * From CustomerData Where CustID = \'" + f.quickcustidmaskedTextBox.Text + "\' ;";
                cmdDerive.Connection = cnnOLEDB;
                OleDbDataReader dr = cmdDerive.ExecuteReader(); //It will go to the database and read column by column. However, it will not read by itself. Hence, while statement is required to force it to read it.
                if (dr.Read() == true)
                {
                    customer.CustID = dr[0].ToString();
                    customer.FName = dr[1].ToString(); //ref: https://social.msdn.microsoft.com/Forums/vstudio/en-US/387afc74-d920-4cbd-858d-261ad7932899/accessing-textbox-on-another-form?forum=vbgeneral
                    MessageBox.Show("  Login successful!\n Welcome," + customer.FName + "!");
                    f.Dispose();
                    dr.Close();
                    CustomerDetails refresh = new CustomerDetails(customer.AdminID, customer.CustID, customer.Balance, customer.Save);
                    refresh.Show();
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
    }
}

/*References: https://syntaxdb.com/ref/csharp
              https://stackoverflow.com/questions/846395/how-can-i-make-a-datetimepicker-display-an-empty-string
              https://stackoverflow.com/questions/17757612/how-to-check-if-a-maskedtextbox-is-empty-from-a-user-input
              https://www.c-sharpcorner.com/article/using-error-provider-control-in-windows-forms-and-C-Sharp/
              https://stackoverflow.com/questions/4734116/find-and-extract-a-number-from-a-string
              https://www.dotnetperls.com/substring
              https://www.codeproject.com/Questions/329879/Datetime-picker-control-to-be-blank-when-the-form
    */
