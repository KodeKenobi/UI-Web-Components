using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Cheque
    {
        public int ChequeKey { get; set; }
        public string Chqeftnum { get; set; }
        public string PayType { get; set; }
        public int? PayDate { get; set; }
        public string Payee { get; set; }
        public double? PayAmount { get; set; }
        public string PayAccNum { get; set; }
        public string PayAccType { get; set; }
        public string PayBank { get; set; }
        public string PayBranchCode { get; set; }
        public string ChqStatus { get; set; }
        public int? ChqCapUsr { get; set; }
        public int? ChqAutUsr { get; set; }
        public int? ChqPayUsr { get; set; }
        public int? ChqCanUsr { get; set; }
        public DateTime? ChqCapDateTime { get; set; }
        public DateTime? ChqAutDateTime { get; set; }
        public DateTime? ChqPayDateTime { get; set; }
        public DateTime? ChqCanDateTime { get; set; }
        public string ChqUnaReason { get; set; }
        public string ChqCanReason { get; set; }
        public int? CapitalKey { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
    }
}
