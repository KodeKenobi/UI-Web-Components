using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblRole
    {
        public int FldRoleId { get; set; }
        public string FldRoleName { get; set; }
        public string FldRoleDescription { get; set; }
        public int? FldRoleParentid { get; set; }
        public bool? FldRoleIsactiveflag { get; set; }
    }
}
