using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PslLodging
    {
        public int MemColKey { get; set; }
        public int? PersalNum { get; set; }
        public string TransType { get; set; }
        public int? EffectiveMonth { get; set; }
        public int? Usernum { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
