using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.Extensions.Configuration;

namespace dotnet_ECommerce.Models
{
    public class PaymentManager : IPayment
    {
        public IConfiguration Configuration { get; }

        public PaymentManager(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public bool Run(decimal total)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = Configuration["AuthorizeNetLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = Configuration["AuthorizeNetTransactionKey"]
            };

            var creditCard = new creditCardType
            {
                cardNumber = "4111111111111111",
                expirationDate = "0723"
            };

            var billingAdress = new customerAddressType
            {
                firstName = "Josie",
                lastName = "Cat",
                address = "123 Catnip Lane",
                city = "meowsville",
                zip = "12345"
            };

            var paymentType = new paymentType { Item = creditCard };

            var transactionRequest = new transactionRequestType
            {
                transactionType = transactionTypeEnum.authCaptureTransaction.ToString(),
                amount = total,
                payment = paymentType,
                billTo = billingAdress
            };

            var request = new createTransactionRequest { transactionRequest = transactionRequest };

            var controller = new createTransactionController(request);
            controller.Execute();

            var response = controller.GetApiResponse();

            if (response != null)
            {
                if (response.messages.resultCode == messageTypeEnum.Ok)
                {
                    return true;
                }
            }
            else
            {
                if (response.transactionResponse.errors != null)
                {
                    return false;
                }
            }
            return false;
        }
    }
}
