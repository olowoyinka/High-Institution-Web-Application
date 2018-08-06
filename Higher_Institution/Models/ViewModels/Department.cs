using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Higher_Institution.Models.ViewModels
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }


        public ICollection<ApplicationUser> ApplicationUser { get; set; }

        public ICollection<Course> Course { get; set; }

        public ICollection<InstructorUser> Instructor { get; set; }
    }
}
