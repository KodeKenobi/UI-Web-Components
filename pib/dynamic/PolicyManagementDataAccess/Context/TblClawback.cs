using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblClawback
    {
        public int FldDetailId { get; set; }
        public int FldCommissionId { get; set; }
        public int FldAgentId { get; set; }
        public int FldPolicyId { get; set; }
        public string FldMemberDisplayname { get; set; }
        public string FldMemberIdnumber { get; set; }
        public string FldMemberType { get; set; }
        public int? FldSchemeId { get; set; }
        public bool? FldMemberIsreflag { get; set; }
        public string FldMemberProduct { get; set; }
        public DateTime? FldDateTaken { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldDateCancelled { get; set; }
        public int? FldTransSortorder { get; set; }
        public string FldClawbackType { get; set; }
        public string FldReasonCancelled { get; set; }
        public decimal? FldPremium { get; set; }
        public decimal? FldAmountPaid { get; set; }
        public decimal? FldAmountClawback { get; set; }
        public string FldStatus { get; set; }

        public virtual TblCommission FldCommission { get; set; }
    }
}
