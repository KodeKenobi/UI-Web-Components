using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class CompulsoryCover
    {
        public int? CoverKey { get; set; }
        public short? CvrVersion { get; set; }
        public string ClaimNum { get; set; }

        public virtual BenefitCover C { get; set; }
        public virtual Claim ClaimNumNavigation { get; set; }
    }
}
