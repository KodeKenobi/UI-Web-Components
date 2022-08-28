using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwCoverRule
    {
        public int FldCoverruleId { get; set; }
        public short FldCoverVersion { get; set; }
        public byte? FldCoverruleMinage { get; set; }
        public byte? FldCoverruleMaxage { get; set; }
        public double? FldCoverruleCover { get; set; }
        public double? FldCoverrulePremium { get; set; }
        public double? FldCoverruleCost { get; set; }
        public short? FldCoverruleWaitingperiod { get; set; }
        public DateTime? FldCoverruleEffectivedate { get; set; }
        public DateTime? FldCoverruleDatemodified { get; set; }
        public int? FldCoverruleModifiedby { get; set; }
        public byte? FldCoverruleIsactiveflag { get; set; }
    }
}
