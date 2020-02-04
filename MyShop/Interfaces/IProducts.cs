using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Interfaces
{
    public interface IProducts
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetFavProducts { get;}
        Product GetProduct(int productId);
    }
}
