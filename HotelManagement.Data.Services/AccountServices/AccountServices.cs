using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentEmail.Core.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Services.AccountServices.Contracts;
using HotelManagement.EmailService;
using HotelManagement.EmailService.Contracts;
using HotelManagement.Web.ViewModels.AccountModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelManagement.Data.Services.AccountServices;

public class AccountServices : IAccountServices
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IMapper mapper;
    private readonly ISendGridEmail emailService;
    private readonly ApplicationDbContext context;

    public AccountServices(UserManager<ApplicationUser> _userManager,
        IMapper _mapper,
        ISendGridEmail _emailService,
        ApplicationDbContext _context)
    {
        this.userManager = _userManager;
        this.mapper = _mapper;
        this.emailService = _emailService;
        this.context = _context;
    }


    public async Task<ApplicationUser>? GetUserByEmailAsync(string email)
    {
        return await userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser>? GetUserByIdAsync(string id)
    {
        return await userManager.FindByIdAsync(id);
    }
     

    public async Task<ApplicationUser>? GetUserIncludedDepartmentsByIdAsync(string id)
    {
        return await context.Users.Include(u => u.EmployeeDepartment).ThenInclude(ed => ed.Department).Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
    }
    public async Task<ApplicationUser>? GetUserByUserNameAsync(string username)
    {
        return await userManager.FindByNameAsync(username);
    }

    public async Task<IdentityResult> CreateUserAsync(RegisterViewModel userModel)
    {
        var user = mapper.Map<ApplicationUser>(userModel);

        var resultUser = await userManager.CreateAsync(user, userModel.Password);

        var department = await context.Departments.Where(d => d.Id == userModel.DepartmentId).Include(d => d.RoleDepartment).ThenInclude(d => d.RoleName).FirstOrDefaultAsync();

        var roleNames = department.RoleDepartment.Select(rd => rd.RoleName.NameOfRole).ToList();

        if (department != null && roleNames != null)
        {
            var resultRoles = await userManager.AddToRolesAsync(user, roleNames);

            if (!resultRoles.Succeeded)
            {
                resultUser.Errors?.Concat(resultRoles.Errors);
            }
        }
                

        if (resultUser.Succeeded && resultUser.Errors?.Count() == 0)
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
    
    public async Task<IdentityResult> UpdateUserAsync(EmployeeEditViewModel model)
    {
        
        var user = await GetUserByIdAsync(model.Id.ToString());

        if (user == null)
        {
            throw new ArgumentNullException("User with id doesn't exist.");
        }
       

        if (model.UserName != user.UserName)
        {
            var checkUsername = await GetUserByUserNameAsync(model.UserName);
            if (checkUsername != null)
            {
                throw new InvalidOperationException("Username not free, there's already a user with this username.");
            }
        }

        if (model.Email != user.Email)
        {
            var checkEmail = await GetUserByEmailAsync(model.Email);
            if (checkEmail != null)
            {
                throw new InvalidOperationException("Email not free, there's already a user with this email.");
            }
        }

        

        user.UserName = model.UserName;

        user.FirstName = model.FirstName;

        user.MiddleName = model.MiddleName;

        user.LastName = model.LastName;

        user.PhoneNumber = model.PhoneNumber;

        user.RFID = model.RFID;

        user.EGN = model.EGN;

        user.IsActive = model.IsActive;

        user.Salary = model.Salary;

        user.Email = model.Email;

        user.EditedOn = DateTime.Now;

        var result =await userManager.UpdateAsync(user);

        return result;
    }

    public async Task<IdentityResult> ConfirmEmailAsync(string uid, string token)
    {
        var user = await GetUserByIdAsync(uid);

        var result = await userManager.ConfirmEmailAsync(user, token);

        return result;
    }

    public async Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync()
    {
        var departments =await this.context.Departments.Where(d => d.IsActive).ProjectTo<DepartmentDto>(mapper.ConfigurationProvider).ToListAsync();

        return new RegisterViewModel()
        {
            Departments = departments,
        };

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

    public async Task<EditViewModel> GetEditViewModelByUserNameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);

        var result = mapper.Map<EditViewModel>(user);

        return result;
    }

    public EditViewModel ProjectApplicationUserToEditViewModel(ApplicationUser user)
    {
        var result = mapper.Map<EditViewModel>(user);

        return result;
    }

    public async Task<IdentityResult> DisableUser(string userId)
    {
        var user = await GetUserByIdAsync(userId);

        if (user == null || user.Email==null)
        {
            throw new ArgumentNullException("User with id doesn't exist or there's a problem");
        }

        user.IsActive = false;

        var result = await userManager.UpdateAsync(user);


        return result;
    }

    public async Task<IdentityResult> EnableUser(string userId)
    {
        var user = await GetUserByIdAsync(userId);

        if (user == null || user.Email == null)
        {
            throw new ArgumentNullException("User with id doesn't exist or there's a problem");
        }

        user.IsActive = true;

        var result = await userManager.UpdateAsync(user);
        
        return result;
    }

    // public Task GenerateEmailConfirmationTokenAsync(ApplicationUser user)
    // {
    //     throw new NotImplementedException();
    // }
}