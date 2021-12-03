using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace LMS_Final_Project
{
    class DataLayer
    {
        private string connectionString = "";
        SqlConnection conn;
        
        public DataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void CreateSchema()
        {
            string CreateDataBasequery = $@"
                    

                                           ";
        }
           
    }

    }
}
