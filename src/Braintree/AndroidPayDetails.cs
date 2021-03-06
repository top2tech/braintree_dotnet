using System;

namespace Braintree
{
    public class AndroidPayDetails
    {
        public virtual string Bin { get; set; }
        public virtual string ExpirationMonth { get; set; }
        public virtual string ExpirationYear { get; set; }
        public virtual string GoogleTransactionId { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string SourceCardLast4 { get; set; }
        public virtual string SourceCardType { get; set; }
        public virtual string SourceDescription { get; set; }
        public virtual string VirtualCardLast4 { get; set; }
        public virtual string VirtualCardType { get; set; }
        public virtual string CardType { get; set; }
        public virtual string Last4 { get; set; }
        public virtual string Token { get; set; }

        protected internal AndroidPayDetails(NodeWrapper node)
        {
            Bin = node.GetString("bin");
            ExpirationMonth = node.GetString("expiration-month");
            ExpirationYear = node.GetString("expiration-year");
            GoogleTransactionId = node.GetString("google-transaction-id");
            ImageUrl = node.GetString("image-url");
            SourceCardType = node.GetString("source-card-type");
            SourceCardLast4 = node.GetString("source-card-last-4");
            SourceDescription = node.GetString("source-description");
            VirtualCardLast4 = node.GetString("virtual-card-last-4");
            VirtualCardType = node.GetString("virtual-card-type");
            CardType = node.GetString("virtual-card-type");
            Last4 = node.GetString("virtual-card-last-4");
            Token = node.GetString("token");
        }

        [Obsolete("Mock Use Only")]
        protected internal AndroidPayDetails() { }
    }
}
