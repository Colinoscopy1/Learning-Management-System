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

        public string GetCourseName()
        {
            return this._ClassName;
        }

        public int GetCourseInstructorID()
        {
            return this._InstructorID;
        }

        public string GetCourseBuilding()
        {
            return this._Building;
        }

        public string GetCourseRoom()
        {
            return this._RoomNumber;
        }

        public int GetCourseProgram()
        {
            return this._ProgramID;
        }
    }
}
