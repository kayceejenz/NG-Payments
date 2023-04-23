using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGPayments.Test.Gateways
{
    [TestClass]
    public class RemitaPayments
    {
     
        private readonly RemitaConfiguration configuration = new RemitaConfiguration()
        {
            MerchantId = "2547916", // Demo Merchant ID
            ServiceTypeId = "4430731", // Demo Service Type ID
            ApiKey = "1946", // Demo Api Key
        };

        [TestMethod]
        public async Task GenerateStandardInvoice()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                serviceTypeId = configuration.ServiceTypeId,
                amount = "2000",
                orderId = Guid.NewGuid().ToString().Replace("-",""),
                payerName = "john doe",
                payerEmail = "doe@gmail.com",
                payerPhone = "09062067384",
                description = "payment for septmeber fees"
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.GenerateInvoice(gatewayRequest);

            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Status, "Payment Reference generated");
            Assert.IsNotNull(response.RemitaResponse.Rrr);

        }

        [TestMethod]
        public async Task GenerateSplitPaymentInvoice()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                serviceTypeId = configuration.ServiceTypeId,
                amount = "2000",
                orderId = Guid.NewGuid().ToString(),
                payerName = "John Doe",
                payerEmail = "doe@gmail.com",
                payerPhone = "09062067384",
                description = "Payment for Septmeber Fees",
                //lineItems = new LineItems[] {
                //    new LineItems
                //    {
                //        lineItemId = "",
                //        beneficiaryAccount ="",
                //        beneficiaryName = "",
                //        beneficiaryAmount = "",
                //        bankCode = "",
                //        deductFeeFrom = ""
                //    },
                //    new LineItems
                //    {
                //        lineItemId = "",
                //        beneficiaryAccount ="",
                //        beneficiaryName = "",
                //        beneficiaryAmount = "",
                //        bankCode = "",
                //        deductFeeFrom = ""
                //    }
                //}
            };

            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.GenerateInvoice(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Status, "Payment Reference generated");
            Assert.IsNotNull(response.RemitaResponse.Rrr);
        }

        [TestMethod]
        public async Task GenerateCustomFieldInvoice()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                serviceTypeId = configuration.ServiceTypeId,
                amount = "2000",
                orderId = Guid.NewGuid().ToString(),
                payerName = "John Doe",
                payerEmail = "doe@gmail.com",
                payerPhone = "09062067384",
                description = "Payment for Septmeber Fees",
                customFields = new List<object>() {
                    new
                    {
                        Name = "",
                        Value = "",
                        Type = ""
                    },
                     new
                    {
                        Name = "",
                        Value = "",
                        Type = ""
                    }
                }
            };

            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.GenerateInvoice(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.RemitaResponse.Status, "Payment Reference generated");
            Assert.IsNotNull(response.RemitaResponse.Rrr);
        }

        [TestMethod]
        public async Task GenerateCustomFieldAndSplitPaymentInvoice()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                serviceTypeId = configuration.ServiceTypeId,
                amount = "2000",
                orderId = Guid.NewGuid().ToString(),
                payerName = "John Doe",
                payerEmail = "doe@gmail.com",
                payerPhone = "09062067384",
                description = "Payment for Septmeber Fees",
                customFields = new List<object>() {
                    new
                    {
                        Name = "",
                        Value = "",
                        Type = ""
                    },
                     new
                    {
                        Name = "",
                        Value = "",
                        Type = ""
                    }
                },
                //lineItems = new LineItems[] {
                //    new LineItems
                //    {
                //        lineItemId = "",
                //        beneficiaryAccount ="",
                //        beneficiaryName = "",
                //        beneficiaryAmount = "",
                //        bankCode = "",
                //        deductFeeFrom = ""
                //    },
                //    new LineItems
                //    {
                //        lineItemId = "",
                //        beneficiaryAccount ="",
                //        beneficiaryName = "",
                //        beneficiaryAmount = "",
                //        bankCode = "",
                //        deductFeeFrom = ""
                //    }
                //}
            };

            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.GenerateInvoice(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Status, "Payment Reference generated");
            Assert.IsNotNull(response.RemitaResponse.Rrr);
        }

        [TestMethod]
        public async Task CheckInvoiceStatusWithOrderID()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                orderId = "3b53f4f3dc824658aa8a827d4bd3ddae",
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.CheckInvoiceStatus(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Status, "022");
        }
        [TestMethod]
        public async Task CheckInvoiceStatusWithRRR()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                rrr = "190010144722",
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.CheckInvoiceStatus(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Status, "059");
        }

        [TestMethod]
        public async Task CancelInvoice()
        {
            RemitaRequestBody payload = new RemitaRequestBody
            {
                configuration = this.configuration,
                rrr = "190010144722",
            };
            GatewayRequest gatewayRequest = new GatewayRequest()
            {
                RemitaRequest = payload,
            };

            var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);
            var response = await paymentService.CancelInvoice(gatewayRequest);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.RemitaResponse);
            Assert.AreEqual(response.RemitaResponse.Statuscode, "02");
        }
    }
}
