using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberCollect
    {
        public MemberCollect()
        {
            MemberGroups = new HashSet<MemberGroup>();
        }

        public int MemColKey { get; set; }
        public string CollectType { get; set; }
        public string CollectAction { get; set; }
        public int? CollectFreq { get; set; }
        public string CollectSurname { get; set; }
        public string CollectInitial { get; set; }
        public string CollectIdnum { get; set; }
        public int? CollectStart { get; set; }
        public string DoAccNum { get; set; }
        public string DoAccType { get; set; }
        public string DoBankName { get; set; }
        public string DoBranchName { get; set; }
        public string DoBranchCode { get; set; }
        public short? DoDebitDay { get; set; }
        public string SoStaffNum { get; set; }
        public string UnpReason { get; set; }
        public int? ColOrgKey { get; set; }
        public int? DeptKey { get; set; }
        public int? MemPropKey { get; set; }
        public int? UserNum { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual CollectOrg ColOrgKeyNavigation { get; set; }
        public virtual ICollection<MemberGroup> MemberGroups { get; set; }
    }
}
