using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementDataAccess.Context;
using PolicyManagementDataAccess;
using PolicyManagementSystem.Controllers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BCryptNet = BCrypt.Net.BCrypt;

namespace PolicyManagementSystem.Controllers
{
    [Authorize]
    public class UserManagementController : Controller
    {

        private IUserAccountRepository _userAccountRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserManagementController(IUserAccountRepository userAccountRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userAccountRepository = userAccountRepository;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public ActionResult Index()
        {
            //Get list of users
            var users = _userAccountRepository.GetUsers().ToList();
            var viewModel = new UserManagementViewModel() { tblUseraccounts = new List<TblUseraccount>()};

            //Set the users
            viewModel.tblUseraccounts = users;

            return View("~/Pages/UserManagement/Index.cshtml", viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new UserManagementViewModel();
            _userAccountRepository.GetProvinces();

            return View("~/Pages/UserManagement/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult Roles()
        {
            var model = new UserManagementViewModel();

            return View("~/Pages/UserManagement/Roles.cshtml", model);
        }
       

            [HttpPost]
        public async Task<IActionResult> Create(UserManagementViewModel model)
        {
         
            var user = new IdentityUser
            {
                UserName = model.tblUseraccount.FldUserEmail,
                Email = model.tblUseraccount.FldUserEmail,

                EmailConfirmed = true
            };
           // model.tblUseraccount.FldUserTitle
            byte[] passwordHash, passwordSalt;
            string password = Convert.ToString(BCryptNet.HashPassword(model.tblUseraccount.FldUserPassword));

            _userAccountRepository.CreatePasswordHash(password, out passwordHash, out passwordSalt);
           
            model.tblUseraccount.FldPasswordHash = passwordHash;
            model.tblUseraccount.FldPasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash.ToString();

            //Create AspNetUsers and tblUSERACCOUNT user accounts
            _userAccountRepository.CreateUserAccounts(model.tblUseraccount);
            var result = await _userManager.CreateAsync(user, model.tblUseraccount.FldUserPassword);
            
            if (result.Succeeded)
            {
                //Add user to role
                var result1 = await _userManager.AddToRoleAsync(user, model.tblUseraccount.FldUserAccounttype);
                return RedirectToAction("Index", "UserManagement");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("error", error.Description);
            }

            return View("~/Pages/UserManagement/Create.cshtml", model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get the selected user
            var user =_userAccountRepository.GetUser(id);
            var viewModel = new UserManagementViewModel() { tblUseraccount = new TblUseraccount() };

            //Get Agent details
            if (user.FldAgentId.HasValue)
            {
                var agent = _userAccountRepository.GetAgentById(user.FldAgentId.Value);

                viewModel.Agent = agent;
            }

            //Set the users
            viewModel.tblUseraccount = user;

            return View("~/Pages/UserManagement/Edit.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserManagementViewModel model)
        {
            try
            {
                //Check if it's an old user from the DB
                var user = new IdentityUser
                {
                    UserName = model.tblUseraccount.FldUserEmail,
                    Email = model.tblUseraccount.FldUserEmail,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(user, model.tblUseraccount.FldUserPassword);

                if (result.Succeeded)
                {
                    //Add the role
                    await _userManager.AddToRoleAsync(user, model.tblUseraccount.FldUserAccounttype);

                    //Update the agent entity
                    model.Agent.ContactEmail = model.tblUseraccount.FldUserEmail;
                    _userAccountRepository.UpdateAgent(model.Agent);

                    //Update the user
                    _userAccountRepository.Update(model.tblUseraccount);

                    return RedirectToAction("Index", "UserManagement");
                    
                }
                else
                {
                    //Update the user manager and system user
                    var aspUser = _userManager.Users.FirstOrDefault(u => u.Email == model.tblUseraccount.FldUserEmail);

                    aspUser.UserName = model.tblUseraccount.FldUserEmail;
                    aspUser.UserName = model.tblUseraccount.FldUserEmail;
                    aspUser.PasswordHash = model.tblUseraccount.FldUserPassword;

                    //await _userManager.UpdateAsync(aspUser);

                    //Update the agent entity
                    model.Agent.ContactEmail = model.tblUseraccount.FldUserEmail;
                    _userAccountRepository.UpdateAgent(model.Agent);

                    //Update the user
                    _userAccountRepository.Update(model.tblUseraccount);

                    return RedirectToAction("Index", "UserManagement");
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
