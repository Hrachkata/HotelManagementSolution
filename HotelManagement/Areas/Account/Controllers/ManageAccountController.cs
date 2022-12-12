using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using HotelManagement.Data.Services.AccountServices.Contracts;
using HotelManagement.Web.ViewModels.AccountModels;
using Serilog;

namespace HotelManagement.Areas.Account.Controllers
{
    /// <summary>
    /// Manage your account controller.
    /// </summary>
    [Area("Account")]
    [Authorize]
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

        /// <summary>
        /// Settings get method.
        /// </summary>
        /// <returns>Your account settings.</returns>

        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            if (User.Identity == null)
            {
                return Unauthorized();
            }

            var user = await accountServices.GetEditViewModelByUserNameAsync(User.Identity.Name);

            return View(user);

        }


        /// <summary>
        /// Setting post method, changes made to your account are made here.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
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
                var logMessages = new StringBuilder();

                foreach (var error in updateResult.Errors)
                {

                    logMessages.Append(error.Description);
                    ModelState.AddModelError("", error.Description);
                }

                Log.Logger.Error("Errors: {0} while attempting to update user: {1}", logMessages.ToString(), this.User?.Identity?.Name ?? "ERROR MISSING USERNAME / TEST ENVIRONMENT");

                return View(accountServices.ProjectApplicationUserToEditViewModel(user));
            }

            Log.Logger.Information("User: {0}, made changes to their account.", this.User?.Identity?.Name ?? "ERROR MISSING USERNAME / TEST ENVIRONMENT");

            return RedirectToAction("Index", "Home", new {area = ""});
        }


    }
}
