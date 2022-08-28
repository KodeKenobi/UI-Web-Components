using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Claim
    {
        public string ClaimNum { get; set; }
        public string ExtClaimNum { get; set; }
        public int? ClmDate { get; set; }
        public string NotifyPerson { get; set; }
        public string NotifyMethod { get; set; }
        public int? NotifyDate { get; set; }
        public string PenCode { get; set; }
        public string CertNum { get; set; }
        public string CertType { get; set; }
        public string ClmCause { get; set; }
        public string ClmType { get; set; }
        public string ClmStatus { get; set; }
        public string ClmFirstName { get; set; }
        public string ClmSecondName { get; set; }
        public string ClmSurname { get; set; }
        public int? ClmDob { get; set; }
        public string ClmIdnum { get; set; }
        public string AssFirstName { get; set; }
        public string AssSecondName { get; set; }
        public string AssSurname { get; set; }
        public double? ClmAmount { get; set; }
        public int? ClmCapUsr { get; set; }
        public int? ClmFwdUsr { get; set; }
        public int? ClmFinUsr { get; set; }
        public int? ClmAutUsr { get; set; }
        public int? ClmRefUsr { get; set; }
        public int? ClmRepUsr { get; set; }
        public int? ClmCanUsr { get; set; }
        public DateTime? ClmCapDateTime { get; set; }
        public DateTime? ClmFwdDateTime { get; set; }
        public DateTime? ClmFinDateTime { get; set; }
        public DateTime? ClmAutDateTime { get; set; }
        public DateTime? ClmRefDateTime { get; set; }
        public DateTime? ClmRepDateTime { get; set; }
        public DateTime? ClmCanDateTime { get; set; }
        public string ClmCanReason { get; set; }
        public string ClmRepReason { get; set; }
        public int? CapitalKey { get; set; }
        public short? RelationKey { get; set; }
        public decimal? FldClaimAmountpaid { get; set; }
        public DateTime? FldClaimDatepaid { get; set; }
        public string FldClaimRefnumber { get; set; }

        public virtual Capital CapitalKeyNavigation { get; set; }
        public virtual Relation RelationKeyNavigation { get; set; }
    }
}
