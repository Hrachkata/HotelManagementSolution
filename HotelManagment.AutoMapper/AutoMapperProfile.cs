using HotelManagement.Data.Models.UserModels;
using AutoMapper;
using HotelManagement.Web.ViewModels.UserModels;

namespace HotelManagement.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterViewModel, ApplicationUser>();

        CreateMap<ApplicationUser, UserViewModel>().ForMember(d => d.DepartmentNames,
            o => o.MapFrom(s => s.EmployeeDepartment.Select(ed => ed.Department.Name).ToList()));       
    }
}