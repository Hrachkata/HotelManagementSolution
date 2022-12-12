using HotelManagement.Data.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding.Contracts;

public interface ISeedDepartments
{
    /// <summary>
    /// Returns department entities
    /// </summary>
    /// <returns>ICollection&lt;Department&gt;</returns>
    ICollection<Department> SeedDepartmentModels();

    /// <summary>
    /// Returns roledepartment entities
    /// </summary>
    /// <returns>ICollection&lt;RoleDepartment&gt;</returns>
    ICollection<RoleDepartment> SeedDepartmentRoles();


}