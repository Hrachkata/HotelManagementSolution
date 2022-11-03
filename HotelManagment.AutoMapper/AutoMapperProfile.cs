using HotelManagement.Data.Models.UserModels;
using AutoMapper;
using HotelManagement.Web.ViewModels.UserModels;
using HotelManagement.Data.Models.Models;

namespace HotelManagement.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterViewModel, ApplicationUser>()
            .ForMember(d => d.EmployeeDepartment,
            o => o.MapFrom(s => new List<EmployeeDepartment>() { new EmployeeDepartment
                {
                    DepartmentId = s.DepartmentId,
                    ApplicationUserId = s.Id
                } 
            }))
            .ForMember(d => d.CreatedOn,
            o => o.MapFrom(s => DateTime.Now))
            .ForMember(d => d.SecurityStamp,
            o => o.MapFrom(s => Guid.NewGuid()));

        CreateMap<ApplicationUser, UserViewModel>().ForMember(d => d.DepartmentNames,
            o => o.MapFrom(s => s.EmployeeDepartment.Select(ed => ed.Department.Name).ToList()));  
        

    }
}