using System;
using AuthorizeNet.Api.Contracts.V1;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IPayment
    {
        bool Run(double total);
    }
}
