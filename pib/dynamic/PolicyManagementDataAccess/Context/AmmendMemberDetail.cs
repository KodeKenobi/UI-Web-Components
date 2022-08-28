using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class AmmendMemberDetail
    {
        public int MemDetNum { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string MaidenName { get; set; }
        public string Idnum { get; set; }
        public int? Dob { get; set; }
        public string Occupation { get; set; }
        public string Sex { get; set; }
        public short? RelationKey { get; set; }
        public int? MemGrpNum { get; set; }
        public int? UserNum { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
