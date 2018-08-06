using Higher_Institution.Models;
using Higher_Institution.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Data
{
    public class InstructorDbContext : IdentityDbContext<InstructorUser>
    {
        public InstructorDbContext(DbContextOptions<InstructorDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Entity<InstructorUser>().ToTable("InstructorRegisterUser");
            builder.Entity<IdentityRole>().ToTable("InstructorRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("InstructorUserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("InstructorRoleClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("InstructorUserLogin");
            builder.Entity<IdentityUserRole<string>>().ToTable("InstructorUserRole");
            builder.Entity<IdentityUserToken<string>>().ToTable("InstructorUserToken");
        }

        

       

        //public DbSet<Higher_Institution.Models.InstructorUser> InstructorUser { get; set; }
    }
}
