using GroceryStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GroceryStore.Models
{
    public class Cart
    {
        private StoreContext db = new StoreContext();

        string CartID { get; set; }
        public const string CartSessionKey = "CartId";

        public static Cart GetCart(HttpContextBase context)
        {
            var cart = new Cart();
            cart.CartID = cart.GetCartId(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static Cart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(Food food)
        {

            var cartItem = db.CartItems.SingleOrDefault(
                c => c.CartID == CartID
                && c.FoodID == food.FoodID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    CartItemID = Guid.NewGuid(),
                    FoodID = food.FoodID,
                    CartID = CartID,
                    Count = 1,
                    DateAdded = DateTime.Now
                };
                db.CartItems.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Count++;
            }
  
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {

            // Get the cart item
            var cartItem = db.CartItems.FirstOrDefault(
               c => c.CartID == CartID
               && c.FoodID == id);

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
                    db.CartItems.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.CartItems.Where(
                cart => cart.CartID == CartID);

            foreach (var cartItem in cartItems)
            {
                db.CartItems.Remove(cartItem);
            }

 
            db.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return db.CartItems.Where(
                cart => cart.CartID == CartID).ToList();
        }

        public int GetCartCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.CartItems
                          where cartItems.CartID == CartID
                          select (int?)cartItems.Count).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public decimal GetCartTotal()
        {
            // Multiply food price by count of that food to get 
            // the current price for each of those foods in the cart
            // sum all food price totals to get the cart total
            decimal? total = (from cartItems in db.CartItems
                              where cartItems.CartID == CartID
                              select (int?)cartItems.Count *
                              cartItems.Food.Price).Sum();

            return total ?? decimal.Zero;
        }

        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                Guid tempCartId = Guid.NewGuid();
        
                context.Session[CartSessionKey] = tempCartId.ToString();
              
            }
            return context.Session[CartSessionKey].ToString();
        }
        
    }
}