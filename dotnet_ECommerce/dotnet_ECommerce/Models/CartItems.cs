using System;
namespace dotnet_ECommerce.Models
{
    public class CartItems
    {
        public int ID { get; set; }

        public int CartID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        // Navigational Properties
        public Cart Cart { get; set; }

        public Product Product { get; set; }
    }
}
