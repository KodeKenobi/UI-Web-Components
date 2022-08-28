using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Relation
    {
        public Relation()
        {
            Claims = new HashSet<Claim>();
            MemberDetails = new HashSet<MemberDetail>();
        }

        public short RelationKey { get; set; }
        public string Descript { get; set; }
        public short? NumPerGrp { get; set; }
        public byte? SponsorTf { get; set; }

        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<MemberDetail> MemberDetails { get; set; }
    }
}
