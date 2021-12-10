using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace LMS_Final_Project
{
    class HandIn
    {
        public int postID;
        public int studentID;
        public string studentName;
        public string filePath;
        public string submittedDate;
        public int grade;
        public DateTime gradedDate;

        public string postTitle;

        string serverAddress = ConfigurationManager.AppSettings.Get("server");
        string databaseName = ConfigurationManager.AppSettings.Get("database");
        string userID = ConfigurationManager.AppSettings.Get("username");
        string password = ConfigurationManager.AppSettings.Get("password");
        string connectionString;
        DataLayer d;

        public HandIn(int post, int student, string file, string title, string datetime)
        {
            connectionString = $"server={serverAddress};database={databaseName};user id={userID};password={password}";
            d = new DataLayer(connectionString);

            this.postID = post;
            this.studentID = student;
            this.filePath = file;
            this.postTitle = title;
            this.studentName = d.GetStudentNamebyID(this.studentID);
            this.submittedDate = datetime;
        }

        public override string ToString()
        {
            return this.studentName +": "+ this.postTitle;
        }
    }
}
