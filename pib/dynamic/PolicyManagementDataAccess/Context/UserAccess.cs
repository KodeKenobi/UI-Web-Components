using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class UserAccess
    {
        public int? UserNum { get; set; }
        public int? AccNum { get; set; }
        public byte? AccTf { get; set; }

        public virtual SecureAccess AccNumNavigation { get; set; }
        public virtual SecureUser UserNumNavigation { get; set; }
    }
}
