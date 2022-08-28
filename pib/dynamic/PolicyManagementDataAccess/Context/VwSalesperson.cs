using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwSalesperson
    {
        public int FldSalespersonId { get; set; }
        public string FldSalespersonNumber { get; set; }
        public int? FldBranchId { get; set; }
        public string FldBranchName { get; set; }
        public string FldSalespersonDisplayname { get; set; }
        public string FldSalespersonIdnumber { get; set; }
        public int? FldSalespersonTitle { get; set; }
        public int? FldSalespersonFname { get; set; }
        public int? FldSalespersonLname { get; set; }
        public string FldSalespersonPhone { get; set; }
        public string FldSalespersonFax { get; set; }
        public string FldSalespersonEmail { get; set; }
        public string FldSalespersonLevel { get; set; }
        public DateTime? FldSalespersonStartdate { get; set; }
        public DateTime? FldSalespersonEnddate { get; set; }
        public string FldAddressTypeid { get; set; }
        public string FldAddressLine1 { get; set; }
        public string FldAddressLine2 { get; set; }
        public string FldAddressTowncity { get; set; }
        public string FldAddressPostalcode { get; set; }
        public int FldCountSales { get; set; }
        public int FldSumSales { get; set; }
        public bool? FldIsrecompliantflag { get; set; }
        public bool? FldAgentIsactiveflag { get; set; }
    }
}
