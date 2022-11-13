using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding
{
    public class SeedUserData
    {
        private Guid adminGuid = Guid.NewGuid();

        private Guid ownerGuid = Guid.NewGuid();
        public void SeedUsers(ModelBuilder builder)
        {
            

            ApplicationUser user = new ApplicationUser()
            {
                Id = adminGuid,
                UserName = "Admin",
                MiddleName = "Admin",
                EGN = "123",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                CreatedOn = DateTime.Now,
                NormalizedUserName = "ADMIN",
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                Salary = 0,
                RFID = "123456789",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123");

            builder.Entity<ApplicationUser>().HasData(user);
        }

        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "f&b",
                    NormalizedName = "F&B"
                },
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Human Resources",
                    NormalizedName = "HUMAN RESOURCES"
                },
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Director",
                    NormalizedName = "DIRECTOR"
                },
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new ApplicationUserRole()
                {
                    Id = ownerGuid,
                    Name = "Owner",
                    NormalizedName = "OWNER"
                },
                new ApplicationUserRole()
                {
                    Id = Guid.NewGuid(),
                    Name = "Front Desk",
                    NormalizedName = "FRONT DESK"
                }
        );
    }
                
        public void SeedRoleNameItems(ModelBuilder builder)
        {
            var models = new List<RoleName> {
                new RoleName
                {
                    Id = 1,
                    NameOfRole = "F&B",
                },
                new RoleName
                {
                    Id = 2,
                    NameOfRole = "HUMAN RESOURCES"
                },
                new RoleName
                {
                    Id=3,
                    NameOfRole = "ADMIN"
                },
                new RoleName
                {
                    Id =4,
                    NameOfRole = "DIRECTOR",
                },
                new RoleName
                {
                    Id = 5,
                    NameOfRole = "OWNER",
                },
                new RoleName
                {
                    Id = 6,
                    NameOfRole = "FRONT DESK",
                },
            };

            builder.Entity<RoleName>().HasData(models);
        }

       public void SeedUserRoles(ModelBuilder builder)
        {
                builder.Entity<IdentityUserRole<Guid>>().HasData(
                    new IdentityUserRole<Guid>()
                   { RoleId = ownerGuid, UserId = adminGuid }
        );

       }
    }
}
