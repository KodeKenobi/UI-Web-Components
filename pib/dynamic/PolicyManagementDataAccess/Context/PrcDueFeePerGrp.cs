using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcDueFeePerGrp
    {
        public int MemGrpNum { get; set; }
        public double? DueAmount { get; set; }
        public double? FeeAmount { get; set; }
        public int? MemPayNum { get; set; }
    }
}
