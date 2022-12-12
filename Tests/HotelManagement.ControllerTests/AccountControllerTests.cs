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

public class AccountControllersTests
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

    private AccountController accountController;
    
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

        accountController =
            new AccountController(signInManager, userManager, accountServices);
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
    /// <summary>
    /// Login get test
    /// </summary>
    [Test]
    public void LoginGetTest()
    {
        var result = accountController.Login();
        
        Assert.That(result, Is.InstanceOf<IActionResult>());

        var value = result as ViewResult;

        Assert.IsInstanceOf<LoginViewModel>(value.Model);

    }
    
    /// <summary>
    /// Register tests
    /// </summary>
    [Test]
    public async Task RegisterGetTest()
    {
        var result = await  accountController.Register();
        
        Assert.That(result, Is.InstanceOf<IActionResult>());

        var value = result as ViewResult;

        Assert.IsInstanceOf<RegisterViewModel>(value.Model);

    }
   
    [Test]
    public async Task RegisterPostTest()
    {
        var registerModel = new RegisterViewModel()
        {
            UserName = "Ratata",
            MiddleName = "Patata",
            DepartmentId = 3,
            EGN = "12353523",
            PhoneNumber = "1324234567890",
            CreatedOn = DateTime.Now,
            FirstName = "Muncho",
            LastName = "Tapuncho",
            Password = "Balagal21@a",
            Salary = 0,
            RFID = "123456789",
        };
        
        var result = await  accountController.Register(registerModel);
        
        Assert.That(result, Is.InstanceOf<RedirectResult>());
       
    }
    
    /// <summary>
    /// Confirm email test
    /// </summary>
    [Test]
    public async Task ConfirmEmailGetTest()
    {
        var result = await  accountController.ConfirmEmail(firstUser.Id.ToString(), "awteawet", firstUser.Email);
        
        Assert.That(result, Is.InstanceOf<ViewResult>());
       
        var value = result as ViewResult;

        Assert.IsInstanceOf<ConfirmEmailViewModel>(value.Model);
        
    }
    
    [Test]
    public async Task ConfirmEmailPostTest1()
    {
        firstUser.EmailConfirmed = false;

        context.SaveChanges();
        var emailModel = new ConfirmEmailViewModel()
        {
            Email = firstUser.Email,
            EmailSent = true,
            EmailVerified = true,
            IsConfirmed = true
        };
        
        var result = await  accountController.ConfirmEmail(emailModel);
        
        Assert.That(result, Is.InstanceOf<ViewResult>());
       
        var value = result as ViewResult;

        Assert.IsInstanceOf<ConfirmEmailViewModel>(value.Model);
        
    }
    
    [Test]
    public async Task ConfirmEmailPostTest2()
    {
        firstUser.EmailConfirmed = false;
        context.SaveChanges();
        var emailModel = new ConfirmEmailViewModel()
        {
            Email = firstUser.Email,
            EmailSent = false,
            EmailVerified = false,
            IsConfirmed = false
        };
        
        var result = await  accountController.ConfirmEmail(emailModel);
        
        Assert.That(result, Is.InstanceOf<ViewResult>());
       
        var value = result as ViewResult;

        Assert.IsInstanceOf<ConfirmEmailViewModel>(value.Model);

        var model = value.Model as ConfirmEmailViewModel;
        
        Assert.IsTrue(model.EmailSent);
    }
    
    /// <summary>
    /// ForgotPassword test
    /// </summary>
    [Test]
    public async Task ForgotPasswordGetTest()
    {
        var result = await  accountController.ForgotPassword();
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        
    }
    [Test]
    public async Task ForgotPasswordPostTest()
    {
        var newForgotPassModel = new ForgotPasswordViewModel()
        {
            Email = firstUser.Email,
            EmailSent = false
        };
        
        var result = await  accountController.ForgotPassword(newForgotPassModel);
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var value = result as ViewResult;

        Assert.IsInstanceOf<ForgotPasswordViewModel>(value.Model);

        var model = value.Model as ForgotPasswordViewModel;
        
        Assert.IsTrue(model.EmailSent);
    }
    
    /// <summary>
    /// Reset password test
    /// </summary>
    [Test]
    public async Task ResetPasswordGetTest()
    {
        var result = await  accountController.ResetPassword(firstUser.Id.ToString(), "Lalala");
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        
    }
    [Test]
    public async Task ResetPasswordPostTest()
    {
        var newResetPassModel = new ResetPasswordModel
        {
            UserId = firstUser.Id.ToString(),
            Token = "lalalal",
            NewPassword = "bingoBango",
            ConfirmPassword = "bingoBango"
        };
        
        var result = await  accountController.ResetPassword(newResetPassModel);
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

        var value = result as ViewResult;


    }
    
    [Test]
    public async Task ResetPasswordConfirmation()
    {
        var result =  accountController.ResetPasswordConfirmation();
        
        Assert.That(result, Is.InstanceOf<ViewResult>());

    }
}