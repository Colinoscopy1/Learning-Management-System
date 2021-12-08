using System;
using System.Collections.Generic;
using System.Text;

namespace LMS_Final_Project
{
    public class Course
    {
        private string _ClassNumber;
        private string _ClassName;
        private string _Building;
        private string _RoomNumber;
        private int _InstructorID;
        private int _ProgramID;
        //add a list of posts here
        //not sure about these
        private DateTime _classTime;
        private int _classFrequency;
        private int _classDuration;

        public Course(string classNum, string className, string building, string roomNum, int instructorID, int programID)
        {
            this._ClassNumber = classNum;
            this._ClassName = className;
            this._Building = building;
            this._RoomNumber = roomNum;
            this._InstructorID = instructorID;
            this._ProgramID = programID;
        }

        public override string ToString()
        {
            return this._ClassNumber + ": " + this._ClassName;
        }

        public string GetCourseId()
        {
            return this._ClassNumber;
        }
    }
}
