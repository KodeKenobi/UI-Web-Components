using AspNetCore.Reporting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Reporting.WinForms;
using PolicyManagementDataAccess;
using PolicyManagementDataAccess.Context;
using PolicyManagementDataAccess.Helpers;
using PolicyManagementSystem.Controllers.Models;
using PolicyManagementModels.PrincipalMemberDetails;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;


namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class PolicyApplicationController : Controller
    {
        private IPolicyApplicationRepository _applicationRegistrationRepository;
        private IClientEngagementRepository _clientEngagementRepository;
        private IWebHostEnvironment _env;
        private IPolicyApplicationRepository _policyApplicationRepository;
        private IMemberApplicationRepository _memberApplicationRepository;
        private IUserAccountRepository _userAccountRepository;
        private IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;






        public PolicyApplicationController(IMemberApplicationRepository memberApplicationRepository,
            IWebHostEnvironment env,IPolicyApplicationRepository applicationRegistrationRepository, 
            IClientEngagementRepository clientEngagementRepository, IUserAccountRepository userAccountRepository, IMapper mapper,
            UserManager<IdentityUser> userManager, IPolicyApplicationRepository policyApplicationRepository)
        {
            _applicationRegistrationRepository = applicationRegistrationRepository;
            _clientEngagementRepository = clientEngagementRepository;
            _env = env;
            _memberApplicationRepository = memberApplicationRepository;
            _userAccountRepository = userAccountRepository;
            _mapper = mapper;
            _userManager = userManager;
            _policyApplicationRepository = policyApplicationRepository;


        }

        [HttpGet]
        public IActionResult Index()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyApplication/Index.cshtml", model);
        }

        public IActionResult PolicyMemberList(int memPropNum)
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            var memberProposer = _policyApplicationRepository.MemberProposerGetById(memPropNum);
            return View("~/Pages/PolicyApplication/PolicyMemberList.cshtml");
        }
            //[HttpGet]
            //public IActionResult GetById(string email)
            //{
            //    var memberApplication = _memberApplicationRepository.MemberApplicationGetByEmail(email);
            //    var model = _mapper.Map<PolicyApplicationViewModel>(memberApplication);
            //    return Ok(model);
            //}
            [HttpPost]
        public IActionResult SavePrincipalMemberDetails(PolicyApplicationViewModel model)
        {
            var pibPolicies = _applicationRegistrationRepository.GetPIBPolicyList();

            var mtgPolicies = _applicationRegistrationRepository.GetMTGPolicyList();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var memberApplication = _memberApplicationRepository.MemberApplicationGetByEmail(User.Identity.Name);
            if (pibPolicies != null)
            {
                model.AddPrincipalMemberDetails.CoverID = Convert.ToInt32(pibPolicies);
            }
            else if (mtgPolicies != null && pibPolicies == null)
            {
                model.AddPrincipalMemberDetails.CoverID = Convert.ToInt32(mtgPolicies);
            }
            if (memberApplication != null)
            {
                model.AddPrincipalMemberDetails.UserNum = Convert.ToInt32(memberApplication.MemDetNum);
                model.AddPrincipalMemberDetails.Title = memberApplication.Title;
                model.AddPrincipalMemberDetails.ContactPerson = memberApplication.FirstName;
                // model.PrincipalMemberDetails.M = memberApplication.MaidenName;
                model.AddPrincipalMemberDetails.Surname = memberApplication.Surname;
                model.AddPrincipalMemberDetails.Idnum = memberApplication.Idnum;
                model.AddPrincipalMemberDetails.CaptureDate = DateTime.Now.ToString();
                model.AddPrincipalMemberDetails.ContactEmail = memberApplication.Email;
                model.AddPrincipalMemberDetails.ContactCell = memberApplication.Phone;
                if (userId != null)
                {
                    model.AddPrincipalMemberDetails.UserID = userId;
                }

            }
            else
            {
                try
                {
                    _policyApplicationRepository.AddPrincipalMemberDetails(model.AddPrincipalMemberDetails);
                    //return Ok();
                }
                catch (Exception )
                {

                }
            }
            model.MemberProposer.UserId = Guid.Parse(userId);
            model.MemberProposer.Status = "Review";
            var memPropKey = _applicationRegistrationRepository.AddMemberProposer(model.MemberProposer);
            return View("~/Pages/PolicyApplication/Create.cshtml", model);

        }

      

        [HttpGet]
        public IActionResult Create()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

            var memberApplication = _memberApplicationRepository.MemberApplicationGetByEmail(User.Identity.Name);

            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            var pibPolicies = _applicationRegistrationRepository.GetPIBPolicyList();

            var mtgPolicies = _applicationRegistrationRepository.GetMTGPolicyList();
            

            //Populate policies
            model.PIBPolicies = pibPolicies.Select(a => new SelectListItem
            {
                Text = a.PlanID + " - Cover R" + a.CoverAmount,
                Value = Convert.ToString( a.PolicyCoverID)
            });

            model.MTGPolicies = mtgPolicies.Select(a => new SelectListItem
            {
                Text = a.PlanID + " - Cover R" + a.CoverAmount,
                Value = Convert.ToString(a.PolicyCoverID)
            });

            if (memberApplication != null)
            {
                var memberGroup = new MemberGroup();
                var memberProposer = new MemberProposer();
                memberGroup.ContactPerson = memberApplication.FirstName;
                memberGroup.MiddleName = memberApplication.MaidenName;
                memberGroup.Surname = memberApplication.Surname;
                memberGroup.Idnum = memberApplication.Idnum;
                memberGroup.Title = memberApplication.Title;
                memberGroup.ContactPhone = memberApplication.Phone;

                memberProposer.FirstName = memberApplication.FirstName;
                memberProposer.SecondName = memberApplication.MaidenName;
                memberProposer.Surname = memberApplication.Surname;
                memberProposer.Idnum = memberApplication.Idnum;
                memberProposer.Title = memberApplication.Title;
                memberProposer.ContactPhone = memberApplication.Phone;
                memberProposer.ContactEmail = memberApplication.Email;

                model.PrincipalMemberDetails = memberGroup;
                model.MemberProposer = memberProposer;

                return View("~/Pages/PolicyApplication/Create.cshtml", model);
            }
            else if(memberApplication== null)
            {

            }
            return View("~/Pages/PolicyApplication/Create.cshtml", model);
        }
        //Private helper methods
        private int CalculateAge(DateTime birthDay)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDay.Year;
            if (birthDay > today.AddYears(-age)) { 
            }

            return age;
        }
        private decimal CalculateTotal()
        {
            decimal total = 0;
            return total;
        }

        [HttpPost]
        public IActionResult Create(PolicyApplicationViewModel model, string submit, string save)
        {

            //check if its Print Summary
            if (submit == "Print")
            {
                TempData["member"] = model;

                return RedirectToAction("DownloadPIBContract", new { model = model });
            }

            try
            {
                //Start with the business rules before we start adding
                if (model.Beneficiary.Idnum == model.PrincipalMemberDetails.Idnum)
                {
                    ModelState.AddModelError("error", "Beneficiary ID must not be the same as the principal member");

                    return View("~/Pages/PolicyApplication/Create.cshtml", model);
                }

                if (model.MemberProposer.RelationToPrincipalMember == "Other(Specify)")
                {
                    model.MemberProposer.RelationToPrincipalMember = model.RelationOther;
                }
            
              
                //Get the logged in userId
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                //Add the premium payer details
                model.MemberProposer.UserId = Guid.Parse(userId);
                model.MemberProposer.Status = "Review";

                var memPropKey = _applicationRegistrationRepository.AddMemberProposer(model.MemberProposer);

                //Add Banking details
                if (model.Banking.DoBankName == "Other")
                {
                    model.Banking.DoBankName = model.OtherBankName;
                }

                model.Banking.CollectSurname = model.MemberProposer.Surname;
                model.Banking.CollectIdnum = model.MemberProposer.Idnum;
                model.Banking.CollectStart = int.Parse(model.CommencementDate.ToString("yyyyMMdd"));
                model.Banking.MemPropKey = memPropKey;
                model.Banking.UserId = Guid.Parse(userId);

                var env = _env;
                var verificationLink = Url.Action("VerifyPolicy", "PolicyApplication", new { id = memPropKey }, Request.Scheme);

                var memColKey = _applicationRegistrationRepository.AddBankingDetails(model.Banking, model.MemberProposer.FirstName, env.WebRootPath, verificationLink);

                //Add the Principal details
                model.PrincipalMemberDetails.CoverId = model.CoverID;
                model.PrincipalMemberDetails.MemPropKey = memPropKey;
                model.PrincipalMemberDetails.InsInterest = "Principal";
                model.PrincipalMemberDetails.MemColKey = memColKey;
                model.PrincipalMemberDetails.UserId = Guid.Parse(userId);

                var PrincipalMemGrpKey = _applicationRegistrationRepository.AddMemberGroup(model.PrincipalMemberDetails);

                //Add Beneficiary
                model.Beneficiary.UserId = Guid.Parse(userId);
                model.Beneficiary.MemPropNum = memPropKey;

                _applicationRegistrationRepository.AddBeneficiary(model.Beneficiary);

                //Add spouse Details if filled in the form
                if (!string.IsNullOrEmpty(model.SpouseDetails.ContactPerson))
                {
                    model.SpouseDetails.CoverId = model.CoverID;
                    model.SpouseDetails.MemPropKey = memPropKey;
                    model.SpouseDetails.UserId = Guid.Parse(userId);
                    model.SpouseDetails.InsInterest = "Spouse";
                    model.SpouseDetails.MemColKey = memColKey;
                    _applicationRegistrationRepository.AddMemberGroup(model.SpouseDetails);
                }

                //Add children if added
                if (!string.IsNullOrEmpty(model.ChildrenDetails.FirstOrDefault().Idnum))
                {
                    foreach (var child in model.ChildrenDetails)
                    {
                        child.CoverId = model.CoverID;
                        child.MemPropKey = memPropKey;
                        child.UserId = Guid.Parse(userId);
                        child.InsInterest = "Child";
                        child.MemColKey = memColKey;

                        //Check if the child is older than 21 years
                        //var birthday = DateTime.ParseExact(child.Idnum.Substring(0, 6), "yyMMdd", null);

                        //var age = CalculateAge(birthday);

                        //if(age > 21)
                        //{
                        //    ModelState.AddModelError("", "Child age must not be greater than 21");

                        //    var errmodel = new PolicyApplicationViewModel() { BrokerNotificationList = _clientEngagementRepository.GetBrokerNotificationList() };

                        //    return View("~/Pages/PolicyApplication/Create.cshtml", errmodel);
                        //}

                        _applicationRegistrationRepository.AddMemberGroup(child);
                    }
                }

                //Add extended family if added
                if (!string.IsNullOrEmpty(model.ExtendedFamilies.FirstOrDefault().Idnum))
                {
                    foreach (var fam in model.ExtendedFamilies)
                    {
                        fam.MemPropKey = memPropKey;
                        fam.InsInterest = "Extended Family";
                        fam.UserId = Guid.Parse(userId);
                        fam.MemColKey = memColKey;

                        _applicationRegistrationRepository.AddMemberGroup(fam);
                    }
                }

                //Save the signature
                byte[] bytes = Convert.FromBase64String(model.base64String.Split(',')[1]);

                var filePath = $"{_env.WebRootPath}\\Signatures\\Signature" + memPropKey + ".png";

                using (var imageFile = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                //Add Compliance
                model.Compliance.MemPropKey = memPropKey;
                model.Compliance.UserId = Guid.Parse(userId);
                model.Compliance.PremiumPayerSignature = filePath;

                _applicationRegistrationRepository.AddMemberComplaince(model.Compliance);

                var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

                var smodel = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };
                //add message before returning view. Send email confirmation
                return View("~/Pages/PolicyApplication/ApplicationSubmitted.cshtml", smodel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

                var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

                var errmodel = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

                return View("~/Pages/PolicyApplication/Create.cshtml", errmodel);
            }
            
        }

        public ActionResult VerifyPolicy(int id)
        {
            var model = new PolicyApplicationViewModel();

            //Get premium payer details
            var premiumMember = _applicationRegistrationRepository.MemberProposerGetById(id);

            //Get Banking details
            var bankingDetails = _applicationRegistrationRepository.BankingDetailsGetByUserId(id);

            //Get member details
            var memberDetails = _applicationRegistrationRepository.MembersGetByUserId(id);

            //Set Principal spouse details from members list
            foreach (var member in memberDetails)
            {
                if (member.InsInterest == "Principal")
                {
                    model.PrincipalMemberDetails = member;
                }

                if (member.InsInterest == "Spouse")
                {
                    model.SpouseDetails = member;
                }
            }

            var children = new List<MemberGroup>();
            var extendedFam = new List<MemberGroup>();
            //Set the extended family and children from the list
            foreach (var member in memberDetails)
            {
                if (member.InsInterest == "Child")
                {
                    children.Add(member);
                }

                if (member.InsInterest == "Extended Family")
                {
                    extendedFam.Add(member);
                }
            }

            //Get beneficiary
            var beneficiary = _applicationRegistrationRepository.BeneficiaryGetByUserId(id);

            //Get Compliance
            var compliance = _applicationRegistrationRepository.MemberComplainceGetByUserId(id);

            //Assign commecement date
            //if (bankingDetails.CollectStart.HasValue)
            //{
            //    model.CommencementDate = DateTime.Parse(bankingDetails.CollectStart.ToString());
            //}

            DateTime dt;
            if (DateTime.TryParseExact(bankingDetails.CollectStart.ToString(), "yyyyMMdd",
                          CultureInfo.InvariantCulture,
                          DateTimeStyles.None, out dt))
            {
                model.CommencementDate = dt;
            }

            //Assign values to the model
            model.MemberProposer = premiumMember;
            model.Compliance = compliance;
            model.ChildrenDetails = children;
            model.Banking = bankingDetails;
            model.Beneficiary = beneficiary;
            model.ExtendedFamilies = extendedFam;
            model.ReviewCount = _applicationRegistrationRepository.GetReviewList().Count();

            if (premiumMember.Status == "Review")
            {
                return View("~/Pages/PolicyApplication/VerifyPolicy.cshtml", model);
            }

            return View("~/Pages/PolicyApplication/ApplicationLocked.cshtml", model);
        }

        [HttpPost]
        public ActionResult Verify(int id, string submit, string reason)
        {
            if (submit == "Approve")
            {
                //Change the application status and save
                var memberProposer = _applicationRegistrationRepository.MemberProposerGetById(id);

                memberProposer.Status = "Approved";

                //Udate the entity
                _applicationRegistrationRepository.MemberProposerUpdate(memberProposer, string.Empty, string.Empty, string.Empty);  
                //After application has been approved, email should be sent to the customer

                //TODO:If the application is stop order Generate stop order form
                var banking = _applicationRegistrationRepository.BankingDetailsGetByUserId(id);

                var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

                var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList, MemberProposer = memberProposer };

                if (banking.CollectType == "S/O")
                {
                    //Generate stop order
                    model.IsStopOrder = true;
                }

                return View("~/Pages/PolicyApplication/PolicyAccepted.cshtml", model);
            }
            else
            {
                //Decline the application
                var memberProposer = _applicationRegistrationRepository.MemberProposerGetById(id);

                memberProposer.Status = "Declined";

                //Send the premium member an email
                var env = _env;
                var changeLink = Url.Action("Edit", "PolicyApplication", new { id = id }, Request.Scheme);

                //Udate the entity
                _applicationRegistrationRepository.MemberProposerUpdate(memberProposer, env.WebRootPath, reason, changeLink);

                var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

                var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

                return View("~/Pages/PolicyApplication/PolicyDeclined.cshtml", model);

            }
        }

        public IActionResult DownloadPIBContract(int id, PolicyApplicationViewModel model)
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{_env.WebRootPath}\\Reports\\PIBContract.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var memberProposer = _applicationRegistrationRepository.MemberProposerGetById(id);

            var banking = _applicationRegistrationRepository.BankingDetailsGetByUserId(id);

            //Get beneficiary
            var beneficiary = _applicationRegistrationRepository.BeneficiaryGetByUserId(id);

            //Get Compliance
            var compliance = _applicationRegistrationRepository.MemberComplainceGetByUserId(id);

            //Set the report parameters
            parameters.Add("FullNames", memberProposer.FirstName + " " + memberProposer.Surname);
            parameters.Add("RankOccupation", memberProposer.Occupation);
            parameters.Add("SectionStation", "");
            parameters.Add("SalaryForceNo", "");
            parameters.Add("PaypointNo", "");
            parameters.Add("IdNum", memberProposer.Idnum);
            parameters.Add("Address1", memberProposer.Address1);
            parameters.Add("Address2", memberProposer.Address2);
            parameters.Add("Address3", memberProposer.Address3);
            parameters.Add("PayerCellNo", memberProposer.ContactPhone);
            parameters.Add("WorkTel", memberProposer.WorkPhone);
            parameters.Add("Email", memberProposer.ContactEmail);
            parameters.Add("Department", "");
            parameters.Add("Premium", "");
            parameters.Add("EffectiveDate", banking.CollectStart.ToString());
            parameters.Add("PolicyNumber", memberProposer.MemPropKey.ToString());
            parameters.Add("CollectFreq", banking.CollectFreq.ToString());
            parameters.Add("Date", DateTime.Now.ToShortDateString());
            parameters.Add("DateLong", DateTime.Now.ToLongDateString());
            parameters.Add("PolicyStatus", "Approved");
            parameters.Add("ExtendedPremium", "0.00");
            parameters.Add("TotalPremium", "0.00");
            parameters.Add("PremiumPayerName", memberProposer.FirstName + " " + memberProposer.Surname);
            parameters.Add("PaymentMethod", banking.CollectType.ToString());
            parameters.Add("AccountNo", banking.DoAccNum.ToString());
            parameters.Add("BankName", banking.DoBankName.ToString());
            parameters.Add("AccountType", banking.DoAccType.ToString());
            parameters.Add("BranchName", banking.DoBranchName.ToString());
            parameters.Add("BranchCode", banking.DoBranchCode.ToString());
            parameters.Add("DebitDay", banking.DoDebitDay.ToString());
            parameters.Add("SignatureUrl", compliance.PremiumPayerSignature.ToString());


            var dsBen = new PolicyManagementSystem.Controllers.Models.DatasetBeneficiary();
            var listBen = new List<DatasetBeneficiary>();
            dsBen.BeneficiaryName = beneficiary.FirstName + " " + beneficiary.Surname;
            dsBen.Relation = beneficiary.Alias;
            dsBen.IDNumber = beneficiary.Idnum;
            dsBen.PhoneNumber = "n/a";
            dsBen.FaxNumber = "n/a";

            listBen.Add(dsBen);

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("BeneficiaryName");
            dt.Columns.Add("Relation");
            dt.Columns.Add("IDNumber");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("FaxNumber");
            dt.Rows.Add(dsBen);

            //ReportDataSource rds = new ReportDataSource("Beneficiary", dt);
            //rds.Value = listBen;

            AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(path);
            
            //localReport.AddDataSource("Beneficiary", rds);

            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public IActionResult DownloadStopOrder(int id)
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{_env.WebRootPath}\\Reports\\StopOrder.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            var memberProposer = _applicationRegistrationRepository.MemberProposerGetById(id);

            var banking = _applicationRegistrationRepository.BankingDetailsGetByUserId(id);

            //Set the report parameters
            //parameters.Add
            parameters.Add("FullNames", memberProposer.FirstName + " " + memberProposer.SecondName);
            parameters.Add("RankOccupation", memberProposer.Occupation);
            parameters.Add("SectionStation", "");
            parameters.Add("SalaryForceNo", "");
            parameters.Add("PaypointNo", "");
            parameters.Add("IdNum", memberProposer.Idnum);
            parameters.Add("Address1", memberProposer.Address1);
            parameters.Add("Address2", memberProposer.Address2);
            parameters.Add("Address3", memberProposer.Address3);
            parameters.Add("PayerCellNo", memberProposer.ContactPhone);
            parameters.Add("WorkTel", memberProposer.WorkPhone);
            parameters.Add("Email", memberProposer.ContactEmail);
            parameters.Add("Department", "");
            parameters.Add("Premium", "");
            parameters.Add("EffectiveDate", banking.CollectStart.ToString());
            parameters.Add("PolicyNumber", memberProposer.MemPropKey.ToString());
            parameters.Add("CollectFreq", banking.CollectFreq.ToString());


            //get products from product table 
            AspNetCore.Reporting.LocalReport localReport = new AspNetCore.Reporting.LocalReport(path);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            return File(result.MainStream, "application/pdf");
        }

        public ActionResult ReviewList(int no)
        {
            var model = new PolicyApplicationViewModel() { MembersCount = no, MemberProposerList = _applicationRegistrationRepository.GetReviewList(), ReviewCount = _applicationRegistrationRepository.GetReviewList().Count() };

            return PartialView("~/Pages/PolicyApplication/ReviewList.cshtml", model);
        }

        public ActionResult LoadChildren(int no)
        {
            var model = new PolicyApplicationViewModel() { MembersCount = no };

            return PartialView("~/Pages/PolicyApplication/_ChildrenDetails.cshtml", model);
        }
        //public ActionResult LoadTotalPremium(string idNum, string name, int coverID,int pPremium, int ePremium)
        //{
        //    var model = new PolicyApplicationViewModel();
        //    var PrincipalPremium = pPremium;
        //    var ExtendedPremium = ePremium;
        //    var birthday = DateTime.ParseExact(idNum.Substring(0, 6), "yyMMdd", null);
        //    var age = CalculateAge(birthday);
        //    if(name=="PrincipalMemberDetails.Idnum")
        //    {
        //       var premium = Convert.ToInt32(_applicationRegistrationRepository.getPolicyList().FirstOrDefault(p => p.CoverID == coverID));
        //        if (age > 64)
        //        {
        //           premium += 88;
        //        }

        //       PrincipalPremium = premium;
        //    }
        //    if (name == "ExtendedFamiliesIDNumber")
        //    {
        //        var policyFlag = _applicationRegistrationRepository.GetPIBPolicyList().FirstOrDefault(p => p.CoverID == coverID && p.CoverType == CoverType.PIBCover);
        //        var plan = _applicationRegistrationRepository.GetMTGPolicyList().FirstOrDefault(p => p.CoverID == coverID && p.CoverType == CoverType.MTGCover).PlanID;
        //        var premiums = _applicationRegistrationRepository.getPolicyList().Where(p => p.CoverType ==CoverType.MTGCover && p.Description == "Extended");
        //        //  var premiums = _applicationRegistrationRepository.getPolicyList().Where(p => p.CoverType == CoverType.PIBCover && p.PlanID = plan && p.Description == "Extended");

        //        //var minAge = int.Parse(item.MinAge);
        //        //       var maxAge = int.Parse(item.MaxAge);

        //        var listPremiums = new List<PremiumModel>();
        //    }
        //    return PartialView("~/Pages/PolicyApplication/_TotalPremium.cshtml", model);

        //}

        public ActionResult LoadTotalPremium(string idNum, string name, int coverId, int pPremium, int ePremium)
        {
            var model = new PolicyApplicationViewModel();

            var PrincipalPremium = pPremium;
            var ExtendedPremium = ePremium;

            var birthday = DateTime.ParseExact(idNum.Substring(0, 6), "yyMMdd", null);

            var age = CalculateAge(birthday);

            if (name == "PrincipalMemberDetails.Idnum")
            {
                //Then get the premium for principal member
                var premium = Convert.ToInt32(_applicationRegistrationRepository.getPolicyList().FirstOrDefault(p => p.PolicyCoverID == coverId));

                if (age > 64)
                {
                    premium += 88;
                }

                PrincipalPremium = premium;
            }

            if (name == "ExtendedFamiliesIDNumber")
            {
                var listPremiums = new List<PremiumModel>();

                var policyFlag = _applicationRegistrationRepository.GetPIBPolicyList().FirstOrDefault(p => p.PolicyCoverID == coverId && p.CoverType == CoverType.PIBCover);
                var plan = _applicationRegistrationRepository.GetMTGPolicyList().FirstOrDefault(p => p.PolicyCoverID == coverId && p.CoverType == CoverType.MTGCover).PlanID;
                var premiums = _applicationRegistrationRepository.getPolicyList().Where(p => p.CoverType == CoverType.PIBCover && p.Description == "Extended");

                // var premiums = _applicationRegistrationRepository.getPolicyList().Where(p => p.CoverType == CoverType.PIBCover && p.PlanID = plan && p.Description == "Extended");
              
                foreach (var item in premiums)
                {
                    var minAge = item.MinAge;
                    var maxAge = item.MaxAge;

                    if (age > minAge && age <= maxAge)
                    {
                        ExtendedPremium = Convert.ToInt32(item.Premium);
                        break;
                    }
                }

                var premium = premiums.Where(x => age > x.MinAge && age <= x.MaxAge);

                //ExtendedPremium += int.Parse(premium.FirstOrDefault().Premium);
            }

            //Calculate the total premium to be paid
            model.TotalCover = "R " + (PrincipalPremium + ExtendedPremium);
            model.PrincipalMemberPremium = PrincipalPremium;
            model.ExtendMemberPremium = ExtendedPremium;

            return PartialView("~/Pages/PolicyApplication/_TotalPremium.cshtml", model);
            }

            public ActionResult LoadSiblings(int no)
        {
            var model = new PolicyApplicationViewModel() { MembersCount = no };

            return PartialView("~/Pages/PolicyApplication/_ExtendedFamilies.cshtml", model);
        }

        //public IActionResult ViewPolicy()
        //{
        //    var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
        //    var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

        //    return View("~/Pages/PolicyManagement/PolicyList.cshtml", model);
        //}
    }
}
