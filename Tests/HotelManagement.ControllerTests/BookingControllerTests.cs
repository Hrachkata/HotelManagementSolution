using AutoMapper;
using HotelManagement.Areas.Reservations.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.BookingServices;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ControllerTests;
[TestFixture]
public class BookingControllerTests
{
    private ApplicationDbContext context;

    private List<Reservation> reservations;

    private List<Room> rooms;
    
    private BookingService bookingService;

    private IMapper mapper;
    
    [OneTimeSetUp]
    public void InitMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        mapper = config.CreateMapper();
    }

    [SetUp]
    public void Setup()
    {
        reservations = new SeedReservations().SeedReservationModels().ToList();

        rooms = new SeedRooms().SeedRoomsOnEveryFloor().ToList();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

        this.context = new ApplicationDbContext(options);
        this.context.Reservations.AddRange(reservations);
        this.context.Rooms.AddRange(rooms);
        this.context.SaveChanges();

        bookingService = new Data.Services.BookingServices.BookingService(mapper,  context);
    }

    [TearDown]
    public void Teardown()
    {
        this.context.Rooms.RemoveRange(rooms);
        this.context.Reservations.RemoveRange(reservations);

        this.context.SaveChanges();
    }

    [Test]
    public void MethodReserveGetTest()
    {
        var controller = new BookingController(bookingService);
        
        var newModel = new SingleFreeRoomModel()
        {
            
            ArrivalDate = DateTime.Today.AddDays(-10),
            Capacity = 3,
            DepartureDate = DateTime.Today,
            IsCleaned = true,
            IsOccupied = true,
            IsOutOfService = true,
            PricePerPerson = 300M,
            RoomId = 9,
            RoomNumber = 202,
            RoomType = "Standard"
        };

        var controllerResult = controller.Reserve(newModel);
        
        
        Assert.That(controllerResult, Is.InstanceOf<IActionResult>());

        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<BookingModel>(value.Model);

        var result = value.Model as BookingModel;
        
        Assert.AreEqual(newModel.ArrivalDate, result.ArrivalDate);
        Assert.AreEqual(newModel.Capacity, result.Capacity);
        Assert.AreEqual(newModel.DepartureDate, result.DepartureDate);
        Assert.AreEqual(newModel.IsCleaned, result.IsCleaned);
        Assert.AreEqual(newModel.IsOccupied, result.IsOccupied);
        Assert.AreEqual(newModel.PricePerPerson, result.PricePerPerson);
        Assert.AreEqual(newModel.RoomId, result.RoomId);
        Assert.AreEqual(newModel.RoomNumber, result.RoomNumber);
        
    }
    
    [Test]
    public async Task MethodReservePostTest()
    {
        var controller = new BookingController(bookingService);
        
        var bookingModel = new BookingModel()
        {
            GuestFirstName = "Nafta",
            GuestLastName = "Nadenichkova",
            GuestNationality = "Etiopiq",
            GuestPhoneNumber = "4aga2142",
            Address = "Kozi vryh 4 st. 2",
            totalPrice = 300M,
            GuestEmail = "missnk342@abv.bg",
            NumberOfGuests = 2,
            NumberOfChildren = 1,
            ArrivalDate = DateTime.Today.AddDays(-10),
            Capacity = 3,
            DepartureDate = DateTime.Today,
            IsCleaned = true,
            IsOccupied = true,
            IsOutOfService = true,
            PricePerPerson = 300M,
            RoomId = 1,
            RoomNumber = 101,
            RoomType = "Standard"
        };

        var controllerResult = await controller.Reserve(bookingModel);
        
        Assert.That(controllerResult, Is.InstanceOf<RedirectToActionResult>());
        
    }

    [Test]
    public async Task MethodReservePostReturnsViewWIthSameModelOnInvalidData()
    {
        var controller = new BookingController(bookingService);
        
        var bookingModel = new BookingModel()
        {
            GuestFirstName = "",
            GuestLastName = "",
            GuestNationality = "",
            GuestPhoneNumber = "4aga2142",
            Address = "",
            totalPrice = 300M,
            GuestEmail = "missnk342@abv.bg",
            NumberOfGuests = 532522,
            NumberOfChildren = 1,
            ArrivalDate = DateTime.Today.AddDays(-10),
            Capacity = 3,
            DepartureDate = DateTime.Today.AddDays(-30),
            IsCleaned = true,
            IsOccupied = true,
            IsOutOfService = true,
            PricePerPerson = 300M,
            RoomId = 2362362,
            RoomNumber = 101,
            RoomType = "Standard"
        };

        var controllerResult = await controller.Reserve(bookingModel);
        
        Assert.That(controllerResult, Is.InstanceOf<ViewResult>());
        
        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<BookingModel>(value.Model);

        var result = value.Model as BookingModel;
        
        Assert.AreEqual(bookingModel, result);
        
    }


}