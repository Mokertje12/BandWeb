using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandWeb.Models;

namespace BandWeb.Models.ViewModels
{
    public class ArtistDetailViewModel
    {
        public List<Artist> Artist { get; set; }

        public Artist artist { get; set; }
    }
}
