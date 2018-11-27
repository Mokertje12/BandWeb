using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
{
    public class Order
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public decimal totalprice { get; set; }
        public Order()
        {

        }
    }
}
