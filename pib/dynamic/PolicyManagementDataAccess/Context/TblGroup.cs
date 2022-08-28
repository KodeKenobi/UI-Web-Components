using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblGroup
    {
        public TblGroup()
        {
            TblDocuments = new HashSet<TblDocument>();
        }

        public int FldGroupId { get; set; }
        public string FldGroupName { get; set; }
        public string FldGroupDescription { get; set; }
        public int? FldGroupParent { get; set; }
        public bool? FldGroupIsactiveflag { get; set; }

        public virtual ICollection<TblDocument> TblDocuments { get; set; }
    }
}
