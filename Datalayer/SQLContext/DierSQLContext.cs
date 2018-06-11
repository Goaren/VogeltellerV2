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
    public class DierSQLContext : IDierContext
    {

        public List<Vogel> GetAllVogels()
        {
            string query = "Select * From Vogel";
            List<Vogel> DierList = new List<Vogel>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DierList.Add(CreateVogelFromReader(dr));
                       
                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return DierList;
        }
        public List<Zoogdier> GetAllZoogdieren()
        {
            string query = "Select * From Zoogdier";
            List<Zoogdier> DierList = new List<Zoogdier>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DierList.Add(CreateZoogdierFromReader(dr));

                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return DierList;
        }
        public Vogel CreateVogel(Vogel vogel)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "INSERT INTO Vogel (Naam, BroedPeriodeStart, BroedPeriodeEinde, Broedpaar)" +
                    "VALUES (@naam, @broedperiodestart, @broedperiodeeinde, @broedpaar)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@naam", vogel.Naam);
                    cmd.Parameters.AddWithValue("@broedperiodestart", vogel.BroedperiodeStart);
                    cmd.Parameters.AddWithValue("@broedperiodeeinde", vogel.BroedperiodeEinde);
                    cmd.Parameters.AddWithValue("@broedpaar", vogel.Broedpaar);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return vogel;
            }
        }
        public Zoogdier CreateZoogdier(Zoogdier zoogdier)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "INSERT INTO Zoogdier (Naam, Familie)" +
                    "VALUES (@naam, @familie)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@naam", zoogdier.Naam);
                    cmd.Parameters.AddWithValue("@familie", zoogdier.Familie);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return zoogdier;
            }
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
                Convert.ToDateTime(dr["BroedPeriodeStart"]),
                Convert.ToDateTime(dr["BroedPeriodeEind"]),
                Convert.ToInt32(dr["Broedpaar"]));
            return v;
        }

    }
}
