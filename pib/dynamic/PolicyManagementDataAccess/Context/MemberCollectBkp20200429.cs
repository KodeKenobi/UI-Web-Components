﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberCollectBkp20200429
    {
        public int MemColKey { get; set; }
        public string CollectType { get; set; }
        public string CollectAction { get; set; }
        public int? CollectFreq { get; set; }
        public string CollectSurname { get; set; }
        public string CollectInitial { get; set; }
        public string CollectIdnum { get; set; }
        public int? CollectStart { get; set; }
        public string DoAccNum { get; set; }
        public string DoAccType { get; set; }
        public string DoBankName { get; set; }
        public string DoBranchName { get; set; }
        public string DoBranchCode { get; set; }
        public short? DoDebitDay { get; set; }
        public string SoStaffNum { get; set; }
        public string UnpReason { get; set; }
        public int? ColOrgKey { get; set; }
        public int? DeptKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
