using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class AgentPayment
    {
        public int AgtPayKey { get; set; }
        public string AgtPayType { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
        public double? Amount { get; set; }
        public int? TransDate { get; set; }
        public int? AgentKey { get; set; }
        public int? CapitalKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Agent AgentKeyNavigation { get; set; }
        public virtual Capital CapitalKeyNavigation { get; set; }
    }
}
