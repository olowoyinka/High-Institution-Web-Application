using Higher_Institution.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class MainStudentReesult
    {
        public int MainStudentReesultID { get; set; }

        //[Required]
        [Display(Name = "Course")]
        public int CourseID { get; set; }

        //[Required]
        [Display(Name = "Student")]
        public string ApplicationUserId { get; set; }

        public string FullName { get; set; }

        public string ApplicationIdCourseId { get; set; }

        public string InstructorUserId { get; set; }

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
    }
}
