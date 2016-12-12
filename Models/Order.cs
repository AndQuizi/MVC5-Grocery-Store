using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GroceryStore.Models
{
    public class Order
    {
        public Guid OrderID { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string Address { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string Country { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        public decimal Total { get; set; }

        [DataType(DataType.Date)]
        public System.DateTime OrderDate { get; set; }

        public List<CartItem> Cart { get; set; }

    }
}