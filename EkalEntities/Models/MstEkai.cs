using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstEkai
    {
        public MstEkai()
        {
            TxnVolunteer = new HashSet<TxnVolunteer>();
        }

        public int EkaiId { get; set; }
        public string EkaiName { get; set; }
        public short? EkaiTypeId { get; set; }
        public int? ParentEkaiId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstEkaiType EkaiType { get; set; }
        public virtual ICollection<TxnVolunteer> TxnVolunteer { get; set; }
    }
}
