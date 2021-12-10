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
    public partial class InstructorPosts : UserControl
    {
        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        string connectionString;
        
        DataLayer dl;

        Course course;

        public InstructorPosts(Course course)
        {
            InitializeComponent();
            this.course = course;
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            dl = new DataLayer(connectionString);

            
        }
    }
}
