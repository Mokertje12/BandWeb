using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.DAL.Contexts;
using BandWeb.DAL.Repositories;
using BandWeb.Logic.Interfaces;
using BandWeb.Logic.Logics;
using Microsoft.Extensions.Configuration;

namespace BandWeb.Factory
{
    public class ArtistFactory
    {
        private readonly IConfiguration _iconfiguration;

        public ArtistFactory(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }

        public static IArtistLogic CreateSqlLogic(IConfiguration configuration)
        {
            return new ArtistLogic(new ArtistRepository(new ArtistSqlContext(configuration)));
        }
    }
}
