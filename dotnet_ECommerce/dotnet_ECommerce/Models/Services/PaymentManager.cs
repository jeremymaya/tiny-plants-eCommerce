using System;
using System.Collections.Generic;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.Extensions.Configuration;

namespace dotnet_ECommerce.Models
{
    public class PaymentManager : IPayment
    {
        private readonly IConfiguration _configuration;
        //public IConfiguration Configuration { get; }
        public PaymentManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool Run(decimal total, creditCardType creditCard, customerAddressType billingAdress, paymentType paymentType)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthorizeNetLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthorizeNetTransactionKey"]
            };

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
                    Console.WriteLine("Success, Auth Code : " + response.transactionResponse.authCode);
                    return true;
                }
            }
            else
            {
                if (response.transactionResponse.errors != null)
                {
                    Console.WriteLine("Transaction Error : " + response.transactionResponse.errors[0].errorCode + " " + response.transactionResponse.errors[0].errorText);
                    return false;
                }
            }
            return false;
        }
    }
}
