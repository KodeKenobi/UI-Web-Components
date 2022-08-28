using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PolicyManagementDataAccess.Context;
using PolicyManagementModels.Policy;
using PolicyManagementModels.PrincipalMemberDetails;
using PolicyManagementDataAccess.Repositories;
using PolicyManagementMailer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Web;
using Microsoft.AspNetCore.Identity;




namespace PolicyManagementDataAccess.Repositories
{
    public class PolicyApplicationRepository : IPolicyApplicationRepository
    {
        private BrkBaseContext context;
        // private DbSet<Covers> policyEntity;
        private DbSet<MemberCollect> memberCollectEntity;
        private DbSet<Beneficiary> beneficiaryEntity;
        private DbSet<MemberGroup> memberGroupEntity;
        private DbSet<MemberProposer> memberProposerEntity;
        private DbSet<MemberCompliance> memberComplianceEntity;
        private IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        ///  private readonly PolicyCover _policyCover;
        ///  private IUserAccountRepository userAccountRepository;
       


        public PolicyApplicationRepository(BrkBaseContext context, IMapper mapper )
        {
            this.context = context;
            // policyEntity = context.Set<Covers>();
            beneficiaryEntity = context.Set<Beneficiary>();
            memberProposerEntity = context.Set<MemberProposer>();
            memberCollectEntity = context.Set<MemberCollect>();
            memberGroupEntity = context.Set<MemberGroup>();
            memberComplianceEntity = context.Set<MemberCompliance>();
           _mapper = mapper;
          // _policyCover = policyCover;
        }

        public IEnumerable<PolicyCover> getPolicyList()
        {
            try
            {
                return context.PolicyCovers.AsEnumerable(); /*_policyCover.AsEnumerable();*/
            }
            catch (Exception)
            {
                throw;
            }

        }
        public IEnumerable<PolicyCover> GetPIBPolicyList()
        {
            try
            {
                var list = context.PolicyCovers.Where(p => p.Description == "Principal Member" && p.CoverType ==CoverType.PIBCover).ToList().OrderBy(x =>x.Premium);

                return list;
            }
            catch (Exception)
            {

                throw;
            }

        }

       public IEnumerable<PolicyCover> GetMTGPolicyList()
        {
            try
            {
                var list = context.PolicyCovers.Where(p => p.Description == "Principal Member" && p.CoverType == CoverType.MTGCover).ToList().OrderBy(x => x.Premium);

                return list;
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
        public Addresses GetAddressById(MemberApplication model)
        {
            var address = context.Addresses.Find(model.MemDetNum);
            if (address == null) throw new KeyNotFoundException("Address not found");
            return address;
        }
        public MemberGroup AddPrincipalMemberDetails(AddPrincipalMemberDetails model)
        {
            var details = _mapper.Map<MemberGroup>(model);
            context.MemberGroups.Add(details);
            context.SaveChanges();
            return details;
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


        //public List<New> GetPIBPolicyList()
        //{
        //    try
        //    {
        //        var list = policyEntity.Where(p => p.Description == "Principal Member" && p.IsPibflag == "1").ToList().OrderBy(x => int.Parse(x.Premium));

        //        return list.ToList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public List<New> GetMTGPolicyList()
        //{
        //    try
        //    {
        //        var list = policyEntity.Where(p => p.Description == "Principal Member" && p.IsPibflag == "0").ToList().OrderBy(x => int.Parse(x.Premium));

        //        return list.ToList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public List<MemberProposer> GetReviewList()
        {
            try
            {
                return memberProposerEntity.OrderByDescending(x => x.UserDateTime).Where(m => m.Status == "Review").ToList();
            }
            catch (Exception)
            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                throw;
            }
        }
  
        public void AddMemberComplaince(MemberCompliance memberCompliance)
        {
            try
            {
                memberCompliance.Id = Guid.NewGuid();
                memberCompliance.DateCreated = DateTime.Now;

                context.Entry(memberCompliance).State = EntityState.Added;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void MemberProposerUpdate(MemberProposer memberProposer, string webRootPath, string reason, string changeLink)
        {
            try
            {
                var proposer = MemberProposerGetById(memberProposer.MemPropKey);

                if (proposer == null)
                {
                    throw new Exception("user is not found");
                }

                //Then send a decline notification
                if (memberProposer.Status == "Declined")
                {
                    var mailer = new Mailer(_env, _config);

                    mailer.SendDeclineApplicationNotificationEmail(webRootPath, proposer.FirstName, reason, proposer.ContactEmail, changeLink);
                }
                ///var
                proposer.Status = memberProposer.Status;
                proposer.FirstName = memberProposer.FirstName;
                proposer.Surname = memberProposer.Surname;
                proposer.Idnum = memberProposer.Idnum;
                proposer.ContactPhone = memberProposer.ContactPhone;
                proposer.WorkPhone = memberProposer.WorkPhone;
                proposer.Address1 = memberProposer.Address1;
                proposer.Address2 = memberProposer.Address2;
                proposer.Address3 = memberProposer.Address3;
                proposer.PostalCode = memberProposer.PostalCode;
                proposer.ContactEmail = memberProposer.ContactEmail;
                proposer.RelationToPrincipalMember = memberProposer.RelationToPrincipalMember;

                //var mailer = new Mailer(_env, _config);
                //var sms  = mailer.SendSMS(proposer.ContactPhone, "This is your otp");

                //update user
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddBeneficiary(Beneficiary beneficiary)
        {
            try
            {
                //get the last ID
                var newID = context.Beneficiaries.OrderByDescending(x => x.BeneficiaryId).FirstOrDefault().BeneficiaryId + 1;

                //beneficiary.BeneficiaryId = newID;
                beneficiary.UserDateTime = DateTime.Now;
                context.Entry(beneficiary).State = EntityState.Added;

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int AddMemberGroup(MemberGroup memberGroup)
        {
            try
            {
                //get the last ID
                var newID = context.MemberGroups.OrderByDescending(x => x.MemGrpNum).FirstOrDefault().MemGrpNum + 1;

                memberGroup.MemGrpNum = newID;
                memberGroup.UserDateTime = DateTime.Now;

                context.Entry(memberGroup).State = EntityState.Added;

                context.SaveChanges();

                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int AddBankingDetails(MemberCollect memberCollect, string userName, string webRootPath, string verificationLink)
        {
            try
            {
                //get the last ID
                var newID = context.MemberCollects.OrderByDescending(x => x.MemColKey).FirstOrDefault().MemColKey + 1;

                memberCollect.MemColKey = newID;
                memberCollect.UserDateTime = DateTime.Now;

                context.Entry(memberCollect).State = EntityState.Added;

                context.SaveChanges();

                //Send the verification officer the notification
                var mailer = new Mailer(_env, _config);

                mailer.SendApplicationNotificationEmail(webRootPath, userName, "chulzmch@gmail.com", verificationLink);

                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public int AddMemberProposer(MemberProposer memberProposer)
        {
            try
            {
                //get the last ID
                var newID = context.MemberProposers.OrderByDescending(x => x.MemPropKey).FirstOrDefault().MemPropKey + 1;

                memberProposer.MemPropKey = newID;
                memberProposer.UserDateTime = DateTime.Now;

                context.Entry(memberProposer).State = EntityState.Added;

                context.SaveChanges();



                return newID;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
       
        public void AddMemberDetails(MemberGroup memberGroup)
        {
            try
                // var memberApplication = MemberApplicationGetByEmail(User.Identity.Name);
            {
                var newId = context.MemberGroups.OrderByDescending(x => x.MemGrpNum).FirstOrDefault().MemGrpNum + 1;
                var memberApplication = new MemberApplication();
               // SingleOrDefault

                //var principalMemberDetails =
                //memberGroup.Title = e;
                //memberGroup.ContactPerson = memberApplication.FirstName;
                //// model.PrincipalMemberDetails.M = memberApplication.MaidenName;
                //memberGroup.Surname = memberApplication.Surname;
                //memberGroup.Idnum = memberApplication.Idnum;
                //memberGroup.CaptureDate = Convert.ToInt16(DateTime.Now);
                //memberGroup.ContactEmail = memberApplication.Email;

            }
            catch
            {

            }

            }

        public Beneficiary BeneficiaryGetByUserId(int userId)
        {
            try
            {
                return beneficiaryEntity.SingleOrDefault(s => s.MemPropNum == userId);
            }
            catch (Exception)
            {
                throw;
            }

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

        public List<MemberGroup> MembersGetByUserId(int userId)
        {
            try
            {
                return memberGroupEntity.Where(s => s.MemPropKey == userId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MemberGroup PrincipalMemberDetailsGetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }
        public MemberGroup GetPrincipalMemberDetailsGetById(int id)
        {
        return getMemberGroup(id);
         }

        public MemberGroup SpouseDetailsGetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<MemberGroup> ChildrenGetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public List<MemberGroup> ExtendedFamiliesGetByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public MemberCollect BankingDetailsGetByUserId(int userId)
        {
            try
            {
                return memberCollectEntity.SingleOrDefault(s => s.MemPropKey == userId);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public MemberCompliance MemberComplainceGetByUserId(int userId)
        {
            try
            {
                return memberComplianceEntity.SingleOrDefault(s => s.MemPropKey == userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
            
        public void MemberComplainceUpdate(MemberCompliance memberCompliance)
        {
            try
            {
                var com = MemberComplainceGetByUserId(memberCompliance.MemPropKey.Value);

                if (com == null)
                {
                    throw new Exception("Complaince is not found");
                }

                com.Advice = memberCompliance.Advice;
                com.ApplicationStage = memberCompliance.ApplicationStage;
                com.ClaimsProcedure = memberCompliance.ClaimsProcedure;
                com.DebitOrder = memberCompliance.DebitOrder;
                com.Exclusions = memberCompliance.Exclusions;
                com.IntermediaryStatus = memberCompliance.IntermediaryStatus;
                com.PolicyReplacement = memberCompliance.PolicyReplacement;
                com.RightsReserved = memberCompliance.RightsReserved;
                com.WaitingPeriods = memberCompliance.WaitingPeriods;

                //update
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddDetails(MemberGroup model)
        {
            //var curretlyLoggedInUserId = (((System.Security.Claims.ClaimsPrincipal)System.Web.HttpContext.Current.User).Claims).ToList()[0].Value;
            //  var memberDetails = context.MemberDetails.SingleOrDefault(x => x.Idnum == model.Idnum);
            //var memberApplication = MemberApplicationGetByEmail(User.Identity.Name);
           /// var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
           // var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            try
            {

                //if (memberDetails == null)
                //{
                //    memberDetails.Title = model.Title;
                //    memberDetails.FirstName = model.FirstName;
                //    memberDetails.SecondName = model.SecondName;
                //    memberDetails.Surname = model.Surname;
                //    memberDetails.Idnum = model.Idnum;
                //    memberDetails.Dob = model.Dob;
                //    memberDetails.Occupation =
                //}
            }
            catch (Exception ex)
            {

            }
        }
        public void UpdateMemberGroup(MemberGroup memberGroup)
        {
            //Get MemberGroup
          var member = memberGroupEntity.SingleOrDefault(s => s.MemGrpNum == memberGroup.MemGrpNum);
            try
            {
              
                if(member!=null)
                {
                    member.ContactCell = memberGroup.ContactCell;
                    member.ContactEmail = memberGroup.ContactEmail;
                    member.ContactPerson = memberGroup.ContactPerson;
                    member.ContactPhone = memberGroup.ContactPhone;
                    member.CoverId = memberGroup.CoverId;
                    member.InsInterest = memberGroup.InsInterest;
                    member.InsRef = memberGroup.InsRef;
                    member.MaritalStatus = memberGroup.MaritalStatus;
                 // member.Idnum = memberGroup.Idnum;
                    member.Title = memberGroup.Title;
                }
                else
                {
                    throw new Exception("Member details not found");
                }
            

            }
            catch (Exception)
            {
                throw;
            }

            
            context.MemberGroups.Update(member);
            context.SaveChanges();
        }

        public void MemberGroupUpdate(MemberGroup memberGroup)
        {
            try
            {
                var member = memberGroupEntity.SingleOrDefault(s => s.MemGrpNum == memberGroup.MemGrpNum);

                if (member == null)
                {
                    throw new Exception("Member details not found");
                }

               

                //update
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void BeneficiaryUpdate(Beneficiary beneficiary)
        {
            try
            {
                var bn = BeneficiaryGetByUserId(beneficiary.MemPropNum.Value);

                if (bn == null)
                {
                    throw new Exception("Beneficiary not found");
                }

                bn.FirstName = beneficiary.FirstName;
                bn.Surname = beneficiary.Surname;
                bn.Idnum = beneficiary.Idnum;
                bn.Alias = beneficiary.Alias;

                //update
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public MemberApplication GetApplicationsByNumber(int memDetNum)
        {
            return context.MemberApplications.Find(memDetNum);
        }
        public MemberApplication MemberApplicationGetByEmail(string email)
        {
            return context.MemberApplications.Find(email);
        }
        public void BankingDetailsUpdate(MemberCollect memberCollect)
        {
            try
            {
                var bnk = BankingDetailsGetByUserId(memberCollect.MemPropKey.Value);

                if (bnk == null)
                {
                    throw new Exception("Bank details not found");
                }

                bnk.CollectType = memberCollect.CollectType;
                bnk.CollectFreq = memberCollect.CollectFreq;
                bnk.CollectStart = memberCollect.CollectStart;
                bnk.DoBankName = memberCollect.DoBankName;
                bnk.DoBranchCode = memberCollect.DoBranchCode;
                bnk.DoBranchName = memberCollect.DoBranchName;
                bnk.DoAccNum = memberCollect.DoAccNum;
                bnk.CollectSurname = memberCollect.CollectSurname;
                bnk.DoAccType = memberCollect.DoAccType;
                bnk.DoDebitDay = memberCollect.DoDebitDay;

                //update
                context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }
        // helper methods
        // private Task<TblUseraccount> GetCurrentUserAsync() => UserManager.GetUserAsync(HttpContext.User)

        //private string GetUserId(this ClaimsPrincipal principal)
        //{
        //    if (principal == null)
        //        throw new ArgumentNullException(nameof(principal));

        //    return principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //}
        public decimal GetPolicyPremium(PolicyCover model)
        {
            decimal total = 0;
            var policy = context.PolicyCovers.Find(model.PolicyCoverID);
            if (policy != null)
            {
                total += policy.Premium;

            }
            return total;
        }
        //private decimal CalculatePremium(MemberPolicy policy)
        //{
        //    decimal total = 0;
        //    if (policy.CoverID != 0 || policy.CoverID! < 0)
        //    {
        //        policy.PremiumTotal+=
        //    }
        //}
        //private decimal UpdateCalculatePremium(Policy policy)
        //{
        //    decimal total = 0;
        //    if(policy.CoverID!=0 || policy.CoverID!<0)
        //    {

        //    }
        //}

        private MemberGroup getMemberGroup(int id)
            {
                var member = context.MemberGroups.Find(id);
                if (member == null) throw new KeyNotFoundException("User not found");
                return member;
            }
 
}
}
