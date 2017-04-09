using System;

namespace Braintree
{
    public class VenmoAccount : PaymentMethod
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string VenmoUserId { get; set; }
        public string SourceDescription { get; set; }
        public string ImageUrl { get; set; }
        public bool? IsDefault { get; set; }
        public string CustomerId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Subscription[] Subscriptions { get; set; }

        protected internal VenmoAccount(NodeWrapper node, IBraintreeGateway gateway)
        {
            Token = node.GetString("token");
            Username = node.GetString("username");
            VenmoUserId = node.GetString("venmo-user-id");
            SourceDescription = node.GetString("source-description");
            ImageUrl = node.GetString("image-url");

            IsDefault = node.GetBoolean("default");
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
        protected internal VenmoAccount() { }
    }
}

