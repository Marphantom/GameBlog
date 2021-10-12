using GameBlog.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameBlog.Contexts
{
    public class GameBlogDBContext : IdentityDbContext
    {
        public GameBlogDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Posts> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedingUsers(modelBuilder);
            SeedingRoles(modelBuilder);
            SeedingUserRoles(modelBuilder);
        }
        private void SeedingUsers(ModelBuilder builder)
        {
            AppUser user = new AppUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Trong Nguyen",
                Email = "jstrongnguyen@gmail.com",
                NormalizedEmail = "jstrongnguyen@gmail.com",
                NormalizedUserName = "trong nguyen",
                LockoutEnabled = false,
                PhoneNumber = "0932127783",
                Avatar = "~/images/avatar.jpg"
            };

            PasswordHasher<AppUser> passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Nguyen12345");

            builder.Entity<AppUser>().HasData(user);
        }

        private void SeedingRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "SystemAdmin", ConcurrencyStamp = "1", NormalizedName = "System Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Admin", ConcurrencyStamp = "2", NormalizedName = "Admin" }
                );
        }

        private void SeedingUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }
}
