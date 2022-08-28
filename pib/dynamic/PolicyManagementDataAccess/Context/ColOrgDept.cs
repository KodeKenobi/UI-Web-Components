using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class ColOrgDept
    {
        public int DeptKey { get; set; }
        public string DeptName { get; set; }
        public string DeptShort { get; set; }
        public string DeptHead { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public bool? ActiveTf { get; set; }
        public int? ColOrgKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual CollectOrg ColOrgKeyNavigation { get; set; }
    }
}
