using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class InstructorCourse
    {
        public int InstructorCourseID { get; set; }

        public string InstructorUserId { get; set; }

        public int CourseID { get; set; }

        public InstructorUser Instructor { get; set; }

        public Course Course { get; set; }

    }
}
