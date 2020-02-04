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
    public class ShopCartController : Controller
    {
        private readonly IProducts _products;
        private readonly ShopCart _shopCart;

        public ShopCartController(IProducts products,ShopCart shopCart)
        {
            _products = products;
            _shopCart = shopCart;
        }

        public ViewResult Index() 
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult AddToCart(int id)
        {
            var item = _products.Products.FirstOrDefault(i => i.id == id);

            if(item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCart(int id)
        {
            ShopCartItem item = _shopCart.Find(id);
            _shopCart.RemoveFromCart(item);


            return RedirectToAction("Index");
        }
    }
}

