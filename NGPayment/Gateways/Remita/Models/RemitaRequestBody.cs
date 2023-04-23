
using System.Collections.Generic;

namespace NGPayments.Gateways.Remita.Models
{
    public class RemitaRequestBody
    {
        public RemitaConfiguration configuration { get; set; }

        /// <summary>
        /// Your Unique Merchant ID on Remita.
        /// </summary>
        public string merchantId { get; set; }

        /// <summary>
        /// ID for your good/service on Remita.
        /// </summary>
        public string serviceTypeId { get; set; }

        /// <summary>
        /// Api Generated From Remita
        /// </summary>
        public string apiKey { get; set; }

        /// <summary>
        ///  Amount for Invoice
        /// </summary>
        public string amount { get; set; }

        /// <summary>
        /// Your Unique reference for that Invoice
        /// </summary>
        public string orderId { get; set; }

        /// <summary>
        /// Payer Name
        /// </summary>
        public string payerName { get; set; }

        /// <summary>
        /// Payer Email
        /// </summary>
        public string payerEmail { get; set; }

        /// <summary>
        /// Payer Phone Number
        /// </summary>
        public string payerPhone { get; set; }

        /// <summary>
        ///   Payment Description
        /// </summary>
        public string description { get; set; }

        /// <summary>
        ///  SHA-512 hash of merchantId+ serviceTypeId+ orderId+totalAmount+apiKey
        /// </summary>
        public string hash { get; set; }

        /// <summary>
        /// Value should be a date with format "DD/MM/YYYY". This field is optional, as such can be exempted from invoice generation calls.
        /// </summary>
        public string expiryDate { get; set; }

        //public LineItems[] lineItems { get; set; }

        public object customFields { get; set; }

        /// <summary>
        ///     Transaction RRR for invoice cancellation
        /// </summary>
        public string rrr { get; set; }
    }

    public class LineItems
    {
        /// <summary>
        /// Your unique identifier for each line item. A line item being the relevant details of a beneficiary in the split payment
        /// </summary>
        public string lineItemId { get; set; }
        /// <summary>
        /// Name of Beneficiary in the split payment
        /// </summary>
        public string beneficiaryName { get; set; }
        /// <summary>
        /// Account Number to which Beneficiary will be receiving their share of the payment
        /// </summary>
        public string beneficiaryAccount { get; set; }
        /// <summary>
        /// Bank code for Account Number of Beneficiary in the split payment.
        /// </summary>
        public string bankCode { get; set; }
        /// <summary>
        /// Amount from the Total Invoiced amount to be paid to beneficiary
        /// </summary>
        public string beneficiaryAmount { get; set; }
        /// <summary>
        /// Value should be '1' or '0'. '1' if the benifiary in question will be bearing the transaction fees. Transaction fees can only be borne by one beneficiary
        /// </summary>
        public string deductFeeFrom { get; set; }
    }

}