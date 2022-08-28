using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblCoverrule
    {
        public int FldPlanId { get; set; }
        public string FldPlanName { get; set; }
        public int FldUnderwriterId { get; set; }
        public string FldUnderwriterName { get; set; }
        public int FldSchemeId { get; set; }
        public short FldSchemeVersion { get; set; }
        public string FldSchemeName { get; set; }
        public int FldBenefitId { get; set; }
        public short FldBenefitVersion { get; set; }
        public string FldBenefitDescription { get; set; }
        public short? FldBenefitWaitingperiod { get; set; }
        public int FldCoverId { get; set; }
        public short FldCoverVersion { get; set; }
        public string FldCoverDescription { get; set; }
        public string FldRelationName { get; set; }
        public short FldRelationId { get; set; }
        public byte? FldCoverMinage { get; set; }
        public byte? FldCoverMaxage { get; set; }
        public double? FldCoverAmount { get; set; }
        public double? FldCoverPremium { get; set; }
        public double? FldCoverCost { get; set; }
        public byte? ActiveTf { get; set; }
    }
}
