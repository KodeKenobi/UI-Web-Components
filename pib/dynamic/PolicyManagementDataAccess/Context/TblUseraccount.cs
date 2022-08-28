using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblUseraccount 
    {
        public int FldAccountId { get; set; }
        public int? FldCompanyId { get; set; }
        public string FldUsername { get; set; }
        public string FldUserPassword { get; set; }
        [JsonIgnore]
        public byte[] FldPasswordHash { get; set; }
        [JsonIgnore]
        public byte[] FldPasswordSalt { get; set; }
        public string FldUserAccounttype { get; set; }
        public int? FldAgentId { get; set; }
        public string FldUserDepartment { get; set; }
        public string FldUserEmail { get; set; }
        public string FldUserTitle { get; set; }
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

        public virtual SecureUser FldAccount { get; set; }

       
    }
}
