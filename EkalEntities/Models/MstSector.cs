using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstSector
    {
        public short SectorId { get; set; }
        public string SectorName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
