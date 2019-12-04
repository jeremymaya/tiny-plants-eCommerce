using System;
namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IPayment
    {
        void Run(decimal total);
    }
}
