using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Higher_Institution.Migrations.InstructorDb
{
    public partial class Inheritance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "EntryYear",
                columns: table => new
                {
                    EntryYearID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntryYear", x => x.EntryYearID);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "Semester",
                columns: table => new
                {
                    SemesterID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Semester", x => x.SemesterID);
                });

            migrationBuilder.CreateTable(
                name: "InstructorRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstructorUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "InstructorRegisterUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AssignCourse = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    ParentAddress = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRegisterUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorRegisterUser_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    CourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseCode = table.Column<string>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Semester = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.CourseID);
                    table.ForeignKey(
                        name: "FK_Course_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    LevelID = table.Column<int>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    ParentAddress = table.Column<string>(nullable: true),
                    ParentName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    SemesterID = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUser_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorRoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorRoleClaim_InstructorRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "InstructorRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorCourse",
                columns: table => new
                {
                    InstructorCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CourseID = table.Column<int>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorCourse", x => x.InstructorCourseID);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorCourse_InstructorRegisterUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedStudentCourse",
                columns: table => new
                {
                    GeneratedStudentCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationIdCourseId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true),
                    SemesterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedStudentCourse", x => x.GeneratedStudentCourseID);
                    table.ForeignKey(
                        name: "FK_GeneratedStudentCourse_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneratedStudentCourse_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedStudentCourse_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneratedStudentCourse_InstructorRegisterUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GeneratedStudentCourse_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainStudentReesult",
                columns: table => new
                {
                    MainStudentReesultID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationIdCourseId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true),
                    SemesterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainStudentReesult", x => x.MainStudentReesultID);
                    table.ForeignKey(
                        name: "FK_MainStudentReesult_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainStudentReesult_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainStudentReesult_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainStudentReesult_InstructorRegisterUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MainStudentReesult_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourse",
                columns: table => new
                {
                    StudentCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationIdCourseId = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    SemesterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourse", x => x.StudentCourseID);
                    table.ForeignKey(
                        name: "FK_StudentCourse_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourse_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ViewStudentCourse",
                columns: table => new
                {
                    ViewStudentCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    EntryYear = table.Column<string>(nullable: true),
                    FindCollection = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Level = table.Column<string>(nullable: true),
                    Name = table.Column<int>(nullable: false),
                    Semester = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewStudentCourse", x => x.ViewStudentCourseID);
                    table.ForeignKey(
                        name: "FK_ViewStudentCourse_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstructorUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorUserClaim_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorUserClaim_InstructorRegisterUser_UserId",
                        column: x => x.UserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_InstructorUserLogin_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorUserLogin_InstructorRegisterUser_UserId",
                        column: x => x.UserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InstructorUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_InstructorUserRole_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstructorUserRole_InstructorRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "InstructorRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InstructorUserRole_InstructorRegisterUser_UserId",
                        column: x => x.UserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarryOverStudentCourse",
                columns: table => new
                {
                    CarryOverStudentCourseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationIdCourseName = table.Column<string>(nullable: true),
                    ApplicationIdSemesterGrade = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    GeneratedStudentCourseID = table.Column<int>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true),
                    SemesterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarryOverStudentCourse", x => x.CarryOverStudentCourseID);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_ApplicationUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_GeneratedStudentCourse_GeneratedStudentCourseID",
                        column: x => x.GeneratedStudentCourseID,
                        principalTable: "GeneratedStudentCourse",
                        principalColumn: "GeneratedStudentCourseID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_InstructorRegisterUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorRegisterUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarryOverStudentCourse_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_DepartmentID",
                table: "ApplicationUser",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_EntryYearID",
                table: "ApplicationUser",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_LevelID",
                table: "ApplicationUser",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_SemesterID",
                table: "ApplicationUser",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRegisterUser_DepartmentID",
                table: "InstructorRegisterUser",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "InstructorRegisterUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "InstructorRegisterUser",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_ApplicationUserId",
                table: "CarryOverStudentCourse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_CourseID",
                table: "CarryOverStudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_EntryYearID",
                table: "CarryOverStudentCourse",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_GeneratedStudentCourseID",
                table: "CarryOverStudentCourse",
                column: "GeneratedStudentCourseID");

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_InstructorUserId",
                table: "CarryOverStudentCourse",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CarryOverStudentCourse_SemesterID",
                table: "CarryOverStudentCourse",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_DepartmentID",
                table: "Course",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStudentCourse_ApplicationUserId",
                table: "GeneratedStudentCourse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStudentCourse_CourseID",
                table: "GeneratedStudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStudentCourse_EntryYearID",
                table: "GeneratedStudentCourse",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStudentCourse_InstructorUserId",
                table: "GeneratedStudentCourse",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedStudentCourse_SemesterID",
                table: "GeneratedStudentCourse",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_CourseID",
                table: "InstructorCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorCourse_InstructorUserId",
                table: "InstructorCourse",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainStudentReesult_ApplicationUserId",
                table: "MainStudentReesult",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainStudentReesult_CourseID",
                table: "MainStudentReesult",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_MainStudentReesult_EntryYearID",
                table: "MainStudentReesult",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_MainStudentReesult_InstructorUserId",
                table: "MainStudentReesult",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MainStudentReesult_SemesterID",
                table: "MainStudentReesult",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_ApplicationUserId",
                table: "StudentCourse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_CourseID",
                table: "StudentCourse",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_EntryYearID",
                table: "StudentCourse",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_SemesterID",
                table: "StudentCourse",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_ViewStudentCourse_ApplicationUserId",
                table: "ViewStudentCourse",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "InstructorRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InstructorRoleClaim_RoleId",
                table: "InstructorRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserClaim_ApplicationUserId",
                table: "InstructorUserClaim",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserClaim_UserId",
                table: "InstructorUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserLogin_ApplicationUserId",
                table: "InstructorUserLogin",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserLogin_UserId",
                table: "InstructorUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserRole_ApplicationUserId",
                table: "InstructorUserRole",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUserRole_RoleId",
                table: "InstructorUserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarryOverStudentCourse");

            migrationBuilder.DropTable(
                name: "InstructorCourse");

            migrationBuilder.DropTable(
                name: "MainStudentReesult");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "ViewStudentCourse");

            migrationBuilder.DropTable(
                name: "InstructorRoleClaim");

            migrationBuilder.DropTable(
                name: "InstructorUserClaim");

            migrationBuilder.DropTable(
                name: "InstructorUserLogin");

            migrationBuilder.DropTable(
                name: "InstructorUserRole");

            migrationBuilder.DropTable(
                name: "InstructorUserToken");

            migrationBuilder.DropTable(
                name: "GeneratedStudentCourse");

            migrationBuilder.DropTable(
                name: "InstructorRole");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "InstructorRegisterUser");

            migrationBuilder.DropTable(
                name: "EntryYear");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "Semester");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
