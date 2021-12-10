using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class InstructorHandIns : UserControl
    {
        DataLayer d;
        List<string[]> handins;
        HandIn hand;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public InstructorHandIns(Course course)
        {
            InitializeComponent();
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            d = new DataLayer(connectionString);

            handins = d.GetUngradedHandins(course.GetCourseId());

            foreach(string[] array in handins)
            {
                HandIn tmp = new HandIn(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), array[2], array[3], array[4]);
                lstPosts.Items.Add(tmp);
            }

            if (lstPosts.SelectedItem != null)
            {
                hand = (HandIn)lstPosts.SelectedItem;
                lblDetails.Visible = true;
                btnFile.Visible = true;
                btnGrade.Visible = true;
                label2.Visible = true;
                txtGrade.Visible = true;
                lblDetails.Text = "Submitted by " + hand.studentName + " on " + hand.submittedDate;
            }
            else
            {
                lblDetails.Visible = false;
                btnFile.Visible = false;
                btnGrade.Visible = false;
                label2.Visible = false;
                txtGrade.Visible = false;
            }
        }

        private void lstPosts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPosts.SelectedItem != null)
            {
                hand = (HandIn)lstPosts.SelectedItem;
                lblDetails.Visible = true;
                btnFile.Visible = true;
                btnGrade.Visible = true;
                label2.Visible = true;
                txtGrade.Visible = true;
                lblDetails.Text = "Submitted by " + hand.studentName + " on " + hand.submittedDate;
            }
            else
            {
                lblDetails.Visible = false;
                btnFile.Visible = false;
                btnGrade.Visible = false;
                label2.Visible = false;
                txtGrade.Visible = false;
            }
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            if (lstPosts.SelectedItem != null)
            {
                try
                {
                    string filepath = Environment.CurrentDirectory + hand.filePath;
                    string filename = hand.filePath.Split("\\").LastOrDefault();
                    SaveFileDialog save = new SaveFileDialog();
                    save.FileName = filename;
                    save.ShowDialog();
                    File.Copy(filepath, save.FileName);
                    Process.Start("explorer.exe", save.FileName);
                }
                catch
                {

                }
            }
            else
            {
                MessageBox.Show("Please select a handin");
            }
            
        }

        private void btnGrade_Click(object sender, EventArgs e)
        {
            if (txtGrade.Text != null)
            {
                try
                {
                    int grade = Convert.ToInt32(txtGrade.Text);
                    d.GradeHandIn(hand.postID, hand.studentID, grade, DateTime.Now);
                }
                catch
                {
                    MessageBox.Show("Please enter a valid integer for grade");
                }
            }
        }
    }
}
