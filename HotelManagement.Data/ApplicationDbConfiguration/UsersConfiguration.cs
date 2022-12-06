using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private readonly Guid _adminGuid;


        public UserConfiguration(Guid adminGuid)
        {
            this._adminGuid = adminGuid;
        }
    
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var seeder = new SeedUserData();

            builder.HasData(seeder.SeedUsers(this._adminGuid));
        }
    }