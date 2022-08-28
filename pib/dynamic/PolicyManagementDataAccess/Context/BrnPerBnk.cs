using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrnPerBnk
    {
        public int BankKey { get; set; }
        public int BrnKey { get; set; }

        public virtual Bank BankKeyNavigation { get; set; }
        public virtual BnkBranch BrnKeyNavigation { get; set; }
    }
}
