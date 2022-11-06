using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Web.ViewModels.UserModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.UserServices;

public class AccountDataService : IAccountDataService
{
    private ApplicationDbContext context { get; set; }

    private IMapper mapper { get; set; }

    public AccountDataService(ApplicationDbContext _context,
        IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;   
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

    public IEnumerable<UserViewModel> GetUserViewModelsAsync()
    {
        var users = context.Users.Include(u => u.EmployeeDepartment).ThenInclude(d => d.Department).ProjectTo<UserViewModel>(mapper.ConfigurationProvider);

        return users;
    }
}