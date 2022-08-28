using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcAgtRemit
    {
        public int AgentKey { get; set; }
        public int MemGrpNum { get; set; }
        public string FldRef { get; set; }
        public string MemFirstName { get; set; }
        public string MemSecondName { get; set; }
        public string MemSurname { get; set; }
        public string MemIdnum { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCell { get; set; }
        public double? LvlCostRate { get; set; }
        public double? MemPayAmt { get; set; }
        public string UnpReason { get; set; }
        public string CollectType { get; set; }
        public string ColOrgName { get; set; }
        public byte? ActivePolicy { get; set; }
    }
}
