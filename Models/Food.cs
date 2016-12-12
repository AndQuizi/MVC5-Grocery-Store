using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Food
    {

        public int FoodID { get; set; }

        public int VendorID { get; set; }

        public int FoodGroupID { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        [Display(Name = "Item")]
        public String Name { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000 dollars.")]
        public Decimal Price { get; set; }

        public String Description { get; set; }

        [Range(0, 500, ErrorMessage = "Weight must be between 0 and 500 pounds.")]
        [Display(Name = "Weight (lb.)")]
        public Double Weight { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Expiry Date")]
        public DateTime ExpiryDate { get; set; }

        [Range(0, Int32.MaxValue)]
        public int Stock { get; set; }

        public string ImgName { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual FoodGroup FoodGroup { get; set; }

    }
}