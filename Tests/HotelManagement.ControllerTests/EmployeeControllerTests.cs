using AutoMapper;
using HotelManagement.Areas.Admin.Controllers;
using HotelManagement.AutoMapper;
using HotelManagement.Data;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.Services.AccountServices;
using HotelManagement.Data.Services.EmployeeServices;
using HotelManagement.EmailService.Contracts;
using HotelManagement.MockedLibraries;
using HotelManagement.Web.ViewModels.BookingModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;

namespace HotelManagement.ControllerTests;

public class EmployeeServicesTests
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

    private AccountServices accountServices;

    private EmployeeServices employeeServices;

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

        employeeServices = new EmployeeServices(context, mapper, accountServices);
        
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
    
    /// <summary>
    /// All method tests
    /// </summary>
    
    [Test]
    public async  Task MethodAllShouldWorkCorrectlyWhenNoQueryParamsAreGivenReturnsAll()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var queryModel = new AllEmployeesViewModel()
        {
            EmployeeSorting = EmployeeSortingClass.EmployeeSorting.Newest,
            DepartmentName = "",
            Active = true,
            SearchTerm = "",
            CurrentPage = 0,
        };

        var controllerResult = await controller.All(queryModel);
        
        Assert.That(controllerResult, Is.InstanceOf<IActionResult>());

        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<AllEmployeesViewModel>(value.Model);

        var result = value.Model as AllEmployeesViewModel;
            
        Assert.That(AllEmployeesViewModel.EmployeesPerPage >= result.Employees.Count());
            
        Assert.AreEqual(context.Departments.Where(u => u.IsActive == true).Count(), result.Departments.Count());
    }
   
    [Test]
    public async  Task MethodAllShouldWorkCorrectlyWhenQueryParamsAreGiven()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var queryModel = new AllEmployeesViewModel()
        {
            EmployeeSorting = EmployeeSortingClass.EmployeeSorting.Newest,
            DepartmentName = "H&R",
            Active = false,
            SearchTerm = "",
            CurrentPage = 0,
        };

        var controllerResult = await controller.All(queryModel);
        
        Assert.That(controllerResult, Is.InstanceOf<IActionResult>());

        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<AllEmployeesViewModel>(value.Model);

        var result = value.Model as AllEmployeesViewModel;
            
        Assert.That(AllEmployeesViewModel.EmployeesPerPage >= result.Employees.Count());
            
        Assert.AreEqual(context.Users.Where(u => u.EmployeeDepartment.Any(d => !(d.Department.Name == "H&R"))).Count(), result.Employees.Count());
    }
    
    /// <summary>
    /// Details tests
    /// </summary>
    
    [Test]
    public async  Task MethodDetailsShouldWorkCorrectly()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var controllerResult = await controller.Details(context.Users.First().Id.ToString());
        
        Assert.That(controllerResult, Is.InstanceOf<IActionResult>());

        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<EmployeeDetailsModel>(value.Model);

        var result = value.Model as EmployeeDetailsModel;
       
        Assert.AreEqual(context.Users.First().Id.ToString(), result.Id.ToString());
    }
    
    
    /// <summary>
    /// Edit tests
    /// </summary>
    
    [Test]
    public async  Task EditMethodGetTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var controllerResult = await controller.Edit(context.Users.First().Id.ToString());
        
        Assert.That(controllerResult, Is.InstanceOf<IActionResult>());

        var value = controllerResult as ViewResult;

        Assert.IsInstanceOf<EmployeeEditViewModel>(value.Model);

        var result = value.Model as EmployeeEditViewModel;
       
        Assert.AreEqual(context.Users.First().Id.ToString(), result.Id.ToString());
    }
    
    [Test]
    public async  Task EditMethoPostTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var user = context.Users.First();

        var editModel = mapper.Map<EmployeeEditViewModel>(user);

        var controlSalary = editModel.Salary + 100;

        editModel.Salary += 100;
        
        editModel.PhoneNumber = "1251512";

        var controlPhone = "1251512";
        
        var controllerResult = await controller.Edit(editModel);
        
        Assert.That(controllerResult, Is.InstanceOf<RedirectToActionResult>());

        var value = controllerResult as RedirectToActionResult;

        Assert.AreEqual(context.Users.First().PhoneNumber, controlPhone);
        
        Assert.AreEqual(context.Users.First().Salary, controlSalary);
    }
    
    /// <summary>
    /// Remove department tests
    /// </summary>
    [Test]
    public async  Task RemoveDepartmentPostTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var user = context.Users.First();

        var editModel = mapper.Map<EmployeeEditViewModel>(user);

        var controlCount = user.EmployeeDepartment.Count();
        
        editModel.DepartmentsEmployeeDoesntHave.AddRange(new DepartmentDto[]
        {
            new DepartmentDto()
            {
                DepartmentId = 1,
                DepartmentName = "TestDepartment1"
            },
            new DepartmentDto()
            {
                DepartmentId = 2,
                DepartmentName = "TestDepartment2"
            }
        });

        editModel.DepartmentEmployeeDoesntHaveId = 1;

        var result = await controller.AddDepartment(editModel);
        Assert.IsInstanceOf<RedirectResult>(result);
            
        Assert.AreEqual(controlCount +1 , user.EmployeeDepartment.Count );
    }
    
    /// <summary>
    /// Add department tests
    /// </summary>
    [Test]
    public async  Task AddDepartmentPostTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var user = context.Users.First();

        var editModel = mapper.Map<EmployeeEditViewModel>(user);
        
        user.EmployeeDepartment.AddRange(new EmployeeDepartment[]
        {
            new EmployeeDepartment()
            {
                DepartmentId = 1,
                ApplicationUserId = user.Id
            },
            new EmployeeDepartment()
            {
                DepartmentId = 2,
                ApplicationUserId = user.Id
            }
        });

        var controlCount = user.EmployeeDepartment.Count();

        context.SaveChanges();
        
        editModel.DepartmentOfEmployeeId = 1;

        var result = await controller.RemoveDepartment(editModel);
        Assert.IsInstanceOf<RedirectResult>(result);
            
        Assert.AreEqual(controlCount - 1 , user.EmployeeDepartment.Count );
    }
    
    /// <summary>
    /// Disable tests
    /// </summary>
    [Test]
    public async  Task DisableUserTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var user = context.Users.First();

        var result = await controller.Disable(user.Id.ToString());
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        
        Assert.IsFalse(user.IsActive);

    }
    
    /// <summary>
    /// Enablr tests
    /// </summary>
    [Test]
    public async  Task EnableUserTest()
    {
        var controller = new ManageEmployeesController(employeeServices, accountServices);

        var user = context.Users.First();

        user.IsActive = false;

        context.SaveChanges();

        var result = await controller.Enable(user.Id.ToString());
        Assert.IsInstanceOf<RedirectToActionResult>(result);
        
        Assert.IsTrue(user.IsActive);

    }
}