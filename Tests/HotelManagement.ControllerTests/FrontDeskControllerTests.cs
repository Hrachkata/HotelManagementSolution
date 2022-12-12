using AutoMapper;
using FakeItEasy;
using HotelManagement.Areas.Account.Controllers;
using HotelManagement.Areas.Hotel.Controllers;
using HotelManagement.Areas.Reservations.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Controllers;
using HotelManagement.Data.Services.BookingServices;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.BookingServices;
using HotelManagement.Data.Services.FloorServices;
using HotelManagement.Data.Services.FrontDeskServices;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.EmailService;
using HotelManagement.Web.ViewModels.FloorModels;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ControllerTests;
[TestFixture]
public class FrontDeskControllerTests
{
    private ApplicationDbContext context;
    
    private List<Floor> floors;

    private List<Room> rooms;

    private List<RoomType> roomTypes;

    private List<Reservation> reservations;

    private IMapper mapper;

    private readonly SendGridEmail emailService;

    private readonly UserManager<ApplicationUser> userManager;

    private IFrontDeskServices frontDeskServices;
    
    [OneTimeSetUp]
    public void InitMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        mapper = config.CreateMapper();
    }
    
    [SetUp]
    public void Setup()
    {
        roomTypes = new SeedRoomTypes().SeedRoomTypesWithoutRooms().ToList();
        
        floors = new SeedFloors().SeedFloorsWithoutRooms().ToList();

        reservations = new SeedReservations().SeedReservationModels().ToList();

        rooms = new SeedRooms().SeedRoomsOnEveryFloor().ToList();
        
        

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

        this.context = new ApplicationDbContext(options);
        this.context.Floors.AddRange(floors);
        this.context.Rooms.AddRange(rooms);
        this.context.RoomTypes.AddRange(roomTypes);
        this.context.Reservations.AddRange(reservations);
        this.context.SaveChanges();

        frontDeskServices = new FrontDeskServices(context, mapper);
    }
    
    [TearDown]
    public void Teardown()
    {
        this.context.Floors.RemoveRange(floors);
        this.context.RoomTypes.RemoveRange(roomTypes);
        this.context.Rooms.RemoveRange(rooms);

        this.context.SaveChanges();
    }

    [Test]
    public async Task TestAllFreeRooms()
    {
        var floorServices = new FloorServices(context, mapper);
        var controller = new FrontDeskController(frontDeskServices,floorServices );

        var testData = new AllFreeRoomsViewModel()
        {
            RoomType = "",
            SearchTerm = "",
            Available = false,
            CurrentPage = 0,
            RoomTypes = context.RoomTypes.Select(rt => rt.Type),
            ArrivalDate = null,
            DepartureDate = null,
            RoomSorting = RoomSortingClass.RoomSorting.Newest,
        };

        var result = await controller.FreeRooms(testData, 0);

        Assert.That(result, Is.InstanceOf<IActionResult>());

        var value = result as ViewResult;
        
        Assert.That(value.Model, Is.InstanceOf<AllFreeRoomsViewModel>());
        Assert.IsInstanceOf<AllFreeRoomsViewModel>(value.Model); 

        var model = value.Model as AllFreeRoomsViewModel;

        var contextRooms = context.Rooms;
        
        var modelRooms = model.Rooms;
        
        
        Assert.AreEqual( context.Rooms.Count(), model.TotalRoomsCount +1 );
        
        Assert.IsTrue(AllFreeRoomsViewModel.RoomsPerPage >= model.Rooms.Count);
    }
}