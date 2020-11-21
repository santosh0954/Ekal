using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class VCustomerOrderWithDetails
    {
        public int OrderDetailsId { get; set; }
        public int? OrderId { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? ItemId { get; set; }
        public string ItemName { get; set; }
        public short? Qty { get; set; }
        public string Unit { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
    }
}
