using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BnkBranch
    {
        public BnkBranch()
        {
            BrnPerBnks = new HashSet<BrnPerBnk>();
        }

        public int BrnKey { get; set; }
        public string BrnCde { get; set; }
        public string BrnStream { get; set; }
        public string BrnName { get; set; }
        public string StrAddress1 { get; set; }
        public string StrAddress2 { get; set; }
        public string PstAddress1 { get; set; }
        public string PstAddress2 { get; set; }
        public string PostalCode { get; set; }
        public string ContactPhone { get; set; }
        public string ContactDialCode { get; set; }
        public string ContactFax { get; set; }

        public virtual ICollection<BrnPerBnk> BrnPerBnks { get; set; }
    }
}
