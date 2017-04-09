using System;

namespace Braintree
{
    public class PayPalAccount : PaymentMethod
    {
        public virtual string Email { get; set; }
        public virtual string BillingAgreementId { get; set; }
        public virtual string Token { get; set; }
        public virtual bool? IsDefault { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string CustomerId { get; set; }
        public virtual DateTime? CreatedAt { get; set; }
        public virtual DateTime? UpdatedAt { get; set; }
        public virtual Subscription[] Subscriptions { get; set; }

        protected internal PayPalAccount(NodeWrapper node, IBraintreeGateway gateway)
        {
            Email = node.GetString("email");
            BillingAgreementId = node.GetString("billing-agreement-id");
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
        protected internal PayPalAccount() { }
    }
}
