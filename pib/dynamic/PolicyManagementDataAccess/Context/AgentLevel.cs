using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class AgentLevel
    {
        public AgentLevel()
        {
            Agents = new HashSet<Agent>();
            LevelCovers = new HashSet<LevelCover>();
        }

        public int LevelKey { get; set; }
        public string LvlDescript { get; set; }
        public int? LvlRank { get; set; }
        public bool? ActiveTf { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
        public virtual ICollection<LevelCover> LevelCovers { get; set; }
    }
}
