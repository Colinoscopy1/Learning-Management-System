using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LMS_Final_Project
{
    public partial class Form1 : Form
    {
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        
        public Form1()
        {
            InitializeComponent();
            string connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";

            try
            {
                DataLayer d = new DataLayer(connectionString);
                d.CreateSchema();
            }
            catch
            {
                
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginRegister lr = new LoginRegister();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterStudent rs = new RegisterStudent();
            rs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterEmployee re = new RegisterEmployee();
            re.ShowDialog();
        }
    }
}
