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


    public async Task<RegisterViewModel> GetRegisterViewModelWithRolesAsync()
    {
        var roles = await context.Roles.ToListAsync();

        var model = new RegisterViewModel()
        {
            Roles = roles
        };

        return model;
    }
}