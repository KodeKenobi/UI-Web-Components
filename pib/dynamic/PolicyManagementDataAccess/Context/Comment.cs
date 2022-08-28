using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class Comment
    {
        public Comment()
        {
            CommentLinks = new HashSet<CommentLink>();
        }

        public int CommentKey { get; set; }
        public string CmtHeading { get; set; }
        public string CmtSubject { get; set; }
        public string CmtText { get; set; }
        public string CmtReference { get; set; }
        public DateTime? CapDateTime { get; set; }
        public int? CapUserNum { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<CommentLink> CommentLinks { get; set; }
    }
}
