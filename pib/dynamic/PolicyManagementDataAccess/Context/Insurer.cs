using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Insurer
    {
        public Insurer()
        {
            InsPlans = new HashSet<InsPlan>();
        }

        public int InsurerKey { get; set; }
        public string InsurerName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public string PstAddress1 { get; set; }
        public string PstAddress2 { get; set; }
        public string PstAddress3 { get; set; }
        public string PstAddress4 { get; set; }
        public string PostalCode { get; set; }
        public string StrAddress1 { get; set; }
        public string StrAddress2 { get; set; }
        public string StrAddress3 { get; set; }
        public string StrAddress4 { get; set; }
        public string CompRegNum { get; set; }
        public int? BrkContractDate { get; set; }
        public byte? AnnexuresTf { get; set; }
        public byte? InsurerNotesTf { get; set; }
        public byte? ActiveTf { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<InsPlan> InsPlans { get; set; }
    }
}
