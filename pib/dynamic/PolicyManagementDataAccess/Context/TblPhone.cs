using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblPhone
    {
        public string FldObjectType { get; set; }
        public int FldObjectId { get; set; }
        public string FldPhoneTypeid { get; set; }
        public string FldPhoneNumber { get; set; }
    }
}
