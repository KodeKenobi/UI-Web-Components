using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class CommentLink
    {
        public int LinkKey { get; set; }
        public int? NumLnkKey { get; set; }
        public string AlphaLnkKey { get; set; }
        public string CmtLnkType { get; set; }
        public int? CommentKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual Comment CommentKeyNavigation { get; set; }
    }
}
