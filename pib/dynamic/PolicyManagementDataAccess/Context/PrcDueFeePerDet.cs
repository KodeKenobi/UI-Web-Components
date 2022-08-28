using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcDueFeePerDet
    {
        public int MemGrpNum { get; set; }
        public double? CvrCharge { get; set; }
        public double? CvrFee { get; set; }
        public bool? PayCvrFeeTf { get; set; }
        public int? StartDate { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
    }
}
