using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblEvent
    {
        public int FldEventId { get; set; }
        public int FldEventObjectid { get; set; }
        public string FldEventLevel { get; set; }
        public string FldEventFunctionid { get; set; }
        public string FldEventDescription { get; set; }
        public string FldEventSqlscript { get; set; }
        public DateTime FldEventDatelogged { get; set; }
        public int FldEventLoggedby { get; set; }
        public string FldEventComputer { get; set; }
    }
}
