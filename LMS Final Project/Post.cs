using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public Post(int id, string title, string body, int isAssignment, DateTime dueDate, string classNumber)
        {
            InitializeComponent();
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
            StudentHome parent = (this.Parent as StudentHome);

            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            File.Copy(op.FileName, Environment.CurrentDirectory + "\\Upload\\" + op.FileName.Split("\\").LastOrDefault());
            string filePath = "\\Upload\\" + op.FileName.Split("\\").LastOrDefault();

            d.CreateHandIn(this.id, parent.studentID, filePath, DateTime.Now);

            //SendHandin(this.id, filePath);
        }

        private void lblDueDate_Click(object sender, EventArgs e)
        {

        }
    }
}
