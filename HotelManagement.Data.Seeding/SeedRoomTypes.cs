using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedRoomTypes : ISeedRoomTypes
{
    public ICollection<RoomType> SeedRoomTypesWithoutRooms()
    {
        var models = new List<RoomType>()
        {
            new RoomType()
            {
                Id = 1,
                Type = "Standard",
                PricePerPerson = 100,
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 2,
                Type = "Apartment",
                PricePerPerson = 150,
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 3,
                Type = "Deluxe",
                PricePerPerson = 250,
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 4,
                Type = "President",
                PricePerPerson = 400,
                CreatedOn = DateTime.Today
            }
        };


        return models;
    }
}