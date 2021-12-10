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

        Course course;

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
            flowMain.Controls.Clear();
            lstContainer.DataSource = d.GetClassesbyInstructor(employeeID);
        }

        private void lstContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (datasource == "Class Roster")
            {
                flowMain.Controls.Clear();
                btnAddPost.Visible = false;
                Course crs = (Course)lstContainer.SelectedItem;
                InstructorRoster inst = new InstructorRoster(crs);
                flowMain.Controls.Add(inst);
            }
            else if (datasource == "Hand Ins")
            {
                flowMain.Controls.Clear();
                btnAddPost.Visible = false;
                Course crs = (Course)lstContainer.SelectedItem;
                InstructorHandIns handins = new InstructorHandIns(crs);
                flowMain.Controls.Add(handins);
            }
            else if(datasource == "Posts")
            {
                flowMain.Controls.Clear();
                btnAddPost.Visible = true;
                Course crs = (Course)lstContainer.SelectedItem;
                foreach (Post post in d.GetPostsbyClass(crs.GetCourseId()))
                {
                    flowMain.Controls.Add(post);
                }
                
            }
        }

        private void btnHandin_Click(object sender, EventArgs e)
        {
            datasource = "Hand Ins";
            btnClassRoster.Enabled = true;
            lstContainer.DataSource = d.GetClassesbyInstructor(employeeID);
        }

        private void btnPosts_Click(object sender, EventArgs e)
        {
            datasource = "Posts";
            btnClassRoster.Enabled = true;
            lstContainer.DataSource = d.GetClassesbyInstructor(employeeID);
        }

        private void btnAddPost_Click(object sender, EventArgs e)
        {
            Course course = (Course)lstContainer.SelectedItem;
            CreatePost post = new CreatePost(course);
            post.ShowDialog();
        }
    }
}
