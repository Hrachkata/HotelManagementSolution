using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.UserServices;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<ApplicationUser> signInManager { get; set; }

        public UserManager<ApplicationUser> userManager { get; set; }

        public RoleManager<ApplicationUserRole> roleManager { get; set; }

        public IUserDataService dataService { get; set; }
        public AccountController(
            SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            RoleManager<ApplicationUserRole> _roleManager,
            IUserDataService _dataService
            )
        {
            signInManager = _signInManager;

            userManager = _userManager;

            roleManager = _roleManager;

            dataService = _dataService;
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
        [AllowAnonymous]
        public async Task<IActionResult> Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home");
            }
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

            var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

            if (!result.Succeeded || result.IsNotAllowed)
            {
                ModelState.AddModelError("", "Try again.");
                return View(model);
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var doesUserExist = await userManager.FindByNameAsync(model.UserName);

            if (doesUserExist != null)
            {
                ModelState.AddModelError("", "User already exists.");
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(model);
            }

            return RedirectToAction("Index", "Home");
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
