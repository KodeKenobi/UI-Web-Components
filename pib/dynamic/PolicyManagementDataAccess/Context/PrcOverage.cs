using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcOverage
    {
        public int? MemGrpNum { get; set; }
        public string MainMember { get; set; }
        public string OverageDep { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Proposer { get; set; }
        public string ContactPerson { get; set; }
        public int? MemDetNum { get; set; }
    }
}
