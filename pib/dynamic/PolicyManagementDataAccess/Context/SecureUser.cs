using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class SecureUser
    {
        public int UserNum { get; set; }
        public string LogName { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string PassWord1 { get; set; }
        public string PassWord2 { get; set; }
        public string PassWord3 { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPhone { get; set; }
        public string UserFax { get; set; }
        public string UserEmail { get; set; }
        public string StaffNum { get; set; }
        //public string Token { get; set; }
        //public bool IsSuccess { get; set; }

        public virtual TblUseraccount TblUseraccount { get; set; }
    }
}
