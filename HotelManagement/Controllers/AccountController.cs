using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using static HotelManagement.ViewConstants;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.EmailService;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using NuGet.Common;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<ApplicationUser> signInManager { get; set; }

        public UserManager<ApplicationUser> userManager { get; set; }

        private readonly SendGridEmail sendGridEmail;
        public RoleManager<ApplicationUserRole> roleManager { get; set; }

        public IMapper mapper { get; set; }

        public IUserDataService dataService { get; set; }
        public AccountController(
            SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationUserRole> _roleManager,
            IUserDataService _dataService,
            IMapper _mapper,
            SendGridEmail _sendGridEmail
            )
        {
            sendGridEmail = _sendGridEmail;

            signInManager = _signInManager;

            userManager = _userManager;

            roleManager = _roleManager;

            dataService = _dataService;

            mapper = _mapper;
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
            
            var model = await dataService.GetRegisterViewModelWithRolesAndDepartmentsAsync();


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
            

            var user = await userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                ModelState.AddModelError("", "Non-existent user.");
                return View(model);
            }

            if (user.EmailConfirmed == false)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id.ToString(), token = token }, Request.Scheme);

                return View("ResendEmail", confirmUrl);
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

        [HttpGet]
        public async Task<IActionResult> ResendEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResendEmail(string model)
        {
            Console.WriteLine(model);

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

            var doesUserExist = await userManager.FindByNameAsync(model.UserName);
            var doesEmailExist = await userManager.FindByEmailAsync(model.Email);



            if (doesUserExist != null || doesEmailExist != null)
            {
                ModelState.AddModelError("", "User already exists.");
                return View(model);
            }

            var user = mapper.Map<ApplicationUser>(model);
                        
            var resultUser = await userManager.CreateAsync(user, model.Password);

            if (resultUser.Succeeded == true)
            {
                var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                var confirmUrl = Url.Action("ConfirmEmail", "Account", new {userId = user.Id.ToString(), token = token}, Request.Scheme);
                Console.WriteLine(confirmUrl);
            }

            var roleResult = await userManager.AddToRoleAsync(user, model.RoleName);

            if (!resultUser.Succeeded || !roleResult.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (String.IsNullOrEmpty(userId) || String.IsNullOrEmpty(token))
            {
                return RedirectToAction("Index", "Home");
            }
            
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                ViewData[ErrorTitle] = "User Id is invalid";

                ViewData[ErrorDescription] = "Please resend the confirmation email and try again.";

                return View("UserErrorModel");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);
            
            if (!result.Succeeded)
            {
                ViewData[ErrorTitle] = "Error occurred";

                ViewData[ErrorDescription] = "Please try again later.";

                var statusCode = HttpContext.Response.StatusCode;

                ViewData[StatusCodeForError] = "404"; 
                
                return View("UserErrorModel");
            }

            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }


    }
    
}
