namespace Braintree
{
    public class VenmoAccountDetails
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public string VenmoUserId { get; set; }
        public string ImageUrl { get; set; }
        public string SourceDescription { get; set; }

        protected internal VenmoAccountDetails(NodeWrapper node)
        {
            Token = node.GetString("token");
            Username = node.GetString("username");
            VenmoUserId = node.GetString("venmo-user-id");
            ImageUrl = node.GetString("image-url");
            SourceDescription = node.GetString("source-description");
        }
    }
}
