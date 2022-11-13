using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedRooms
{
    public void SeedRoomsOnEveryFloor(ModelBuilder builder)
    {
        var models = new List<Room>()
        {
            //floor 1
            
            new Room()
            {
                Id = 1,
                RoomNumber = 101,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 2,
                RoomNumber = 102,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 1,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 3,
                RoomNumber = 103,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 1,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 4,
                RoomNumber = 104,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },

            //Floor 2

            new Room()
            {
                Id = 5,
                RoomNumber = 201,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 6,
                RoomNumber = 202,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 2,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 7,
                RoomNumber = 203,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 2,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 8,
                RoomNumber = 204,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },

            //floor 3

            new Room()
            {
                Id = 9,
                RoomNumber = 301,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 3,
                RoomTypeId = 3,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 10,
                RoomNumber = 302,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 3,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 11,
                RoomNumber = 303,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 3,
                RoomTypeId = 3,
                CreatedOn = DateTime.Today
            },

            //floor 4

            new Room()
            {
                Id = 12,
                RoomNumber = 401,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 4,
                RoomTypeId = 4,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 13,
                RoomNumber = 402,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                FloorId = 4,
                RoomTypeId = 4,
                CreatedOn = DateTime.Today
            }

        };


        builder.Entity<Room>().HasData(models);
    }
}