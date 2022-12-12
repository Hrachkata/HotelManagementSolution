using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.AccountServices.Contracts;
using HotelManagement.Web.ViewModels.AccountModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;



namespace HotelManagement.Areas.Account.Controllers
{
/// <summary>
/// The (User) controller, used by admins or H&R to add employees.
/// </summary>
    [Authorize]
    [Area("Account")]
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

        /// <summary>
        /// Login get method.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }
            var model = new LoginViewModel();
            
            return View(model);

        }


        /// <summary>
        /// Register get method.
        /// </summary>
        /// <returns>View with departments.</returns>
        [HttpGet]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
        public async Task<IActionResult> Register()
        {
            
            var model = await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync();

            Log.Logger.Information("User: {0}, requested create employee page.", this.User?.Identity?.Name ?? "ERROR MISSING USERNAME / TEST ENVIRONMENT");

            return View(model);

        }

        /// <summary>
        /// Login post method.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>If employee is successful in loggin in they are redirected to the home page.</returns>
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

                Log.Logger.Information("User: {0}, attempted to login but their email isn't confirmed.", model.UserName);

                return RedirectToAction("ConfirmEmail", ConfirmEmailViewModel);
            }

            var rememberMeCheckbox = model.RememberMe;

            var result = await signInManager.PasswordSignInAsync(user, model.Password, rememberMeCheckbox, false);

            if (!result.Succeeded || result.IsNotAllowed)
            {
                Log.Logger.Information("User: {0}, attempted to login.", model.UserName);
                ModelState.AddModelError("", "Try again.");
                return View(model);
            }

            Log.Logger.Information("User: {0}, logged in.", model.UserName);

            return RedirectToAction("Index", "Home", new {area = ""});

        }
        
        /// <summary>
        /// Register post method, used to register new employees in the app.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        [Authorize(Roles = ("Human Resources,Owner,Director,Manager,Admin"))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync());
            }

            var doesUserExist = await accountServices.GetUserByUserNameAsync(model.UserName);
            var doesEmailExist = await accountServices.GetUserByEmailAsync(model.Email);
            
            if (doesUserExist != null || doesEmailExist != null)
            {
                ModelState.AddModelError("", "User already exists.");
                return View(await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync());
            }
            
            var resultUser = await accountServices.CreateUserAsync(model);

            if (resultUser.Errors.Any() || !resultUser.Succeeded)
            {
                foreach (var error in resultUser.Errors)
                {
                    ModelState.AddModelError("", error.Description);    
                }

                return View(await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync());
            }

            Log.Logger.Information("User: {0}, registered a new employee.", model.UserName);

            return Redirect("/Admin");
        }

        /// <summary>
        /// Confirm email, used to confirm email of user.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="email"></param>
        /// <returns></returns>

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


        /// <summary>
        /// Confirm email post method, generates and sends the email confirmation token.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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

                Log.Logger.Information("Sent confirmation email to {0}.", model.Email);

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


        /// <summary>
        /// Logout method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home", new { area = "" });
        }


        /// <summary>
        /// Forgot password get method, returns the forgot password view.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }


        /// <summary>
        /// Forgot password post method, sends the forgotPassword email to user.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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

                Log.Logger.Information("Sent forgot password email to {0}.", model.Email);

                model.EmailSent = true;
            }
            return View(model);
        }


        /// <summary>
        /// Reset password get method.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword(string userId, string token)
        {
            var resetModel = new ResetPasswordModel()
            {
                UserId = userId,
                Token = token
            };

            Log.Logger.Information("User with id: {0} requested reset password.", userId);

            return View(resetModel);
        }


        /// <summary>
        /// Reset password post method, resets the user password.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await accountServices.ResetPasswordAsync(model);

                if (result.Succeeded)
                {
                    Log.Logger.Information("User with id: {0} reset password.", model.UserId);

                    return View("ResetPasswordConfirmation");

                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
    
            return View(model);
        }


        /// <summary>
        /// Reset password confirmation method.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

    }
    
}
