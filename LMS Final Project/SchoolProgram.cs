using System;
using System.Collections.Generic;
using System.Text;

namespace LMS_Final_Project
{
    public class SchoolProgram
    {
        private int _ProgramID;
        private string _ProgramName;
        private int _Semester;
        private int _Year;
        private List<Course> courses;

        public SchoolProgram(int progID, string progName, int semester, int year)
        {
            this._ProgramID = progID;
            this._ProgramName = progName;
            this._Semester = semester;
            this._Year = year;
        }

        public void AddCourses(List<Course> tmp)
        {
            foreach (Course crs in tmp)
            {
                this.courses.Add(crs);
            }
        }
    }
}
