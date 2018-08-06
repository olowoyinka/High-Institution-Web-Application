using Higher_Institution.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.InstructorViewModels
{
    public class InstructorIndexData
    {
        public InstructorUser InstructorUser { get; set; }

        public AssignedCourseData EditProfile { get; set; }

        public Course Course { get; set; }

        public IEnumerable<Course> Courses { get; set; }

        public IEnumerable<GeneratedStudentCourse> GeneratedStudentCoursess { get; set; }

        public IList<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }

        //public GeneratedStudentCourse GeneratedStudentCoursesss { get; set; }
    }
}
