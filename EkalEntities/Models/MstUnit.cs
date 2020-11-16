using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstUnit
    {
        public MstUnit()
        {
            MstItems = new HashSet<MstItems>();
        }

        public short UnitId { get; set; }
        public string Unit { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<MstItems> MstItems { get; set; }
    }
}
