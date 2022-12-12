using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding
{
    public class SeedUserData : ISeedUserData
    {
        public ICollection<ApplicationUser> SeedUsers(Guid adminGuid)
        {
            

            ApplicationUser user = new ApplicationUser()
            {
                Id = adminGuid,
                UserName = "Admin",
                MiddleName = "Admin",
                Email = "admin@admin.admin",
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



            ApplicationUser user2 = new ApplicationUser()
            {
                Id = Guid.NewGuid(),
                UserName = "John",
                MiddleName = "Doe",
                LastName = "Johnathan",
                Email = "johnnnyboy@johnnyboy.john",
                EGN = "2934827162",
                LockoutEnabled = true,
                PhoneNumber = "08923471624",
                CreatedOn = DateTime.Now,
                NormalizedUserName = "JOHN",
                FirstName = "Johnny",
                SecurityStamp = Guid.NewGuid().ToString(),
                Salary = 9000,
                RFID = "324123539",
                EmailConfirmed = true
            };

            user2.PasswordHash = passwordHasher.HashPassword(user, "JohnnyBoy123");


            var models = new List<ApplicationUser>()
            {
                user,
                user2
            };


            return models;
        }

        public ICollection<ApplicationUserRole> SeedRoles(Guid ownerGuid, Guid adminGuid, Guid HRguid, Guid directorGuid)
        {
            var models = new List<ApplicationUserRole>()
            {
                new ApplicationUserRole()
                {
                    Id = adminGuid,
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
                    Id = HRguid,
                    Name = "Human Resources",
                    NormalizedName = "HUMAN RESOURCES"
                },
                new ApplicationUserRole()
                {
                    Id = directorGuid,
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
            };

            return models;
        }
    
                
        public ICollection<RoleName> SeedRoleNameItems()
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

            return models;
        }

        public ICollection<IdentityUserRole<Guid>> SeedUserRoles(Guid adminGuid, Guid ownerGuid, Guid adminRoleGuid, Guid HRRoleGuid, Guid directorRoleGuid)
        {
            return new List<IdentityUserRole<Guid>>()
            {
                new IdentityUserRole<Guid>()
                    { RoleId = ownerGuid, UserId = adminGuid },
                new IdentityUserRole<Guid>()
                    { RoleId = adminRoleGuid, UserId = adminGuid },
                new IdentityUserRole<Guid>()
                    { RoleId = HRRoleGuid, UserId = adminGuid },
                new IdentityUserRole<Guid>()
                    { RoleId = directorRoleGuid, UserId = adminGuid },

            };
        }

    }
    
}
