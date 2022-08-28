using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwUser
    {
        public int? FldAccountId { get; set; }
        public int? FldCompanyId { get; set; }
        public string ExcellenceUsername { get; set; }
        public string ExcellencePassword { get; set; }
        public string FldUsername { get; set; }
        public string FldUserPassword { get; set; }
        public string FldUserFname { get; set; }
        public string FldUserLname { get; set; }
        public string FldUserTitle { get; set; }
        public string FldUserDisplayname { get; set; }
        public string FldUserAccounttype { get; set; }
        public string FldUserStaffnumber { get; set; }
        public int? FldAgentId { get; set; }
        public string FldUserDepartment { get; set; }
        public string FldUserJobtitle { get; set; }
        public bool? FldUserChangepasswordatlogin { get; set; }
        public bool? FldUserCanchangepassword { get; set; }
        public bool? FldUserDoespasswordexpire { get; set; }
        public bool? FldUserIsaccountlockedout { get; set; }
        public bool? FldUserIsaccountdisabled { get; set; }
        public bool? FldUserHasaccountexpired { get; set; }
        public DateTime? FldUserPasswordexpiarydate { get; set; }
        public bool? FldUserIsloggedin { get; set; }
        public string FldUserLastloggedonmachine { get; set; }
        public DateTime? FldUserDatelastloggedin { get; set; }
        public bool? FldUserIsactiveflag { get; set; }
        public string FldCompanyName { get; set; }
        public string FldCompanyTradingas { get; set; }
        public string FldCompanyWebsite { get; set; }
        public string FldCompanyPhone { get; set; }
        public string FldCompanyFax { get; set; }
        public string FldCompanyEmail { get; set; }
        public string FldAddressLine1 { get; set; }
        public string FldAddressLine2 { get; set; }
        public string FldAddressTowncity { get; set; }
        public string FldAddressPostalcode { get; set; }
    }
}
