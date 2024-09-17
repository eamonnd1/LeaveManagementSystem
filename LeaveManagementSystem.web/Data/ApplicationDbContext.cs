using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "3be49617-e2ca-40a0-9707-7f990df5a16c",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "0e9cdd4e-1f5e-4f4d-8d93-b02817356197",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR"
                },
                new IdentityRole
                {
                    Id = "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                });

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    UserName = "admin@localhost.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                });

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c732cc9b-14ca-43d7-bf3d-a67b31ae7c80",
                    UserId = "9e8cb1d1-fd93-4ada-b144-69a705bc8ba5"
                });
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
    }
}
