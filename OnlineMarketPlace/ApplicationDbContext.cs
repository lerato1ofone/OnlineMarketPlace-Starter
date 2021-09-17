using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OnlineMarketPlace.Data.Enums;
using OnlineMarketPlace.Models;
using System;

namespace OnlineMarketPlace
{
    public class ApplicationDbContext : DbContext
    {
        public IConfiguration Configuration { get; }

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
             new User
             {
                 UserId = Guid.NewGuid(),
                 FirstName = "Admin",
                 LastName = "Area",
                 Email = "admin@admin.com",
                 Password = BCrypt.Net.BCrypt.HashPassword("admin", 10),
                 UserRole = UserRole.Admin
             },
              new User
              {
                  UserId = Guid.NewGuid(),
                  FirstName = "Mason",
                  LastName = "Smith",
                  Email = "msmith@customer.com",
                  Password = BCrypt.Net.BCrypt.HashPassword("customer", 10),
                  UserRole = UserRole.Customer
              });
        }
    }
}