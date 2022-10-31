using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.UserServices;

public class UserDataService : IUserDataService
{
    private ApplicationDbContext context { get; set; }

    public UserDataService(ApplicationDbContext _context)
    {
        context = _context;
    }


    public async Task<RegisterViewModel> GetRegisterViewModelWithRolesAndDepartmentsAsync()
    {
        var roles = await context.Roles.ToListAsync();

        var departments = await context.Departments.ToListAsync();

        var model = new RegisterViewModel()
        {
            Roles = roles,
            Departments = departments
        };

        return model;
    }
}