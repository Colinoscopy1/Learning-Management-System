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
            List<string> characters = new List<string>();
            string username = "";

            if (txtFname.Text.Length > 12)
            {
                for (int i = 0; i < 12; i++)
                {
                    username += txtFname.Text.Split()[i];
                }
            }
            else
            {
                username += txtFname.Text;
            }

            username += ".";

            if (txtLname.Text.Length > 13)
            {
                for (int i = 0; i < 13; i++)
                {
                    username += txtLname.Text.Split()[i];
                }
            }
            else
            {
                username += txtLname.Text;
            }

            d.CreateStudentAccount(studentID, username, password);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
