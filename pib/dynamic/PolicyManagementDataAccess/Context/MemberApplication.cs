using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberApplication
    {
        public int MemDetNum { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string MaidenName { get; set; }
        public string Idnum { get; set; }
        public DateTime? Dob { get; set; }
        public string Occupation { get; set; }
        public string Sex { get; set; }
        public DateTime? UserDateTime { get; set; }
        public bool? ProfileConfirmed { get; set; }

    }
}
