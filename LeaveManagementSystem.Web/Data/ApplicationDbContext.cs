using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().
                HasData(
                new IdentityRole { Id = "2852ea1f-2066-4b70-9c6c-625addef42c5", Name = "Employee", NormalizedName = "EMPLOYEE" },
                new IdentityRole { Id = "3a045307-297a-414c-b833-801d2717c0ee", Name = "Supervisor", NormalizedName = "SUPERVISOR" },
                new IdentityRole { Id = "b02c3aef-9985-4eca-9283-77040111df04", Name = "Administrator", NormalizedName = "ADMINISTRATOR" }
                );
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<ApplicationUser>()
                .HasData(
                    new ApplicationUser
                    {
                        Id = "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4",
                        Email = "admin@localhost.com",
                        NormalizedEmail = "ADMIN@LOCAlHOST.COM",
                        NormalizedUserName = "ADMIN@LOCAlHOST.COM",
                        UserName = "admin@localhost.com",
                        PasswordHash = hasher.HashPassword(null, "P@assword1"),
                        EmailConfirmed = true,
                        FirstName = "Joel",
                        LastName = "Hernandez",
                        DateOfBirth = new DateOnly(1992,6,11)
                    }
                );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b02c3aef-9985-4eca-9283-77040111df04",
                    UserId = "7c433a0b-d3b7-49f8-a475-bd9d523ba3e4"
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "b02c3aef-9985-4eca-9283-77040111df04",
                    UserId = "6e08019a-d183-4095-9b34-3f933d35590f"
                });

            modelBuilder.Entity<ApplicationUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RolesClaims");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UsersClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UsersLogins");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UsersRoles");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsersTokens");
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<LeaveAllocation> LeaveAllocations { get; set; }
        public DbSet<Period> Periods { get; set; }
    }
}
