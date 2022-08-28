using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Bank
    {
        public Bank()
        {
            BrnPerBnks = new HashSet<BrnPerBnk>();
            BrnRanges = new HashSet<BrnRange>();
        }

        public int BankKey { get; set; }
        public string BankName { get; set; }
        public string BankShort { get; set; }

        public virtual ICollection<BrnPerBnk> BrnPerBnks { get; set; }
        public virtual ICollection<BrnRange> BrnRanges { get; set; }
    }
}
