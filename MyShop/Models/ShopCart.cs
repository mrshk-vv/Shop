using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Models
{
    public class ShopCart
    {
        private readonly DatabaseContent databaseContent;

        public string ShopCartId { get; set; }
        public List<ShopCartItem> listShopItems { get; set; }

        public ShopCart(DatabaseContent databaseContent)
        {
            this.databaseContent = databaseContent;
        }
        
        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DatabaseContent>();

            string shopCartId = session.GetString("cartId") ?? Guid.NewGuid().ToString();

            session.SetString("cartId", shopCartId);

            return new ShopCart(context) 
            { 
                ShopCartId = shopCartId 
            };
        }

        public void AddToCart(Product product)
        {
            databaseContent.ShopCartItem.Add
            (
                new ShopCartItem
                {
                    ShopCartId = ShopCartId,
                    product = product,
                    price = product.price
                }
             );
            databaseContent.SaveChanges();
        }

        public void RemoveFromCart(ShopCartItem  shopCartItem)
        {
            var delItem = new ShopCartItem
            {
                id = shopCartItem.id,
                product = shopCartItem.product,
                price = shopCartItem.price
            };
            databaseContent.ShopCartItem.Remove
            (
                delItem
             );

            databaseContent.SaveChanges();
        }
        public ShopCartItem Find(int id)
        {
            return databaseContent.ShopCartItem.AsNoTracking().FirstOrDefault(it => it.id == id);
        }

        public List<ShopCartItem> GetShopItems()
        {
            return databaseContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartId)
                                               .Include(s => s.product)
                                               .ToList();
        }
    }
}
