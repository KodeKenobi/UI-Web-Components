﻿using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblSmstest
    {
        public long FldId { get; set; }
        public string FldType { get; set; }
        public string FldFrom { get; set; }
        public string FldTo { get; set; }
        public string FldBody { get; set; }
        public DateTime? FldDate { get; set; }
        public string FldStatus { get; set; }
    }
}
