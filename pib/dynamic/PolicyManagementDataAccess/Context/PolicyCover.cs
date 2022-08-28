
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess.Context
{
    public partial class PolicyCover
    {
        [Key]
        public int PolicyCoverID { get; set; }
        public string PlanID { get; set; }
        public string Description { get; set; }
        public int RelationKey { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoverAmount { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Premium { get; set; }
        public CoverType CoverType { get; set; }
    }
}
