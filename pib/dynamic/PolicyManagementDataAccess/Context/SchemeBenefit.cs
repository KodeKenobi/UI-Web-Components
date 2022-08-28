using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class SchemeBenefit
    {
        public SchemeBenefit()
        {
            BenefitCovers = new HashSet<BenefitCover>();
        }

        public int BenefitKey { get; set; }
        public short BenVersion { get; set; }
        public byte? CurrentTf { get; set; }
        public string BenDescript { get; set; }
        public int? TakeOnDate { get; set; }
        public int? CancelDate { get; set; }
        public int? ReinStateDate { get; set; }
        public short? WaitingPeriod { get; set; }
        public short? NotifyPeriod { get; set; }
        public short? DocPeriod { get; set; }
        public byte? ActiveTf { get; set; }
        public int? SchemeNum { get; set; }
        public short? SchVersion { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Scheme Sch { get; set; }
        public virtual ICollection<BenefitCover> BenefitCovers { get; set; }
    }
}
