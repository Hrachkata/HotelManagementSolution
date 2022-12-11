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
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.EmailService.Contracts;
using HotelManagement.MockedLibraries;
using HotelManagement.Web.ViewModels.AccountModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using Moq;

namespace HotelManagement.Data.Services.Tests;

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

    private ApplicationUser firstUser; 
        
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

        userManager = new MockUserManager().CreateUserManager(context);

        emailService = new MockEmailService().SendGridEmailMocked();
            
        accountServices = new AccountServices.AccountServices(userManager, mapper, emailService, context);

        firstUser = context.Users.First();
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
           
        Assert.AreEqual(firstUser, await accountServices.GetUserByIdAsync(firstUser.Id.ToString()));

            
    }

    [Test]
    public async Task AccountServicesTestGetUserByEmail()
    {
        var toTest = await accountServices.GetUserByEmailAsync(context.Users.First().Email);

            
        Assert.AreEqual(firstUser, toTest);
           
    }
        
    [Test]
    public async Task AccountServicesTestGetUserByUserName()
    {
        Assert.AreEqual(firstUser, await accountServices.GetUserByUserNameAsync(firstUser.UserName));
           
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

        var user1db = users.Where(u => u.Id == user1.Id).FirstOrDefault();
            
        var user2db = users.Where(u => u.Id == user2.Id).FirstOrDefault();
            
        Assert.AreEqual(user1, user1db);
            
            
        Assert.AreEqual(user2, user2db);

    }

    [Test]
    [TestCase(0)]
    [TestCase(1)]
    public async Task AccountServicestTestGetUserIncludedDepartmentsByIdAsync(int index)
    {
        Assert.AreEqual(context.Users.ToList()[index].EmployeeDepartment.Count,
            (await accountServices.GetUserIncludedDepartmentsByIdAsync(context.Users.ToList()[index].Id.ToString())).EmployeeDepartment.Count);
            
        Assert.AreEqual(context.Users.ToList()[index].EmployeeDepartment,
            (await accountServices.GetUserIncludedDepartmentsByIdAsync(context.Users.ToList()[index].Id.ToString())).EmployeeDepartment);
    }
        
        
    [Test]
    public async Task AccountServicesTestUpdateUser()
    {
        Assert.That((await accountServices.UpdateUserAsync(new EmployeeEditViewModel()
        {
            Id = context.Users.Last().Id,
            UserName = "Admasdtafasfafini",
            MiddleName = "Admin",
            Email = "abavabegaerg@abv.bg",
            EGN = "123",
            PhoneNumber = "1234567890",
            FirstName = "Admin",
            LastName = "Admin",
            Salary = 0,
            RFID = "123456789",
        })).Succeeded, Is.EqualTo(true));
           
        Assert.AreEqual("abavabegaerg@abv.bg", context.Users.Last().Email);
            
        Assert.AreEqual("Admasdtafasfafini", context.Users.Last().UserName);
            
        Assert.AreEqual("Admin", context.Users.Last().MiddleName);
            
        Assert.AreEqual("123", context.Users.Last().EGN);
            
        Assert.AreEqual("1234567890", context.Users.Last().PhoneNumber);
            
        Assert.AreEqual("Admin", context.Users.Last().LastName);
            
        Assert.AreEqual("Admin", context.Users.Last().FirstName);
            
        Assert.AreEqual("123456789", context.Users.Last().RFID);
    }
        
    [Test]
    public async Task AccountServicesTestResetPasswordTest()
    {
        var newModel = new ResetPasswordModel()
        {
            UserId = "sf",
            Token = "asdf",
            NewPassword = "asd"
        };
            
        Assert.AreEqual(IdentityResult.Success, await accountServices.ResetPasswordAsync(newModel));
           
    }

    [Test]
    public async Task AccountServicesTestGetEditViewModelByUserNameAsync()
    {
        var result = await accountServices.GetEditViewModelByUserNameAsync(firstUser.UserName);
            
        Assert.AreEqual(result.Id,firstUser.Id);
        Assert.AreEqual(result.FirstName,firstUser.FirstName);
        Assert.AreEqual(result.LastName,firstUser.LastName);
        Assert.AreEqual(result.Email,firstUser.Email);
        Assert.AreEqual(result.MiddleName,firstUser.MiddleName);
        Assert.AreEqual(result.UserName,firstUser.UserName);
        Assert.AreEqual(result.PhoneNumber,firstUser.PhoneNumber);
            
    }
        
    [Test]
    public async Task AccountServicesTestProjectToEditViewModel()
    {
        var result = accountServices.ProjectApplicationUserToEditViewModel(firstUser);
            
        Assert.AreEqual(result.Id,firstUser.Id);
        Assert.AreEqual(result.FirstName,firstUser.FirstName);
        Assert.AreEqual(result.LastName,firstUser.LastName);
        Assert.AreEqual(result.Email,firstUser.Email);
        Assert.AreEqual(result.MiddleName,firstUser.MiddleName);
        Assert.AreEqual(result.UserName,firstUser.UserName);
        Assert.AreEqual(result.PhoneNumber,firstUser.PhoneNumber);
            
    }

    [Test]

    public async Task AccountServicesTestDisableUser()
    {
        var result = await accountServices.DisableUser(firstUser.Id.ToString());
            
        Assert.AreEqual(IdentityResult.Success, result);
    }
        
    [Test]
    [TestCase("aklgjkagjka")]
    [TestCase("123asdf")]
    public async Task AccountServicesTestDisableUserThrowsWithInvalidId(string testId)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await accountServices.DisableUser(testId));
            
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await accountServices.DisableUser(Guid.NewGuid().ToString()));
    }
        
        
    [Test]

    public async Task AccountServicesTestEnable()
    {
        var result = await accountServices.EnableUser(firstUser.Id.ToString());
            
        Assert.AreEqual(IdentityResult.Success, result);
    }
        
    [Test]
    [TestCase("aklgjkagjka")]
    [TestCase("123asdf")]
    public async Task AccountServicesTestEnableUserThrowsWithInvalidId(string testId)
    {
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await accountServices.EnableUser(testId));
            
        Assert.ThrowsAsync<ArgumentNullException>(async Task() => await accountServices.EnableUser(Guid.NewGuid().ToString()));
    }
        
    [Test]

    public async Task AccountServicesTestConfirmEmailAsync()
    {
        var result = await accountServices.ConfirmEmailAsync(firstUser.Id.ToString(), "asfasf");
            
        Assert.AreEqual(IdentityResult.Success, result);
            
        Assert.AreEqual(true, firstUser.EmailConfirmed);

    }
        
    [Test]

    public async Task AccountServicesTestGetRegisterViewModel()
    {
        var result = await accountServices.GetRegisterViewModelWithRolesAndDepartmentsAsync();
            
        Assert.AreEqual(departments.Count, result.Departments.Count);
  
    }
        
    [Test]

    public async Task AccountServicesTestSendForgotPasswordEmail()
    {
        var result = accountServices.SendForgotPasswordEmailAsync(firstUser, "asdasdadasda");
            
        Assert.AreEqual(true, result.Successful);
           
    }
}