using NGPayments.Entities;
using NGPayments.Gateways.Monnify.Models;
using NGPayments.Handlers;
using NGPayments.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NGPayments.Gateways.Monnify.Services
{
    public class MonnifyService : IGateway
    {
        public const string baseUrl = "https://sandbox.monnify.com/api";
        private readonly RequestHandler _requestHandler;

        public MonnifyService()
        {
            this._requestHandler = new RequestHandler(baseUrl);
        }

        public async Task<GatewayResponse> GenerateInvoice(GatewayRequest request)
        {
            GatewayResponse Response = new GatewayResponse();
            MonnifyRequestBody payload = request.MonnifyRequest;
            MonnifyConfiguration configuration = payload.configuration;
            string authorizationString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.ApiKey}:{configuration.ClientSecret}"));
            string auth = $"Basic {authorizationString}";
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
            try
            {
                var response = await this._requestHandler.Post<MonnifyResponseBody, MonnifyRequestBody>("/v1/invoice/create", payload, headers);
                Response.MonnifyResponse = response;
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
            MonnifyRequestBody payload = request.MonnifyRequest;
            MonnifyConfiguration configuration = payload.configuration;
            string authorizationString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.ApiKey}:{configuration.ClientSecret}"));
            string auth = $"Basic {authorizationString}";
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
            try
            {
                var response = await this._requestHandler.Delete<MonnifyResponseBody>($"/v1/invoice/{payload.invoiceReference}/cancel", headers);
                Response.MonnifyResponse = response;
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
            MonnifyRequestBody payload = request.MonnifyRequest;
            MonnifyConfiguration configuration = payload.configuration;
            string authorizationString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{configuration.ApiKey}:{configuration.ClientSecret}"));
            string auth = $"Basic {authorizationString}";
            Dictionary<string, string> headers = new Dictionary<string, string>
            {
                { "Authorization", auth }
            };
            try
            {
                var response = await this._requestHandler.Get<MonnifyResponseBody>($"/v1/merchant/transactions/query?transactionReference={payload.transactionReference}", headers);
                Response.MonnifyResponse = response;
                return Response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
