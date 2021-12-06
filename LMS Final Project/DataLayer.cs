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
           
    }

    }

