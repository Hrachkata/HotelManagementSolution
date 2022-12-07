using AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Seeding.Contracts;
using HotelManagement.EmailService;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data.Services.Tests
{
    internal class DepartmentServicesTest
    {
        private ApplicationDbContext context;

        private List<ApplicationUser> users;

        private List<Department> departments;
            private AccountServices.AccountServices accountServices;

        private readonly IMapper mapper;

        private readonly SendGridEmail emailService;

        private readonly UserManager<ApplicationUser> userManager;

        [SetUp]
        public void Setup()
        {
            departments = new SeedDepartments().SeedDepartmentModels().ToList();

            users = new SeedUserData().SeedUsers(Guid.NewGuid()).ToList();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .EnableDetailedErrors()
                .UseInMemoryDatabase(databaseName: "HotelManagementInMemoryDb")
            .Options;

            this.context = new ApplicationDbContext(options);
            this.context.AddRange(users);
            this.context.AddRange(departments);
            this.context.SaveChanges();

            accountServices = new AccountServices.AccountServices(userManager, mapper, emailService, context);
        }

        [Test]
        public void AreTheCorrectNumberOfDepartmentsAddedToDb()
        {
            Assert.AreEqual(departments.Count, this.context.Departments.Count());
        }

        //[Test]
        //public void GetUserWithDepartments()
        //{
        //    //TODO tree seednem 200 raboti 
        //    Assert.AreEqual(departments.Count, this.context.Departments.Count());
        //}
    }
}
