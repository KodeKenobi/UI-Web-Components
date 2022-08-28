using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblCompany
    {
        public int FldCompanyId { get; set; }
        public string FldCompanyName { get; set; }
        public string FldCompanyTradingas { get; set; }
        public string FldCompanySlogan { get; set; }
        public string FldCompanyRegnumber { get; set; }
        public string FldCompanyVatnumber { get; set; }
        public int? FldSmsaccountId { get; set; }
        public string FldCompanyWebsite { get; set; }
        public int? FldCompanyLogo { get; set; }
        public bool? FldCompanyIsactiveflag { get; set; }
    }
}
