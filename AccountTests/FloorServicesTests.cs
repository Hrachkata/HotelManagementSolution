using AutoMapper;
using AutoMapper.Internal;
using EllipticCurve.Utils;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.FloorServices.ViewServices;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static HotelManagement.Web.ViewModels.FloorModels.ServiceModels.RoomSortingClass;

namespace HotelManagement.Data.Services.Tests
{
    [TestFixture]
    internal class FloorServicesTests
    {
        
        private ApplicationDbContext context;

        private List<Floor> floors;

        private List<Room> rooms;

        private List<RoomType> roomTypes;

        private IMapper mapperTest;

        [OneTimeSetUp]
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

        [Test]
        public void AreTheCorrectNumberOfRoomsAddedToDb()
        {
            Assert.AreEqual(rooms.Count, this.context.Rooms.Count());
        }

        [Test]
        public void AreTheCorrectNumberOfFloorsAddedToDb()
        {
            Assert.AreEqual(floors.Count, this.context.Floors.Count());
        }
        
        [Test]
        public void AreTheCorrectNumberOfRoomTypesAddedToDb()
        {
            Assert.AreEqual(roomTypes.Count, this.context.RoomTypes.Count());
        }

        [OneTimeSetUp]
        public void InitMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            mapperTest = config.CreateMapper();
        }

        [Test]
        public async Task GetRoomTypesShouldReturnTheCorrectCount()
        {
            var floorServices = new FloorServices.FloorServices(context, mapperTest);

            var result = await floorServices.GetRoomTypes();

            Assert.AreEqual(this.context.RoomTypes.Count(), result.Count());
        }

        [Test]
        public async Task GetRoomTypesShouldReturnCorrectValues()
        {
          
            var floorServices = new FloorServices.FloorServices(context, mapperTest);

            var result = await floorServices.GetRoomTypes();

            var resultAsList = result.ToList();

            var dbTypes = context.RoomTypes.ToList();

            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(dbTypes[i].Type, resultAsList[i]);
            } 
        }

        [Test]
        public async Task GetRoomMethodAllShouldReturnAllActiveRoomsWithNoQueryParams()
        {
                        
            var floorServices = new FloorServices.FloorServices(context, mapperTest);

            var result = await floorServices.All(RoomSorting.Newest,"",true,"",false, 0, 99999, 0);

            Assert.AreEqual(this.context.Rooms.Where(r => r.IsActive).Count(), result.Rooms.Count());
        }


        [Test]
        public async Task GetRoomMethodAllShouldReturnWorkCorrectlyWithTheGivenQueryParams()
        {
           
            var floorServices = new FloorServices.FloorServices(context, mapperTest);

            var result = await floorServices.All(RoomSorting.Newest, "", true, "", true, 0, 99999, 0);

            Assert.AreEqual(this.context.Rooms.Where(r => r.IsActive && r.IsOccupied == false && r.IsCleaned == true && r.IsOutOfService == false).Count(), result.Rooms.Count());
        }


        [Test]
        public async Task GetRoomMethodAllShouldWorkWhenGivenPaginationParameters()
        {
         
            var floorServices = new FloorServices.FloorServices(context, mapperTest);

            var result = await floorServices.All(RoomSorting.Newest, "", true, "", false, 1, 10, 0);

            Assert.AreEqual(this.context.Rooms.Skip(10).Take(10).Count(), result.Rooms.Count());
        }

        [Test]
        public async Task FloorServiceForVisualization()
        {

            var floorUiServices = new FloorVisualisationServices(context, mapperTest);

            var result = await floorUiServices.GetFloorItems();

            Assert.AreEqual(this.context.Floors.Count(), result.Count());
        }
    }
}
