using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Higher_Institution.Migrations
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
                name: "StudentRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "InstructorUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    AssignCourse = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IdentityNumber = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
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
                    State = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstructorUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstructorUser_Department_DepartmentID",
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
                name: "StudentUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DateofBirth = table.Column<DateTime>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
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
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
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
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUser_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUser_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUser_Level_LevelID",
                        column: x => x.LevelID,
                        principalTable: "Level",
                        principalColumn: "LevelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUser_Semester_SemesterID",
                        column: x => x.SemesterID,
                        principalTable: "Semester",
                        principalColumn: "SemesterID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRoleClaim",
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
                    table.PrimaryKey("PK_StudentRoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentRoleClaim_StudentRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "StudentRole",
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
                        name: "FK_InstructorCourse_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
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
                        name: "FK_GeneratedStudentCourse_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
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
                        name: "FK_GeneratedStudentCourse_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
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
                        name: "FK_MainStudentReesult_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
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
                        name: "FK_MainStudentReesult_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
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
                name: "Scores",
                columns: table => new
                {
                    ScoresID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    CourseID = table.Column<int>(nullable: false),
                    EntryYearID = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Grade = table.Column<int>(nullable: false),
                    SemesterID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoresID);
                    table.ForeignKey(
                        name: "FK_Scores_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scores_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "CourseID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_EntryYear_EntryYearID",
                        column: x => x.EntryYearID,
                        principalTable: "EntryYear",
                        principalColumn: "EntryYearID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Scores_Semester_SemesterID",
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
                        name: "FK_StudentCourse_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
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
                        name: "FK_ViewStudentCourse_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    InstructorUserId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentUserClaim_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserClaim_StudentUser_UserId",
                        column: x => x.UserId,
                        principalTable: "StudentUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_StudentUserLogin_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserLogin_StudentUser_UserId",
                        column: x => x.UserId,
                        principalTable: "StudentUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentUserRole",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false),
                    InstructorUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentUserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_StudentUserRole_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentUserRole_StudentRole_RoleId",
                        column: x => x.RoleId,
                        principalTable: "StudentRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentUserRole_StudentUser_UserId",
                        column: x => x.UserId,
                        principalTable: "StudentUser",
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
                        name: "FK_CarryOverStudentCourse_StudentUser_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "StudentUser",
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
                        name: "FK_CarryOverStudentCourse_InstructorUser_InstructorUserId",
                        column: x => x.InstructorUserId,
                        principalTable: "InstructorUser",
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
                name: "IX_StudentUser_DepartmentID",
                table: "StudentUser",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUser_EntryYearID",
                table: "StudentUser",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUser_LevelID",
                table: "StudentUser",
                column: "LevelID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "StudentUser",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "StudentUser",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentUser_SemesterID",
                table: "StudentUser",
                column: "SemesterID");

            migrationBuilder.CreateIndex(
                name: "IX_InstructorUser_DepartmentID",
                table: "InstructorUser",
                column: "DepartmentID");

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
                name: "IX_Scores_ApplicationUserId",
                table: "Scores",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_CourseID",
                table: "Scores",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_EntryYearID",
                table: "Scores",
                column: "EntryYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_SemesterID",
                table: "Scores",
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
                table: "StudentRole",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentRoleClaim_RoleId",
                table: "StudentRoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserClaim_InstructorUserId",
                table: "StudentUserClaim",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserClaim_UserId",
                table: "StudentUserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserLogin_InstructorUserId",
                table: "StudentUserLogin",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserLogin_UserId",
                table: "StudentUserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserRole_InstructorUserId",
                table: "StudentUserRole",
                column: "InstructorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentUserRole_RoleId",
                table: "StudentUserRole",
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
                name: "Scores");

            migrationBuilder.DropTable(
                name: "StudentCourse");

            migrationBuilder.DropTable(
                name: "ViewStudentCourse");

            migrationBuilder.DropTable(
                name: "StudentRoleClaim");

            migrationBuilder.DropTable(
                name: "StudentUserClaim");

            migrationBuilder.DropTable(
                name: "StudentUserLogin");

            migrationBuilder.DropTable(
                name: "StudentUserRole");

            migrationBuilder.DropTable(
                name: "StudentUserToken");

            migrationBuilder.DropTable(
                name: "GeneratedStudentCourse");

            migrationBuilder.DropTable(
                name: "StudentRole");

            migrationBuilder.DropTable(
                name: "StudentUser");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "InstructorUser");

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
