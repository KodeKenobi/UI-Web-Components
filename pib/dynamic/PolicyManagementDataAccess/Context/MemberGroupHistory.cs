using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberGroupHistory
    {
        public int MemGrpId { get; set; }
        public int MemGrpNum { get; set; }
        public string InsRef { get; set; }
        public string FldRef { get; set; }
        public int? CaptureDate { get; set; }
        public int? AppDate { get; set; }
        public int? TakeOnDate { get; set; }
        public int? SuspendDate { get; set; }
        public int? ReInstateDate { get; set; }
        public byte? ActiveTf { get; set; }
        public string ContactPerson { get; set; }
        public string ContactPhone { get; set; }
        public string ContactCell { get; set; }
        public string ContactEmail { get; set; }
        public string StrAddress1 { get; set; }
        public string StrAddress2 { get; set; }
        public string StrAddress3 { get; set; }
        public string StrAddress4 { get; set; }
        public string PstAddress1 { get; set; }
        public string PstAddress2 { get; set; }
        public string PstAddress3 { get; set; }
        public string PostalCode { get; set; }
        public string CanReason { get; set; }
        public int? MemColKey { get; set; }
        public int? MemPropKey { get; set; }
        public string InsInterest { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }
        public int? NewAppDate { get; set; }
    }
}
