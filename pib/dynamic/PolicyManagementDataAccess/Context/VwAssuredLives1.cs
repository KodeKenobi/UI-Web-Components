using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwAssuredLives1
    {
        public int? FldPolicyNumber { get; set; }
        public int FldMemberId { get; set; }
        public string FldMemberTitle { get; set; }
        public string FldMemberFname { get; set; }
        public string FldMemberLname { get; set; }
        public string FldMemberDisplayname { get; set; }
        public string FldMemberIdnumber { get; set; }
        public DateTime? FldMemberDateofbirth { get; set; }
        public int? FldMemberAge { get; set; }
        public string FldMemberStatus { get; set; }
        public string FldMemberStatusdesc { get; set; }
        public DateTime? FldMemberStartdate { get; set; }
        public DateTime? FldMemberEnddate { get; set; }
        public short FldRelationId { get; set; }
        public string FldClaimId { get; set; }
        public int FldCoverruleId { get; set; }
        public short FldCoverVersion { get; set; }
        public string FldCoverruleMembertype { get; set; }
        public byte? FldCoverruleMinage { get; set; }
        public byte? FldCoverruleMaxage { get; set; }
        public double? FldCoverrulePremium { get; set; }
        public double? FldCoverruleCover { get; set; }
        public double? FldCoverruleCost { get; set; }
        public short? FldCoverruleWaitingperiod { get; set; }
        public byte? FldCoverruleIsactiveflag { get; set; }
        public byte? CurrentTf { get; set; }
        public int? FldAgentId { get; set; }
    }
}
