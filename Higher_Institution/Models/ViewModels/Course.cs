using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class Course
    {
        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [Display(Name = "Level")]
        public string Level { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public string Semester { get; set; }

        [Display(Name = "Full Name")]
        public string Full
        {
            get
            {
                return DepartmentID + " " + Semester + " " + Level;
            }

        }

        public string FullName { get; set; }

        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        public Department Department { get; set; }

        public ICollection<StudentCourse> StudentCourse { get; set; }

        public IList<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }

        public ICollection<InstructorCourse> InstructorCourse { get; set; }

    }
}
