using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnCustomerOrderDetails
    {
        public int OrderDetailsId { get; set; }
        public int? OrderId { get; set; }
        public int? ItemId { get; set; }
        public short? Qty { get; set; }
        public decimal? Rate { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual MstItems Item { get; set; }
        public virtual TxnCustomerOrder Order { get; set; }
    }
}
