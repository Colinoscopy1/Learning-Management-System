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
    public partial class AdminHome : Form
    {
        public string userName;
        public int employeeID;
        DataLayer d;
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public AdminHome(string username)
        {
            InitializeComponent();
            userName = username;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            d = new DataLayer(connectionString);
            employeeID = d.GetEmployeeIDbyUsername(userName);
            string employeeName = d.GetStudentNamebyID(employeeID);

            lblWelcome.Text = "Welcome, " + employeeName + "!";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
