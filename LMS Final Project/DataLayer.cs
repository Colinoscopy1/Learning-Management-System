using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace LMS_Final_Project
{
    public class DataLayer
    {
        private string connectionString = "";
        SqlConnection conn;

        public DataLayer(string connString)
        {
            this.connectionString = connString;
        }

        public void CreateSchema()
        {
            string CreateDataBasequery = $@"CREATE TABLE [dbo].[Employees](
											[EmployeeID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[FName] [varchar](30) NOT NULL,
											[LName] [varchar](30) NOT NULL,
											[Office_Number] [varchar](15) NULL,
											[Email] [varchar](50) NULL,
											[Phone] [varchar](14) NULL	
											);

										CREATE TABLE [dbo].[EmployeeAccounts](
											[Username] [varchar](25) PRIMARY KEY NOT NULL,
											[Password] [varchar](64) NOT NULL,
											[EmployeeID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Employees] (EmployeeID),
											[Is_Admin] [bit] NOT NULL
											);

										CREATE TABLE [dbo].[Students](
											[StudentID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[FName] [varchar](30) NOT NULL,
											[LName] [varchar](30) NOT NULL,
											[Email] [varchar](60) NOT NULL,
											[Phone] [varchar](14) NOT NULL,
											[Is_Approved] [bit] NOT NULL,
											[Academic_Probtation] [bit] NOT NULL
											);

										CREATE TABLE [dbo].[StudentAccounts](
											[AccountNumber] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[Username] [varchar](25) NOT NULL,
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[Password] [varchar](64) NOT NULL
											);

										CREATE TABLE [dbo].[Programs](
											[ProgramID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[Program_Name] [varchar](50) NOT NULL,
											[Semester] [int] NOT NULL,
											[Year] [int] NOT NULL
											);

										CREATE TABLE [dbo].[Classes](
											[Class_Number] [varchar](7) PRIMARY KEY NOT NULL,
											[Class_Name] [varchar](MAX) NOT NULL,
											[Building] [varchar](50) NULL,
											[Room_Number] [varchar](5) NULL,
											[InstructorID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Employees] (EmployeeID),
											[ProgramID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Programs] (ProgramID)
											);

										CREATE TABLE [dbo].[ClassTimes](
											[Day_of_Week] [varchar](8) NOT NULL,
											[Class] [varchar](7) NOT NULL FOREIGN KEY REFERENCES [dbo].[Classes] (Class_Number),
											[Time] [time] NOT NULL,
											[Duration_Minutes] [int] NOT NULL
											);

										CREATE TABLE [dbo].[Posts](
											[Post_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[Post_Title] [varchar](50) NULL,
											[Post_Body] [varchar](max) NULL,
											[Is_Assignment] [bit] NOT NULL,
											[Due_Date] [datetime] NULL,
											[Class] [varchar](7) NULL FOREIGN KEY REFERENCES [dbo].[Classes] (Class_Number)
											);

										CREATE TABLE [dbo].[HandIns](
											[Post_ID] [int] IDENTITY(1,1) NOT NULL FOREIGN KEY REFERENCES [dbo].[Posts] (Post_ID),
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[FilePath] [varchar](max) NULL,
											[Submitted] [datetime] NOT NULL,
											[Grade] [int] NULL,
											[Graded] [datetime] NULL
											);

										CREATE TABLE [dbo].[ClassRoster](
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[Class] [varchar](7) NULL FOREIGN KEY REFERENCES [dbo].[Classes] (Class_Number)
											);

										CREATE TABLE [dbo].[StudentGrades](
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[Class_Num] [varchar] (7) NOT NULL FOREIGN KEY REFERENCES [dbo].[Classes] (Class_Number),
											[Grade] [int] NULL
											);

										INSERT INTO Employees VALUES ('Default', 'Admin', 'N/A', 'N/A', 'N/A');

										INSERT INTO EmployeeAccounts VALUES ('Admin', CONVERT (VARCHAR(64), HASHBYTES('SHA2_256', 'password'), 2), 1, 1);";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(CreateDataBasequery, conn);
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        #region Student Stuff
        public void CreateStudent(string fname, string lname, string email, string phone)
        {
            string createStudentQuery = @"INSERT INTO Students VALUES (@fname, @lname, @email, @phone, 0, 0)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(createStudentQuery, conn);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@phone", phone);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public bool StudentLogin(string username, string userpassword)
        {
            bool ret = false;

            //string studentLoginQuery = $@"SELECT COUNT(*) FROM StudentAccounts WHERE Username = '{username}' AND Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '{userpassword}'), 2))";

            string studentLoginQuery = $@"SELECT COUNT(*) FROM StudentAccounts WHERE Username = @user AND Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @password), 2))";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(studentLoginQuery, conn);
                //using parameterization causes Scalar to crash
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@password", userpassword);
                int countRecord = Convert.ToInt32(cmd.ExecuteScalar());

                if (countRecord > 0)
                    ret = true;
                else
                    ret = false;
            }
            catch
            {
                ret = false;
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> ret = new List<Student>();
            string GetAllStudentsQuery = $@"Select * From Students";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(GetAllStudentsQuery, conn);


            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int studentID = reader.GetInt32(0);
                        string FName = reader.GetString(1);
                        string LName = reader.GetString(2);
                        string Email = reader.GetString(3);
                        string Phone = reader.GetString(4);
                        bool approved = reader.GetBoolean(5);
                        bool probation = reader.GetBoolean(6);

                        Student tmp = new Student(studentID, FName, LName, Email, Phone, approved, probation);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;

        }

        public int GetStudentIdbyEmail(string email)
        {
            int ret = 0;

            string getIDquery = $@"SELECT StudentID from Students WHERE Email = '{email}'";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getIDquery, conn);

            try
            {
                conn.Open();
                ret = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return ret;

        }

        public int GetStudentIdbyUsername(string username)
        {
            int ret = 0;

            string getIDquery = $@"SELECT StudentID from StudentAccounts WHERE Username = @user";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getIDquery, conn);
            cmd.Parameters.AddWithValue("@user", username);

            try
            {
                conn.Open();
                ret = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetStudentUsernameByEmail(string email)
        {
            string ret = "";

            string getIDquery = $@"SELECT Username FROM StudentAccounts a JOIN Students s ON a.StudentID = s.StudentID WHERE s.Email = '{email}'";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getIDquery, conn);

            try
            {
                conn.Open();
                ret = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetStudentNamebyID(int studentID)
        {
            string ret = "";

            string getNameQuery = $@"SELECT FName +' '+ LName [Full_Name] FROM Students WHERE StudentID = {studentID}";

            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getNameQuery, conn);
                //cmd.Parameters.AddWithValue("@id", studentID);
                ret = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void CreateStudentAccount(int studentid, string username, string password)
        {
            string createStudentAccount = @"INSERT INTO StudentAccounts VALUES (@username, @studentid, CONVERT (VARCHAR(64), HASHBYTES('SHA2_256', @password), 2))";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(createStudentAccount, conn);
            cmd.Parameters.AddWithValue("@studentid", studentid);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        //add method to get all students and cast to a list of Student class
        #endregion

        #region Employee Stuff
        public int GetEmployeeIDbyUsername(string username)
        {
            int ret = 0;

            string getIDquery = $@"SELECT EmployeeID from EmployeeAccounts WHERE Username = @user";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getIDquery, conn);
            cmd.Parameters.AddWithValue("@user", username);

            try
            {
                conn.Open();
                ret = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetEmployeeUsernamebyEmail(string email)
        {
            string ret = "";

            string getIDquery = $@"SELECT Username FROM EmployeeAccounts a JOIN Employees e ON a.EmployeeID = s.EmployeeID WHERE s.Email = '{email}'";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getIDquery, conn);

            try
            {
                conn.Open();
                ret = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetEmployeeNamebyID(int employeeID)
        {
            string ret = "";

            string getNameQuery = $@"SELECT FName +' '+ LName [Full_Name] FROM Employees WHERE EmployeeID = {employeeID}";

            conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(getNameQuery, conn);
                //cmd.Parameters.AddWithValue("@id", studentID);
                ret = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> ret = new List<Employee>();
            string GetAllEmployeesQuery = $@"Select * From Employees";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(GetAllEmployeesQuery, conn);


            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int EmployeeID = reader.GetInt32(0);
                        string FName = reader.GetString(1);
                        string LName = reader.GetString(2);
                        string OfficeNumber = reader.GetString(3);
                        string Email = reader.GetString(4);
                        string Phone = reader.GetString(5);

                        Employee tmp = new Employee(EmployeeID, FName, LName, OfficeNumber, Email, Phone);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void CreateEmployee(string fname, string lname, string email, string officenum, string phone)
        {
            string createEmployeeQuery = @"INSERT INTO Employees VALUES (@fname, @lname, @officenum, @email,  @phone)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(createEmployeeQuery, conn);
            cmd.Parameters.AddWithValue("@fname", fname);
            cmd.Parameters.AddWithValue("@lname", lname);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@officenum", officenum);
            cmd.Parameters.AddWithValue("@phone", phone);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public int GetEmployeeIDbyEmail(string email)
        {
            int ret = 0;

            string getEmployeeIDQuery = $@"SELECT EmployeeID from Employees WHERE Email = '{email}'";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getEmployeeIDQuery, conn);

            try
            {
                conn.Open();
                ret = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void CreateEmployeeAccount(string username, string password, int employeeid, int admin)
        {
            string createEmployeeAccount = @"INSERT INTO EmployeeAccounts VALUES (@username, CONVERT (VARCHAR(64), HASHBYTES('SHA2_256', @password), 2), @employeeid, @admin)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(createEmployeeAccount, conn);
            cmd.Parameters.AddWithValue("@employeeid", employeeid);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@admin", admin);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public bool CheckStudentApproval(string username, string userPassword)
        {
            bool ret = false;

            //   string studentStatus = $@"SELECT s.Is_Approved FROM Students s JOIN StudentAccounts a ON s.StudentID = a.StudentID WHERE a.Username = '{username}' AND 
            //a.Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '{userPassword}'), 2));";

            string studentStatus = $@"SELECT s.Is_Approved FROM Students s JOIN StudentAccounts a ON s.StudentID = a.StudentID WHERE a.Username = @user AND 
									a.Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', @password), 2));";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(studentStatus, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@password", userPassword);

            try
            {
                conn.Open();
                //always returns null even though query is right!
                object test = cmd.ExecuteScalar();
                int countRecord = Convert.ToInt32(cmd.ExecuteScalar());

                if (countRecord > 0)
                    ret = true;
                else
                    ret = false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                //ret = false;
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public bool CheckAdminStatus(string username, string password)
        {
            bool ret = false;

            string checkAdminQuery = @"SELECT Is_Admin FROM EmployeeAccounts WHERE Username = @user and Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256',@password), 2))";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(checkAdminQuery, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@password", password);
                int countRecord = Convert.ToInt32(cmd.ExecuteScalar());

                if (countRecord == 1)
                    ret = true;
                else
                    ret = false;
            }
            catch
            {
                ret = false;
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public bool EmployeeLogin(string username, string password)
        {
            bool ret = false;

            string employeeLoginQuery = @"SELECT COUNT(*) FROM EmployeeAccounts WHERE Username = @user AND Password = CONVERT(VARCHAR(64), HASHBYTES('SHA2_256',@password), 2)";

            conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(employeeLoginQuery, conn);
                cmd.Parameters.AddWithValue("@user", username);
                cmd.Parameters.AddWithValue("@password", password);
                int countRecord = Convert.ToInt32(cmd.ExecuteScalar());

                if (countRecord > 0)
                    ret = true;
                else
                    ret = false;
            }
            catch
            {
                ret = false;
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void RemoveEmployee(Employee employee)
        {
            int ID = employee.employeeID;

            string RemoveEmployeeQuery = $@"
                Delete From EmployeeAccounts Where EmployeeID = @ID;
                Delete From Employees Where EmployeeID = @ID";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(RemoveEmployeeQuery, conn);
            cmd.Parameters.AddWithValue("@ID", ID);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Class Stuff
        public void AddStudentToClass(string classNumber, int studentID)
        {
            string addStudentQuery = $@"Insert Into ClassRoster(StudentID, Class) Values (@studentID, @class)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(addStudentQuery, conn);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@class", classNumber);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }

        }

        public void RemoveStudentEntirely(Student student)
        {
            int ID = student.studentID;

            string RemoveStudentQuery = $@"
                                           Delete From StudentAccounts where studentID = @student;
                                           Delete From ClassRoster where studentID = @student;
                                           Delete From HandIns where studentID = @student;
                                           Delete From StudentGrades where studentID = @student;
                                           Delete From Students Where studentID = @student";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(RemoveStudentQuery, conn);
            cmd.Parameters.AddWithValue("@student", ID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public void RemoveStudentFromClass(int studentID, Course course)
        {
            string addStudentQuery = $@"Delete From ClassRoster Where studentID = @studentID and Class = @class";
            string courseID = course.GetCourseId();
            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(addStudentQuery, conn);
            cmd.Parameters.AddWithValue("@studentID", studentID);
            cmd.Parameters.AddWithValue("@class", courseID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Course> GetEnrolledClasses(int studentID)
        {
            List<Course> ret = new List<Course>();

            string yourcoursequery = $@"SELECT c.Class_Number, c.Class_Name, c.Building, c.Room_Number, c.InstructorID, c.ProgramID FROM ClassRoster r JOIN Classes c 
										ON r.Class = c.Class_Number WHERE r.StudentID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(yourcoursequery, conn);
            cmd.Parameters.AddWithValue("@id", studentID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string classNum = reader.GetString(0);
                        string className = reader.GetString(1);
                        string building = reader.GetString(2);
                        string roomNum = reader.GetString(3);
                        int instructor = reader.GetInt32(4);
                        int progID = reader.GetInt32(5);

                        Course tmp = new Course(classNum, className, building, roomNum, instructor, progID);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<Course> GetAllClasses()
        {
            List<Course> ret = new List<Course>();

            string allclassquery = $@"SELECT Class_Number, Class_Name, Building, Room_Number, InstructorID, ProgramID FROM Classes";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(allclassquery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string classNum = reader.GetString(0);
                        string className = reader.GetString(1);
                        string building = reader.GetString(2);
                        string roomNum = reader.GetString(3);
                        int instructor = reader.GetInt32(4);
                        int progID = reader.GetInt32(5);

                        Course tmp = new Course(classNum, className, building, roomNum, instructor, progID);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<string> GetClassTimes(string classNum)
        {
            List<string> ret = new List<string>();

            string timequery = $@"SELECT Day_of_Week +'s at '+ Time [DayTime] FROM ClassTimes WHERE Class = @num";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(timequery, conn);
            cmd.Parameters.AddWithValue("@num", classNum);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tmp = reader.GetString(0);
                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<Course> GetClassesbyInstructor(int employeeID)
        {
            List<Course> ret = new List<Course>();

            string allclassquery = $@"SELECT Class_Number, Class_Name, Building, Room_Number, InstructorID, ProgramID FROM Classes WHERE InstructorID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(allclassquery, conn);
            cmd.Parameters.AddWithValue("id", employeeID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string classNum = reader.GetString(0);
                        string className = reader.GetString(1);
                        string building = reader.GetString(2);
                        string roomNum = reader.GetString(3);
                        int instructor = reader.GetInt32(4);
                        int progID = reader.GetInt32(5);

                        Course tmp = new Course(classNum, className, building, roomNum, instructor, progID);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<string> GetStudentsFromRoster(string classNum)
        {
            List<string> ret = new List<string>();

            string rosterquery = $@"SELECT s.FName +' '+ s.LName [FullName] FROM ClassRoster r JOIN Students s ON r.StudentID = s.StudentID WHERE r.Class = @num";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(rosterquery, conn);
            cmd.Parameters.AddWithValue("@num", classNum);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tmp = reader.GetString(0);
                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<SchoolProgram> GetPrograms()
        {
            List<SchoolProgram> ret = new List<SchoolProgram>();

            string programquery = $@"SELECT ProgramID, Program_Name, Semester, Year FROM Programs";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(programquery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int programID = reader.GetInt32(0);
                        string progName = reader.GetString(1);
                        int semester = reader.GetInt32(2);
                        int year = reader.GetInt32(3);

                        SchoolProgram tmp = new SchoolProgram(programID, progName, semester, year);
                        tmp.AddCourses(GetCourseByProgram(programID));
                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<Course> GetCourseByProgram(int programID)
        {
            List<Course> ret = new List<Course>();

            string coursequery = $@"SELECT Class_Number, Class_Name, Building, Room_Number, InstructorID, ProgramID from Classes WHERE ProgramID = @progID";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(coursequery, conn);
            cmd.Parameters.AddWithValue("@progID", programID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string classNum = reader.GetString(0);
                        string className = reader.GetString(1);
                        string building = reader.GetString(2);
                        string roomNum = reader.GetString(3);
                        int instructor = reader.GetInt32(4);
                        int progID = reader.GetInt32(5);

                        Course tmp = new Course(classNum, className, building, roomNum, instructor, progID);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetProgNamebyID(int progID)
        {
            string ret = "";

            string namequery = $@"SELECT Program_Name FROM Programs WHERE ProgramID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(namequery, conn);
            cmd.Parameters.AddWithValue("@id", progID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public string GetFinalGradebyStudentID(int studentID, string classnum)
        {
            string ret = "";

            string finalgradequery = $@"SELECT Grade FROM StudentGrades WHERE StudentID = @id AND Class_Num = @class";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(finalgradequery, conn);
            cmd.Parameters.AddWithValue("@id", studentID);
            cmd.Parameters.AddWithValue("@class", classnum);

            try
            {
                conn.Open();
                ret = cmd.ExecuteScalar().ToString();
            }
            catch
            {

            }
            finally
            {
                conn.Close();
            }

            return ret;
        }
        #endregion

        #region posts/handins

        public void CreatePost(string title, string body, int isAssignment, DateTime dueDate, string classNum)
        {
            string makepostQuery = $@"INSERT INTO Posts VALUES (@title, @body, @assign, @due, @class)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(makepostQuery, conn);
            cmd.Parameters.AddWithValue("@title", title);
            cmd.Parameters.AddWithValue("@body", body);
            cmd.Parameters.AddWithValue("@assign", isAssignment);
            cmd.Parameters.AddWithValue("@due", dueDate);
            cmd.Parameters.AddWithValue("@class", classNum);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Post> GetPostsbyClass(string classNumber)
        {
            List<Post> ret = new List<Post>();

            string postquery = $@"SELECT Convert(varchar, (Post_ID),1) +'|'+ Post_Title +'|'+ Post_Body +'|'+ Convert(varchar, (Is_Assignment),1) +'|'+ 
                                    Convert(varchar, (Due_Date),1) [PostDetails] FROM Posts WHERE Class = @class";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(postquery, conn);
            cmd.Parameters.AddWithValue("@class", classNumber);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tmp = reader.GetString(0);
                        int id = Convert.ToInt32(tmp.Split("|")[0]);
                        string title = tmp.Split("|")[1];
                        string body = tmp.Split("|")[2];
                        int assign = Convert.ToInt32(tmp.Split("|")[3]);
                        DateTime due;
                        if (assign == 1)
                        {
                            due = DateTime.Parse(tmp.Split("|")[4]);
                            Post pst = new Post(id, title, body, assign, due, classNumber);
                            ret.Add(pst);
                        }
                        else
                        {
                            Post pst = new Post(id, title, body, assign, classNumber);
                            ret.Add(pst);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public List<string> GetGradedHandins(int studentID)
        {
            List<string> ret = new List<string>();

            string getPostsbyGraded = $@"SELECT Convert(varchar, (p.Post_ID),1) +'|'+ p.Post_Title FROM HandIns h JOIN Posts p ON h.Post_ID = p.Post_ID WHERE h.Grade is not null AND h.StudentID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(getPostsbyGraded, conn);
            cmd.Parameters.AddWithValue("@id", studentID);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tmp = reader.GetString(0);
                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void CreateHandIn(int postId, int studentID, string filePath, DateTime submitted)
        {
            string makehandinquery = $@"INSERT INTO HandIns ([Post_ID], [StudentID], [FilePath], [Submitted]) VALUES (@postid, @studentid, @filepath, @submitted)";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(makehandinquery, conn);
            cmd.Parameters.AddWithValue("@postid", postId);
            cmd.Parameters.AddWithValue("@studentid", studentID);
            cmd.Parameters.AddWithValue("@filepath", filePath);
            cmd.Parameters.AddWithValue("@submitted", submitted);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void GradeHandIn(int postID, int studentID, int grade, DateTime graded)
        {
            string updatehandin = $@"UPDATE HandIns SET [Grade] = @grade, [Graded] = @graded WHERE Post_ID = @post AND StudentID = @student";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(updatehandin, conn);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@graded", graded);
            cmd.Parameters.AddWithValue("@post", postID);
            cmd.Parameters.AddWithValue("@student", studentID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public void SetStudentFinalGrade(int studentID, string classID, string grade)
        {
            string finalgrade = $@"UPDATE StudentGrades SET [Grade] = @grade WHERE StudentID = @id AND Class_Num = @class";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(finalgrade, conn);
            cmd.Parameters.AddWithValue("@grade", grade);
            cmd.Parameters.AddWithValue("@id", studentID);
            cmd.Parameters.AddWithValue("@class", classID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion

        #region admin controls

        public void PlaceStudentOnProbation(Student student)
        {
            int tmp;

            if (student.Academic_Probation == true)
                tmp = 0;
            else
                tmp = 1;

            string probateStudent = $@"UPDATE Students SET Academic_Probation = @status WHERE StudentID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(probateStudent, conn);
            cmd.Parameters.AddWithValue("@id", student.studentID);
            cmd.Parameters.AddWithValue("@status", tmp);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public List<string> GetPendingStudents()
        {
            List<string> ret = new List<string>();

            string pendingstudentQuery = $@"SELECT FName +' '+ LName +','+ StudentID FROM Students WHERE Is_Approved = 0";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(pendingstudentQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string tmp = reader.GetString(0);

                        ret.Add(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return ret;
        }

        public void ApprovePendingStudent(int studentID)
        {
            string approveStudent = $@"UPDATE Students SET Is_Approved = 1 WHERE StudentID = @id";

            conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(approveStudent, conn);
            cmd.Parameters.AddWithValue("@id", studentID);

            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        #endregion
    }
}

