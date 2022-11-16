using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedRoomTypes
{
    public void SeedRoomTypesWithoutRooms(ModelBuilder builder)
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
            },
        };


        builder.Entity<RoomType>().HasData(models);
    }
}