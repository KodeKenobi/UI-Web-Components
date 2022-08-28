using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Area
    {
        public Area()
        {
            Agents = new HashSet<Agent>();
        }

        public int AreaKey { get; set; }
        public string AreaName { get; set; }
        public string AreaDescript { get; set; }
        public string AreaNum { get; set; }
        public byte? ActiveTf { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<Agent> Agents { get; set; }
    }
}
