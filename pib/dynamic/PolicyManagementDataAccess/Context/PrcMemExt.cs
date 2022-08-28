using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PrcMemExt
    {
        public int? ExtSchNum { get; set; }
        public string MemGrpNum { get; set; }
        public string InsRef { get; set; }
        public string Descript { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Idnum { get; set; }
        public string Dob { get; set; }
        public decimal? Cost { get; set; }
        public decimal? Charge { get; set; }
        public string FldRef { get; set; }
        public decimal? ExtendedCost { get; set; }
        public decimal? Total { get; set; }
    }
}
