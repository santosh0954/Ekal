using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstEkaiType
    {
        public MstEkaiType()
        {
            MstEkai = new HashSet<MstEkai>();
        }

        public short EkaiTypeId { get; set; }
        public string EkaiTypeName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<MstEkai> MstEkai { get; set; }
    }
}
