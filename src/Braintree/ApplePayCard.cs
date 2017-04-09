using System;

namespace Braintree
{
    public class ApplePayCard : PaymentMethod
    {
        public virtual string CardType { get; set; }
        public virtual string Last4 { get; set; }
        public virtual string ExpirationMonth { get; set; }
        public virtual string ExpirationYear { get; set; }
        public virtual string Token { get; set; }
        public virtual string PaymentInstrumentName { get; set; }
        public virtual string SourceDescription { get; set; }
        public virtual bool? IsDefault { get; set; }
        public virtual bool? IsExpired { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual Subscription[] Subscriptions { get; set; }

        protected internal ApplePayCard(NodeWrapper node, IBraintreeGateway gateway)
        {
            CardType = node.GetString("card-type");
            Last4 = node.GetString("last-4");
            ExpirationMonth = node.GetString("expiration-month");
            ExpirationYear = node.GetString("expiration-year");
            Token = node.GetString("token");
            PaymentInstrumentName = node.GetString("payment-instrument-name");
            SourceDescription = node.GetString("source-description");
            IsDefault = node.GetBoolean("default");
            IsExpired = node.GetBoolean("expired");
            ImageUrl = node.GetString("image-url");
            CustomerId = node.GetString("customer-id");
            CreatedAt = node.GetDateTime("created-at");
            UpdatedAt = node.GetDateTime("updated-at");

            var subscriptionXmlNodes = node.GetList("subscriptions/subscription");
            Subscriptions = new Subscription[subscriptionXmlNodes.Count];
            for (int i = 0; i < subscriptionXmlNodes.Count; i++)
            {
                Subscriptions[i] = new Subscription(subscriptionXmlNodes[i], gateway);
            }
        }

        [Obsolete("Mock Use Only")]
        protected internal ApplePayCard() { }
    }
}
