using PolicyManagementDataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PolicyManagementModels;
using PolicyManagementModels.Users;

namespace PolicyManagementSystem.Controllers.Models
{
    public class ApplicantRegistrationViewModel
    {
        public MemberApplication MemberApplication { get; set; }
        //Intergrate the new model  in old one
        public CreateAddressModel CreateAddressModel { get; set; }
        public RegisterModel RegisterModel { get; set; }
        public List<MemberApplication> MemberApplications { get; set; }

        public MemberApplication AspNetUsers { get; set; }
        public string Password { get; set; }
    }
}
