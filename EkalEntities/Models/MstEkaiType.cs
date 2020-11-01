using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstEkaiType
    {
        public short EkaiTypeId { get; set; }
        public string EkaiTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
