using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class RegisterEmployee : Form
    {
        string firstName;
        string lastName;
        string email;
        string officeNumber;
        string phone;
        string password;
        bool admin = false;

        DataLayer d;

        public RegisterEmployee()
        {
            InitializeComponent();
            string serverAddress = ConfigurationManager.AppSettings.Get("server");
            string databaseName = ConfigurationManager.AppSettings.Get("database");
            string userID = ConfigurationManager.AppSettings.Get("username");
            string password = ConfigurationManager.AppSettings.Get("password");

            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            this.d = new DataLayer(connectionString);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match, try again");
                txtPass.Clear();
                txtConfirmPass.Clear();
            }
            else
            {
                this.firstName = txtFname.Text.Trim();
                this.lastName = txtLname.Text.Trim();
                this.email = txtEmail.Text.Trim();
                this.officeNumber = txtOfficeNumber.Text.Trim();
                this.phone = txtPhone.Text.Trim();
                this.password = txtPass.Text.Trim();
            }

            try
            {
                d.CreateEmployee(firstName, lastName, email, officeNumber, phone);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string username = "";
            int employeeID = d.GetEmployeeIDbyEmail(email);

            if (txtFname.Text.Length > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    username += firstName.ToCharArray()[i];
                }
            }
            else
            {
                username += firstName;
            }

            username += ".";

            if (txtLname.Text.Length > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    username += lastName.ToCharArray()[i];
                }
            }
            else
            {
                username += lastName;
            }

            int adminBit = 0;
            if (admin == true)
                adminBit = 1;
            else if (admin == false)
                adminBit = 0;

            d.CreateEmployeeAccount(username, password, employeeID, adminBit);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (admin == false)
                admin = true;
            else if (admin == true)
                admin = false;


        }
    }
}
