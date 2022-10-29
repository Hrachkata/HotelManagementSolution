using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Data.Models.Models;

namespace HotelManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        
        }

        public DbSet<Department> Type { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<>()

            base.OnModelCreating(builder);

        }
    }
}