using System.Runtime.CompilerServices;
using HotelManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Models.Models;
using System.Reflection.Emit;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
    {
        private SeedUserData UserSeeder;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            SeedUserData _UserSeeder)
            : base(options)
        {
            UserSeeder = _UserSeeder;

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeesDepartments { get; set; }


        public DbSet<Floor> Floors { get; set; }
        public DbSet<Reservation>Reservations{ get; set; }

        public DbSet<RoleDepartment> RolesDepartments { get; set; }  
        public DbSet<RoleName> RoleName { get; set; }
        public DbSet<Room> Rooms{ get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeDepartment>()
                .HasKey(ed => new { ed.ApplicationUserId, ed.DepartmentId });

            builder.Entity<EmployeeDepartment>()
                .HasOne(ed => ed.ApplicationUser)
                .WithMany(u => u.EmployeeDepartment)
                .HasForeignKey(ed => ed.ApplicationUserId);

            builder.Entity<EmployeeDepartment>()
                .HasOne(ed => ed.ApplicationUser)
                .WithMany(d => d.EmployeeDepartment)
                .HasForeignKey(ed => ed.ApplicationUserId);



            builder.Entity<RoleDepartment>()
                .HasKey(rd => new { rd.RoleNameId, rd.DepartmentId });

            builder.Entity<RoleDepartment>()
                .HasOne(rd => rd.RoleName)
                .WithMany(rn => rn.RoleDepartment)
                .HasForeignKey(rd => rd.RoleNameId);

            builder.Entity<RoleDepartment>()
                .HasOne(rd => rd.Department)
                .WithMany(d => d.RoleDepartment)
                .HasForeignKey(rd => rd.DepartmentId);



            UserSeeder.SeedRoles(builder);

            UserSeeder.SeedUsers(builder);

            UserSeeder.SeedUserRoles(builder);

            UserSeeder.SeedDepartments(builder);

            UserSeeder.SeedRoleNameItems(builder);

            UserSeeder.SeedDepartmentRoles(builder);
           
            base.OnModelCreating(builder);
        }
    }
}