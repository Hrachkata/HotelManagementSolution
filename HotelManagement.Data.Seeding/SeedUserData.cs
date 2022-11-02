using HotelManagement.Data.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding
{
    public class SeedUserData
    {
        private Guid adminGuid = Guid.NewGuid();

        private Guid adminRoleGuid = Guid.NewGuid();
        public void SeedUsers(ModelBuilder builder)
        {
            

            ApplicationUser user = new ApplicationUser()
            {
                Id = adminGuid,
                UserName = "Admin",
                Email = "admin@gmail.com",
                MiddleName = "Admin",
                EGN = "124124124",
                LockoutEnabled = false,
                PhoneNumber = "1234567890",
                CreatedOn = DateTime.Now,
                NormalizedUserName = "ADMIN",
                FirstName = "Admin",
                LastName = "Admin",
                SecurityStamp = Guid.NewGuid().ToString(),
                Salary = 1,
                RFID = "234",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin123");

            

            builder.Entity<ApplicationUser>().HasData(user);
        }

        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole("Admin")
                {
                    Id = adminRoleGuid,
                    NormalizedName = "ADMIN"
                },
                new ApplicationUserRole("HumanResources")
                {
                    Id = Guid.NewGuid(),
                    NormalizedName = "HUMANRESOURCES"
                },
                new ApplicationUserRole("Director")
                {
                    Id = Guid.NewGuid(),
                    NormalizedName = "DIRECTOR"
                },
                new ApplicationUserRole("FrontDesk")
                {
                    Id = Guid.NewGuid(),
                    NormalizedName = "FRONTDESK"
                }
        );
    }

        public void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                    { RoleId = adminRoleGuid, UserId = adminGuid }
        );

        }
    }
}
