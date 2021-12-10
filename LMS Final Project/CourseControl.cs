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

            List<Course> crslist = dl.GetEnrolledClasses(home.studentID);

            if (crslist.Count >= 4)
            {
                btnRegister.Enabled = false;
            }

            List<Course> enrolled = dl.GetEnrolledClasses(home.studentID);

            if (enrolled.Count >= 6)
            {
                btnClassEnroll.Visible = false;
            }
            else if (enrolled.Count > 0)
            {
                btnClassEnroll.Visible = true;
            }
            else
            {
                btnClassEnroll.Visible = false;
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            foreach (Course tmp in this.programs.GetCourses())
            {
                dl.AddStudentToClass(tmp.GetCourseId(), home.studentID);
            }

            lstCourses.DataSource = dl.GetCourseByProgram(programs.GetID());

            List<Course> crslist = dl.GetEnrolledClasses(home.studentID);

            if (crslist.Count >= 4)
            {
                btnRegister.Enabled = false;
            }
        }

        private void btnClassEnroll_Click(object sender, EventArgs e)
        {
            
            Course crs = (Course)lstCourses.SelectedItem;

            dl.AddStudentToClass(crs.GetCourseId(), home.studentID);
            MessageBox.Show("Class Enrollment Successful");
        }

        private void lstCourses_SelectedIndexChanged(object sender, EventArgs e)
        {
            Course crs = (Course)lstCourses.SelectedItem;

            string instructor = dl.GetEmployeeNamebyID(crs.GetCourseInstructorID());

            lblBuilding.Text = crs.GetCourseBuilding();
            lblClassName.Text = crs.GetCourseName();
            lblClassNum.Text = crs.GetCourseId();
            lblInst.Text = instructor;
            lblProgram.Text = crs.GetCourseProgram().ToString();
            lblRoom.Text = crs.GetCourseRoom();

            List<Course> enrolled = dl.GetEnrolledClasses(home.studentID);

            if (enrolled.Count >= 6)
            {
                btnClassEnroll.Visible = false;
            }
            else if (enrolled.Count > 0)
            {
                btnClassEnroll.Visible = true;
            }
            else
            {
                btnClassEnroll.Visible = false;
            }
        }
    }
}
