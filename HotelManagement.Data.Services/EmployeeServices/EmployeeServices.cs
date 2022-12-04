
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Web.ViewModels.ManageEmployeesModels;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Services.AccountServices.Contracts;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using static HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels.EmployeeSortingClass;
using Microsoft.AspNetCore.Identity;

namespace HotelManagement.Data.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly IAccountServices accountServices;

        public EmployeeServices(
            ApplicationDbContext _context,
            IMapper _mapper,
            IAccountServices _accountServices
            )
        {
            context = _context;

            mapper = _mapper;
            this.accountServices = _accountServices;
        }
             
        public async Task<EmployeeQueryServiceModel> All(
            EmployeeSorting sorting = EmployeeSorting.Newest,
            string department = "",
            bool active = true,
            string searchTerm = "",
            int currentPage = 1, 
            int employeesPerPage = 1)
        {


            var employeeQuery = this.context.Users
                .Include(u => u.EmployeeDepartment)
                .ThenInclude(u=>u.Department)
                .Where(u => u.IsActive == active).AsQueryable();

            var searchToLower = searchTerm?.ToLower() ?? string.Empty;

            if (!string.IsNullOrEmpty(department))
            {
                employeeQuery = this.context.Users
                    .Where(u => u.IsActive==true && u.EmployeeDepartment
                        .Any(d => d.Department.Name == department));
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                employeeQuery = employeeQuery.Where(h =>
                    h.FirstName.ToLower().Contains(searchToLower) ||
                    h.MiddleName.ToLower().Contains(searchToLower) ||
                    h.LastName.ToLower().Contains(searchToLower));
            }

            employeeQuery = sorting switch
            {
                EmployeeSorting.Newest =>
                    employeeQuery.OrderByDescending(e => e.CreatedOn),
                EmployeeSorting.Oldest =>
                    employeeQuery.OrderBy(e => e.CreatedOn),
                EmployeeSorting.ByDepartment =>
                    employeeQuery.OrderBy(e => e.EmployeeDepartment.Select(ed => ed.Department.Name).FirstOrDefault()),
                EmployeeSorting.ByFirstName =>
                    employeeQuery.OrderBy(e => e.FirstName),
                EmployeeSorting.ByLastName =>
                    employeeQuery.OrderBy(e => e.LastName)
            };

            var employees = await employeeQuery.Skip((currentPage) * employeesPerPage)
                .Take(employeesPerPage)
                .ProjectTo<SingleEmployeeServiceModel>(mapper.ConfigurationProvider).ToListAsync();

            var totalEmployees = employeeQuery.Count();

            return new EmployeeQueryServiceModel()
            {
                Employees = employees,
                TotalEmployeesCount = totalEmployees
            };
        }

        public async Task<IEnumerable<string>> AllDeparmentsNames()
        {
            return await this.context.Departments.Select(d => d.Name).Distinct().ToListAsync();
        }

        public async Task<EmployeeDetailsModel> GetUserDetailsModel(string id)
        {
            var user = await accountServices.GetUserIncludedDepartmentsByIdAsync(id);

            if (user == null)
            {
                throw new NotFoundException($"User with id {id} not found.");
            }

            return mapper.Map<EmployeeDetailsModel>(user);
        }

        public async Task<EmployeeEditViewModel>? GetUserEditViewModelByIdAsync(string id)
        {
            Guid idToGuid;

            bool idValidation = Guid.TryParse(id, out idToGuid);

            if (!idValidation)
            {
                throw new ArgumentException("Id is invalid.");
            }



            var user = await context.Users
                .Include(u => u.EmployeeDepartment)
                .ThenInclude(ed => ed.Department)
                .Where(u => u.Id == idToGuid).FirstOrDefaultAsync();

            if (user == null)
            {
                throw new ArgumentNullException("User doesn't exist or id is invalid.");
            }

            var employeeDepartments = user.EmployeeDepartment.Select(d => d.DepartmentId).ToList();

            var departmentsEmployeeNotPresentIn = await context.Departments.Where(d => !employeeDepartments.Contains(d.Id)).ProjectTo<DepartmentDto>(mapper.ConfigurationProvider).ToListAsync();

            var result = mapper.Map<EmployeeEditViewModel>(user);

            result.DepartmentsEmployeeDoesntHave = departmentsEmployeeNotPresentIn;

            return result;
        }

        public async Task<bool> AddDepartmentToUser(int departmentId, string userId)
        {
            Guid idToGuid;

            bool idValidation = Guid.TryParse(userId, out idToGuid);

            if (!idValidation)
            {
                throw new ArgumentException("User id format is invalid or the id is invalid.");
            }

            var result = await context.Users.FindAsync(idToGuid);

            if (result == null)
            {
                throw new ArgumentNullException("User doesn't exist or id is invalid.");
            }

            var dep = await context.Departments.FindAsync(departmentId);

            if (dep == null)
            {
                throw new ArgumentNullException("Department doesn't exist or id is invalid.");
            }

            result.EmployeeDepartment.Add(new EmployeeDepartment
            {
                DepartmentId = departmentId,
                ApplicationUserId = idToGuid
            });

            var resultSaveChanges = await context.SaveChangesAsync();

            if (resultSaveChanges > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveDepartmentFromUser(int departmentId, string userId)
        {
            Guid idToGuid;

            bool idValidation = Guid.TryParse(userId, out idToGuid);

            if (!idValidation)
            {
                throw new ArgumentException("User id format is invalid or the id is invalid.");
            }

            var result = await context.Users.Include(u => u.EmployeeDepartment).FirstOrDefaultAsync();

            var depToRemove = result.EmployeeDepartment.Where(ed => ed.DepartmentId == departmentId).FirstOrDefault();
            
            if (depToRemove == null)

            {
                throw new ArgumentException("Department id is invalid or user isn't present in the department.");
            }

            result.EmployeeDepartment.Remove(depToRemove);

            var resultSaveChanges = await context.SaveChangesAsync();

            if (resultSaveChanges > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<IdentityResult> EditUserFromEditViewModel(EmployeeEditViewModel editedModel)
        {
            return await accountServices.UpdateUserAsync(editedModel);
        }

        public async Task<IdentityResult> DisableUser(string userId)
        {


            var result = await accountServices.DisableUser(userId);

            return result;
        }

        public async Task<IdentityResult> EnableUser(string userId)
        {
            var result = await accountServices.EnableUser(userId);

            return result;
        }
    }
}
