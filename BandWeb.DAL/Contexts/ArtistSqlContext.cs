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
    public class ArtistSqlContext : BaseRepository, IArtistRepository
    {
        public ArtistSqlContext(IConfiguration iconfiguration): base(iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        public IEnumerable<Artist> GetAllArtist()
        {
            List<Artist> artistlist = new List<Artist>();
            using (SqlConnection db = OpenConnection())
            {
                db.Open();
                SqlCommand cmd = db.CreateCommand();
                try
                {
                    cmd.CommandText =
                        "SELECT * FROM dbo.Artist";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string imagePath = "/images/" + reader.GetString(4);
                                artistlist.Add(new Artist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), imagePath));

                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return artistlist;
        }
        public List<Artist> GetDetailArtist(string id)
        {
            List<Artist> artistlist = new List<Artist>();
            using (SqlConnection db = OpenConnection())
            {
                db.Open();
                SqlCommand cmd = db.CreateCommand();
                try
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    cmd.CommandText =
                        "SELECT * FROM Artist WHERE id = @ID";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                string imagePath = "/images/" + reader.GetString(4);
                                artistlist.Add(new Artist(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), imagePath));
                                
                            }
                        }
                    }
                }
                catch
                {

                }
            }
            return artistlist;
        }
        public void NewArtist(Artist art)
        {
            using (SqlConnection db = OpenConnection())
            {
                db.Open();
                SqlCommand cmd = db.CreateCommand();
                try
                {
                    cmd.Parameters.AddWithValue("@Name", art.name);
                    cmd.Parameters.AddWithValue("@Description", art.description);
                    cmd.Parameters.AddWithValue("@Listeners", art.listeners);
                    cmd.Parameters.AddWithValue("@Image_Path", art.image_path);

                    cmd.CommandText = 
                        "INSERT INTO Artist (name, description, listeners, image_path) VALUES(@Name, @Description, @Listeners, @Image_Path)";
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                }
            }
        }
    }
}
