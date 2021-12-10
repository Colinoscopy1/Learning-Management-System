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
    public partial class EmployeeInfo : UserControl
    {
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        DataLayer dl;

        Employee employee;

        public EmployeeInfo(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            dl = new DataLayer(connectionString);

            lblEmail.Text = employee.email;
            lblEmployeeID.Text = employee.employeeID.ToString();
            lblFirstName.Text = employee.FName + " " + employee.LName;
            lblOfficeNumber.Text = employee.officeNumber;
            lblPhone.Text = employee.phone;

            lstClasses.DataSource = dl.GetClassesbyInstructor(employee.employeeID);
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            dl.RemoveEmployee(employee);
            lstClasses.DataSource = dl.GetClassesbyInstructor(employee.employeeID);
        }
    }
}
