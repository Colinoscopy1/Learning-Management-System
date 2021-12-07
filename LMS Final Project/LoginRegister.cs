using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class LoginRegister : Form
    {
        int loginType;

        public LoginRegister(int type)
        {
            InitializeComponent();

            btnGo.Text = "Login";
            this.loginType = type;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            //if the account is an employee
            if (this.loginType == 1)
            {
                //put the method(s) for employee query here
            }
            //if the account is a student
            else
            {
                //put the method(s) for student query here
            }
        }
    }
}
