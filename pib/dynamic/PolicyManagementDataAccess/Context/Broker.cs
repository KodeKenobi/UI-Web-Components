using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Broker
    {
        public Broker()
        {
            BrokerBranches = new HashSet<BrokerBranch>();
            BrokerPeople = new HashSet<BrokerPerson>();
        }

        public int BrokerKey { get; set; }
        public string BrokerShort { get; set; }
        public string BrokerName { get; set; }
        public string RegNum { get; set; }
        public short? GetBrkFeeTf { get; set; }
        public short? UseAgentSysTf { get; set; }
        public short? UsePropSysTf { get; set; }
        public short? UseImgSysTf { get; set; }
        public short? AutoCanUnp { get; set; }
        public short? UnpCanPrd { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<BrokerBranch> BrokerBranches { get; set; }
        public virtual ICollection<BrokerPerson> BrokerPeople { get; set; }
    }
}
