using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerFee
    {
        public int BrkFeeKey { get; set; }
        public string BrkFeeType { get; set; }
        public string Descript { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
        public double? Amount { get; set; }
        public int? CapitalKey { get; set; }
        public int? SchCstKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
    }
}
