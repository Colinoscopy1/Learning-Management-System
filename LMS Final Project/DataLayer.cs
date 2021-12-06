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
            string CreateDataBasequery = $@"
                    CREATE TABLE [dbo].[Employees](
	                [EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	                [FName] [varchar](30) NOT NULL,
	                [LName] [varchar](30) NOT NULL,
	                [Office_Number] [varchar](15) NULL,
	                [Email] [varchar](50) NULL,
	                [Phone] [varchar](14) NULL	
                    );

                    CREATE TABLE [dbo].[EmployeeAccounts](
	                [Username] [varchar](25) PRIMARY KEY NOT NULL,
	                [Password] [varchar](64) NOT NULL,
	                [EmployeeID] [int] NOT NULL,
	                [Is_Admin] [bit] NOT NULL
                    );

                    CREATE TABLE [dbo].[Classes](
	                [Class_Number] [varchar](5) NOT NULL,
	                [Building] [varchar](50) NULL,
	                [Room_Number] [varchar](5) NULL,
	                [Class_Time] [datetime] NOT NULL,
	                [Class_Duration] [datetime] NOT NULL,
	                [Instructor] [varchar](30) NOT NULL,
	                [Program] [varchar](50) NOT NULL
                    );

                    CREATE TABLE [dbo].[Programs](
	                [ProgramID] [int] IDENTITY(1,1) NOT NULL,
	                [Program_Name] [varchar](50) NOT NULL,
	                [Semester] [int] NOT NULL,
	                [Year] [datetime] NULL
                    );

                    CREATE TABLE [dbo].[Posts](
					[Post_ID] [int] IDENTITY(1,1) NOT NULL,
					[Post_Title] [varchar](50) NULL,
					[Post_Body] [varchar](1000) NULL,
					[Is_Assignment] [bit] NOT NULL,
					[Due_Date] [datetime] NULL,
					[Class] [varchar](5) NULL
					);

					CREATE TABLE [dbo].[HandIns](
					[Post_ID] [int] IDENTITY(1,1) NOT NULL,
					[StudentID] [int] NOT NULL,
					[FilePath] [varchar](max) NULL
					);

					CREATE TABLE [dbo].[ClassRoster](
					[StudentID] [int] NOT NULL,
					[Class] [nchar](10) NOT NULL
					) ;
			
					CREATE TABLE [dbo].[Students](
					[StudentID] [int] IDENTITY(1,1) NOT NULL,
					[FName] [varchar](30) NOT NULL,
					[LName] [varchar](30) NOT NULL,
					[Email] [varchar](60) NOT NULL,
					[Phone] [varchar](14) NOT NULL,
					[Is_Approved] [bit] NOT NULL,
					[Academic_Probtation] [bit] NOT NULL
					);

					CREATE TABLE [dbo].[StudentAccounts](
					[AccountNumber] [int] IDENTITY(1,1) NOT NULL,
					[Username] [varchar](25) NOT NULL,
					[StudentID] [int] NOT NULL,
					[Password] [varchar](64) NOT NULL
					);

				    INSERT INTO [dbo].[EmployeeAccounts]
					([Username]
					,[Password]
					,[EmployeeID]
					,[Is_Admin])
					VALUES
					 ('Admin',
					  'password',
					  '1',
					  1);

                     ";

			conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(CreateDataBasequery, conn);
            try
            {
				conn.Open();
				cmd.ExecuteNonQuery();
				
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
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

		public void CreateEmployee(string fname, string lname, string email, string officenum, string phone)
        {
			string createEmployeeQuery = @"INSERT INTO Employees VALUES (@fname, @lname, @email, @officenum, @phone)";

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

		public int GetStudentIdbyEmail(string email)
        {
			int ret = 0;

			string getIDquery = $@"SELECT StudentID from Students WHERE Email = {email}";

			conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(getIDquery, conn);

			try
			{
				conn.Open();
				ret = (int)cmd.ExecuteScalar();
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

		public void CreateStudentAccount(int studentid, string username, string password)
        {
			string createStudentAccount = @"INSERT INTO StudentAccounts VALUES (@studentid, @username, CONVERT (VARCHAR(64), HASHBYTES('SHA2_256', @password), 2))";

			conn = new SqlConnection(connectionString);
			SqlCommand cmd = new SqlCommand(createStudentAccount, conn);

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
           
    }

}

