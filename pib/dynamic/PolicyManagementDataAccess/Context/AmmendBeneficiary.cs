using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class AmmendBeneficiary
    {
        public int BeneficiaryId { get; set; }
        public int MemGrpNum { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string Alias { get; set; }
        public int? BenPerc { get; set; }
        public string Idnum { get; set; }
        public int? Dob { get; set; }
        public string Pst1 { get; set; }
        public string Pst2 { get; set; }
        public string Pst3 { get; set; }
        public decimal? Code { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BenNum { get; set; }
        public int? UserNum { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
