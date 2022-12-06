using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class FloorsConfiguration : IEntityTypeConfiguration<Floor>
    {
        
        public void Configure(EntityTypeBuilder<Floor> builder)
        {
            var seeder = new SeedFloors();

            builder.HasData(seeder.SeedFloorsWithoutRooms());
        }



    }