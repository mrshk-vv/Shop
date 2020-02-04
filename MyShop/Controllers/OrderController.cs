using Microsoft.AspNetCore.Mvc;
using MyShop.Interfaces;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Controllers
{
    public class OrderController : Controller
    {
        public readonly IAllOrders _orders;
        public readonly ShopCart _shopCart;

        public OrderController(IAllOrders orders, ShopCart shopCart)
        {
            _orders = orders;
            _shopCart = shopCart;
        }


        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.listShopItems = _shopCart.GetShopItems();

            if(_shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас нет товаров");
            }
            else
            {
                _orders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Massage = "Заказ успешно обработан";
            return View();
        }
    }
}
