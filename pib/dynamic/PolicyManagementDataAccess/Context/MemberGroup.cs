using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class MemberGroup
    {
        public MemberGroup()
        {
            ImageLinks = new HashSet<ImageLink>();
            MemberDetails = new HashSet<MemberDetail>();
            ProductPerAgents = new HashSet<ProductPerAgent>();
            TblSales = new HashSet<TblSale>();
        }

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
        public string MiddleName { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public string MaritalStatus { get; set; }
        public int? CoverId { get; set; }
        public string ContactPhone { get; set; }
        public string Idnum { get; set; }
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
        public Guid? UserId { get; set; }
        public DateTime? UserDateTime { get; set; }
        public int? NewAppDate { get; set; }
        public string EasyPayNum { get; set; }
        public bool? GeneratedOnline { get; set; }
        public virtual MemberCollect MemColKeyNavigation { get; set; }
        public virtual MemberProposer MemPropKeyNavigation { get; set; }
        public virtual ICollection<ImageLink> ImageLinks { get; set; }
        public virtual ICollection<MemberDetail> MemberDetails { get; set; }
        public virtual ICollection<ProductPerAgent> ProductPerAgents { get; set; }
        public virtual ICollection<TblSale> TblSales { get; set; }
    }
}
