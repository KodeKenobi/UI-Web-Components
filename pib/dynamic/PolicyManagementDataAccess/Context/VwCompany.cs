using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwCompany
    {
        public int FldCompanyId { get; set; }
        public string FldCompanyName { get; set; }
        public string FldCompanyTradingas { get; set; }
        public string FldCompanyRegnumber { get; set; }
        public string FldCompanyVatnumber { get; set; }
        public string FldCompanySlogan { get; set; }
        public int? FldCompanyLogo { get; set; }
        public bool? FldCompanyIsactiveflag { get; set; }
        public int? FldImageId { get; set; }
        public string FldImageName { get; set; }
        public string FldImagePath { get; set; }
        public string FldImageExtension { get; set; }
        public string FldImageSize { get; set; }
        public byte[] FldImageByte { get; set; }
        public int? FldImageCreatedby { get; set; }
        public int? FldAccountId { get; set; }
        public int? FldAccountApiid { get; set; }
        public string FldAccountUsername { get; set; }
        public string FldAccountPassword { get; set; }
        public string FldAccountSenderid { get; set; }
        public int? FldAccountCallback { get; set; }
        public DateTime? FldAccountDeliverytime { get; set; }
        public int? FldAccountConcat { get; set; }
        public int? FldAccountEscalate { get; set; }
        public string FldCompanyWebsite { get; set; }
        public int? FldSmsaccountId { get; set; }
    }
}
