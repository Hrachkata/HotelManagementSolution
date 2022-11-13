using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedFloors
{
    public void SeedFloorsWithoutRooms(ModelBuilder builder)
    {
        var models = new List<Floor>()
        {
            new Floor()
            {
                Id = 1,
                FloorNumber = 1,
                CreatedOn = DateTime.Today
            },
            new Floor()
            {
                Id = 2,
                FloorNumber = 2,
                CreatedOn = DateTime.Today
            },
            new Floor()
            {
                Id = 3,
                FloorNumber = 3,
                CreatedOn = DateTime.Today
            },
            new Floor()
            {
                Id = 4,
                FloorNumber = 4,
                CreatedOn = DateTime.Today
            },
        };


        builder.Entity<Floor>().HasData(models);
    }


}