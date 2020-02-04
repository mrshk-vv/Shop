using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> getAllProducts { get; set; }


        public string searchResult { get; set; }
        public string currCategory { get; set; }
    }
}
