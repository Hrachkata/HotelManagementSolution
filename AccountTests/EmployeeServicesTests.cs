using AutoMapper;
using HotelManagement.AutoMapper;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.EmailService.Contracts;
using HotelManagement.MockedLibraries;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Services.Tests;

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

    private AccountServices.AccountServices accountServices;

    private EmployeeServices.EmployeeServices employeeServices;

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

        employeeServices = new EmployeeServices.EmployeeServices(context, mapper, accountServices);
        
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
    public async  Task MethodAllShouldWorkCorrectlyWhenNoQueryParamsAreGivenReturnsAll()
    {
        var result =await employeeServices.All(EmployeeSortingClass.EmployeeSorting.Newest,
            "", true, 
            "", 0, 99999);
        
        
            
        Assert.AreEqual(context.Users.Where(u => u.IsActive == true).Count(), result.Employees.Count());
            
        result =await employeeServices.All(EmployeeSortingClass.EmployeeSorting.Newest,
            "", false, 
            "", 0, 99999);
        
        Assert.AreEqual(context.Users.Where(u => u.IsActive == false).Count(), result.Employees.Count());
    }
    
    
    [Test]
    [TestCase("Admin")]
    [TestCase("A")]
    [TestCase("24")]
    [TestCase("2")]
    [TestCase("z%$#")]
    [TestCase("Azn")]
    public async  Task MethodAllShouldWorkCorrectlyWhenSearchParamIsGiven(string search)
    {
        search = search.ToLower();
        
        var result =await employeeServices.All(EmployeeSortingClass.EmployeeSorting.Newest,
            "", true, 
            search, 0, 99999);
        
        Assert.AreEqual(context.Users.Where(h =>
            h.FirstName.ToLower().Contains(search) ||
            h.MiddleName.ToLower().Contains(search) ||
            h.LastName.ToLower().Contains(search)).Count(), result.Employees.Count());
    }
    
    [Test]
    [TestCase(EmployeeSortingClass.EmployeeSorting.Newest)]
    public async  Task MethodAllShouldWorkCorrectlyWhenSortingParamIsGiven1(EmployeeSortingClass.EmployeeSorting sorting)
    {
        var result =await employeeServices.All(sorting,
            "", true, 
            "", 0, 99999);
        
        Assert.AreEqual(context.Users.OrderByDescending(e => e.CreatedOn).Select(p => p.UserName).ToList(), result.Employees.Select(p => p.UserName).ToList());
    }
    
    [Test]
    [TestCase(EmployeeSortingClass.EmployeeSorting.ByFirstName)]
    public async  Task MethodAllShouldWorkCorrectlyWhenSortingParamIsGiven2(EmployeeSortingClass.EmployeeSorting sorting)
    {
        var result =await employeeServices.All(sorting,
            "", true, 
            "", 0, 99999);
        
        Assert.AreEqual(context.Users.OrderBy(e => e.FirstName).Select(p => p.UserName).ToList(), result.Employees.Select(p => p.UserName).ToList());
    }
    
    [Test]
    [TestCase(EmployeeSortingClass.EmployeeSorting.ByLastName)]
    public async  Task MethodAllShouldWorkCorrectlyWhenSortingParamIsGiven3(EmployeeSortingClass.EmployeeSorting sorting)
    {
        var result =await employeeServices.All(sorting,
            "", true, 
            "", 0, 99999);
        
        Assert.AreEqual(context.Users.OrderBy(e => e.LastName).Select(p => p.UserName).ToList(), result.Employees.Select(p => p.UserName).ToList());
    }
    
    [Test]
    [TestCase(EmployeeSortingClass.EmployeeSorting.Oldest)]
    public async  Task MethodAllShouldWorkCorrectlyWhenSortingParamIsGiven4(EmployeeSortingClass.EmployeeSorting sorting)
    {
        var result =await employeeServices.All(sorting,
            "", true, 
            "", 0, 99999);
        
        Assert.AreEqual(context.Users.OrderBy(e => e.CreatedOn).Select(p => p.UserName).ToList(), result.Employees.Select(p => p.UserName).ToList());
    }



    [Test] 
    public async Task MethodAllDepartmentNAmesShouldWorkCorrectly()
    {
        
        
        Assert.AreEqual(context.Departments.Distinct().Count(), (await employeeServices.AllDeparmentsNames()).Count());
    }
    
    [Test] 
    public async Task MethodGetUserDetailsModeShouldWorkCorrectly()
    {
        var id = context.Users.First().Id.ToString();
        
        var expected =  await context.Users.Include(u => u.EmployeeDepartment)
            .ThenInclude(ed => ed.Department).Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();

        var actualUser = await employeeServices.GetUserDetailsModel(id);
        
        Assert.AreEqual(expected.UserName,   actualUser.UserName);
        Assert.AreEqual(expected.RFID,       actualUser.RFID);
        Assert.AreEqual(expected.Id,         actualUser.Id);
        Assert.AreEqual(expected.FirstName,  actualUser.FirstName);
        Assert.AreEqual(expected.Salary,     actualUser.Salary);
        Assert.AreEqual(expected.MiddleName, actualUser.MiddleName);
    }
    
    [Test] 
    public async Task MethodGetUserDetailsModeShouldThrowOnUserNull()
    { 
        Assert.ThrowsAsync<ArgumentNullException>(async Task()=>await employeeServices.GetUserDetailsModel("adfgahaery23"));
    }
    
    [Test] 
    public async Task MethodGetUserEditViewModelByIdAsyncShouldWorkCorrectly()
    {
        var id = context.Users.First().Id.ToString();
        
        var actualUser = await employeeServices.GetUserEditViewModelByIdAsync(id);

        var expected = await context.Users.Include(u => u.EmployeeDepartment)
            .ThenInclude(ed => ed.Department)
            .Where(u => u.Id.ToString() == id).FirstOrDefaultAsync();
        
        Assert.AreEqual(expected.UserName,   actualUser.UserName);
        Assert.AreEqual(expected.RFID,       actualUser.RFID);
        Assert.AreEqual(expected.Id,         actualUser.Id);
        Assert.AreEqual(expected.FirstName,  actualUser.FirstName);
        Assert.AreEqual(expected.Salary,     actualUser.Salary);
        Assert.AreEqual(expected.MiddleName, actualUser.MiddleName);
    }
    
    
    /// <summary>
    /// Add department to user tests
    /// </summary>
    
        [Test] 
        public async Task MethodAddDepartmentToUserShouldWorkCorrectly()
        {
            var controlCount = context.Users.First().EmployeeDepartment.Count;
            
            Assert.IsTrue(await employeeServices.AddDepartmentToUser(1, context.Users.First().Id.ToString()));
            
            Assert.AreEqual(controlCount+1, context.Users.First().EmployeeDepartment.Count );
        }
    
        [Test] 
        public async Task MethodAddDepartmentShouldThrowIfUserIdIsntGuid()
        {
            Assert.ThrowsAsync<ArgumentException>(async Task() => await employeeServices.AddDepartmentToUser(1, "laglalgalga"));
        }
        
        [Test] 
        public async Task MethodAddDepartmentShouldThrowIfUserIdDoesntExistInTheDB()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async Task() => await employeeServices.AddDepartmentToUser(1, Guid.NewGuid().ToString()));
        }
        
        [Test] 
        public async Task MethodAddDepartmentShouldThrowIfDepartmentDoesntExistInDB()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async Task() => await employeeServices.AddDepartmentToUser(235235, context.Users.First().Id.ToString()));
        }
        
        
        /// <summary>
        /// Remove department from user tests
        /// </summary>
        
        [Test] 
        public async Task MethodRemoveDepartmentFromUserShouldWorkCorrectly()
        {
            var user = context.Users.First();
            
            user.EmployeeDepartment.Add(new EmployeeDepartment()
            {
                ApplicationUserId = user.Id,
                DepartmentId = context.Departments.First().Id
            });

            context.SaveChanges();
            
            var controlCount = user.EmployeeDepartment.Count;
            
            Assert.IsTrue(await employeeServices.RemoveDepartmentFromUser(context.Users.First().EmployeeDepartment.First().DepartmentId, context.Users.First().Id.ToString()));
            
            Assert.AreEqual(controlCount-1, context.Users.First().EmployeeDepartment.Count );
        }
    
        [Test] 
        public async Task MethodRemoveDepartmentFromUserShouldThrowIfUserIdIsntGuid()
        {
            Assert.ThrowsAsync<ArgumentException>(async Task() => await employeeServices.RemoveDepartmentFromUser(1, "laglalgalga"));
        }
        
        [Test] 
        public async Task MethodRemoveDepartmentFromUserShouldThrowIfUserIdDoesntExistInTheDB()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async Task() => await employeeServices.RemoveDepartmentFromUser(1, Guid.NewGuid().ToString()));
        }
        
        [Test] 
        public async Task MethodRemoveDepartmentFromUserShouldThrowIfDepartmentDoesntExistInDB()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async Task() => await employeeServices.RemoveDepartmentFromUser(235235, context.Users.First().Id.ToString()));
        }
        
        /// <summary>
        /// Disable user test
        /// </summary>
        [Test] 
        public async Task DisableUserTest()
        {
            var user = context.Users.First();
            
            Assert.IsTrue(user.IsActive);

            employeeServices.DisableUser(user.Id.ToString());
            
            Assert.IsFalse(user.IsActive);
        }
        
        /// <summary>
        /// Enable user test
        /// </summary>
        [Test] 
        public async Task EnableUserTest()
        {
            var user = context.Users.First();

            user.IsActive = false;

            context.SaveChanges();
            
            employeeServices.EnableUser(user.Id.ToString());
            
            Assert.IsTrue(user.IsActive);
        }
        
        
        /// <summary>
        /// EditUserFromEditViewModel test
        /// </summary>
        
        [Test] 
        public async Task MethodEditUserThrowsWithInvalidModel()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async Task() =>  await employeeServices.EditUserFromEditViewModel(new EmployeeEditViewModel()));
        }
        
        [Test] 
        public async Task MethodEditUserWorksWithCorrectModel()
        {
            var user = context.Users.First();

            var controlUser = new ApplicationUser()
            {
                Salary = user.Salary,
                EGN = user.EGN,
                FirstName = user.FirstName
            };

            var editModel = mapper.Map<EmployeeEditViewModel>(user);

            editModel.Salary += 100;

            editModel.EGN = "173516728561";
            
            editModel.FirstName = "Bacho";

            Assert.IsTrue((await employeeServices.EditUserFromEditViewModel(editModel)).Succeeded);
            
            Assert.AreEqual(controlUser.Salary +100, user.Salary);
            
            Assert.AreNotEqual(controlUser.FirstName, user.FirstName);
            
            Assert.AreNotEqual(controlUser.EGN, user.EGN);
        }
}