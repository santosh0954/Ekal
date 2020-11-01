using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstEkai
    {
        public int EkaiId { get; set; }
        public string EkaiName { get; set; }
        public short? EkaiTypeId { get; set; }
        public int? ParentEkaiId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
