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
                    

                                           ";
        }
           
    }

    }
}
