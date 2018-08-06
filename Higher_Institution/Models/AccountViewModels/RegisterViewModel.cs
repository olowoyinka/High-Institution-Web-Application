using Higher_Institution.Models.Enum;
using Higher_Institution.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Higher_Institution.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Identity Number")]
        public string IdentityNumber { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Surname + " " + FirstName + " " + MiddleName;
            }
        }

        [Required]
        [Display(Name = "Gender")]
        public GenderEnum Gender { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateofBirth { get; set; }

        [Required]
        [Display(Name = "State of Origin")]
        public StateEnum State { get; set; }

        [Required]
        [Display(Name = "Address/Resident")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Parent's/Mentor Name")]
        public string ParentName { get; set; }

        [Required]
        [Display(Name = "Parent's/Mentor Address")]
        public string ParentAddress { get; set; }

        //[Required]
        [Display(Name = "Upload Profile Picture")]
        public string AvatarImage { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        //[DataType(DataType.Password)]
        // [Display(Name = "Password")]
        //public string Password { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm password")]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        //public string ConfirmPassword { get; set; }


        [Required]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        [Required]
        [Display(Name = "Entry Year")]
        public int EntryYearID { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public int SemesterID { get; set; }

        [Required]
        [Display(Name = "Level")]
        public int LevelID { get; set; }




        public Department Department { get; set; }

        public EntryYear EntryYear { get; set; }

        public Semester Semester { get; set; }

        public Level Level { get; set; }



        public ICollection<StudentCourse> StudentCourse { get; set; }

        public ICollection<GeneratedStudentCourse> GeneratedStudentCourse { get; set; }

        public ICollection<ViewStudentCourse> ViewStudentCourse { get; set; }
    }
}
