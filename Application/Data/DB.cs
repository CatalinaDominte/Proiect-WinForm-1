using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data
{
    public class DB
    {
        private static SqlConnection connection = null;
        private DB() { }

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                string connectionString = "Data Source=.;Initial Catalog=winform;Integrated Security=True";

             

                connection = new SqlConnection(connectionString);

            }
            

            return connection;
        }
    }
}
