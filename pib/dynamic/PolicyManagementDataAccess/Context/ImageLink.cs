using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class ImageLink
    {
        public int LinkKey { get; set; }
        public int? NumLnkKey { get; set; }
        public string AlphaLnkKey { get; set; }
        public string ImgLnkType { get; set; }
        public int? ImageKey { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual BrokerImage ImageKeyNavigation { get; set; }
        public virtual MemberGroup NumLnkKey1 { get; set; }
        public virtual InsPlan NumLnkKey2 { get; set; }
        public virtual Receipt NumLnkKey3 { get; set; }
        public virtual Agent NumLnkKeyNavigation { get; set; }
    }
}
