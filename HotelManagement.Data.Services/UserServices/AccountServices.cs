using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using AutoMapper;
using FluentEmail.Core.Models;
using HotelManagement.EmailService;

namespace HotelManagement.Data.Services.UserServices;

public class AccountServices : IAccountServices
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly UserManager<ApplicationUser> signInManager;
    private readonly RoleManager<ApplicationUserRole> roleManager;
    private readonly IConfiguration configuration;
    private readonly IMapper mapper;
    private readonly SendGridEmail emailService;

     public AccountServices(UserManager<ApplicationUser> _userManager,
        UserManager<ApplicationUser> _signInManager,
        RoleManager<ApplicationUserRole> _roleManager,
        IConfiguration _configuration,
        IMapper _mapper,
        SendGridEmail _emailService)
    {
        this.userManager = _userManager;
        this.signInManager = _signInManager;
        this.roleManager = _roleManager;
        this.configuration = _configuration;
        this.mapper = _mapper;
        this.emailService = _emailService;
    }


    public async Task<ApplicationUser>? GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser>? GetUserByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }

    public async Task<ApplicationUser>? GetUserByUserNameAsync(string username)
    {
        return await userManager.FindByNameAsync(username);
    }

    public async Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel)
    {
        var user = mapper.Map<ApplicationUser>(userModel);

        var resultUser = await userManager.CreateAsync(user, userModel.Password);

        var resultRoles = await userManager.AddToRoleAsync(user, userModel.RoleName);
        
        resultUser.Errors.Concat(resultRoles.Errors);

        if (resultUser.Succeeded)
        {
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            SendConfirmationEmail(user, token);
        }
        
        return resultUser;
    }

    public SendResponse SendConfirmationEmail(ApplicationUser user, string token)
    {
        return emailService.sendConfirmationEmail(user.Id.ToString(), token, user.Email);
    }
    
    public async Task<IdentityResult> UpdateUserAsync(RegisterViewModel userModel)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
    {
        var user = await GetUserByIdAsync(uid);

        var result = await userManager.ConfirmEmailAsync(user, token);

        return result;
    }

    public async Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
    {
        throw new NotImplementedException();
    }

    public SendResponse SendForgotPasswordEmailAsync(ApplicationUser user, string token)
    {
        return emailService.SendForgotPasswordEmail(user.Id.ToString(), token, user.Email);
    }

    public async Task<IdentityResult> ResetPasswordAsync(ResetPasswordModel model)
    {
        var result = userManager
            .ResetPasswordAsync(await userManager.FindByIdAsync(model.UserId),
                model.Token,
                model.NewPassword);

        return await result;
    }
}