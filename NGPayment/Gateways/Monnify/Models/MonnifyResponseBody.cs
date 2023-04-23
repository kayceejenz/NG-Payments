
namespace NGPayments.Gateways.Monnify.Models
{
    public class MonnifyResponseBody : BaseResponse
    {
        public MonnifyRequestBody ResponseBody { get; set; }
    }
    public class BaseResponse
    {
        public bool RequestSuccessful { get; set; }
        public string ResponseMessage { get; set; }
        public string ResponseCode { get; set; }
    }
}
