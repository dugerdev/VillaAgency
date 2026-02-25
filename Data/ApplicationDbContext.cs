using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VillaAgency.Models.Entities;

namespace VillaAgency.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppilcationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Identity tablo adlarını özelleştirme (şema: app)
            builder.Entity<AppilcationUser>().ToTable("Users", "app");
            builder.Entity<IdentityRole>().ToTable("Roles", "app");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "app");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "app");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "app");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "app");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "app");

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            string AdminRoleId = Guid.Parse("019c330e-6c3e-7ace-aa53-1dfe8fda644f").ToString();
            string UserRoleId = Guid.Parse("019c330e-6c3e-753c-bd9b-7e2e7ad57c19").ToString();


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN", 
                },
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER"
                }

                );

            // Template seed data
            SeedData.Seed(builder);
        }

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyImage> PropertyImages { get; set; }
        public DbSet<PropertyType> PropertyTypes { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }
      
    }
}
