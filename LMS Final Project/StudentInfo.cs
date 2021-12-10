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
    public partial class StudentInfo : UserControl
    {
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        string approved;
        string probation;

        DataLayer dl;

        Student student;

        public StudentInfo(Student student)
        {
            InitializeComponent();
            this.student = student;
            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            dl = new DataLayer(connectionString);

            if (student.is_Approved == false)
                approved = "Not Approved";
            else if (student.is_Approved == true)
                approved = "Approved";

            if (student.Academic_Probation == true)
                probation = "On Probation";
            else if (student.Academic_Probation == false)
                probation = "Not on Probation";

            lblApproval.Text = approved;
            lblEmail.Text = student.email;
            lblFirstName.Text = student.FName + " " + student.LName;
            lblPhone.Text = student.phone;
            lblProbation.Text = probation;

            lstClasses.DataSource = dl.GetEnrolledClasses(student.studentID);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dl.RemoveStudentEntirely(student);
        }

        private void btnProbation_Click(object sender, EventArgs e)
        {
            dl.PlaceStudentOnProbation(student);

            if (lblProbation.Text == "On Probation")
            {
                lblProbation.Text = "Not on Probation";
                student.Academic_Probation = false;
            }
            else
            {
                lblProbation.Text = "On Probation";
                student.Academic_Probation = true;
            }
            
            lstClasses.DataSource = dl.GetEnrolledClasses(student.studentID);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            
            if(student.is_Approved == false)
                dl.ApprovePendingStudent(student.studentID);
            else
                MessageBox.Show("Student is Already Approved");

            if(lblApproval.Text == "Not Approved")
            {
                lblApproval.Text = "Approved";
                student.is_Approved = true;
            }

            lblApproval.Refresh();

            

            lstClasses.DataSource = dl.GetEnrolledClasses(student.studentID);
        }

        private void btnRemoveFromClass_Click(object sender, EventArgs e)
        {
            Course course = (Course)lstClasses.SelectedItem;
            dl.RemoveStudentFromClass(student.studentID, course);
            lstClasses.DataSource = dl.GetEnrolledClasses(student.studentID);
        }
    }
}
