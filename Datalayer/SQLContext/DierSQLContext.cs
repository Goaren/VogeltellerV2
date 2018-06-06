using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.SQLContext
{
    public class DierSQLContext
    {
        public List<Dier> GetAllDieren()
        {
            string query = "Select v.Naam From Vogel v union select z.Naam from Zoogdier z";
            List<Dier> DierList = new List<Dier>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DierList.Add(CreateDierFromReader(dr));
                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return DierList;
        }
        public Dier CreateDierFromReader(SqlDataReader dr)
        {
            Dier d = new Dier(
                Convert.ToInt32(dr["ID"]),
                Convert.ToString(dr["Naam"]));
            return d;
        }
        public Zoogdier CreateZoogdierFromReader(SqlDataReader dr)
        {
            Zoogdier z = new Zoogdier(
                Convert.ToInt32(dr["ID"]),
                Convert.ToString(dr["Naam"]),
                Convert.ToString(dr["Familie"]));
            return z;
        }
        public Vogel CreateVogelFromReader(SqlDataReader dr)
        {
            Vogel v = new Vogel(
                Convert.ToInt32(dr["ID"]),
                Convert.ToString(dr["Naam"]),
                Convert.ToDateTime(dr["BroedPeriodeBegin"]),
                Convert.ToDateTime(dr["BroedPeriodeEind"]),
                Convert.ToInt32(dr["Broedpaar"]));
            return v;
        }

    }
}
