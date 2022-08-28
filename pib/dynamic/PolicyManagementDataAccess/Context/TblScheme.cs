using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblScheme
    {
        public int FldSchemeId { get; set; }
        public string FldSchemeName { get; set; }
        public string FldSchemeDescription { get; set; }
        public byte[] FldSchemeLogo { get; set; }
        public string FldSchemeContractresource { get; set; }
        public bool? FldSchemeIsactiveflag { get; set; }
    }
}
