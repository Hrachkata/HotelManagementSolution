using HotelManagement.Data.Models.UserModels;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using HotelManagement.Data.Services.AccountServices.Contracts;

namespace HotelManagement.Areas.Account.Controllers
{
    [Area("Account")]
    public class ManageAccountController : Controller
    {
        public SignInManager<ApplicationUser> signInManager { get; set; }
        public UserManager<ApplicationUser> userManager { get; set; }
        public IAccountServices accountServices { get; set; }
        public ManageAccountController(
            SignInManager<ApplicationUser> _signInManager,
            UserManager<ApplicationUser> _userManager,
            IAccountServices _accountServices)
        {
            accountServices = _accountServices;

            signInManager = _signInManager;

            userManager = _userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Settings()
        {
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            var user = await accountServices.GetEditViewModelByUserNameAsync(User.Identity.Name);

            return View(user);

        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Settings(EditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await accountServices.GetUserByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            var result = await signInManager.CheckPasswordSignInAsync(user, model.OldPassword, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Invalid password, please try again.");

                return View(accountServices.ProjectApplicationUserToEditViewModel(user));
            }

            if (User.IsInRole("Admin"))
            {
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.EGN = model.EGN;
            }
            user.EditedOn = DateTime.Now;

            user.FirstName = model.FirstName;

            user.MiddleName = model.MiddleName;

            user.LastName = model.LastName;

            user.PhoneNumber = model.PhoneNumber;

            var updateResult = await userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                foreach (var error in updateResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(accountServices.ProjectApplicationUserToEditViewModel(user));
            }

            return RedirectToAction("Index", "Home", new {area = ""});
        }


    }
}
