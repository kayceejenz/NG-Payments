using NGPayments.Entities;
using NGPayments.Gateways.Bank3D.Services;
using NGPayments.Gateways.Interswitch.Services;
using NGPayments.Gateways.Monnify.Services;
using NGPayments.Gateways.Remita.Services;
using NGPayments.Interfaces;

namespace NGPayments.Services
{
    public class PaymentFactory
    {

        /// <summary>
        ///     Get desired gateway instance
        /// </summary>
        /// <param name="gateway"></param>
        /// <returns> Gateway service instances</returns>
        public static IGateway GetGatewayInstance(PaymentGateway gateway)
        {           
            IGateway Instance = null;
            switch (gateway)
            {
                case PaymentGateway.INTERSWITCH:
                    Instance = new InterswitchService();
                    break;
                case PaymentGateway.MONNIFY:
                    Instance = new MonnifyService();
                    break;
                case PaymentGateway.REMITA:
                    Instance = new RemitaService();
                    break;
                case PaymentGateway.BANK3D:
                    Instance = new Bank3DService();
                    break;
            }
            return Instance;
        }
    }
}
