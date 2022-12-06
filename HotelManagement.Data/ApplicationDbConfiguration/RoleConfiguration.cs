using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class RoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        private readonly Guid _ownerGuid;


        public RoleConfiguration(Guid ownerGuid)
        {
            this._ownerGuid = ownerGuid;
        }
    
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            var seeder = new SeedUserData();

            builder.HasData(seeder.SeedRoles(this._ownerGuid));
        }
    }