using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class TblFunction
    {
        public string FldFunctionId { get; set; }
        public string FldFunctionKey { get; set; }
        public string FldFunctionName { get; set; }
        public string FldFunctionDescription { get; set; }
        public string FldObjectId { get; set; }
        public string FldFunctionCrud { get; set; }
        public int? FldFunctionOrder { get; set; }

        public virtual TblObjecttype FldObject { get; set; }
    }
}
