using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwRole
    {
        public string FldRoleName { get; set; }
        public string FldRoleDescription { get; set; }
        public int FldRoleId { get; set; }
        public int? FldRoleParentid { get; set; }
        public string FldRoleParentname { get; set; }
    }
}
