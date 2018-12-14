using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.DAL.Interfaces;
using BandWeb.Models;
namespace BandWeb.DAL.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly IArtistRepository _iartistRepository;
        public ArtistRepository(IArtistRepository iartistRepository)
        {
            _iartistRepository = iartistRepository;
        }
        public IEnumerable<Artist> GetAllArtist()
        {
            return _iartistRepository.GetAllArtist();
        }
        public List<Artist> GetDetailArtist(string id)
        {
            return _iartistRepository.GetDetailArtist(id);
        }
        public void NewArtist(Artist art)
        {
            _iartistRepository.NewArtist(art);
        }
    }
}
