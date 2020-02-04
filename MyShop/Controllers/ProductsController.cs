using Microsoft.AspNetCore.Mvc;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProducts _products;
        private readonly IProductsCategory _productsCategory;

        public ProductsController(IProducts products,IProductsCategory productsCategory)
        {
            _products = products;
            _productsCategory = productsCategory;
        }


        [Route("Products/List")]
        [Route("Products/List/{category?}")]
        public ViewResult List(string category)
        {
            string _category = category;

            IEnumerable<Product> products = null;
            string currCategory = "";

            if (string.IsNullOrEmpty(category))
            {
                products = _products.Products.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("phones", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.Products.Where(i => i.Category.categoryName == "Мобильные телефоны").OrderBy(i => i.id);
                    currCategory = "Мобильные телефоны";
                }
                if (string.Equals("televisors", category, StringComparison.OrdinalIgnoreCase))
                {
                    products = _products.Products.Where(i => i.Category.categoryName == "Телевизоры").OrderBy(i => i.id);
                    currCategory = "Телевизоры";
                }
            }

            var prodObj = new ProductListViewModel
            {
                getAllProducts = products,
                currCategory = currCategory
            };

            return View(prodObj);
        }

        [HttpPost]
        public async Task<IActionResult> Search(string prodName)
        {
            IEnumerable<Product> products = null;
            string resultSearch = "";


            if (string.IsNullOrEmpty(prodName))
            {
                products = _products.Products.OrderBy(i => i.id);
            }
            else
            {
                products = _products.Products.Where(n => n.name.Contains(prodName));
            }
            var prodObj = new ProductListViewModel
            {
                getAllProducts = products,
                searchResult = prodName
            };
            return View(prodObj);
        }
    }
}
