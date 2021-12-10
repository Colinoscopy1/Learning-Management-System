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
    public partial class StudentGradesControl : UserControl
    {
        StudentHome home;
        Course thiscourse;
        string connectionString;
        DataLayer d;
        List<string> handIns;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");

        public StudentGradesControl(StudentHome prev, Course crs)
        {
            InitializeComponent();
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            d = new DataLayer(connectionString);
            thiscourse = crs;
            home = prev;

            handIns = d.GetGradedHandins(home.studentID);

            foreach(string item in handIns)
            {
                lstPosts.Items.Add(item.Split("|")[0] + ": " + item.Split("|")[1]);
            }
        }
    }
}
