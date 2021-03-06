#pragma warning disable 1591

using System;

namespace Braintree
{
    public class MerchantAccountBusinessDetails
    {
        public virtual string DbaName { get; set; }
        public virtual string LegalName { get; set; }
        public virtual string TaxId { get; set; }
        public virtual Address Address { get; set; }

        protected internal MerchantAccountBusinessDetails(NodeWrapper node)
        {
            DbaName = node.GetString("dba-name");
            LegalName = node.GetString("legal-name");
            TaxId = node.GetString("tax-id");
            Address = new Address(node.GetNode("address"));
        }

        [Obsolete("Mock Use Only")]
        protected internal MerchantAccountBusinessDetails() { }
    }
}
