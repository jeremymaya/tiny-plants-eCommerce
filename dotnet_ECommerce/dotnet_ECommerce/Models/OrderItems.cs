using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_ECommerce.Models
{
    public class OrderItems
    {
        public int ID { get; set; }

        public int OrderID{ get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string CreditCard { get; set; }

        public string Timestamp { get; set; }

        /// <summary>
        /// Navigational Properties
        /// </summary>
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
