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
        Vogel vogel;
        Zoogdier zoogdier;
        public Vogel GetVogelById(int id)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "SELECT * FROM Vogel WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vogel = CreateVogelFromReader(dr);
                        }
                    }
                }
            }
            return vogel;
        }
        public Zoogdier GetZoogdierById(int id)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "SELECT * FROM Zoogdier WHERE ID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            zoogdier = CreateZoogdierFromReader(dr);
                        }
                    }
                }
            }
            return zoogdier;
        }

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
        public bool UpdateVogel(Vogel vogel)
        {
            using(SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "UPDATE Vogel Set Naam=@naam, BroedPeriodeStart=@broedperiodestart, BroedPeriodeEinde=@broedperiodeeinde, Broedpaar=@broedpaar WHERE ID=@id";
                using(SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", vogel.Id);
                    cmd.Parameters.AddWithValue("@naam", vogel.Naam);
                    cmd.Parameters.AddWithValue("@broedperiodestart", vogel.BroedperiodeStart);
                    cmd.Parameters.AddWithValue("@broedperiodeeinde", vogel.BroedperiodeEinde);
                    cmd.Parameters.AddWithValue("@broedpaar", vogel.Broedpaar);
                    try
                    {
                        if(Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch(Exception e)
                    {

                    }
                }   
            }
            return false;
        }
        public bool UpdateZoogdier(Zoogdier zoogdier)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "UPDATE Zoogdier Set Naam=@naam, Familie=@familie WHERE ID=@id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", zoogdier.Id);
                    cmd.Parameters.AddWithValue("@naam", zoogdier.Naam);
                    cmd.Parameters.AddWithValue("@familie", zoogdier.Familie);
                    try
                    {
                        if (Convert.ToInt32(cmd.ExecuteNonQuery()) > 0)
                        {
                            return true;
                        }
                    }
                    catch (Exception e)
                    {

                    }
                }
            }
            return false;
        }

        public bool DeleteVogel(int id)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "DELETE FROM Vogel WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        public bool DeleteZoogdier(int id)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "DELETE FROM Zoogdier WHERE ID=@id";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("id", id);
                    if (Convert.ToInt32(command.ExecuteNonQuery()) == 1)
                    {
                        return true;
                    }
                }
            }

            return false;
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
                Convert.ToDateTime(dr["BroedPeriodeEinde"]),
                Convert.ToInt32(dr["Broedpaar"]));
            return v;
        }

    }
}
