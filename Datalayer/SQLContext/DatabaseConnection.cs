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
        private static readonly string connectionString = "Server=tcp:rozer.database.windows.net,1433;Initial Catalog=VogelTeller;Persist Security Info=False;User ID=Rozer;Password=Henk5924;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

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
