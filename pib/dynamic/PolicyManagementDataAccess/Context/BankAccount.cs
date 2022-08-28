using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BankAccount
    {
        public BankAccount()
        {
            Capitals = new HashSet<Capital>();
        }

        public int AccKey { get; set; }
        public string BankName { get; set; }
        public string AccName { get; set; }
        public string AccNum { get; set; }
        public string AccType { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public byte? NomAccNum { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<Capital> Capitals { get; set; }
    }
}
