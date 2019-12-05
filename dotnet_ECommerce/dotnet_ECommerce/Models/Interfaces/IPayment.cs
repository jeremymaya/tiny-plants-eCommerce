using AuthorizeNet.Api.Contracts.V1;
using System;

namespace dotnet_ECommerce.Models.Interfaces
{
    public interface IPayment
    {
        bool Run(decimal total, creditCardType creditCard, customerAddressType billingAdress, paymentType paymentType);
    }
}
