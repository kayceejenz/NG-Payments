using NGPayments.Entities;
using System.Threading.Tasks;

namespace NGPayments.Interfaces
{
    public interface IGateway
    {
        /// <summary>
        ///     Generate gateway payment invoice
        /// </summary>
        /// <param name="request"> payload</param>
        /// <returns>Gateway generated invoice</returns>
        Task<GatewayResponse> GenerateInvoice(GatewayRequest request);


        /// <summary>
        ///     Generate gateway payment invoice
        /// </summary>
        /// <param name="request"> payload</param>
        /// <returns>Gateway generated invoice</returns>
        Task<GatewayResponse> CancelInvoice(GatewayRequest request);


        /// <summary>
        ///     Generate gateway payment invoice
        /// </summary>
        /// <param name="request"> payload</param>
        /// <returns>Gateway generated invoice</returns>
        Task<GatewayResponse> CheckInvoiceStatus(GatewayRequest request);
    }
}
