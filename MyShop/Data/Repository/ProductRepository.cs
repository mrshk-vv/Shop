using Microsoft.EntityFrameworkCore;
using MyShop.Interfaces;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class ProductRepository : IProducts
    {
        private readonly DatabaseContent databaseContent;

        public ProductRepository(DatabaseContent databaseContent)
        {
            this.databaseContent = databaseContent;
        }

        public IEnumerable<Product> Products => 
            databaseContent.Products.Include(c => c.Category);

        public IEnumerable<Product> GetFavProducts => 
            databaseContent.Products.Where(p => p.isFavorite).Include(c => c.Category);


        public Product GetProduct(int productId) => 
            databaseContent.Products.FirstOrDefault(p => p.id == productId);
        
    }
}
