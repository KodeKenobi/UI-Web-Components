using System;
using System.Collections.Generic;

#nullable disable

namespace PolicyManagementDataAccess.Context
{
    public partial class BrokerImage
    {
        public BrokerImage()
        {
            ImageLinks = new HashSet<ImageLink>();
        }

        public int ImageKey { get; set; }
        public string ImgDescript { get; set; }
        public string ImgReference1 { get; set; }
        public string ImgReference2 { get; set; }
        public int? UserNum { get; set; }
        public DateTime? UserDateTime { get; set; }

        public virtual ICollection<ImageLink> ImageLinks { get; set; }
    }
}
