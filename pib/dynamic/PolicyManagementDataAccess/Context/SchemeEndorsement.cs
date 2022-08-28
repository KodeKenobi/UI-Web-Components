using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class SchemeEndorsement
    {
        public short EndorseKey { get; set; }
        public string EndorseNote { get; set; }
        public int? EndorseDate { get; set; }
        public int? SchemeNum { get; set; }
        public short? SchVersion { get; set; }

        public virtual Scheme Sch { get; set; }
    }
}
