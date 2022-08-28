using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcMemStat
    {
        public int MemGrpNum { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public int? RelationKey { get; set; }
        public string RelDescript { get; set; }
        public double? CvrCharge { get; set; }
        public string PstAddress1 { get; set; }
        public string PstAddress2 { get; set; }
        public string PstAddress3 { get; set; }
        public string PostalCode { get; set; }
        public double? BalArrear { get; set; }
        public double? BalAlloc { get; set; }
    }
}
