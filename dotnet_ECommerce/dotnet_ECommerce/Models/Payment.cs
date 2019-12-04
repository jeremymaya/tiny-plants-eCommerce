using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers.Bases;
using dotnet_ECommerce.Models.Interfaces;
using Microsoft.Extensions.Configuration;

namespace dotnet_ECommerce.Models
{
    public class Payment : IPayment
    {
        private readonly IConfiguration _configuration;

        public Payment(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Run(decimal total)
        {
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = _configuration["AuthorizeNetLoginID"],
                ItemElementName = ItemChoiceType.transactionKey,
                Item = _configuration["AuthorizeNetTransactionKey"]
            };

        }
    }
}
