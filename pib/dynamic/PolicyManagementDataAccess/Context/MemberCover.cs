using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberCover
    {
        public int? MemDetNum { get; set; }
        public int? CoverKey { get; set; }
        public short? CvrVersion { get; set; }
        public string ClaimNum { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public byte? PayCvrFeeTf { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual BenefitCover C { get; set; }
        public virtual Claim ClaimNumNavigation { get; set; }
        public virtual MemberDetail MemDetNumNavigation { get; set; }
    }
}
