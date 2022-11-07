
using AutoMapper;
using AutoMapper.QueryableExtensions;
using HotelManagement.Data.Services.EmployeeServices.Contracts;
using HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels;
using Microsoft.EntityFrameworkCore;
using static HotelManagement.Web.ViewModels.ManageEmployeesModels.ServiceModels.EmployeeSortingClass;
namespace HotelManagement.Data.Services.EmployeeServices
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public EmployeeServices(
            ApplicationDbContext _context,
            IMapper _mapper
            )
        {
            context = _context;

            mapper = _mapper;
        }
       
        public async Task<EmployeeQueryServiceModel> All(EmployeeSorting sorting = EmployeeSorting.Newest,
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
    }
}
