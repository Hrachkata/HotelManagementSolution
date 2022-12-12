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
        private readonly Guid _HRRoleGuid;
        private readonly Guid _adminRoleGuid;
        private readonly Guid _directorRoleGuid;


        public RoleConfiguration(Guid ownerGuid, Guid adminRoleGuid, Guid HRRoleGuid, Guid directorRoleGuid)
        {
            this._ownerGuid = ownerGuid;
            this._adminRoleGuid = adminRoleGuid;
            this._HRRoleGuid = HRRoleGuid;
            this._directorRoleGuid = directorRoleGuid;


        }

    public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            var seeder = new SeedUserData();

            builder.HasData(seeder.SeedRoles(this._ownerGuid, this._adminRoleGuid, this._HRRoleGuid, this._directorRoleGuid));
        }
    }