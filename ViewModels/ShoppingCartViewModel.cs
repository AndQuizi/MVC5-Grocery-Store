﻿using GroceryStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroceryStore.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<CartItem> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}