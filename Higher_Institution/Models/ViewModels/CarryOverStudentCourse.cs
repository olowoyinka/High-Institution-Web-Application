using Higher_Institution.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class CarryOverStudentCourse
    {
        public int CarryOverStudentCourseID { get; set; }

        //[Required]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        //[Display(Name = "Generated StudentCourse")]
        //public int GeneratedStudentCourseID { get; set; }

        //[Required]
        [Display(Name = "Student")]
        public string ApplicationUserId { get; set; }

        public string FullName { get; set; }

        public string InstructorUserId { get; set; }

        public string ApplicationIdCourseName { get; set; }

        public string ApplicationIdSemesterGrade { get; set; }


        [Display(Name = "Entry Year")]
        public int EntryYearID { get; set; }

        [Display(Name = "Semester")]
        public int SemesterID { get; set; }


        [Display(Name = "Grade")]
        public GradeEnum Grade { get; set; }


        public Course Course { get; set; }

        public Semester Semester { get; set; }

        public EntryYear EntryYear { get; set; }

        public InstructorUser Instructor { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public GeneratedStudentCourse GeneratedStudentCourse { get; set; }
    }
}
