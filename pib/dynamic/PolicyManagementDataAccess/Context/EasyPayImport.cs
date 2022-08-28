using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class EasyPayImport
    {
        public int ImportId { get; set; }
        public string FileName { get; set; }
        public int? FileGenNum { get; set; }
        public short? EasyPayCode { get; set; }
        public string UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
    }
}
