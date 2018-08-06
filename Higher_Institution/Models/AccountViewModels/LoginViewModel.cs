using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Higher_Institution.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Identity Number")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password/Surname")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
