using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datalayer.Interfaces;
using System.Data.SqlClient;
using Models.Models;

namespace Datalayer.SQLContext
{
    public class BezoekSQLContext : IBezoekContext
    {

        public List<Bezoek> GetAllBezoeken()
        {
            string query = "SELECT * FROM Bezoek";
            List<Bezoek> BezoekList = new List<Bezoek>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BezoekList.Add(CreateBezoekFromReader(dr));
                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return BezoekList;
        }
        private Bezoek CreateBezoekFromReader(SqlDataReader reader)
        {
            return new Bezoek(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToDateTime(reader["Start"]),
                 Convert.ToDateTime(reader["Einde"]),
                 Convert.ToInt32(reader["AccountID"]),
                 Convert.ToInt32(reader["GebiedID"]));
        }
    }
}
