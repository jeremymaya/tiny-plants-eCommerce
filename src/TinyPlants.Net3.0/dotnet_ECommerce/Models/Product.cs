using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dotnet_ECommerce.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        public string Sku { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Description { get; set; }

        public string Image { get; set; }
        [Required]
        public bool IsFeatured { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
