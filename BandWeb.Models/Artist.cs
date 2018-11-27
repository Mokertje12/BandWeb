using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
{
    public class Artist
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string listeners { get; set; }
        public string image_path { get; set; }

        public Artist(string Name, string Desription, string Listeners, string Image_Path)
        {
            name = Name;
            description = Desription;
            listeners = Listeners;
            image_path = Image_Path;

        }
        public Artist()
        {

        }
    }
}
