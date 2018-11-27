using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.Models;

namespace BandWeb.DAL.Interfaces
{
    public interface IArtistRepository
    {
        IEnumerable<Artist> GetAllArtist();
        Artist GetDetailArtist(string id);
        void NewArtist(Artist art);
    }
}
