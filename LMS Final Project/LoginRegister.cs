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
        public LoginRegister(string type)
        {
            InitializeComponent();

            this.Text = type;
            btnGo.Text = type;

            if (type == "Login")
            {
                lblConfirmPass.Visible = false;
                txtConfirmPass.Visible = false;
            }
        }
    }
}
