using System;

namespace Braintree
{
    public class AndroidPayCard : PaymentMethod
    {
        public virtual string CardType { get; set; }
        public virtual string Last4 { get; set; }
        public virtual string SourceCardType { get; set; }
        public virtual string SourceCardLast4 { get; set; }
        public virtual string SourceDescription { get; set; }
        public virtual string VirtualCardType { get; set; }
        public virtual string VirtualCardLast4 { get; set; }
        public virtual string ExpirationMonth { get; set; }
        public virtual string ExpirationYear { get; set; }
        public virtual string Token { get; set; }
        public virtual string GoogleTransactionId { get; set; }
        public virtual string Bin { get; set; }
        public virtual bool? IsDefault { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual Subscription[] Subscriptions { get; set; }

        protected internal AndroidPayCard(NodeWrapper node, IBraintreeGateway gateway)
        {
            CardType = node.GetString("virtual-card-type");
            VirtualCardType = node.GetString("virtual-card-type");
            SourceCardType = node.GetString("source-card-type");
            Last4 = node.GetString("virtual-card-last-4");
            SourceCardLast4 = node.GetString("source-card-last-4");
            VirtualCardLast4 = node.GetString("virtual-card-last-4");
            SourceDescription = node.GetString("source-description");
            Bin = node.GetString("bin");
            ExpirationMonth = node.GetString("expiration-month");
            ExpirationYear = node.GetString("expiration-year");
            GoogleTransactionId = node.GetString("google-transaction-id");
            Token = node.GetString("token");
            IsDefault = node.GetBoolean("default");
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
        protected internal AndroidPayCard() { }
    }
}
