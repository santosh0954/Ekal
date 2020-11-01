using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class MstItems
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public short? UnitId { get; set; }
        public bool? IsProductionRequired { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
    }
}
