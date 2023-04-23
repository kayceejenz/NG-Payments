using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGPayments.Gateways.Remita.Models
{
    public class RemitaConfiguration
    {
        /// <summary>
        /// Your Unique Merchant ID on Remita.
        /// </summary>
        public string MerchantId;

        /// <summary>
        /// ID for your good/service on Remita.
        /// </summary>
        public string ServiceTypeId;

        /// <summary>
        /// Api Generated From Remita
        /// </summary>
        public string ApiKey;
    }

}
