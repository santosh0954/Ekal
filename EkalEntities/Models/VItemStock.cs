using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VItemStock
    {
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? TotalQty { get; set; }
    }
}
