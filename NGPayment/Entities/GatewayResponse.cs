using NGPayments.Gateways.Monnify.Models;
using NGPayments.Gateways.Remita.Models;

namespace NGPayments.Entities
{
    public class GatewayResponse
    {
        public RemitaResponseBody RemitaResponse { get; set; }
        public MonnifyResponseBody MonnifyResponse { get; set; }
    }
}
