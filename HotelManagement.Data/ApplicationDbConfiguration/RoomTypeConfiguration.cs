using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Seeding;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class RoomTypeConfiguration : IEntityTypeConfiguration<RoomType>
    {
        
        public void Configure(EntityTypeBuilder<RoomType> builder)
        {
            var seeder = new SeedRoomTypes();

            builder.HasData(seeder.SeedRoomTypesWithoutRooms());
        }



    }