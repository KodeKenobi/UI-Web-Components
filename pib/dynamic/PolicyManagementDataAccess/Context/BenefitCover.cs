using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BenefitCover
    {
        public BenefitCover()
        {
            LevelCovers = new HashSet<LevelCover>();
        }

        public int CoverKey { get; set; }
        public short CvrVersion { get; set; }
        public byte? CurrentTf { get; set; }
        public string CvrDescript { get; set; }
        public short? Precedence { get; set; }
        public double? CvrAmount { get; set; }
        public double? CvrCost { get; set; }
        public double? CvrCharge { get; set; }
        public double? CvrFee { get; set; }
        public int? Membership { get; set; }
        public byte? MinAge { get; set; }
        public byte? MaxAge { get; set; }
        public byte? CeaseAge { get; set; }
        public int? EffectiveDate { get; set; }
        public byte? CompulsoryTf { get; set; }
        public byte? ActiveTf { get; set; }
        public byte? CvrAtClmTf { get; set; }
        public int? BenefitKey { get; set; }
        public short? BenVersion { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual SchemeBenefit Ben { get; set; }
        public virtual ICollection<LevelCover> LevelCovers { get; set; }
    }
}
