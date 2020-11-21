using System;
using System.Collections.Generic;

namespace EkalEntities.Models
{
    public partial class TxnCustomer
    {
        public TxnCustomer()
        {
            TxnCustomerDeliveryAddress = new HashSet<TxnCustomerDeliveryAddress>();
            TxnCustomerOrder = new HashSet<TxnCustomerOrder>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string AltMobileNo { get; set; }
        public string EMail { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string StateCode { get; set; }
        public string DistrictCode { get; set; }
        public string Tehsil { get; set; }
        public string Pincode { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }

        public virtual ICollection<TxnCustomerDeliveryAddress> TxnCustomerDeliveryAddress { get; set; }
        public virtual ICollection<TxnCustomerOrder> TxnCustomerOrder { get; set; }
    }
}
