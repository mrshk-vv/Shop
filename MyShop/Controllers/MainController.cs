using Microsoft.AspNetCore.Mvc;
using MyShop.Interfaces;
using MyShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class MainController : Controller
    {
        private readonly IProducts _products;

        public MainController(IProducts products)
        {
            _products = products;
        }

        public ViewResult Index()
        {
            var mainProducts = new MainViewModel
            {
                favProducts = _products.GetFavProducts
            };

            return View(mainProducts);
        }
    }
}
