using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class ProviderPayment
    {
        public int ProvPayKey { get; set; }
        public string ProvPayType { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
        public decimal? RatePerMember { get; set; }
        public int? NumOfMember { get; set; }
        public int? DateOfCalc { get; set; }
        public double? Amount { get; set; }
        public int? CapitalKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
    }
}
