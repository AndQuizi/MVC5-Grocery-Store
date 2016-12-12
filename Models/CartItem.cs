using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class CartItem
    {

        public Guid CartItemID { get; set; }

        public int FoodID { get; set; }

        [Required]
        public String CartID { get; set; }

        [Range(1, Double.MaxValue)]
        public int Count { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual Food Food { get; set; }
    }
}