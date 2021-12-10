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
    public partial class AdminHome : Form
    {
        public string userName;
        public int employeeID;
        string datasource = "";
        string employee = "";
        
        DataLayer d;
        List<Student> stdnt;
        List<Employee> emply;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;

        public AdminHome(string username)
        {
            InitializeComponent();
            userName = username;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            d = new DataLayer(connectionString);
            employeeID = d.GetEmployeeIDbyUsername(userName);
            string employeeName = d.GetEmployeeNamebyID(employeeID);

            lblWelcome.Text = "Welcome, " + employeeName + "!";
        }

      

        private void btnStudents_Click(object sender, EventArgs e)
        {
            datasource = "Students";
            stdnt = d.GetAllStudents();

            lstContainer.DataSource = stdnt;

        }

        private void btnEmployees_Click(object sender, EventArgs e)
        {
            datasource = "Employees";
            emply = d.GetAllEmployees();

            lstContainer.DataSource = emply;
        }

        private void lstContainer_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            if (datasource == "Employees")
            {
                createEmployee.Controls.Clear();
                EmployeeInfo emi = new EmployeeInfo((Employee)lstContainer.SelectedItem);
                createEmployee.Controls.Add(emi);
                employee = lstContainer.SelectedItem.ToString();
            }
            else if (datasource == "Students")
            {
                createEmployee.Controls.Clear();
                StudentInfo stdnti = new StudentInfo((Student)lstContainer.SelectedItem);
                createEmployee.Controls.Add(stdnti);
            }
            else
            {
                createEmployee.Controls.Clear();
            }
           

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterEmployee rgstr = new RegisterEmployee();
            rgstr.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            string tmp = datasource;

            datasource = "";
            
            lstContainer.DataSource = null;

            if (tmp == "Employees")
            {
                emply = d.GetAllEmployees();
                lstContainer.DataSource = emply;
            }
            else
            {
                stdnt = d.GetAllStudents();
                lstContainer.DataSource = stdnt;
            }
        }
    }
}
