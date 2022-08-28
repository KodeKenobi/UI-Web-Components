using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblEmail
    {
        public string FldObjectType { get; set; }
        public int FldObjectId { get; set; }
        public string FldEmailTypeid { get; set; }
        public string FldEmailAddress { get; set; }
    }
}
