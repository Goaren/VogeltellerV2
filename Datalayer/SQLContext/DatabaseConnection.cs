using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datalayer.SQLContext
{
    class DatabaseConnection
    {
        private static readonly string connectionString = "Data Source=DUNSPARCE\\SQLEXPRESS;Initial Catalog=VogelTeller;Integrated Security=True";

        public static SqlConnection Connection
        {
            get
            {
                SqlConnection connection = new SqlConnection(connectionString);
                try
                {
                    connection.Open();
                }
                catch (Exception e)
                {
                    connection.Close();
                }
                return connection;
            }
        }
    }
}
