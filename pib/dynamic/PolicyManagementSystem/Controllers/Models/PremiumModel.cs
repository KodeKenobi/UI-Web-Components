using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class PremiumModel
    {
        public int Premium { get; set; }

        public int MinAge { get; set; }

        public int MaxAge { get; set; }
    }
}
