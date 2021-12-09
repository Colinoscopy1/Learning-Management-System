using System;
using System.Collections.Generic;
using System.Text;

namespace LMS_Final_Project
{
    public class Student
    {
        public int studentID;
        public string FName;
        public string LName;
        public string email;
        public string phone;
        public bool is_Approved;
        public bool Academic_Probation;

        public Student(int studentID, string FName, string LName, string email, string phone, bool approved, bool probation)
        {
            this.studentID = studentID;
            this.FName = FName;
            this.LName = LName;
            this.email = email;
            this.phone = phone;
            this.is_Approved = approved;
            this.Academic_Probation = probation;
        }

        public override string ToString()
        {
            return this.FName + " " + this.LName + ": " + this.studentID;
        }
    }
}
