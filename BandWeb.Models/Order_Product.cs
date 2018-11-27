using System;
using System.Collections.Generic;
using System.Text;

namespace BandWeb.Models
{
    public class Order_Product
    {
        public int product_id { get; set; }
        public int order_id { get; set; }
        public decimal quantity { get; set; }
        public Order_Product()
        {

        }
    }
}
