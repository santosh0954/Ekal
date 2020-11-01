using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstRegion
    {
        public short RegionId { get; set; }
        public string RegionName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
