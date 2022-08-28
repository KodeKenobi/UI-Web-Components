using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PolicyManagementModels.Policy;

namespace PolicyManagementModels.PrincipalMemberDetails
{
    public class AddPrincipalMemberDetails
    {
        [Required(ErrorMessage = "Secondary Contact Name is required")]
        public string ContactPerson { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        public string Title { get; set; }
        //[Required(ErrorMessage = "Secondary Contact Name is required")]
        public string MaritalStatus { get; set; }
        public int? CoverID { get; set; }
       /// [Required(ErrorMessage = "Contact Phone Name is required")]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage = "ID Number is required")]
        public string Idnum { get; set; }
        [Required(ErrorMessage = "Contact Cell is a required")]
        public string ContactCell { get; set; }
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string ContactEmail { get; set; }
        public string UserID { get; set; }
        public string CaptureDate { get; set; }
        public int UserNum { get; set; }
       
    }
}
