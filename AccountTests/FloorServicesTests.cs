using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Services.Tests
{
    internal class FloorServicesTests
    {
        private ApplicationDbContext context;

        private List<Floor> floors;

        private List<Room> rooms;

        private List<RoomType> roomTypes;


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

        [Test]
        public void AreTheCorrectNumberOfFloorsAddedToDb()
        {
            Assert.AreEqual(floors.Count, this.context.Floors.Count());
        }

        [Test]
        public void AreTheCorrectNumberOfRoomsAddedToDb()
        {
            Assert.AreEqual(rooms.Count, this.context.Rooms.Count());
        }

        [Test]
        public void AreTheCorrectNumberOfRoomTypesAddedToDb()
        {
            Assert.AreEqual(roomTypes.Count, this.context.RoomTypes.Count());
        }
    }
}
