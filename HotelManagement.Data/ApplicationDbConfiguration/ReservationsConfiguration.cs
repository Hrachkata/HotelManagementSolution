using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class ReservationsConfiguration : IEntityTypeConfiguration<Reservation>
    {
        
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            var seeder = new SeedReservations();

            builder.HasData(seeder.SeedReservationModels());
        }



    }