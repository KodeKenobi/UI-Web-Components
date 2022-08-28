using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerBranch
    {
        public int BranchKey { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string PstAddress1 { get; set; }
        public string PstAddress2 { get; set; }
        public string PstAddress3 { get; set; }
        public string PostalCode { get; set; }
        public string StrAddress1 { get; set; }
        public string StrAddress2 { get; set; }
        public string StrAddress3 { get; set; }
        public string StrAddress4 { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public bool? ActiveTf { get; set; }
        public int? BrokerKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Broker BrokerKeyNavigation { get; set; }
    }
}
