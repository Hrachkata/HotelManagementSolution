using HotelManagement.Data.Models.UserModels;
using AutoMapper;
using HotelManagement.Web.ViewModels.UserModels;
using HotelManagement.Data.Models.Models;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;

namespace HotelManagement.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RegisterViewModel, ApplicationUser>()
            .ForMember(d => d.EmployeeDepartment,
                o => o.MapFrom(s => new List<EmployeeDepartment>()
                {
                    new EmployeeDepartment
                    {
                        DepartmentId = s.DepartmentId,
                        ApplicationUserId = s.Id
                    }
                }))
            .ForMember(d => d.CreatedOn,
                o => o.MapFrom(s => DateTime.Now))
            .ForMember(d => d.SecurityStamp,
                o => o.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.Id, 
                o => o.MapFrom(s => Guid.NewGuid()));

        CreateMap<ApplicationUser, SingleEmployeeServiceModel>().ForMember(d => d.DepartmentName,
            o => o.MapFrom(s 
                => s.EmployeeDepartment.Select(ed => ed.Department.Name).FirstOrDefault()))
            .ForMember(d => d.UserId,
                o => o.MapFrom(s => s.Id))
            .ForMember(d => d.IsActive,
                o => o.MapFrom(s => s.IsActive));

        CreateMap<ApplicationUser, EditViewModel>().ForMember(d => d.PhoneNumber,
            o => o.MapFrom(s => s.PhoneNumber))
            .ForMember(d => d.Id,
            o => o.MapFrom(s => s.Id));

    }
}