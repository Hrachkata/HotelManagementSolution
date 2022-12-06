using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedDepartments
{
    ICollection<Department> SeedDepartmentModels();

    ICollection<RoleDepartment> SeedDepartmentRoles();


}