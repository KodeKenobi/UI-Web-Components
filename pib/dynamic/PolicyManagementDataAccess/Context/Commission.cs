using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Commission
    {
        public decimal? FldMemberPremium { get; set; }
        public decimal? CommissionEarned { get; set; }
        public decimal? FldMemberCover { get; set; }
        public DateTime? FldPolicyCommencementdate { get; set; }
        public DateTime? FldPolicyTerminationdate { get; set; }
        public string FldPolicyCapturedby { get; set; }
        public string FldBranchName { get; set; }
    }
}
