using Higher_Institution.Models.Enum;
using Higher_Institution.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Higher_Institution.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string IdentityNumber { get; set; }

        public string Surname { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FullName { get; set; }

        public GenderEnum Gender { get; set; }

        public DateTime DateofBirth { get; set; }

        public StateEnum State { get; set; }

        public string Address { get; set; }

        public string ParentName { get; set; }

        public string ParentAddress { get; set; }

        public string Image { get; set; }




        public int DepartmentID { get; set; }

        public int EntryYearID { get; set; }

        public int SemesterID { get; set; }

        public int LevelID { get; set; }




        public Department Department { get; set; }

        public EntryYear EntryYear { get; set; }

        public Semester Semester { get; set; }

        public Level Level { get; set; }


        


        public ICollection<StudentCourse> StudentCourse { get; set; }

        public ICollection<CarryOverStudentCourse> CarryOverStudentCourse { get; set; }

        public ICollection<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }

        public ICollection<ViewStudentCourse> ViewStudentCourse { get; set; }
    }
}
