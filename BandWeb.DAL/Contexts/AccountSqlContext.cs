using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.DAL.Base;
using BandWeb.DAL.Interfaces;
using BandWeb.Models;
using BandWeb.DAL.Contexts;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BandWeb.DAL.Contexts
{
    public class AccountSqlContext : BaseRepository, IAccountRepository
    {
        public AccountSqlContext(IConfiguration iconfiguration) : base(iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public void CreateUser(User user)
        {
            using (SqlConnection db = OpenConnection())
            {
                db.Open();
                SqlCommand cmd = db.CreateCommand();
                try
                {
                    cmd.Parameters.AddWithValue("@Name", user.name);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@Password", user.password);
                    cmd.Parameters.AddWithValue("@Streetname", user.streetname);
                    cmd.Parameters.AddWithValue("@Housenumber", user.housenumber);
                    cmd.Parameters.AddWithValue("@City", user.city);

                    cmd.CommandText =
                        "INSERT INTO [User] (name, email, password, streetname, housenumber, city) VALUES(@Name, @Email, @Password, @Streetname, @Housenumber, @City)";
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }
    }
}
