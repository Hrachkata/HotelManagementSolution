using FluentEmail.Core.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Web.ViewModels.AccountModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Services.AccountServices.Contracts;

/// <summary>
/// Account services
/// </summary>
public interface IAccountServices
{

    /// <summary>
    /// Returns user with included departments
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task&lt;ApplicationUser&gt;</returns>
    Task<ApplicationUser>? GetUserIncludedDepartmentsByIdAsync(string id);

    /// <summary>
    /// Gets user by email
    /// </summary>
    /// <param name="email"></param>
    /// <returns>Task<ApplicationUser></returns>
    Task<ApplicationUser> GetUserByEmailAsync(string email);

    /// <summary>
    /// Gets user by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Task&lt;ApplicationUser&gt;</returns>
    Task<ApplicationUser> GetUserByIdAsync(string id);

    /// <summary>
    /// Gets user by username
    /// </summary>
    /// <param name="username"></param>
    /// <returns>Task&lt;ApplicationUser&gt;</returns>
    Task<ApplicationUser> GetUserByUserNameAsync(string username);

    /// <summary>
    /// Creates user
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns>  Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel);

    /// <summary>
    /// Sends confirmation email
    /// </summary>
    /// <param name="user"></param>
    /// <param name="token"></param>
    /// <returns>SendResponse</returns>
    SendResponse SendConfirmationEmail(ApplicationUser user, string token);

    /// <summary>
    /// Sends forgot password email
    /// </summary>
    /// <param name="user"></param>
    /// <param name="token"></param>
    /// <returns>SendResponse</returns>
    SendResponse SendForgotPasswordEmailAsync(ApplicationUser user, string token);


    /// <summary>
    /// Updates/edits user
    /// </summary>
    /// <param name="userModel"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> UpdateUserAsync(EmployeeEditViewModel userModel);

    /// <summary>
    /// Confirms email
    /// </summary>
    /// <param name="uid"></param>
    /// <param name="token"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

    // Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

    /// <summary>
    /// Returns the model required by the register view method
    /// </summary>
    /// <returns>Task&lt;RegisterViewModel&gt;</returns>
    Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync();

    /// <summary>
    /// Resets password of user
    /// </summary>
    /// <param name="model"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>

    Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);

    /// <summary>
    /// Returns the editViewModel for user by username
    /// </summary>
    /// <param name="userName"></param>
    /// <returns>Task&lt;EditViewModel&gt;</returns>

    Task<EditViewModel> GetEditViewModelByUserNameAsync(string userName);

    /// <summary>
    /// Maps user to EditViewModel
    /// </summary>
    /// <param name="user"></param>
    /// <returns>EditViewModel</returns>
    EditViewModel ProjectApplicationUserToEditViewModel(ApplicationUser user);

    /// <summary>
    /// Disables user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> DisableUser(string userId);

    /// <summary>
    /// Enables user by id
    /// </summary>
    /// <param name="userId"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> EnableUser(string userId);

    /// <summary>
    /// Adds user to role
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> AddUserToRolesAsync(ApplicationUser user, ICollection<string> roleNames);

    /// <summary>
    /// Removes roles from user
    /// </summary>
    /// <param name="user"></param>
    /// <param name="roleName"></param>
    /// <returns>Task&lt;IdentityResult&gt;</returns>
    Task<IdentityResult> RemoveRolesAsync(ApplicationUser user, ICollection<string> roleNames);
}