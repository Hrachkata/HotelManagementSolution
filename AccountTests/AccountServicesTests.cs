using AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.AccountServices;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.Data.Services.Tests
{
    public class AccountServicesTests
    {

        private ApplicationDbContext context;

        private List<ApplicationUser> users;

        private readonly IMapper mapper;

        private readonly SendGridEmail emailService;

        private readonly UserManager<ApplicationUser> userManager;

        private AccountServices.AccountServices accountServices;

        [SetUp]
        public void Setup()
        {
            users = new SeedUserData().SeedUsers(Guid.NewGuid()).ToList();


            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .EnableDetailedErrors()
                .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
                
            .Options;
           
            this.context = new ApplicationDbContext(options);
            this.context.AddRange(users);
            this.context.SaveChanges();

            accountServices = new AccountServices.AccountServices(userManager, mapper, emailService, context);
        }

        [Test]
        public void AreTheCorrectNumberOfUsersAddedToDb()
        {            
            Assert.AreEqual(2, this.context.Users.Count());
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