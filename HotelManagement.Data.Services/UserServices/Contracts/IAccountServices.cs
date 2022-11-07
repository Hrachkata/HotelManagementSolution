using FluentEmail.Core.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Services.UserServices.Contracts;

public interface IAccountServices
{
    Task<ApplicationUser> GetUserByEmailAsync(string email);

    Task<ApplicationUser> GetUserByIdAsync(string id);

    Task<ApplicationUser> GetUserByUserNameAsync(string username);
    Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel);

    SendResponse SendConfirmationEmail(ApplicationUser user, string token);
    SendResponse SendForgotPasswordEmailAsync(ApplicationUser user, string token);
    
    Task<IdentityResult> UpdateUserAsync(RegisterViewModel userModel);

    Task<IdentityResult> ConfirmEmailAsync(string uid, string token);

    Task GenerateEmailConfirmationTokenAsync(ApplicationUser user);

    Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync();

    Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model);

    Task<EditViewModel> GetEditViewModelByUserNameAsync(string userName);

    EditViewModel ProjectApplicationUserToEditViewModel(ApplicationUser user);
}