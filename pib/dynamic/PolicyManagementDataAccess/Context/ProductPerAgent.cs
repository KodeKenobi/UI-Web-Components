using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class ProductPerAgent
    {
        public int AgentKey { get; set; }
        public int ProductKey { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public byte? ActiveTf { get; set; }
        public double? ProductComm { get; set; }
        public int? StrComMon { get; set; }
        public byte? PrdAgtComFreq { get; set; }
        public int? NextAgentKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
        public bool? ToBeClawedBack { get; set; }
        public int? ClawBackMonth { get; set; }
        public bool? ConfirmedClawBack { get; set; }

        public virtual Agent AgentKeyNavigation { get; set; }
        public virtual MemberGroup ProductKeyNavigation { get; set; }
    }
}
