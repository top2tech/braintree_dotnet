#pragma warning disable 1591

using Newtonsoft.Json;
using System;

namespace Braintree
{
    public class VerificationStatus : Enumeration
    {
        public static readonly VerificationStatus FAILED = new VerificationStatus("failed");
        public static readonly VerificationStatus GATEWAY_REJECTED = new VerificationStatus("gateway_rejected");
        public static readonly VerificationStatus PROCESSOR_DECLINED = new VerificationStatus("processor_declined");
        public static readonly VerificationStatus UNRECOGNIZED = new VerificationStatus("unrecognized");
        public static readonly VerificationStatus VERIFIED = new VerificationStatus("verified");


        public static readonly VerificationStatus[] ALL = {
            FAILED, GATEWAY_REJECTED, PROCESSOR_DECLINED, VERIFIED
        };
        [JsonConstructor]
        protected VerificationStatus(string name) : base(name) {}
    }

    public class CreditCardVerification
    {
        public virtual string AvsErrorResponseCode { get; set; }
        public virtual string AvsPostalCodeResponseCode { get; set; }
        public virtual string AvsStreetAddressResponseCode { get; set; }
        public virtual string CvvResponseCode { get; set; }
        public virtual TransactionGatewayRejectionReason GatewayRejectionReason { get; set; }
        public virtual string ProcessorResponseCode { get; set; }
        public virtual string ProcessorResponseText { get; set; }
        public virtual string MerchantAccountId { get; set; }
        public virtual VerificationStatus Status { get; set; }
        public virtual string Id { get; set; }
        public virtual Address BillingAddress { get; set; }
        public virtual CreditCard CreditCard { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual RiskData RiskData { get; set; }

        public CreditCardVerification(NodeWrapper node, IBraintreeGateway gateway)
        {
            if (node == null) return;

            AvsErrorResponseCode = node.GetString("avs-error-response-code");
            AvsPostalCodeResponseCode = node.GetString("avs-postal-code-response-code");
            AvsStreetAddressResponseCode = node.GetString("avs-street-address-response-code");
            CvvResponseCode = node.GetString("cvv-response-code");
            GatewayRejectionReason = (TransactionGatewayRejectionReason)CollectionUtil.Find(
                TransactionGatewayRejectionReason.ALL,
                node.GetString("gateway-rejection-reason"),
                null
            );
            ProcessorResponseCode = node.GetString("processor-response-code");
            ProcessorResponseText = node.GetString("processor-response-text");
            MerchantAccountId = node.GetString("merchant-account-id");
            Status = (VerificationStatus)CollectionUtil.Find(VerificationStatus.ALL, node.GetString("status"), VerificationStatus.UNRECOGNIZED);
            Id = node.GetString("id");
            BillingAddress = new Address(node.GetNode("billing"));
            CreditCard = new CreditCard(node.GetNode("credit-card"), gateway);
            CreatedAt = node.GetDateTime("created-at");

            var riskDataNode = node.GetNode("risk-data");
            if (riskDataNode != null)
            {
                RiskData = new RiskData(riskDataNode);
            }
        }
        
        [Obsolete("Mock Use Only")]
        protected internal CreditCardVerification() { }
    }
}
