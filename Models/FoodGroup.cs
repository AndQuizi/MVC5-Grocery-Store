using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class FoodGroup
    {

        public int FoodGroupID { get; set; }

        [StringLength(255, MinimumLength = 3)]
        [Display(Name = "Food Group")]
        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }

    }
}
 