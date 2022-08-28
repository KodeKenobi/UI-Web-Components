using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class RelativeCover
    {
        public short? RelationKey { get; set; }
        public int? CoverKey { get; set; }
        public short? CvrVersion { get; set; }

        public virtual BenefitCover C { get; set; }
        public virtual Relation RelationKeyNavigation { get; set; }
    }
}
