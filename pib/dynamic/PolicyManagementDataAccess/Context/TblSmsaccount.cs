using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblSmsaccount
    {
        public int FldAccountId { get; set; }
        public int? FldAccountApiid { get; set; }
        public string FldAccountUsername { get; set; }
        public string FldAccountPassword { get; set; }
        public string FldAccountSenderid { get; set; }
        public int? FldAccountCallback { get; set; }
        public DateTime? FldAccountDeliverytime { get; set; }
        public int? FldAccountConcat { get; set; }
        public int? FldAccountEscalate { get; set; }
        public int? FldAccountCreatedby { get; set; }
    }
}
