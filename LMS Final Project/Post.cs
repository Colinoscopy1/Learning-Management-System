using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class Post : UserControl
    {
        int assignment;
        public Post(string title, string body, int isAssignment, DateTime dueDate, string classNumber)
        {
            InitializeComponent();
            lblTitle.Text = title;
            lblBody.Text = body;
            lblDueDate.Text = dueDate.ToShortDateString();
            lblClass.Text = classNumber;
            this.assignment = isAssignment;

            if (assignment == 1)
                lblDueDate.Visible = true;
            else if (assignment == 0)
                lblDueDate.Visible = false;
        }

       
    }
}
