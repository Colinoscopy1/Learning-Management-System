using System;
using System.Collections.Generic;
using System.Text;

namespace LMS_Final_Project
{
    public class Employee
    {
        public int employeeID;
        public string FName;
        public string LName;
        public string officeNumber;
        public string email;
        public string phone;

        public Employee(int employeeID, string FName, string LName, string officeNumber, string email, string phone)
        {
            this.employeeID = employeeID;
            this.FName = FName;
            this.LName = LName;
            this.officeNumber = officeNumber;
            this.email = email;
            this.phone = phone;
        }

        public override string ToString()
        {
            return this.FName + " " + this.LName + ": " + this.employeeID;
        }
    }
}
