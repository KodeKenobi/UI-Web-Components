using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess;
using PolicyManagementDataAccess.Context;
using PolicyManagementSystem.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNet.Identity;


namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class PolicyManagementController : Controller
    {
        private IUserAccountRepository _userAccountRepository;
        private IPolicyApplicationRepository _applicationRegistrationRepository;
        private IClientEngagementRepository _clientEngagementRepository;
        private IPolicyManagementRepository _policyManagementRepository;
        //  private IPolicyApplicationRepository _policyApplicationRepository;
        private IWebHostEnvironment _env;
        public PolicyManagementController(IPolicyManagementRepository policyManagementRepository, IPolicyApplicationRepository applicationRegistrationRepository,
            IClientEngagementRepository clientEngagementRepository, IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
            _applicationRegistrationRepository = applicationRegistrationRepository;
            _clientEngagementRepository = clientEngagementRepository;
            _policyManagementRepository = policyManagementRepository;
          //  _policyApplicationRepository = policyApplicationRepository;
        }

        public IActionResult Index()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/Index.cshtml", model);
        }

        public IActionResult ViewPolicy(int currentPage, string searchValue)
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyManagementViewModel() { BrokerNotificationList = notificationList };
            var members = _policyManagementRepository.MemberProposerGetList(currentPage, searchValue, 20);
            model.MemberProposerList = members;
            model.CurrentPage = currentPage;

            return View("~/Pages/PolicyManagement/PolicyList.cshtml", model);
        }
        public IActionResult PolicyMembersEdit(int currentPage, string searchValue)
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyManagementViewModel() { BrokerNotificationList = notificationList };
            var members = _policyManagementRepository.MemberProposerGetList(currentPage, searchValue, 20);
            model.MemberProposerList = members;
            model.CurrentPage = currentPage;

            return View("~/Pages/PolicyManagement/PolicyMembersEdit.cshtml", model);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] PolicyApplicationViewModel model)
        {
           // var user = _userAccountRepository.GetUser(id);

            return View("~/Pages/PolicyManagement/Edit.cshtml", model);
        }

        public IActionResult PolicyList(int memPropNum)
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyManagementViewModel() { BrokerNotificationList = notificationList };

            var memberProposer = _policyManagementRepository.MemberProposerGetById(memPropNum);

            //Get principal member

            return View("~/Pages/PolicyManagement/PolicyList.cshtml", model);
        }
        [HttpPost]
        public IActionResult AmandPolicy(PolicyApplicationViewModel model, string submit)
        {
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

                using (var imageFile = new System.IO.FileStream(filePath, FileMode.Create))
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

                return View("~/Pages/PolicyApplication/ApplicationSubmitted.cshtml", smodel);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("error", ex.Message);

                var notificationList = _clientEngagementRepository.GetBrokerNotificationList();

                var errmodel = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

                return View("~/Pages/PolicyApplication/Create.cshtml", errmodel);
            }

            //Get principal member

            return View("~/Pages/PolicyManagement/AmandPolicy.cshtml", model);
        }
       
        [HttpGet]
        public IActionResult ChangeContactDetails(int memDetNum)
        {
            //var notificationList = _policyManagementRepository.MemberCollectGetbyId();
            //var model = new PolicyManagementViewModel() { PrincipalMemberDetails = _clientEngagementRepository.GetCallMeBackById(id), BrokerNotificationList = notificationList };

            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // model.MemberDetail.UserNum = Convert.ToInt32(userId);
            // if(model.MemberDetail.UserNum!=null)
            // {

            // }
            // model.PrincipalMemberDetails.CoverId = model.CoverID;
            //// model.PrincipalMemberDetails.MemPropKey = memPropKey;
            // model.PrincipalMemberDetails.InsInterest = "Principal";
            //// model.PrincipalMemberDetails.MemColKey = memColKey;
            // model.PrincipalMemberDetails.UserId = Guid.Parse(userId
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyManagementViewModel() { BrokerNotificationList = notificationList };

           var memberProposer = _policyManagementRepository.MemberProposerGetById(memDetNum);
            if(memberProposer!=null)
            {
               ///  model.PrincipalMemberDetails.ContactPerson = memberProposer.FirstName;
               // model.PrincipalMemberDetails.Surname = memberProposer.Surname;
               // model.PrincipalMemberDetails.Idnum = memberProposer.Idnum;
                model.MemberProposer.ContactPhone = memberProposer.ContactPhone;
                model.MemberProposer.ContactEmail = memberProposer.ContactEmail;
            }

            return View("~/Pages/PolicyManagement/ChangeContactDetails.cshtml", model);
        }
        [HttpPut]
        public IActionResult ChangeContactDetails(PolicyManagementViewModel model)
        {
           // MemberDetail memberDetail = new MemberDetail();
            // MemberProposerUpdate(MemberProposer memberProposer, string webRootPath, string reason, string changeLink)
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // memberDetail.MemDetNum = Convert.ToInt16(userId);
            var secure = _policyManagementRepository.SecureUserGetById(Convert.ToInt32(userId));
            if (secure != null)
            {
                // model.MemberDetail.UserNum = secure.
                secure.UserEmail = model.MemberProposer.ContactEmail;
                secure.UserPhone = model.MemberProposer.ContactPhone;
                _policyManagementRepository.UpdateMemberDetail(model.MemberDetail);
            }
            
            return View("~/Pages/PolicyManagement/ChangeContactDetails.cshtml", model);
        }

        public IActionResult AddSpouse()
        {
            
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/AddSpouse.cshtml", model);
        }
        [HttpPost]
        public IActionResult AddSpouse(PolicyManagementViewModel model, string submit)

        { 
             var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.MemberProposer.UserId = Guid.Parse(userId);
          //  var  memPropKey = _policyManagementRepository.AddMemberProposer(model.MemberProposer);
            //Add spouse Details if filled in the form
            if (!string.IsNullOrEmpty(model.SpouseDetails.ContactPerson))
            {
                model.SpouseDetails.CoverId = model.CoverID;
              //  model.SpouseDetails.MemPropKey = memPropKey;
                model.SpouseDetails.UserId = Guid.Parse(userId);
                model.SpouseDetails.InsInterest = "Spouse";
               // model.SpouseDetails.MemColKey = memColKey;
               // _policyManagementRepository.AddMemberGroup(model.SpouseDetails);
            }
            return View("~/Pages/PolicyManagement/AddSpouse.cshtml", model);
        }


          public IActionResult ChangePaymentMethod()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/ChangePaymentMethod.cshtml", model);
        }

        public IActionResult ChangePremiumPayer()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/ChangePremiumPayer.cshtml", model);
        }

        public IActionResult AddRemoveChildren()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/AddRemoveChildren.cshtml", model);
        }

        public IActionResult PolicyCancellation()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/PolicyCancellation.cshtml", model);
        }

        public IActionResult UpgradePolicy()
        {
            var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
            var model = new PolicyApplicationViewModel() { BrokerNotificationList = notificationList };

            return View("~/Pages/PolicyManagement/UpgradePolicy.cshtml", model);
        }
        //public IActionResult ViewPolicy()
        //{
        //    //var notificationList = _clientEngagementRepository.GetBrokerNotificationList();
        //    //var model = new PolicyManagementViewModel();

        //    //model.MemberProposerList.ToList();

        //    var viewPolicy = new List<PolicyManagementViewModel>();

        //    return View("~/Pages/PolicyManagement/PolicyList.cshtml", viewPolicy);

        //}

        [HttpPost]
        public IActionResult AmendContact(PolicyApplicationViewModel model)
        {
            if (model.MemberProposer.RelationToPrincipalMember == "Other(Specify)")
            {
                model.MemberProposer.RelationToPrincipalMember = model.RelationOther;
            }

            //Get the logged in userId
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            //Add the premium payer details
            model.MemberProposer.UserId = Guid.Parse(userId);
            var memPropKey = 0;
            //var memPropKey = _applicationRegistrationRepository.AddMemberProposer(model.MemberProposer);

            //Add the Principal details
            model.PrincipalMemberDetails.CoverId = model.CoverID;
            model.PrincipalMemberDetails.MemPropKey = memPropKey;
            model.PrincipalMemberDetails.UserId = Guid.Parse(userId);


            var PrincipalMemGrpKey = _applicationRegistrationRepository.AddMemberGroup(model.PrincipalMemberDetails);

            //Add spouse Details if filled in the form
            if (!string.IsNullOrEmpty(model.SpouseDetails.ContactPerson))
            {
                model.SpouseDetails.CoverId = model.CoverID;
                model.SpouseDetails.MemPropKey = memPropKey;
                model.SpouseDetails.UserId = Guid.Parse(userId);
                _applicationRegistrationRepository.AddMemberGroup(model.SpouseDetails);
            }

            //Add children if added
            if (model.ChildrenDetails.Count() > 0)
            {
                foreach (var child in model.ChildrenDetails)
                {
                    child.CoverId = model.CoverID;
                    child.MemPropKey = memPropKey;
                    child.UserId = Guid.Parse(userId);
                    child.InsInterest = "Child";

                    //Check if the child is older than 21 years
                    //var newDate = DateTime.Parse(child.Idnum.Substring(0, 6));

                    _applicationRegistrationRepository.AddMemberGroup(child);
                }
            }

            //Add Banking details
            model.Banking.CollectSurname = model.MemberProposer.Surname;
            model.Banking.CollectIdnum = model.MemberProposer.Idnum;
            model.Banking.UserId = Guid.Parse(userId);

            //var memColKey = _applicationRegistrationRepository.AddBankingDetails(model.Banking);

            //Add extended family if added
            if (model.ExtendedFamilies.Count() > 0)
            {
                foreach (var fam in model.ExtendedFamilies)
                {
                    fam.CoverId = model.CoverID;
                    fam.MemPropKey = memPropKey;
                    fam.UserId = Guid.Parse(userId);
                    fam.MemColKey = 1;

                    _applicationRegistrationRepository.AddMemberGroup(fam);
                }
            }

            return View("~/Pages/PolicyManagement/Index.cshtml");
        }

        [HttpPost]
        public IActionResult AddSpouse(PolicyApplicationViewModel model)
        {
            
            //Add spouse Details if filled in the form
            if (!string.IsNullOrEmpty(model.SpouseDetails.ContactPerson))
            {
                model.SpouseDetails.CoverId = model.CoverID;
                _applicationRegistrationRepository.AddMemberGroup(model.SpouseDetails);
            }

            return View("~/Pages/PolicyManagement/Index.cshtml");
        }

        [HttpPost]
        public IActionResult AddRemoveChild(PolicyApplicationViewModel model)
        {
            
            //Add children if added
            if (model.ChildrenDetails.Count() > 0)
            {
                foreach (var child in model.ChildrenDetails)
                {
                    child.CoverId = model.CoverID;
                    child.InsInterest = "Child";

                    //Check if the child is older than 21 years
                    //var newDate = DateTime.Parse(child.Idnum.Substring(0, 6));

                    _applicationRegistrationRepository.AddMemberGroup(child);
                }
            }

            return View("~/Pages/PolicyManagement/Index.cshtml");
        }


    }
}
