using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess
{
    public interface IPolicyManagementRepository
    {
        void UpdateBeneficiary(Beneficiary beneficiary);

        void UpdateMemberGroup(MemberGroup memberGroup);

        void UpdateBankingDetails(MemberCollect memberCollect);

        void UpdateMemberProposer(MemberProposer memberProposer);
        void UpdateMemberDetail(MemberDetail memberDetail);

        
        List<MemberProposer> MemberProposerGetList(int currentPage, string searchValue, int pageSize);

        MemberProposer MemberProposerGetById(int id);


        Beneficiary BeneficiaryGetByMemGrpNum(int memGrpNum);

        List<MemberGroup> MembersGetByMemPropNum(int memPropNum);

        MemberCollect MemberCollectGetbyId(int id);
        MemberDetail MemberDetailsGetById(int id);
        void AddBeneficiary(AmmendBeneficiary beneficiary);
       // void 

        int AddMemberGroup(AmmendMemberGroup memberGroup);

        int AddBankingDetails(AmmendMemberCollect memberCollect);

        int AddMemberProposer(AmmendMemberProposer memberProposer);
        TblUseraccount UserAccountsGetById(int id);
        SecureUser SecureUserGetById(int id);
    }
}
