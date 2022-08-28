using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcPslExpTbl
    {
        public int MemColKey { get; set; }
        public string SoStaffNum { get; set; }
        public string CollectSurname { get; set; }
        public string CollectInitial { get; set; }
        public string CollectIdnum { get; set; }
        public double? CollectAmount { get; set; }
        public bool? PslFoundTf { get; set; }
        public double? PslAmount { get; set; }
        public string PslReference { get; set; }
        public string PslInsType { get; set; }
        public string Status { get; set; }
        public int SalMonth { get; set; }
        public string AmendType { get; set; }
    }
}
