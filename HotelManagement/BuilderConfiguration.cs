using HotelManagement.AutoMapper;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.BookingServices;
using HotelManagement.Data.Services.BookingServices.Contracts;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Data.Services.EmployeeServices;
using HotelManagement.Data.Services.FloorServices.Contracts;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Data.Services.FrontDeskServices;
using HotelManagement.Data.Services.ReservationServices;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Data.Services.RoomServices.Contracts;
using HotelManagement.Data.Services.RoomServices;
using HotelManagement.Data.Services.UserServices;
using HotelManagement.Data.Services.UserServices.Contracts;
using HotelManagement.Data.Services.ViewServices;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HotelManagement;

public class BuilderConfiguration
{
    public void AddServicesToBuidler(WebApplicationBuilder? builder)
    {
        builder.Services.AddControllersWithViews();

        //My services and configurations

        builder.Services.AddScoped<IAccountServices, AccountServices>();

        //this is for email sending
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .AddUserSecrets<SendGridEmail>()
            .Build();

        builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        builder.Services.AddScoped<IEmployeeServices, EmployeeServices>();

        builder.Services.AddScoped<IFloorServices, FloorServices>();

        builder.Services.AddScoped<IRoomServices, RoomServices>();

        builder.Services.AddScoped<IFrontDeskServices, FrontDeskServices>();

        builder.Services.AddScoped<IBookingService, BookingService>();

        builder.Services.AddScoped<IReservationServices, ReservationServices>();

        builder.Services.AddSingleton(configuration);

        builder.Services.AddAutoMapper(typeof(AutoMapperProfile));


        builder.Services.AddSingleton<SeedUserData, SeedUserData>();

        builder.Services.AddSingleton<SeedDeparments, SeedDeparments>();

        builder.Services.AddSingleton<SeedFloors, SeedFloors>();

        builder.Services.AddSingleton<SeedRoomTypes, SeedRoomTypes>();

        builder.Services.AddSingleton<SeedRooms, SeedRooms>();


        builder.Services.AddTransient<SendGridEmail, SendGridEmail>();

        builder.Services.AddScoped<FloorVisualisationServices, FloorVisualisationServices>();

        
    }
}