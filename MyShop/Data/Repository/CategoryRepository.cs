using MyShop.Interfaces;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class CategoryRepository : IProductsCategory
    {
        public readonly DatabaseContent databaseContent;

        public CategoryRepository(DatabaseContent databaseContent)
        {
            this.databaseContent = databaseContent;
        }

        public IEnumerable<Category> AllCategories => databaseContent.Category;
    }
}
