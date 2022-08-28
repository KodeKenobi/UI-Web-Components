using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrnRange
    {
        public int RngKey { get; set; }
        public long? RangeLow { get; set; }
        public long? RangeHgh { get; set; }
        public int? BankKey { get; set; }

        public virtual Bank BankKeyNavigation { get; set; }
    }
}
