using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PolicyManagementSystem.Controllers.Models
{
    public class ForgotPasswordViewModel
    {
        //public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Display(Name = "Registered email address")]
        public bool RememberMe { get; set; }
    }
}
