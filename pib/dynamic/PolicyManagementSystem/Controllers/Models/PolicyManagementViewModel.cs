using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class PolicyManagementViewModel : BaseViewModel
    {
        //internal object FirstName;

        public List<MemberProposer> MemberProposerList { get; set; }

        public Beneficiary Beneficiary { get; set; }

        public MemberGroup PrincipalMemberDetails { get; set; }

        public MemberGroup SpouseDetails { get; set; }

        public MemberCollect Banking { get; set; }

        public List<MemberGroup> ChildrenDetails { get; set; }

        public List<MemberGroup> ExtendedFamilies { get; set; }

        public MemberProposer MemberProposer { get; set; }
        public MemberDetail MemberDetail { get; set; }

        public int CoverID { get; set; }

        public int CurrentPage { get; set; }

        public int MembersCount { get; set; }

        public string RelationOther { get; set; }
    }
}
