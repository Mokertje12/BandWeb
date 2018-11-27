using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using BandWeb;
using Microsoft.Extensions.Options;
using BandWeb.Models;
using Microsoft.Extensions.Configuration;

namespace BandWeb.DAL.Base
{
    public abstract class BaseRepository
    {
        protected IConfiguration _iconfiguration;
        public BaseRepository(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }

        //public string Connection()
        //{
        //    return _serviceSettings.Value.DefaultConnection;
        //}

        

        public SqlConnection OpenConnection()
        {
            string conn = _iconfiguration.GetConnectionString("DefaultConnection");

            return new SqlConnection(conn);
        }

    }
}