using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwPremiumPayer
    {
        public int FldPolicyNumber { get; set; }
        public int? FldPremiumpayerId { get; set; }
        public string FldPremiumpayerTitle { get; set; }
        public string FldPremiumpayerFname { get; set; }
        public string FldPremiumpayerMname { get; set; }
        public string FldPremiumpayerLname { get; set; }
        public string FldPremiumpayerDisplayname { get; set; }
        public string FldPremiumpayerIdnumber { get; set; }
        public DateTime? FldPremiumpayerDateofbith { get; set; }
        public string FldPremiumpayerOccupation { get; set; }
        public string FldPremiumpayerPhone { get; set; }
        public string FldPremiumpayerCell { get; set; }
        public string FldPremiumpayerEmail { get; set; }
    }
}
