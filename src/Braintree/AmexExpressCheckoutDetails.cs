using System;

namespace Braintree
{
    public class AmexExpressCheckoutDetails
    {
        public virtual string Token { get; set; }
        public virtual string CardType { get; set; }
        public virtual string Bin { get; set; }
        public virtual string ExpirationMonth { get; set; }
        public virtual string ExpirationYear { get; set; }
        public virtual string CardMemberNumber { get; set; }
        public virtual string CardMemberExpiryDate { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string SourceDescription { get; set; }

        protected internal AmexExpressCheckoutDetails(NodeWrapper node)
        {
            Token = node.GetString("token");
            CardType = node.GetString("card-type");
            Bin = node.GetString("bin");
            ExpirationMonth = node.GetString("expiration-month");
            ExpirationYear = node.GetString("expiration-year");
            CardMemberNumber = node.GetString("card-member-number");
            CardMemberExpiryDate = node.GetString("card-member-expiry-date");
            ImageUrl = node.GetString("image-url");
            SourceDescription = node.GetString("source-description");
        }

        [Obsolete("Mock Use Only")]
        protected internal AmexExpressCheckoutDetails() { }
    }
}
