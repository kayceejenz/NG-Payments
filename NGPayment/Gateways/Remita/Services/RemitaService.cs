using NGPayments.Entities;
using NGPayments.Gateways.Remita.Models;
using NGPayments.Handlers;
using NGPayments.Helpers;
using NGPayments.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NGPayments.Gateways.Remita.Services
{
    public class RemitaService : IGateway
    {
        private const string baseUrl = "https://remitademo.net/remita/exapp/api/v1/send/api";

        private readonly RequestHandler _requestHandler;

        public RemitaService()
        {
            this._requestHandler = new RequestHandler(baseUrl);
        }

        public async Task<GatewayResponse> GenerateInvoice(GatewayRequest request)
        {
            GatewayResponse Response = new GatewayResponse();
            RemitaRequestBody payload = request.RemitaRequest;
            RemitaConfiguration configuration = payload.configuration;
            string authorizationString = $"{configuration.MerchantId}{configuration.ServiceTypeId}{payload.orderId}{payload.amount}{configuration.ApiKey}";
            string auth = $"remitaConsumerKey={configuration.MerchantId},remitaConsumerToken={Encryption.SHA512(authorizationString)}";
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
            try
            {
                var response = await this._requestHandler.Post<RemitaResponseBody, RemitaRequestBody>("/echannelsvc/merchant/api/paymentinit", payload, headers);
                Response.RemitaResponse = response;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GatewayResponse> CancelInvoice(GatewayRequest request)
        {
            GatewayResponse Response = new GatewayResponse();
            RemitaRequestBody payload = request.RemitaRequest;
            RemitaConfiguration configuration = payload.configuration;
            string authorizationString = $"{payload.rrr}{configuration.ApiKey}{configuration.MerchantId}";
            string apiHash = Encryption.SHA512(authorizationString);
            string auth = $"remitaConsumerKey={configuration.MerchantId},remitaConsumerToken={apiHash}";
            payload.merchantId = configuration.MerchantId;
            payload.hash = apiHash;
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
            try
            {
                var response = await this._requestHandler.Post<RemitaResponseBody, RemitaRequestBody>("/echannelsvc/v2/api/deactivate.json", payload, headers);
                Response.RemitaResponse = response;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GatewayResponse> CheckInvoiceStatus(GatewayRequest request)
        {
            GatewayResponse Response = new GatewayResponse();
            RemitaRequestBody payload = request.RemitaRequest;
            RemitaConfiguration configuration = payload.configuration;
            if (!string.IsNullOrEmpty(payload.rrr))
            {
                string authorizationString = $"{payload.rrr}{configuration.ApiKey}{configuration.MerchantId}";
                string apiHash = Encryption.SHA512(authorizationString);
                string auth = $"remitaConsumerKey={configuration.MerchantId},remitaConsumerToken={apiHash}";
                Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
                try
                {
                    var response = await this._requestHandler.Get<RemitaResponseBody>($"/echannelsvc/{configuration.MerchantId}/{payload.rrr}/{apiHash}/status.reg", headers);
                    Response.RemitaResponse = response;
                    return Response;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else if (!string.IsNullOrEmpty(payload.orderId))
            {
                string authorizationString = $"{payload.orderId}{ configuration.ApiKey}{configuration.MerchantId}";
                string apiHash = Encryption.SHA512(authorizationString);
                string auth = $"remitaConsumerKey={configuration.MerchantId},remitaConsumerToken={apiHash}";
                Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
                try
                {
                    var response = await this._requestHandler.Get<RemitaResponseBody>($"/echannelsvc/{configuration.MerchantId}/{payload.orderId}/{apiHash}/orderstatus.reg", headers);
                    Response.RemitaResponse = response;
                    return Response;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else throw new ArgumentException("No orderId or RRR provided");
        }
    }
}