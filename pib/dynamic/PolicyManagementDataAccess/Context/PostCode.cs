using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PostCode
    {
        public string PostalCode { get; set; }
        public string Province { get; set; }
        public string Area { get; set; }
        public string Area2 { get; set; }
    }
}
