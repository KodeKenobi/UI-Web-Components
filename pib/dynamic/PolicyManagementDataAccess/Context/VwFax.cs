using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwFax
    {
        public string FldObjectType { get; set; }
        public int FldObjectId { get; set; }
        public string FldFaxTypeid { get; set; }
        public string FldFaxNumber { get; set; }
    }
}
