using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.IO;
using BandWeb.DAL.Interfaces;
using BandWeb.Models;
using BandWeb.Logic.Interfaces;

namespace BandWeb.Logic.Logics
{
    public class ArtistLogic : IArtistLogic
    {
        private readonly IArtistRepository _artistrepo;
        public ArtistLogic(IArtistRepository artistRepo)
        {
            _artistrepo = artistRepo;
        }
        public IEnumerable<Artist> GetAllArtist()
        {
            List<Artist> artist = _artistrepo.GetAllArtist().AsList();
            return artist;
        }
        public List<Artist> GetDetailArtist(string id)
        {
            List<Artist> artist = _artistrepo.GetDetailArtist(id);
            return artist;
        }
        public void NewArtist(Artist art)
        {
            _artistrepo.NewArtist(art);
        }
    }
}
