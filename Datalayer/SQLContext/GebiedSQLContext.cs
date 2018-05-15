using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Models;

namespace Datalayer.SQLContext
{
    public class GebiedSQLContext
    {
        Gebied gebied;

        public List<Gebied> GetAllGebieden()
        {
            string query = "SELECT * FROM Gebied";
            List<Gebied> GebiedList = new List<Gebied>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        GebiedList.Add(CreateGebiedFromReader(dr));
                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return GebiedList;
        }
        public Gebied CreateGebiedFromReader(SqlDataReader dr)
        {
            Gebied g = new Gebied(
                Convert.ToInt32(dr["ID"]),
                Convert.ToString(dr["Naam"]),
                Convert.ToDouble(dr["X"]),
                Convert.ToDouble(dr["Y"]),
                Convert.ToInt32(dr["Zoom"]));
            return g;
        }
    }
}
