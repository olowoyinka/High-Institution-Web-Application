using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class AssignedCourseData
    {
        public int CourseID { get; set; }

        public string Names { get; set; }

        public string CourseCode { get; set; }

        public string Levels { get; set; }

        public string FullName { get; set; }

        public string Semesters { get; set; }

        public string Departments { get; set; }

        public int CarryIdentity { get; set; }

        public bool Assigned { get; set; }
    }
}
