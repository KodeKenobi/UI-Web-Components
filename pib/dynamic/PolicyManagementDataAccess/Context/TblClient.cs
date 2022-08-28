using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblClient
    {
        public int FldClientId { get; set; }
        public string FldUsername { get; set; }
        public string FldPassword { get; set; }
        public int? FldCompanyId { get; set; }
    }
}
