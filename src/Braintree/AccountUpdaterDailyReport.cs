using System;

namespace Braintree
{
    public class AccountUpdaterDailyReport
    {
        public virtual DateTime? ReportDate { get; set; }
        public virtual string ReportUrl { get; set; }

        protected internal AccountUpdaterDailyReport(NodeWrapper node)
        {
            ReportDate = node.GetDateTime("report-date");
            ReportUrl = node.GetString("report-url");
        }

        [Obsolete("Mock Use Only")]
        protected internal AccountUpdaterDailyReport() { }
    }
}

