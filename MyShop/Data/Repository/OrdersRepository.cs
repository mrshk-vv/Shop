using MyShop.Interfaces;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        public readonly DatabaseContent databaseContent;
        public readonly ShopCart _shopCart;

        public OrdersRepository(DatabaseContent databaseContent,ShopCart shopCart)
        {
            this.databaseContent = databaseContent;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            databaseContent.Order.Add(order);
            databaseContent.SaveChanges();

            var items = _shopCart.listShopItems;

            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    productId = el.product.id,
                    orderId = order.id,
                    price = el.product.price
                };
                databaseContent.OrderDetail.Add(orderDetail);
            }
            databaseContent.SaveChanges();
        }   
    }
}
