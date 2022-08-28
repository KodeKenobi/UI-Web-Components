using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class AgentCommission
    {
        public decimal? FldMemberPremium { get; set; }
        public decimal? FldMemberCover { get; set; }
        public DateTime? FldPolicyCommencementdate { get; set; }
        public DateTime? FldPolicyTerminationdate { get; set; }
        public string FldPolicyCapturedby { get; set; }
        public string FldPolicyStatus { get; set; }
        public string FldBranchName { get; set; }
        public string FldSalespersonDisplayname { get; set; }
        public DateTime? FldSalespersonStartdate { get; set; }
        public DateTime? FldSalespersonEnddate { get; set; }
    }
}
