using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess;
using PolicyManagementSystem.Controllers.Models;
using System.Threading.Tasks;



namespace PolicyManagementSystem.Controllers
{
    public class ApplicantRegistrationController : Controller
    {
        private IMemberApplicationRepository _memberApplicationRepository;
        private IWebHostEnvironment _env;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;



        public ApplicantRegistrationController(
        IMemberApplicationRepository memberApplicationRepository,
        IWebHostEnvironment env,
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager)
        {
            this._memberApplicationRepository = memberApplicationRepository;
            this._env = env;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }



        [HttpPost]
        public async Task<IActionResult> RegisterApplicant(
        ApplicantRegistrationViewModel model)
        {
            ApplicantRegistrationController registrationController = this;
            IdentityUser identityUser = new IdentityUser();
            identityUser.UserName = model.MemberApplication.Email;
            identityUser.Email = model.MemberApplication.Email;
            IdentityUser user = identityUser;
            if (registrationController._memberApplicationRepository.IdAlreadyRegistered(model.MemberApplication.Idnum))
            {
                ((ControllerBase)registrationController).ModelState.AddModelError("error", "ID Number already registered.");
                return (IActionResult)registrationController.View("~/Pages/ApplicantRegistration/Index.cshtml", (object)model);
            }
            IdentityResult async = await registrationController._userManager.CreateAsync(user, model.Password);
            if (async.Succeeded)
            {
                string confirmationTokenAsync = await registrationController._userManager.GenerateEmailConfirmationTokenAsync(user);
                string confirmationLink = UrlHelperExtensions.Action(((ControllerBase)registrationController).Url, "ConfirmEmail", "Account", (object)new
                {
                    code = confirmationTokenAsync,
                    email = user.Email
                }, ((ControllerBase)registrationController).Request.Scheme);
                IWebHostEnvironment env = registrationController._env;
                registrationController._memberApplicationRepository.Add(model.MemberApplication, env.WebRootPath, confirmationLink);
                IdentityResult roleAsync = await registrationController._userManager.AddToRoleAsync(user, "Applicant");
                return (IActionResult)((ControllerBase)registrationController).RedirectToAction("Login", "Account");
            }
            foreach (IdentityError error in async.Errors)
                ((ControllerBase)registrationController).ModelState.AddModelError("error", error.Description);
            return (IActionResult)registrationController.View("~/Pages/ApplicantRegistration/Index.cshtml", (object)model);
        }



        [HttpPost]
        public IActionResult RegisterApplicantConfirmProfile(int id) => (IActionResult)this.View("~/Pages/ApplicantRegistration/Index.cshtml");



        [HttpGet]
        public IActionResult Index() => (IActionResult)this.View("~/Pages/ApplicantRegistration/Index.cshtml");
    }
}