using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Agent
    {
        public Agent()
        {
            AgentPayments = new HashSet<AgentPayment>();
            ImageLinks = new HashSet<ImageLink>();
            ProductPerAgents = new HashSet<ProductPerAgent>();
            TblSales = new HashSet<TblSale>();
           // Address = new HashSet<Address>();
        }

        public int AgentKey { get; set; }
        public string AgentNum { get; set; }
        public string AgentName { get; set; }
        public string IdregNum { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PostalCode { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public int? StartDate { get; set; }
        public int? EndDate { get; set; }
        public double? CommRate { get; set; }
        public double? Salary { get; set; }
        public string AccHolder { get; set; }
        public string AccNum { get; set; }
        public string AccType { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string BranchCode { get; set; }
        public string BranchTown { get; set; }
        public bool? PayPerCvr { get; set; }
        public bool? PayPerPrm { get; set; }
        public byte? AgtComFreq { get; set; }
        public byte? AgtVatregTf { get; set; }
        public int? AreaKey { get; set; }
        public int? SupAgentKey { get; set; }
        public int? LevelKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
        public bool? FldIsrecompliantflag { get; set; }
        public bool? FldAgentIsactiveflag { get; set; }
        public virtual Addresses Address { get; set; }
        public virtual Area AreaKeyNavigation { get; set; }
        public virtual AgentLevel LevelKeyNavigation { get; set; }
        public virtual ICollection<AgentPayment> AgentPayments { get; set; }
        public virtual ICollection<ImageLink> ImageLinks { get; set; }
        public virtual ICollection<ProductPerAgent> ProductPerAgents { get; set; }
        public virtual ICollection<TblSale> TblSales { get; set; }
    }
}
