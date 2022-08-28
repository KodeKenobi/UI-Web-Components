using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblDocument
    {
        public int FldDocumentId { get; set; }
        public int? FldPolicyId { get; set; }
        public string FldDocumentName { get; set; }
        public string FldDocumentUri { get; set; }
        public string FldDocumentFilename { get; set; }
        public byte[] FldDocumentBytes { get; set; }
        public string FldDocumentType { get; set; }
        public int? FldGroupId { get; set; }
        public string FldDocumentDescription { get; set; }
        public bool? FldDocumentIsactiveflag { get; set; }
        public DateTime FldDocumentDatecreated { get; set; }
        public string FldDocumetCreatedby { get; set; }
        public DateTime? FldDocumentDateaccessed { get; set; }
        public string FldDocumetAccessedby { get; set; }

        public virtual TblGroup FldGroup { get; set; }
    }
}
