using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberPayment
    {
        public int MemPayNum { get; set; }
        public string MemPayType { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
        public decimal? Amount { get; set; }
        public int? TransDate { get; set; }
        public string Reason { get; set; }
        public int? MemGrpNum { get; set; }
        public bool? DblDeductTf { get; set; }
        public int? CapitalKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
