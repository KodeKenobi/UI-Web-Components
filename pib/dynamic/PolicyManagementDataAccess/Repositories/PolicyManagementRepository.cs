using Castle.Core.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess.Repositories
{
    public class PolicyManagementRepository : IPolicyManagementRepository
    {
        private BrkBaseContext context;
        private DbSet<MemberCollect> memberCollectEntity;
        private DbSet<Beneficiary> beneficiaryEntity;
        private DbSet<MemberGroup> memberGroupEntity;
        private DbSet<MemberProposer> memberProposerEntity;
        private DbSet<MemberDetail> memberDetail;
        private IHostingEnvironment _env;
        private readonly IConfiguration _config;

        public PolicyManagementRepository(BrkBaseContext context)
        {
            this.context = context;
            beneficiaryEntity = context.Set<Beneficiary>();
            memberProposerEntity = context.Set<MemberProposer>();
            memberCollectEntity = context.Set<MemberCollect>();
            memberGroupEntity = context.Set<MemberGroup>();
            memberDetail = context.Set<MemberDetail>();
        }

        public int AddBankingDetails(AmmendMemberCollect memberCollect)
        {
            try
            {
                var newID = context.AmmendMemberCollects.OrderByDescending(x => x.MemColKey).FirstOrDefault().MemColKey + 1;

                memberCollect.MemColKey = newID;
                memberCollect.UserDateTime = DateTime.Now;

                context.Entry(memberCollect).State = EntityState.Added;

                context.SaveChanges();

                return newID;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void AddBeneficiary(AmmendBeneficiary beneficiary)
        {
            try
            {
                var newID = context.AmmendBeneficiaries.OrderByDescending(x => x.BeneficiaryId).FirstOrDefault().BeneficiaryId + 1;

                beneficiary.BeneficiaryId = newID;
                beneficiary.UserDateTime = DateTime.Now;

                context.Entry(beneficiary).State = EntityState.Added;

                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public int AddMemberGroup(AmmendMemberGroup memberGroup)
        {
            var newID = context.AmmendMemberGroups.OrderByDescending(x => x.MemGrpNum).FirstOrDefault().MemGrpNum + 1;

            memberGroup.MemGrpNum = newID;
            memberGroup.UserDateTime = DateTime.Now;

            context.Entry(memberGroup).State = EntityState.Added;

            context.SaveChanges();

            return newID;
        }

        public int AddMemberProposer(AmmendMemberProposer memberProposer)
        {
            try
            {
                var newID = context.MemberProposers.OrderByDescending(x => x.MemPropKey).FirstOrDefault().MemPropKey + 1;

                memberProposer.MemPropKey = newID;
                memberProposer.UserDateTime = DateTime.Now;

                context.Entry(memberProposer).State = EntityState.Added;

                context.SaveChanges();

                return newID;
            }
            catch (Exception)
            {
                throw;
            }

        }

        //Need to check this logic to display record and search functionality
        public List<MemberProposer> MemberProposerGetList(int currentPage, string searchValue, int pageSize = 20)
        {
            try
            {
                if (currentPage == 0)
                {
                    currentPage = 1;
                }

                //Check if the user entered search
                if (!string.IsNullOrEmpty(searchValue))
                {
                    var filteredList = memberProposerEntity.Where(x => 
                    //var filteredList = memberProposerEntity.ToList().FindAll(x =>
                    x.FirstName.Contains(searchValue) ||
                    x.SecondName.Contains(searchValue) ||
                    x.Surname.Contains(searchValue) ||
                    x.ContactEmail.Contains(searchValue) ||
                    x.ContactPhone.Contains(searchValue)).ToList();

                    return filteredList.OrderBy(d => d.MemPropKey).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
                }

                return memberProposerEntity.OrderBy(d => d.MemPropKey).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public TblUseraccount UserAccountsGetById(int id)
        {
            return context.TblUseraccounts.Find(id);
        }
        public SecureUser SecureUserGetById(int id)
        {
            return context.SecureUsers.Find(id);
        }

        public MemberProposer MemberProposerGetById(int id)
        {
            try
            {
                return memberProposerEntity.SingleOrDefault(s => s.MemPropKey == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Beneficiary BeneficiaryGetByMemGrpNum(int memGrpNum)
        {
            try
            {
                return beneficiaryEntity.SingleOrDefault(x => x.MemGrpNum == memGrpNum);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<MemberGroup> MembersGetByMemPropNum(int memPropNum)
        {
            try
            {
                return memberGroupEntity.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberDetail MemberDetailsGetById(int id)
        {
            try
            {
                return memberDetail.SingleOrDefault(x => x.MemGrpNum == id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberCollect MemberCollectGetbyId(int id)
        {
            try
            {
                return memberCollectEntity.SingleOrDefault(x => x.MemColKey == id);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void UpdateBankingDetails(MemberCollect memberCollect)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeneficiary(Beneficiary beneficiary)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberGroup(MemberGroup memberGroup)
        {
            throw new NotImplementedException();
        }

        public void UpdateMemberProposer(MemberProposer memberProposer)
        {
            throw new NotImplementedException();
        }
   ///  UpdatMemberDetails
        public void UpdateMemberDetail(MemberDetail memberDetail)
        {
            try
            {
               // var user =
                var member = MemberDetailsGetById(memberDetail.MemDetNum);
                if(member!=null)
                {
                    member.FirstName = memberDetail.FirstName;
                    member.Surname = memberDetail.Surname;
                    member.Idnum = memberDetail.Idnum;

                    //member.Ph = memberDetail.ContactPhone;
                    //member.Em = memberDetail.ContactEmail;
                    //member.FirstName = me
                }
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
