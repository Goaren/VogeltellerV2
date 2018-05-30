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
    public class AccountSQLContext : IAccountContext
    {
        public Account InsertAccount(Account account)
        {
            using (SqlConnection conn = DatabaseConnection.Connection)
            {
                string query = "INSERT INTO ACCOUNT (Email, Voornaam, Achternaam, Wachtwoord, IsAdmin) VALUES (@email, @voornaam, @achternaam, @wachtwoord, @isadmin)";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@email", account.Email);
                    command.Parameters.AddWithValue("@voornaam", account.Voornaam);
                    command.Parameters.AddWithValue("@achternaam", account.Achternaam);
                    command.Parameters.AddWithValue("@wachtwoord", account.Wachtwoord);
                    command.Parameters.AddWithValue("@isadmin", account.IsAdmin);
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                    }
                }
                return account;
            }
        }
        public Account Login(string email, string wachtwoord)
        {
            SqlConnection connection = DatabaseConnection.Connection;

            //Check the state of the connection
            ConnectionState conState = connection.State;

            if (conState == ConnectionState.Open)
            {
                string query = "SELECT * FROM ACCOUNT WHERE Email = @email and Wachtwoord = @wachtwoord";
                using (connection)
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@wachtwoord", wachtwoord);
                    cmd.ExecuteScalar();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Account account = CreateAccountFromReader(reader);
                            return account;
                        }
                    }
                }
            }
            return null;
        }
        private Account CreateAccountFromReader(SqlDataReader reader)
        {
            return new Account(
                 Convert.ToInt32(reader["ID"]),
                 Convert.ToString(reader["Email"]),
                 Convert.ToString(reader["Voornaam"]),
                 Convert.ToString(reader["Achternaam"]),
                 Convert.ToString(reader["Wachtwoord"]),
                 Convert.ToBoolean(reader["IsAdmin"]));
        }
    }
}
