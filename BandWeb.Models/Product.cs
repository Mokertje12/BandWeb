using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public int category_id { get; set; }
        public int artist_id { get; set; }
        public Product()
        {

        }
    }
}
