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
    public partial class StudentHome : Form
    {
        public string userName;
        public int studentID;
        DataLayer d;
        List<SchoolProgram> programs;
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public StudentHome(string username)
        {
            InitializeComponent();
            userName = username;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            d = new DataLayer(connectionString);
            studentID = d.GetStudentIdbyUsername(userName);
            string studentName = d.GetStudentNamebyID(studentID);

            lblWelcome.Text = "Welcome, " + studentName + "!";
        }

        private void btnRegProg_Click(object sender, EventArgs e)
        {
            //run a query to populate flowside with a list of items from programs table, clicking on one generates a list of classes in flowmain
            programs = d.GetPrograms();
            lstContainer.DataSource = programs;
            
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstContainer.DataSource == programs)
            {
                flowMain.Controls.Clear();
                CourseControl crs = new CourseControl(this, (SchoolProgram)lstContainer.SelectedItem);
                flowMain.Controls.Add(crs);
            }

        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            lstContainer.DataSource = null;


            lstContainer.DataSource = d.GetEnrolledClasses(this.studentID);
        }
    }
}
