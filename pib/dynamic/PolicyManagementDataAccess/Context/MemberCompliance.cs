using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberCompliance
    {
        public Guid Id { get; set; }
        public bool? IntermediaryStatus { get; set; }
        public bool? Advice { get; set; }
        public bool? WaitingPeriods { get; set; }
        public bool? DebitOrder { get; set; }
        public bool? RightsReserved { get; set; }
        public bool? Exclusions { get; set; }
        public bool? ClaimsProcedure { get; set; }
        public bool? PolicyReplacement { get; set; }
        public bool? ApplicationStage { get; set; }
        public string PolicyReplacementCompany { get; set; }
        public string PremiumPayerSignature { get; set; }
        public int? MemPropKey { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
