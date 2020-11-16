using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnCustomerOrder
    {
        public TxnCustomerOrder()
        {
            TxnCustomerOrderDetails = new HashSet<TxnCustomerOrderDetails>();
        }

        public int CustomerOrderId { get; set; }
        public int? CustomerId { get; set; }
        public string OrderNo { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ExpectedDeliveryDate { get; set; }
        public DateTime? ActualDeliveryDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TxnCustomer Customer { get; set; }
        public virtual ICollection<TxnCustomerOrderDetails> TxnCustomerOrderDetails { get; set; }
    }
}
