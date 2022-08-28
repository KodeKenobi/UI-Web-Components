using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class SchemeCharge
    {
        public int SchChgKey { get; set; }
        public string SchChgType { get; set; }
        public int? AllocMonth { get; set; }
        public int? PostMonth { get; set; }
        public double? Amount { get; set; }
        public int? CapitalKey { get; set; }
        public int? SchemeNum { get; set; }
        public short? SchVersion { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
        public virtual Scheme Sch { get; set; }
    }
}
