using NGPayments.Gateways.Monnify.Models;
using NGPayments.Gateways.Remita.Models;

namespace NGPayments.Entities
{
    public class GatewayRequest
    {
        public RemitaRequestBody RemitaRequest { get; set; }
        public MonnifyRequestBody MonnifyRequest { get; set; }
    }
}
