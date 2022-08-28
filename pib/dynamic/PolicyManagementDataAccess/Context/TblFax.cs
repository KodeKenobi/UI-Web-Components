using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblFax
    {
        public string FldObjectType { get; set; }
        public int FldObjectId { get; set; }
        public string FldFaxTypeid { get; set; }
        public string FldFaxNumber { get; set; }
    }
}
