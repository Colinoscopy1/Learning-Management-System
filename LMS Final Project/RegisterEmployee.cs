﻿using System;
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
                this.firstName = txtFname.Text;
                this.lastName = txtLname.Text;
                this.email = txtEmail.Text;
                this.phone = txtPhone.Text;
                this.password = txtPass.Text;
            }

            try
            {
                d.CreateEmployee(firstName, lastName, email, officeNumber, phone);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
