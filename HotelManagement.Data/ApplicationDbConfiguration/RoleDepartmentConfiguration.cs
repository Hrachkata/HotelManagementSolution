using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class RoleDepartmentConfiguration : IEntityTypeConfiguration<RoleDepartment>
    {
        public void Configure(EntityTypeBuilder<RoleDepartment> builder)
        {
            var seeder = new SeedDepartments();

            builder.HasData(seeder.SeedDepartmentRoles());
        }



    }