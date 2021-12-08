﻿using System;
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
											[Building] [varchar](50) NULL,
											[Room_Number] [varchar](5) NULL,
											[InstructorID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Programs] (ProgramID),
											[ProgramID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Employees] (EmployeeID)
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
											[Post_ID] [int] IDENTITY(1,1) PRIMARY KEY NOT NULL,
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[FilePath] [varchar](max) NULL
											);

										CREATE TABLE [dbo].[ClassRoster](
											[StudentID] [int] NOT NULL FOREIGN KEY REFERENCES [dbo].[Students] (StudentID),
											[Class] [varchar](7) NULL FOREIGN KEY REFERENCES [dbo].[Classes] (Class_Number)
											);

										INSERT INTO Employees VALUES ('Default', 'Admin', 'N/A', 'N/A', 'N/A');

										INSERT INTO EmployeeAccounts VALUES ('Admin', CONVERT (VARCHAR(64), HASHBYTES('SHA2_256', 'password'), 2), 0, 1);";

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

			string studentStatus = $@"SELECT s.Is_Approved FROM Students s JOIN StudentAccounts a ON s.StudentID = a.StudentID WHERE a.Username = '{username}' AND 
									a.Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '{userPassword}'), 2));";

			conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(studentStatus, conn);
			//cmd.Parameters.AddWithValue("@user", username);
			//cmd.Parameters.AddWithValue("@password", userPassword);

			try
            {
				conn.Open();
				//always returns null even though query is right!
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

		public bool StudentLogin(string username, string userpassword)
        {
			bool ret = false;

			string studentLoginQuery = $@"SELECT COUNT(*) FROM StudentAccounts WHERE Username = '{username}' AND Password = (CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', '{userpassword}'), 2))";

			conn = new SqlConnection(connectionString);
            try
            {
				conn.Open();
				SqlCommand cmd = new SqlCommand(studentLoginQuery, conn);
				//using parameterization causes Scalar to crash
				//cmd.Parameters.AddWithValue("@user", username);
				//cmd.Parameters.AddWithValue("@password", userpassword);
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
				int countRecord = (int)cmd.ExecuteScalar();

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
				int countRecord = (int)cmd.ExecuteScalar();

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
	}

}

