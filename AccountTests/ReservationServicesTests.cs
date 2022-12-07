
using AutoMapper;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.ReservationServices.Contracts;
using HotelManagement.Data.Services.ReservationServices;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;
using HotelManagement.Web.ViewModels.ReservationsModels.ServiceModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.Tests;
[TestFixture]
internal class ReservationServicesTests
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

        reservationServices = new ReservationServices.ReservationServices(context, mapperTest);

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
    /// Reservation all method tests
    /// </summary>
    /// <param name="perPage"></param>
    
    [Test]
    [TestCase(2)]
    [TestCase(5)]
    [TestCase(1)]
    [TestCase(3)]
    public async Task ReservationsAllMethodShouldReturnBasedOnPerPageReservations(int perPage)
    {
        var result = await reservationServices.All(
            DateTime.Today.AddDays(-100),
            null,
            ReservationSortingClass.ReservationSorting.Newest,
            "",
            0,
            perPage);
        
        Assert.AreEqual(perPage, result.Reservations.Count());

    }
    
    [Test]
    [TestCase("atha")]
    [TestCase("1")]
    [TestCase("Ka")]
    [TestCase("Ba")]
    [TestCase("B")]
    [TestCase("25")]
    [TestCase("23463@#$55")]
    [TestCase("107")]
    public async Task ReservationsAllMethodShouldWorkWithASearchTerm(string searchToLower)
    {
        searchToLower = searchToLower.ToLower();
        
        var result = await reservationServices.All(
            null,
            null,
            ReservationSortingClass.ReservationSorting.Newest,
            searchToLower,
            0,
            9999);

        var expected = reservations.Where(r => r.Room.RoomNumber.ToString().Contains(searchToLower) ||
                                               r.Id.Contains(searchToLower) ||
                                               r.GuestFirstName.Contains(searchToLower) ||
                                               r.GuestLastName.Contains(searchToLower) ||
                                               r.GuestEmail.Contains(searchToLower));

        var expectedCount = expected.Count();

        var actual = result.Reservations.Count();
        
        Assert.AreEqual(expectedCount, actual); 

    }
    
    
    [Test]
    [TestCase(100)]
    [TestCase(20)]
    [TestCase(5)]
    [TestCase(1)]
    public async Task ReservationsAllMethodShouldWorkWithDifferentFromArrivalDateParams(int dateNumber)
    {

        var arrivalDate = DateTime.Today.AddDays(-dateNumber);
        
        var result = await reservationServices.All(
            arrivalDate,
            null,
            ReservationSortingClass.ReservationSorting.Newest,
            "",
            0,
            9999);

        var expected = reservations.Where(r => r.ArrivalDate >= arrivalDate);

        var expectedCount = expected.Count();

        var actual = result.Reservations.Count();
        
        Assert.AreEqual(expectedCount, actual); 

    }
    
    [Test]
    [TestCase(15)]
    [TestCase(10)]
    [TestCase(5)]
    [TestCase(1)]
    public async Task ReservationsAllMethodShouldWorkWithDifferentFromArrivalDateParamsAndToArrivalDateParams(int dateNumber)
    {

        var fromArrivalDate = DateTime.Today.AddDays(-dateNumber);
        
        var toArrivalDate = DateTime.Today.AddDays(dateNumber);

        
        var result = await reservationServices.All(
            fromArrivalDate,
            toArrivalDate,
            ReservationSortingClass.ReservationSorting.Newest,
            "",
            0,
            9999);

        var expected = reservations.Where(r => r.ArrivalDate >= fromArrivalDate && r.ArrivalDate <= toArrivalDate);

        var expectedCount = expected.Count();

        var actual = result.Reservations.Count();
        
        Assert.AreEqual(expectedCount, actual); 

    }

    
    /// <summary>
    /// Reservations check in tests
    /// </summary>
    /// <param name="resIndex"></param>
    
    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(1)]
    public async Task CheckInMethodWorksCorrectly(int resIndex)
    {
        var reservations = context.Reservations.ToList();

        var currentRes = reservations[resIndex];

        var currentRoomId = currentRes.RoomId;

        var currentResId = currentRes.Id;

        reservationServices.CheckIn(currentResId, currentRoomId);
        
        reservations = context.Reservations.ToList();
        currentRes = reservations[resIndex];
        currentRoomId = currentRes.RoomId;
        
        Assert.AreEqual(true, currentRes.CheckedIn);
        
        Assert.AreEqual(true, context.Rooms.Find(currentRoomId).IsOccupied);
        
        Assert.AreEqual(false, context.Rooms.Find(currentRoomId).IsCleaned);
    }
    
    [Test]
    [TestCase("bababayay", 2)]
    [TestCase("GSDGSDGDasdad", 3)]
    [TestCase("23523adsf", 5)]

    public async Task CheckInMethodThrowsOnNull(string invalidId, int resIndex)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await reservationServices.CheckIn(invalidId, resIndex));
    }
    
    
    /// <summary>
    /// Check out tests
    /// </summary>
    /// <param name="resIndex"></param>
    
    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(1)]
    public async Task CheckOutMethodWorksCorrectly(int resIndex)
    {
        var reservations = context.Reservations.ToList();

        var currentRes = reservations[resIndex];

        var currentRoomId = currentRes.RoomId;

        var currentResId = currentRes.Id;

        reservationServices.CheckOut(currentResId, currentRoomId);
        
        reservations = context.Reservations.ToList();
        currentRes = reservations[resIndex];
        currentRoomId = currentRes.RoomId;
        
        Assert.AreEqual(false, currentRes.CheckedIn);
        
        Assert.AreEqual(false, currentRes.IsActive);
        
        Assert.AreEqual(false, context.Rooms.Find(currentRoomId).IsOccupied);
        
        Assert.AreEqual(false, context.Rooms.Find(currentRoomId).IsCleaned);
    }
    
    [Test]
    [TestCase("bababayay", 2)]
    [TestCase("GSDGSDGDasdad", 3)]
    [TestCase("23523adsf", 5)]
    public async Task CheckOutMethodThrowsOnNull(string invalidId, int resIndex)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await reservationServices.CheckOut(invalidId, resIndex));
    }
    
    /// <summary>
    /// Print folio paying method tests
    /// </summary>
    /// <param name="resIndex"></param>
    
    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(1)]
    public async Task PrintFolioPaidMethodWorksCorrectly(int resIndex)
    {
        var reservations = context.Reservations.ToList();

        var currentRes = reservations[resIndex];

        var currentResId = currentRes.Id;

        reservationServices.PrintFolioPaid(currentResId);
        
        reservations = context.Reservations.ToList();
        currentRes = reservations[resIndex];
       
        Assert.AreEqual(0M, currentRes.totalPrice);
        
    }
    
    [Test]
    [TestCase("bababayay")]
    [TestCase("GSDGSDGDasdad")]
    [TestCase("23523adsf")]
    public async Task CheckOutMethodThrowsOnNull(string invalidId)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await reservationServices.PrintFolioPaid(invalidId));
    }
    
    
    /// <summary>
    /// Cancel reservation
    /// </summary>
    /// <param name="resIndex"></param>
    
    [Test]
    [TestCase(0)]
    [TestCase(2)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(1)]
    public async Task CancelReservationMethodWorksCorrectly(int resIndex)
    {
        var reservations = context.Reservations.ToList();

        var currentRes = reservations[resIndex];

        var currentResId = currentRes.Id;

        reservationServices.CancelReservation(currentResId);
        
        reservations = context.Reservations.ToList();
        currentRes = reservations[resIndex];
       
        Assert.AreEqual(false, currentRes.IsActive);
        
    }
    
    [Test]
    [TestCase("bababayay")]
    [TestCase("GSDGSDGDasdad")]
    [TestCase("23523adsf")]
    public async Task CancelReservationMethodThrowsOnNull(string invalidId)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await reservationServices.CancelReservation(invalidId));
    }

}