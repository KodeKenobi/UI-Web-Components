using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class LevelCover
    {
        public int LevelKey { get; set; }
        public int CoverKey { get; set; }
        public short CvrVersion { get; set; }
        public double? LvlCostRate { get; set; }
        public string LvlPayType { get; set; }
        public short? LvlComFreq { get; set; }
        public byte? PayToSup { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual BenefitCover C { get; set; }
        public virtual AgentLevel LevelKeyNavigation { get; set; }
    }
}
