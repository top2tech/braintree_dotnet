using System;
using System.Collections.Generic;

namespace Braintree
{
    public class Disbursement
    {
        public virtual string Id { get; set; }
        public virtual decimal? Amount { get; set; }
        public virtual string ExceptionMessage { get; set; }
        public virtual DateTime? DisbursementDate { get; set; }
        public virtual string FollowUpAction { get; set; }
        public virtual MerchantAccount MerchantAccount { get; set; }
        public virtual List<string> TransactionIds { get; set; }
        public virtual bool? Success { get; set; }
        public virtual bool? Retry { get; set; }

        private IBraintreeGateway gateway;

        public Disbursement(NodeWrapper node, IBraintreeGateway gateway)
        {
            Id = node.GetString("id");
            Amount = node.GetDecimal("amount");
            ExceptionMessage = node.GetString("exception-message");
            DisbursementDate = node.GetDateTime("disbursement-date");
            FollowUpAction = node.GetString("follow-up-action");
            MerchantAccount = new MerchantAccount(node.GetNode("merchant-account"));
            TransactionIds = new List<string>();
            foreach (var stringNode in node.GetList("transaction-ids/item")) 
            {
                TransactionIds.Add(stringNode.GetString("."));
            }
            Success = node.GetBoolean("success");
            Retry = node.GetBoolean("retry");
            this.gateway = gateway;
        }

        [Obsolete("Mock Use Only")]
        protected internal Disbursement() { }

        public virtual ResourceCollection<Transaction> Transactions()
        {
            var gateway = new TransactionGateway(this.gateway);

            var searchRequest = new TransactionSearchRequest().
                Ids.IncludedIn(TransactionIds.ToArray());

            return gateway.Search(searchRequest);
        }
    }
}
