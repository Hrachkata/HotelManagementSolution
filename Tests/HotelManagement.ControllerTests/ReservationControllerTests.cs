
using AutoMapper;
using HotelManagement.Areas.Reservations.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Data.Services.ReservationServices;
using HotelManagement.Web.ViewModels.FloorModels;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ControllerTests;

[TestFixture]
internal class ReservationControllerTests
{
    private ApplicationDbContext context;

    private List<Floor> floors;

    private List<Reservation> reservations;
    
    private List<Room> rooms;

    private List<RoomType> roomTypes;

    private IMapper mapperTest;

    private IReservationServices reservationServices;
    
    
    [SetUp]
    public void Setup()
    {


        roomTypes = new SeedRoomTypes().SeedRoomTypesWithoutRooms().ToList();

        floors = new SeedFloors().SeedFloorsWithoutRooms().ToList();

        rooms = new SeedRooms().SeedRoomsOnEveryFloor().ToList();

        reservations = new SeedReservations().SeedReservationModels().ToList();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

        this.context = new ApplicationDbContext(options);
        this.context.RoomTypes.AddRange(roomTypes);

        this.context.Floors.AddRange(floors);

        this.context.Rooms.AddRange(rooms);

        this.context.Reservations.AddRange(reservations);
        
        this.context.SaveChanges();

        reservationServices = new ReservationServices(context, mapperTest);

        context.Reservations.Add(new Reservation()
        {
            Id = "RH88JLM4",
            GuestFirstName = "Alabala",
            GuestLastName = "Alabala2",
            GuestNationality = "Englardo",
            GuestEmail = "alabala@abv.bg",
            GuestPhoneNumber = "9347857345",
            Address = "London st.22 nm 34",
            NumberOfChildren = 1,
            NumberOfGuests = 3,
            RoomId = 1,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(10),
            CheckedIn = true,
            totalPrice = 400M
        });

    }

    [TearDown]
    public void Teardown()
    {
        this.context.Floors.RemoveRange(floors);
        this.context.RoomTypes.RemoveRange(roomTypes);
        this.context.Rooms.RemoveRange(rooms);
        this.context.Reservations.RemoveRange(reservations);
        this.context.SaveChanges();
    }
    
    [OneTimeSetUp]
    public void InitMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        mapperTest = config.CreateMapper();
    }

    
    /// <summary>
    /// All reservations test
    /// </summary>
    
    [Test]
    public async Task TestAllRooms()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new AllReservationsModel()
        {
            ReservationSorting = ReservationSortingClass.ReservationSorting.Newest,
            RoomType = "",
            SearchTerm = "",
            ArrivalDateFrom = null,
            ArrivalDateTo = null,
            CurrentPage = 0,
        };

        var result = await controller.AllReservations(testData);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as ViewResult;
        
        Assert.That(value.Model, Is.InstanceOf<AllReservationsModel>());
        Assert.IsInstanceOf<AllReservationsModel>(value.Model); 
        
        var model = value.Model as AllReservationsModel;
        
        Assert.AreEqual(context.Reservations.Count(), model.TotalReservationsCount);
        
        Assert.That(AllReservationsModel.ReservationsPerPage >= model.Reservations.Count());
    }
    
    
    /// <summary>
    /// CheckIn test
    /// </summary>
    [Test]
    public async Task CheckInMethodTest()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            RoomId = 1,
        };

        var result = await controller.CheckIn(testData);

        var value = result as ViewResult;
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var model = value.Model as SingleReservationViewModel;
        
        Assert.AreEqual(model, testData);
        
        Assert.AreEqual(value.ViewData["Status"], "Check in");
  
        Assert.AreEqual(true,context.Reservations.Find("RH88JLM4").CheckedIn);
    }
    
    [Test]
    public async Task CheckInMethodThrowsWithInvalidId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "R34673473asdfJLM4",
            RoomId = 1,
        };
       
        var result = await controller.CheckIn(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
    
    [Test]
    public async Task CheckInMethodThrowsWithInvalidRoomId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            RoomId = 2352351,
        };
       
        var result = await controller.CheckIn(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
    
    /// <summary>
    /// CheckOut test
    /// </summary>
    [Test]
    public async Task CheckOutMethodTest()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            GuestFirstName = "Alabala",
            GuestLastName = "Alabala2",
            GuestNationality = "Englardo",
            GuestEmail = "alabala@abv.bg",
            GuestPhoneNumber = "9347857345",
            Address = "London st.22 nm 34",
            NumberOfChildren = 1,
            NumberOfGuests = 3,
            RoomNumber = 101,
            RoomId = 1,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(10),
            CheckedIn = true,
            totalPrice = 400M
        };

        await controller.CheckIn(testData);
        
        var result = await controller.CheckOut(testData);

        var value = result as ViewResult;
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var model = value.Model as SingleReservationViewModel;
        
        Assert.AreEqual(model, testData);
        
        Assert.AreEqual(value.ViewData["Status"], "Check out");
  
        Assert.AreEqual(false,context.Reservations.Find("RH88JLM4").CheckedIn);
    }
    
    
    [Test]
    public async Task CheckOutMethodThrowsWithInvalidId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "R34673473asdfJLM4",
            RoomId = 1,
        };
       
        var result = await controller.CheckOut(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
    
    [Test]
    public async Task CheckOutMethodThrowsWithInvalidRoomId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            RoomId = 2352351,
        };
       
        var result = await controller.CheckOut(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
    
    /// <summary>
    /// Reservation details test
    /// </summary>
    [Test]
    public async Task ReservationDetailsMethodTest()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            GuestFirstName = "Alabala",
            GuestLastName = "Alabala2",
            GuestNationality = "Englardo",
            GuestEmail = "alabala@abv.bg",
            GuestPhoneNumber = "9347857345",
            Address = "London st.22 nm 34",
            NumberOfChildren = 1,
            NumberOfGuests = 3,
            RoomNumber = 101,
            RoomId = 1,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(10),
            CheckedIn = true,
            totalPrice = 400M
        };

        var result = await controller.ReservationDetails(testData);

        var value = result as ViewResult;
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var model = value.Model as SingleReservationViewModel;
        
        Assert.AreEqual(model, testData);
        
    }
    
    
    /// <summary>
    /// Print folio test
    /// </summary>
    [Test]
    public async Task PrintFolioMethodTest()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            GuestFirstName = "Alabala",
            GuestLastName = "Alabala2",
            GuestNationality = "Englardo",
            GuestEmail = "alabala@abv.bg",
            GuestPhoneNumber = "9347857345",
            Address = "London st.22 nm 34",
            NumberOfChildren = 1,
            NumberOfGuests = 3,
            RoomNumber = 101,
            RoomId = 1,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(10),
            CheckedIn = true,
            totalPrice = 400M
        };

        var result = await controller.PrintFolio(testData);

        var value = result as ViewResult;
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var model = value.Model as SingleReservationViewModel;
        
        Assert.AreEqual(model, testData);
        
        Assert.AreEqual(0,context.Reservations.Find("RH88JLM4").totalPrice);
        
    }
    
    [Test]
    public async Task PrintFolioMethodThrowsWithInvalidId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "R34673473asdfJLM4",
            RoomId = 1,
        };
       
        var result = await controller.PrintFolio(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
    
    
    /// <summary>
    /// Print folio test
    /// </summary>
    [Test]
    public async Task CancelMethodTest()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "RH88JLM4",
            GuestFirstName = "Alabala",
            GuestLastName = "Alabala2",
            GuestNationality = "Englardo",
            GuestEmail = "alabala@abv.bg",
            GuestPhoneNumber = "9347857345",
            Address = "London st.22 nm 34",
            NumberOfChildren = 1,
            NumberOfGuests = 3,
            RoomNumber = 101,
            RoomId = 1,
            ArrivalDate = DateTime.Today,
            DepartureDate = DateTime.Today.AddDays(10),
            CheckedIn = true,
            totalPrice = 400M
        };
        
        var result = await controller.Cancel(testData);

        var value = result as ViewResult;
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var model = value.Model as SingleReservationViewModel;
        
        Assert.AreEqual(model, testData);
        
        Assert.AreEqual(false,context.Reservations.Find("RH88JLM4").IsActive);
        
    }
    
    
    [Test]
    public async Task CancelMethodThrowsWithInvalidId()
    {
        var controller = new ReservationsController(reservationServices);
      
        var testData = new SingleReservationViewModel()
        {
            Id = "R34673473asdfJLM4",
            RoomId = 1,
        };
       
        var result = await controller.Cancel(testData);

        Assert.AreEqual(1, controller.ModelState.ErrorCount);
        
    }
   
}