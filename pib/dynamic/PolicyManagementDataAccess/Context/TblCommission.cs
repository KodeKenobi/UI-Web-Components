using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblCommission
    {
        public TblCommission()
        {
            TblClawbacks = new HashSet<TblClawback>();
            TblSales = new HashSet<TblSale>();
        }

        public int FldCommissionId { get; set; }
        public string FldCommissionName { get; set; }
        public DateTime FldCommissionStartdate { get; set; }
        public DateTime FldCommissionEnddate { get; set; }
        public bool? FldCommissionIscurrentflag { get; set; }
        public DateTime FldCommissionDatecreated { get; set; }
        public int FldCommissionCreatedby { get; set; }
        public DateTime? FldCommissionDatesubmitted { get; set; }
        public int? FldCommissionSubmittedby { get; set; }

        public virtual ICollection<TblClawback> TblClawbacks { get; set; }
        public virtual ICollection<TblSale> TblSales { get; set; }
    }
}
