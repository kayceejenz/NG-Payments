using System.Collections.Generic;


namespace NGPayments.Gateways.Monnify.Models
{
    public class MonnifyRequestBody
    {
        public MonnifyConfiguration configuration { get; set; }
      
        /// <summary>
        ///  Amount to pay
        /// </summary>
        public string amount { get; set; }
        /// <summary>
        ///  invoice reference number generated for a transaction
        /// </summary>
        public string invoiceReference { get; set; }
        /// <summary>
        ///  Description for payment
        /// </summary>
        public string description { get; set; }
        /// <summary>
        ///  Name of account for the transaction
        /// </summary>
        public string accountName { get; set; }
        /// <summary>
        ///  Account number for payment
        /// </summary>
        public string accountNumber { get; set; }
        /// <summary>
        ///  Check out url for remit payment
        /// </summary>
        public string checkoutUrl { get; set; }
        /// <summary>
        /// Name of bank for payment
        /// </summary>
        public string bankName { get; set; }
        /// <summary>
        ///  Bank code for payment
        /// </summary>
        public string bankCode { get; set; }
        /// <summary>
        ///  Monnify contract code 
        /// </summary>
        public string contractCode { get; set; }
        /// <summary>
        ///  Customer email address for payment notification
        /// </summary>
        public string customerEmail { get; set; }
        /// <summary>
        ///  Customer display name
        /// </summary>
        public string customerName { get; set; }
        /// <summary>
        ///  Customer unique identification number
        /// </summary>
        public string customerUniqueId { get; set; }
      
        public string createdBy { get; set; }
        /// <summary>
        ///  Status of the invoice
        /// </summary>
        public string invoiceStatus { get; set; }
        /// <summary>
        /// Date invoice was created
        /// </summary>
        public string createdOn { get; set; }
        /// <summary>
        ///  Date invoice will expire
        /// </summary>
        public string expiryDate { get; set; }
        public string currencyCode { get; set; }
        public string[] paymentMethods { get; set; }
        public IList<MonnifyIncomeSplitConfig> incomeSplitConfig { get; set; }
        public string redirectUrl { get; set; }
        public byte[] invoiceLogo { get; set; }
        public IList<dynamic> invoiceItems { get; set; }
        public string paymentStatus { get; set; }
        public string transactionReference { get; set; }
    }

    public class MonnifyIncomeSplitConfig
    {
        /// <summary>
        ///  Code of the sub account
        /// </summary>
        public string subAccountCode { get; set; }
        /// <summary>
        ///  percentage for the fee to be paid
        /// </summary>
        public double feePercentage { get; set; }
        /// <summary>
        ///  Fee split percentage
        /// </summary>
        public double splitPercentage { get; set; }
        /// <summary>
        ///  Amount to be paid when splitted
        /// </summary>
        public decimal SplitAmount { get; set; }
        /// <summary>
        ///  Bearer of the fee to be paid
        /// </summary>
        public bool feeBearer { get; set; }

    }

    public class MonnifyPaymentNotification
    {
        /// <summary>
        ///  Reference number for a transaction
        /// </summary>
        public string transactionReference { get; set; }
        /// <summary>
        /// Invoice payment reference number generated at time of creation
        /// </summary>
        public string paymentReference { get; set; }
        /// <summary>
        /// Amount paid during transaction
        /// </summary>
        public string amountPaid { get; set; }
        /// <summary>
        ///  Total amount that are to be paid
        /// </summary>
        public string totalPayable { get; set; }
        /// <summary>
        ///  Date payment was made
        /// </summary>
        public string paidOn { get; set; }
        /// <summary>
        ///  Status of the transaction
        /// </summary>
        public string paymentStatus { get; set; }
        /// <summary>
        ///  Description of the paid transaction
        /// </summary>
        public string paymentDescription { get; set; }
        /// <summary>
        ///  Hash of the transaction
        /// </summary>
        public string transactionHash { get; set; }
        /// <summary>
        /// Currency of the amount paid
        /// </summary>
        public string currency { get; set; }
    }
}
