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
    public partial class LoginRegister : Form
    {
        int loginType;
        string connectionString;
        string username;
        string userPassword;
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        public LoginRegister(int type)
        {
            InitializeComponent();

            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            this.loginType = type;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            username = txtUsername.Text;
            userPassword = txtPassword.Text;

            DataLayer d = new DataLayer(connectionString);
            //if the account is an employee
            if (this.loginType == 1)
            {
                //put the method(s) for employee query here
                if (d.EmployeeLogin(username, userPassword))
                {
                    if (d.CheckAdminStatus(username, userPassword))
                    {
                        //launch admin home form
                        AdminHome home = new AdminHome(username);
                        this.Hide();
                        home.ShowDialog();
                    }
                    else
                    {
                        //launch instructor home form
                        InstructorHome home = new InstructorHome(username);
                        this.Hide();
                        home.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect.");
                }
            }
            //if the account is a student
            else
            {
                //put the method(s) for student query here
                if (d.CheckStudentApproval(username, userPassword))
                {
                    if (d.StudentLogin(username, userPassword))
                    {
                        //launch student home form
                        StudentHome home = new StudentHome(username);
                        this.Hide();
                        home.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Username or password is incorrect.");
                    }
                }
                else
                {
                    MessageBox.Show("Your account has not been approved yet. Please check back later.");
                }
            }
        }
    }
}
