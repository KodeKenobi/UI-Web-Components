using Microsoft.AspNetCore.Mvc.Rendering;
using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using PolicyManagementModels.PrincipalMemberDetails;

namespace PolicyManagementSystem.Controllers.Models
{
    public class PolicyApplicationViewModel : BaseViewModel
    {
        public Covers Covers { get; set; }

        public string base64String { get; set; }

        public Beneficiary Beneficiary { get; set; }

        public MemberGroup PrincipalMemberDetails { get; set; }
        public AddPrincipalMemberDetails AddPrincipalMemberDetails { get; set; }

        public MemberGroup SpouseDetails { get; set; }

        public MemberCollect Banking { get; set; }

        public MemberCompliance Compliance { get; set; }

        public List<MemberGroup> ChildrenDetails { get; set; }

        public List<MemberGroup> ExtendedFamilies { get; set; }

        public MemberProposer MemberProposer { get; set; }

        public List<MemberProposer> MemberProposerList { get; set; }

        public IEnumerable<SelectListItem> PIBPolicies { get; set; }
        public int? PIBPoliciesId { get; set; }

        public string TotalCover { get; set; }

        public int PrincipalMemberPremium { get; set; }

        public int ExtendMemberPremium { get; set; }

        public IEnumerable<SelectListItem> MTGPolicies { get; set; }

        public int? MTGPoliciesId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime CommencementDate { get; set; }

        public string OtherBankName { get; set; }

        public bool IsStopOrder { get; set; }

        public int CoverID { get; set; }

        public int MTGCoverID { get; set; }
        public int CurrentPage { get; set; }

        public int MembersCount { get; set; }

        public string RelationOther { get; set; }
    }
}
