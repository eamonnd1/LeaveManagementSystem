using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagementSystem.Data.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
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
    }
}
