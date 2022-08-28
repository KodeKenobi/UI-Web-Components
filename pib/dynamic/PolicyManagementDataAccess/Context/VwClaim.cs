using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwClaim
    {
        public string FldClaimNumber { get; set; }
        public int? FldPolicyNumber { get; set; }
        public DateTime? FldClaimDate { get; set; }
        public string FldClaimName { get; set; }
        public string FldClaimIdnumber { get; set; }
        public double? FldClaimAmount { get; set; }
        public decimal? FldClaimPaid { get; set; }
        public DateTime? FldClaimDatepaid { get; set; }
        public string FldClaimPmtref { get; set; }
        public string FldClaimStatus { get; set; }
        public int? FldSchemeId { get; set; }
        public string FldClaimMembertype { get; set; }
    }
}
