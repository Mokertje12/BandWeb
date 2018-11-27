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
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = "SELECT * FROM dbo.Artist";
                return db.Query<Artist>(query);
            }
        }
        public Artist GetDetailArtist(string id)
        {
            using (IDbConnection db = OpenConnection())
            {
                db.Open();
                string query = $"SELECT * FROM Artist WHERE id = {id}";
                return db.QuerySingle<Artist>(query);
            }
        }
        public void NewArtist(Artist art)
        {
            using (IDbConnection db = OpenConnection())
            {
                    string Query =
                        $"INSERT INTO Artist VALUES('{art.name}', '{art.description}', '{art.listeners}', '{art.image_path}')";
                    db.Execute(Query);
            }
        }
    }
}
