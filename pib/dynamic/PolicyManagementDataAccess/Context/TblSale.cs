using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblSale
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
        public string FldMemberOldproduct { get; set; }
        public string FldMemberProduct { get; set; }
        public DateTime? FldDateTaken { get; set; }
        public DateTime? FldStartDate { get; set; }
        public DateTime? FldDateReinstated { get; set; }
        public int? FldTransSortorder { get; set; }
        public string FldSaletype { get; set; }
        public decimal? FldMemberOldcover { get; set; }
        public decimal? FldMemberNewcover { get; set; }
        public decimal? FldMemberOldpremium { get; set; }
        public decimal? FldMemberNewpremium { get; set; }
        public decimal? FldAmountEarned { get; set; }
        public string FldStatus { get; set; }

        public virtual Agent FldAgent { get; set; }
        public virtual TblCommission FldCommission { get; set; }
        public virtual MemberGroup FldPolicy { get; set; }
    }
}
