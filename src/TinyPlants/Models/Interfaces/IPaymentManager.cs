using System;
using AuthorizeNet.Api.Contracts.V1;

namespace TinyPlants.Models.Interfaces;

public interface IPaymentManager
{
    bool Run(double total, creditCardType creditCard, customerAddressType billingAdress);
}
