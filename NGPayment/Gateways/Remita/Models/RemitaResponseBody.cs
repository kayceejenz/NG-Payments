
using System.Runtime.Serialization;

namespace NGPayments.Gateways.Remita.Models
{

    /// <summary>
    /// Represents reply gotten from remita for every transaction
    /// </summary>
    public class RemitaResponseBody
    {

        /// <summary>
        /// Status of every transaction indicating if the transaction was a success or failure
        /// </summary>
        [DataMember(Name = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Status Code
        /// </summary>
        [DataMember(Name = "statuscode")]
        public string Statuscode { get; set; }

        
        /// <summary>
        /// Remita Reference generated for every transaction
        /// </summary>
        [DataMember(Name = "RRR")]
        public string Rrr { get; set; }

    }

}
