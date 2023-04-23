using NGPayments.Entities;
using NGPayments.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGPayments.Gateways.Bank3D.Services
{
    public class Bank3DService : IGateway
    {
        public Task<GatewayResponse> GenerateInvoice(GatewayRequest request)
        {
            throw new NotImplementedException();
        }

        Task<GatewayResponse> IGateway.CancelInvoice(GatewayRequest request)
        {
            throw new NotImplementedException();
        }

        Task<GatewayResponse> IGateway.CheckInvoiceStatus(GatewayRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
