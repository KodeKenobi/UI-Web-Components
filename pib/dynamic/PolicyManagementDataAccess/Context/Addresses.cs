using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PolicyManagementDataAccess.Context
{
    public partial class Addresses
    {
        [Key]
        public int AddressID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public AddressType  AddressType { get; set; }
        public string AddressName { get; set; }
        public int MemDetNum { get; set; }
        [ForeignKey("MemDetNum")]
        public MemberApplication MemberApplication { get; set; }


    }
}
