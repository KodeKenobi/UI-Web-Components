using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolicyManagementDataAccess.Context
{
   public class PrincipalMember
    {
        public int PrincipalMemberID { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        //[Required(ErrorMessage = "Secondary Contact Name is required")]
        public string MaritalStatus { get; set; }
        public int? CoverId { get; set; }
     
        public string ContactPhone { get; set; }
       
        public string Idnum { get; set; }
     
        public string ContactCell { get; set; }
      
        public string ContactEmail { get; set; }
    }
}
