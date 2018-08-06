using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Higher_Institution.Data;
using Higher_Institution.Models.Enum;

namespace Higher_Institution.Migrations.InstructorDb
{
    [DbContext(typeof(InstructorDbContext))]
    partial class InstructorDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Higher_Institution.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<DateTime>("DateofBirth");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int>("EntryYearID");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<string>("IdentityNumber");

                    b.Property<string>("Image");

                    b.Property<int>("LevelID");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("ParentAddress");

                    b.Property<string>("ParentName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("SemesterID");

                    b.Property<int>("State");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("EntryYearID");

                    b.HasIndex("LevelID");

                    b.HasIndex("SemesterID");

                    b.ToTable("ApplicationUser");
                });

            modelBuilder.Entity("Higher_Institution.Models.InstructorUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address");

                    b.Property<string>("AssignCourse");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DateofBirth");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("FullName");

                    b.Property<int>("Gender");

                    b.Property<string>("IdentityNumber");

                    b.Property<string>("Image");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MiddleName");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("ParentAddress");

                    b.Property<string>("ParentName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<int>("State");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("InstructorRegisterUser");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.CarryOverStudentCourse", b =>
                {
                    b.Property<int>("CarryOverStudentCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationIdCourseName");

                    b.Property<string>("ApplicationIdSemesterGrade");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CourseID");

                    b.Property<int>("EntryYearID");

                    b.Property<string>("FullName");

                    b.Property<int?>("GeneratedStudentCourseID");

                    b.Property<int>("Grade");

                    b.Property<string>("InstructorUserId");

                    b.Property<int>("SemesterID");

                    b.HasKey("CarryOverStudentCourseID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseID");

                    b.HasIndex("EntryYearID");

                    b.HasIndex("GeneratedStudentCourseID");

                    b.HasIndex("InstructorUserId");

                    b.HasIndex("SemesterID");

                    b.ToTable("CarryOverStudentCourse");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CourseCode")
                        .IsRequired();

                    b.Property<int>("DepartmentID");

                    b.Property<string>("FullName");

                    b.Property<string>("Level")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Semester")
                        .IsRequired();

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.EntryYear", b =>
                {
                    b.Property<int>("EntryYearID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("EntryYearID");

                    b.ToTable("EntryYear");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.GeneratedStudentCourse", b =>
                {
                    b.Property<int>("GeneratedStudentCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationIdCourseId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CourseID");

                    b.Property<int>("EntryYearID");

                    b.Property<string>("FullName");

                    b.Property<int>("Grade");

                    b.Property<string>("InstructorUserId");

                    b.Property<int>("SemesterID");

                    b.HasKey("GeneratedStudentCourseID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseID");

                    b.HasIndex("EntryYearID");

                    b.HasIndex("InstructorUserId");

                    b.HasIndex("SemesterID");

                    b.ToTable("GeneratedStudentCourse");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.InstructorCourse", b =>
                {
                    b.Property<int>("InstructorCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<string>("InstructorUserId");

                    b.HasKey("InstructorCourseID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorUserId");

                    b.ToTable("InstructorCourse");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.Level", b =>
                {
                    b.Property<int>("LevelID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("LevelID");

                    b.ToTable("Level");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.MainStudentReesult", b =>
                {
                    b.Property<int>("MainStudentReesultID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationIdCourseId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CourseID");

                    b.Property<int>("EntryYearID");

                    b.Property<string>("FullName");

                    b.Property<int>("Grade");

                    b.Property<string>("InstructorUserId");

                    b.Property<int>("SemesterID");

                    b.HasKey("MainStudentReesultID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseID");

                    b.HasIndex("EntryYearID");

                    b.HasIndex("InstructorUserId");

                    b.HasIndex("SemesterID");

                    b.ToTable("MainStudentReesult");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.Semester", b =>
                {
                    b.Property<int>("SemesterID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("SemesterID");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationIdCourseId");

                    b.Property<string>("ApplicationUserId");

                    b.Property<int>("CourseID");

                    b.Property<int>("EntryYearID");

                    b.Property<string>("FullName");

                    b.Property<int>("Grade");

                    b.Property<int>("SemesterID");

                    b.HasKey("StudentCourseID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CourseID");

                    b.HasIndex("EntryYearID");

                    b.HasIndex("SemesterID");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.ViewStudentCourse", b =>
                {
                    b.Property<int>("ViewStudentCourseID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("EntryYear");

                    b.Property<string>("FindCollection");

                    b.Property<string>("FullName");

                    b.Property<string>("Level");

                    b.Property<int>("Name");

                    b.Property<string>("Semester");

                    b.HasKey("ViewStudentCourseID");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("ViewStudentCourse");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("InstructorRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("InstructorRoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("InstructorUserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("UserId");

                    b.ToTable("InstructorUserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("ApplicationUserId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("RoleId");

                    b.ToTable("InstructorUserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("InstructorUserToken");
                });

            modelBuilder.Entity("Higher_Institution.Models.ApplicationUser", b =>
                {
                    b.HasOne("Higher_Institution.Models.ViewModels.Department", "Department")
                        .WithMany("ApplicationUser")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.EntryYear", "EntryYear")
                        .WithMany()
                        .HasForeignKey("EntryYearID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.InstructorUser", b =>
                {
                    b.HasOne("Higher_Institution.Models.ViewModels.Department", "Department")
                        .WithMany("Instructor")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.CarryOverStudentCourse", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("CarryOverStudentCourse")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.EntryYear", "EntryYear")
                        .WithMany()
                        .HasForeignKey("EntryYearID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.GeneratedStudentCourse", "GeneratedStudentCourse")
                        .WithMany("CarryOverStudentCourse")
                        .HasForeignKey("GeneratedStudentCourseID");

                    b.HasOne("Higher_Institution.Models.InstructorUser", "Instructor")
                        .WithMany("CarryOverStudentCourse")
                        .HasForeignKey("InstructorUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.Course", b =>
                {
                    b.HasOne("Higher_Institution.Models.ViewModels.Department", "Department")
                        .WithMany("Course")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.GeneratedStudentCourse", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("GeneratedStudentCourse")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Course", "Course")
                        .WithMany("GeneratedStudentCourse")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.EntryYear", "EntryYear")
                        .WithMany()
                        .HasForeignKey("EntryYearID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.InstructorUser", "InstructorUser")
                        .WithMany("GeneratedStudentCourse")
                        .HasForeignKey("InstructorUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.InstructorCourse", b =>
                {
                    b.HasOne("Higher_Institution.Models.ViewModels.Course", "Course")
                        .WithMany("InstructorCourse")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.InstructorUser", "Instructor")
                        .WithMany("InstructorCourse")
                        .HasForeignKey("InstructorUserId");
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.MainStudentReesult", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.EntryYear", "EntryYear")
                        .WithMany()
                        .HasForeignKey("EntryYearID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.InstructorUser", "Instructor")
                        .WithMany("MainStudentReesult")
                        .HasForeignKey("InstructorUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.StudentCourse", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("StudentCourse")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.ViewModels.Course", "Course")
                        .WithMany("StudentCourse")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.EntryYear", "EntryYear")
                        .WithMany()
                        .HasForeignKey("EntryYearID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.ViewModels.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Higher_Institution.Models.ViewModels.ViewStudentCourse", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ViewStudentCourse")
                        .HasForeignKey("ApplicationUserId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.InstructorUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Higher_Institution.Models.InstructorUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Higher_Institution.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Higher_Institution.Models.InstructorUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
