using System;
using System.ComponentModel.DataAnnotations;

namespace dotnet_ECommerce.Models
{
    public class OrderItems
    {
        public int ID { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// Navigational Properties
        /// </summary>
        public Order Order { get; set; }

        public Product Product { get; set; }
    }
}
