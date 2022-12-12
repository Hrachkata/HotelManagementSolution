
using AutoMapper;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Web.ViewModels.RoomModels;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.Tests;

[TestFixture]
internal class RoomServicesTests
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
    /// Edit tests
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task GetRoomEditViewModelAsyncMethodWorksCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);

        var roomEditModel = await roomServices.GetRoomEditViewModelAsync(id);
        
        Assert.That(roomEditModel.RoomNumber, Is.EqualTo(context.Rooms.Find(id).RoomNumber));
        Assert.That(roomEditModel.Id, Is.EqualTo(context.Rooms.Find(id).Id));
        Assert.That(roomEditModel.Capacity, Is.EqualTo(context.Rooms.Find(id).Capacity));
        Assert.That(roomEditModel.currentFloorId, Is.EqualTo(context.Rooms.Find(id).FloorId));
        Assert.That(roomEditModel.currentRoomTypeId, Is.EqualTo(context.Rooms.Find(id).RoomTypeId));

    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task GetRoomEditViewModelAsyncMethodSholdThrowIfIdIsInvalidOrOutOfRange(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
       
        Assert.ThrowsAsync<ArgumentNullException>(async Task() =>  await roomServices.GetRoomEditViewModelAsync(id));
    }
  
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task EditRoomsThrowsWhenInvalidIdIsGivenWithTheModel(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);

        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.GetRoomEditViewModelAsync(id));

    }
    
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task EditRoomsWorksCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);

        var roomEditModel = await roomServices.GetRoomEditViewModelAsync(id);

        roomEditModel.Capacity += 10;

        roomEditModel.RoomNumber *= 2;

        var result = await roomServices.EditRoomWithEditViewModel(roomEditModel);

        Assert.That(result, Is.EqualTo(1));

        var changedRoom = context.Rooms.Find(id);
        
        Assert.That(roomEditModel.Capacity, Is.EqualTo(changedRoom.Capacity));
        
        Assert.That(roomEditModel.RoomNumber, Is.EqualTo(changedRoom.RoomNumber));
    }
    
    
    /// <summary>
    /// Delete tests
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task DeleteRoomSetsRoomInactiveById(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        var result = await roomServices.DeleteRoomById(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(false, context.Rooms.Find(id).IsActive);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task DeleteRoomThrowsWhenInvalidIdIsGiven(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.DeleteRoomById(id));
    }
    
    [Test]
    [TestCase(2)]
    [TestCase(4)]
    public async Task DeleteRoomThrowsWhenARoomHasReservation(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);

        var reservation = new Reservation()
        {
            Id = "asdasdasd",
            Address = "ahgadfhadha",
            GuestFirstName = "ahadfhadfha",
            GuestLastName = "afjadfsjasjaja",
            GuestNationality = "ahadfhaeryaeryae",
            GuestPhoneNumber = "346502034767246",
            GuestEmail = "adfyhahya@ABV.BG"
        };
        
        context.Rooms.Find(id).Reservations.Add(reservation);

        context.SaveChanges();
        
        Assert.ThrowsAsync<OperationCanceledException>(async Task() => await roomServices.DeleteRoomById(id));

    }
    
    
    /// <summary>
    /// Out of service tests
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task SetRoomOutOfServiceShouldWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        var result = await roomServices.RoomOutOfServiceByIdAsync(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(true, context.Rooms.Find(id).IsOutOfService);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task SetRoomOutOfServiceByIdShouldThrowIfIdIsInvalid(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.RoomOutOfServiceByIdAsync(id));
    }
    
    [Test]
    [TestCase(2)]
    [TestCase(4)]
    public async Task SetRoomOutOfServiceByIdShouldThrowIfThereIsReservations(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);

        var reservation = new Reservation()
        {
            Id = "asdasdasd",
            Address = "ahgadfhadha",
            GuestFirstName = "ahadfhadfha",
            GuestLastName = "afjadfsjasjaja",
            GuestNationality = "ahadfhaeryaeryae",
            GuestPhoneNumber = "346502034767246",
            GuestEmail = "adfyhahya@ABV.BG"
        };
        
        context.Rooms.Find(id).Reservations.Add(reservation);

        context.SaveChanges();
        
        Assert.ThrowsAsync<OperationCanceledException>(async Task() => await roomServices.RoomOutOfServiceByIdAsync(id));

    }
    
    /// <summary>
    /// Is Dirty tests
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task IsDirtyRoomShouldWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        var result = await roomServices.IsDirtyAsync(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(false, context.Rooms.Find(id).IsCleaned);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task IsDirtyShouldThrowIfIdIsInvalid(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.IsDirtyAsync(id));
    }
    
    /// <summary>
    /// Is Cleaned
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task IsCleanedRoomShouldWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        await roomServices.IsDirtyAsync(id);
        
        var result = await roomServices.IsCleanedAsync(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(true, context.Rooms.Find(id).IsCleaned);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task IsCleanedShouldThrowIfIdIsInvalid(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.IsCleanedAsync(id));
    }
    
    
    /// <summary>
    /// Enable tests
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task EnableRoomShouldWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        await roomServices.DeleteRoomById(id);
        
        var result = await roomServices.EnableRoomById(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(true, context.Rooms.Find(id).IsActive);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task EnableShouldThrowIfIdIsInvalid(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.EnableRoomById(id));
    }
    
    /// <summary>
    /// In service test
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task InServiceRoomShouldWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        await roomServices.RoomOutOfServiceByIdAsync(id);
        
        var result = await roomServices.RoomInServiceByIdAsync(id);
        
        Assert.IsTrue(result);
        
        Assert.AreEqual(false, context.Rooms.Find(id).IsOutOfService);
    
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task InServiceShouldThrowIfIdIsInvalid(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.RoomInServiceByIdAsync(id));
    }
    
    
    /// <summary>
    /// Details methods
    /// </summary>
    /// <param name="id"></param>
    [Test]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(5)]
    public async Task GetRoomDetailsModelByIdMethodWorkCorrectly(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        await roomServices.RoomOutOfServiceByIdAsync(id);
        
        var result = await roomServices.GetRoomDetailsModelAsync(id);

        var roomInDb = context.Rooms
            .Include(r => r.Reservations)
            .Include(r => r.RoomType)
            .Where(r => r.Id ==id).FirstOrDefault();
        
        Assert.AreEqual(roomInDb.Capacity, result.Capacity);
        Assert.AreEqual(roomInDb.IsOutOfService, result.IsOutOfService);
        Assert.AreEqual(roomInDb.CreatedOn, result.CreatedOn);
        Assert.AreEqual(roomInDb.IsCleaned, result.IsCleaned);
        Assert.AreEqual(roomInDb.EditedOn, result.EditedOn);
        Assert.AreEqual(roomInDb.IsActive, result.IsActive);
        Assert.AreEqual(roomInDb.IsOccupied, result.IsOccupied);
        Assert.AreEqual(roomInDb.RoomNumber, result.RoomNumber);
        Assert.AreEqual(roomInDb.RoomType.Type, result.RoomType);
        Assert.AreEqual(roomInDb.Id, result.Id);
        Assert.AreEqual(roomInDb.RoomType.PricePerPerson, result.PricePerPerson);
        Assert.AreEqual(roomInDb.Reservations.Count(), result.NumberOfReservations);
    }
    
    [Test]
    [TestCase(45674)]
    [TestCase(34321)]
    public async Task GetRoomDetailsThrowsWhenInvalidIdIsGiven(int id)
    {
        var roomServices = new RoomServices.RoomServices(context, mapperTest);
    
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await roomServices.GetRoomDetailsModelAsync(id));
    }
}