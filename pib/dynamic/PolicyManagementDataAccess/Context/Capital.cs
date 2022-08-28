using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Capital
    {
        public Capital()
        {
            AgentPayments = new HashSet<AgentPayment>();
            BrokerFees = new HashSet<BrokerFee>();
            Cheques = new HashSet<Cheque>();
            Claims = new HashSet<Claim>();
            ProviderPayments = new HashSet<ProviderPayment>();
            Receipts = new HashSet<Receipt>();
            SchComVats = new HashSet<SchComVat>();
            SchemeCharges = new HashSet<SchemeCharge>();
            SchemeCommissions = new HashSet<SchemeCommission>();
            SchemeCosts = new HashSet<SchemeCost>();
        }

        public int CapitalKey { get; set; }
        public int? AccKey { get; set; }
        public byte? BalancedTf { get; set; }
        public string UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual BankAccount AccKeyNavigation { get; set; }
        public virtual ICollection<AgentPayment> AgentPayments { get; set; }
        public virtual ICollection<BrokerFee> BrokerFees { get; set; }
        public virtual ICollection<Cheque> Cheques { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<ProviderPayment> ProviderPayments { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
        public virtual ICollection<SchComVat> SchComVats { get; set; }
        public virtual ICollection<SchemeCharge> SchemeCharges { get; set; }
        public virtual ICollection<SchemeCommission> SchemeCommissions { get; set; }
        public virtual ICollection<SchemeCost> SchemeCosts { get; set; }
    }
}
