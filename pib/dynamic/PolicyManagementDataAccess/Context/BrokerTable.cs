using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerTable
    {
        public int? TableKey { get; set; }
        public string TableCode { get; set; }
        public string TableName { get; set; }
        public int? NextKey { get; set; }
        public bool? ImgLinkTf { get; set; }
    }
}
