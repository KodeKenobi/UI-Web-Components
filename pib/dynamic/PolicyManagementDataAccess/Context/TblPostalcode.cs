using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblPostalcode
    {
        public int FldPostalcodeId { get; set; }
        public string FldPlace { get; set; }
        public string FldStreetcode { get; set; }
        public string FldPoboxcode { get; set; }
        public string FldCity { get; set; }
        public string FldProvince { get; set; }
    }
}
