using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberProposer
    {
        public MemberProposer()
        {
            MemberGroups = new HashSet<MemberGroup>();
        }

        public int MemPropKey { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Idnum { get; set; }
        public int? Dob { get; set; }
        public string Occupation { get; set; }
        public string ContactPhone { get; set; }
        public string WorkPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string RelationToPrincipalMember { get; set; }
        public bool? ApplicationApproved { get; set; }
        public string Status { get; set; }
        public int? UserNum { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<MemberGroup> MemberGroups { get; set; }
    }
}
