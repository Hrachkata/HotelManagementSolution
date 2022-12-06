using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.ApplicationDbConfiguration;


    internal class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
    {
        private readonly Guid _adminGuid;
        private readonly Guid _ownerGuid;

        public IdentityUserRoleConfiguration(Guid adminGuid, Guid ownerGuid)
        {
            this._adminGuid = adminGuid;

            this._ownerGuid = ownerGuid;
        }

        


            

        public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
        {
            var seeder = new SeedUserData();

            builder.HasData(seeder.SeedUserRoles(this._adminGuid, this._ownerGuid));
        }
    }