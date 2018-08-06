using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.ViewModels
{
    public class ViewStudentCourse
    {
        
        public int ViewStudentCourseID { get; set; }


        public string Semester { get; set; }
       

        public string Level { get; set; }

        public int Name { get; set; }

        public string FullName { get; set; }

        public string FindCollection { get; set; }


        public string EntryYear { get; set; }


        public string ApplicationUserId { get; set; }

      

        public ApplicationUser ApplicationUser { get; set; }

       

        
    }
}
