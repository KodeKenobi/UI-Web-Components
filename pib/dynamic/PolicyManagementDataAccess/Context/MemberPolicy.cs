using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberPolicy
    {
        public int MemberPolicyID { get; set; }
        public int CoverID { get; set; }
        public int MemNum { get; set; }
        public decimal PremiumTotal { get; set; }
        public decimal CoverTotal { get; set; }
        public int fldACCOUNT_ID { get; set; }
    }
}
