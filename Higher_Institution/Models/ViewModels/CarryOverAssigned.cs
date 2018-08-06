using Higher_Institution.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class CarryOverAssigned
    {
        public string ApplicationUserId { get; set; }

        public string ApplicationUserName { get; set; }

        public GradeEnum Grade { get; set; }

        public string ApplicationUserIdentityNumber { get; set; }

        public string FullName { get; set; }

        public int GeneratedStudentCourseID { get; set; }

        public string Departments { get; set; }

        public bool Assigned { get; set; }
    }
}
