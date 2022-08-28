using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class ClaimRefund
    {
        public int? ClmRefKey { get; set; }
        public double? RefAmount { get; set; }
        public string ClaimNum { get; set; }
        public int? CapitalKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
        public virtual Claim ClaimNumNavigation { get; set; }
    }
}
