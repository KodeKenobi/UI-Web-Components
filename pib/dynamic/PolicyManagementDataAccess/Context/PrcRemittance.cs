using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcRemittance
    {
        public int MemGrpNum { get; set; }
        public string InsRef { get; set; }
        public string MemFirstName { get; set; }
        public string MemSecondName { get; set; }
        public string MemSurname { get; set; }
        public string MemIdnum { get; set; }
        public double? GrpCvrCost { get; set; }
        public double? GrpCvrCharge { get; set; }
        public double? GrpDue { get; set; }
        public double? GrpPay { get; set; }
    }
}
