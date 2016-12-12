using GroceryStore.DAL;
using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Controllers
{
    public class CheckoutController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult CreateOrder()
        {
            return View();
        }
    
        [HttpPost, ActionName("CreateOrder")]
        public ActionResult CreateOrderPost()
        {
            var order = new Order();

            if (TryUpdateModel(order, "",
               new string[] { "FirstName", "LastName", "Address",  "City", "PostalCode", "Country", "Phone", "Email"}))
            {
                try
                {
                    var cart = Cart.GetCart(this.HttpContext);
                    decimal orderTotal = 0;
                    var cartItems = cart.GetCartItems();

                    foreach (var item in cartItems)
                    {
                        orderTotal += (item.Count * item.Food.Price);
                    }

                    order.OrderDate = DateTime.Now;
                    order.Cart = cartItems;
                    order.Total = orderTotal;

                    db.SaveChanges();
                    cart.EmptyCart();

                }
                catch 
                {
                    return View(order);
                }
            }
            return RedirectToAction("Complete", new { id = order.OrderID });

        }

        public ActionResult Complete(Guid id)
        {
            bool isValid = db.Orders.Any(
                o => o.OrderID == id);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
        

    }
}
