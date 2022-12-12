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
using FluentEmail.Core.Models;
using HotelManagement.Areas.Account.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.EmailService.Contracts;
using HotelManagement.MockedLibraries;
using HotelManagement.Web.ViewModels.AccountModels;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework.Internal;

namespace HotelManagement.ControllerTests;

public class ManageAccountControllersTests
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
    private SignInManager<ApplicationUser> signInManager;
    private AccountServices accountServices;

    private ApplicationUser firstUser;

    private ManageAccountController controller;
    
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

        roles = new SeedUserData().SeedRoles(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()).ToList();
            
        userRoles = new SeedUserData().SeedUserRoles(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()).ToList();
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

        userManager = new MockUserManager().CreateUserManager(context);
        

        emailService = new MockEmailService().SendGridEmailMocked();
            
        accountServices = new AccountServices(userManager, mapper, emailService, context);

        firstUser = context.Users.First();

        controller =
            new ManageAccountController(signInManager, userManager, accountServices);
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


    }