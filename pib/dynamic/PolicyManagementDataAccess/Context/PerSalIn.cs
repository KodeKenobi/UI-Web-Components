using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PerSalIn
    {
        public int PslRecKey { get; set; }
        public string PslTrnType { get; set; }
        public string PslStaffNum { get; set; }
        public string PslReference { get; set; }
        public string PslSurname { get; set; }
        public string PslInitial { get; set; }
        public string PslIdnum { get; set; }
        public double? PslAmount { get; set; }
        public string PslInsType { get; set; }
        public int? PslSalMonth { get; set; }
        public int? PslMemColKey { get; set; }
        public string FileType { get; set; }
    }
}
