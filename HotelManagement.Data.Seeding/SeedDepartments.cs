using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.Data.Seeding;

public class SeedDepartments : ISeedDepartments
{

    public ICollection<Department> SeedDepartmentModels() 
    {
        var models = new List<Department>()
                {
                    new Department
                    {
                        Id = 1,
                        Name = "F&B",
                        Description = "Some Department",
                        CreatedOn = DateTime.Now
                    }, new Department{
                        Id = 2,
                        Name = "Human Resources",
                        Description = "This is the human resource department with access to employee management and hiring new employees.",
                        CreatedOn = DateTime.Now
                    }, new Department{
                        Id = 3,
                        Name = "IT department",
                        Description = "This is the IT department with access to employee management, hiring new employees, admin panel and front desk.",
                        CreatedOn = DateTime.Now
                    }, new Department{
                        Id = 4,
                        Name = "Reservations",
                        Description = "This is the front desk/reception department with access to reservations and front desk.",
                        CreatedOn = DateTime.Now
                    }, new Department{
                        Id = 5,
                        Name = "Director",
                       Description = "This is the director department with access to employee management, hiring new employees, admin panel and front desk.",
                        CreatedOn = DateTime.Now
                    }, new Department{
                        Id = 6,
                        Name = "Owner",
                        Description = "This is full access! NOT RECOMMENDED",
                        CreatedOn = DateTime.Now
                    }
                };

        return models;
    }

    public ICollection<RoleDepartment> SeedDepartmentRoles()
    {
        var models = new List<RoleDepartment>() {

                new RoleDepartment
                {
                    DepartmentId = 1,
                    RoleNameId = 1
                },
                new RoleDepartment
                {
                    DepartmentId = 2,
                    RoleNameId = 2
                },
                new RoleDepartment
                {
                    DepartmentId = 3,
                    RoleNameId = 3
                },
                new RoleDepartment
                {
                    DepartmentId = 3,
                    RoleNameId = 2
                },
                new RoleDepartment
                {
                    DepartmentId = 3,
                    RoleNameId = 6
                },
                new RoleDepartment
                {
                    DepartmentId = 4,
                    RoleNameId = 6
                },
                //Director
                new RoleDepartment { DepartmentId = 5, RoleNameId = 3 },
                new RoleDepartment { DepartmentId = 5, RoleNameId = 2 },
                new RoleDepartment { DepartmentId = 5, RoleNameId = 5 }, 
                //Owner
                new RoleDepartment { DepartmentId = 6, RoleNameId = 1 },
                new RoleDepartment { DepartmentId = 6, RoleNameId = 2 },
                new RoleDepartment { DepartmentId = 6, RoleNameId = 3 },
                new RoleDepartment { DepartmentId = 6, RoleNameId = 4 },
                new RoleDepartment { DepartmentId = 6, RoleNameId = 5 },
                new RoleDepartment { DepartmentId = 6, RoleNameId = 6 },

            };

        return models;
    }
}