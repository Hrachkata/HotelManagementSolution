using AutoMapper;
using HotelManagement.Areas.Hotel.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.RoomServices;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.ControllerTests;

[TestFixture]
internal class RoomControllerTests
{
    private ApplicationDbContext context;

    private List<Floor> floors;

    private List<Room> rooms;

    private List<RoomType> roomTypes;

    private IMapper mapperTest;

    [SetUp]
    public void Setup()
    {


        roomTypes = new SeedRoomTypes().SeedRoomTypesWithoutRooms().ToList();

        floors = new SeedFloors().SeedFloorsWithoutRooms().ToList();

        rooms = new SeedRooms().SeedRoomsOnEveryFloor().ToList();

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .EnableDetailedErrors()
            .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

        this.context = new ApplicationDbContext(options);
        this.context.RoomTypes.AddRange(roomTypes);

        this.context.Floors.AddRange(floors);

        this.context.Rooms.AddRange(rooms);

        this.context.SaveChanges();
        
        
    }

    [TearDown]
    public void Teardown()
    {
        this.context.Floors.RemoveRange(floors);
        this.context.RoomTypes.RemoveRange(roomTypes);
        this.context.Rooms.RemoveRange(rooms);

        this.context.SaveChanges();
    }
    
    [OneTimeSetUp]
    public void InitMapper()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        mapperTest = config.CreateMapper();
    }
    
    /// <summary>
    /// get room details
    /// </summary>
    [Test]
    public async Task TestDetailsGet()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();
        
        
        var result = await controller.Details(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as ViewResult;
        
        Assert.That(value.Model, Is.InstanceOf<RoomDetailsViewModel>());
        Assert.IsInstanceOf<RoomDetailsViewModel>(value.Model); 
        
        var model = value.Model as RoomDetailsViewModel;
        
        Assert.That(model.Capacity == firstRoom.Capacity);
        Assert.That(model.RoomNumber == firstRoom.RoomNumber);
        Assert.That(model.RoomType == firstRoom.RoomType.Type);
        Assert.That(model.IsOutOfService == firstRoom.IsOutOfService);
    }
    
    /// <summary>
    /// get edit model
    /// </summary>
    
    [Test]
    public async Task TestEditGet()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();
        
        
        var result = await controller.Edit(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as ViewResult;
        
        Assert.That(value.Model, Is.InstanceOf<RoomEditViewModel>());
        Assert.IsInstanceOf<RoomEditViewModel>(value.Model); 
        
        var model = value.Model as RoomEditViewModel;
        
        Assert.That(model.Capacity == firstRoom.Capacity);
        Assert.That(model.RoomNumber == firstRoom.RoomNumber);
        Assert.That(model.currentRoomTypeId == firstRoom.RoomTypeId);
        Assert.That(model.currentFloorId == firstRoom.FloorId);

        
    }
    
    /// <summary>
    /// post edit model
    /// </summary>
    
    [Test]
    public async Task TestEditPost()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();

        var editModel = new RoomEditViewModel()
        {
            Capacity = 3,
            RoomNumber = 101,
            Id = 1,
            currentRoomTypeId = 1,
            RoomTypeDtoId = 1,
            currentFloorId = 1,
            FloorId = 1,

        };
        
        
        var result = await controller.Edit(editModel);
        
        Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");
        
        
    }
    
    /// <summary>
    /// delete room
    /// </summary>
    
    [Test]
    public async Task TestDeleteRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();
        
        
        var result = await controller.Delete(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsActive, false);
    }
    
    /// <summary>
    /// enable room
    /// </summary>
    
    [Test]
    public async Task TestEnableRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();

        firstRoom.IsActive = false;
        context.SaveChanges();
        
        var result = await controller.Enable(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsActive, true);
    }
    
    /// <summary>
    /// IsCleaned room
    /// </summary>
    
    [Test]
    public async Task TestIsDirtyRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();
        
        
        
        var result = await controller.IsDirty(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsCleaned, false);
    }
    
    /// <summary>
    /// enable room
    /// </summary>
    
    [Test]
    public async Task TestISCleanedRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();

        firstRoom.IsCleaned = false;
        context.SaveChanges();
        
        var result = await controller.IsCleaned(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsCleaned, true);
    }
    
    /// <summary>
    /// OutOfService room
    /// </summary>
    
    [Test]
    public async Task TestOutOfServiceRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();
        
        var result = await controller.OutOfService(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsOutOfService, true);
    }
    
    /// <summary>
    /// InService room
    /// </summary>
    
    [Test]
    public async Task TestIsInServicedRoom()
    {
        var roomServices = new RoomServices(context, mapperTest);
        var controller = new RoomController(roomServices );
        var firstRoom = context.Rooms.First();

        firstRoom.IsOutOfService = true;
        context.SaveChanges();
        
        var result = await controller.InService(firstRoom.Id);
        
        Assert.That(result, Is.InstanceOf<IActionResult>());
        
        var value = result as RedirectToActionResult;
        
        Assert.AreEqual(value.ActionName, "Details");

        Assert.AreEqual(firstRoom.IsOutOfService, false);
    }
}