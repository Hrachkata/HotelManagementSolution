using AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.AccountServices;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.EmailService.Contracts;
using HotelManagement.MockedLibraries;
using HotelManagement.Web.ViewModels.AccountModels;
using Moq;

namespace HotelManagement.Data.Services.Tests
{
    public class AccountServicesTests
    {

        private ApplicationDbContext context;

        private List<ApplicationUser> users;
        private List<Department> departments;
        private List<ApplicationUserRole> roles;
        private List<IdentityUserRole<Guid>> userRoles;
        private List<RoleName> roleNames;

        private IMapper mapper;

        private ISendGridEmail emailService;

        private UserManager<ApplicationUser> userManager;

        private AccountServices.AccountServices accountServices;
        
        
        
        [OneTimeSetUp]
        public void InitMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            mapper = config.CreateMapper();
        }
        
        [SetUp]
        public void Setup()
        {
            users = new SeedUserData().SeedUsers(Guid.NewGuid()).ToList();

            departments = new SeedDepartments().SeedDepartmentModels().ToList();

            roles = new SeedUserData().SeedRoles(Guid.NewGuid()).ToList();
            
            userRoles = new SeedUserData().SeedUserRoles(Guid.NewGuid(), Guid.NewGuid()).ToList();
            roleNames = new SeedUserData().SeedRoleNameItems().ToList();


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .EnableDetailedErrors()
                .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
                
            .Options;
           
            this.context = new ApplicationDbContext(options);
            this.context.AddRange(users);
            this.context.AddRange(roles);
            this.context.AddRange(userRoles);
            this.context.AddRange(departments);
            this.context.AddRange(roleNames);
            this.context.SaveChanges();

            userManager = new MockUserManager().CreateUserManager();

            emailService = new MockEmailService().SendGridEmailMocked();
            
            accountServices = new AccountServices.AccountServices(userManager, mapper, emailService, context);
        }

        [TearDown]
        public void TearDown()
        {
            this.context.RemoveRange(users);
            this.context.RemoveRange(roles);
            this.context.RemoveRange(userRoles);
            this.context.RemoveRange(departments);
            this.context.RemoveRange(roleNames);
            this.context.SaveChanges();
        }

        [Test]
        public async Task AccountServicesTestGetUserById()
        {
           Assert.AreEqual("Atanas", (await accountServices.GetUserByIdAsync("ratata")).FirstName);

            
        }

        [Test]
        public async Task AccountServicesTestGetUserByEmail()
        {
            Assert.AreEqual("Atanas", (await accountServices.GetUserByEmailAsync("ratata")).FirstName);
           
        }
        
        [Test]
        public async Task AccountServicesTestGetUserByUserName()
        {
            Assert.AreEqual("Atanas", (await accountServices.GetUserByUserNameAsync("ratata")).FirstName);
           
        }
        
        [Test]
        public async Task AccountServicesTestCreateUser()
        {
            Assert.That((await accountServices.CreateUserAsync(new RegisterViewModel()
            {
                UserName = "AdminAki",
                MiddleName = "Admin",
                DepartmentId = 3,
                EGN = "123",
                PhoneNumber = "1234567890",
                CreatedOn = DateTime.Now,
                FirstName = "Admin",
                LastName = "Admin",
                Password = "Balagal21@a",
                Salary = 0,
                RFID = "123456789",
                })).Succeeded, Is.EqualTo(true));
           
        }
        
        [Test]
        public void AreTheUsersAddedWithCorrectData()
        {
            var user1= this.context.Users.First();

            var user2 = this.context.Users.Last();

            Assert.AreEqual(user1.FirstName, users[0].FirstName);

            Assert.AreEqual(user1.LastName, users[0].LastName);
            Assert.AreEqual(user1.FirstName, users[0].FirstName);

            Assert.AreEqual(user1.UserName, users[0].UserName);
            Assert.AreEqual(user1.RFID, users[0].RFID);

            Assert.AreEqual(user2.FirstName, users[1].FirstName);
                                
            Assert.AreEqual(user2.LastName, users[1].LastName);
            Assert.AreEqual(user2.FirstName, users[1].FirstName);
                                
            Assert.AreEqual(user2.UserName, users[1].UserName);
            Assert.AreEqual(user2.RFID, users[1].RFID);

        }

        
    }
}