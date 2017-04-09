using System;

namespace Braintree
{
    public class ThreeDSecureInfo
    {
        public virtual string Status { get; set; }
        public virtual string Enrolled { get; set; }
        public virtual bool? LiabilityShifted { get; set; }
        public virtual bool? LiabilityShiftPossible { get; set; }

        public ThreeDSecureInfo(NodeWrapper node)
        {
            if (node == null)
                return;

            Enrolled = node.GetString("enrolled");
            Status = node.GetString("status");
            LiabilityShifted = node.GetBoolean("liability-shifted");
            LiabilityShiftPossible = node.GetBoolean("liability-shift-possible");
        }

        [Obsolete("Mock Use Only")]
        protected internal ThreeDSecureInfo() { }
    }
}

