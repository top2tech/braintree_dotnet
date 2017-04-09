using System;

namespace Braintree
{
    public class ApplePayDetails
    {
        public virtual string CardType { get; set; }
        public virtual string PaymentInstrumentName { get; set; }
        public virtual string SourceDescription { get; set; }
        public virtual string CardholderName { get; set; }
        public virtual string ExpirationMonth { get; set; }
        public virtual string ExpirationYear { get; set; }
        public virtual string Token { get; set; }
        public virtual string LastFour { get; set; }

        protected internal ApplePayDetails(NodeWrapper node)
        {
            CardType = node.GetString("card-type");
            PaymentInstrumentName = node.GetString("payment-instrument-name");
            SourceDescription = node.GetString("source-description");
            CardholderName = node.GetString("cardholder-name");
            ExpirationMonth = node.GetString("expiration-month");
            ExpirationYear = node.GetString("expiration-year");
            Token = node.GetString("token");
            LastFour = node.GetString("last-4");
        }

        [Obsolete("Mock Use Only")]
        protected internal ApplePayDetails() { }
    }
}
