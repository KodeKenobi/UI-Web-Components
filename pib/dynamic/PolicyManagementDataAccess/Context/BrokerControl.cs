using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerControl
    {
        public int ControlKey { get; set; }
        public int? PostMonth { get; set; }
        public string SysDateFormat { get; set; }
        public bool? PayMonthlyTf { get; set; }
        public int? PayMonth { get; set; }
        public int? PaidPassWord { get; set; }
        public decimal? RatePerMember { get; set; }
        public double? MinRentalAmt { get; set; }
        public string ImagePath { get; set; }
    }
}
