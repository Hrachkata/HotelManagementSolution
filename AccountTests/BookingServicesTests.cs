using AutoMapper;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.BookingServices;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.FrontDeskModels.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.Tests;
[TestFixture]
public class BookingServicesTests
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

        bookingService = new BookingServices.BookingService(mapper,  context);
    }

    [TearDown]
    public void Teardown()
    {
        this.context.Rooms.RemoveRange(rooms);
        this.context.Reservations.RemoveRange(reservations);

        this.context.SaveChanges();
    }


    [Test]

    public void BookingServiceProjectModelToBookingMOdel()
    {
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

        var result = bookingService.projectRoomModelToBookingModel(newModel);
        
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
    public async Task BookingServiceProjectReserveRoom()
    {
        var countBeforeReservation = context.Reservations.Count();
        
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
            RoomId = 9,
            RoomNumber = 202,
            RoomType = "Standard"
        };

        var result = await bookingService.reserveRoom(bookingModel);
        
        Assert.AreEqual(true, result);
        
        Assert.AreEqual(countBeforeReservation +1 ,  context.Reservations.Count());
    }


}