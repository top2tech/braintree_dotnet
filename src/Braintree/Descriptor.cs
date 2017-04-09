#pragma warning disable 1591


namespace Braintree
{
    public class Descriptor
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Url { get; set; }

        protected internal Descriptor(NodeWrapper node)
        {
            if (node != null)
            {
                Name = node.GetString("name");
                Phone = node.GetString("phone");
                Url = node.GetString("url");
            }
        }

        public Descriptor()
        {

        }

    }
}
