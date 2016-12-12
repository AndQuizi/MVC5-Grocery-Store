using GroceryStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GroceryStore.Models;
using GroceryStore.ViewModels;

namespace GroceryStore.Controllers
{
    public class ShoppingCartController : Controller
    {

        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            var cart = Cart.GetCart(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetCartTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
  
            var addedAlbum = db.Foods.Single(food => food.FoodID == id);

            var cart = Cart.GetCart(this.HttpContext);

            cart.AddToCart(addedAlbum);

            return RedirectToAction("Index");
        }
   
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
     
            var cart = Cart.GetCart(this.HttpContext);
            string foodName = db.CartItems.FirstOrDefault(item => item.FoodID == id).Food.Name;
            int itemCount = cart.RemoveFromCart(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(foodName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetCartTotal(),
                CartCount = cart.GetCartCount(),
                ItemCount = itemCount
            };
            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = Cart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCartCount();
            return PartialView("CartSummary");
        }

    }
}