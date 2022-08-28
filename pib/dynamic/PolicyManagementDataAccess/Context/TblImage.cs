using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblImage
    {
        public int FldImageId { get; set; }
        public int FldCompanyId { get; set; }
        public string FldImageName { get; set; }
        public string FldImagePath { get; set; }
        public string FldImageExtension { get; set; }
        public string FldImageSize { get; set; }
        public byte[] FldImageByte { get; set; }
        public DateTime? FldImageDatecreated { get; set; }
        public int? FldImageCreatedby { get; set; }
    }
}
