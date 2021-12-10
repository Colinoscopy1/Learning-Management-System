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
    public partial class StudentGradesControl : UserControl
    {
        StudentHome home;
        Course thiscourse;
        string connectionString;
        DataLayer d;
        List<string> handIns;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        public StudentGradesControl(StudentHome prev, Course crs)
        {
            InitializeComponent();
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            d = new DataLayer(connectionString);
            thiscourse = crs;
            home = prev;

            handIns = d.GetGradedHandins(home.studentID, thiscourse.GetCourseId());

            foreach(string item in handIns)
            {
                lstPosts.Items.Add(item.Split("|")[0] + ": " + item.Split("|")[1]);
            }

            string grade = d.GetFinalGradebyStudentID(home.studentID, thiscourse.GetCourseId());

            if (grade == "")
            {
                lblFinal.Visible = false;
                lblFinalGrade.Visible = false;
            }

            else
            {
                lblFinal.Visible = true;
                lblFinalGrade.Visible = true;
                lblFinalGrade.Text = grade;
            }

            if (lstPosts.SelectedItem != null)
            {
                lblPostName.Visible = true;
                lblHIGrade.Visible = true;
                lblPostName.Text = "Your Grade For " + lstPosts.SelectedItem.ToString().Split(": ")[1];
                lblHIGrade.Text = d.GetHandInGradeByPostID(Convert.ToInt32(lstPosts.SelectedItem.ToString().Split(": ")[0]), home.studentID).ToString();
            }
            else
            {
                lblPostName.Visible = false;
                lblHIGrade.Visible = false;
            }
        }

        private void lstPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPosts.SelectedItem != null)
            {
                lblPostName.Visible = true;
                lblHIGrade.Visible = true;
                lblPostName.Text = "Your Grade For " + lstPosts.SelectedItem.ToString().Split(": ")[1];
                lblHIGrade.Text = d.GetHandInGradeByPostID(Convert.ToInt32(lstPosts.SelectedItem.ToString().Split(": ")[0]), home.studentID).ToString();
            }
            else
            {
                lblPostName.Visible = false;
                lblHIGrade.Visible = false;
            }
        }
    }
}
