using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class InsPlan
    {
        public InsPlan()
        {
            ImageLinks = new HashSet<ImageLink>();
            Schemes = new HashSet<Scheme>();
        }

        public int PlanNum { get; set; }
        public string PlanName { get; set; }
        public int? TakeOnDate { get; set; }
        public byte? ActiveTf { get; set; }
        public int? InsurerKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Insurer InsurerKeyNavigation { get; set; }
        public virtual ICollection<ImageLink> ImageLinks { get; set; }
        public virtual ICollection<Scheme> Schemes { get; set; }
    }
}
