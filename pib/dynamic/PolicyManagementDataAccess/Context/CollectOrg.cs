using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class CollectOrg
    {
        public CollectOrg()
        {
            ColOrgDepts = new HashSet<ColOrgDept>();
            MemberCollects = new HashSet<MemberCollect>();
        }

        public int ColOrgKey { get; set; }
        public string ColOrgCode { get; set; }
        public string ColOrgName { get; set; }
        public string ColOrgShort { get; set; }
        public string ColOrgGroup { get; set; }
        public string DeductDescript { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public string AltColOrgCode { get; set; }
        public int? NextFilSeq { get; set; }
        public byte? ActiveTf { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
        public short? NomAccIndic { get; set; }

        public virtual ICollection<ColOrgDept> ColOrgDepts { get; set; }
        public virtual ICollection<MemberCollect> MemberCollects { get; set; }
    }
}
