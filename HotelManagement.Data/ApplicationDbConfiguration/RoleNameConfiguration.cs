using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class RoleNameConfiguration : IEntityTypeConfiguration<RoleName>
    {
        public void Configure(EntityTypeBuilder<RoleName> builder)
        {
            var seeder = new SeedUserData();

            builder.HasData(seeder.SeedRoleNameItems());
        }
    }