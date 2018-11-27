using System;
using System.Collections.Generic;
using System.Text;
using BandWeb.Models;

namespace BandWeb.Logic.Interfaces
{
    public interface IArtistLogic
    {
        IEnumerable<Artist> GetAllArtist();
        Artist GetDetailArtist(string id);
        void NewArtist(Artist art);
    }
}
