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
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 2,
                Type = "Apartment",
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 3,
                Type = "Deluxe",
                CreatedOn = DateTime.Today
            },
            new RoomType()
            {
                Id = 4,
                Type = "President",
                CreatedOn = DateTime.Today
            },
        };


        builder.Entity<RoomType>().HasData(models);
    }
}