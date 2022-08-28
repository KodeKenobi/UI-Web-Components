using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class DatasetBeneficiary
    {
        public string BeneficiaryName { get; set; }
        public string Relation { get; set; }
        public string IDNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}
