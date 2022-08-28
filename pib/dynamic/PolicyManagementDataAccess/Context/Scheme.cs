using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Scheme
    {
        public Scheme()
        {
            SchemeBenefits = new HashSet<SchemeBenefit>();
            SchemeCharges = new HashSet<SchemeCharge>();
            SchemeCommissions = new HashSet<SchemeCommission>();
            SchemeCosts = new HashSet<SchemeCost>();
            SchemeEndorsements = new HashSet<SchemeEndorsement>();
        }

        public int SchemeNum { get; set; }
        public short SchVersion { get; set; }
        public byte? CurrentTf { get; set; }
        public string SchemeName { get; set; }
        public string ExtSchNum { get; set; }
        public int? TakeOnDate { get; set; }
        public int? CancelDate { get; set; }
        public int? ReinstateDate { get; set; }
        public float? SchComRate { get; set; }
        public string SchemeType { get; set; }
        public string CoverPeriod { get; set; }
        public short? ReviewFreq { get; set; }
        public byte? ReviewTf { get; set; }
        public short? ReviewLetterCount { get; set; }
        public int? ReviewLetterDate { get; set; }
        public string EligibilityNote { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactFax { get; set; }
        public string ContactEmail { get; set; }
        public byte? PupdeathTf { get; set; }
        public byte? PupdisableTf { get; set; }
        public byte? PupretireTf { get; set; }
        public byte? ActiveTf { get; set; }
        public int? PlanNum { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual InsPlan PlanNumNavigation { get; set; }
        public virtual ICollection<SchemeBenefit> SchemeBenefits { get; set; }
        public virtual ICollection<SchemeCharge> SchemeCharges { get; set; }
        public virtual ICollection<SchemeCommission> SchemeCommissions { get; set; }
        public virtual ICollection<SchemeCost> SchemeCosts { get; set; }
        public virtual ICollection<SchemeEndorsement> SchemeEndorsements { get; set; }
    }
}
