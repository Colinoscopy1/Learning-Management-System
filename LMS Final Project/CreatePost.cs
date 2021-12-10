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
    public partial class CreatePost : Form
    {
        string Title;
        string Body;
        DateTime dueDate;
        int Assignment;
        string ClassID;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        DataLayer dl;

        Course course;


        public CreatePost(Course course)
        {
            InitializeComponent();
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            dl = new DataLayer(connectionString);
            this.course = course;
            lblClass.Text = course.GetCourseName();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Title = txtTitle.Text;
            Body = txtBody.Text;
            dueDate = dtpDueDate.Value;
            ClassID = lblClass.Text;

            if (cmbType.Text == "Assignment")
                Assignment = 1;
            else
                Assignment = 0;

            if (cmbType.Text == "Assignment" || cmbType.Text == "Post")
            {
                dl.CreatePost(Title, Body, Assignment, dueDate, course.GetCourseId());
                this.Close();
            }
            else
            {
                MessageBox.Show("Please Specify a Type");
                return;
            }
        }
    }
}
