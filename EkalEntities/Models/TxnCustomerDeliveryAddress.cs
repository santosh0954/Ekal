using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnCustomerDeliveryAddress
    {
        public int CustomerDeliveryAddressId { get; set; }
        public int? CustomerId { get; set; }
        public string AddressType { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string StateCode { get; set; }
        public string DistrictCode { get; set; }
        public string Tehsil { get; set; }
        public string Pincode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual TxnCustomer Customer { get; set; }
    }
}
