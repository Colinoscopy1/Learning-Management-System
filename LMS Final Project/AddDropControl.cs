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
    public partial class AddDropControl : UserControl
    {
        StudentHome previousForm;
        DataLayer d;
        Course tmp;
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public AddDropControl(StudentHome prev, Course selected)
        {
            InitializeComponent();
            previousForm = prev;
            tmp = selected;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            d = new DataLayer(connectionString);

            lstEnrolled.DataSource = d.GetEnrolledClasses(previousForm.studentID);
            if (lstEnrolled.Items.Count >= 6)
            {
                btnAdd.Visible = false;
            }
            else if (lstEnrolled.Items.Count > 0)
            {
                btnDrop.Visible = true;
            }
            else
            {
                btnDrop.Visible = false;
            }

            lblClassName.Text = tmp.GetCourseName();
            lblClassNum.Text = tmp.GetCourseId();
            lblInst.Text = d.GetEmployeeNamebyID(tmp.GetCourseInstructorID());
            lblBuilding.Text = tmp.GetCourseBuilding();
            lblRoom.Text = tmp.GetCourseRoom();
            lblProgram.Text = d.GetProgNamebyID(tmp.GetCourseProgram());

            Course crs = (Course)lstEnrolled.SelectedItem;
            string grade = d.GetFinalGradebyStudentID(previousForm.studentID, crs.GetCourseId());

            if (grade != "" && grade != "W")
                btnDrop.Enabled = false;
            else
                btnDrop.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            d.AddStudentToClass(tmp.GetCourseId(), previousForm.studentID);
            lstEnrolled.DataSource = null;
            lstEnrolled.DataSource = d.GetEnrolledClasses(previousForm.studentID);
        }

        private void btnDrop_Click(object sender, EventArgs e)
        {
            Course crs = (Course)lstEnrolled.SelectedItem;
            d.RemoveStudentFromClass(previousForm.studentID, crs);
            lstEnrolled.DataSource = null;
            lstEnrolled.DataSource = d.GetEnrolledClasses(previousForm.studentID);
        }

        private void lstEnrolled_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstEnrolled.SelectedItem != null)
            {
                Course crs = (Course)lstEnrolled.SelectedItem;
                string grade = d.GetFinalGradebyStudentID(previousForm.studentID, crs.GetCourseId());

                if (grade != "" && grade != "W")
                    btnDrop.Enabled = false;
                else
                    btnDrop.Enabled = true;
            }
        }
    }
}
