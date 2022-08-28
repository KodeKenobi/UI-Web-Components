using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcPartCert
    {
        public long? MemGrpNum { get; set; }
        public long? PlanNum { get; set; }
        public long? SchemeNum { get; set; }
        public string SchemeName { get; set; }
        public string AppDate { get; set; }
        public string StartDate { get; set; }
        public string SuspendDate { get; set; }
        public string ReinstateDate { get; set; }
        public string ContactPerson { get; set; }
        public string FieldRef { get; set; }
        public string GrpPerson { get; set; }
        public string GrpRelation { get; set; }
        public string GrpIdnum { get; set; }
        public string GrpDob { get; set; }
        public string GrpBenAmount { get; set; }
        public string GrpBenCover { get; set; }
        public string GrpBenStart { get; set; }
        public decimal? FamCharge { get; set; }
        public decimal? ExtCharge { get; set; }
        public decimal? TotalCharge { get; set; }
        public bool? MainMemTf { get; set; }
        public string Address { get; set; }
        public string AgentName { get; set; }
        public string PayType { get; set; }
        public string PersalAccNo { get; set; }
        public string AccType { get; set; }
        public string BranchPayPoint { get; set; }
        public string DebitDay { get; set; }
        public string PayFreq { get; set; }
        public string Email { get; set; }
        public string ContactTel { get; set; }
        public string ContactCell { get; set; }
        public string Ben1 { get; set; }
        public string Ben1Id { get; set; }
        public string Ben2 { get; set; }
        public string Ben2Id { get; set; }
    }
}
