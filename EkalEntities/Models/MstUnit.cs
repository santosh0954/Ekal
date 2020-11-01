using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstUnit
    {
        public short UnitId { get; set; }
        public string Unit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
