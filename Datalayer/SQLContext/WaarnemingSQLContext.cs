using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Models;
using Datalayer.Interfaces;

namespace Datalayer.SQLContext
{
    public class WaarnemingSQLContext : IWaarnemingContext
    {
        Waarneming waarneming;
        Gebied gebied;
        public Waarneming GetWaarnemingById(int id)
        {

            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "Select * from Waarneming Where ID = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            waarneming = CreateWaarnemingFromReader(dr);
                        }
                    }
                }
            }
            return waarneming;
        }
        public List<Waarneming> GetAllWaarnemingen()
        {
            string query = "select * from waarneming";
            List<Waarneming> WaarnemingList = new List<Waarneming>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        WaarnemingList.Add(CreateWaarnemingFromReader(dr));
                    }
                }
                DatabaseConnection.Connection.Close();
            }
            return WaarnemingList;
        }
        public List<Waarneming> GetAllWaarnemingenBijGebied(int id)
        {
            string query = "select * from waarneming where GebiedID =(select ID from Gebied where ID = @id)";
            List<Waarneming> WaarnemingList = new List<Waarneming>();
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            WaarnemingList.Add(CreateWaarnemingFromReader(dr));
                        }
                    }
                    DatabaseConnection.Connection.Close();
                }
            }
            return WaarnemingList;
        }
        public Waarneming CreateWaarneming(Waarneming waarneming)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "INSERT INTO Waarneming (X, Y, GebiedID, AccountID, VogelID, SoortID, ZoogdierId)" +
                    "VALUES (@x, @y, @gebiedid, @accountid, @vogelid, @soortid, @zoogdierid)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@x", waarneming.X);
                    cmd.Parameters.AddWithValue("@y", waarneming.Y);
                    cmd.Parameters.AddWithValue("@gebiedid", waarneming.GebiedId);
                    cmd.Parameters.AddWithValue("@accountid", waarneming.AccountId);
                    cmd.Parameters.AddWithValue("@vogelid", waarneming.VogelId);
                    cmd.Parameters.AddWithValue("@soortid", waarneming.SoortId);
                    cmd.Parameters.AddWithValue("@zoogdierid", waarneming.ZoogdierId);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return waarneming;
            }
        }

        public Waarneming CreateWaarnemingFromReader(SqlDataReader dr)
        {
            Waarneming w;
            if (Convert.ToString(dr["VogelID"]) == null)
            {
                w = new Waarneming(
                Convert.ToInt32(dr["ID"]),
                Convert.ToDouble(dr["X"]),
                Convert.ToDouble(dr["Y"]),
                Convert.ToDateTime(dr["Date"]),
                Convert.ToInt32(dr["GebiedID"]),
                Convert.ToInt32(dr["AccountID"]),
                Convert.ToInt32(dr["SoortID"]),
                Convert.ToInt32(dr["ZoogdierID"]));
            }
            else
            {
                w = new Waarneming(
                Convert.ToDateTime(dr["Date"]),
                Convert.ToInt32(dr["ID"]),
                Convert.ToDouble(dr["X"]),
                Convert.ToDouble(dr["Y"]),
                Convert.ToInt32(dr["GebiedID"]),
                Convert.ToInt32(dr["AccountID"]),
                Convert.ToInt32(dr["VogelID"]),
                Convert.ToInt32(dr["SoortID"]));
            }


            return w;
        }
    }
}

