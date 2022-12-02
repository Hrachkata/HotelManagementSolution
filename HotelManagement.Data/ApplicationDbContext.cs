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
        private readonly SeedDeparments departmentSeeder;
        private readonly SeedFloors floorSeeder;
        private readonly SeedRoomTypes roomTypeSeeder;
        private readonly SeedRooms roomSeeder;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            SeedUserData _UserSeeder,
            SeedDeparments _DepartmentSeeder,
            SeedFloors _FloorSeeder,
            SeedRoomTypes _RoomTypeSeeder,
            SeedRooms _RoomSeeder)
            : base(options)
        {
            UserSeeder = _UserSeeder;
            departmentSeeder = _DepartmentSeeder;
            floorSeeder = _FloorSeeder;
            roomTypeSeeder = _RoomTypeSeeder;
            roomSeeder = _RoomSeeder;
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeesDepartments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Reservation>Reservations{ get; set; }
        public DbSet<RoleDepartment> RolesDepartments { get; set; }  
        public DbSet<RoleName> RoleName { get; set; }
        public DbSet<Room> Rooms{ get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }
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

            UserSeeder.SeedRoleNameItems(builder);

            departmentSeeder.SeedDepartments(builder);

            departmentSeeder.SeedDepartmentRoles(builder);

            floorSeeder.SeedFloorsWithoutRooms(builder);           
            
            roomTypeSeeder.SeedRoomTypesWithoutRooms(builder);
           
            roomSeeder.SeedRoomsOnEveryFloor(builder);

            base.OnModelCreating(builder);
        }
    }
}