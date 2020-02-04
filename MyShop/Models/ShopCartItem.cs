using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ShopCartItem
    {
        public int id { get; set; }
        public Product product { get; set; }
        public uint price { get; set; }

        public string ShopCartId { get; set; }
    }
}
