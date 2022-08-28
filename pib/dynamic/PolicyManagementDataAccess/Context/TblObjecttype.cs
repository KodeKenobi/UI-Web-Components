using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblObjecttype
    {
        public TblObjecttype()
        {
            TblFunctions = new HashSet<TblFunction>();
        }

        public string FldObjectId { get; set; }
        public string FldObjectName { get; set; }
        public string FldObjectDescription { get; set; }
        public bool? FldObjectIsactiveflag { get; set; }

        public virtual ICollection<TblFunction> TblFunctions { get; set; }
    }
}
