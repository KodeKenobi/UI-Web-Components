using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolicyManagementModels.PrincipalMemberDetails;

namespace PolicyManagementDataAccess
{
    public interface IPolicyApplicationRepository
    {
        IEnumerable<PolicyCover> getPolicyList();

        //List<New> GetPIBPolicyList();

        //List<New> GetMTGPolicyList();
        IEnumerable<PolicyCover> GetPIBPolicyList();
        IEnumerable<PolicyCover> GetMTGPolicyList();

        void AddBeneficiary(Beneficiary beneficiary);

        void BeneficiaryUpdate(Beneficiary beneficiary);

        void AddMemberComplaince(MemberCompliance memberCompliance);
        void AddMemberDetails(MemberGroup memberGroup);

        Beneficiary BeneficiaryGetByUserId(int userId);
        List<MemberProposer> MemberProposerGetList(int currentPage, string searchValue, int pageSize);

        void MemberProposerUpdate(MemberProposer memberProposer, string webRootPath, string reason, string changeLink);

        MemberCompliance MemberComplainceGetByUserId(int userId);

        void MemberComplainceUpdate(MemberCompliance memberCompliance);

        List<MemberProposer> GetReviewList();

        MemberGroup PrincipalMemberDetailsGetByUserId(Guid userId);
        public MemberGroup GetPrincipalMemberDetailsGetById(int id);

        MemberGroup SpouseDetailsGetByUserId(Guid userId);

        List<MemberGroup> ChildrenGetByUserId(Guid userId);

        List<MemberGroup> MembersGetByUserId(int userId);

        List<MemberGroup> ExtendedFamiliesGetByUserId(Guid userId);

        MemberCollect BankingDetailsGetByUserId(int userId);

        //MemberProposer MemberProposerGetById(int userId);
        MemberProposer MemberProposerGetById(int id);

        int AddMemberGroup(MemberGroup memberGroup);

        void MemberGroupUpdate(MemberGroup memberGroup);
        List<MemberGroup> MembersGetByMemPropNum(int memPropNum);


        int AddBankingDetails(MemberCollect memberCollect,string userName, string webRootPath, string verificationLink);

        void BankingDetailsUpdate(MemberCollect memberCollect);

        int AddMemberProposer(MemberProposer memberProposer);
        MemberApplication GetApplicationsByNumber(int MemDetNum);
        decimal GetPolicyPremium(PolicyCover id);
        Addresses GetAddressById(MemberApplication model);
        MemberGroup AddPrincipalMemberDetails(AddPrincipalMemberDetails model);

   //    MemberGroup GetMemberById(MemberGroup id);


    }
}
