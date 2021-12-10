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
        private string datasource = "";
       
        DataLayer d;
        List<SchoolProgram> programs;
        List<Course> classes;
        List<Course> allClasses;


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
            datasource = "programs";
            
            programs = d.GetPrograms();
            lstContainer.DataSource = programs;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (datasource == "programs")
            {
                flowMain.Controls.Clear();
                CourseControl crs = new CourseControl(this, (SchoolProgram)lstContainer.SelectedItem);
                flowMain.Controls.Add(crs);
            }
            else if(datasource == "classes")
            {
                flowMain.Controls.Clear();
                //ClassInfo clsi = new ClassInfo();
                Course tmp = (Course)lstContainer.SelectedItem;
                string classnum = tmp.GetCourseId();
                List<Post> posts = d.GetPostsbyClass(classnum);
                foreach (Post pst in posts)
                {
                    flowMain.Controls.Add(pst);
                }
            }
            else if(datasource == "allClasses")
            {
                flowMain.Controls.Clear();
                Course tmp = (Course)lstContainer.SelectedItem;
                AddDropControl add = new AddDropControl(this, tmp);
                flowMain.Controls.Add(add);
            }
            else if(datasource == "grades")
            {
                flowMain.Controls.Clear();
                Course tmp = (Course)lstContainer.SelectedItem;
                StudentGradesControl grade = new StudentGradesControl(this, tmp);
                flowMain.Controls.Add(grade);
            }
            
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            datasource = "allClasses";
            
            flowMain.Controls.Clear();
            allClasses = d.GetAllClasses();
            lstContainer.DataSource = allClasses;
        }

        private void btnYourClasses_Click(object sender, EventArgs e)
        {
            datasource = "classes";
            
            classes = d.GetEnrolledClasses(this.studentID);
            flowMain.Controls.Clear();
            lstContainer.DataSource = classes;

        }

        private void btnGrades_Click(object sender, EventArgs e)
        {
            datasource = "grades";

            classes = d.GetEnrolledClasses(this.studentID);
            flowMain.Controls.Clear();
            lstContainer.DataSource = classes;
        }
    }
}
