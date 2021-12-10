using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class Post : UserControl
    {
        int assignment;
        int id;
        DataLayer d;
        public delegate void CreateHandin(int postID, string filePath);
        public CreateHandin SendHandin;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public Post(int id, string title, string body, int isAssignment, DateTime dueDate, string classNumber)
        {
            InitializeComponent();
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            d = new DataLayer(connectionString);

            lblTitle.Text = title;
            lblBody.Text = body;
            lblDueDate.Text = dueDate.ToShortDateString();
            lblClass.Text = classNumber;
            this.assignment = isAssignment;
            this.id = id;

            if (assignment == 1)
            {
                lblDueDate.Visible = true;
                btnHandin.Visible = true;
            }
            else if (assignment == 0)
            {
                lblDueDate.Visible = false;
                btnHandin.Visible = false;
            }
        }

        public Post(int id, string title, string body, int isAssignment, string classNumber)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblBody.Text = body;
            lblClass.Text = classNumber;
            this.assignment = isAssignment;

            if (assignment == 1)
            {
                lblDueDate.Visible = true;
                btnHandin.Visible = true;
            }
            else if (assignment == 0)
            {
                lblDueDate.Visible = false;
                btnHandin.Visible = false;
            }
        }

        private void btnHandin_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel panel = (this.Parent as FlowLayoutPanel);
            StudentHome parent = (panel.Parent as StudentHome);

            try
            {
                OpenFileDialog op = new OpenFileDialog();
                op.ShowDialog();
                File.Copy(op.FileName, Environment.CurrentDirectory + "\\Upload\\" + op.FileName.Split("\\").LastOrDefault());
                string filePath = "\\Upload\\" + op.FileName.Split("\\").LastOrDefault();

                d.CreateHandIn(this.id, parent.studentID, filePath, DateTime.Now);
            }
            catch
            {
                MessageBox.Show("File already exists, please rename file.");
            }
            
        }

        private void lblDueDate_Click(object sender, EventArgs e)
        {

        }
    }
}
