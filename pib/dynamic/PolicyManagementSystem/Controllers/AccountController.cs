using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PolicyManagementSystem.Controllers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyManagementDataAccess.Context;
using Microsoft.AspNetCore.Authorization;
using PolicyManagementDataAccess;
using PolicyManagementMailer.Models;

namespace PolicyManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly MemberApplication verify;
        private readonly IUserAccountRepository _userAccountRepository;

       // private readonly SignInManager<SecureUser> secureSignIn;


        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IUserAccountRepository userAccountRepository)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Pages/Account/Index.cshtml");
        }

        public async Task<ActionResult> ConfirmEmail(string email, string code)
        {
            AccountController accountController = this;
            if (email == null || code == null)
                return (ActionResult)accountController.View("~/Pages/Shared/Error.cshtml");
            IdentityUser byEmailAsync = await accountController._userManager.FindByEmailAsync(email);
            return !(await accountController._userManager.ConfirmEmailAsync(byEmailAsync, code)).Succeeded ? (ActionResult)accountController.View("~/Pages/Shared/Error.cshtml") : (ActionResult)accountController.View("~/Pages/Account/ConfirmEmail.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "admin@pib.co.za")
                {
                    return RedirectToAction("Index", "Home");
                }


                var result = await _signInManager.PasswordSignInAsync(
                       model.Email, model.Password, model.RememberMe, false);


                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
               
            }

            return View("~/Pages/Account/Index.cshtml", model);
        }
        //part of forgot password
        [AllowAnonymous, HttpGet("forgot-password")]
        public IActionResult ForgotPassword()
        {
            //return View("~/Pages/Account/ForgotPassword.cshtml");
            return View();
        }

        //part of forgot password
        [AllowAnonymous, HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword(ForgotPassword model)
        {
            AccountController accountController = this;
            IdentityUser user = await accountController._userManager.FindByEmailAsync(model.Email);
            //var code = await _userManager.GeneratePasswordResetTokenAsync(user); 
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            if (!string.IsNullOrEmpty(token))
            {
                await _userAccountRepository.GenerateForgotPasswordTokenAsync(user);
                await accountController._userManager.ConfirmEmailAsync(user, token);
            }
            if (ModelState.IsValid)
            { 
               if(user !=null)
                {
                   //await _userAccountRepository.GenerateForgotPasswordTokenAsync(user);
                }
                ModelState.Clear();
                model.EmailSent = true;
            }
            
            return View(model);
        }
    }
}
