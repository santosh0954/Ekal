﻿using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnItemStock
    {
        public int ItemStockId { get; set; }
        public int? ItemId { get; set; }
        public decimal? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? TotalAmount { get; set; }
        public int? ItemProviderId { get; set; }
        public int? EkaiId { get; set; }
        public string Status { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstItems Item { get; set; }
        public virtual TxnItemProvider ItemProvider { get; set; }
    }
}
