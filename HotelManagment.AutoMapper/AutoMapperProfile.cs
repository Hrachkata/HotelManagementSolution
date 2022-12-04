using HotelManagement.Data.Models.UserModels;
using AutoMapper;
using AutoMapper.Configuration;
using HotelManagement.Data.Models.Models;
using HotelManagement.Web.ViewModels.AccountModels;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FloorModelForVisualization;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using HotelManagement.Web.ViewModels.RoomModels;
using HotelManagement.Web.ViewModels.RoomModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;

namespace HotelManagement.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentDto>()
            .ForMember(d => d.DepartmentId,
                o => o.MapFrom(s => s.Id))
            .ForMember(d => d.DepartmentName,
                o => o.MapFrom(s => s.Name));

        CreateMap<RegisterViewModel, ApplicationUser>()
            .ForMember(d => d.Id,
                o => o.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.CreatedOn,
                o => o.MapFrom(s => DateTime.Now))
            .ForMember(d => d.SecurityStamp,
                o => o.MapFrom(s => Guid.NewGuid()))
            .ForMember(d => d.EmployeeDepartment,
                o => o.MapFrom(s => new List<EmployeeDepartment>()
                {
                    new EmployeeDepartment
                    {
                        DepartmentId = s.DepartmentId,
                        ApplicationUserId = s.Id
                    }
                }));

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

        CreateMap<ApplicationUser, EmployeeDetailsModel>()
            .ForMember(d => d.Departments,
            o => o.MapFrom(s => s.EmployeeDepartment.Select(ed => ed.Department.Name)));

        CreateMap<ApplicationUser, EmployeeEditViewModel>()
            .ForMember(d => d.DepartmentsOfEmployee,
            o => o.MapFrom(s => s.EmployeeDepartment.Select(ed => ed.Department)));
        
        CreateMap<Floor, FloorViewModel>()
            .ForMember(d => d.FreeRooms,
                o => o.MapFrom(s => s.Rooms.Where(r => r.IsCleaned && !r.IsOccupied && !r.IsOutOfService).Count()));


        CreateMap<Room, SingleRoomServiceModel>().ForMember(d => d.RoomNumber,
            o => o.MapFrom(s => s.RoomNumber))
            .ForMember(d => d.RoomId,
                o => o.MapFrom(s => s.Id))
            .ForMember(d => d.RoomType,
                o => o.MapFrom(s => s.RoomType.Type));


        CreateMap<Room, RoomDetailsViewModel>()
            .ForMember(d => d.RoomType,
            o => o.MapFrom(s => s.RoomType.Type))
            .ForMember(d => d.NumberOfReservations,
            o => o.MapFrom(s => s.Reservations.Count()))
            .ForMember(d => d.PricePerPerson,
            o => o.MapFrom(s => s.RoomType.PricePerPerson))
            .ForMember(d => d.PriceOnFullCapacity,
            o => o.MapFrom(s => s.RoomType.PricePerPerson * s.Capacity))
            .ForMember(d => d.RoomTypeId,
            o => o.MapFrom(s => s.RoomTypeId));

        CreateMap<RoomType, RoomTypeDto>();
        CreateMap<Floor, FloorDto>();

        CreateMap<Room, RoomEditViewModel>()
             .ForMember(d => d.currentRoomTypeId,
                o => o.MapFrom(s => s.RoomTypeId))
             .ForMember(d => d.currentFloorId,
                o => o.MapFrom(s => s.FloorId));


        CreateMap<Room, SingleFreeRoomModel>().ForMember(d => d.RoomType,
                o => o.MapFrom(s => s.RoomType.Type))
            .ForMember(d => d.PricePerPerson,
                o => o.MapFrom(s => s.RoomType.PricePerPerson))
            .ForMember(d => d.RoomId,
                o => o.MapFrom(s => s.Id));

        CreateMap<SingleFreeRoomModel, BookingModel>();

        CreateMap<BookingModel, Reservation>()
            .ForMember(d => d.ArrivalDate,
                o => o.MapFrom(s => s.ArrivalDate.Value))
            .ForMember(d => d.DepartureDate,
                o => o.MapFrom(s => s.DepartureDate.Value))
            .ForMember(d => d.CreatedOn,
                o => o.MapFrom(s => DateTime.Now))
            .ForMember(d => d.totalPrice,
                o => o.MapFrom(
                    s => s.PricePerPerson * s.NumberOfGuests - (0.1M * s.PricePerPerson * (s.NumberOfChildren.HasValue ? s.NumberOfChildren.Value : 0))));



        CreateMap<Reservation, SingleReservationViewModel>()
            .ForMember(d => d.RoomNumber,
                o => o.MapFrom(s => s.Room.RoomNumber))
            .ForMember(d => d.IsOccupied,
                o => o.MapFrom(s => s.Room.IsOccupied));

    }

    
}