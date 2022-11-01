using System.Runtime.CompilerServices;
using HotelManagement.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Models.Models;
using System.Reflection.Emit;
using HotelManagement.Data.Models.UserModels;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeesDepartments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Reservation>Reservations{ get; set; }
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

            builder.Entity<Department>().HasData(new List<Department>() { new Department
            {
                Name = "F&B",
                Description = "Some Department",
                EmployeeCount = 23,
                CreatedOn = DateTime.Now
            }, new Department{
                Name = "Human Resources",
                Description = "Some Department",
                EmployeeCount = 1,
                CreatedOn = DateTime.Now
            }, new Department{
                Name = "IT department",
                Description = "Some Department",
                EmployeeCount = 4,
                CreatedOn = DateTime.Now
            }, new Department{
                Name = "Reservations",
                Description = "Some Department",
                EmployeeCount = 10,
                CreatedOn = DateTime.Now
            }, new Department{
                Name = "Director",
                Description = "Some Department",
                EmployeeCount = 1,
                CreatedOn = DateTime.Now
            } });
    

           
            base.OnModelCreating(builder);

        }
    }
}