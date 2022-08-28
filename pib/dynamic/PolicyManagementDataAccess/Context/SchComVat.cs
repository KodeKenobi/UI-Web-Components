using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class SchComVat
    {
        public int ComVatKey { get; set; }
        public string ComVatType { get; set; }
        public double? Amount { get; set; }
        public int? CapitalKey { get; set; }
        public int? SchComKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
    }
}
