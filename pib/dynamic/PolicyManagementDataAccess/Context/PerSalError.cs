using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class PerSalError
    {
        public int? ErrorKey { get; set; }
        public string ErrorDescript { get; set; }
        public string ErrorAction { get; set; }
    }
}
