using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Services.FrontDeskServices.Contracts;
using HotelManagement.Web.ViewModels.FloorModels.ServiceModels;

namespace HotelManagement.Data.Services.Tests;

internal class FrontDeskServicesTests
{
    private ApplicationDbContext context;

    private List<Room> rooms;

    private List<RoomType> roomTypes;

    private List<Reservation> reservations;

    private IMapper mapperTest;

    private readonly SendGridEmail emailService;

    private readonly UserManager<ApplicationUser> userManager;

    private IFrontDeskServices frontDeskServices;

    [SetUp]
    public void Setup()
    {
        roomTypes = new SeedRoomTypes().SeedRoomTypesWithoutRooms().ToList();

        reservations = new SeedReservations().SeedReservationModels().ToList();

        rooms = new SeedRooms().SeedRoomsOnEveryFloor().ToList();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

        this.context = new ApplicationDbContext(options);
        this.context.Rooms.AddRange(rooms);
        this.context.RoomTypes.AddRange(roomTypes);
        this.context.Reservations.AddRange(reservations);
        this.context.SaveChanges();

        frontDeskServices = new FrontDeskServices.FrontDeskServices(context, mapperTest);
    }

    [OneTimeSetUp]
    public void InitMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        mapperTest = config.CreateMapper();
    }
        
    [TearDown]
    public void Teardown()
    {
        this.context.Rooms.RemoveRange(rooms);
        this.context.RoomTypes.RemoveRange(roomTypes);
        this.context.Reservations.RemoveRange(reservations);
        this.context.SaveChanges();
    }
        
    [Test]
    public async  Task MethodAllShouldWorkCorrectlyWhenNoQueryParamsAreGivenReturnsAll()
    {
        var result =await frontDeskServices.All(null,
            null, RoomSortingClass.RoomSorting.Newest,
            "", false, "", 0, 99999, 0);
            
        Assert.AreEqual(context.Rooms.Count(), result.Rooms.Count());
            
        Assert.AreEqual(context.Rooms.Count(), result.TotalRoomsCount);
    }
        
    [Test]
    public async  Task MethodAllShouldWorkCorrectlyOnlyAvailable()
    {
        var result =await frontDeskServices.All(null,
            null, RoomSortingClass.RoomSorting.Newest,
            "", true, "", 0, 99999, 0);
            
        Assert.AreEqual(context.Rooms.Where(r => r.IsOutOfService == false).Count(), result.Rooms.Count());
    }

    [Test]
    [TestCase("President")]
    [TestCase("Standard")]
    [TestCase("q2346qtads")]
    [TestCase("Getetetet")]
    public async  Task MethodAllShouldWorkCorrectlyByType(string type)
    {
        var result =await frontDeskServices.All(null,
            null, RoomSortingClass.RoomSorting.Newest,
            type, false, "", 0, 99999, 0);
            
        Assert.AreEqual(context.Rooms.Include(r => r.RoomType).Where(r => r.RoomType.Type == type).Count(), result.Rooms.Count());
    }

    [Test]
    [TestCase("asdgasdg")]
    [TestCase("123")]
    [TestCase("1")]
    [TestCase("55555")]
    [TestCase("12")]
    [TestCase("101")]
    public async  Task MethodAllShouldWorkCorrectlyBySearch(string search)
    {
        search = search.ToLower();
            
        var result =await frontDeskServices.All(null,
            null, RoomSortingClass.RoomSorting.Newest,
            "", false, search, 0, 99999, 0);
            
        Assert.AreEqual(context.Rooms.Include(r => r.RoomType).Where(r => r.RoomNumber.ToString().Contains(search)).Count(), result.Rooms.Count());
    }

    [Test]
    [TestCase(15)]
    [TestCase(10)]
    [TestCase(5)]
    [TestCase(1)]
    public async Task ReservationsAllMethodShouldWorkWithDifferentFromArrivalDateParamsAndToArrivalDateParams(
        int dateNumber)
    {

        var fromArrivalDate = DateTime.Today.AddDays(-dateNumber);

        var toArrivalDate = DateTime.Today.AddDays(dateNumber);
            
        var result =await frontDeskServices.All(fromArrivalDate,
            toArrivalDate, RoomSortingClass.RoomSorting.Newest,
            "", false, "", 0, 99999, 0);

        var resultRooms = new List<Room>();

        foreach (var room in context.Rooms)
        {
            if (room.Reservations.Count == 0 )
            {
                resultRooms.Add(room);

                continue;
            }

            if (room.Reservations.Any(r => ((r.ArrivalDate >= fromArrivalDate && r.ArrivalDate <= toArrivalDate) || (r.DepartureDate >= fromArrivalDate && r.DepartureDate <= toArrivalDate)) && r.IsActive == true))
            {
                continue;
            }

            resultRooms.Add(room);
        }
            
        Assert.AreEqual(resultRooms.Count(), result.Rooms.Count());
            
    }

        
    [Test]
    [TestCase(1, 2)]
    [TestCase(1, 2000)]
    [TestCase(2000, 2)]
    [TestCase(5, 21)]
    [TestCase(20, 1)]

    public async  Task MethodAllShouldWorkCorrectlyPagination(int currentPage, int roomsPerPage)
    {
        var result =await frontDeskServices.All(null,
            null, RoomSortingClass.RoomSorting.Newest,
            "", false, "", currentPage, roomsPerPage, 0);

        var roomsPaged = context.Rooms.ToList();
            
        roomsPaged = roomsPaged.Skip((currentPage) * roomsPerPage)
            .Take(roomsPerPage).ToList();
            
        Assert.AreEqual(roomsPaged.Count(), result.Rooms.Count());
    }



    /// <summary>
    /// Set room occupation method tests
    /// </summary>

    [Test]
    public async Task MethodSetRoomOccupationShouldWorkCorrectly()
    {
        var method = frontDeskServices.GetType().GetMethod("SetRoomOccupation", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);

            
            
        // var result = method.Invoke((this, new object[]
        // {
        //      context.Rooms
        // }));
    }
}