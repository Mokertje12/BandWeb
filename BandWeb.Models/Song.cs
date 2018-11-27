using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
{
    public class Song
    {
        public int id { get; set; }
        public string name { get; set; }
        public int album_id { get; set; }
        public int artist_id { get; set; }
        public Song()
        {

        }
    }
}
