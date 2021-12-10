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
    public partial class InstructorHome : Form
    {
        public string userName;
        public int employeeID;
        DataLayer d;
        string datasource = "";

        List<Student> student;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public InstructorHome(string username)
        {
            InitializeComponent();
            userName = username;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            d = new DataLayer(connectionString);
            employeeID = d.GetEmployeeIDbyUsername(userName);
            string employeeName = d.GetEmployeeNamebyID(employeeID);

            lblWelcome.Text = "Welcome, " + employeeName + "!";
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClassRoster_Click(object sender, EventArgs e)
        {
            datasource = "Class Roster";
            lstContainer.DataSource = null;
            lstContainer.DataSource = d.GetClassesbyInstructor(employeeID);
        }

        private void lstContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course crs = (Course)lstContainer.SelectedItem;
            InstructorRoster inst = new InstructorRoster(crs);
            flowMain.Controls.Add(inst);
        }
    }
}
