using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Receipt
    {
        public Receipt()
        {
            ImageLinks = new HashSet<ImageLink>();
        }

        public int ReceiptKey { get; set; }
        public string PayMethod { get; set; }
        public string ReceiptType { get; set; }
        public string ReceiptPurpose { get; set; }
        public int? TransDate { get; set; }
        public string DrawerName { get; set; }
        public string DrawerChqEftNum { get; set; }
        public double? Amount { get; set; }
        public int? RdreceiptKey { get; set; }
        public int? CapitalKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
        public virtual ICollection<ImageLink> ImageLinks { get; set; }
    }
}
