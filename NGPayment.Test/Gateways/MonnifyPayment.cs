using NGPayments.Entities;
using NGPayments.Gateways.Monnify.Models;
using NGPayments.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace NGPayments.Test.Gateways
{
    [TestClass]
    public class MonnifyPayment
    {
        private readonly MonnifyConfiguration configuration = new MonnifyConfiguration
        {
            ApiKey = "MK_TEST_MT3NUVU3KR",
            ClientSecret = "DFD6CQLLX8TD9U4YACCSJSWQ9CRU4B7Y",
            ContractCode = "6424247297"
        };

        [TestMethod]
        public async Task GenerateInvoice()
        {
            MonnifyRequestBody payload = new MonnifyRequestBody
            {
                configuration = this.configuration,
                amount = "2000",
                invoiceReference = Guid.NewGuid().ToString().Replace("-", ""),
                contractCode = configuration.ContractCode,
                currencyCode = "NGN",
                paymentMethods = new string[] { "ACCOUNT_TRANSFER","CARD" },
                customerName = "john doe",
                customerEmail = "doe@gmail.com",
                customerUniqueId = "09062067384",
                description = "payment for septmeber fees",
                expiryDate = DateTime.Now.AddDays(1).ToString("yyy-MM-dd HH:mm:ss"),
                redirectUrl = "http:localhost:2000"
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                MonnifyRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);
            var response = await paymentService.GenerateInvoice(gatewayRequest);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.MonnifyResponse);
            Assert.AreEqual(response.MonnifyResponse.RequestSuccessful, true);
            Assert.AreEqual(response.MonnifyResponse.ResponseCode, "0");
            Assert.AreEqual(response.MonnifyResponse.ResponseMessage, "success");
        }
        [TestMethod]
        public async Task CheckInvoiceStatus()
        {
            MonnifyRequestBody payload = new MonnifyRequestBody
            {
                configuration = this.configuration,
                transactionReference = "MNFY|61|20230203144234|000011"
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                MonnifyRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);
            var response = await paymentService.CheckInvoiceStatus(gatewayRequest);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.MonnifyResponse);
            Assert.AreEqual(response.MonnifyResponse.RequestSuccessful, true);
            Assert.AreEqual(response.MonnifyResponse.ResponseCode, "0");
            Assert.AreEqual(response.MonnifyResponse.ResponseMessage, "success");
        }
        [TestMethod]
        public async Task CancelInvoice()
        {
            MonnifyRequestBody payload = new MonnifyRequestBody
            {
                configuration = this.configuration,
                invoiceReference = "9bea927007fe4a98a059c3740e224b57"
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                MonnifyRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);
            var response = await paymentService.CancelInvoice(gatewayRequest);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.MonnifyResponse);
            //Assert.AreEqual(response.MonnifyResponse.RequestSuccessful, true);
            //Assert.AreEqual(response.MonnifyResponse.ResponseCode, "0");
            //Assert.AreEqual(response.MonnifyResponse.ResponseMessage, "success");
        }
    }
}
