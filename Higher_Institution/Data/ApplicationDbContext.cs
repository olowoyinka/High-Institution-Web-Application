using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Higher_Institution.Models;
using Higher_Institution.Models.ViewModels;

namespace Higher_Institution.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("StudentUser");
            builder.Entity<IdentityRole>().ToTable("StudentRole");
            builder.Entity<IdentityUserClaim<string>>().ToTable("StudentUserClaim");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("StudentRoleClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("StudentUserLogin");
            builder.Entity<IdentityUserRole<string>>().ToTable("StudentUserRole");
            builder.Entity<IdentityUserToken<string>>().ToTable("StudentUserToken");
        }

        public DbSet<Course>  Course { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<EntryYear> EntryYear { get; set; }
        //public DbSet<GradeAssign> GradeAssign { get; set; }
        public DbSet<InstructorCourse> InstructorCourse { get; set; }
        public DbSet<Level> Level { get; set; }
        public DbSet<Semester> Semester { get; set; }
        public DbSet<StudentCourse> StudentCourse { get; set; }
        public DbSet<ViewStudentCourse> ViewStudentCourse { get; set; }
        public DbSet<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }
        public DbSet<CarryOverStudentCourse> CarryOverStudentCourse { get; set; }
        public DbSet<MainStudentReesult> MainStudentReesult { get; set; }
        public DbSet<Scores> Scores { get; set; }
        //public DbSet<YearAssign> YearAssign { get; set; }
        public DbSet<Higher_Institution.Models.ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Higher_Institution.Models.InstructorUser> InstructorUser { get; set; }

    }
}
