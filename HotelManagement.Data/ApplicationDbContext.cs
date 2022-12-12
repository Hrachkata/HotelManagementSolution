using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Models.Models;
using HotelManagement.Data.Models.UserModels;
using HotelManagement.Data.Seeding;
using HotelManagement.Data.ApplicationDbConfiguration;
using HotelManagement.Data.Seeding.Contracts;
using Microsoft.AspNetCore.Identity;


namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, Guid>
    {

        private ISeedUserData UserSeeder;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeesDepartments { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Reservation>Reservations{ get; set; }
        public DbSet<RoleDepartment> RolesDepartments { get; set; }  
        public DbSet<RoleName> RoleName { get; set; }
        public DbSet<Room> Rooms{ get; set; }

        //public DbSet<Guest> Guests { get; set; }

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

            //builder.Entity<Guest>().HasIndex(u => u.PhoneNumber).IsUnique();

            builder.Entity<ApplicationUser>().HasIndex(u => u.UserName).IsUnique();
            builder.Entity<ApplicationUser>().HasIndex(u => u.RFID).IsUnique();

            builder.ApplyConfiguration(new RoleNameConfiguration());

            builder.ApplyConfiguration(new DepartmentConfiguration());
            
            builder.ApplyConfiguration(new FloorsConfiguration());

            builder.ApplyConfiguration(new RoomConfiguration());

            builder.ApplyConfiguration(new RoomTypeConfiguration());
                
           

            var adminGuid = Guid.NewGuid();

            builder.ApplyConfiguration(new UserConfiguration(adminGuid));

            var ownerGuid = Guid.NewGuid();

            var adminRoleGuid = Guid.NewGuid();

            var HRRoleGuid = Guid.NewGuid();

            var directorRoleGuid = Guid.NewGuid();

            builder.ApplyConfiguration(new RoleConfiguration(ownerGuid, adminRoleGuid, HRRoleGuid, directorRoleGuid));

            builder.ApplyConfiguration(new IdentityUserRoleConfiguration(adminGuid, ownerGuid, adminRoleGuid, HRRoleGuid, directorRoleGuid));

            builder.ApplyConfiguration(new RoleDepartmentConfiguration());
            
            builder.ApplyConfiguration(new ReservationsConfiguration());
            
            base.OnModelCreating(builder);
        }
    }
}