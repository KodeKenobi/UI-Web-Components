using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class CallMeBack
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string NearestBranch { get; set; }
        public string Product { get; set; }
        public string Comment { get; set; }
    }
}
