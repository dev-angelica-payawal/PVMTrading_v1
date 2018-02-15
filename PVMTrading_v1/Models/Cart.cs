using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PVMTrading_v1.Models
{
    public class PvMCart
    {
        [Key]
        public int Id { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }
        public int Count { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateCreated { get; set; }

        public virtual Product Product { get; set; }
    }

    public partial class PvMcarts
    {
        private ApplicationDbContext _context;
        ApplicationDbContext db = new ApplicationDbContext();
        public string PvmCartId { get; set; }
        public const string CartSessionKey = "CartId";

        public static PvMcarts GetCart(HttpContextBase context)
        {
            var cart = new PvMcarts();

            cart.PvmCartId = cart.GetCartId(context);

            return cart;
        }

        public static PvMcarts GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Product product)
        {
            var cartItem = db.Product.SingleOrDefault(c => c.CartId == PvmCartId && c.ProductId == product.Id);

            if (cartItem == null)
            {
                cartItem = new PvMCart
                {
                    ProductId = product.Id,
                    CartId = PvmCartId,
                    Count = 1,
                    DateCreated = DateTime.Now
                };
                db.Product.Add(cartItem);
            }
            else
            {
                cartItem.Count++;
            }

            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            var cartItem = db.Product.SingleOrDefault(cart => cart.CartId == PvmCartId && cart.ProductId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Count > 1)
                {
                    cartItem.Count--;
                    itemCount = cartItem.Count;
                }
                else
                {
                    db.Product.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.Product.Where(cart => cart.CartId == PvmCartId);

            foreach (var cartItem in cartItems)
            {
                db.Product.Remove(cartItem);
            }
            db.SaveChanges();
        }

        public List<PvMCart> GetCartItems()
        {
            return db.Product.Where(cart => cart.CartId == PvmCartId).ToList();
        }


        public int GetCount()
        {
            int? count =
                (from cartItems in db.Product where cartItems.CartId == PvmCartId select (int?)cartItems.Count).Sum();

            return count ?? 0;
        }

        public decimal GetTotal()
        {
            decimal? total = (from cartItems in db.Product
                where cartItems.CartId == PvmCartId
                              select (int?)cartItems.Count * cartItems.Product.AvailableForSelling).Sum();

            return total ?? decimal.Zero;
        }



        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }

                else
                {
                    Guid tempCartId = Guid.NewGuid();
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.Product.Where(c => c.CartId == PvmCartId);
            foreach (PvMCart item in shoppingCart)
            {
                item.CartId = userName;
            }

            db.SaveChanges();
        }
    }
}