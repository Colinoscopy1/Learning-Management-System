using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS_Final_Project
{
    public partial class RegisterStudent : Form
    {
        string firstName;
        string lastName;
        string email;
        string phone;
        string password;

        DataLayer d;

        public RegisterStudent()
        {
            InitializeComponent();
            string serverAddress = ConfigurationManager.AppSettings.Get("server");
            string databaseName = ConfigurationManager.AppSettings.Get("database");
            string userID = ConfigurationManager.AppSettings.Get("username");
            string password = ConfigurationManager.AppSettings.Get("password");

            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            this.d = new DataLayer(connectionString);
        }

        private void txtLname_Leave(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtPass.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Passwords do not match, try again");
                txtPass.Clear();
                txtConfirmPass.Clear();
            }
            else
            {
                this.firstName = txtFname.Text;
                this.lastName = txtLname.Text;
                this.email = txtEmail.Text;
                this.phone = txtPhone.Text;
                this.password = txtPass.Text;
            }

            try
            {
                d.CreateStudent(firstName, lastName, email, phone);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            int studentID = d.GetStudentIdbyEmail(email);
            string username = "";

            if (txtFname.Text.Length > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    username += txtFname.Text.Trim().ToCharArray()[i];
                }
            }
            else
            {
                username += txtFname.Text.Trim();
            }

            username += ".";

            if (txtLname.Text.Length > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    username += txtLname.Text.Trim().ToCharArray()[i];
                }
            }
            else
            {
                username += txtLname.Text.Trim();
            }

            d.CreateStudentAccount(studentID, username, password);

            string tmp = d.GetStudentUsernameByEmail(email);

            MessageBox.Show("Your username is: " + tmp);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
