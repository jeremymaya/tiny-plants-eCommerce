using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ECommerce.Models
{
    public class Email
    {
        public string ToEmail { get; set; }
        public string Subject {get; set;}
        public string Message { get; set; }
    }
}
