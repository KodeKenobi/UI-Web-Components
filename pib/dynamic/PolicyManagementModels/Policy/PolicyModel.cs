using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementModels.Policy
{
    public class PolicyModel
    {
        public int CoverID { get; set; }
        public string PlanID { get; set; }
        public string Description { get; set; }
        public int RelationKey { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public decimal Cover { get; set; }
        public decimal Premium { get; set; }
        public bool IsPIBFLag { get; set; }

        public SelectList PolicyList { get; set; }


    }
}
