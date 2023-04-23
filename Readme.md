# `NG Payments`

SDK for interacting with different payment gateways supported on our services.

## Authors

- [Kaycee](https://www.github.com/preciouskosisochukwu)

## Badges

[![MIT License](https://img.shields.io/apm/l/atomic-design-ui.svg?)](https://github.com/tterb/atomic-design-ui/blob/master/LICENSEs)
[![GPLv3 License](https://img.shields.io/badge/License-GPL%20v3-yellow.svg)](https://opensource.org/licenses/)
[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)

## Supported Gateways

- Remita
- Monnify

## Core Features

- Invoice generation
- Cancel invoice
- Check invoice status

## ⭐️ `Star us`

If this NG Payments helps you - please star this project, every star makes us very happy!

## 🧭 Table of contents

- [`NG Payments`](#ng-payments)
- [🧭 Table of contents](#-table-of-contents)
- [🚦 Core Features](#core-features)
  - [`Remita`](#remita)
    - [`Generate Invoice`](#remita-generation-invoice)
    - [`Cancel Invoice`](#remita-cancel-invoice)
    - [`Check Invoice Status`](#remita-check-invoice-status)
  - [`Monnify`](#monnify)
    - [`Generate Invoice`](#monnify-generation-invoice)
    - [`Cancel Invoice`](#monnify-cancel-invoice)
    - [`Check Invoice Status`](#monnify-check-invoice-status)

## 🎯 Core Features

### Remita

#### Remita Generation Invoice

You can generation a remita invoice from the remita payment gateway provider by create our remita payment service instance using our payment factory

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Services;

   public class RemitaPayments
    {

     // Defining the remita configuration properties using our `RemitaConfiguration` class
        private readonly RemitaConfiguration configuration = new RemitaConfiguration()
        {
            MerchantId = "2547916", // Demo Merchant ID
            ServiceTypeId = "4430731", // Demo Service Type ID
            ApiKey = "1946", // Demo Api Key
        };

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

        // Get the remita payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);

        // Generate remita payment invoice
        var response = await paymentService.GenerateInvoice(gatewayRequest);
    }

```

#### Remita Cancel Invoice

You can cancel an already generated invoice on remita with `RRR`

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Services;

   public class RemitaPayments
    {

     // Defining the remita configuration properties using our `RemitaConfiguration` class
        private readonly RemitaConfiguration configuration = new RemitaConfiguration()
        {
            MerchantId = "2547916", // Demo Merchant ID
            ServiceTypeId = "4430731", // Demo Service Type ID
            ApiKey = "1946", // Demo Api Key
        };

        // Defining the invoice cancellation payload
        RemitaRequestBody payload = new RemitaRequestBody
        {
            configuration = this.configuration,
            rrr = "190010144722", // generated RRR
        };

        // Get the remita payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);

        // Cancel remita payment invoice
        var response = await paymentService.CancelInvoice(gatewayRequest);
    }
```

#### Remita Check Invoice Status

You can check the status of an already generated invoice using the `orderId` or `RRR`

##### Using order Id

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Services;

   public class RemitaPayments
    {

        // Defining the remita configuration properties using our `RemitaConfiguration` class
        private readonly RemitaConfiguration configuration = new RemitaConfiguration()
        {
            MerchantId = "2547916", // Demo Merchant ID
            ServiceTypeId = "4430731", // Demo Service Type ID
            ApiKey = "1946", // Demo Api Key
        };

        // Defining the invoice status checker payload
        RemitaRequestBody payload = new RemitaRequestBody
        {
            configuration = this.configuration,
            orderId = "3b53f4f3dc824658aa8a827d4bd3ddae", // generated order Id
        };

        // Get the remita payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);

        // Check remita payment invoice status
        var response = await paymentService.CheckInvoiceStatus(gatewayRequest);
    }
```

##### Using RRR

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Services;

   public class RemitaPayments
    {

        // Defining the remita configuration properties using our `RemitaConfiguration` class
        private readonly RemitaConfiguration configuration = new RemitaConfiguration()
        {
            MerchantId = "2547916", // Demo Merchant ID
            ServiceTypeId = "4430731", // Demo Service Type ID
            ApiKey = "1946", // Demo Api Key
        };

        // Defining the invoice status checker payload
        RemitaRequestBody payload = new RemitaRequestBody
        {
            configuration = this.configuration,
            rrr = "190010144722", // generated RRR
        };

        // Get the remita payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.REMITA);

        // Check remita payment invoice status
        var response = await paymentService.CheckInvoiceStatus(gatewayRequest);
    }
```

### Monnify

#### Monnify Generation Invoice

You can generation a monnify invoice from the monnify payment gateway provider by create our monnify payment service instance using our payment factory

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Monnify.Models;
using NGPayments.Services;

   public class MonnifyPayments
    {

        // Defining the monnify configuration properties using our `MonnifyConfiguration` class
        private readonly MonnifyConfiguration configuration = new MonnifyConfiguration
        {
            ApiKey = "MK_TEST_MT3NUVU3KR",
            ClientSecret = "DFD6CQLLX8TD9U4YACCSJSWQ9CRU4B7Y",
            ContractCode = "6424247297"
        };

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

        // Get the monnify payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);

        // Generate monnify payment invoice
        var response = await paymentService.GenerateInvoice(gatewayRequest);
    }
```

#### Monnify Cancel Invoice

You can cancel an already generated invoice on monnify with the `transactionReference`

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Monnify.Models;
using NGPayments.Services;

   public class MonnifyPayments
    {

        // Defining the monnify configuration properties using our `MonnifyConfiguration` class
        private readonly MonnifyConfiguration configuration = new MonnifyConfiguration
        {
            ApiKey = "MK_TEST_MT3NUVU3KR",
            ClientSecret = "DFD6CQLLX8TD9U4YACCSJSWQ9CRU4B7Y",
            ContractCode = "6424247297"
        };

        // Defining the invoice cancellation payload
        MonnifyRequestBody payload = new MonnifyRequestBody
        {
            configuration = this.configuration,
            transactionReference = "MNFY|61|20230203144234|000011"
        };

        GatewayRequest gatewayRequest = new GatewayRequest()
        {
            MonnifyRequest = payload,
        };

        // Get the monnify payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);

        // Cancel monnify payment invoice
        var response = await paymentService.CancelInvoice(gatewayRequest);
    }
```

#### Monnify Check Invoice Status

You can check the status of an already generated invoice using the `transactionReference`

```cs
using NGPayments.Entities;
using NGPayments.Gateways.Monnify.Models;
using NGPayments.Services;

   public class MonnifyPayments
    {

        // Defining the monnify configuration properties using our `MonnifyConfiguration` class
        private readonly MonnifyConfiguration configuration = new MonnifyConfiguration
        {
            ApiKey = "MK_TEST_MT3NUVU3KR",
            ClientSecret = "DFD6CQLLX8TD9U4YACCSJSWQ9CRU4B7Y",
            ContractCode = "6424247297"
        };

        // Defining the invoice cancellation payload
        MonnifyRequestBody payload = new MonnifyRequestBody
        {
            configuration = this.configuration,
            transactionReference = "MNFY|61|20230203144234|000011"
        };

        GatewayRequest gatewayRequest = new GatewayRequest()
        {
            MonnifyRequest = payload,
        };

        // Get the monnify payment service instance
        var paymentService = PaymentFactory.GetGatewayInstance(PaymentGateway.MONNIFY);

        // Check monnify payment invoice status
        var response = await paymentService.CheckInvoiceStatus(gatewayRequest);
    }
```
