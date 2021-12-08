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
    public partial class CourseControl : UserControl
    {
        StudentHome home;
        SchoolProgram programs;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        DataLayer dl;

        public CourseControl(StudentHome tmp, SchoolProgram prgrm)
        {
            InitializeComponent();
            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            dl = new DataLayer(connectionString);
            this.programs = prgrm;
            
            this.home = tmp;
            lstCourses.DataSource = dl.GetCourseByProgram(prgrm.GetID()); 

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            foreach (Course tmp in this.programs.GetCourses())
            {
                dl.AddStudentToClass(tmp.GetCourseId(), home.studentID);
            }
        }
    }
}
