using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class VwPolicy
    {
        public int FldPolicyNumber { get; set; }
        public string FldPolicyEasypaynumber { get; set; }
        public int? FldIssuesCount { get; set; }
        public string FldMemberDisplayname { get; set; }
        public string FldMemberIdnumber { get; set; }
        public DateTime? FldMemberDateofbirth { get; set; }
        public int? MemberDetailDob { get; set; }
        public decimal? FldPolicyTotalpremium { get; set; }
        public decimal? FldMemberPremium { get; set; }
        public decimal? FldMemberCover { get; set; }
        public int? FldSchemeId { get; set; }
        public bool? FldProductIsreflag { get; set; }
        public int? FldWaitingperiod { get; set; }
        public DateTime? FldPolicyDatetaken { get; set; }
        public DateTime? FldPolicyCommencementdate { get; set; }
        public DateTime? FldPolicyTerminationdate { get; set; }
        public DateTime? FldPolicyReinstatedate { get; set; }
        public string FldPolicyStatus { get; set; }
        public string FldPolicyViewgroup { get; set; }
        public string FldPolicyCancelreason { get; set; }
        public string FldPolicyInsurableinterest { get; set; }
        public string FldPaymentMethod { get; set; }
        public int? FldPaymentFrequency { get; set; }
        public string FldAccountHolder { get; set; }
        public string FldAccountNumber { get; set; }
        public string FldAccountType { get; set; }
        public short? FldDebitDay { get; set; }
        public string FldBankName { get; set; }
        public string FldBranchName { get; set; }
        public string FldBranchCode { get; set; }
        public int? FldBankId { get; set; }
        public int? FldPremiumpayerId { get; set; }
        public string FldPremiumpayerIdnumber { get; set; }
        public string FldPremiumpayerTitle { get; set; }
        public string FldPremiumpayerFname { get; set; }
        public string FldPremiumpayerLname { get; set; }
        public string FldPremiumpayerDisplayname { get; set; }
        public string FldPremiumpayerOccupation { get; set; }
        public string FldPhysicaladdressLine1 { get; set; }
        public string FldPhysicaladdressLine2 { get; set; }
        public string FldPhysicaladdressTowncity { get; set; }
        public string FldPhysicaladdressPostalcode { get; set; }
        public string FldPostaladdressLine1 { get; set; }
        public string FldPostaladdressLine2 { get; set; }
        public string FldPostaladdressTowncity { get; set; }
        public string FldPostaladdressPostalcode { get; set; }
        public string FldPremiumpayerMobilephone { get; set; }
        public string FldPremiumpayerWorkphone { get; set; }
        public string FldPremiumpayerEmail { get; set; }
        public string FldPremiumpayerStaffno { get; set; }
        public int? FldSalespersonId { get; set; }
        public int? FldBeneficiaryId { get; set; }
        public string FldBeneficiaryTitle { get; set; }
        public string FldBeneficiaryFname { get; set; }
        public string FldBeneficiaryLname { get; set; }
        public string FldBeneficiaryDisplayname { get; set; }
        public string FldBeneficiaryIdnumber { get; set; }
        public int? FldBeneficiaryRelation { get; set; }
        public string FldBeneficiaryPhone { get; set; }
        public string FldBeneficiaryEmail { get; set; }
        public int? FldBeneficiaryFax { get; set; }
        public int? FldMemcollectKey { get; set; }
        public int? FldCollecorgKey { get; set; }
        public string FldCollecorgName { get; set; }
        public DateTime FldServerDate { get; set; }
        public string FldPolicyCapturedby { get; set; }
        public DateTime? FldPolicyDatecaptured { get; set; }
        public int MemDetNum { get; set; }
    }
}
