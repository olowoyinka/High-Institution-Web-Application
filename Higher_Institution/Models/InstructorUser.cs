using Higher_Institution.Models.Enum;
using Higher_Institution.Models.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models
{
    public class InstructorUser : IdentityUser
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


        public string AssignCourse { get; set; }


        public int DepartmentID { get; set; }

        public Department Department { get; set; }


        public ICollection<InstructorCourse> InstructorCourse { get; set; }

        public ICollection<CarryOverStudentCourse> CarryOverStudentCourse { get; set; }

        public ICollection<MainStudentReesult> MainStudentReesult { get; set; }

        public ICollection<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }

    }
}
