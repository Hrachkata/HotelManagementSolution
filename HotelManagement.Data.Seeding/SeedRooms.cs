using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedRooms : ISeedRooms
{
    public ICollection<Room> SeedRoomsOnEveryFloor()
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
                Capacity = 3,
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
                Capacity = 4,
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
                Capacity = 4,
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
                Capacity = 4,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 5,
                RoomNumber = 105,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 3,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 6,
                RoomNumber = 106,
                IsCleaned = false,
                IsOccupied = false,
                IsOutOfService = true,
                Capacity = 3,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 7,
                RoomNumber = 107,
                IsCleaned = false,
                IsOccupied = false,
                IsOutOfService = true,
                Capacity = 3,
                FloorId = 1,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            //Floor 2

            new Room()
            {
                Id = 8,
                RoomNumber = 201,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 2,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 9,
                RoomNumber = 202,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 1,
                FloorId = 2,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 10,
                RoomNumber = 203,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 4,
                FloorId = 2,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 11,
                RoomNumber = 204,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 1,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 12,
                RoomNumber = 205,
                IsCleaned = false,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 1,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 13,
                RoomNumber = 205,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = true,
                Capacity = 1,
                FloorId = 2,
                RoomTypeId = 1,
                CreatedOn = DateTime.Today
            },

            //floor 3

            new Room()
            {
                Id = 14,
                RoomNumber = 301,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 2,
                FloorId = 3,
                RoomTypeId = 3,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 15,
                RoomNumber = 302,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 1,
                FloorId = 3,
                RoomTypeId = 2,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 16,
                RoomNumber = 303,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 4,
                FloorId = 3,
                RoomTypeId = 3,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 17,
                RoomNumber = 303,
                IsCleaned = false,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 4,
                FloorId = 3,
                RoomTypeId = 3,
                CreatedOn = DateTime.Today
            },

            //floor 4

            new Room()
            {
                Id = 18,
                RoomNumber = 401,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 2,
                FloorId = 4,
                RoomTypeId = 4,
                CreatedOn = DateTime.Today
            },
            new Room()
            {
                Id = 19,
                RoomNumber = 402,
                IsCleaned = true,
                IsOccupied = false,
                IsOutOfService = false,
                Capacity = 2,
                FloorId = 4,
                RoomTypeId = 4,
                CreatedOn = DateTime.Today
            }

        };


        return models;
    }
}