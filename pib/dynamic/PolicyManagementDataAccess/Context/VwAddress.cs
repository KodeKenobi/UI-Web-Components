using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwAddress
    {
        public string FldObjectType { get; set; }
        public int FldObjectId { get; set; }
        public string FldAddressTypeid { get; set; }
        public string FldAddressLine1 { get; set; }
        public string FldAddressLine2 { get; set; }
        public string FldAddressTowncity { get; set; }
        public string FldAddressPostalcode { get; set; }
    }
}
