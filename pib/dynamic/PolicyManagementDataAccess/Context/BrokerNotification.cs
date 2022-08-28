using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerNotification
    {
        public Guid Id { get; set; }
        public Guid UserNum { get; set; }
        public Guid CallMeBackId { get; set; }
        public string AmendRef { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
