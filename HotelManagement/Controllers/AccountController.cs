using System.Runtime.InteropServices;
using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.EmailService;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Common;
using Newtonsoft.Json.Linq;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<ApplicationUser> signInManager { get; set; }
        public UserManager<ApplicationUser> userManager { get; set; }
        public IAccountServices accountServices { get; set; }
        public AccountController(
            SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            IAccountServices _accountServices)
        {
            accountServices = _accountServices;

            signInManager = _signInManager;

            userManager = _userManager;
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new LoginViewModel();


            return View(model);

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Register()
        {
            
            var model = await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync();


            return View(model);

        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await accountServices.GetUserByUserNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Non-existent user.");
                return View(model);
            }

            if (user.EmailConfirmed == false)
            {
                var ConfirmEmailViewModel = new ConfirmEmailViewModel()
                {
                    Email = user.Email,
                    EmailVerified = false
                };

                return RedirectToAction("ConfirmEmail", ConfirmEmailViewModel);
            }

            var rememberMeCheckbox = model.RememberMe;

            var result = await signInManager.PasswordSignInAsync(user, model.Password, rememberMeCheckbox, false);

            if (!result.Succeeded || result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Try again.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");

        }
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var doesUserExist = await accountServices.GetUserByUserNameAsync(model.UserName);
            var doesEmailExist = await accountServices.GetUserByEmailAsync(model.Email);
            
            if (doesUserExist != null || doesEmailExist != null)
            {
                ModelState.AddModelError("", "User already exists.");
                return View(model);
            }
            
            var resultUser = await accountServices.CreateUserAsync(model);

            if (resultUser.Errors.Any() || !resultUser.Succeeded)//|| !roleResult.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userId, string token, string email)
        {
            var model = new ConfirmEmailViewModel()
            {
                Email = email
            };

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return View(model);
            }

            var result = await accountServices.ConfirmEmailAsync(userId, token);

            if (result.Succeeded)
            {
                model.EmailVerified = true;
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel model)
        {

            var user = await accountServices.GetUserByEmailAsync(model.Email);

            if (user != null)
            {
                if (user.EmailConfirmed)
                {
                    model.IsConfirmed = true;

                    return View(model);
                }

                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                accountServices.SendConfirmationEmail(user, token);

                model.EmailSent = true;

                ModelState.Clear();
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong, please contact your system administrator.");
            }

            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await accountServices.GetUserByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);

                    accountServices.SendForgotPasswordEmailAsync(user, token);
                }

                ModelState.Clear();

                model.EmailSent = true;
            }
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            var resetModel = new ResetPasswordModel()
            {
                UserId = userId,
                Token = token
            };

            return View(resetModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountServices.ResetPasswordAsync(model);

                if (result.Succeeded)
                {
                    return Redirect("/Account/ResetPasswordConfirmation");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

    }
    
}
